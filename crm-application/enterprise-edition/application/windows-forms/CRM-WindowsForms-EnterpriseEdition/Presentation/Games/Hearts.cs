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
        private System.Windows.Forms.Timer animationTimer;
        private List<AnimatedCard> animatedCards = new();
        private Action? animationOnComplete = null;

        // Card graphics
        private const int CardWidth = 60;
        private const int CardHeight = 90;
        private const int CardSpacing = 20;
        private const int TableCenterY = 300;
        private const int HandTop = 500;
        private const int TableCenterX = 450;

        // UI
        private ComboBox difficultyComboBox;
        private Button newGameButton;
        private Label trickLabel;
        private Label scoreLabel;
        private Label phaseLabel;
        private Button passButton;

        public Hearts()
        {
            InitializeComponent();
            DoubleBuffered = true;
            InitializeGameUI();
            StartNewGame();
        }

        private void InitializeGameUI()
        {
            this.Size = new Size(1000, 650);

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
                Size = new Size(700, 30),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };
            Controls.Add(scoreLabel);

            passButton = new Button
            {
                Text = "Pass Selected Cards",
                Location = new Point(20, 160),
                Width = 180,
                Height = 30,
                Visible = false,
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.Control
            };
            passButton.Click += PassButton_Click;
            Controls.Add(passButton);

            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 20;
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
            phaseLabel.Text = $"Passing phase: {passDirection}";
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

        private int FindTwoOfClubsPlayer()
        {
            for (int i = 0; i < 4; i++)
                if (players[i].Hand.Any(c => c.Suit == "Clubs" && c.Rank == 2))
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
                            MessageBox.Show("Invalid play according to Hearts rules.");
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
                MessageBox.Show("Select exactly 3 cards to pass.");
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
                phaseLabel.Text = "Trick phase";
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
                    Progress = 0
                });
            }
            // Animate AI cards
            for (int i = 1; i < 4; i++)
            {
                var aiHand = players[i].Hand;
                var pass = aiPassCards[i];
                for (int j = 0; j < pass.Count; j++)
                {
                    int fromX, fromY;
                    (fromX, fromY) = GetAIHandPosition(i);
                    int toPlayer = GetPassTarget(i);
                    int toX, toY;
                    if (toPlayer == 0)
                    {
                        // To human hand
                        toX = TableCenterX - (aiHand.Count * CardWidth + (aiHand.Count - 1) * CardSpacing) / 2 + (aiHand.Count + j) * (CardWidth + CardSpacing);
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
                        Progress = 0
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
                if (anim.Progress < 1.0)
                {
                    anim.Progress += 0.08;
                    if (anim.Progress > 1.0) anim.Progress = 1.0;
                    anim.Current = new Point(
                        (int)(anim.From.X + (anim.To.X - anim.From.X) * anim.Progress),
                        (int)(anim.From.Y + (anim.To.Y - anim.From.Y) * anim.Progress)
                    );
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
            // Centered more horizontally and vertically
            return aiIndex switch
            {
                1 => (TableCenterX + 120, TableCenterY - 40),
                2 => (TableCenterX, TableCenterY - 140),
                3 => (TableCenterX - 120, TableCenterY - 40),
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
                var suits = new[] { "Clubs", "Diamonds", "Spades" };
                foreach (var suit in suits)
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
                    pass.AddRange(ai.Hand.Where(c => c.Suit == "Spades" && c.Rank == 12));
                if (pass.Count < 3)
                    pass.AddRange(ai.Hand.Where(c => c.Suit == "Hearts" && c.Rank >= 12));
                // Add highest cards
                if (pass.Count < 3)
                    pass.AddRange(ai.Hand.OrderByDescending(c => c.Rank).Where(c => !pass.Contains(c)));
                return pass.Take(3).ToList();
            }
            // Medium: pass Q♠, high hearts, then random
            if (aiDifficulty == Difficulty.Medium)
            {
                var pass = new List<Card>();
                pass.AddRange(ai.Hand.Where(c => c.Suit == "Spades" && c.Rank == 12));
                pass.AddRange(ai.Hand.Where(c => c.Suit == "Hearts" && c.Rank >= 12));
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
            var timer = new System.Windows.Forms.Timer { Interval = 400 };
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                timer.Dispose();
                PlayCard(currentPlayerIndex, aiCard);
            };
            timer.Start();
        }

        private List<Card> GetValidCards(Player player, List<(int player, Card card)> currentTrick)
        {
            var hand = player.Hand;
            if (currentTrick.Count == 0)
            {
                // First trick, first play: must play 2♣
                if (hand.Any(c => c.Suit == "Clubs" && c.Rank == 2) && trick.Count == 0 && roundNumber == 1)
                    return hand.Where(c => c.Suit == "Clubs" && c.Rank == 2).ToList();

                // Can't lead hearts until broken, unless only hearts left
                if (!heartsBroken && hand.Any(c => c.Suit != "Hearts"))
                    return hand.Where(c => c.Suit != "Hearts").ToList();
                return hand;
            }
            var leadSuit = currentTrick[0].card.Suit;
            var valid = hand.Where(c => c.Suit == leadSuit).ToList();
            return valid.Any() ? valid : hand;
        }

        private Card ChooseHardAICard(Player ai, List<Card> validCards)
        {
            // Hard AI: avoid points, dump Q♠ if safe, try to void suits, play low if possible
            // 1. If can play Q♠ and someone else has led spades, and Q♠ is not the only spade, play Q♠
            if (validCards.Any(c => c.Suit == "Spades" && c.Rank == 12))
            {
                if (trick.Count > 0 && trick[0].card.Suit == "Spades")
                {
                    // If not leading, and not only spade, play Q♠
                    if (ai.Hand.Count(c => c.Suit == "Spades") > 1)
                        return validCards.First(c => c.Suit == "Spades" && c.Rank == 12);
                }
            }
            // 2. If can dump points and can't win trick, do so
            var points = validCards.Where(c => c.GetHeartsPoints() > 0).ToList();
            if (points.Any())
            {
                // Play lowest point card
                return points.OrderBy(c => c.Rank).First();
            }
            // 3. Try to void a suit by playing singleton
            var singleton = validCards.GroupBy(c => c.Suit).Where(g => ai.Hand.Count(x => x.Suit == g.Key) == 1).SelectMany(g => g).ToList();
            if (singleton.Any())
                return singleton.OrderBy(c => c.Rank).First();
            // 4. Otherwise, play lowest card
            return validCards.OrderBy(c => c.Rank).First();
        }

        private bool IsValidPlay(Card card)
        {
            var hand = players[0].Hand;
            if (trick.Count == 0)
            {
                // First trick, first play: must play 2♣
                if (hand.Any(c => c.Suit == "Clubs" && c.Rank == 2) && trick.Count == 0 && roundNumber == 1)
                    return card.Suit == "Clubs" && card.Rank == 2;

                // Can't lead hearts until broken, unless only hearts left
                if (!heartsBroken && hand.Any(c => c.Suit != "Hearts"))
                    return card.Suit != "Hearts";
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
            int fromX, fromY, toX, toY;
            if (playerIndex == 0)
            {
                int i = trick.Count;
                fromX = TableCenterX - (player.Hand.Count * CardWidth + (player.Hand.Count) * CardSpacing) / 2 + i * (CardWidth + CardSpacing);
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
                Progress = 0
            });

            animationOnComplete = () =>
            {
                trick.Add((playerIndex, card));
                if (card.Suit == "Hearts")
                    heartsBroken = true;
                if (trick.Count == 4)
                {
                    int winner = DetermineTrickWinner();
                    int trickPoints = trick.Sum(x => x.card.GetHeartsPoints());
                    scores[winner] += trickPoints;
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
                        phaseLabel.Text = isPassingPhase ? $"Passing phase: {passDirection}" : "Trick phase";
                        passButton.Visible = isPassingPhase;
                        if (isPassingPhase)
                        {
                            selectedPassCards.Clear();
                            aiPassCards.Clear();
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
                            Invalidate();
                            if (!players[currentPlayerIndex].IsHuman && !isPassingPhase)
                                PlayAITurn();
                            return;
                        }
                    }
                }
                else
                {
                    currentPlayerIndex = (currentPlayerIndex + 1) % 4;
                }
                Invalidate();
                if (!players[currentPlayerIndex].IsHuman && !isPassingPhase)
                    PlayAITurn();
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

        private void ShowEndOfGameSummary()
        {
            int minScore = scores.Values.Min();
            var winners = players.Where((p, i) => scores[i] == minScore).Select(p => p.Name).ToList();
            string summary = "Game Over!\n\n";
            summary += string.Join("\n", players.Select((p, i) => $"{p.Name}: {scores[i]} points"));
            summary += "\n\nWinner" + (winners.Count > 1 ? "s" : "") + ": " + string.Join(", ", winners);
            MessageBox.Show(summary, "Hearts - Game Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Hearts_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.DarkGreen);

            // Draw player hands
            DrawHand(g, players[0].Hand, TableCenterX, HandTop, true);

            // Draw AI hands (as card backs)
            DrawAIHand(g, 1, TableCenterX + 200, TableCenterY - 100);
            DrawAIHand(g, 2, TableCenterX, TableCenterY - 200);
            DrawAIHand(g, 3, TableCenterX - 200, TableCenterY - 100);

            // Draw trick cards (animated)
            foreach (var anim in animatedCards)
            {
                DrawCard(g, anim.Card, anim.Current.X, anim.Current.Y, true, false);
            }

            // Draw trick on table
            foreach (var (player, card) in trick)
            {
                int px = TableCenterX + (int)(Math.Cos(Math.PI / 2 * player) * 80) - CardWidth / 2;
                int py = TableCenterY + (int)(Math.Sin(Math.PI / 2 * player) * 80) - CardHeight / 2;
                DrawCard(g, card, px, py, false, false);
            }

            // Draw labels
            trickLabel.Text = $"Trick: {string.Join(", ", trick.Select(x => $"{players[x.player].Name}: {x.card}"))}";
            scoreLabel.Text = $"Scores: {string.Join(" | ", players.Select((p, i) => $"{p.Name}: {scores[i]}"))}";

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

        private void DrawHand(Graphics g, List<Card> hand, int centerX, int y, bool clickable)
        {
            for (int i = 0; i < hand.Count; i++)
            {
                int x = centerX - (hand.Count * CardWidth + (hand.Count - 1) * CardSpacing) / 2 + i * (CardWidth + CardSpacing);
                DrawCard(g, hand[i], x, y, clickable, isPassingPhase && selectedPassCards.Contains(hand[i]));
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

        private void DrawCard(Graphics g, Card card, int x, int y, bool clickable, bool highlight)
        {
            var rect = new Rectangle(x, y, CardWidth, CardHeight);
            g.FillRectangle(highlight ? Brushes.Gold : clickable ? Brushes.LightYellow : Brushes.White, rect);
            g.DrawRectangle(Pens.Black, rect);
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
            g.DrawString($"{card.GetRankString()}{suitSymbol}", font, suitColor, x + 8, y + 8);
        }

        private void DrawCardBack(Graphics g, int x, int y, bool highlight)
        {
            var rect = new Rectangle(x, y, CardWidth, CardHeight);
            g.FillRectangle(highlight ? Brushes.LightBlue : Brushes.SteelBlue, rect);
            g.DrawRectangle(Pens.Black, rect);
            g.DrawString("♥", new Font("Segoe UI", 20, FontStyle.Bold), Brushes.White, x + 15, y + 30);
        }

        // --- Data classes ---

        private class Player
        {
            public string Name { get; set; }
            public bool IsHuman { get; set; }
            public List<Card> Hand { get; set; }
        }

        private class Card
        {
            public string Suit { get; set; }
            public int Rank { get; set; } // 2-14 (14 = Ace)

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

            public int GetHeartsPoints()
            {
                if (Suit == "Hearts") return 1;
                if (Suit == "Spades" && Rank == 12) return 13; // Queen of Spades
                return 0;
            }
        }

        private class AnimatedCard
        {
            public Card Card;
            public int PlayerIndex;
            public Point From;
            public Point To;
            public Point Current;
            public double Progress;
        }
    }
}