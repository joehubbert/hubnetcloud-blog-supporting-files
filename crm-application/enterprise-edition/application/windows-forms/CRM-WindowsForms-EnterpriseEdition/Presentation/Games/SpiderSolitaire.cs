using System.Drawing.Drawing2D;

namespace CRM.Presentation.Games
{
    public partial class SpiderSolitaire : Form
    {
        private const int CardWidth = 70;
        private const int CardHeight = 100;
        private const int CardSpacing = 15;
        private const int TopMargin = 300;
        private const int LeftMargin = 30;
        private const int TableauCount = 10;
        private const int StockDealCount = 10;

        private int suitCount = 1;

        private List<CardState>[] tableau = new List<CardState>[TableauCount];
        private Stack<Card> stock = new Stack<Card>();
        private List<List<Card>> foundations = new List<List<Card>>();
        private Stack<GameState> undoStack = new Stack<GameState>();

        // UI Elements
        private ComboBox difficultyComboBox = null!;
        private Button newGameButton = null!
;
        private Button undoButton = null!;
        private Button dealButton = null!;
        private Panel infoPanel = null!;
        private Label scoreLabel = null!;
        private Label movesLabel = null!;
        private Label statusLabel = null!;
        private Label suitCountLabel = null!;

        // Animation
        private System.Windows.Forms.Timer animationTimer = null!;
        private List<AnimatedCard> currentAnimations = new List<AnimatedCard>();
        private Action? animationOnComplete = null;

        // Scoring
        private int score = 500;
        private int moves = 0;

        // Drag and drop fields
        private bool isDragging = false;
        private Point dragStartPoint;
        private Point dragCurrentPoint;
        private List<CardState>? draggingCards = null;
        private int? dragSourceCol = null;
        private int? dragSourceRow = null;

        public SpiderSolitaire(int initialSuitCount = 2)
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.suitCount = initialSuitCount;
            InitializeGameUI();
            StartNewGame();
        }

