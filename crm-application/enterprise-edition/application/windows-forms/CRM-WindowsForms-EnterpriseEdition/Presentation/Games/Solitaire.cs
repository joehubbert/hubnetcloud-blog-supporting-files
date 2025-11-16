using System.Drawing.Drawing2D;

namespace CRM.Presentation.Games
{
    public partial class Solitaire : Form
    {
        private const int CardWidth = 70;
        private const int CardHeight = 100;
        private const int CardSpacing = 20;
        private const int TopMargin = 150;
        private const int LeftMargin = 30;
        private const int TableauCount = 7;
        private const int FoundationCount = 4;

        private List<CardState>[] tableau = new List<CardState>[TableauCount];
        private List<Card>[] foundations = new List<Card>[FoundationCount];
        private Stack<Card> stock = new Stack<Card>();
        private Stack<Card> waste = new Stack<Card>();

        // Scoring
        private int score = 0;
        private int moves = 0;

        // UI Elements
        private Label scoreLabel = null!;
        private Label movesLabel = null!;
        private Label statusLabel = null!;
        private Button newGameButton = null!;
        private Button dealButton = null!;
        private Button undoButton = null!;
        private Button hintButton = null!;
        private Panel infoPanel = null!;
        private CheckBox hintsCheckBox = null!;

        // Drag and drop
        private bool isDragging = false;
        private Point dragStartPoint;
        private Point dragCurrentPoint;
        private List<CardState>? draggingCards = null;
        private int? dragSourceCol = null;
        private int? dragSourceRow = null;
        private bool dragSourceWaste = false;

        // Undo
        private Stack<GameState> undoStack = new Stack<GameState>();

        // Animation
        private System.Windows.Forms.Timer animationTimer = null!;
        private List<AnimatedCard> currentAnimations = new List<AnimatedCard>();
        private Action? animationOnComplete = null;

        // Hints
        private List<HintMove> currentHints = new List<HintMove>();
        private int currentHintIndex = 0;

        // Stock recycle limit
        private int stockRecycleCount = 0;
        private const int MaxStockRecycles = 3;

        public Solitaire()
        {
            InitializeComponent();
            DoubleBuffered = true;
            InitializeGameUI();
            StartNewGame();
        }

