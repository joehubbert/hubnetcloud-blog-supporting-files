using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace CRM.Presentation.Games
{
    public partial class GinRummy : Form
    {
        private enum Difficulty { Easy, Medium, Hard }
        private enum GamePhase { DrawPhase, DiscardPhase, GameOver }
        private enum AnimationType { Deal, Draw, Discard, Knock, Layoff, Flip }

        private Difficulty aiDifficulty = Difficulty.Medium;
        private GamePhase currentPhase = GamePhase.DrawPhase;

        private List<Player> players = new();
        private int currentPlayerIndex = 0;
        private List<Card> deck = new();
        private List<Card> discardPile = new();
        private Dictionary<int, int> scores = new();
        private Card? lastDrawnCard = null;
        private bool drewFromDiscard = false;

        // Animation
        private System.Windows.Forms.Timer animationTimer = null!;
        private List<AnimatedCard> animatedCards = new();
        private Action? animationOnComplete = null;
        private AnimationType currentAnimationType = AnimationType.Deal;

        // Card graphics
        private const int CardWidth = 70;
        private const int CardHeight = 100;
        private const int CardSpacing = 15;
        private const int TableCenterY = 300;
        private const int PlayerHandY = 540;
        private const int OpponentHandY = 90;
        private const int TableCenterX = 600;
        private const int DeckX = 350;
        private const int DiscardX = 480;
        private const int PileY = 280;

        // UI
        private ComboBox difficultyComboBox = null!;
        private Button newGameButton = null!;
        private Button knockButton = null!;
        private Button ginButton = null!;
        private Label scoreLabel = null!;
        private Label phaseLabel = null!;
        private Label statusLabel = null!;
        private Label deadwoodLabel = null!;
        private Panel infoPanel = null!;

        // Meld tracking for visualization
        private List<List<Card>> playerMelds = new();
        private List<List<Card>> opponentMelds = new();
        private Card? selectedCard = null;

        public GinRummy()
        {
            InitializeComponent();
            DoubleBuffered = true;
            InitializeGameUI();
            StartNewGame();
        }

        private void InitializeGameUI()
        {
            this.Size = new Size(1400, 800);
            this.BackColor = Color.ForestGreen;
            this.Text = "Gin Rummy";
            this.MinimumSize = new Size(1400, 800);

            // Left column controls
            difficultyComboBox = new ComboBox
            {
                Location = new Point(20, 20),
                Width = 130,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10)
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
                Location = new Point(20, 65),
                Width = 130,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightGray,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            newGameButton.Click += (s, e) => StartNewGame();
            Controls.Add(newGameButton);

            knockButton = new Button
            {
                Text = "Knock",
                Location = new Point(20, 120),
                Width = 130,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Orange,
                Enabled = false,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            knockButton.Click += KnockButton_Click;
            Controls.Add(knockButton);

            ginButton = new Button
            {
                Text = "Gin!",
                Location = new Point(20, 175),
                Width = 130,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Gold,
                Enabled = false,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            ginButton.Click += GinButton_Click;
            Controls.Add(ginButton);

            // Right side information panel with background
            infoPanel = new Panel
            {
                Location = new Point(1050, 15),
                Size = new Size(330, 220),
                BackColor = Color.FromArgb(200, 0, 50, 0),
                BorderStyle = BorderStyle.FixedSingle
            };
            Controls.Add(infoPanel);

            phaseLabel = new Label
            {
                Location = new Point(10, 10),
                Size = new Size(310, 40),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft
            };
            infoPanel.Controls.Add(phaseLabel);

            statusLabel = new Label
            {
                Location = new Point(10, 60),
                Size = new Size(310, 40),
                Font = new Font("Segoe UI", 11, FontStyle.Italic),
                ForeColor = Color.Yellow,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft
            };
            infoPanel.Controls.Add(statusLabel);

            scoreLabel = new Label
            {
                Location = new Point(10, 110),
                Size = new Size(310, 40),
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft
            };
            infoPanel.Controls.Add(scoreLabel);

            deadwoodLabel = new Label
            {
                Location = new Point(10, 160),
                Size = new Size(310, 40),
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.LightCyan,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft
            };
            infoPanel.Controls.Add(deadwoodLabel);

            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 16; // ~60 FPS
            animationTimer.Tick += AnimationTimer_Tick;

            this.Paint += GinRummy_Paint;
            this.MouseClick += GinRummy_MouseClick;
            this.MouseMove += GinRummy_MouseMove;
        }

        private void StartNewGame()
        {
            currentPhase = GamePhase.DrawPhase;

            players.Clear();
            players.Add(new Player { IsHuman = true, Name = "You", Hand = new List<Card>() });
            players.Add(new Player { IsHuman = false, Name = "AI", Hand = new List<Card>() });

            if (scores.Count == 0)
            {
                scores[0] = 0;
                scores[1] = 0;
            }

            deck.Clear();
            discardPile.Clear();
            animatedCards.Clear();
            lastDrawnCard = null;
            drewFromDiscard = false;
            selectedCard = null;
            playerMelds.Clear();
            opponentMelds.Clear();

            currentPlayerIndex = 0;
            knockButton.Enabled = false;
            ginButton.Enabled = false;

            phaseLabel.Text = "Dealing cards...";
            statusLabel.Text = "Get ready!";
            UpdateScoreDisplay();

            DealNewHand();
        }

        private void DealNewHand()
        {
            deck = Card.GetDeck();
            var rnd = new Random();
            deck = deck.OrderBy(_ => rnd.Next()).ToList();

            // Animated dealing
            currentAnimationType = AnimationType.Deal;
            int cardIndex = 0;

            for (int round = 0; round < 10; round++)
            {
                for (int playerIdx = 0; playerIdx < 2; playerIdx++)
                {
                    var card = deck[cardIndex++];
                    int targetY = playerIdx == 0 ? PlayerHandY : OpponentHandY;

                    animatedCards.Add(new AnimatedCard
                    {
                        Card = card,
                        PlayerIndex = playerIdx,
                        From = new Point(DeckX, PileY),
                        To = new Point(TableCenterX - 200 + round * 40, targetY),
                        Current = new Point(DeckX, PileY),
                        Progress = 0,
                        Rotation = 0,
                        Scale = 1.0f,
                        Delay = round * 2 + playerIdx
                    });
                }
            }

            deck.RemoveRange(0, 20);

            // Flip top card to discard pile
            var firstDiscard = deck[0];
            deck.RemoveAt(0);
            discardPile.Add(firstDiscard);

            animationOnComplete = () =>
            {
                // Add cards to hands after animation
                for (int i = 0; i < 10; i++)
                {
                    players[0].Hand.Add(animatedCards[i * 2].Card);
                    players[1].Hand.Add(animatedCards[i * 2 + 1].Card);
                }

                SortHand(players[0]);
                SortHand(players[1]);

                animatedCards.Clear();

                phaseLabel.Text = "Your Turn - Draw a Card";
                statusLabel.Text = "Click the deck or discard pile to draw";
                UpdateDeadwoodDisplay();
                Invalidate();
            };

            animationTimer.Start();
        }

        private void SortHand(Player player)
        {
            player.Hand = player.Hand.OrderBy(c => c.Suit).ThenBy(c => c.Rank).ToList();
        }

        private void GinRummy_MouseMove(object? sender, MouseEventArgs e)
        {
            if (currentPlayerIndex != 0 || animatedCards.Count > 0)
                return;

            // Highlight card on hover
            bool needsRedraw = false;
            var hand = players[0].Hand;

            for (int i = 0; i < hand.Count; i++)
            {
                int x = GetCardX(hand.Count, i);
                var rect = new Rectangle(x, PlayerHandY, CardWidth, CardHeight);

                if (rect.Contains(e.Location) && currentPhase == GamePhase.DiscardPhase)
                {
                    if (selectedCard != hand[i])
                    {
                        selectedCard = hand[i];
                        needsRedraw = true;
                    }
                }
            }

            if (needsRedraw)
                Invalidate();
        }

        private void GinRummy_MouseClick(object? sender, MouseEventArgs e)
        {
            if (animatedCards.Count > 0 || currentPlayerIndex != 0)
                return;

            if (currentPhase == GamePhase.DrawPhase)
            {
                // Check deck click
                var deckRect = new Rectangle(DeckX, PileY, CardWidth, CardHeight);
                if (deckRect.Contains(e.Location) && deck.Count > 0)
                {
                    DrawFromDeck();
                    return;
                }

                // Check discard pile click
                var discardRect = new Rectangle(DiscardX, PileY, CardWidth, CardHeight);
                if (discardRect.Contains(e.Location) && discardPile.Count > 0)
                {
                    DrawFromDiscard();
                    return;
                }
            }
            else if (currentPhase == GamePhase.DiscardPhase)
            {
                // Check hand click for discard
                var hand = players[0].Hand;
                for (int i = 0; i < hand.Count; i++)
                {
                    int x = GetCardX(hand.Count, i);
                    var rect = new Rectangle(x, PlayerHandY, CardWidth, CardHeight);
                    if (rect.Contains(e.Location))
                    {
                        DiscardCard(hand[i]);
                        return;
                    }
                }
            }
        }

        private void DrawFromDeck()
        {
            if (deck.Count == 0) return;

            var card = deck[0];
            deck.RemoveAt(0);
            lastDrawnCard = card;
            drewFromDiscard = false;

            currentAnimationType = AnimationType.Draw;
            animatedCards.Add(new AnimatedCard
            {
                Card = card,
                PlayerIndex = 0,
                From = new Point(DeckX, PileY),
                To = new Point(GetCardX(players[0].Hand.Count, players[0].Hand.Count), PlayerHandY),
                Current = new Point(DeckX, PileY),
                Progress = 0,
                Rotation = 360,
                Scale = 1.0f,
                Delay = 0
            });

            animationOnComplete = () =>
            {
                players[0].Hand.Add(card);
                SortHand(players[0]);
                animatedCards.Clear();

                currentPhase = GamePhase.DiscardPhase;
                phaseLabel.Text = "Your Turn - Discard a Card";
                statusLabel.Text = "Click a card to discard it";

                CheckForKnockOrGin();
                UpdateDeadwoodDisplay();
                Invalidate();
            };

            animationTimer.Start();
        }

        private void DrawFromDiscard()
        {
            if (discardPile.Count == 0) return;

            var card = discardPile[^1];
            discardPile.RemoveAt(discardPile.Count - 1);
            lastDrawnCard = card;
            drewFromDiscard = true;

            currentAnimationType = AnimationType.Draw;
            animatedCards.Add(new AnimatedCard
            {
                Card = card,
                PlayerIndex = 0,
                From = new Point(DiscardX, PileY),
                To = new Point(GetCardX(players[0].Hand.Count, players[0].Hand.Count), PlayerHandY),
                Current = new Point(DiscardX, PileY),
                Progress = 0,
                Rotation = 360,
                Scale = 1.2f,
                Delay = 0
            });

            animationOnComplete = () =>
            {
                players[0].Hand.Add(card);
                SortHand(players[0]);
                animatedCards.Clear();

                currentPhase = GamePhase.DiscardPhase;
                phaseLabel.Text = "Your Turn - Discard a Card";
                statusLabel.Text = "Click a card to discard it";

                CheckForKnockOrGin();
                UpdateDeadwoodDisplay();
                Invalidate();
            };

            animationTimer.Start();
        }

        private void DiscardCard(Card card)
        {
            players[0].Hand.Remove(card);
            selectedCard = null;

            currentAnimationType = AnimationType.Discard;
            int cardIndex = players[0].Hand.Count;

            animatedCards.Add(new AnimatedCard
            {
                Card = card,
                PlayerIndex = 0,
                From = new Point(GetCardX(cardIndex + 1, cardIndex), PlayerHandY),
                To = new Point(DiscardX, PileY),
                Current = new Point(GetCardX(cardIndex + 1, cardIndex), PlayerHandY),
                Progress = 0,
                Rotation = -15,
                Scale = 1.0f,
                Delay = 0
            });

            animationOnComplete = () =>
            {
                discardPile.Add(card);
                animatedCards.Clear();

                currentPhase = GamePhase.DrawPhase;
                currentPlayerIndex = 1;
                knockButton.Enabled = false;
                ginButton.Enabled = false;

                UpdateDeadwoodDisplay();
                Invalidate();

                // AI turn
                DelayedAction(800, () => PlayAITurn());
            };

            animationTimer.Start();
        }

        private void PlayAITurn()
        {
            if (deck.Count == 0 && discardPile.Count <= 1)
            {
                EndRound(true);
                return;
            }

            phaseLabel.Text = "AI's Turn";
            statusLabel.Text = "AI is thinking...";

            // AI decision logic
            bool shouldDrawFromDiscard = false;

            if (discardPile.Count > 0)
            {
                var topDiscard = discardPile[^1];
                shouldDrawFromDiscard = ShouldAIDrawFromDiscard(topDiscard);
            }

            DelayedAction(600, () =>
            {
                if (shouldDrawFromDiscard && discardPile.Count > 0)
                {
                    AIDrawFromDiscard();
                }
                else if (deck.Count > 0)
                {
                    AIDrawFromDeck();
                }
                else
                {
                    EndRound(true);
                }
            });
        }

        private bool ShouldAIDrawFromDiscard(Card card)
        {
            var tempHand = new List<Card>(players[1].Hand) { card };
            var melds = FindBestMelds(tempHand);
            var deadwood = CalculateDeadwood(tempHand, melds);

            var currentMelds = FindBestMelds(players[1].Hand);
            var currentDeadwood = CalculateDeadwood(players[1].Hand, currentMelds);

            switch (aiDifficulty)
            {
                case Difficulty.Hard:
                    return deadwood < currentDeadwood - 2;
                case Difficulty.Medium:
                    return deadwood < currentDeadwood - 5;
                default: // Easy
                    return deadwood < currentDeadwood - 8;
            }
        }

        private void AIDrawFromDeck()
        {
            if (deck.Count == 0) return;

            var card = deck[0];
            deck.RemoveAt(0);

            currentAnimationType = AnimationType.Draw;
            animatedCards.Add(new AnimatedCard
            {
                Card = card,
                PlayerIndex = 1,
                From = new Point(DeckX, PileY),
                To = new Point(TableCenterX - 100, OpponentHandY),
                Current = new Point(DeckX, PileY),
                Progress = 0,
                Rotation = 180,
                Scale = 1.0f,
                Delay = 0
            });

            animationOnComplete = () =>
            {
                players[1].Hand.Add(card);
                SortHand(players[1]);
                animatedCards.Clear();
                Invalidate();

                DelayedAction(400, () => AIDiscard());
            };

            animationTimer.Start();
        }

        private void AIDrawFromDiscard()
        {
            if (discardPile.Count == 0) return;

            var card = discardPile[^1];
            discardPile.RemoveAt(discardPile.Count - 1);

            currentAnimationType = AnimationType.Draw;
            animatedCards.Add(new AnimatedCard
            {
                Card = card,
                PlayerIndex = 1,
                From = new Point(DiscardX, PileY),
                To = new Point(TableCenterX - 100, OpponentHandY),
                Current = new Point(DiscardX, PileY),
                Progress = 0,
                Rotation = 180,
                Scale = 1.0f,
                Delay = 0
            });

            animationOnComplete = () =>
            {
                players[1].Hand.Add(card);
                SortHand(players[1]);
                animatedCards.Clear();
                Invalidate();

                DelayedAction(400, () => AIDiscard());
            };

            animationTimer.Start();
        }

        private void AIDiscard()
        {
            // Check if AI can knock or go gin
            var melds = FindBestMelds(players[1].Hand);
            int deadwood = CalculateDeadwood(players[1].Hand, melds);

            if (deadwood == 0)
            {
                // AI goes Gin!
                AIGin(melds);
                return;
            }

            if (deadwood <= 10 && ShouldAIKnock(deadwood))
            {
                AIKnock(melds);
                return;
            }

            // Choose card to discard
            var cardToDiscard = ChooseAIDiscard();
            players[1].Hand.Remove(cardToDiscard);

            currentAnimationType = AnimationType.Discard;
            animatedCards.Add(new AnimatedCard
            {
                Card = cardToDiscard,
                PlayerIndex = 1,
                From = new Point(TableCenterX - 100, OpponentHandY),
                To = new Point(DiscardX, PileY),
                Current = new Point(TableCenterX - 100, OpponentHandY),
                Progress = 0,
                Rotation = 15,
                Scale = 1.0f,
                Delay = 0
            });

            animationOnComplete = () =>
            {
                discardPile.Add(cardToDiscard);
                animatedCards.Clear();

                currentPhase = GamePhase.DrawPhase;
                currentPlayerIndex = 0;

                phaseLabel.Text = "Your Turn - Draw a Card";
                statusLabel.Text = "Click the deck or discard pile to draw";

                UpdateDeadwoodDisplay();
                Invalidate();
            };

            animationTimer.Start();
        }

        private bool ShouldAIKnock(int deadwood)
        {
            return aiDifficulty switch
            {
                Difficulty.Hard => deadwood <= 5,
                Difficulty.Medium => deadwood <= 7,
                _ => deadwood <= 10
            };
        }

        private Card ChooseAIDiscard()
        {
            var hand = players[1].Hand;
            var melds = FindBestMelds(hand);
            var deadwoodCards = GetDeadwoodCards(hand, melds);

            if (deadwoodCards.Any())
            {
                // Discard highest deadwood card
                return deadwoodCards.OrderByDescending(c => GetCardValue(c)).First();
            }

            // Discard from least valuable meld
            return hand.OrderBy(c => GetCardValue(c)).First();
        }

        private void CheckForKnockOrGin()
        {
            var melds = FindBestMelds(players[0].Hand);
            int deadwood = CalculateDeadwood(players[0].Hand, melds);

            deadwoodLabel.Text = $"Your Deadwood: {deadwood} points";

            if (deadwood == 0)
            {
                ginButton.Enabled = true;
                knockButton.Enabled = false;
                statusLabel.Text = "You can go GIN! Click the Gin button!";
                statusLabel.ForeColor = Color.Gold;
            }
            else if (deadwood <= 10)
            {
                knockButton.Enabled = true;
                ginButton.Enabled = false;
                statusLabel.Text = $"You can KNOCK (deadwood: {deadwood})";
                statusLabel.ForeColor = Color.Orange;
            }
            else
            {
                knockButton.Enabled = false;
                ginButton.Enabled = false;
                statusLabel.ForeColor = Color.Yellow;
            }
        }

        private void KnockButton_Click(object? sender, EventArgs e)
        {
            playerMelds = FindBestMelds(players[0].Hand);
            EndRound(false, true, false);
        }

        private void GinButton_Click(object? sender, EventArgs e)
        {
            playerMelds = FindBestMelds(players[0].Hand);
            EndRound(false, false, true);
        }

        private void AIKnock(List<List<Card>> melds)
        {
            opponentMelds = melds;
            statusLabel.Text = "AI knocks!";
            DelayedAction(1500, () => EndRound(false, true, false, true));
        }

        private void AIGin(List<List<Card>> melds)
        {
            opponentMelds = melds;
            statusLabel.Text = "AI goes GIN!";
            DelayedAction(1500, () => EndRound(false, false, true, true));
        }

        private void EndRound(bool draw, bool knocked = false, bool gin = false, bool aiWon = false)
        {
            currentPhase = GamePhase.GameOver;

            // Reveal hands with flip animation
            RevealHands(() =>
            {
                CalculateScore(draw, knocked, gin, aiWon);
            });
        }

        private void RevealHands(Action onComplete)
        {
            currentAnimationType = AnimationType.Flip;

            // Animate AI hand reveal
            var aiHand = players[1].Hand;
            for (int i = 0; i < aiHand.Count; i++)
            {
                animatedCards.Add(new AnimatedCard
                {
                    Card = aiHand[i],
                    PlayerIndex = 1,
                    From = new Point(TableCenterX - 200 + i * 40, OpponentHandY),
                    To = new Point(TableCenterX - 200 + i * 40, OpponentHandY + 50),
                    Current = new Point(TableCenterX - 200 + i * 40, OpponentHandY),
                    Progress = 0,
                    Rotation = 180,
                    Scale = 1.0f,
                    Delay = i
                });
            }

            animationOnComplete = () =>
            {
                animatedCards.Clear();
                onComplete();
            };

            animationTimer.Start();
        }

        private void CalculateScore(bool draw, bool knocked, bool gin, bool aiWon)
        {
            if (playerMelds.Count == 0)
                playerMelds = FindBestMelds(players[0].Hand);
            if (opponentMelds.Count == 0)
                opponentMelds = FindBestMelds(players[1].Hand);

            int playerDeadwood = CalculateDeadwood(players[0].Hand, playerMelds);
            int aiDeadwood = CalculateDeadwood(players[1].Hand, opponentMelds);

            string result = "";
            int playerPoints = 0;
            int aiPoints = 0;

            if (draw)
            {
                result = "Game drawn - deck exhausted!";
            }
            else if (gin)
            {
                if (aiWon)
                {
                    aiPoints = 25 + playerDeadwood;
                    result = $"AI goes GIN! AI gets {aiPoints} points!";
                }
                else
                {
                    playerPoints = 25 + aiDeadwood;
                    result = $"You go GIN! You get {playerPoints} points!";
                }
            }
            else if (knocked)
            {
                if (aiWon)
                {
                    if (playerDeadwood <= aiDeadwood)
                    {
                        // Player undercuts
                        playerPoints = 25 + (aiDeadwood - playerDeadwood);
                        result = $"You undercut the AI! You get {playerPoints} points!";
                    }
                    else
                    {
                        aiPoints = aiDeadwood - playerDeadwood;
                        result = $"AI knocks and wins! AI gets {aiPoints} points!";
                    }
                }
                else
                {
                    if (aiDeadwood <= playerDeadwood)
                    {
                        // AI undercuts
                        aiPoints = 25 + (playerDeadwood - aiDeadwood);
                        result = $"AI undercuts you! AI gets {aiPoints} points!";
                    }
                    else
                    {
                        playerPoints = playerDeadwood - aiDeadwood;
                        result = $"You knock and win! You get {playerPoints} points!";
                    }
                }
            }

            scores[0] += playerPoints;
            scores[1] += aiPoints;

            UpdateScoreDisplay();

            string summary = result + "\n\n";
            summary += $"Your deadwood: {playerDeadwood}\n";
            summary += $"AI deadwood: {aiDeadwood}\n\n";
            summary += $"Your score: {scores[0]}\n";
            summary += $"AI score: {scores[1]}";

            if (scores[0] >= 100 || scores[1] >= 100)
            {
                summary += "\n\n=== GAME OVER ===\n";
                summary += scores[0] >= 100 ? "YOU WIN THE GAME!" : "AI WINS THE GAME!";

                MessageBox.Show(summary, "Gin Rummy - Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

                scores[0] = 0;
                scores[1] = 0;
            }
            else
            {
                MessageBox.Show(summary, "Gin Rummy - Round Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            playerMelds.Clear();
            opponentMelds.Clear();
            StartNewGame();
        }

        private List<List<Card>> FindBestMelds(List<Card> hand)
        {
            var melds = new List<List<Card>>();
            var remaining = new List<Card>(hand);

            // Find runs first
            foreach (var suit in new[] { "Clubs", "Diamonds", "Hearts", "Spades" })
            {
                var suited = remaining.Where(c => c.Suit == suit).OrderBy(c => c.Rank).ToList();

                for (int i = 0; i < suited.Count - 2; i++)
                {
                    var run = new List<Card> { suited[i] };

                    for (int j = i + 1; j < suited.Count; j++)
                    {
                        if (suited[j].Rank == run[^1].Rank + 1)
                        {
                            run.Add(suited[j]);
                        }
                        else if (suited[j].Rank != run[^1].Rank)
                        {
                            break;
                        }
                    }

                    if (run.Count >= 3)
                    {
                        melds.Add(run);
                        foreach (var card in run)
                            remaining.Remove(card);
                        i = -1; // Restart
                        break;
                    }
                }
            }

            // Find sets
            for (int rank = 2; rank <= 14; rank++)
            {
                var sameRank = remaining.Where(c => c.Rank == rank).ToList();
                if (sameRank.Count >= 3)
                {
                    melds.Add(sameRank);
                    foreach (var card in sameRank)
                        remaining.Remove(card);
                }
            }

            return melds;
        }

        private int CalculateDeadwood(List<Card> hand, List<List<Card>> melds)
        {
            var deadwoodCards = GetDeadwoodCards(hand, melds);
            return deadwoodCards.Sum(c => GetCardValue(c));
        }

        private List<Card> GetDeadwoodCards(List<Card> hand, List<List<Card>> melds)
        {
            var inMelds = melds.SelectMany(m => m).ToHashSet();
            return hand.Where(c => !inMelds.Contains(c)).ToList();
        }

        private int GetCardValue(Card card)
        {
            if (card.Rank >= 10) return 10;
            return card.Rank;
        }

        private void UpdateScoreDisplay()
        {
            scoreLabel.Text = $"Score - You: {scores[0]}  |  AI: {scores[1]}";
        }

        private void UpdateDeadwoodDisplay()
        {
            if (currentPlayerIndex == 0 && players[0].Hand.Count > 0)
            {
                var melds = FindBestMelds(players[0].Hand);
                int deadwood = CalculateDeadwood(players[0].Hand, melds);
                deadwoodLabel.Text = $"Your Deadwood: {deadwood} points";
            }
        }

        private int GetCardX(int handSize, int cardIndex)
        {
            int totalWidth = handSize * CardWidth + (handSize - 1) * CardSpacing;
            return TableCenterX - totalWidth / 2 + cardIndex * (CardWidth + CardSpacing);
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

        private void AnimationTimer_Tick(object? sender, EventArgs e)
        {
            bool anyActive = false;

            foreach (var anim in animatedCards)
            {
                if (anim.Delay > 0)
                {
                    anim.Delay--;
                    anyActive = true;
                    continue;
                }

                if (anim.Progress < 1.0)
                {
                    anim.Progress += currentAnimationType == AnimationType.Deal ? 0.15 : 0.12;
                    if (anim.Progress > 1.0) anim.Progress = 1.0;

                    // Different easing for different animations
                    double easedProgress = currentAnimationType == AnimationType.Flip
                        ? Math.Sin(anim.Progress * Math.PI / 2) // Ease-out sine
                        : anim.Progress < 0.5
                            ? 4 * anim.Progress * anim.Progress * anim.Progress
                            : 1 - Math.Pow(-2 * anim.Progress + 2, 3) / 2;

                    anim.Current = new Point(
                        (int)(anim.From.X + (anim.To.X - anim.From.X) * easedProgress),
                        (int)(anim.From.Y + (anim.To.Y - anim.From.Y) * easedProgress)
                    );

                    // Rotation effects
                    if (currentAnimationType == AnimationType.Draw)
                    {
                        anim.Rotation = (float)(anim.Rotation * (1 - anim.Progress));
                    }
                    else if (currentAnimationType == AnimationType.Discard)
                    {
                        anim.Rotation = (float)(Math.Sin(anim.Progress * Math.PI) * 15);
                    }
                    else if (currentAnimationType == AnimationType.Flip)
                    {
                        anim.Rotation = (float)(180 * (1 - anim.Progress));
                    }

                    // Scale effects
                    if (currentAnimationType == AnimationType.Draw && anim.Scale > 1.0f)
                    {
                        anim.Scale = 1.0f + (float)((anim.Scale - 1.0f) * (1 - anim.Progress));
                    }

                    anyActive = true;
                }
            }

            Invalidate();

            if (!anyActive)
            {
                animationTimer.Stop();
                animationOnComplete?.Invoke();
                animationOnComplete = null;
            }
        }

        private void GinRummy_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.Clear(Color.ForestGreen);

            // Draw table areas
            DrawTableAreas(g);

            // Draw deck
            if (deck.Count > 0)
                DrawCardBack(g, DeckX, PileY);

            // Draw deck count
            g.DrawString($"{deck.Count}", new Font("Segoe UI", 11, FontStyle.Bold),
                Brushes.White, DeckX + 8, PileY + CardHeight + 8);

            // Draw discard pile
            if (discardPile.Count > 0)
            {
                DrawCard(g, discardPile[^1], DiscardX, PileY, false, false);
                g.DrawString($"{discardPile.Count}", new Font("Segoe UI", 11, FontStyle.Bold),
                    Brushes.White, DiscardX + 8, PileY + CardHeight + 8);
            }

            // Draw player labels
            DrawPlayerLabel(g, "You", TableCenterX, PlayerHandY - 35);
            DrawPlayerLabel(g, "AI", TableCenterX, OpponentHandY - 35);

            // Draw player hand
            if (!animatedCards.Any(a => a.PlayerIndex == 0 && currentAnimationType == AnimationType.Deal))
            {
                DrawPlayerHand(g, players[0].Hand, PlayerHandY);
            }

            // Draw AI hand
            if (currentPhase == GamePhase.GameOver)
            {
                DrawRevealedHand(g, players[1].Hand, OpponentHandY + 50);
            }
            else if (!animatedCards.Any(a => a.PlayerIndex == 1 && currentAnimationType == AnimationType.Deal))
            {
                DrawOpponentHand(g, players[1].Hand, OpponentHandY);
            }

            // Draw melds if game over
            if (currentPhase == GamePhase.GameOver)
            {
                DrawMelds(g, playerMelds, PlayerHandY + 120);
                DrawMelds(g, opponentMelds, OpponentHandY + 170);
            }

            // Draw animated cards
            foreach (var anim in animatedCards.Where(a => a.Delay == 0))
            {
                DrawAnimatedCard(g, anim);
            }
        }

        private void DrawTableAreas(Graphics g)
        {
            // Draw deck area
            using (var pen = new Pen(Color.Yellow, 3) { DashStyle = DashStyle.Dash })
            {
                g.DrawRectangle(pen, DeckX - 6, PileY - 6, CardWidth + 12, CardHeight + 12);
            }
            g.DrawString("DECK", new Font("Segoe UI", 10, FontStyle.Bold),
                Brushes.Yellow, DeckX, PileY - 28);

            // Draw discard area
            using (var pen = new Pen(Color.Orange, 3) { DashStyle = DashStyle.Dash })
            {
                g.DrawRectangle(pen, DiscardX - 6, PileY - 6, CardWidth + 12, CardHeight + 12);
            }
            g.DrawString("DISCARD", new Font("Segoe UI", 10, FontStyle.Bold),
                Brushes.Orange, DiscardX, PileY - 28);
        }

        private void DrawPlayerLabel(Graphics g, string name, int x, int y)
        {
            var font = new Font("Segoe UI", 12, FontStyle.Bold);
            var size = g.MeasureString(name, font);

            var backRect = new RectangleF(x - size.Width / 2 - 8, y, size.Width + 16, size.Height + 4);
            using (var brush = new SolidBrush(Color.FromArgb(150, 0, 0, 0)))
            {
                g.FillRoundedRectangle(brush, backRect, 5);
            }
            g.DrawString(name, font, Brushes.White, x - size.Width / 2, y);
        }

        private void DrawPlayerHand(Graphics g, List<Card> hand, int y)
        {
            for (int i = 0; i < hand.Count; i++)
            {
                int x = GetCardX(hand.Count, i);
                bool isSelected = hand[i] == selectedCard;
                int offsetY = isSelected ? -15 : 0;
                DrawCard(g, hand[i], x, y + offsetY, true, isSelected);
            }
        }

        private void DrawOpponentHand(Graphics g, List<Card> hand, int y)
        {
            for (int i = 0; i < hand.Count; i++)
            {
                int x = GetCardX(hand.Count, i);
                DrawCardBack(g, x, y);
            }
        }

        private void DrawRevealedHand(Graphics g, List<Card> hand, int y)
        {
            for (int i = 0; i < hand.Count; i++)
            {
                int x = GetCardX(hand.Count, i);
                DrawCard(g, hand[i], x, y, false, false);
            }
        }

        private void DrawMelds(Graphics g, List<List<Card>> melds, int startY)
        {
            if (melds.Count == 0) return;

            int x = 200;
            foreach (var meld in melds)
            {
                // Draw meld background
                using (var brush = new SolidBrush(Color.FromArgb(120, 0, 255, 0)))
                {
                    g.FillRoundedRectangle(brush,
                        new RectangleF(x - 8, startY - 8, meld.Count * 25 + CardWidth - 10, CardHeight + 16), 8);
                }

                for (int i = 0; i < meld.Count; i++)
                {
                    DrawCard(g, meld[i], x + i * 25, startY, false, false);
                }
                x += meld.Count * 25 + CardWidth + 15;
            }
        }

        private void DrawAnimatedCard(Graphics g, AnimatedCard anim)
        {
            var state = g.Save();

            g.TranslateTransform(anim.Current.X + CardWidth / 2, anim.Current.Y + CardHeight / 2);
            g.RotateTransform(anim.Rotation);
            g.ScaleTransform(anim.Scale, anim.Scale);
            g.TranslateTransform(-CardWidth / 2, -CardHeight / 2);

            if (currentAnimationType == AnimationType.Flip && anim.Rotation > 90)
            {
                DrawCardBack(g, 0, 0);
            }
            else
            {
                DrawCard(g, anim.Card, 0, 0, false, false);
            }

            g.Restore(state);
        }

        private void DrawCard(Graphics g, Card card, int x, int y, bool clickable, bool highlight)
        {
            var rect = new Rectangle(x, y, CardWidth, CardHeight);

            // Draw shadow with glow for highlighted cards
            if (highlight)
            {
                using (var shadowBrush = new SolidBrush(Color.FromArgb(120, 255, 215, 0)))
                {
                    g.FillRectangle(shadowBrush, new Rectangle(x - 3, y - 3, CardWidth + 6, CardHeight + 6));
                }
            }
            g.FillRectangle(new SolidBrush(Color.FromArgb(60, 0, 0, 0)),
                new Rectangle(x + 5, y + 5, CardWidth, CardHeight));

            // Draw card background
            using (var gradientBrush = new LinearGradientBrush(rect, Color.White, Color.WhiteSmoke, 45f))
            {
                g.FillRectangle(gradientBrush, rect);
            }

            // Draw border
            var pen = highlight ? new Pen(Color.Gold, 4) : new Pen(Color.Black, 2);
            g.DrawRectangle(pen, rect);

            // Draw rounded corners effect
            g.DrawArc(Pens.DarkGray, x, y, 10, 10, 180, 90);
            g.DrawArc(Pens.DarkGray, x + CardWidth - 10, y, 10, 10, 270, 90);

            // Draw card content
            string suitSymbol = card.Suit switch
            {
                "Hearts" => "♥",
                "Diamonds" => "♦",
                "Clubs" => "♣",
                "Spades" => "♠",
                _ => "?"
            };
            var suitColor = (card.Suit == "Hearts" || card.Suit == "Diamonds")
                ? Brushes.Crimson : Brushes.Black;

            var rankFont = new Font("Segoe UI", 16, FontStyle.Bold);
            var suitFont = new Font("Segoe UI", 14, FontStyle.Bold);

            // Top-left corner
            g.DrawString(card.GetRankString(), rankFont, suitColor, x + 5, y + 3);
            g.DrawString(suitSymbol, suitFont, suitColor, x + 5, y + 25);

            // Bottom-right corner (upside down)
            var state = g.Save();
            g.TranslateTransform(x + CardWidth, y + CardHeight);
            g.RotateTransform(180);
            g.DrawString(card.GetRankString(), rankFont, suitColor, 5, 3);
            g.DrawString(suitSymbol, suitFont, suitColor, 5, 25);
            g.Restore(state);

            // Center symbol
            var centerFont = new Font("Segoe UI", 28, FontStyle.Bold);
            var symbolSize = g.MeasureString(suitSymbol, centerFont);
            g.DrawString(suitSymbol, centerFont, suitColor,
                x + CardWidth / 2 - symbolSize.Width / 2,
                y + CardHeight / 2 - symbolSize.Height / 2);
        }

        private void DrawCardBack(Graphics g, int x, int y)
        {
            var rect = new Rectangle(x, y, CardWidth, CardHeight);

            // Shadow
            g.FillRectangle(new SolidBrush(Color.FromArgb(60, 0, 0, 0)),
                new Rectangle(x + 5, y + 5, CardWidth, CardHeight));

            // Background gradient
            using (var gradientBrush = new LinearGradientBrush(rect,
                Color.FromArgb(139, 0, 0), Color.FromArgb(178, 34, 34), 45f))
            {
                g.FillRectangle(gradientBrush, rect);
            }

            g.DrawRectangle(new Pen(Color.Black, 2), rect);

            // Pattern
            using (var patternBrush = new SolidBrush(Color.FromArgb(150, 255, 215, 0)))
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        g.DrawString("♦", new Font("Segoe UI", 10), patternBrush,
                            x + 10 + i * 15, y + 10 + j * 18);
                    }
                }
            }

            // Center logo
            var logoFont = new Font("Segoe UI", 13, FontStyle.Bold);
            var logo = "GR";
            var logoSize = g.MeasureString(logo, logoFont);
            g.DrawString(logo, logoFont, Brushes.Gold,
                x + CardWidth / 2 - logoSize.Width / 2,
                y + CardHeight / 2 - logoSize.Height / 2);
        }

        // Data classes
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

            public override string ToString() => $"{GetRankString()}{Suit[0]}";

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
            public int Delay;
        }
    }

    // Extension method for rounded rectangles
    public static class GraphicsExtensions
    {
        public static void FillRoundedRectangle(this Graphics g, Brush brush, RectangleF rect, float radius)
        {
            using (var path = new GraphicsPath())
            {
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseFigure();
                g.FillPath(brush, path);
            }
        }
    }
}