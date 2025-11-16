using System.Drawing.Drawing2D;

namespace CRM.Presentation.Games
{
    public partial class FreeCell : Form
    {
        private List<Card>[] tableau = new List<Card>[8];
        private Card[] freeCells = new Card[4];
        private List<Card>[] foundations = new List<Card>[4];
        private Deck deck = new Deck();

        private const int CardWidth = 70;
        private const int CardHeight = 100;
        private const int CardSpacing = 15;
        private const int TopMargin = 180;
        private const int LeftMargin = 50;

        // Scoring
        private int score = 0;
        private int moves = 0;

        // UI Elements
        private Label scoreLabel = null!;
        private Label movesLabel = null!;
        private Label statusLabel = null!;
        private Button newGameButton = null!;
        private Panel infoPanel = null!;

        // Animation
        private System.Windows.Forms.Timer animationTimer = null!;
        private List<AnimatedCard> currentAnimations = new();
        private Action? animationOnComplete = null;

        // Dragging
        private bool isDragging = false;
        private Point dragStartPoint;
        private Point dragCurrentPoint;
        private List<Card>? draggingCards = null;
        private int? dragSourceCol = null;
        private int? dragSourceRow = null;
        private int? dragSourceFreeCell = null;

        public FreeCell()
        {
            InitializeComponent();
            DoubleBuffered = true;
            InitializeGameUI();
            StartNewGame();
        }

        private void InitializeGameUI()
        {
            this.Size = new Size(850, 700);
            this.BackColor = Color.ForestGreen;
            this.Text = "FreeCell";
            this.MinimumSize = new Size(850, 700);

            // New Game Button
            newGameButton = new Button
            {
                Text = "New Game",
                Location = new Point(20, 20),
                Width = 120,
                Height = 40,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightGray,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };
            newGameButton.Click += (s, e) => StartNewGame();
            Controls.Add(newGameButton);

            // Info Panel
            infoPanel = new Panel
            {
                Location = new Point(650, 15),
                Size = new Size(180, 150),
                BackColor = Color.FromArgb(200, 0, 50, 0),
                BorderStyle = BorderStyle.FixedSingle
            };
            Controls.Add(infoPanel);

            scoreLabel = new Label
            {
                Location = new Point(10, 10),
                Size = new Size(160, 35),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = "Score: 0"
            };
            infoPanel.Controls.Add(scoreLabel);

            movesLabel = new Label
            {
                Location = new Point(10, 55),
                Size = new Size(160, 35),
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = "Moves: 0"
            };
            infoPanel.Controls.Add(movesLabel);

            statusLabel = new Label
            {
                Location = new Point(10, 100),
                Size = new Size(160, 40),
                Font = new Font("Segoe UI", 10, FontStyle.Italic),
                ForeColor = Color.Yellow,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                Text = "Drag cards to move"
            };
            infoPanel.Controls.Add(statusLabel);

            // Animation timer
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 16; // ~60 FPS
            animationTimer.Tick += AnimationTimer_Tick;

            this.Paint += FreeCell_Paint;
            this.MouseDown += FreeCell_MouseDown;
            this.MouseMove += FreeCell_MouseMove;
            this.MouseUp += FreeCell_MouseUp;
        }

        private void StartNewGame()
        {
            deck.Shuffle();
            for (int i = 0; i < 8; i++)
                tableau[i] = new List<Card>();
            for (int i = 0; i < 4; i++)
                foundations[i] = new List<Card>();
            Array.Clear(freeCells, 0, freeCells.Length);

            int col = 0;
            foreach (var card in deck.Cards)
            {
                tableau[col % 8].Add(card);
                col++;
            }

            score = 0;
            moves = 0;
            UpdateLabels();
            currentAnimations.Clear();
            animationOnComplete = null;
            animationTimer.Stop();
            isDragging = false;
            draggingCards = null;
            dragSourceCol = null;
            dragSourceRow = null;
            dragSourceFreeCell = null;
            statusLabel.Text = "Drag cards to move";
            statusLabel.ForeColor = Color.Yellow;
            Invalidate();
        }

        private void UpdateLabels()
        {
            scoreLabel.Text = $"Score: {score}";
            movesLabel.Text = $"Moves: {moves}";
        }