        private void InitializeGameUI()
        {
            this.Size = new Size(1300, 750);
            this.BackColor = Color.ForestGreen;
            this.Text = "Spider Solitaire";
            this.MinimumSize = new Size(1300, 750);

            // Left column controls
            difficultyComboBox = new ComboBox
            {
                Location = new Point(20, 20),
                Width = 130,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10)
            };
            difficultyComboBox.Items.AddRange(new object[] { "Easy (1 Suit)", "Medium (2 Suits)", "Hard (3 Suits)", "Expert (4 Suits)" });
            difficultyComboBox.SelectedIndex = suitCount switch
            {
                1 => 0,
                2 => 1,
                3 => 2,
                4 => 3,
                _ => 1 // Default to Medium
            };
            difficultyComboBox.SelectedIndexChanged += (s, e) =>
            {
                int newSuitCount = difficultyComboBox.SelectedIndex switch
                {
                    0 => 1, // Easy
                    1 => 2, // Medium
                    2 => 3, // Hard
                    3 => 4, // Expert
                    _ => 2
                };
                
                if (newSuitCount != suitCount)
                {
                    suitCount = newSuitCount;
                    UpdateSuitCountLabel();
                    StartNewGame();
                }
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

            undoButton = new Button
            {
                Text = "Undo",
                Location = new Point(20, 115),
                Width = 130,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightYellow,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            undoButton.Click += (s, e) => Undo();
            Controls.Add(undoButton);

            dealButton = new Button
            {
                Text = "Deal Row",
                Location = new Point(20, 165),
                Width = 130,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightBlue,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            dealButton.Click += (s, e) => DealStock();
            Controls.Add(dealButton);

            // Right side information panel
            infoPanel = new Panel
            {
                Location = new Point(1120, 15),
                Size = new Size(160, 220),
                BackColor = Color.FromArgb(200, 0, 50, 0),
                BorderStyle = BorderStyle.FixedSingle
            };
            Controls.Add(infoPanel);

            suitCountLabel = new Label
            {
                Location = new Point(10, 10),
                Size = new Size(140, 40),
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = false,
                Text = "1 Suit"
            };
            infoPanel.Controls.Add(suitCountLabel);

            scoreLabel = new Label
            {
                Location = new Point(10, 60),
                Size = new Size(140, 40),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = false,
                Text = "Score: 500"
            };
            infoPanel.Controls.Add(scoreLabel);

            movesLabel = new Label
            {
                Location = new Point(10, 110),
                Size = new Size(140, 40),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = false,
                Text = "Moves: 0"
            };
            infoPanel.Controls.Add(movesLabel);

            statusLabel = new Label
            {
                Location = new Point(10, 160),
                Size = new Size(140, 50),
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.Yellow,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.TopLeft,
                AutoSize = false,
                Text = "Drag cards to move"
            };
            infoPanel.Controls.Add(statusLabel);

            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 16; // ~60 FPS
            animationTimer.Tick += AnimationTimer_Tick;

            this.Paint += SpiderSolitaire_Paint;
            this.MouseDown += SpiderSolitaire_MouseDown;
            this.MouseMove += SpiderSolitaire_MouseMove;
            this.MouseUp += SpiderSolitaire_MouseUp;
        }

        private void UpdateSuitCountLabel()
        {
            suitCountLabel.Text = suitCount switch
            {
                1 => "1 Suit",
                2 => "2 Suits",
                3 => "3 Suits",
                4 => "4 Suits",
                _ => "2 Suits"
            };
        }

        private void StartNewGame()
        {
            var suits = suitCount switch
            {
                1 => new[] { CardSuit.Spades },
                2 => new[] { CardSuit.Spades, CardSuit.Hearts },
                3 => new[] { CardSuit.Spades, CardSuit.Hearts, CardSuit.Diamonds },
                4 => new[] { CardSuit.Spades, CardSuit.Hearts, CardSuit.Diamonds, CardSuit.Clubs },
                _ => new[] { CardSuit.Spades, CardSuit.Hearts }
            };

            // Distribute 8 decks as evenly as possible among the suits
            int[] decksPerSuit = new int[suits.Length];
            int baseDecks = 8 / suits.Length;
            int remainder = 8 % suits.Length;
            for (int i = 0; i < suits.Length; i++)
                decksPerSuit[i] = baseDecks + (i < remainder ? 1 : 0);

            var cards = new List<Card>();
            for (int i = 0; i < suits.Length; i++)
            {
                for (int d = 0; d < decksPerSuit[i]; d++)
                {
                    for (int r = 1; r <= 13; r++)
                    {
                        cards.Add(new Card(suits[i], r));
                    }
                }
            }

            cards = Card.ShuffleDeck(cards);

            for (int i = 0; i < TableauCount; i++)
                tableau[i] = new List<CardState>();

            int cardIdx = 0;
            for (int i = 0; i < TableauCount; i++)
            {
                int count = (i < 4) ? 6 : 5;
                for (int j = 0; j < count; j++)
                {
                    var card = cards[cardIdx++];
                    tableau[i].Add(new CardState(card, j == count - 1));
                }
            }

            stock = new Stack<Card>(cards.Skip(cardIdx).Reverse());
            foundations.Clear();
            undoStack.Clear();
            currentAnimations.Clear();
            animationOnComplete = null;
            animationTimer.Stop();
            
            score = 500;
            moves = 0;
            isDragging = false;
            draggingCards = null;
            dragSourceCol = null;
            dragSourceRow = null;

            UpdateLabels();
            UpdateSuitCountLabel();
            statusLabel.Text = "Drag cards to move";
            statusLabel.ForeColor = Color.Yellow;
            Invalidate();
        }

        private void UpdateLabels()
        {
            scoreLabel.Text = $"Score: {score}";
            movesLabel.Text = $"Moves: {moves}";
            dealButton.Enabled = stock.Count >= StockDealCount && tableau.All(col => col.Count > 0);
        }

        private void Undo()
        {
            if (animationTimer.Enabled || undoStack.Count == 0) return;

            var state = undoStack.Pop();
            for (int i = 0; i < TableauCount; i++)
                tableau[i] = state.Tableau[i].Select(cs => cs.Clone()).ToList();
            stock = new Stack<Card>(state.Stock.AsEnumerable().Reverse());
            foundations = state.Foundations.Select(f => f.ToList()).ToList();
            score = state.Score;
            moves = state.Moves;
            
            isDragging = false;
            draggingCards = null;
            dragSourceCol = null;
            dragSourceRow = null;
            
            UpdateLabels();
            statusLabel.Text = "Undone";
            statusLabel.ForeColor = Color.LightGreen;
            Invalidate();
        }

        private void SaveStateForUndo()
        {
            undoStack.Push(new GameState
            {
                Tableau = tableau.Select(col => col.Select(cs => cs.Clone()).ToList()).ToArray(),
                Stock = stock.ToList(),
                Foundations = foundations.Select(f => f.ToList()).ToList(),
                Score = score,
                Moves = moves
            });
        }

        private void DealStock()
        {
            if (animationTimer.Enabled) return;
            if (stock.Count < StockDealCount) return;
            if (tableau.Any(col => col.Count == 0))
            {
                statusLabel.Text = "Fill empty columns first!";
                statusLabel.ForeColor = Color.Red;
                return;
            }

            SaveStateForUndo();
            var cardsToDeal = new List<Card>();
            for (int i = 0; i < TableauCount; i++)
            {
                var card = stock.Pop();
                cardsToDeal.Add(card);
            }

            var froms = new List<Point>();
            var tos = new List<Point>();
            
            for (int i = 0; i < TableauCount; i++)
            {
                froms.Add(new Point(170 + TableauCount * (CardWidth + CardSpacing), TopMargin));
                tos.Add(new Point(170 + i * (CardWidth + CardSpacing), TopMargin + tableau[i].Count * 25));
            }

            AnimateMultiCardMove(cardsToDeal, froms, tos, () =>
            {
                for (int i = 0; i < TableauCount; i++)
                    tableau[i].Add(new CardState(cardsToDeal[i], true));
                
                score -= 10;
                moves++;
                UpdateLabels();
                statusLabel.Text = "Row dealt";
                statusLabel.ForeColor = Color.LightCyan;
                Invalidate();
            });
        }

        private void SpiderSolitaire_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.Clear(Color.ForestGreen);

            // Draw section labels
            DrawSectionLabel(g, "Stock", 170 + TableauCount * (CardWidth + CardSpacing), TopMargin - 35);
            DrawSectionLabel(g, "Completed", 170 + (TableauCount + 1) * (CardWidth + CardSpacing) + 20, TopMargin - 35);

            // Draw Stock
            int stockX = 170 + TableauCount * (CardWidth + CardSpacing);
            int stockY = TopMargin;
            
            if (stock.Count > 0)
                DrawCardBack(g, stockX, stockY);
            else
                DrawCardSlot(g, stockX, stockY, "✓", false);

            g.DrawString($"{stock.Count / 10} deals", new Font("Segoe UI", 9, FontStyle.Bold),
                Brushes.White, stockX, stockY + CardHeight + 5);

            // Draw Foundations (completed sequences)
            int foundX = stockX + CardWidth + CardSpacing + 20;
            int foundY = TopMargin;
            for (int i = 0; i < foundations.Count; i++)
            {
                if (foundations[i].Count > 0)
                {
                    var card = foundations[i].Last();
                    DrawCard(g, card, foundX, foundY + i * (CardHeight / 2 + 5), false);
                }
            }

            if (foundations.Count > 0)
            {
                g.DrawString($"{foundations.Count}/8", new Font("Segoe UI", 10, FontStyle.Bold),
                    Brushes.White, foundX, foundY + foundations.Count * (CardHeight / 2 + 5) + 5);
            }

            // Draw Tableau
            for (int i = 0; i < TableauCount; i++)
            {
                int x = 170 + i * (CardWidth + CardSpacing);
                int y = TopMargin;

                if (tableau[i].Count == 0)
                {
                    DrawCardSlot(g, x, y, "K", false);
                }

                for (int j = 0; j < tableau[i].Count; j++)
                {
                    // Don't draw cards being dragged
                    if (isDragging && dragSourceCol == i && dragSourceRow.HasValue && j >= dragSourceRow.Value)
                        continue;

                    var cardState = tableau[i][j];
                    int cardY = y + j * 25;

                    if (cardState.FaceUp)
                        DrawCard(g, cardState.Card, x, cardY, IsPartOfValidSequence(i, j));
                    else
                        DrawCardBack(g, x, cardY);
                }
            }

            // Draw animated cards
            foreach (var anim in currentAnimations.Where(a => a.Delay == 0))
            {
                DrawAnimatedCard(g, anim);
            }

            // Draw dragging cards on top
            if (isDragging && draggingCards != null)
            {
                for (int i = 0; i < draggingCards.Count; i++)
                {
                    int x = dragCurrentPoint.X - CardWidth / 2;
                    int y = dragCurrentPoint.Y - CardHeight / 2 + i * 25;
                    DrawCard(g, draggingCards[i].Card, x, y, true);
                }
            }

            // Win detection
            if (IsWin())
            {
                DrawWinMessage(g);
            }
        }

        private void DrawSectionLabel(Graphics g, string text, int x, int y)
        {
            var font = new Font("Segoe UI", 11, FontStyle.Bold);
            var size = g.MeasureString(text, font);
            var backRect = new RectangleF(x - 5, y, size.Width + 10, size.Height + 4);

            using (var brush = new SolidBrush(Color.FromArgb(150, 0, 0, 0)))
            {
                g.FillRoundedRectangle(brush, backRect, 5);
            }
            g.DrawString(text, font, Brushes.White, x, y);
        }

        private void DrawCardSlot(Graphics g, int x, int y, string label, bool highlight)
        {
            var rect = new Rectangle(x, y, CardWidth, CardHeight);

            using (var pen = new Pen(highlight ? Color.Gold : Color.FromArgb(100, 255, 255, 255), 2)
            { DashStyle = DashStyle.Dash })
            {
                g.DrawRectangle(pen, rect);
            }

            var font = new Font("Segoe UI", 20, FontStyle.Bold);
            var size = g.MeasureString(label, font);
            using (var labelBrush = new SolidBrush(Color.FromArgb(80, 255, 255, 255)))
            {
                g.DrawString(label, font, labelBrush,
                    x + (CardWidth - size.Width) / 2,
                    y + (CardHeight - size.Height) / 2);
            }
        }

        private void DrawCard(Graphics g, Card card, int x, int y, bool highlight)
        {
            var rect = new Rectangle(x, y, CardWidth, CardHeight);

            if (highlight)
            {
                using (var shadowBrush = new SolidBrush(Color.FromArgb(120, 255, 215, 0)))
                {
                    g.FillRectangle(shadowBrush, new Rectangle(x - 3, y - 3, CardWidth + 6, CardHeight + 6));
                }
            }
            g.FillRectangle(new SolidBrush(Color.FromArgb(60, 0, 0, 0)),
                new Rectangle(x + 4, y + 4, CardWidth, CardHeight));

            using (var gradientBrush = new LinearGradientBrush(rect, Color.White, Color.WhiteSmoke, 45f))
            {
                g.FillRectangle(gradientBrush, rect);
            }

            var pen = highlight ? new Pen(Color.Gold, 3) : new Pen(Color.Black, 2);
            g.DrawRectangle(pen, rect);

            g.DrawArc(Pens.DarkGray, x, y, 10, 10, 180, 90);
            g.DrawArc(Pens.DarkGray, x + CardWidth - 10, y, 10, 10, 270, 90);

            string suitSymbol = card.GetSuitString();
            var suitColor = card.GetSuitBrush();

            var rankFont = new Font("Segoe UI", 13, FontStyle.Bold);
            var suitFont = new Font("Segoe UI", 11, FontStyle.Bold);

            g.DrawString(card.GetRankString(), rankFont, suitColor, x + 5, y + 3);
            g.DrawString(suitSymbol, suitFont, suitColor, x + 5, y + 20);

            var state = g.Save();
            g.TranslateTransform(x + CardWidth, y + CardHeight);
            g.RotateTransform(180);
            g.DrawString(card.GetRankString(), rankFont, suitColor, 5, 3);
            g.DrawString(suitSymbol, suitFont, suitColor, 5, 20);
            g.Restore(state);

            var centerFont = new Font("Segoe UI", 22, FontStyle.Bold);
            var symbolSize = g.MeasureString(suitSymbol, centerFont);
            g.DrawString(suitSymbol, centerFont, suitColor,
                x + CardWidth / 2 - symbolSize.Width / 2,
                y + CardHeight / 2 - symbolSize.Height / 2);
        }

        private void DrawCardBack(Graphics g, int x, int y)
        {
            var rect = new Rectangle(x, y, CardWidth, CardHeight);

            g.FillRectangle(new SolidBrush(Color.FromArgb(60, 0, 0, 0)),
                new Rectangle(x + 4, y + 4, CardWidth, CardHeight));

            using (var gradientBrush = new LinearGradientBrush(rect,
                Color.FromArgb(139, 0, 139), Color.FromArgb(75, 0, 130), 45f))
            {
                g.FillRectangle(gradientBrush, rect);
            }

            g.DrawRectangle(new Pen(Color.Black, 2), rect);

            using (var patternBrush = new SolidBrush(Color.FromArgb(150, 255, 215, 0)))
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        g.DrawString("♠", new Font("Segoe UI", 9), patternBrush,
                            x + 12 + i * 18, y + 8 + j * 18);
                    }
                }
            }

            var logoFont = new Font("Segoe UI", 11, FontStyle.Bold);
            var logo = "SPIDER";
            var logoSize = g.MeasureString(logo, logoFont);
            g.DrawString(logo, logoFont, Brushes.Gold,
                x + CardWidth / 2 - logoSize.Width / 2,
                y + CardHeight / 2 - logoSize.Height / 2);
        }

        private void DrawAnimatedCard(Graphics g, AnimatedCard anim)
        {
            var state = g.Save();

            g.TranslateTransform(anim.Current.X + CardWidth / 2, anim.Current.Y + CardHeight / 2);
            g.RotateTransform(anim.Rotation);
            g.ScaleTransform(anim.Scale, anim.Scale);
            g.TranslateTransform(-CardWidth / 2, -CardHeight / 2);

            DrawCard(g, anim.Card, 0, 0, true);

            g.Restore(state);
        }

        private void DrawWinMessage(Graphics g)
        {
            var winFont = new Font("Segoe UI", 36, FontStyle.Bold);
            var text = "You Win!";
            var size = g.MeasureString(text, winFont);

            var backRect = new RectangleF(
                (ClientSize.Width - size.Width) / 2 - 20,
                (ClientSize.Height - size.Height) / 2 - 20,
                size.Width + 40,
                size.Height + 40);

            using (var brush = new SolidBrush(Color.FromArgb(220, 0, 100, 0)))
            {
                g.FillRoundedRectangle(brush, backRect, 15);
            }

            g.DrawString(text, winFont, Brushes.Gold,
                (ClientSize.Width - size.Width) / 2,
                (ClientSize.Height - size.Height) / 2);
        }

        // Animation methods
        private void AnimateMultiCardMove(List<Card> cards, List<Point> froms, List<Point> tos, Action onComplete)
        {
            currentAnimations.Clear();
            for (int i = 0; i < cards.Count; i++)
            {
                currentAnimations.Add(new AnimatedCard
                {
                    Card = cards[i],
                    From = froms[i],
                    To = tos[i],
                    Current = froms[i],
                    Progress = 0,
                    Rotation = 0,
                    Scale = 1.0f,
                    Delay = i * 2
                });
            }
            animationOnComplete = onComplete;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object? sender, EventArgs e)
        {
            bool anyActive = false;

            foreach (var anim in currentAnimations)
            {
                if (anim.Delay > 0)
                {
                    anim.Delay--;
                    anyActive = true;
                    continue;
                }

                if (anim.Progress < 1.0)
                {
                    anim.Progress += 0.12;
                    if (anim.Progress > 1.0) anim.Progress = 1.0;

                    double easedProgress = anim.Progress < 0.5
                        ? 4 * anim.Progress * anim.Progress * anim.Progress
                        : 1 - Math.Pow(-2 * anim.Progress + 2, 3) / 2;

                    anim.Current = new Point(
                        (int)(anim.From.X + (anim.To.X - anim.From.X) * easedProgress),
                        (int)(anim.From.Y + (anim.To.Y - anim.From.Y) * easedProgress)
                    );

                    anim.Rotation = (float)(Math.Sin(anim.Progress * Math.PI) * 5);

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

        // Mouse interaction methods
        private void SpiderSolitaire_MouseDown(object? sender, MouseEventArgs e)
        {
            if (IsWin() || animationTimer.Enabled) return;

            int stockX = 170 + TableauCount * (CardWidth + CardSpacing);
            int stockY = TopMargin;
            if (IsPointInRect(e.Location, stockX, stockY, CardWidth, CardHeight))
            {
                DealStock();
                return;
            }

            // Drag from tableau
            for (int i = 0; i < TableauCount; i++)
            {
                int x = 170 + i * (CardWidth + CardSpacing);
                int y = TopMargin;
                for (int j = 0; j < tableau[i].Count; j++)
                {
                    int cardY = y + j * 25;
                    if (IsPointInRect(e.Location, x, cardY, CardWidth, CardHeight))
                    {
                        if (!tableau[i][j].FaceUp) continue;
                        if (CanPickUpSequence(tableau[i], j))
                        {
                            isDragging = true;
                            dragStartPoint = e.Location;
                            dragCurrentPoint = e.Location;
                            draggingCards = tableau[i].Skip(j).ToList();
                            dragSourceCol = i;
                            dragSourceRow = j;
                            Capture = true;
                            Invalidate();
                            return;
                        }
                    }
                }
            }
        }

        private void SpiderSolitaire_MouseMove(object? sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                dragCurrentPoint = e.Location;
                Invalidate();
            }
        }

        private void SpiderSolitaire_MouseUp(object? sender, MouseEventArgs e)
        {
            if (!isDragging || draggingCards == null)
            {
                EndDrag();
                return;
            }

            // Try to drop on tableau
            for (int i = 0; i < TableauCount; i++)
            {
                int x = 170 + i * (CardWidth + CardSpacing);
                int y = TopMargin;
                int colHeight = tableau[i].Count > 0 ? CardHeight + (tableau[i].Count - 1) * 25 : CardHeight;
                
                if (IsPointInRect(e.Location, x, y, CardWidth, colHeight))
                {
                    if (CanMoveSequenceToTableau(draggingCards, i) && (dragSourceCol != i))
                    {
                        SaveStateForUndo();
                        
                        tableau[dragSourceCol!.Value].RemoveRange(dragSourceRow!.Value, draggingCards.Count);
                        tableau[i].AddRange(draggingCards);
                        
                        score -= 1;
                        moves++;
                        
                        if (tableau[dragSourceCol.Value].Count > 0 && !tableau[dragSourceCol.Value].Last().FaceUp)
                        {
                            tableau[dragSourceCol.Value].Last().FaceUp = true;
                            score += 2;
                        }
                        
                        EndDrag();
                        UpdateLabels();
                        statusLabel.Text = "Card moved";
                        statusLabel.ForeColor = Color.Yellow;
                        
                        TryMoveToFoundation(i);
                        Invalidate();
                        return;
                    }
                }
            }

            // Invalid drop
            EndDrag();
            statusLabel.Text = "Invalid move!";
            statusLabel.ForeColor = Color.Red;
            Invalidate();
        }

        private void EndDrag()
        {
            isDragging = false;
            draggingCards = null;
            dragSourceCol = null;
            dragSourceRow = null;
            Capture = false;
        }

        private bool IsPointInRect(Point p, int x, int y, int w, int h)
        {
            return p.X >= x && p.X <= x + w && p.Y >= y && p.Y <= y + h;
        }

        private bool CanPickUpSequence(List<CardState> col, int startRow)
        {
            if (!col[startRow].FaceUp) return false;
            
            for (int i = startRow; i < col.Count - 1; i++)
            {
                if (!col[i].FaceUp || !col[i + 1].FaceUp) return false;
                if (col[i].Card.Rank != col[i + 1].Card.Rank + 1) return false;
            }
            return true;
        }

        private bool CanMoveSequenceToTableau(List<CardState> moving, int tableauIndex)
        {
            if (moving == null || moving.Count == 0) return false;
            var col = tableau[tableauIndex];
            
            if (col.Count == 0)
                return moving[0].Card.Rank == 13;
            
            var top = col.Last();
            return top.FaceUp && moving[0].Card.Rank == top.Card.Rank - 1;
        }

        private bool IsPartOfValidSequence(int col, int row)
        {
            if (row >= tableau[col].Count) return false;
            if (!tableau[col][row].FaceUp) return false;
            
            for (int i = row; i < tableau[col].Count - 1; i++)
            {
                if (tableau[col][i].Card.Rank != tableau[col][i + 1].Card.Rank + 1)
                    return false;
                if (tableau[col][i].Card.Suit != tableau[col][i + 1].Card.Suit)
                    return false;
            }
            return true;
        }

        private void TryMoveToFoundation(int tableauIndex)
        {
            var col = tableau[tableauIndex];
            if (col.Count < 13) return;
            
            var seq = col.Skip(col.Count - 13).ToList();
            if (seq.Count == 13 && seq.All(cs => cs.FaceUp) && 
                seq[0].Card.Rank == 13 && seq.Last().Card.Rank == 1 && 
                seq.All(cs => cs.Card.Suit == seq[0].Card.Suit))
            {
                // Animate to foundation
                var cards = seq.Select(cs => cs.Card).ToList();
                int foundX = 170 + (TableauCount + 1) * (CardWidth + CardSpacing) + 20;
                int foundY = TopMargin + foundations.Count * (CardHeight / 2 + 5);
                
                var froms = new List<Point>();
                var tos = new List<Point>();
                
                for (int i = 0; i < 13; i++)
                {
                    froms.Add(new Point(170 + tableauIndex * (CardWidth + CardSpacing), 
                        TopMargin + (col.Count - 13 + i) * 25));
                    tos.Add(new Point(foundX, foundY));
                }
                
                AnimateMultiCardMove(cards, froms, tos, () =>
                {
                    foundations.Add(cards);
                    col.RemoveRange(col.Count - 13, 13);
                    
                    score += 100;
                    
                    if (col.Count > 0 && !col.Last().FaceUp)
                    {
                        col.Last().FaceUp = true;
                        score += 2;
                    }
                    
                    UpdateLabels();
                    statusLabel.Text = "Complete suit!";
                    statusLabel.ForeColor = Color.LightGreen;
                    Invalidate();
                    
                    CheckWin();
                });
            }
        }

        private bool IsWin()
        {
            bool won = foundations.Count == 8;
            if (won)
            {
                score += 1000;
                UpdateLabels();
                statusLabel.Text = "Victory!";
                statusLabel.ForeColor = Color.Gold;
            }
            return won;
        }

        private void CheckWin()
        {
            if (IsWin())
            {
                Invalidate();
            }
        }

        // Data classes
        private class CardState
        {
            public Card Card { get; set; }
            public bool FaceUp { get; set; }

            public CardState(Card card, bool faceUp)
            {
                Card = card;
                FaceUp = faceUp;
            }

            public CardState Clone() => new CardState(Card, FaceUp);
        }

        private class GameState
        {
            public List<CardState>[] Tableau { get; set; } = null!;
            public List<Card> Stock { get; set; } = null!;
            public List<List<Card>> Foundations { get; set; } = null!;
            public int Score { get; set; }
            public int Moves { get; set; }
        }

        private class AnimatedCard
        {
            public Card Card = null!;
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