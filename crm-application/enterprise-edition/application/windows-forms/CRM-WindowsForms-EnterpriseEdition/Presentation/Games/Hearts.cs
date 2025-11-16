using System.Drawing.Drawing2D;

namespace CRM.Presentation.Games
{
    public partial class Hearts : Form
    {
        private enum Difficulty { Easy, Medium, Hard }
        private enum PassDirection { Left, Right, Across, Hold }

        private Difficulty aiDifficulty = Difficulty.Medium;
        private PassDirection passDirection = PassDirection.Left;
        private int roundNumber = 1;

        private List<Player> players = new();
        private int currentPlayerIndex = 0;
        private List<(int player, Card card)> trick = new();
        private Dictionary<int, int> scores = new();
        private bool heartsBroken = false;

        // Passing phase
        private bool isPassingPhase = true;
        private List<Card> selectedPassCards = new();
        private Dictionary<int, List<Card>> aiPassCards = new();

        // Animation
        private System.Windows.Forms.Timer animationTimer = null!;
        private List<AnimatedCard> animatedCards = new();
        private Action? animationOnComplete = null;

        // Card graphics
        private const int CardWidth = 70;
        private const int CardHeight = 100;
        private const int CardSpacing = 20;
        private const int TableCenterY = 300;
        private const int HandTop = 520;
        private const int TableCenterX = 500;

        // UI
        private ComboBox difficultyComboBox = null!;
        private Button newGameButton = null!;
        private Label trickLabel = null!;
        private Label scoreLabel = null!;
        private Label phaseLabel = null!;
        private Label statusLabel = null!;
        private Button passButton = null!;
        private Panel infoPanel = null!;

        public Hearts()
        {
            InitializeComponent();
            DoubleBuffered = true;
            InitializeGameUI();
            StartNewGame();
        }