        private void FreeCell_Paint(object? sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            g.Clear(Color.ForestGreen);

            // Draw FreeCells section labels
            DrawSectionLabel(g, "Free Cells", LeftMargin, TopMargin - 60);

            // Draw FreeCells
            for (int i = 0; i < 4; i++)
            {
                int x = LeftMargin + i * (CardWidth + CardSpacing);
                int y = TopMargin;

                // Draw slot outline
                DrawCardSlot(g, x, y, "F" + (i + 1), false);

                // Draw card if present and not animating
                if (freeCells[i] != null && !IsCardAnimating(freeCells[i]))
                {
                    DrawCard(g, freeCells[i], x, y, false);
                }
            }

            // Draw Foundations section labels
            DrawSectionLabel(g, "Foundations", LeftMargin + 4 * (CardWidth + CardSpacing) + 20, TopMargin - 60);

            // Draw Foundations
            string[] foundationLabels = { "♣", "♦", "♥", "♠" };
            for (int i = 0; i < 4; i++)
            {
                int x = LeftMargin + (i + 4) * (CardWidth + CardSpacing) + 20;
                int y = TopMargin;
                Card? top = foundations[i].Count > 0 ? foundations[i].Last() : null;

                // Draw slot outline
                DrawCardSlot(g, x, y, foundationLabels[i], false);

                // Draw card if present and not animating
                if (top != null && !IsCardAnimating(top))
                {
                    DrawCard(g, top, x, y, false);
                }
            }

            // Draw Tableau
            for (int i = 0; i < 8; i++)
            {
                int x = LeftMargin + i * (CardWidth + CardSpacing);
                int y = TopMargin + CardHeight + 50;

                for (int j = 0; j < tableau[i].Count; j++)
                {
                    // Don't draw cards being dragged or animating
                    if (isDragging && dragSourceCol == i && dragSourceRow.HasValue && j >= dragSourceRow.Value)
                        continue;

                    if (IsCardAnimating(tableau[i][j]))
                        continue;

                    DrawCard(g, tableau[i][j], x, y + j * 30, false);
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
                    int y = dragCurrentPoint.Y - CardHeight / 2 + i * 30;
                    DrawCard(g, draggingCards[i], x, y, true);
                }
            }

            // Win detection
            if (IsWin())
            {
                DrawWinMessage(g);
            }
        }

        private bool IsCardAnimating(Card card)
        {
            return currentAnimations.Any(a => a.Card == card);
        }