        private void InitializeGameUI()
        {
            this.Size = new Size(1000, 750);
            this.BackColor = Color.ForestGreen;
            this.Text = "Solitaire";
            this.MinimumSize = new Size(1000, 750);

            // Left column controls
            newGameButton = new Button
            {
                Text = "New Game",
                Location = new Point(20, 20),
                Width = 130,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightGray,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            newGameButton.Click += (s, e) => StartNewGame();
            Controls.Add(newGameButton);

            dealButton = new Button
            {
                Text = "Deal",
                Location = new Point(20, 70),
                Width = 130,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightBlue,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            dealButton.Click += (s, e) => DealStock();
            Controls.Add(dealButton);

            undoButton = new Button
            {
                Text = "Undo",
                Location = new Point(20, 120),
                Width = 130,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightYellow,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            undoButton.Click += (s, e) => Undo();
            Controls.Add(undoButton);

            hintButton = new Button
            {
                Text = "Show Hint",
                Location = new Point(20, 170),
                Width = 130,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightGreen,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            hintButton.Click += (s, e) => ShowHint();
            Controls.Add(hintButton);

            hintsCheckBox = new CheckBox
            {
                Text = "Hints",
                Location = new Point(20, 220),
                Width = 130,
                Height = 30,
                Checked = false,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            };
            hintsCheckBox.CheckedChanged += (s, e) =>
            {
                if (!hintsCheckBox.Checked)
                {
                    currentHints.Clear();
                    currentHintIndex = 0;
                    Invalidate();
                }
            };
            Controls.Add(hintsCheckBox);

            // Right side information panel
            infoPanel = new Panel
            {
                Location = new Point(820, 15),
                Size = new Size(160, 180),
                BackColor = Color.FromArgb(200, 0, 50, 0),
                BorderStyle = BorderStyle.FixedSingle
            };
            Controls.Add(infoPanel);

            scoreLabel = new Label
            {
                Location = new Point(10, 10),
                Size = new Size(140, 40),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = false,
                Text = "Score: 0"
            };
            infoPanel.Controls.Add(scoreLabel);

            movesLabel = new Label
            {
                Location = new Point(10, 60),
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
                Location = new Point(10, 110),
                Size = new Size(140, 60),
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

            this.Paint += Solitaire_Paint;
            this.MouseDown += Solitaire_MouseDown;
            this.MouseMove += Solitaire_MouseMove;
            this.MouseUp += Solitaire_MouseUp;
            this.MouseDoubleClick += Solitaire_MouseDoubleClick;
        }

        private void StartNewGame()
        {
            for (int i = 0; i < TableauCount; i++)
                tableau[i] = new List<CardState>();
            for (int i = 0; i < FoundationCount; i++)
                foundations[i] = new List<Card>();
            stock.Clear();
            waste.Clear();

            isDragging = false;
            draggingCards = null;
            dragSourceCol = null;
            dragSourceRow = null;
            dragSourceWaste = false;

            score = 0;
            moves = 0;
            undoStack.Clear();
            currentHints.Clear();
            currentHintIndex = 0;
            currentAnimations.Clear();
            animationOnComplete = null;
            animationTimer.Stop();
            stockRecycleCount = 0;

            UpdateLabels();
            statusLabel.Text = "Drag cards to move";
            statusLabel.ForeColor = Color.Yellow;

            // Create and shuffle deck
            var deck = Card.CreateStandardDeck();
            deck = Card.ShuffleDeck(deck);

            // Deal to tableau
            int deckIndex = 0;
            for (int col = 0; col < TableauCount; col++)
            {
                for (int row = 0; row <= col; row++)
                {
                    var card = deck[deckIndex++];
                    tableau[col].Add(new CardState(card, row == col));
                }
            }

            // Remaining cards to stock
            for (; deckIndex < deck.Count; deckIndex++)
                stock.Push(deck[deckIndex]);

            Invalidate();
        }

        private void UpdateLabels()
        {
            scoreLabel.Text = $"Score: {score}";
            movesLabel.Text = $"Moves: {moves}";
        }

        private void DealStock()
        {
            if (animationTimer.Enabled) return;

            if (stock.Count > 0)
            {
                SaveStateForUndo();
                var card = stock.Pop();

                AnimateCardMove(card, new Point(180, TopMargin),
                    new Point(180 + CardWidth + CardSpacing, TopMargin), () =>
                    {
                        waste.Push(card);
                        score -= 1;
                        moves++;
                        UpdateLabels();
                        statusLabel.Text = "Card dealt";
                        statusLabel.ForeColor = Color.LightCyan;
                        Invalidate();
                    });
            }
            else if (waste.Count > 0)
            {
                if (stockRecycleCount < MaxStockRecycles)
                {
                    SaveStateForUndo();
                    var cards = waste.ToList();
                    waste.Clear();
                    foreach (var card in cards)
                        stock.Push(card);

                    stockRecycleCount++;
                    score -= 100;
                    moves++;
                    UpdateLabels();
                    statusLabel.Text = $"Stock recycled ({stockRecycleCount}/{MaxStockRecycles})";
                    statusLabel.ForeColor = Color.Orange;
                    Invalidate();
                }
                else
                {
                    statusLabel.Text = "Max recycles reached!";
                    statusLabel.ForeColor = Color.Red;
                }
            }
        }

        private void Undo()
        {
            if (animationTimer.Enabled || undoStack.Count == 0) return;

            var state = undoStack.Pop();
            for (int i = 0; i < TableauCount; i++)
                tableau[i] = state.Tableau[i].Select(cs => cs.Clone()).ToList();
            for (int i = 0; i < FoundationCount; i++)
                foundations[i] = state.Foundations[i].ToList();
            stock = new Stack<Card>(state.Stock.Reverse<Card>());
            waste = new Stack<Card>(state.Waste.Reverse<Card>());
            score = state.Score;
            moves = state.Moves;
            stockRecycleCount = state.StockRecycleCount;

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
                Foundations = foundations.Select(col => col.ToList()).ToArray(),
                Stock = stock.ToList(),
                Waste = waste.ToList(),
                Score = score,
                Moves = moves,
                StockRecycleCount = stockRecycleCount
            });
        }

        private void Solitaire_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.Clear(Color.ForestGreen);

            // Draw section labels
            DrawSectionLabel(g, "Stock", 180, TopMargin - 35);
            DrawSectionLabel(g, "Waste", 180 + CardWidth + CardSpacing, TopMargin - 35);
            DrawSectionLabel(g, "Foundations", 180 + 3 * (CardWidth + CardSpacing) + 20, TopMargin - 35);

            // Draw Stock
            if (stock.Count > 0)
                DrawCardBack(g, 180, TopMargin);
            else
                DrawCardSlot(g, 180, TopMargin, "↻", false);

            g.DrawString($"{stock.Count}", new Font("Segoe UI", 10, FontStyle.Bold),
                Brushes.White, 180 + 5, TopMargin + CardHeight + 5);

            // Draw Waste (fanned)
            int wasteX = 180 + CardWidth + CardSpacing;
            int wasteY = TopMargin;
            int wasteFanOffset = 15;
            int maxFan = 3;

            if (waste.Count > 0)
            {
                var wasteCards = waste.Reverse().Take(maxFan).Reverse().ToList();
                for (int i = 0; i < wasteCards.Count; i++)
                {
                    int wx = wasteX + (i * wasteFanOffset);
                    int wy = wasteY;
                    bool isTop = (i == wasteCards.Count - 1);
                    if (isTop)
                        DrawCard(g, wasteCards[i], wx, wy, false);
                    else
                        DrawCardPartial(g, wasteCards[i], wx, wy);
                }
            }
            else
            {
                DrawCardSlot(g, wasteX, wasteY, "W", false);
            }

            // Draw Foundations
            string[] foundationLabels = { "♣", "♦", "♥", "♠" };
            for (int i = 0; i < FoundationCount; i++)
            {
                int x = 180 + (i + 3) * (CardWidth + CardSpacing) + 20;
                int y = TopMargin;
                Card? top = foundations[i].Count > 0 ? foundations[i].Last() : null;
                bool highlight = IsHintFoundation(i);

                if (top != null)
                    DrawCard(g, top, x, y, highlight);
                else
                    DrawCardSlot(g, x, y, foundationLabels[i], highlight);
            }

            // Draw Tableau
            for (int i = 0; i < TableauCount; i++)
            {
                int x = 180 + i * (CardWidth + CardSpacing);
                int y = TopMargin + CardHeight + 60;

                if (tableau[i].Count == 0)
                {
                    DrawCardSlot(g, x, y, "K", false);
                }

                for (int j = 0; j < tableau[i].Count; j++)
                {
                    // Don't draw cards being dragged
                    if (isDragging && dragSourceCol == i && dragSourceRow.HasValue && j >= dragSourceRow.Value)
                        continue;

                    bool highlight = IsHintTableau(i, j);
                    var cardState = tableau[i][j];
                    int cardY = y + j * 25;

                    if (cardState.FaceUp)
                        DrawCard(g, cardState.Card, x, cardY, highlight);
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

        private void DrawCardPartial(Graphics g, Card card, int x, int y)
        {
            using (var gradientBrush = new LinearGradientBrush(
                new Rectangle(x, y, 15, CardHeight), Color.White, Color.WhiteSmoke, 45f))
            {
                g.FillRectangle(gradientBrush, x, y, 15, CardHeight);
            }
            g.DrawLine(Pens.Black, x, y, x, y + CardHeight);
        }

        private void DrawCardBack(Graphics g, int x, int y)
        {
            var rect = new Rectangle(x, y, CardWidth, CardHeight);

            g.FillRectangle(new SolidBrush(Color.FromArgb(60, 0, 0, 0)),
                new Rectangle(x + 4, y + 4, CardWidth, CardHeight));

            using (var gradientBrush = new LinearGradientBrush(rect,
                Color.FromArgb(0, 100, 200), Color.FromArgb(0, 60, 140), 45f))
            {
                g.FillRectangle(gradientBrush, rect);
            }

            g.DrawRectangle(new Pen(Color.Black, 2), rect);

            using (var patternBrush = new SolidBrush(Color.FromArgb(150, 255, 255, 255)))
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

            var logoFont = new Font("Segoe UI", 12, FontStyle.Bold);
            var logo = "SOL";
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

        // Animation and interaction methods continue in next part...

        private void AnimateCardMove(Card card, Point from, Point to, Action onComplete)
        {
            currentAnimations.Clear();
            currentAnimations.Add(new AnimatedCard
            {
                Card = card,
                From = from,
                To = to,
                Current = from,
                Progress = 0,
                Rotation = 0,
                Scale = 1.0f,
                Delay = 0
            });
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

        // Mouse interaction methods...
        private void Solitaire_MouseDown(object? sender, MouseEventArgs e)
        {
            if (IsWin() || animationTimer.Enabled) return;

            // Check Stock
            if (IsPointInRect(e.Location, 180, TopMargin, CardWidth, CardHeight))
            {
                DealStock();
                return;
            }

            // Check Waste
            int wasteX = 180 + CardWidth + CardSpacing;
            if (waste.Count > 0 && IsPointInRect(e.Location, wasteX, TopMargin, CardWidth + 30, CardHeight))
            {
                isDragging = true;
                dragStartPoint = e.Location;
                dragCurrentPoint = e.Location;
                draggingCards = new List<CardState> { new CardState(waste.Peek(), true) };
                dragSourceWaste = true;
                Capture = true;
                Invalidate();
                return;
            }

            // Check Tableau
            for (int i = 0; i < TableauCount; i++)
            {
                int x = 180 + i * (CardWidth + CardSpacing);
                int y = TopMargin + CardHeight + 60;
                for (int j = 0; j < tableau[i].Count; j++)
                {
                    int cardY = y + j * 25;
                    if (IsPointInRect(e.Location, x, cardY, CardWidth, CardHeight))
                    {
                        if (!tableau[i][j].FaceUp) continue;

                        isDragging = true;
                        dragStartPoint = e.Location;
                        dragCurrentPoint = e.Location;
                        draggingCards = tableau[i].Skip(j).ToList();
                        dragSourceCol = i;
                        dragSourceRow = j;
                        dragSourceWaste = false;
                        Capture = true;
                        Invalidate();
                        return;
                    }
                }
            }
        }

        private void Solitaire_MouseMove(object? sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                dragCurrentPoint = e.Location;
                Invalidate();
            }
        }

        private void Solitaire_MouseUp(object? sender, MouseEventArgs e)
        {
            if (!isDragging || draggingCards == null || animationTimer.Enabled)
            {
                EndDrag();
                return;
            }

            // Try to drop on Foundations
            for (int i = 0; i < FoundationCount; i++)
            {
                int x = 180 + (i + 3) * (CardWidth + CardSpacing) + 20;
                int y = TopMargin;
                if (IsPointInRect(e.Location, x, y, CardWidth, CardHeight) && draggingCards.Count == 1)
                {
                    if (CanMoveToFoundation(draggingCards[0].Card, i))
                    {
                        SaveStateForUndo();
                        PerformFoundationMove(draggingCards[0].Card, i);
                        return;
                    }
                }
            }

            // Try to drop on Tableau
            for (int i = 0; i < TableauCount; i++)
            {
                int x = 180 + i * (CardWidth + CardSpacing);
                int y = TopMargin + CardHeight + 60;
                int colHeight = tableau[i].Count > 0 ? CardHeight + (tableau[i].Count - 1) * 25 : CardHeight;

                if (IsPointInRect(e.Location, x, y, CardWidth, colHeight))
                {
                    if (CanMoveToTableau(draggingCards[0].Card, tableau[i]))
                    {
                        SaveStateForUndo();
                        PerformTableauMove(i);
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

        private void Solitaire_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            if (IsWin() || animationTimer.Enabled) return;

            // Waste double-click
            int wasteX = 180 + CardWidth + CardSpacing;
            if (waste.Count > 0 && IsPointInRect(e.Location, wasteX, TopMargin, CardWidth + 30, CardHeight))
            {
                var card = waste.Peek();
                for (int f = 0; f < FoundationCount; f++)
                {
                    if (CanMoveToFoundation(card, f))
                    {
                        SaveStateForUndo();
                        PerformFoundationMove(card, f);
                        return;
                    }
                }
            }

            // Tableau double-click
            for (int i = 0; i < TableauCount; i++)
            {
                int x = 180 + i * (CardWidth + CardSpacing);
                int y = TopMargin + CardHeight + 60;
                if (tableau[i].Count == 0) continue;

                int j = tableau[i].Count - 1;
                int cardY = y + j * 25;
                if (IsPointInRect(e.Location, x, cardY, CardWidth, CardHeight))
                {
                    var cardState = tableau[i][j];
                    if (!cardState.FaceUp) continue;

                    for (int f = 0; f < FoundationCount; f++)
                    {
                        if (CanMoveToFoundation(cardState.Card, f))
                        {
                            SaveStateForUndo();

                            AnimateCardMove(cardState.Card, new Point(x, cardY),
                                new Point(180 + (f + 3) * (CardWidth + CardSpacing) + 20, TopMargin), () =>
                                {
                                    foundations[f].Add(cardState.Card);
                                    tableau[i].RemoveAt(j);
                                    if (tableau[i].Count > 0 && !tableau[i].Last().FaceUp)
                                    {
                                        tableau[i].Last().FaceUp = true;
                                        score += 5;
                                    }
                                    score += 10;
                                    moves++;
                                    UpdateLabels();
                                    statusLabel.Text = "To foundation!";
                                    statusLabel.ForeColor = Color.LightGreen;
                                    Invalidate();
                                });
                            return;
                        }
                    }
                }
            }
        }

        private void PerformFoundationMove(Card card, int foundationIndex)
        {
            Point from;
            if (dragSourceWaste)
                from = new Point(180 + CardWidth + CardSpacing + 30, TopMargin);
            else
                from = new Point(180 + dragSourceCol!.Value * (CardWidth + CardSpacing),
                    TopMargin + CardHeight + 60 + dragSourceRow!.Value * 25);

            Point to = new Point(180 + (foundationIndex + 3) * (CardWidth + CardSpacing) + 20, TopMargin);

            AnimateCardMove(card, from, to, () =>
            {
                if (dragSourceWaste)
                    waste.Pop();
                else if (dragSourceCol.HasValue && dragSourceRow.HasValue)
                {
                    tableau[dragSourceCol.Value].RemoveAt(dragSourceRow.Value);
                    if (tableau[dragSourceCol.Value].Count > 0 && !tableau[dragSourceCol.Value].Last().FaceUp)
                    {
                        tableau[dragSourceCol.Value].Last().FaceUp = true;
                        score += 5;
                    }
                }

                foundations[foundationIndex].Add(card);
                score += 10;
                moves++;
                EndDrag();
                UpdateLabels();
                statusLabel.Text = "To foundation!";
                statusLabel.ForeColor = Color.LightGreen;
                Invalidate();
            });
        }

        private void PerformTableauMove(int targetCol)
        {
            if (draggingCards == null) return;

            Point from;
            if (dragSourceWaste)
                from = new Point(180 + CardWidth + CardSpacing + 30, TopMargin);
            else
                from = new Point(180 + dragSourceCol!.Value * (CardWidth + CardSpacing),
                    TopMargin + CardHeight + 60 + dragSourceRow!.Value * 25);

            Point to = new Point(180 + targetCol * (CardWidth + CardSpacing),
                TopMargin + CardHeight + 60 + tableau[targetCol].Count * 25);

            var cardToMove = draggingCards[0].Card;
            AnimateCardMove(cardToMove, from, to, () =>
            {
                if (dragSourceWaste)
                {
                    tableau[targetCol].Add(new CardState(waste.Pop(), true));
                }
                else if (dragSourceCol.HasValue && dragSourceRow.HasValue)
                {
                    tableau[targetCol].AddRange(draggingCards);
                    tableau[dragSourceCol.Value].RemoveRange(dragSourceRow.Value, draggingCards.Count);
                    if (tableau[dragSourceCol.Value].Count > 0 && !tableau[dragSourceCol.Value].Last().FaceUp)
                    {
                        tableau[dragSourceCol.Value].Last().FaceUp = true;
                        score += 5;
                    }
                }

                score += 5;
                moves++;
                EndDrag();
                UpdateLabels();
                statusLabel.Text = "Card moved";
                statusLabel.ForeColor = Color.Yellow;
                Invalidate();
            });
        }

        private void EndDrag()
        {
            isDragging = false;
            draggingCards = null;
            dragSourceCol = null;
            dragSourceRow = null;
            dragSourceWaste = false;
            Capture = false;
        }

        private bool IsPointInRect(Point p, int x, int y, int w, int h)
        {
            return p.X >= x && p.X <= x + w && p.Y >= y && p.Y <= y + h;
        }

        private bool CanMoveToFoundation(Card card, int foundationIndex)
        {
            var foundation = foundations[foundationIndex];
            if (foundation.Count == 0)
                return card.Rank == 1;
            var top = foundation.Last();
            return card.Suit == top.Suit && card.Rank == top.Rank + 1;
        }

        private bool CanMoveToTableau(Card card, List<CardState> col)
        {
            if (col.Count == 0)
                return card.Rank == 13;
            var top = col.Last();
            return top.FaceUp && IsRed(card.Suit) != IsRed(top.Card.Suit) && card.Rank == top.Card.Rank - 1;
        }

        private bool IsRed(CardSuit suit) => suit == CardSuit.Hearts || suit == CardSuit.Diamonds;

        private bool IsWin()
        {
            bool won = foundations.All(f => f.Count == 13);
            if (won)
            {
                statusLabel.Text = "Victory!";
                statusLabel.ForeColor = Color.Gold;
            }
            return won;
        }

        // Hint system
        private void ShowHint()
        {
            if (!hintsCheckBox.Checked)
            {
                statusLabel.Text = "Enable hints first";
                statusLabel.ForeColor = Color.Orange;
                return;
            }

            if (currentHints.Count == 0)
                currentHints = FindAllHints();

            if (currentHints.Count == 0)
            {
                statusLabel.Text = "No moves available";
                statusLabel.ForeColor = Color.Red;
                currentHintIndex = 0;
                Invalidate();
                return;
            }

            currentHintIndex = (currentHintIndex + 1) % currentHints.Count;
            statusLabel.Text = $"Hint {currentHintIndex + 1}/{currentHints.Count}";
            statusLabel.ForeColor = Color.Cyan;
            Invalidate();
        }

        private List<HintMove> FindAllHints()
        {
            var hints = new List<HintMove>();

            // Waste to Foundation
            if (waste.Count > 0)
            {
                var card = waste.Peek();
                for (int f = 0; f < FoundationCount; f++)
                {
                    if (CanMoveToFoundation(card, f))
                    {
                        hints.Add(new HintMove
                        {
                            SourceType = HintSourceType.Waste,
                            TargetType = HintTargetType.Foundation,
                            TargetCol = f
                        });
                    }
                }
            }

            // Tableau to Foundation
            for (int i = 0; i < TableauCount; i++)
            {
                if (tableau[i].Count == 0) continue;
                var cardState = tableau[i].Last();
                if (!cardState.FaceUp) continue;

                for (int f = 0; f < FoundationCount; f++)
                {
                    if (CanMoveToFoundation(cardState.Card, f))
                    {
                        hints.Add(new HintMove
                        {
                            SourceType = HintSourceType.Tableau,
                            SourceCol = i,
                            SourceRow = tableau[i].Count - 1,
                            TargetType = HintTargetType.Foundation,
                            TargetCol = f
                        });
                    }
                }
            }

            // Tableau to Tableau
            for (int i = 0; i < TableauCount; i++)
            {
                for (int j = 0; j < tableau[i].Count; j++)
                {
                    if (!tableau[i][j].FaceUp) continue;

                    for (int t = 0; t < TableauCount; t++)
                    {
                        if (i == t) continue;
                        if (CanMoveToTableau(tableau[i][j].Card, tableau[t]))
                        {
                            hints.Add(new HintMove
                            {
                                SourceType = HintSourceType.Tableau,
                                SourceCol = i,
                                SourceRow = j,
                                TargetType = HintTargetType.Tableau,
                                TargetCol = t
                            });
                        }
                    }
                }
            }

            return hints;
        }

        private bool IsHintFoundation(int foundationIndex)
        {
            if (!hintsCheckBox.Checked || currentHints.Count == 0 || currentHintIndex >= currentHints.Count)
                return false;
            var hint = currentHints[currentHintIndex];
            return hint.TargetType == HintTargetType.Foundation && hint.TargetCol == foundationIndex;
        }

        private bool IsHintTableau(int col, int row)
        {
            if (!hintsCheckBox.Checked || currentHints.Count == 0 || currentHintIndex >= currentHints.Count)
                return false;
            var hint = currentHints[currentHintIndex];
            return (hint.SourceType == HintSourceType.Tableau && hint.SourceCol == col && hint.SourceRow == row) ||
                   (hint.TargetType == HintTargetType.Tableau && hint.TargetCol == col && row == tableau[col].Count - 1);
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
            public List<Card>[] Foundations { get; set; } = null!;
            public List<Card> Stock { get; set; } = null!;
            public List<Card> Waste { get; set; } = null!;
            public int Score { get; set; }
            public int Moves { get; set; }
            public int StockRecycleCount { get; set; }
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

        private class HintMove
        {
            public HintSourceType SourceType { get; set; }
            public int SourceCol { get; set; }
            public int SourceRow { get; set; }
            public HintTargetType TargetType { get; set; }
            public int TargetCol { get; set; }
        }

        private enum HintSourceType { Waste, Tableau }
        private enum HintTargetType { Foundation, Tableau }
    }
}