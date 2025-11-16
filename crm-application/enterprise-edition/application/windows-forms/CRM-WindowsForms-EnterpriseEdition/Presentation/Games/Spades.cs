using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRM.Presentation.Games
{
    public partial class Spades : Form
    {
        private enum Difficulty { Easy, Medium, Hard }
        private enum GamePhase { Bidding, Playing }
        private enum AnimationType { CardPlay, TrickCollection, Dealing }

        private Difficulty aiDifficulty = Difficulty.Medium;
        private GamePhase currentPhase = GamePhase.Bidding;

        private List<Player> players = new();
        private int currentPlayerIndex = 0;
        private List<(int player, Card card)> trick = new();
        private Dictionary<int, int> scores = new();
        private Dictionary<int, int> bags = new();
        private Dictionary<int, int> bids = new();
        private Dictionary<int, int> tricksWon = new();
        private bool spadesBroken = false;

        // Animation
        private System.Windows.Forms.Timer animationTimer = null!;
        private List<AnimatedCard> animatedCards = new();
        private Action? animationOnComplete = null;
        private AnimationType currentAnimationType = AnimationType.CardPlay;
        private int trickWinner = -1;

        // Card graphics
        private const int CardWidth = 60;
        private const int CardHeight = 90;
        private const int CardSpacing = 20;
        private const int TableCenterY = 300;
        private const int HandTop = 500;
        private const int TableCenterX = 450;

        // UI
        private ComboBox difficultyComboBox = null!;
        private Button newGameButton = null!;
        private Label trickLabel = null!;
        private Label scoreLabel = null!;
        private Label phaseLabel = null!;
        private NumericUpDown bidControl = null!;
        private Button bidButton = null!;
        private Label statusLabel = null!;

        public Spades()
        {
            InitializeComponent();
            DoubleBuffered = true;
            InitializeGameUI();
            StartNewGame();
        }

        private void InitializeGameUI()
        {
            this.Size = new Size(1000, 650);
            this.BackColor = Color.DarkGreen;

            difficultyComboBox = new ComboBox
            {
                Location = new Point(20, 20),
                Width = 120,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            difficultyComboBox.Items.AddRange(new[] { "Easy", "Medium", "Hard" });
            difficultyComboBox.SelectedIndex = 1;
            difficultyComboBox.SelectedIndexChanged += (s, e) =>
            {
                aiDifficulty = (Difficulty)difficultyComboBox.SelectedIndex;
            };
            Controls.Add(difficultyComboBox);

            newGameButton = new Button
            {
                Text = "New Game",
                Location = new Point(160, 20),
                Width = 100,
                Height = 30,
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.Control
            };
            newGameButton.Click += (s, e) => StartNewGame();
            Controls.Add(newGameButton);

            phaseLabel = new Label
            {
                Location = new Point(20, 60),
                Size = new Size(700, 30),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };
            Controls.Add(phaseLabel);

            trickLabel = new Label
            {
                Location = new Point(20, 90),
                Size = new Size(700, 30),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };
            Controls.Add(trickLabel);

            scoreLabel = new Label
            {
                Location = new Point(20, 120),
                Size = new Size(900, 30),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };
            Controls.Add(scoreLabel);

            statusLabel = new Label
            {
                Location = new Point(20, 150),
                Size = new Size(700, 30),
                Font = new Font("Segoe UI", 11, FontStyle.Italic),
                ForeColor = Color.Yellow,
                BackColor = Color.Transparent,
                Text = ""
            };
            Controls.Add(statusLabel);

            bidControl = new NumericUpDown
            {
                Location = new Point(20, 190),
                Width = 80,
                Minimum = 0,
                Maximum = 13,
                Value = 0,
                Visible = false,
                Font = new Font("Segoe UI", 11)
            };
            Controls.Add(bidControl);

            bidButton = new Button
            {
                Text = "Make Bid",
                Location = new Point(110, 190),
                Width = 100,
                Height = 30,
                Visible = false,
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.Control
            };
            bidButton.Click += BidButton_Click;
            Controls.Add(bidButton);

            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 16; // ~60 FPS for smoother animation
            animationTimer.Tick += AnimationTimer_Tick;

            this.Paint += Spades_Paint;
            this.MouseClick += Spades_MouseClick;
        }

        private void StartNewGame()
        {
            currentPhase = GamePhase.Bidding;
            spadesBroken = false;

            players.Clear();
            for (int i = 0; i < 4; i++)
                players.Add(new Player { IsHuman = i == 0, Name = i == 0 ? "You" : $"AI {i}", Hand = new List<Card>() });

            scores = players.ToDictionary(p => players.IndexOf(p), p => 0);
            bags = players.ToDictionary(p => players.IndexOf(p), p => 0);
            bids.Clear();
            tricksWon.Clear();

            DealCards();
            currentPlayerIndex = 0;
            trick.Clear();
            animatedCards.Clear();
            animationOnComplete = null;
            trickWinner = -1;

            bidControl.Value = 0;
            bidControl.Visible = true;
            bidButton.Visible = true;
            phaseLabel.Text = "Bidding Phase - Select your bid";
            statusLabel.Text = "Review your hand and make your bid";

            DelayedAction(300, () => ProcessBidding());

            Invalidate();
        }

        private void DealCards()
        {
            var deck = Card.GetDeck();
            var rnd = new Random();
            deck = deck.OrderBy(_ => rnd.Next()).ToList();
            for (int i = 0; i < 52; i++)
                players[i % 4].Hand.Add(deck[i]);
            foreach (var p in players)
                p.Hand = p.Hand.OrderBy(c => c.Suit).ThenBy(c => c.Rank).ToList();
        }

        private void ProcessBidding()
        {
            // AI players make their bids
            for (int i = 1; i < 4; i++)
            {
                if (!bids.ContainsKey(i))
                {
                    bids[i] = CalculateAIBid(players[i]);
                    tricksWon[i] = 0;
                }
            }
            UpdateBiddingDisplay();
            Invalidate();
        }

        private int CalculateAIBid(Player ai)
        {
            int bid = 0;
            var spades = ai.Hand.Where(c => c.Suit == "Spades").ToList();
            var highSpades = spades.Where(c => c.Rank >= 11).Count();
            var otherAces = ai.Hand.Where(c => c.Suit != "Spades" && c.Rank == 14).Count();
            var otherKings = ai.Hand.Where(c => c.Suit != "Spades" && c.Rank == 13).Count();

            if (aiDifficulty == Difficulty.Hard)
            {
                // Count likely winners
                bid += highSpades;
                bid += otherAces;

                // Add half of other high cards
                bid += otherKings / 2;

                // Add based on long spades
                if (spades.Count >= 5)
                    bid += 1;
                if (spades.Count >= 7)
                    bid += 1;
            }
            else if (aiDifficulty == Difficulty.Medium)
            {
                bid += highSpades;
                bid += otherAces;
                if (spades.Count >= 5)
                    bid += 1;
            }
            else // Easy
            {
                bid = spades.Count / 3;
                if (bid < 1) bid = 1;
            }

            return Math.Max(1, Math.Min(13, bid));
        }

        private void BidButton_Click(object? sender, EventArgs e)
        {
            bids[0] = (int)bidControl.Value;
            tricksWon[0] = 0;
            bidControl.Visible = false;
            bidButton.Visible = false;

            currentPhase = GamePhase.Playing;
            phaseLabel.Text = "Playing Phase";
            statusLabel.Text = $"{players[currentPlayerIndex].Name}'s turn";
            UpdateBiddingDisplay();
            Invalidate();

            if (!players[currentPlayerIndex].IsHuman)
                PlayAITurn();
        }

        private void UpdateBiddingDisplay()
        {
            string bidText = "Bids: ";
            for (int i = 0; i < 4; i++)
            {
                if (bids.ContainsKey(i))
                    bidText += $"{players[i].Name}: {bids[i]}  ";
                else
                    bidText += $"{players[i].Name}: ?  ";
            }
            trickLabel.Text = bidText;
        }

        private void Spades_MouseClick(object? sender, MouseEventArgs e)
        {
            if (animatedCards.Count > 0 || currentPhase == GamePhase.Bidding)
                return;

            if (!players[currentPlayerIndex].IsHuman)
                return;

            var hand = players[0].Hand;
            for (int i = 0; i < hand.Count; i++)
            {
                int x = TableCenterX - (hand.Count * CardWidth + (hand.Count - 1) * CardSpacing) / 2 + i * (CardWidth + CardSpacing);
                int y = HandTop;
                var rect = new Rectangle(x, y, CardWidth, CardHeight);
                if (rect.Contains(e.Location))
                {
                    if (IsValidPlay(hand[i]))
                    {
                        PlayCard(0, hand[i]);
                    }
                    else
                    {
                        statusLabel.Text = "Invalid play - check Spades rules!";
                        statusLabel.ForeColor = Color.Red;
                        DelayedAction(2000, () => 
                        {
                            statusLabel.ForeColor = Color.Yellow;
                            statusLabel.Text = $"{players[currentPlayerIndex].Name}'s turn";
                        });
                    }
                    break;
                }
            }
        }

        private bool IsValidPlay(Card card)
        {
            var hand = players[0].Hand;
            
            if (trick.Count == 0)
            {
                // Leading: can't lead spades unless broken or only spades left
                if (card.Suit == "Spades")
                {
                    if (spadesBroken) return true;
                    return hand.All(c => c.Suit == "Spades");
                }
                return true;
            }

            var leadSuit = trick[0].card.Suit;

            // Must follow suit if possible
            if (card.Suit == leadSuit) return true;

            // Can play any card if can't follow suit
            return !hand.Any(c => c.Suit == leadSuit);
        }

        private void PlayAITurn()
        {
            if (players[currentPlayerIndex].Hand.Count == 0)
                return;

            var ai = players[currentPlayerIndex];
            var validCards = GetValidCards(ai, trick);
            Card aiCard = aiDifficulty switch
            {
                Difficulty.Easy => validCards.First(),
                Difficulty.Medium => ChooseMediumAICard(ai, validCards),
                Difficulty.Hard => ChooseHardAICard(ai, validCards),
                _ => validCards.First()
            };

            DelayedAction(600, () => PlayCard(currentPlayerIndex, aiCard));
        }

        private void DelayedAction(int milliseconds, Action action)
        {
            var timer = new System.Windows.Forms.Timer { Interval = milliseconds };
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                timer.Dispose();
                action();
            };
            timer.Start();
        }

        private List<Card> GetValidCards(Player player, List<(int player, Card card)> currentTrick)
        {
            var hand = player.Hand;
            
            if (currentTrick.Count == 0)
            {
                // Leading: can't lead spades unless broken or only spades left
                if (!spadesBroken && hand.Any(c => c.Suit != "Spades"))
                    return hand.Where(c => c.Suit != "Spades").ToList();
                return hand;
            }

            var leadSuit = currentTrick[0].card.Suit;
            var valid = hand.Where(c => c.Suit == leadSuit).ToList();
            return valid.Any() ? valid : hand;
        }

        private Card ChooseMediumAICard(Player ai, List<Card> validCards)
        {
            int currentTricks = tricksWon[players.IndexOf(ai)];
            int targetBid = bids[players.IndexOf(ai)];

            // If we need more tricks, try to win
            if (currentTricks < targetBid)
            {
                if (trick.Count > 0)
                {
                    var leadSuit = trick[0].card.Suit;
                    var currentWinner = GetCurrentTrickWinner();
                    var winningCard = trick.First(t => t.player == currentWinner).card;
                    
                    // Try to beat the current winner
                    var canWin = validCards.Where(c => CanBeat(c, winningCard, leadSuit)).ToList();
                    if (canWin.Any())
                        return canWin.OrderBy(c => c.Rank).First(); // Play lowest winning card
                }
                else
                {
                    // Leading, play high card
                    return validCards.OrderByDescending(c => c.Rank).First();
                }
            }

            // Otherwise, play lowest card
            return validCards.OrderBy(c => c.Rank).First();
        }

        private Card ChooseHardAICard(Player ai, List<Card> validCards)
        {
            int playerIndex = players.IndexOf(ai);
            int currentTricks = tricksWon[playerIndex];
            int targetBid = bids[playerIndex];

            if (trick.Count == 0)
            {
                // Leading
                if (currentTricks < targetBid)
                {
                    // Need tricks: lead high cards in long suits
                    var byRank = validCards.OrderByDescending(c => c.Rank).ToList();
                    return byRank.First();
                }
                else
                {
                    // Don't need tricks: lead low cards
                    return validCards.OrderBy(c => c.Rank).First();
                }
            }
            else
            {
                var leadSuit = trick[0].card.Suit;
                var currentWinner = GetCurrentTrickWinner();
                var winningCard = trick.First(t => t.player == currentWinner).card;
                bool isPartner = (playerIndex + 2) % 4 == currentWinner;

                if (currentTricks < targetBid)
                {
                    // Need tricks
                    if (!isPartner)
                    {
                        // Try to win
                        var canWin = validCards.Where(c => CanBeat(c, winningCard, leadSuit)).ToList();
                        if (canWin.Any())
                            return canWin.OrderBy(c => c.Rank).First();
                    }
                }
                else if (currentTricks >= targetBid && !isPartner)
                {
                    // Avoid winning: play lowest card
                    return validCards.OrderBy(c => c.Rank).First();
                }

                // Default: play lowest valid card
                return validCards.OrderBy(c => c.Rank).First();
            }
        }

        private bool CanBeat(Card myCard, Card winningCard, string leadSuit)
        {
            // Spades always beat non-spades
            if (myCard.Suit == "Spades" && winningCard.Suit != "Spades")
                return true;
            if (myCard.Suit != "Spades" && winningCard.Suit == "Spades")
                return false;
            
            // Same suit: higher rank wins
            if (myCard.Suit == winningCard.Suit)
                return myCard.Rank > winningCard.Rank;
            
            return false;
        }

        private int GetCurrentTrickWinner()
        {
            if (trick.Count == 0)
                return -1;

            var leadSuit = trick[0].card.Suit;
            var spades = trick.Where(x => x.card.Suit == "Spades").ToList();
            
            if (spades.Any())
            {
                // Highest spade wins
                return spades.OrderByDescending(x => x.card.Rank).First().player;
            }
            else
            {
                // Highest card in lead suit wins
                var leadCards = trick.Where(x => x.card.Suit == leadSuit).ToList();
                return leadCards.OrderByDescending(x => x.card.Rank).First().player;
            }
        }

        private void PlayCard(int playerIndex, Card card)
        {
            var player = players[playerIndex];
            player.Hand.Remove(card);

            // Animate card to table center with easing
            int fromX, fromY, toX, toY;
            if (playerIndex == 0)
            {
                var hand = player.Hand;
                fromX = TableCenterX - ((hand.Count + 1) * CardWidth + hand.Count * CardSpacing) / 2;
                fromY = HandTop;
            }
            else
            {
                (fromX, fromY) = GetAIHandPosition(playerIndex);
            }

            toX = TableCenterX + (int)(Math.Cos(Math.PI / 2 * playerIndex) * 80) - CardWidth / 2;
            toY = TableCenterY + (int)(Math.Sin(Math.PI / 2 * playerIndex) * 80) - CardHeight / 2;

            animatedCards.Add(new AnimatedCard
            {
                Card = card,
                PlayerIndex = playerIndex,
                From = new Point(fromX, fromY),
                To = new Point(toX, toY),
                Current = new Point(fromX, fromY),
                Progress = 0,
                Rotation = 0,
                Scale = 1.0f
            });

            currentAnimationType = AnimationType.CardPlay;

            animationOnComplete = () =>
            {
                trick.Add((playerIndex, card));
                if (card.Suit == "Spades")
                    spadesBroken = true;

                if (trick.Count == 4)
                {
                    int winner = DetermineTrickWinner();
                    trickWinner = winner;
                    tricksWon[winner]++;
                    
                    statusLabel.Text = $"{players[winner].Name} wins the trick!";
                    
                    // Animate trick collection
                    DelayedAction(800, () => CollectTrick(winner));
                }
                else
                {
                    currentPlayerIndex = (currentPlayerIndex + 1) % 4;
                    statusLabel.Text = $"{players[currentPlayerIndex].Name}'s turn";
                    Invalidate();
                    if (!players[currentPlayerIndex].IsHuman)
                        PlayAITurn();
                }
            };

            animationTimer.Start();
        }

        private void CollectTrick(int winner)
        {
            // Animate cards moving to winner's position
            animatedCards.Clear();
            currentAnimationType = AnimationType.TrickCollection;

            var (winnerX, winnerY) = winner == 0 
                ? (TableCenterX, HandTop + 120) 
                : GetAIHandPosition(winner);

            foreach (var (player, card) in trick)
            {
                int fromX = TableCenterX + (int)(Math.Cos(Math.PI / 2 * player) * 80) - CardWidth / 2;
                int fromY = TableCenterY + (int)(Math.Sin(Math.PI / 2 * player) * 80) - CardHeight / 2;

                animatedCards.Add(new AnimatedCard
                {
                    Card = card,
                    PlayerIndex = player,
                    From = new Point(fromX, fromY),
                    To = new Point(winnerX, winnerY),
                    Current = new Point(fromX, fromY),
                    Progress = 0,
                    Rotation = 0,
                    Scale = 1.0f
                });
            }

            animationOnComplete = () =>
            {
                currentPlayerIndex = winner;
                trick.Clear();
                trickWinner = -1;

                if (players[0].Hand.Count == 0)
                {
                    CalculateRoundScores();
                    
                    if (scores.Values.Any(s => s >= 500))
                    {
                        ShowEndOfGameSummary();
                        StartNewGame();
                        return;
                    }
                    else
                    {
                        DelayedAction(2000, () => StartNewRound());
                        return;
                    }
                }

                statusLabel.Text = $"{players[currentPlayerIndex].Name}'s turn";
                Invalidate();
                if (!players[currentPlayerIndex].IsHuman)
                    PlayAITurn();
            };

            animationTimer.Start();
        }

        private void StartNewRound()
        {
            currentPhase = GamePhase.Bidding;
            spadesBroken = false;
            bids.Clear();
            tricksWon.Clear();

            DealCards();
            currentPlayerIndex = 0;
            trick.Clear();

            bidControl.Value = 0;
            bidControl.Visible = true;
            bidButton.Visible = true;
            phaseLabel.Text = "Bidding Phase - Select your bid";
            statusLabel.Text = "Review your hand and make your bid";

            DelayedAction(300, () => ProcessBidding());
            Invalidate();
        }

        private int DetermineTrickWinner()
        {
            var leadSuit = trick[0].card.Suit;
            var spades = trick.Where(x => x.card.Suit == "Spades").ToList();
            
            if (spades.Any())
            {
                return spades.OrderByDescending(x => x.card.Rank).First().player;
            }
            else
            {
                var leadCards = trick.Where(x => x.card.Suit == leadSuit).ToList();
                return leadCards.OrderByDescending(x => x.card.Rank).First().player;
            }
        }

        private void CalculateRoundScores()
        {
            for (int i = 0; i < 4; i++)
            {
                int bid = bids[i];
                int won = tricksWon[i];

                if (won >= bid)
                {
                    // Made bid
                    scores[i] += bid * 10;
                    int extraTricks = won - bid;
                    scores[i] += extraTricks; // Each overtrick is 1 point (bag)
                    bags[i] += extraTricks;

                    // 10 bags penalty
                    if (bags[i] >= 10)
                    {
                        scores[i] -= 100;
                        bags[i] -= 10;
                    }
                }
                else
                {
                    // Failed bid
                    scores[i] -= bid * 10;
                }
            }

            string summary = "Round Over!\n\n";
            for (int i = 0; i < 4; i++)
            {
                summary += $"{players[i].Name}: Bid {bids[i]}, Won {tricksWon[i]} - Score: {scores[i]} (Bags: {bags[i]})\n";
            }
            MessageBox.Show(summary, "Spades - Round Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowEndOfGameSummary()
        {
            int maxScore = scores.Values.Max();
            var winners = players.Where((p, i) => scores[i] == maxScore).Select(p => p.Name).ToList();
            string summary = "Game Over!\n\n";
            summary += string.Join("\n", players.Select((p, i) => $"{p.Name}: {scores[i]} points (Bags: {bags[i]})"));
            summary += "\n\nWinner" + (winners.Count > 1 ? "s" : "") + ": " + string.Join(", ", winners);
            MessageBox.Show(summary, "Spades - Game Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AnimationTimer_Tick(object? sender, EventArgs e)
        {
            bool anyActive = false;
            foreach (var anim in animatedCards)
            {
                if (anim.Progress < 1.0)
                {
                    anim.Progress += currentAnimationType == AnimationType.TrickCollection ? 0.12 : 0.10;
                    if (anim.Progress > 1.0) anim.Progress = 1.0;

                    // Ease-in-out cubic for smoother animation
                    double easedProgress = anim.Progress < 0.5
                        ? 4 * anim.Progress * anim.Progress * anim.Progress
                        : 1 - Math.Pow(-2 * anim.Progress + 2, 3) / 2;

                    anim.Current = new Point(
                        (int)(anim.From.X + (anim.To.X - anim.From.X) * easedProgress),
                        (int)(anim.From.Y + (anim.To.Y - anim.From.Y) * easedProgress)
                    );

                    // Add slight rotation during play animation
                    if (currentAnimationType == AnimationType.CardPlay)
                    {
                        anim.Rotation = (float)(Math.Sin(anim.Progress * Math.PI) * 5);
                    }

                    // Add scale effect during collection
                    if (currentAnimationType == AnimationType.TrickCollection)
                    {
                        anim.Scale = 1.0f - (float)(anim.Progress * 0.3);
                    }

                    anyActive = true;
                }
            }
            Invalidate();
            if (!anyActive)
            {
                animationTimer.Stop();
                animatedCards.Clear();
                animationOnComplete?.Invoke();
                animationOnComplete = null;
            }
        }

        private void Spades_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.Clear(Color.DarkGreen);

            // Draw player names
            DrawPlayerLabel(g, 0, TableCenterX, HandTop - 25);
            DrawPlayerLabel(g, 1, TableCenterX + 250, TableCenterY - 80);
            DrawPlayerLabel(g, 2, TableCenterX, TableCenterY - 230);
            DrawPlayerLabel(g, 3, TableCenterX - 250, TableCenterY - 80);

            // Draw player hands
            DrawHand(g, players[0].Hand, TableCenterX, HandTop, true);

            // Draw AI hands (as card backs)
            DrawAIHand(g, 1, TableCenterX + 200, TableCenterY - 100);
            DrawAIHand(g, 2, TableCenterX, TableCenterY - 200);
            DrawAIHand(g, 3, TableCenterX - 200, TableCenterY - 100);

            // Draw trick cards on table (not being animated)
            foreach (var (player, card) in trick)
            {
                bool isAnimating = animatedCards.Any(a => a.Card == card && a.PlayerIndex == player);
                if (!isAnimating)
                {
                    int px = TableCenterX + (int)(Math.Cos(Math.PI / 2 * player) * 80) - CardWidth / 2;
                    int py = TableCenterY + (int)(Math.Sin(Math.PI / 2 * player) * 80) - CardHeight / 2;
                    
                    // Highlight winner's card
                    bool isWinner = trickWinner >= 0 && player == trickWinner && trick.Count == 4;
                    DrawCard(g, card, px, py, false, isWinner);
                }
            }

            // Draw animated cards with transformations
            foreach (var anim in animatedCards)
            {
                DrawAnimatedCard(g, anim);
            }

            // Update score label
            string scoreText = "";
            for (int i = 0; i < 4; i++)
            {
                scoreText += $"{players[i].Name}: {scores[i]}";
                if (currentPhase == GamePhase.Playing && tricksWon.ContainsKey(i) && bids.ContainsKey(i))
                    scoreText += $" ({tricksWon[i]}/{bids[i]})";
                scoreText += "  ";
            }
            scoreLabel.Text = scoreText;
        }

        private void DrawPlayerLabel(Graphics g, int playerIndex, int x, int y)
        {
            string name = players[playerIndex].Name;
            var font = new Font("Segoe UI", 10, FontStyle.Bold);
            var size = g.MeasureString(name, font);
            
            var backRect = new RectangleF(x - size.Width / 2 - 5, y, size.Width + 10, size.Height);
            g.FillRectangle(new SolidBrush(Color.FromArgb(100, 0, 0, 0)), backRect);
            g.DrawString(name, font, Brushes.White, x - size.Width / 2, y);
        }

        private void DrawAnimatedCard(Graphics g, AnimatedCard anim)
        {
            // Save graphics state
            var state = g.Save();

            // Apply transformations
            g.TranslateTransform(anim.Current.X + CardWidth / 2, anim.Current.Y + CardHeight / 2);
            g.RotateTransform(anim.Rotation);
            g.ScaleTransform(anim.Scale, anim.Scale);
            g.TranslateTransform(-CardWidth / 2, -CardHeight / 2);

            DrawCard(g, anim.Card, 0, 0, false, false);

            // Restore graphics state
            g.Restore(state);
        }

        private void DrawHand(Graphics g, List<Card> hand, int centerX, int y, bool clickable)
        {
            for (int i = 0; i < hand.Count; i++)
            {
                int x = centerX - (hand.Count * CardWidth + (hand.Count - 1) * CardSpacing) / 2 + i * (CardWidth + CardSpacing);
                DrawCard(g, hand[i], x, y, clickable, false);
            }
        }

        private void DrawAIHand(Graphics g, int aiIndex, int x, int y)
        {
            var hand = players[aiIndex].Hand;
            for (int i = 0; i < hand.Count; i++)
            {
                DrawCardBack(g, x + i * 8, y, false);
            }
        }

        private (int x, int y) GetAIHandPosition(int aiIndex)
        {
            return aiIndex switch
            {
                1 => (TableCenterX + 200, TableCenterY - 100),
                2 => (TableCenterX, TableCenterY - 200),
                3 => (TableCenterX - 200, TableCenterY - 100),
                _ => (TableCenterX, TableCenterY)
            };
        }

        private void DrawCard(Graphics g, Card card, int x, int y, bool clickable, bool highlight)
        {
            var rect = new Rectangle(x, y, CardWidth, CardHeight);
            
            // Draw shadow
            g.FillRectangle(new SolidBrush(Color.FromArgb(50, 0, 0, 0)), 
                new Rectangle(x + 3, y + 3, CardWidth, CardHeight));
            
            // Draw card background
            var brush = highlight ? Brushes.Gold : (clickable ? Brushes.White : Brushes.WhiteSmoke);
            g.FillRectangle(brush, rect);
            
            // Draw border
            var pen = highlight ? new Pen(Color.Orange, 3) : Pens.Black;
            g.DrawRectangle(pen, rect);
            
            // Draw card content
            string suitSymbol = card.Suit switch
            {
                "Hearts" => "♥",
                "Diamonds" => "♦",
                "Clubs" => "♣",
                "Spades" => "♠",
                _ => "?"
            };
            var suitColor = (card.Suit == "Hearts" || card.Suit == "Diamonds") ? Brushes.Red : Brushes.Black;
            var font = new Font("Segoe UI", 14, FontStyle.Bold);
            
            // Draw rank and suit in top-left
            g.DrawString($"{card.GetRankString()}", font, suitColor, x + 5, y + 5);
            g.DrawString(suitSymbol, font, suitColor, x + 5, y + 25);
            
            // Draw large suit symbol in center
            var centerFont = new Font("Segoe UI", 24, FontStyle.Bold);
            var symbolSize = g.MeasureString(suitSymbol, centerFont);
            g.DrawString(suitSymbol, centerFont, suitColor, 
                x + CardWidth / 2 - symbolSize.Width / 2, 
                y + CardHeight / 2 - symbolSize.Height / 2);
        }

        private void DrawCardBack(Graphics g, int x, int y, bool highlight)
        {
            var rect = new Rectangle(x, y, CardWidth, CardHeight);
            
            // Draw shadow
            g.FillRectangle(new SolidBrush(Color.FromArgb(50, 0, 0, 0)), 
                new Rectangle(x + 3, y + 3, CardWidth, CardHeight));
            
            // Draw card back with pattern
            g.FillRectangle(new SolidBrush(Color.FromArgb(20, 40, 120)), rect);
            g.DrawRectangle(Pens.Black, rect);
            
            // Draw pattern
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    g.DrawString("♠", new Font("Segoe UI", 12), Brushes.White, 
                        x + 5 + i * 18, y + 5 + j * 20);
                }
            }
        }

        // --- Data classes ---

        private class Player
        {
            public string Name { get; set; } = string.Empty;
            public bool IsHuman { get; set; }
            public List<Card> Hand { get; set; } = new();
        }

        private class Card
        {
            public string Suit { get; set; } = string.Empty;
            public int Rank { get; set; }

            public override string ToString()
            {
                return $"{GetRankString()}{Suit[0]}";
            }

            public string GetRankString()
            {
                return Rank switch
                {
                    11 => "J",
                    12 => "Q",
                    13 => "K",
                    14 => "A",
                    _ => Rank.ToString()
                };
            }

            public static List<Card> GetDeck()
            {
                var suits = new[] { "Clubs", "Diamonds", "Hearts", "Spades" };
                var deck = new List<Card>();
                foreach (var suit in suits)
                    for (int r = 2; r <= 14; r++)
                        deck.Add(new Card { Suit = suit, Rank = r });
                return deck;
            }
        }

        private class AnimatedCard
        {
            public Card Card = null!;
            public int PlayerIndex;
            public Point From;
            public Point To;
            public Point Current;
            public double Progress;
            public float Rotation;
            public float Scale;
        }
    }
}