        private void DrawSectionLabel(Graphics g, string text, int x, int y)
        {
            var font = new Font("Segoe UI", 12, FontStyle.Bold);
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

            // Draw dashed border for empty slot
            using (var pen = new Pen(highlight ? Color.Gold : Color.FromArgb(100, 255, 255, 255), 2)
            { DashStyle = DashStyle.Dash })
            {
                g.DrawRectangle(pen, rect);
            }

            // Draw label in center
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

            // Draw shadow
            if (highlight)
            {
                using (var shadowBrush = new SolidBrush(Color.FromArgb(120, 255, 215, 0)))
                {
                    g.FillRectangle(shadowBrush, new Rectangle(x - 3, y - 3, CardWidth + 6, CardHeight + 6));
                }
            }
            g.FillRectangle(new SolidBrush(Color.FromArgb(60, 0, 0, 0)),
                new Rectangle(x + 4, y + 4, CardWidth, CardHeight));

            // Draw card background with gradient
            using (var gradientBrush = new LinearGradientBrush(rect, Color.White, Color.WhiteSmoke, 45f))
            {
                g.FillRectangle(gradientBrush, rect);
            }

            // Draw border
            var pen = highlight ? new Pen(Color.Gold, 3) : new Pen(Color.Black, 2);
            g.DrawRectangle(pen, rect);

            // Draw rounded corners effect
            g.DrawArc(Pens.DarkGray, x, y, 10, 10, 180, 90);
            g.DrawArc(Pens.DarkGray, x + CardWidth - 10, y, 10, 10, 270, 90);

            // Draw card content
            string CardSuitSymbol = card.Suit switch
            {
                CardSuit.Hearts => "♥",
                CardSuit.Diamonds => "♦",
                CardSuit.Clubs => "♣",
                CardSuit.Spades => "♠",
                _ => "?"
            };

            var CardSuitColor = (card.Suit == CardSuit.Hearts || card.Suit == CardSuit.Diamonds)
                ? Brushes.Crimson : Brushes.Black;

            var rankFont = new Font("Segoe UI", 14, FontStyle.Bold);
            var CardSuitFont = new Font("Segoe UI", 12, FontStyle.Bold);

            // Top-left corner
            g.DrawString(card.GetRankString(), rankFont, CardSuitColor, x + 5, y + 3);
            g.DrawString(CardSuitSymbol, CardSuitFont, CardSuitColor, x + 5, y + 22);

            // Bottom-right corner (upside down)
            var state = g.Save();
            g.TranslateTransform(x + CardWidth, y + CardHeight);
            g.RotateTransform(180);
            g.DrawString(card.GetRankString(), rankFont, CardSuitColor, 5, 3);
            g.DrawString(CardSuitSymbol, CardSuitFont, CardSuitColor, 5, 22);
            g.Restore(state);

            // Center symbol
            var centerFont = new Font("Segoe UI", 24, FontStyle.Bold);
            var symbolSize = g.MeasureString(CardSuitSymbol, centerFont);
            g.DrawString(CardSuitSymbol, centerFont, CardSuitColor,
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

        private void AnimateCardMove(List<Card> cards, List<Point> froms, List<Point> tos, Action onComplete)
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
                    Delay = i * 2 // Stagger multi-card moves
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

                    // Cubic ease-in-out (same as GinRummy and Spades)
                    double easedProgress = anim.Progress < 0.5
                        ? 4 * anim.Progress * anim.Progress * anim.Progress
                        : 1 - Math.Pow(-2 * anim.Progress + 2, 3) / 2;

                    anim.Current = new Point(
                        (int)(anim.From.X + (anim.To.X - anim.From.X) * easedProgress),
                        (int)(anim.From.Y + (anim.To.Y - anim.From.Y) * easedProgress)
                    );

                    // Add subtle rotation during movement
                    anim.Rotation = (float)(Math.Sin(anim.Progress * Math.PI) * 5);

                    // Slight scale pulse for foundation moves
                    if (IsMovingToFoundation(anim))
                    {
                        anim.Scale = 1.0f + (float)(Math.Sin(anim.Progress * Math.PI) * 0.1);
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

        private bool IsMovingToFoundation(AnimatedCard anim)
        {
            // Check if destination is in foundation area
            int foundationY = TopMargin;
            return Math.Abs(anim.To.Y - foundationY) < 10;
        }

        // DRAG & DROP LOGIC

        private void FreeCell_MouseDown(object? sender, MouseEventArgs e)
        {
            if (IsWin() || currentAnimations.Count > 0) return;

            // Check FreeCells
            for (int i = 0; i < 4; i++)
            {
                int x = LeftMargin + i * (CardWidth + CardSpacing);
                int y = TopMargin;
                if (IsPointInRect(e.Location, x, y, CardWidth, CardHeight) && freeCells[i] != null)
                {
                    isDragging = true;
                    dragStartPoint = e.Location;
                    dragCurrentPoint = e.Location;
                    draggingCards = new List<Card> { freeCells[i] };
                    dragSourceFreeCell = i;
                    dragSourceCol = null;
                    dragSourceRow = null;
                    Capture = true;
                    Invalidate();
                    return;
                }
            }

            // Check Tableau
            for (int i = 0; i < 8; i++)
            {
                int x = LeftMargin + i * (CardWidth + CardSpacing);
                int y = TopMargin + CardHeight + 50;
                for (int j = 0; j < tableau[i].Count; j++)
                {
                    int cardY = y + j * 30;
                    if (IsPointInRect(e.Location, x, cardY, CardWidth, CardHeight))
                    {
                        if (CanPickUpSequence(tableau[i], j))
                        {
                            isDragging = true;
                            dragStartPoint = e.Location;
                            dragCurrentPoint = e.Location;
                            draggingCards = tableau[i].Skip(j).ToList();
                            dragSourceCol = i;
                            dragSourceRow = j;
                            dragSourceFreeCell = null;
                            Capture = true;
                            Invalidate();
                            return;
                        }
                    }
                }
            }
        }

        private void FreeCell_MouseMove(object? sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                dragCurrentPoint = e.Location;
                Invalidate();
            }
        }

        private void FreeCell_MouseUp(object? sender, MouseEventArgs e)
        {
            if (!isDragging || draggingCards == null)
                return;

            // Try to drop on FreeCell
            for (int i = 0; i < 4; i++)
            {
                int x = LeftMargin + i * (CardWidth + CardSpacing);
                int y = TopMargin;
                if (IsPointInRect(e.Location, x, y, CardWidth, CardHeight) && freeCells[i] == null && draggingCards.Count == 1)
                {
                    var card = draggingCards[0];
                    Point from = dragSourceFreeCell.HasValue
                        ? new Point(LeftMargin + dragSourceFreeCell.Value * (CardWidth + CardSpacing), TopMargin)
                        : new Point(LeftMargin + dragSourceCol!.Value * (CardWidth + CardSpacing),
                                    TopMargin + CardHeight + 50 + dragSourceRow!.Value * 30);
                    Point to = new Point(x, y);

                    AnimateCardMove(
                        new List<Card> { card },
                        new List<Point> { from },
                        new List<Point> { to },
                        () =>
                        {
                            if (dragSourceFreeCell.HasValue)
                                freeCells[dragSourceFreeCell.Value] = null;
                            else if (dragSourceCol.HasValue && dragSourceRow.HasValue)
                                tableau[dragSourceCol.Value].RemoveAt(dragSourceRow.Value);

                            freeCells[i] = card;
                            EndDrag();
                            moves++;
                            UpdateLabels();
                            statusLabel.Text = "Moved to Free Cell";
                            statusLabel.ForeColor = Color.LightCyan;
                            Invalidate();
                        });
                    return;
                }
            }

            // Try to drop on Foundation
            for (int i = 0; i < 4; i++)
            {
                int x = LeftMargin + (i + 4) * (CardWidth + CardSpacing) + 20;
                int y = TopMargin;
                if (IsPointInRect(e.Location, x, y, CardWidth, CardHeight) && draggingCards.Count == 1 && CanMoveToFoundation(draggingCards[0], i))
                {
                    var card = draggingCards[0];
                    Point from = dragSourceFreeCell.HasValue
                        ? new Point(LeftMargin + dragSourceFreeCell.Value * (CardWidth + CardSpacing), TopMargin)
                        : new Point(LeftMargin + dragSourceCol!.Value * (CardWidth + CardSpacing),
                                    TopMargin + CardHeight + 50 + dragSourceRow!.Value * 30);
                    Point to = new Point(x, y);

                    AnimateCardMove(
                        new List<Card> { card },
                        new List<Point> { from },
                        new List<Point> { to },
                        () =>
                        {
                            if (dragSourceFreeCell.HasValue)
                                freeCells[dragSourceFreeCell.Value] = null;
                            else if (dragSourceCol.HasValue && dragSourceRow.HasValue)
                                tableau[dragSourceCol.Value].RemoveAt(dragSourceRow.Value);

                            foundations[i].Add(card);
                            EndDrag();
                            score += 10;
                            moves++;
                            UpdateLabels();
                            statusLabel.Text = "Moved to Foundation!";
                            statusLabel.ForeColor = Color.LightGreen;
                            Invalidate();
                        });
                    return;
                }
            }

            // Try to drop on Tableau
            for (int i = 0; i < 8; i++)
            {
                int x = LeftMargin + i * (CardWidth + CardSpacing);
                int y = TopMargin + CardHeight + 50;
                int colHeight = tableau[i].Count > 0 ? CardHeight + (tableau[i].Count - 1) * 30 : CardHeight;

                if (IsPointInRect(e.Location, x, y, CardWidth, colHeight) && (dragSourceCol != i || dragSourceCol == null))
                {
                    if (draggingCards.Count == 1)
                    {
                        if (CanMoveToTableau(draggingCards[0], i))
                        {
                            var card = draggingCards[0];
                            Point from = dragSourceFreeCell.HasValue
                                ? new Point(LeftMargin + dragSourceFreeCell.Value * (CardWidth + CardSpacing), TopMargin)
                                : new Point(LeftMargin + dragSourceCol!.Value * (CardWidth + CardSpacing),
                                            TopMargin + CardHeight + 50 + dragSourceRow!.Value * 30);
                            Point to = new Point(x, y + tableau[i].Count * 30);

                            AnimateCardMove(
                                new List<Card> { card },
                                new List<Point> { from },
                                new List<Point> { to },
                                () =>
                                {
                                    if (dragSourceFreeCell.HasValue)
                                        freeCells[dragSourceFreeCell.Value] = null;
                                    else if (dragSourceCol.HasValue && dragSourceRow.HasValue)
                                        tableau[dragSourceCol.Value].RemoveAt(dragSourceRow.Value);

                                    tableau[i].Add(card);
                                    EndDrag();
                                    moves++;
                                    UpdateLabels();
                                    statusLabel.Text = "Moved to Tableau";
                                    statusLabel.ForeColor = Color.Yellow;
                                    Invalidate();
                                });
                            return;
                        }
                    }
                    else
                    {
                        if (CanMoveSequenceToTableau(draggingCards, i))
                        {
                            var froms = new List<Point>();
                            var tos = new List<Point>();
                            for (int k = 0; k < draggingCards.Count; k++)
                            {
                                froms.Add(new Point(
                                    LeftMargin + dragSourceCol!.Value * (CardWidth + CardSpacing),
                                    TopMargin + CardHeight + 50 + (dragSourceRow!.Value + k) * 30));
                                tos.Add(new Point(
                                    x,
                                    y + (tableau[i].Count + k) * 30));
                            }
                            AnimateCardMove(
                                draggingCards,
                                froms,
                                tos,
                                () =>
                                {
                                    tableau[dragSourceCol!.Value].RemoveRange(dragSourceRow!.Value, draggingCards.Count);
                                    tableau[i].AddRange(draggingCards);
                                    EndDrag();
                                    moves++;
                                    UpdateLabels();
                                    statusLabel.Text = "Moved sequence";
                                    statusLabel.ForeColor = Color.Yellow;
                                    Invalidate();
                                });
                            return;
                        }
                    }
                }
            }

            // Invalid drop
            EndDrag();
            statusLabel.Text = "Invalid move!";
            statusLabel.ForeColor = Color.OrangeRed;
            Invalidate();
        }

        private void EndDrag()
        {
            isDragging = false;
            draggingCards = null;
            dragSourceCol = null;
            dragSourceRow = null;
            dragSourceFreeCell = null;
            Capture = false;
        }

        private bool IsPointInRect(Point p, int x, int y, int w, int h)
        {
            return p.X >= x && p.X <= x + w && p.Y >= y && p.Y <= y + h;
        }

        private bool CanPickUpSequence(List<Card> col, int startRow)
        {
            for (int i = startRow; i < col.Count - 1; i++)
            {
                if (!IsValidSequence(col[i], col[i + 1]))
                    return false;
            }
            int maxMovable = GetMaxMovableCards();
            return (col.Count - startRow) <= maxMovable;
        }

        private bool IsValidSequence(Card upper, Card lower)
        {
            return upper.Rank == lower.Rank + 1 && IsRed(upper.Suit) != IsRed(lower.Suit);
        }

        private int GetMaxMovableCards()
        {
            int emptyFreeCells = freeCells.Count(c => c == null);
            int emptyTableau = tableau.Count(col => col.Count == 0);
            return (emptyFreeCells + 1) * (int)Math.Pow(2, emptyTableau);
        }

        private bool CanMoveToFoundation(Card card, int foundationIndex)
        {
            var foundation = foundations[foundationIndex];
            if (foundation.Count == 0)
                return card.Rank == 1;
            var top = foundation.Last();
            return card.Suit == top.Suit && card.Rank == top.Rank + 1;
        }

        private bool CanMoveToTableau(Card card, int tableauIndex)
        {
            var col = tableau[tableauIndex];
            if (col.Count == 0)
                return true;
            var top = col.Last();
            return IsValidSequence(top, card);
        }

        private bool CanMoveSequenceToTableau(List<Card> moving, int tableauIndex)
        {
            if (moving == null || moving.Count == 0) return false;
            var col = tableau[tableauIndex];
            if (col.Count == 0)
                return true;
            var top = col.Last();
            return IsValidSequence(top, moving[0]);
        }

        private bool IsRed(CardSuit CardSuit) => CardSuit == CardSuit.Hearts || CardSuit == CardSuit.Diamonds;

        private bool IsWin()
        {
            if (foundations.All(f => f.Count == 13))
            {
                score += 1000;
                UpdateLabels();
                statusLabel.Text = "Victory!";
                statusLabel.ForeColor = Color.Gold;
                return true;
            }
            return false;
        }

        private class AnimatedCard
        {
            public Card Card { get; set; } = null!;
            public Point From { get; set; }
            public Point To { get; set; }
            public Point Current { get; set; }
            public double Progress { get; set; }
            public float Rotation { get; set; }
            public float Scale { get; set; }
            public int Delay { get; set; }
        }
    }
}