        private void InitializeGameUI()
        {
            this.Size = new Size(1100, 750);
            this.BackColor = Color.ForestGreen;
            this.Text = "Hearts";
            this.MinimumSize = new Size(1100, 750);

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

            passButton = new Button
            {
                Text = "Pass Cards",
                Location = new Point(20, 120),
                Width = 130,
                Height = 40,
                Visible = false,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Orange,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            passButton.Click += PassButton_Click;
            Controls.Add(passButton);

            // Right side information panel
            infoPanel = new Panel
            {
                Location = new Point(920, 15),
                Size = new Size(160, 220),
                BackColor = Color.FromArgb(200, 0, 50, 0),
                BorderStyle = BorderStyle.FixedSingle
            };
            Controls.Add(infoPanel);

            phaseLabel = new Label
            {
                Location = new Point(10, 10),
                Size = new Size(140, 40),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = false
            };
            infoPanel.Controls.Add(phaseLabel);

            statusLabel = new Label
            {
                Location = new Point(10, 60),
                Size = new Size(140, 45),
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.Yellow,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.TopLeft,
                AutoSize = false
            };
            infoPanel.Controls.Add(statusLabel);

            trickLabel = new Label
            {
                Location = new Point(10, 115),
                Size = new Size(140, 35),
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                ForeColor = Color.LightCyan,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.TopLeft,
                AutoSize = false
            };
            infoPanel.Controls.Add(trickLabel);

            scoreLabel = new Label
            {
                Location = new Point(10, 160),
                Size = new Size(140, 50),
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.TopLeft,
                AutoSize = false
            };
            infoPanel.Controls.Add(scoreLabel);

            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 16; // ~60 FPS
            animationTimer.Tick += AnimationTimer_Tick;

            this.Paint += Hearts_Paint;
            this.MouseClick += Hearts_MouseClick;
        }

        private void StartNewGame()
        {
            roundNumber = 1;
            passDirection = PassDirection.Left;
            heartsBroken = false;
            isPassingPhase = true;
            selectedPassCards.Clear();
            aiPassCards.Clear();

            players.Clear();
            for (int i = 0; i < 4; i++)
                players.Add(new Player { IsHuman = i == 0, Name = i == 0 ? "You" : $"AI {i}", Hand = new List<Card>() });

            scores = players.ToDictionary(p => players.IndexOf(p), p => 0);
            DealCards();
            currentPlayerIndex = FindTwoOfClubsPlayer();
            trick.Clear();
            animatedCards.Clear();
            animationOnComplete = null;
            passButton.Visible = true;
            phaseLabel.Text = $"Pass: {passDirection}";
            statusLabel.Text = "Select 3 cards";
            UpdateScoreDisplay();
            Invalidate();
        }

        private void DealCards()
        {
            var deck = Card.CreateStandardDeck();
            deck = Card.ShuffleDeck(deck);
            for (int i = 0; i < 52; i++)
                players[i % 4].Hand.Add(deck[i]);
            foreach (var p in players)
                p.Hand = p.Hand.OrderBy(c => c.Suit).ThenBy(c => c.Rank).ToList();
        }

        private int FindTwoOfClubsPlayer()
        {
            for (int i = 0; i < 4; i++)
                if (players[i].Hand.Any(c => c.Suit == CardSuit.Clubs && c.Rank == 2))
                    return i;
            return 0;
        }

        private void Hearts_MouseClick(object? sender, MouseEventArgs e)
        {
            if (animatedCards.Count > 0)
                return;

            var hand = players[0].Hand;
            for (int i = 0; i < hand.Count; i++)
            {
                int x = TableCenterX - (hand.Count * CardWidth + (hand.Count - 1) * CardSpacing) / 2 + i * (CardWidth + CardSpacing);
                int y = HandTop;
                var rect = new Rectangle(x, y, CardWidth, CardHeight);
                if (rect.Contains(e.Location))
                {
                    if (isPassingPhase)
                    {
                        // Select/deselect for passing
                        if (selectedPassCards.Contains(hand[i]))
                            selectedPassCards.Remove(hand[i]);
                        else if (selectedPassCards.Count < 3)
                            selectedPassCards.Add(hand[i]);
                        
                        statusLabel.Text = selectedPassCards.Count == 3 
                            ? "Click Pass Cards" 
                            : $"Select {3 - selectedPassCards.Count} more";
                        Invalidate();
                    }
                    else if (players[currentPlayerIndex].IsHuman)
                    {
                        if (IsValidPlay(hand[i]))
                        {
                            PlayCard(0, hand[i]);
                        }
                        else
                        {
                            statusLabel.Text = "Invalid play!";
                            statusLabel.ForeColor = Color.Red;
                            DelayedAction(1500, () => 
                            {
                                statusLabel.Text = "Your turn";
                                statusLabel.ForeColor = Color.Yellow;
                            });
                        }
                    }
                    break;
                }
            }
        }

        private void PassButton_Click(object? sender, EventArgs e)
        {
            if (selectedPassCards.Count != 3)
            {
                statusLabel.Text = "Select 3 cards!";
                statusLabel.ForeColor = Color.Red;
                DelayedAction(1500, () =>
                {
                    statusLabel.Text = "Select 3 cards";
                    statusLabel.ForeColor = Color.Yellow;
                });
                return;
            }
            
            // AI selects cards to pass
            aiPassCards.Clear();
            for (int i = 1; i < 4; i++)
                aiPassCards[i] = ChooseAIPassCards(players[i]);

            // Animate passing
            AnimatePassing(() =>
            {
                // Actually pass the cards
                DoPassing();
                isPassingPhase = false;
                passButton.Visible = false;
                phaseLabel.Text = "Playing";
                statusLabel.Text = players[currentPlayerIndex].IsHuman ? "Your turn" : $"{players[currentPlayerIndex].Name}'s turn";
                currentPlayerIndex = FindTwoOfClubsPlayer();
                trick.Clear();
                Invalidate();
                if (!players[currentPlayerIndex].IsHuman)
                    PlayAITurn();
            });
        }

        private void AnimatePassing(Action onComplete)
        {
            animatedCards.Clear();
            // Animate player's cards
            var hand = players[0].Hand;
            for (int i = 0; i < selectedPassCards.Count; i++)
            {
                int fromX = TableCenterX - (hand.Count * CardWidth + (hand.Count - 1) * CardSpacing) / 2 + hand.IndexOf(selectedPassCards[i]) * (CardWidth + CardSpacing);
                int fromY = HandTop;
                int toPlayer = GetPassTarget(0);
                var (toX, toY) = GetAIHandPosition(toPlayer);
                animatedCards.Add(new AnimatedCard
                {
                    Card = selectedPassCards[i],
                    PlayerIndex = 0,
                    From = new Point(fromX, fromY),
                    To = new Point(toX, toY),
                    Current = new Point(fromX, fromY),
                    Progress = 0,
                    Rotation = 0,
                    Scale = 1.0f,
                    Delay = i * 2
                });
            }
            // Animate AI cards
            for (int i = 1; i < 4; i++)
            {
                var pass = aiPassCards[i];
                for (int j = 0; j < pass.Count; j++)
                {
                    var (fromX, fromY) = GetAIHandPosition(i);
                    int toPlayer = GetPassTarget(i);
                    int toX, toY;
                    if (toPlayer == 0)
                    {
                        // To human hand
                        toX = TableCenterX + (j - 1) * (CardWidth + CardSpacing);
                        toY = HandTop;
                    }
                    else
                    {
                        (toX, toY) = GetAIHandPosition(toPlayer);
                    }
                    animatedCards.Add(new AnimatedCard
                    {
                        Card = pass[j],
                        PlayerIndex = i,
                        From = new Point(fromX, fromY),
                        To = new Point(toX, toY),
                        Current = new Point(fromX, fromY),
                        Progress = 0,
                        Rotation = 0,
                        Scale = 1.0f,
                        Delay = (i * 3) + j * 2
                    });
                }
            }
            animationOnComplete = onComplete;
            animationTimer.Start();
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
                    anim.Progress += 0.10;
                    if (anim.Progress > 1.0) anim.Progress = 1.0;

                    // Cubic ease-in-out
                    double easedProgress = anim.Progress < 0.5
                        ? 4 * anim.Progress * anim.Progress * anim.Progress
                        : 1 - Math.Pow(-2 * anim.Progress + 2, 3) / 2;

                    anim.Current = new Point(
                        (int)(anim.From.X + (anim.To.X - anim.From.X) * easedProgress),
                        (int)(anim.From.Y + (anim.To.Y - anim.From.Y) * easedProgress)
                    );

                    // Add slight rotation during movement
                    anim.Rotation = (float)(Math.Sin(anim.Progress * Math.PI) * 5);

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

        private void DoPassing()
        {
            // Remove passed cards
            players[0].Hand.RemoveAll(c => selectedPassCards.Contains(c));
            for (int i = 1; i < 4; i++)
                players[i].Hand.RemoveAll(c => aiPassCards[i].Contains(c));

            // Pass cards
            var received = new List<List<Card>> { new(), new(), new(), new() };
            for (int i = 0; i < 4; i++)
            {
                int to = GetPassTarget(i);
                if (i == 0)
                    received[to].AddRange(selectedPassCards);
                else
                    received[to].AddRange(aiPassCards[i]);
            }
            for (int i = 0; i < 4; i++)
                players[i].Hand.AddRange(received[i]);
            foreach (var p in players)
                p.Hand = p.Hand.OrderBy(c => c.Suit).ThenBy(c => c.Rank).ToList();
            selectedPassCards.Clear();
        }

        private int GetPassTarget(int player)
        {
            return passDirection switch
            {
                PassDirection.Left => (player + 1) % 4,
                PassDirection.Right => (player + 3) % 4,
                PassDirection.Across => (player + 2) % 4,
                PassDirection.Hold => player,
                _ => player
            };
        }

        private (int x, int y) GetAIHandPosition(int aiIndex)
        {
            return aiIndex switch
            {
                1 => (TableCenterX + 180, TableCenterY - 20),
                2 => (TableCenterX, TableCenterY - 180),
                3 => (TableCenterX - 180, TableCenterY - 20),
                _ => (TableCenterX, TableCenterY)
            };
        }

        private List<Card> ChooseAIPassCards(Player ai)
        {
            // Hard: pass high hearts and Q♠, then high cards, try to void a suit
            if (aiDifficulty == Difficulty.Hard)
            {
                var pass = new List<Card>();
                // Try to void a suit (other than hearts)
                foreach (CardSuit suit in new[] { CardSuit.Clubs, CardSuit.Diamonds, CardSuit.Spades })
                {
                    var suitCards = ai.Hand.Where(c => c.Suit == suit).ToList();
                    if (suitCards.Count <= 3)
                    {
                        pass.AddRange(suitCards);
                        if (pass.Count >= 3) break;
                    }
                }
                // Add Q♠ and high hearts
                if (pass.Count < 3)
                    pass.AddRange(ai.Hand.Where(c => c.Suit == CardSuit.Spades && c.Rank == 12));
                if (pass.Count < 3)
                    pass.AddRange(ai.Hand.Where(c => c.Suit == CardSuit.Hearts && c.Rank >= 12));
                // Add highest cards
                if (pass.Count < 3)
                    pass.AddRange(ai.Hand.OrderByDescending(c => c.Rank).Where(c => !pass.Contains(c)));
                return pass.Take(3).ToList();
            }
            // Medium: pass Q♠, high hearts, then random
            if (aiDifficulty == Difficulty.Medium)
            {
                var pass = new List<Card>();
                pass.AddRange(ai.Hand.Where(c => c.Suit == CardSuit.Spades && c.Rank == 12));
                pass.AddRange(ai.Hand.Where(c => c.Suit == CardSuit.Hearts && c.Rank >= 12));
                if (pass.Count < 3)
                    pass.AddRange(ai.Hand.OrderBy(_ => Guid.NewGuid()).Where(c => !pass.Contains(c)));
                return pass.Take(3).ToList();
            }
            // Easy: just first 3 cards
            return ai.Hand.Take(3).ToList();
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
                Difficulty.Medium => validCards.OrderBy(_ => Guid.NewGuid()).First(),
                Difficulty.Hard => ChooseHardAICard(ai, validCards),
                _ => validCards.First()
            };
            
            DelayedAction(600, () => PlayCard(currentPlayerIndex, aiCard));
        }

        private List<Card> GetValidCards(Player player, List<(int player, Card card)> currentTrick)
        {
            var hand = player.Hand;
            if (currentTrick.Count == 0)
            {
                // First trick, first play: must play 2♣
                if (hand.Any(c => c.Suit == CardSuit.Clubs && c.Rank == 2) && trick.Count == 0 && roundNumber == 1)
                    return hand.Where(c => c.Suit == CardSuit.Clubs && c.Rank == 2).ToList();

                // Can't lead hearts until broken, unless only hearts left
                if (!heartsBroken && hand.Any(c => c.Suit != CardSuit.Hearts))
                    return hand.Where(c => c.Suit != CardSuit.Hearts).ToList();
                return hand;
            }
            var leadSuit = currentTrick[0].card.Suit;
            var valid = hand.Where(c => c.Suit == leadSuit).ToList();
            return valid.Any() ? valid : hand;
        }

        private Card ChooseHardAICard(Player ai, List<Card> validCards)
        {
            // Hard AI: avoid points, dump Q♠ if safe, try to void suits, play low if possible
            if (validCards.Any(c => c.Suit == CardSuit.Spades && c.Rank == 12))
            {
                if (trick.Count > 0 && trick[0].card.Suit == CardSuit.Spades)
                {
                    if (ai.Hand.Count(c => c.Suit == CardSuit.Spades) > 1)
                        return validCards.First(c => c.Suit == CardSuit.Spades && c.Rank == 12);
                }
            }
            
            var points = validCards.Where(c => c.GetHeartsPoints() > 0).ToList();
            if (points.Any())
            {
                return points.OrderBy(c => c.Rank).First();
            }
            
            var singleton = validCards.GroupBy(c => c.Suit).Where(g => ai.Hand.Count(x => x.Suit == g.Key) == 1).SelectMany(g => g).ToList();
            if (singleton.Any())
                return singleton.OrderBy(c => c.Rank).First();
            
            return validCards.OrderBy(c => c.Rank).First();
        }

        private bool IsValidPlay(Card card)
        {
            var hand = players[0].Hand;
            if (trick.Count == 0)
            {
                // First trick, first play: must play 2♣
                if (hand.Any(c => c.Suit == CardSuit.Clubs && c.Rank == 2) && trick.Count == 0 && roundNumber == 1)
                    return card.Suit == CardSuit.Clubs && card.Rank == 2;

                // Can't lead hearts until broken, unless only hearts left
                if (!heartsBroken && hand.Any(c => c.Suit != CardSuit.Hearts))
                    return card.Suit != CardSuit.Hearts;
                return true;
            }
            var leadSuit = trick[0].card.Suit;
            if (card.Suit == leadSuit)
                return true;
            return !hand.Any(c => c.Suit == leadSuit);
        }

        private void PlayCard(int playerIndex, Card card)
        {
            var player = players[playerIndex];
            player.Hand.Remove(card);

            // Animate card to table center
            int fromX, fromY;
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
            
            int toX = TableCenterX + (int)(Math.Cos(Math.PI / 2 * playerIndex) * 100) - CardWidth / 2;
            int toY = TableCenterY + (int)(Math.Sin(Math.PI / 2 * playerIndex) * 100) - CardHeight / 2;

            animatedCards.Add(new AnimatedCard
            {
                Card = card,
                PlayerIndex = playerIndex,
                From = new Point(fromX, fromY),
                To = new Point(toX, toY),
                Current = new Point(fromX, fromY),
                Progress = 0,
                Rotation = 0,
                Scale = 1.0f,
                Delay = 0
            });

            animationOnComplete = () =>
            {
                trick.Add((playerIndex, card));
                if (card.Suit == CardSuit.Hearts)
                    heartsBroken = true;
                    
                if (trick.Count == 4)
                {
                    int winner = DetermineTrickWinner();
                    int trickPoints = trick.Sum(x => x.card.GetHeartsPoints());
                    scores[winner] += trickPoints;
                    
                    trickLabel.Text = $"Trick: {players[winner].Name}";
                    
                    DelayedAction(1200, () =>
                    {
                        currentPlayerIndex = winner;
                        trick.Clear();
                        
                        if (players[0].Hand.Count == 0)
                        {
                            // End of round
                            roundNumber++;
                            passDirection = passDirection switch
                            {
                                PassDirection.Left => PassDirection.Right,
                                PassDirection.Right => PassDirection.Across,
                                PassDirection.Across => PassDirection.Hold,
                                PassDirection.Hold => PassDirection.Left,
                                _ => PassDirection.Left
                            };
                            isPassingPhase = passDirection != PassDirection.Hold;
                            phaseLabel.Text = isPassingPhase ? $"Pass: {passDirection}" : "Playing";
                            passButton.Visible = isPassingPhase;
                            
                            if (isPassingPhase)
                            {
                                selectedPassCards.Clear();
                                aiPassCards.Clear();
                                statusLabel.Text = "Select 3 cards";
                            }
                            
                            // Check for game end
                            if (scores.Values.Any(s => s >= 100))
                            {
                                ShowEndOfGameSummary();
                                StartNewGame();
                                return;
                            }
                            else
                            {
                                DealCards();
                                foreach (var p in players)
                                    p.Hand = p.Hand.OrderBy(c => c.Suit).ThenBy(c => c.Rank).ToList();
                                currentPlayerIndex = FindTwoOfClubsPlayer();
                                heartsBroken = false;
                                trick.Clear();
                                UpdateScoreDisplay();
                                Invalidate();
                                if (!players[currentPlayerIndex].IsHuman && !isPassingPhase)
                                    PlayAITurn();
                                return;
                            }
                        }
                        
                        statusLabel.Text = players[currentPlayerIndex].IsHuman ? "Your turn" : $"{players[currentPlayerIndex].Name}";
                        UpdateScoreDisplay();
                        Invalidate();
                        if (!players[currentPlayerIndex].IsHuman && !isPassingPhase)
                            PlayAITurn();
                    });
                }
                else
                {
                    currentPlayerIndex = (currentPlayerIndex + 1) % 4;
                    statusLabel.Text = players[currentPlayerIndex].IsHuman ? "Your turn" : $"{players[currentPlayerIndex].Name}";
                    Invalidate();
                    if (!players[currentPlayerIndex].IsHuman && !isPassingPhase)
                        PlayAITurn();
                }
            };

            animationTimer.Start();
        }

        private int DetermineTrickWinner()
        {
            var leadSuit = trick[0].card.Suit;
            var leadCards = trick.Select((x, i) => new { Card = x.card, Player = x.player, Index = i })
                                 .Where(x => x.Card.Suit == leadSuit)
                                 .ToList();
            var highest = leadCards.OrderByDescending(x => x.Card.Rank).First();
            return highest.Player;
        }

        private void UpdateScoreDisplay()
        {
            scoreLabel.Text = string.Join("\n", players.Select((p, i) => $"{p.Name}: {scores[i]}"));
        }

        private void ShowEndOfGameSummary()
        {
            int minScore = scores.Values.Min();
            var winners = players.Where((p, i) => scores[i] == minScore).Select(p => p.Name).ToList();
            string summary = "Game Over!\n\n";
            summary += string.Join("\n", players.Select((p, i) => $"{p.Name}: {scores[i]} points"));
            summary += "\n\nWinner" + (winners.Count > 1 ? "s" : "") + ": " + string.Join(", ", winners);
            MessageBox.Show(summary, "Hearts - Game Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Hearts_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.Clear(Color.ForestGreen);

            // Draw player labels
            DrawPlayerLabel(g, "You", TableCenterX, HandTop - 30);
            DrawPlayerLabel(g, "AI 1", TableCenterX + 180, TableCenterY - 50);
            DrawPlayerLabel(g, "AI 2", TableCenterX, TableCenterY - 210);
            DrawPlayerLabel(g, "AI 3", TableCenterX - 180, TableCenterY - 50);

            // Draw player hand
            DrawHand(g, players[0].Hand, TableCenterX, HandTop, true);

            // Draw AI hands (as card backs)
            DrawAIHand(g, 1, TableCenterX + 180, TableCenterY - 20);
            DrawAIHand(g, 2, TableCenterX, TableCenterY - 180);
            DrawAIHand(g, 3, TableCenterX - 180, TableCenterY - 20);

            // Draw trick cards on table (not being animated)
            foreach (var (player, card) in trick)
            {
                bool isAnimating = animatedCards.Any(a => a.Card == card && a.PlayerIndex == player);
                if (!isAnimating)
                {
                    int px = TableCenterX + (int)(Math.Cos(Math.PI / 2 * player) * 100) - CardWidth / 2;
                    int py = TableCenterY + (int)(Math.Sin(Math.PI / 2 * player) * 100) - CardHeight / 2;
                    DrawCard(g, card, px, py, false, false);
                }
            }

            // Draw animated cards
            foreach (var anim in animatedCards.Where(a => a.Delay == 0))
            {
                DrawAnimatedCard(g, anim);
            }

            // Draw selected pass cards highlight
            if (isPassingPhase)
            {
                var hand = players[0].Hand;
                for (int i = 0; i < hand.Count; i++)
                {
                    if (selectedPassCards.Contains(hand[i]))
                    {
                        int x = TableCenterX - (hand.Count * CardWidth + (hand.Count - 1) * CardSpacing) / 2 + i * (CardWidth + CardSpacing);
                        int y = HandTop;
                        g.DrawRectangle(new Pen(Color.Gold, 4), new Rectangle(x - 2, y - 2, CardWidth + 4, CardHeight + 4));
                    }
                }
            }
        }

        private void DrawPlayerLabel(Graphics g, string name, int x, int y)
        {
            var font = new Font("Segoe UI", 11, FontStyle.Bold);
            var size = g.MeasureString(name, font);

            var backRect = new RectangleF(x - size.Width / 2 - 8, y, size.Width + 16, size.Height + 4);
            using (var brush = new SolidBrush(Color.FromArgb(150, 0, 0, 0)))
            {
                g.FillRoundedRectangle(brush, backRect, 5);
            }
            g.DrawString(name, font, Brushes.White, x - size.Width / 2, y);
        }

        private void DrawHand(Graphics g, List<Card> hand, int centerX, int y, bool clickable)
        {
            for (int i = 0; i < hand.Count; i++)
            {
                int x = centerX - (hand.Count * CardWidth + (hand.Count - 1) * CardSpacing) / 2 + i * (CardWidth + CardSpacing);
                bool isSelected = isPassingPhase && selectedPassCards.Contains(hand[i]);
                int offsetY = isSelected ? -15 : 0;
                DrawCard(g, hand[i], x, y + offsetY, clickable, isSelected);
            }
        }

        private void DrawAIHand(Graphics g, int aiIndex, int x, int y)
        {
            var hand = players[aiIndex].Hand;
            for (int i = 0; i < hand.Count; i++)
            {
                DrawCardBack(g, x + i * 10, y);
            }
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
            string suitSymbol = card.GetSuitString();
            var suitColor = card.GetSuitBrush();

            var rankFont = new Font("Segoe UI", 14, FontStyle.Bold);
            var suitFont = new Font("Segoe UI", 12, FontStyle.Bold);

            // Top-left corner
            g.DrawString(card.GetRankString(), rankFont, suitColor, x + 5, y + 3);
            g.DrawString(suitSymbol, suitFont, suitColor, x + 5, y + 22);

            // Bottom-right corner (upside down)
            var state = g.Save();
            g.TranslateTransform(x + CardWidth, y + CardHeight);
            g.RotateTransform(180);
            g.DrawString(card.GetRankString(), rankFont, suitColor, 5, 3);
            g.DrawString(suitSymbol, suitFont, suitColor, 5, 22);
            g.Restore(state);

            // Center symbol
            var centerFont = new Font("Segoe UI", 24, FontStyle.Bold);
            var symbolSize = g.MeasureString(suitSymbol, centerFont);
            g.DrawString(suitSymbol, centerFont, suitColor,
                x + CardWidth / 2 - symbolSize.Width / 2,
                y + CardHeight / 2 - symbolSize.Height / 2);
        }

        private void DrawAnimatedCard(Graphics g, AnimatedCard anim)
        {
            var state = g.Save();

            g.TranslateTransform(anim.Current.X + CardWidth / 2, anim.Current.Y + CardHeight / 2);
            g.RotateTransform(anim.Rotation);
            g.ScaleTransform(anim.Scale, anim.Scale);
            g.TranslateTransform(-CardWidth / 2, -CardHeight / 2);

            DrawCard(g, anim.Card, 0, 0, false, false);

            g.Restore(state);
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
                        g.DrawString("♥", new Font("Segoe UI", 10), patternBrush,
                            x + 10 + i * 15, y + 10 + j * 18);
                    }
                }
            }

            // Center logo
            var logoFont = new Font("Segoe UI", 13, FontStyle.Bold);
            var logo = "♥";
            var logoSize = g.MeasureString(logo, logoFont);
            g.DrawString(logo, logoFont, Brushes.Gold,
                x + CardWidth / 2 - logoSize.Width / 2,
                y + CardHeight / 2 - logoSize.Height / 2);
        }

        // --- Data classes ---
        private class Player
        {
            public string Name { get; set; } = string.Empty;
            public bool IsHuman { get; set; }
            public List<Card> Hand { get; set; } = new();
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
}