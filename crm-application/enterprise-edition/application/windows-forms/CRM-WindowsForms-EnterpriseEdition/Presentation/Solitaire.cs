namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class Solitaire : Form
    {
        private const int CardWidth = 60;
        private const int CardHeight = 90;
        private const int CardSpacing = 20;
        private const int TopMargin = 60;
        private const int LeftMargin = 20;
        private const int TableauCount = 7;
        private const int FoundationCount = 4;

        private List<SolitaireCard>[] tableau = new List<SolitaireCard>[TableauCount];
        private List<SolitaireCard>[] foundations = new List<SolitaireCard>[FoundationCount];
        private Stack<SolitaireCard> stock = new Stack<SolitaireCard>();
        private Stack<SolitaireCard> waste = new Stack<SolitaireCard>();

        // Scoring
        private int score = 0;
        private Label scoreLabel;

        // Selection for moves
        private int? selectedTableauCol = null;
        private int? selectedTableauRow = null;
        private bool selectedWaste = false;

        // Drag and drop
        private bool isDragging = false;
        private Point dragStartPoint;
        private Point dragCurrentPoint;
        private List<SolitaireCard> draggingCards = null;
        private int? dragSourceCol = null;
        private int? dragSourceRow = null;
        private bool dragSourceWaste = false;

        // Undo
        private Stack<GameState> undoStack = new Stack<GameState>();

        // Animation
        private System.Windows.Forms.Timer animationTimer;
        private List<AnimationStep> currentAnimations = new List<AnimationStep>();
        private Action? animationOnComplete = null;

        // Hints
        private Panel hintsPanel;
        private RadioButton hintsOnRadioBtn;
        private RadioButton hintsOffRadioBtn;
        private List<HintMove> currentHints = new List<HintMove>();
        private int currentHintIndex = 0;
        private Button hintBtn;

        private Button restartBtn;
        private Button dealBtn;
        private Button undoBtn;
        private Label winLabel;

        // Stock recycle limit
        private int stockRecycleCount = 0;
        private const int MaxStockRecycles = 3;

        public Solitaire()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.Paint += Solitaire_Paint;
            this.MouseDown += Solitaire_MouseDown;
            this.MouseMove += Solitaire_MouseMove;
            this.MouseUp += Solitaire_MouseUp;
            this.MouseDoubleClick += Solitaire_MouseDoubleClick;

            restartBtn = new Button { Text = "Restart", Location = new Point(LeftMargin, 5), Width = 90, Height = 30, FlatStyle = FlatStyle.Flat, BackColor = SystemColors.Control };
            restartBtn.Click += (s, e) => StartNewGame();
            Controls.Add(restartBtn);

            dealBtn = new Button { Text = "Deal", Location = new Point(LeftMargin + 100, 5), Width = 90, Height = 30, FlatStyle = FlatStyle.Flat, BackColor = SystemColors.Control };
            dealBtn.Click += (s, e) => DealStock();
            Controls.Add(dealBtn);

            undoBtn = new Button { Text = "Undo", Location = new Point(LeftMargin + 200, 5), Width = 90, Height = 30, FlatStyle = FlatStyle.Flat, BackColor = SystemColors.Control };
            undoBtn.Click += (s, e) => Undo();
            Controls.Add(undoBtn);

            scoreLabel = new Label { Text = "Score: 0", Location = new Point(LeftMargin + 300, 10), AutoSize = true, Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = Color.White };
            Controls.Add(scoreLabel);

            winLabel = new Label { Text = "", Location = new Point(LeftMargin + 420, 10), AutoSize = true, Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = Color.Green };
            Controls.Add(winLabel);

            // Hints panel with two radio buttons
            hintsPanel = new Panel { Location = new Point(LeftMargin + 600, 5), Size = new Size(200, 30) };
            hintsOnRadioBtn = new RadioButton { Text = "Hints On", Location = new Point(0, 5), AutoSize = true, Font = new Font("Segoe UI", 12, FontStyle.Regular), ForeColor = Color.White };
            hintsOffRadioBtn = new RadioButton { Text = "Hints Off", Location = new Point(90, 5), AutoSize = true, Checked = true, Font = new Font("Segoe UI", 12, FontStyle.Regular), ForeColor = Color.White };
            hintsPanel.Controls.Add(hintsOnRadioBtn);
            hintsPanel.Controls.Add(hintsOffRadioBtn);
            Controls.Add(hintsPanel);

            hintBtn = new Button { Text = "Show Hint", Location = new Point(LeftMargin + 820, 5), Width = 90, Height = 30, FlatStyle = FlatStyle.Flat, BackColor = SystemColors.Control };
            hintBtn.Click += (s, e) => ShowHint();
            Controls.Add(hintBtn);

            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 15;
            animationTimer.Tick += AnimationTimer_Tick;

            StartNewGame();
        }

        private void StartNewGame()
        {
            for (int i = 0; i < TableauCount; i++)
                tableau[i] = new List<SolitaireCard>();
            for (int i = 0; i < FoundationCount; i++)
                foundations[i] = new List<SolitaireCard>();
            stock.Clear();
            waste.Clear();
            selectedTableauCol = null;
            selectedTableauRow = null;
            selectedWaste = false;
            isDragging = false;
            draggingCards = null;
            dragSourceCol = null;
            dragSourceRow = null;
            dragSourceWaste = false;
            winLabel.Text = "";
            score = 0;
            undoStack.Clear();
            UpdateScoreLabel();
            UpdateDealButtonState();
            currentHints.Clear();
            currentHintIndex = 0;
            currentAnimations.Clear();
            animationOnComplete = null;
            animationTimer.Stop();
            stockRecycleCount = 0;

            // Create and shuffle deck
            var deck = new List<SolitaireCard>();
            foreach (SolitaireSuit suit in Enum.GetValues(typeof(SolitaireSuit)))
                for (int rank = 1; rank <= 13; rank++)
                    deck.Add(new SolitaireCard(suit, rank));
            var rnd = new Random();
            deck = deck.OrderBy(_ => rnd.Next()).ToList();

            // Deal to tableau
            int deckIndex = 0;
            for (int col = 0; col < TableauCount; col++)
            {
                for (int row = 0; row <= col; row++)
                {
                    var card = deck[deckIndex++];
                    card.FaceUp = (row == col);
                    tableau[col].Add(card);
                }
            }

            // Remaining cards to stock
            for (; deckIndex < deck.Count; deckIndex++)
                stock.Push(deck[deckIndex]);

            Invalidate();
        }

        private void UpdateScoreLabel()
        {
            scoreLabel.Text = $"Score: {score}";
        }

        private void DealStock()
        {
            if (animationTimer.Enabled) return;
            SaveStateForUndo();
            if (stock.Count > 0)
            {
                var card = stock.Pop();
                card.FaceUp = true;
                AnimateCardMove(card, new Point(LeftMargin, TopMargin), new Point(LeftMargin + CardWidth + CardSpacing, TopMargin), () =>
                {
                    waste.Push(card);
                    score -= 1;
                    UpdateScoreLabel();
                    UpdateDealButtonState();
                    Invalidate();
                });
            }
            else
            {
                if (stockRecycleCount < MaxStockRecycles)
                {
                    var cards = waste.ToList();
                    waste.Clear();
                    foreach (var card in cards)
                    {
                        card.FaceUp = false;
                        stock.Push(card);
                    }
                    stockRecycleCount++;
                    score -= 100;
                    UpdateScoreLabel();
                    UpdateDealButtonState();
                    Invalidate();
                }
                else
                {
                    MessageBox.Show(this, "No more stock recycles allowed (3-pass limit reached).", "No More Recycles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateDealButtonState();
                }
            }
        }

        private void Undo()
        {
            if (animationTimer.Enabled) return;
            if (undoStack.Count > 0)
            {
                var state = undoStack.Pop();
                for (int i = 0; i < TableauCount; i++)
                    tableau[i] = state.Tableau[i].Select(c => c.Clone()).ToList();
                for (int i = 0; i < FoundationCount; i++)
                    foundations[i] = state.Foundations[i].Select(c => c.Clone()).ToList();
                stock = new Stack<SolitaireCard>(state.Stock.Select(c => c.Clone()).Reverse());
                waste = new Stack<SolitaireCard>(state.Waste.Select(c => c.Clone()).Reverse());
                selectedTableauCol = state.SelectedTableauCol;
                selectedTableauRow = state.SelectedTableauRow;
                selectedWaste = state.SelectedWaste;
                score = state.Score;
                winLabel.Text = state.WinLabel;
                UpdateScoreLabel();
                UpdateDealButtonState();
                Invalidate();
            }
        }

        private void SaveStateForUndo()
        {
            undoStack.Push(new GameState
            {
                Tableau = tableau.Select(col => col.Select(c => c.Clone()).ToList()).ToArray(),
                Foundations = foundations.Select(col => col.Select(c => c.Clone()).ToList()).ToArray(),
                Stock = stock.Select(c => c.Clone()).ToList(),
                Waste = waste.Select(c => c.Clone()).ToList(),
                SelectedTableauCol = selectedTableauCol,
                SelectedTableauRow = selectedTableauRow,
                SelectedWaste = selectedWaste,
                Score = score,
                WinLabel = winLabel.Text
            });
        }

        private void Solitaire_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var font = new Font("Segoe UI", 11, FontStyle.Bold);

            // Draw Stock
            int stockX = LeftMargin;
            int stockY = TopMargin;
            g.FillRectangle(stock.Count > 0 ? Brushes.DarkGreen : Brushes.Gray, stockX, stockY, CardWidth, CardHeight);
            g.DrawRectangle(Pens.Black, stockX, stockY, CardWidth, CardHeight);
            g.DrawString("Stock", font, Brushes.White, stockX + 5, stockY + 5);

            // Draw Waste as a fanned stack (up to 3 cards, rightmost is top)
            // Draw Waste label FIRST
            // Draw Waste label FIRST
            int wasteX = LeftMargin + CardWidth + CardSpacing;
            int wasteY = TopMargin;
            g.DrawString("Waste", font, Brushes.White, wasteX + 5, wasteY -20);

            // Now draw Waste cards (so they appear ON TOP of the label)
            int wasteFanOffset = 12;
            int maxFan = 3;
            if (waste.Count > 0)
            {
                var wasteCards = waste.Reverse().Take(maxFan).Reverse().ToList(); // fix stacking order
                int n = wasteCards.Count;
                for (int i = 0; i < n; i++)
                {
                    int wx = wasteX + (i * wasteFanOffset);
                    int wy = wasteY + (i * 2);
                    bool isTop = (i == n - 1);
                    if (isTop)
                    {
                        var card = wasteCards[i];
                        DrawCard(g, card, wx, wy, font, selectedWaste && !isDragging, IsHintWaste(card));
                        using (var pen = new Pen(Color.Black, 2))
                            g.DrawRectangle(pen, wx, wy, CardWidth, CardHeight);
                    }
                    else
                    {
                        g.FillRectangle(Brushes.White, wx, wy, CardWidth, CardHeight);
                        g.DrawRectangle(Pens.Black, wx, wy, CardWidth, CardHeight);
                    }
                }
            }
            else
            {
                g.FillRectangle(Brushes.White, wasteX, wasteY, CardWidth, CardHeight);
                g.DrawRectangle(Pens.Black, wasteX, wasteY, CardWidth, CardHeight);
            }

            // Draw Foundations
            for (int i = 0; i < FoundationCount; i++)
            {
                int x = LeftMargin + (i + 3) * (CardWidth + CardSpacing);
                int y = TopMargin;
                SolitaireCard top = foundations[i].Count > 0 ? foundations[i].Last() : null;
                bool highlight = IsHintFoundation(i);
                DrawCard(g, top, x, y, font, highlight, false);
                g.DrawRectangle(Pens.Black, x, y, CardWidth, CardHeight);
                g.DrawString("Home", font, Brushes.White, x, y - 20);
            }

            // Draw Tableau
            for (int i = 0; i < TableauCount; i++)
            {
                int x = LeftMargin + i * (CardWidth + CardSpacing);
                int y = TopMargin + CardHeight + 40;
                for (int j = 0; j < tableau[i].Count; j++)
                {
                    bool highlight = selectedTableauCol == i && selectedTableauRow == j && !isDragging;
                    // Highlight hint if enabled and available
                    if (hintsOnRadioBtn.Checked && currentHints.Count > 0 && currentHintIndex < currentHints.Count)
                    {
                        var hint = currentHints[currentHintIndex];
                        if (hint.SourceType == HintSourceType.Tableau && hint.SourceCol == i && hint.SourceRow == j)
                            highlight = true;
                        if (hint.TargetType == HintTargetType.Tableau && hint.TargetCol == i && j == tableau[i].Count - 1)
                            highlight = true;
                    }
                    // Don't draw cards being dragged
                    if (isDragging && dragSourceCol == i && dragSourceRow.HasValue && j >= dragSourceRow.Value)
                        continue;
                    DrawCard(g, tableau[i][j], x, y + j * 25, font, highlight, highlight);
                }
                g.DrawRectangle(Pens.Black, x, y, CardWidth, CardHeight + Math.Max(0, (tableau[i].Count - 1) * 25));
            }

            // Draw animation cards if animating
            if (currentAnimations.Count > 0)
            {
                foreach (var anim in currentAnimations)
                {
                    DrawCard(g, anim.Card, (int)anim.CurrentX, (int)anim.CurrentY, font, true, true);
                }
            }

            // Draw dragging cards on top if dragging
            if (isDragging && draggingCards != null)
            {
                for (int i = 0; i < draggingCards.Count; i++)
                {
                    int x = dragCurrentPoint.X;
                    int y = dragCurrentPoint.Y + i * 25;
                    DrawCard(g, draggingCards[i], x, y, font, true, true);
                }
            }

            // Win detection
            if (IsWin())
            {
                var winFont = new Font("Segoe UI", 32, FontStyle.Bold);
                var text = "You Win!";
                var size = g.MeasureString(text, winFont);
                g.DrawString(text, winFont, Brushes.Green, (ClientSize.Width - size.Width) / 2, (ClientSize.Height - size.Height) / 2);
            }
        }

        private void DrawCard(Graphics g, SolitaireCard card, int x, int y, Font font, bool highlight, bool visibleHighlight)
        {
            if (card == null)
            {
                g.FillRectangle(visibleHighlight ? Brushes.Orange : Brushes.White, x, y, CardWidth, CardHeight);
                if (visibleHighlight)
                {
                    using (var pen = new Pen(Color.OrangeRed, 4))
                        g.DrawRectangle(pen, x + 2, y + 2, CardWidth - 4, CardHeight - 4);
                }
                else
                {
                    g.DrawRectangle(Pens.Black, x, y, CardWidth, CardHeight);
                }
                return;
            }
            Color faceColor = card.FaceUp ? (highlight ? Color.LightYellow : Color.White) : Color.DarkGray;
            using (var brush = new SolidBrush(visibleHighlight ? Color.Orange : faceColor))
                g.FillRectangle(brush, x, y, CardWidth, CardHeight);
            if (visibleHighlight)
            {
                using (var pen = new Pen(Color.OrangeRed, 4))
                    g.DrawRectangle(pen, x + 2, y + 2, CardWidth - 4, CardHeight - 4);
            }
            else
            {
                g.DrawRectangle(Pens.Black, x, y, CardWidth, CardHeight);
            }
            if (card.FaceUp)
            {
                Brush brush = (card.Suit == SolitaireSuit.Hearts || card.Suit == SolitaireSuit.Diamonds) ? Brushes.Red : Brushes.Black;
                g.DrawString(card.ToString(), font, brush, x + 5, y + 5);
            }
        }

        private bool IsHintWaste(SolitaireCard card)
        {
            if (!hintsOnRadioBtn.Checked || currentHints.Count == 0 || currentHintIndex >= currentHints.Count)
                return false;
            var hint = currentHints[currentHintIndex];
            return hint.SourceType == HintSourceType.Waste && waste.Count > 0 && waste.Peek() == card;
        }

        private bool IsHintFoundation(int foundationIndex)
        {
            if (!hintsOnRadioBtn.Checked || currentHints.Count == 0 || currentHintIndex >= currentHints.Count)
                return false;
            var hint = currentHints[currentHintIndex];
            return hint.TargetType == HintTargetType.Foundation && hint.TargetCol == foundationIndex;
        }

        private void Solitaire_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsWin() || animationTimer.Enabled) return;

            // Check Stock
            int stockX = LeftMargin;
            int stockY = TopMargin;
            if (IsPointInRect(e.Location, stockX, stockY, CardWidth, CardHeight))
            {
                DealStock();
                selectedTableauCol = null;
                selectedTableauRow = null;
                selectedWaste = false;
                return;
            }

            // Check Waste
            int wasteX = LeftMargin + CardWidth + CardSpacing;
            int wasteY = TopMargin;
            int wasteFanOffset = 12;
            int maxFan = 3;
            var wasteCards = waste.Reverse().TakeLast(maxFan).ToList();
            int n = wasteCards.Count;
            for (int i = 0; i < n; i++)
            {
                int wx = wasteX + (i * wasteFanOffset);
                int wy = wasteY + (i * 2);
                if (IsPointInRect(e.Location, wx, wy, CardWidth, CardHeight) && i == n - 1)
                {
                    if (waste.Count > 0)
                    {
                        isDragging = true;
                        dragStartPoint = e.Location;
                        dragCurrentPoint = e.Location;
                        draggingCards = new List<SolitaireCard> { waste.Peek() };
                        dragSourceWaste = true;
                        dragSourceCol = null;
                        dragSourceRow = null;
                        Capture = true;
                        Invalidate();
                        return;
                    }
                }
            }

            // Check Tableau for drag
            for (int i = 0; i < TableauCount; i++)
            {
                int x = LeftMargin + i * (CardWidth + CardSpacing);
                int y = TopMargin + CardHeight + 40;
                for (int j = 0; j < tableau[i].Count; j++)
                {
                    int cardY = y + j * 25;
                    if (IsPointInRect(e.Location, x, cardY, CardWidth, CardHeight))
                    {
                        var card = tableau[i][j];
                        if (!card.FaceUp) continue;
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

            // Fallback to click-to-select
            selectedTableauCol = null;
            selectedTableauRow = null;
            selectedWaste = false;
            Invalidate();
        }

        private void Solitaire_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (IsWin() || animationTimer.Enabled) return;

            // Waste double-click (top card only)
            int wasteX = LeftMargin + CardWidth + CardSpacing;
            int wasteY = TopMargin;
            int wasteFanOffset = 12;
            int maxFan = 3;
            var wasteCards = waste.Reverse().TakeLast(maxFan).ToList();
            int n = wasteCards.Count;
            if (n > 0)
            {
                int wx = wasteX + (n - 1) * wasteFanOffset;
                int wy = wasteY + (n - 1) * 2;
                if (IsPointInRect(e.Location, wx, wy, CardWidth, CardHeight))
                {
                    var card = waste.Peek();
                    for (int f = 0; f < FoundationCount; f++)
                    {
                        if (CanMoveToFoundation(card, f))
                        {
                            SaveStateForUndo();
                            AnimateCardMove(card, new Point(wx, wy), new Point(LeftMargin + (f + 3) * (CardWidth + CardSpacing), TopMargin), () =>
                            {
                                foundations[f].Add(waste.Pop());
                                score += 10;
                                UpdateScoreLabel();
                                Invalidate();
                            });
                            return;
                        }
                    }
                }
            }

            // Tableau double-click
            for (int i = 0; i < TableauCount; i++)
            {
                int x = LeftMargin + i * (CardWidth + CardSpacing);
                int y = TopMargin + CardHeight + 40;
                if (tableau[i].Count == 0) continue;
                int j = tableau[i].Count - 1;
                int cardY = y + j * 25;
                if (IsPointInRect(e.Location, x, cardY, CardWidth, CardHeight))
                {
                    var card = tableau[i][j];
                    if (!card.FaceUp) continue;
                    for (int f = 0; f < FoundationCount; f++)
                    {
                        if (CanMoveToFoundation(card, f))
                        {
                            SaveStateForUndo();
                            AnimateCardMove(card, new Point(x, cardY), new Point(LeftMargin + (f + 3) * (CardWidth + CardSpacing), TopMargin), () =>
                            {
                                foundations[f].Add(card);
                                tableau[i].RemoveAt(j);
                                if (tableau[i].Count > 0 && !tableau[i].Last().FaceUp)
                                {
                                    tableau[i].Last().FaceUp = true;
                                    score += 5;
                                }
                                score += 10;
                                UpdateScoreLabel();
                                Invalidate();
                            });
                            return;
                        }
                    }
                }
            }
        }

        private void Solitaire_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                dragCurrentPoint = e.Location;
                Invalidate();
            }
        }

        private void Solitaire_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDragging || draggingCards == null || animationTimer.Enabled)
                return;

            // Try to drop on Foundations
            for (int i = 0; i < FoundationCount; i++)
            {
                int x = LeftMargin + (i + 3) * (CardWidth + CardSpacing);
                int y = TopMargin;
                if (IsPointInRect(e.Location, x, y, CardWidth, CardHeight) && draggingCards.Count == 1)
                {
                    var card = draggingCards[0];
                    if (CanMoveToFoundation(card, i))
                    {
                        SaveStateForUndo();
                        Point from = dragSourceWaste
                            ? new Point(LeftMargin + CardWidth + CardSpacing + 2 * 12, TopMargin + 2 * 2)
                            : new Point(LeftMargin + dragSourceCol.Value * (CardWidth + CardSpacing),
                                        TopMargin + CardHeight + 40 + dragSourceRow.Value * 25);
                        Point to = new Point(x, y);
                        AnimateCardMove(card, from, to, () =>
                        {
                            if (dragSourceWaste)
                            {
                                foundations[i].Add(waste.Pop());
                                score += 10;
                            }
                            else if (dragSourceCol.HasValue && dragSourceRow.HasValue)
                            {
                                foundations[i].Add(card);
                                tableau[dragSourceCol.Value].RemoveAt(dragSourceRow.Value);
                                if (tableau[dragSourceCol.Value].Count > 0 && !tableau[dragSourceCol.Value].Last().FaceUp)
                                {
                                    tableau[dragSourceCol.Value].Last().FaceUp = true;
                                    score += 5;
                                }
                                score += 10;
                            }
                            EndDrag();
                            UpdateScoreLabel();
                            Invalidate();
                        });
                        return;
                    }
                }
            }

            // Try to drop on Tableau
            for (int i = 0; i < TableauCount; i++)
            {
                int x = LeftMargin + i * (CardWidth + CardSpacing);
                int y = TopMargin + CardHeight + 40;
                int colHeight = CardHeight + Math.Max(0, (tableau[i].Count - 1) * 25);
                if (IsPointInRect(e.Location, x, y, CardWidth, colHeight))
                {
                    if (draggingCards.Count == 1)
                    {
                        var card = draggingCards[0];
                        if (CanMoveToTableau(card, tableau[i]))
                        {
                            SaveStateForUndo();
                            Point from = dragSourceWaste
                                ? new Point(LeftMargin + CardWidth + CardSpacing + 2 * 12, TopMargin + 2 * 2)
                                : new Point(LeftMargin + dragSourceCol.Value * (CardWidth + CardSpacing),
                                            TopMargin + CardHeight + 40 + dragSourceRow.Value * 25);
                            Point to = new Point(x, y + tableau[i].Count * 25);
                            AnimateCardMove(card, from, to, () =>
                            {
                                if (dragSourceWaste)
                                {
                                    tableau[i].Add(waste.Pop());
                                    score += 5;
                                }
                                else if (dragSourceCol.HasValue && dragSourceRow.HasValue)
                                {
                                    tableau[i].Add(card);
                                    tableau[dragSourceCol.Value].RemoveAt(dragSourceRow.Value);
                                    if (tableau[dragSourceCol.Value].Count > 0 && !tableau[dragSourceCol.Value].Last().FaceUp)
                                    {
                                        tableau[dragSourceCol.Value].Last().FaceUp = true;
                                        score += 5;
                                    }
                                    score += 5;
                                }
                                EndDrag();
                                UpdateScoreLabel();
                                Invalidate();
                            });
                            return;
                        }
                    }
                    else
                    {
                        // Multi-card drag (tableau sequence)
                        if (CanMoveSequenceToTableau(draggingCards, tableau[i]))
                        {
                            SaveStateForUndo();
                            var froms = new List<Point>();
                            var tos = new List<Point>();
                            for (int k = 0; k < draggingCards.Count; k++)
                            {
                                froms.Add(new Point(
                                    LeftMargin + dragSourceCol.Value * (CardWidth + CardSpacing),
                                    TopMargin + CardHeight + 40 + (dragSourceRow.Value + k) * 25));
                                tos.Add(new Point(
                                    x,
                                    y + (tableau[i].Count + k) * 25));
                            }
                            AnimateMultiCardMove(draggingCards, froms, tos, () =>
                            {
                                tableau[i].AddRange(draggingCards);
                                tableau[dragSourceCol.Value].RemoveRange(dragSourceRow.Value, draggingCards.Count);
                                if (tableau[dragSourceCol.Value].Count > 0 && !tableau[dragSourceCol.Value].Last().FaceUp)
                                {
                                    tableau[dragSourceCol.Value].Last().FaceUp = true;
                                    score += 5;
                                }
                                score += 5;
                                EndDrag();
                                UpdateScoreLabel();
                                Invalidate();
                            });
                            return;
                        }
                    }
                }
            }

            // Invalid drop
            EndDrag();
            score -= 5;
            UpdateScoreLabel();
            Invalidate();
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

        private bool CanMoveToFoundation(SolitaireCard card, int foundationIndex)
        {
            var foundation = foundations[foundationIndex];
            if (foundation.Count == 0)
                return card.Rank == 1; // Ace
            var top = foundation.Last();
            return card.Suit == top.Suit && card.Rank == top.Rank + 1;
        }

        private bool CanMoveToTableau(SolitaireCard card, List<SolitaireCard> col)
        {
            if (col.Count == 0)
                return card.Rank == 13; // King
            var top = col.Last();
            return top.FaceUp && IsRed(card.Suit) != IsRed(top.Suit) && card.Rank == top.Rank - 1;
        }

        private bool CanMoveSequenceToTableau(List<SolitaireCard> moving, List<SolitaireCard> col)
        {
            if (moving == null || moving.Count == 0) return false;
            if (col.Count == 0)
                return moving[0].Rank == 13;
            var top = col.Last();
            return top.FaceUp && IsRed(moving[0].Suit) != IsRed(top.Suit) && moving[0].Rank == top.Rank - 1;
        }

        private bool IsRed(SolitaireSuit suit) => suit == SolitaireSuit.Hearts || suit == SolitaireSuit.Diamonds;

        private bool IsWin()
        {
            return foundations.All(f => f.Count == 13);
        }

        // --- Animation helpers ---

        private void AnimateCardMove(SolitaireCard card, Point from, Point to, Action onComplete)
        {
            currentAnimations.Clear();
            currentAnimations.Add(new AnimationStep
            {
                Card = card,
                From = from,
                To = to,
                CurrentX = from.X,
                CurrentY = from.Y
            });
            animationOnComplete = onComplete;
            animationTimer.Start();
        }

        private void AnimateMultiCardMove(List<SolitaireCard> cards, List<Point> froms, List<Point> tos, Action onComplete)
        {
            currentAnimations.Clear();
            for (int i = 0; i < cards.Count; i++)
            {
                currentAnimations.Add(new AnimationStep
                {
                    Card = cards[i],
                    From = froms[i],
                    To = tos[i],
                    CurrentX = froms[i].X,
                    CurrentY = froms[i].Y
                });
            }
            animationOnComplete = onComplete;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (currentAnimations.Count == 0)
            {
                animationTimer.Stop();
                return;
            }
            bool allArrived = true;
            float speed = 20f;
            foreach (var anim in currentAnimations)
            {
                float dx = anim.To.X - anim.CurrentX;
                float dy = anim.To.Y - anim.CurrentY;
                float dist = (float)Math.Sqrt(dx * dx + dy * dy);
                if (dist < speed)
                {
                    anim.CurrentX = anim.To.X;
                    anim.CurrentY = anim.To.Y;
                }
                else
                {
                    anim.CurrentX += dx / dist * speed;
                    anim.CurrentY += dy / dist * speed;
                    allArrived = false;
                }
            }
            Invalidate();
            if (allArrived)
            {
                animationTimer.Stop();
                currentAnimations.Clear();
                animationOnComplete?.Invoke();
                animationOnComplete = null;
            }
        }

        // --- Hint logic ---

        private void ShowHint()
        {
            if (!hintsOnRadioBtn.Checked)
            {
                currentHints.Clear();
                currentHintIndex = 0;
                Invalidate();
                return;
            }

            // Only recalculate hints if the hint list is empty (so repeated clicks cycle through the same set until the board changes)
            if (currentHints.Count == 0)
                currentHints = FindAllHints();

            if (currentHints.Count == 0)
            {
                currentHintIndex = 0;
                // Show a message box if no hints are available
                MessageBox.Show(this, "No available moves found.", "Hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Invalidate();
                return;
            }

            // Cycle through hints
            currentHintIndex = (currentHintIndex + 1) % currentHints.Count;
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
                            SourceCol = -1,
                            SourceRow = -1,
                            TargetType = HintTargetType.Foundation,
                            TargetCol = f
                        });
                    }
                }
            }

            // Waste to Tableau
            if (waste.Count > 0)
            {
                var card = waste.Peek();
                for (int t = 0; t < TableauCount; t++)
                {
                    if (CanMoveToTableau(card, tableau[t]))
                    {
                        hints.Add(new HintMove
                        {
                            SourceType = HintSourceType.Waste,
                            SourceCol = -1,
                            SourceRow = -1,
                            TargetType = HintTargetType.Tableau,
                            TargetCol = t
                        });
                    }
                }
            }

            // Tableau to Foundation
            for (int i = 0; i < TableauCount; i++)
            {
                if (tableau[i].Count == 0) continue;
                var card = tableau[i].Last();
                if (!card.FaceUp) continue;
                for (int f = 0; f < FoundationCount; f++)
                {
                    if (CanMoveToFoundation(card, f))
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

            // Tableau to Tableau (single card and sequences)
            for (int i = 0; i < TableauCount; i++)
            {
                for (int j = 0; j < tableau[i].Count; j++)
                {
                    var card = tableau[i][j];
                    if (!card.FaceUp) continue;
                    var moving = tableau[i].Skip(j).ToList();
                    for (int t = 0; t < TableauCount; t++)
                    {
                        if (i == t) continue;
                        if (moving.Count == 1 && CanMoveToTableau(card, tableau[t]))
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
                        else if (moving.Count > 1 && CanMoveSequenceToTableau(moving, tableau[t]))
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

        // --- Data classes ---

        private class AnimationStep
        {
            public SolitaireCard Card;
            public Point From;
            public Point To;
            public float CurrentX;
            public float CurrentY;
        }

        private class GameState
        {
            public List<SolitaireCard>[] Tableau { get; set; }
            public List<SolitaireCard>[] Foundations { get; set; }
            public List<SolitaireCard> Stock { get; set; }
            public List<SolitaireCard> Waste { get; set; }
            public int? SelectedTableauCol { get; set; }
            public int? SelectedTableauRow { get; set; }
            public bool SelectedWaste { get; set; }
            public int Score { get; set; }
            public string WinLabel { get; set; }
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

        private void UpdateDealButtonState()
        {
            // Disable if there are 3 cards in the waste stack, enable otherwise
            dealBtn.Enabled = waste.Count < 3;
        }
    }

    public class SolitaireCard
    {
        public SolitaireSuit Suit { get; }
        public int Rank { get; }
        public bool FaceUp { get; set; }
        public SolitaireCard(SolitaireSuit suit, int rank)
        {
            Suit = suit;
            Rank = rank;
            FaceUp = false;
        }
        public SolitaireCard Clone() => new SolitaireCard(Suit, Rank) { FaceUp = this.FaceUp };
        public override string ToString()
        {
            string rankStr = Rank switch
            {
                1 => "A",
                11 => "J",
                12 => "Q",
                13 => "K",
                _ => Rank.ToString()
            };
            return $"{rankStr}{SuitToChar(Suit)}";
        }
        private char SuitToChar(SolitaireSuit suit) => suit switch
        {
            SolitaireSuit.Clubs => '♣',
            SolitaireSuit.Diamonds => '♦',
            SolitaireSuit.Hearts => '♥',
            SolitaireSuit.Spades => '♠',
            _ => '?'
        };
    }

    public enum SolitaireSuit { Clubs, Diamonds, Hearts, Spades }
}