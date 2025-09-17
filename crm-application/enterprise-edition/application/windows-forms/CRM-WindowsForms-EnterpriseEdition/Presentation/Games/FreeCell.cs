namespace CRM.Presentation.Games
{
    public partial class FreeCell : Form
    {
        private List<FreeCellCard>[] tableau = new List<FreeCellCard>[8];
        private FreeCellCard[] freeCells = new FreeCellCard[4];
        private List<FreeCellCard>[] foundations = new List<FreeCellCard>[4];
        private Deck deck = new Deck();

        private const int FreeCellCardWidth = 60;
        private const int FreeCellCardHeight = 90;
        private const int FreeCellCardSpacing = 20;
        private const int TopMargin = 60;
        private const int LeftMargin = 20;

        // Scoring
        private int score = 0;
        private Label scoreLabel;

        // Selection for moves
        private int? selectedCol = null;
        private int? selectedRow = null;
        private int? selectedFreeCell = null;
        private bool selectingFromFreeCell = false;

        // Animation
        private System.Windows.Forms.Timer animationTimer;
        private List<AnimationStep> currentAnimations = new List<AnimationStep>();
        private Action? animationOnComplete = null;

        // Dragging
        private bool isDragging = false;
        private Point dragStartPoint;
        private Point dragCurrentPoint;
        private List<FreeCellCard> draggingCards = null;
        private int? dragSourceCol = null;
        private int? dragSourceRow = null;
        private int? dragSourceFreeCell = null;

        public FreeCell()
        {
            InitializeComponent();
            DoubleBuffered = true;

            // Initialize animation timer before calling StartNewGame
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 15;
            animationTimer.Tick += AnimationTimer_Tick;

            // Initialize scoreLabel before calling StartNewGame
            scoreLabel = new Label { Text = "Score: 0", Location = new Point(LeftMargin + 100, 10), AutoSize = true, Font = new Font("Segoe UI", 12, FontStyle.Bold) };
            Controls.Add(scoreLabel);

            StartNewGame();
            this.Paint += FreeCell_Paint;
            this.MouseDown += FreeCell_MouseDown;
            this.MouseMove += FreeCell_MouseMove;
            this.MouseUp += FreeCell_MouseUp;

            // Restart button
            var restartBtn = new Button { Text = "Restart", Location = new Point(LeftMargin, 5), Width = 90, Height = 25, FlatStyle = FlatStyle.Flat, BackColor = SystemColors.Control };
            restartBtn.Click += (s, e) => StartNewGame();
            Controls.Add(restartBtn);
        }

        private void StartNewGame()
        {
            deck.Shuffle();
            for (int i = 0; i < 8; i++)
                tableau[i] = new List<FreeCellCard>();
            for (int i = 0; i < 4; i++)
                foundations[i] = new List<FreeCellCard>();
            Array.Clear(freeCells, 0, freeCells.Length);

            int col = 0;
            foreach (var card in deck.FreeCellCards)
            {
                tableau[col % 8].Add(card);
                col++;
            }
            score = 0;
            selectedCol = null;
            selectedRow = null;
            selectedFreeCell = null;
            selectingFromFreeCell = false;
            UpdateScoreLabel();
            currentAnimations.Clear();
            animationOnComplete = null;
            animationTimer.Stop();
            isDragging = false;
            draggingCards = null;
            dragSourceCol = null;
            dragSourceRow = null;
            dragSourceFreeCell = null;
            Invalidate();
        }

        private void UpdateScoreLabel()
        {
            scoreLabel.Text = $"Score: {score}";
        }

        private void FreeCell_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var font = new Font("Segoe UI", 11, FontStyle.Bold);

            // Draw FreeCells
            for (int i = 0; i < 4; i++)
            {
                int x = LeftMargin + i * (FreeCellCardWidth + FreeCellCardSpacing);
                int y = TopMargin;
                bool highlight = selectingFromFreeCell && selectedFreeCell == i;
                DrawFreeCellCard(g, freeCells[i], x, y, font, highlight);
                g.DrawRectangle(Pens.Black, x, y, FreeCellCardWidth, FreeCellCardHeight);
                g.DrawString("Free", font, Brushes.Black, x, y - 20);
            }

            // Draw Foundations
            for (int i = 0; i < 4; i++)
            {
                int x = LeftMargin + (i + 4) * (FreeCellCardWidth + FreeCellCardSpacing);
                int y = TopMargin;
                FreeCellCard top = foundations[i].Count > 0 ? foundations[i].Last() : null;
                DrawFreeCellCard(g, top, x, y, font);
                g.DrawRectangle(Pens.Black, x, y, FreeCellCardWidth, FreeCellCardHeight);
                g.DrawString("Home", font, Brushes.Black, x, y - 20);
            }

            // Draw Tableau
            for (int i = 0; i < 8; i++)
            {
                int x = LeftMargin + i * (FreeCellCardWidth + FreeCellCardSpacing);
                int y = TopMargin + FreeCellCardHeight + 40;
                for (int j = 0; j < tableau[i].Count; j++)
                {
                    bool highlight = selectedCol == i && selectedRow.HasValue && j >= selectedRow.Value && !selectingFromFreeCell;
                    // Don't draw cards being dragged
                    if (isDragging && dragSourceCol == i && dragSourceRow.HasValue && j >= dragSourceRow.Value)
                        continue;
                    DrawFreeCellCard(g, tableau[i][j], x, y + j * 25, font, highlight);
                }
                g.DrawRectangle(Pens.Black, x, y, FreeCellCardWidth, FreeCellCardHeight + Math.Max(0, (tableau[i].Count - 1) * 25));
            }

            // Draw animation cards if animating
            if (currentAnimations.Count > 0)
            {
                foreach (var anim in currentAnimations)
                {
                    DrawFreeCellCard(g, anim.FreeCellCard, (int)anim.CurrentX, (int)anim.CurrentY, font, true);
                }
            }

            // Draw dragging cards on top if dragging
            if (isDragging && draggingCards != null)
            {
                for (int i = 0; i < draggingCards.Count; i++)
                {
                    int x = dragCurrentPoint.X;
                    int y = dragCurrentPoint.Y + i * 25;
                    DrawFreeCellCard(g, draggingCards[i], x, y, font, true);
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

        private void DrawFreeCellCard(Graphics g, FreeCellCard card, int x, int y, Font font, bool highlight = false)
        {
            if (card == null)
            {
                g.FillRectangle(highlight ? Brushes.LightYellow : Brushes.White, x, y, FreeCellCardWidth, FreeCellCardHeight);
                return;
            }
            g.FillRectangle(highlight ? Brushes.LightYellow : Brushes.White, x, y, FreeCellCardWidth, FreeCellCardHeight);
            g.DrawRectangle(Pens.Black, x, y, FreeCellCardWidth, FreeCellCardHeight);
            Brush brush = (card.Suit == FreeCellSuit.Hearts || card.Suit == FreeCellSuit.Diamonds) ? Brushes.Red : Brushes.Black;
            g.DrawString(card.ToString(), font, brush, x + 5, y + 5);
        }

        private void AnimateMultiFreeCellCardMove(List<FreeCellCard> cards, List<Point> froms, List<Point> tos, Action onComplete)
        {
            currentAnimations.Clear();
            for (int i = 0; i < cards.Count; i++)
            {
                currentAnimations.Add(new AnimationStep
                {
                    FreeCellCard = cards[i],
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

        // DRAG & DROP LOGIC

        private void FreeCell_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsWin() || currentAnimations.Count > 0) return;

            // Check FreeCells
            for (int i = 0; i < 4; i++)
            {
                int x = LeftMargin + i * (FreeCellCardWidth + FreeCellCardSpacing);
                int y = TopMargin;
                if (IsPointInRect(e.Location, x, y, FreeCellCardWidth, FreeCellCardHeight) && freeCells[i] != null)
                {
                    isDragging = true;
                    dragStartPoint = e.Location;
                    dragCurrentPoint = e.Location;
                    draggingCards = new List<FreeCellCard> { freeCells[i] };
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
                int x = LeftMargin + i * (FreeCellCardWidth + FreeCellCardSpacing);
                int y = TopMargin + FreeCellCardHeight + 40;
                for (int j = 0; j < tableau[i].Count; j++)
                {
                    int cardY = y + j * 25;
                    if (IsPointInRect(e.Location, x, cardY, FreeCellCardWidth, FreeCellCardHeight))
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

        private void FreeCell_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                dragCurrentPoint = e.Location;
                Invalidate();
            }
        }

        private void FreeCell_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDragging || draggingCards == null)
                return;

            // Try to drop on FreeCell
            for (int i = 0; i < 4; i++)
            {
                int x = LeftMargin + i * (FreeCellCardWidth + FreeCellCardSpacing);
                int y = TopMargin;
                if (IsPointInRect(e.Location, x, y, FreeCellCardWidth, FreeCellCardHeight) && freeCells[i] == null && draggingCards.Count == 1)
                {
                    var card = draggingCards[0];
                    Point from = dragSourceFreeCell.HasValue
                        ? new Point(LeftMargin + dragSourceFreeCell.Value * (FreeCellCardWidth + FreeCellCardSpacing), TopMargin)
                        : new Point(LeftMargin + dragSourceCol.Value * (FreeCellCardWidth + FreeCellCardSpacing),
                                    TopMargin + FreeCellCardHeight + 40 + dragSourceRow.Value * 25);
                    Point to = new Point(x, y);

                    AnimateMultiFreeCellCardMove(
                        new List<FreeCellCard> { card },
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
                            score -= 1;
                            UpdateScoreLabel();
                            Invalidate();
                        });
                    return;
                }
            }

            // Try to drop on Foundation
            for (int i = 0; i < 4; i++)
            {
                int x = LeftMargin + (i + 4) * (FreeCellCardWidth + FreeCellCardSpacing);
                int y = TopMargin;
                if (IsPointInRect(e.Location, x, y, FreeCellCardWidth, FreeCellCardHeight) && draggingCards.Count == 1 && CanMoveToFoundation(draggingCards[0], i))
                {
                    var card = draggingCards[0];
                    Point from = dragSourceFreeCell.HasValue
                        ? new Point(LeftMargin + dragSourceFreeCell.Value * (FreeCellCardWidth + FreeCellCardSpacing), TopMargin)
                        : new Point(LeftMargin + dragSourceCol.Value * (FreeCellCardWidth + FreeCellCardSpacing),
                                    TopMargin + FreeCellCardHeight + 40 + dragSourceRow.Value * 25);
                    Point to = new Point(x, y);

                    AnimateMultiFreeCellCardMove(
                        new List<FreeCellCard> { card },
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
                            UpdateScoreLabel();
                            Invalidate();
                        });
                    return;
                }
            }

            // Try to drop on Tableau
            for (int i = 0; i < 8; i++)
            {
                int x = LeftMargin + i * (FreeCellCardWidth + FreeCellCardSpacing);
                int y = TopMargin + FreeCellCardHeight + 40;
                int colHeight = FreeCellCardHeight + Math.Max(0, (tableau[i].Count - 1) * 25);

                if (IsPointInRect(e.Location, x, y, FreeCellCardWidth, colHeight) && (dragSourceCol != i || dragSourceCol == null))
                {
                    if (draggingCards.Count == 1)
                    {
                        // Use CanMoveToTableau for single card
                        if (CanMoveToTableau(draggingCards[0], i))
                        {
                            var card = draggingCards[0];
                            Point from = dragSourceFreeCell.HasValue
                                ? new Point(LeftMargin + dragSourceFreeCell.Value * (FreeCellCardWidth + FreeCellCardSpacing), TopMargin)
                                : new Point(LeftMargin + dragSourceCol.Value * (FreeCellCardWidth + FreeCellCardSpacing),
                                            TopMargin + FreeCellCardHeight + 40 + dragSourceRow.Value * 25);
                            Point to = new Point(x, y + tableau[i].Count * 25);

                            AnimateMultiFreeCellCardMove(
                                new List<FreeCellCard> { card },
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
                                    score -= 1;
                                    UpdateScoreLabel();
                                    Invalidate();
                                });
                            return;
                        }
                    }
                    else
                    {
                        // Use CanMoveSequenceToTableau for multi-card
                        if (CanMoveSequenceToTableau(draggingCards, i))
                        {
                            var froms = new List<Point>();
                            var tos = new List<Point>();
                            for (int k = 0; k < draggingCards.Count; k++)
                            {
                                froms.Add(new Point(
                                    LeftMargin + dragSourceCol.Value * (FreeCellCardWidth + FreeCellCardSpacing),
                                    TopMargin + FreeCellCardHeight + 40 + (dragSourceRow.Value + k) * 25));
                                tos.Add(new Point(
                                    x,
                                    y + (tableau[i].Count + k) * 25));
                            }
                            AnimateMultiFreeCellCardMove(
                                draggingCards,
                                froms,
                                tos,
                                () =>
                                {
                                    tableau[dragSourceCol.Value].RemoveRange(dragSourceRow.Value, draggingCards.Count);
                                    tableau[i].AddRange(draggingCards);
                                    EndDrag();
                                    score -= 1;
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
            dragSourceFreeCell = null;
            Capture = false;
        }

        private bool IsPointInRect(Point p, int x, int y, int w, int h)
        {
            return p.X >= x && p.X <= x + w && p.Y >= y && p.Y <= y + h;
        }

        private bool CanPickUpSequence(List<FreeCellCard> col, int startRow)
        {
            // Only allow picking up a valid descending, alternating color sequence
            for (int i = startRow; i < col.Count - 1; i++)
            {
                if (!IsValidSequence(col[i], col[i + 1]))
                    return false;
            }
            // Only allow as many cards as can be moved (empty freecells/tableau)
            int maxMovable = GetMaxMovableFreeCellCards();
            return (col.Count - startRow) <= maxMovable;
        }

        private bool IsValidSequence(FreeCellCard upper, FreeCellCard lower)
        {
            return upper.Rank == lower.Rank + 1 && IsRed(upper.Suit) != IsRed(lower.Suit);
        }

        private int GetMaxMovableFreeCellCards()
        {
            int emptyFreeCells = freeCells.Count(c => c == null);
            int emptyTableau = tableau.Count(col => col.Count == 0);
            return (emptyFreeCells + 1) * (int)Math.Pow(2, emptyTableau);
        }

        private bool CanMoveToFoundation(FreeCellCard card, int foundationIndex)
        {
            var foundation = foundations[foundationIndex];
            if (foundation.Count == 0)
                return card.Rank == 1; // Ace
            var top = foundation.Last();
            return card.Suit == top.Suit && card.Rank == top.Rank + 1;
        }

        private bool CanMoveToTableau(FreeCellCard card, int tableauIndex)
        {
            var col = tableau[tableauIndex];
            if (col.Count == 0)
                return true;
            var top = col.Last();
            return IsValidSequence(top, card);
        }

        private bool CanMoveSequenceToTableau(List<FreeCellCard> moving, int tableauIndex)
        {
            if (moving == null || moving.Count == 0) return false;
            var col = tableau[tableauIndex];
            if (col.Count == 0)
                return true;
            var top = col.Last();
            return IsValidSequence(top, moving[0]);
        }

        private bool IsRed(FreeCellSuit suit) => suit == FreeCellSuit.Hearts || suit == FreeCellSuit.Diamonds;

        private bool IsWin()
        {
            if (foundations.All(f => f.Count == 13))
            {
                score += 1000;
                UpdateScoreLabel();
                return true;
            }
            return false;
        }

        private class AnimationStep
        {
            public FreeCellCard FreeCellCard;
            public Point From;
            public Point To;
            public float CurrentX;
            public float CurrentY;
        }
    }

    // --- Fixes for Suit/FreeCellSuit conversion and related issues ---

    public class FreeCellCard
    {
        public FreeCellSuit Suit { get; }
        public int Rank { get; } // 1=Ace, 13=King
        public FreeCellCard(FreeCellSuit suit, int rank)
        {
            Suit = suit;
            Rank = rank;
        }
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
        private char SuitToChar(FreeCellSuit suit) => suit switch
        {
            FreeCellSuit.Clubs => '♣',
            FreeCellSuit.Diamonds => '♦',
            FreeCellSuit.Hearts => '♥',
            FreeCellSuit.Spades => '♠',
            _ => '?'
        };
    }

    public enum FreeCellSuit { Clubs, Diamonds, Hearts, Spades }

    public class Deck
    {
        public List<FreeCellCard> FreeCellCards { get; } = new List<FreeCellCard>();
        public Deck()
        {
            FreeCellCards.Clear();
            foreach (FreeCellSuit suit in Enum.GetValues(typeof(FreeCellSuit)))
                for (int rank = 1; rank <= 13; rank++)
                    FreeCellCards.Add(new FreeCellCard(suit, rank));
        }
        public void Shuffle()
        {
            var rnd = new Random();
            FreeCellCards.Sort((a, b) => rnd.Next(-1, 2));
        }
    }
}