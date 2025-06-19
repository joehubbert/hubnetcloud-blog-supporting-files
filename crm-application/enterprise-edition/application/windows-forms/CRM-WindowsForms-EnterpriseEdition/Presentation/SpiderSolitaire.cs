using CRM_WindowsForms_EnterpriseEdition.Presentation;

namespace CRM_WindowsForms.Presentation
{
    public partial class SpiderSolitaire : Form
    {
        private const int CardWidth = 60;
        private const int CardHeight = 90;
        private const int CardSpacing = 20;
        private const int TopMargin = 60;
        private const int LeftMargin = 20;
        private const int TableauCount = 10;
        private const int StockDealCount = 10;

        private int suitCount;

        private List<SpiderSolitaireCard>[] tableau = new List<SpiderSolitaireCard>[TableauCount];
        private Stack<SpiderSolitaireCard> stock = new Stack<SpiderSolitaireCard>();
        private List<List<SpiderSolitaireCard>> foundations = new List<List<SpiderSolitaireCard>>();
        private Stack<GameState> undoStack = new Stack<GameState>();

        private int? selectedCol = null;
        private int? selectedRow = null;

        private Button restartButton;
        private Button undoButton;
        private Button dealButton;
        private Label winLabel;
        private Label suitLabel;
        private Label scoreLabel;

        // Animation
        private System.Windows.Forms.Timer animationTimer;
        private List<AnimationStep> currentAnimations = new List<AnimationStep>();
        private Action? animationOnComplete = null;

        // Scoring
        private int score = 500;

        // Drag and drop fields
        private bool isDragging = false;
        private Point dragStartPoint;
        private Point dragCurrentPoint;
        private List<SpiderSolitaireCard> draggingCards = null;
        private int? dragSourceCol = null;
        private int? dragSourceRow = null;

        public SpiderSolitaire(int suitCount)
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.suitCount = suitCount;
            this.Paint += SpiderSolitaire_Paint;
            this.MouseDown += SpiderSolitaire_MouseDown;
            this.MouseMove += SpiderSolitaire_MouseMove;
            this.MouseUp += SpiderSolitaire_MouseUp;

            restartButton = new Button { Text = "Restart", Location = new Point(LeftMargin, 5), Width = 90, Height = 25, FlatStyle = FlatStyle.Flat, BackColor = SystemColors.Control };
            restartButton.Click += RestartButton_Click;
            Controls.Add(restartButton);

            undoButton = new Button { Text = "Undo", Location = new Point(LeftMargin + 95, 5), Width = 90, Height = 25, FlatStyle = FlatStyle.Flat, BackColor = SystemColors.Control };
            undoButton.Click += (s, e) => Undo();
            Controls.Add(undoButton);

            dealButton = new Button { Text = "Deal", Location = new Point(LeftMargin + 195, 5), Width = 90, Height = 25, FlatStyle = FlatStyle.Flat, BackColor = SystemColors.Control };
            dealButton.Click += (s, e) => DealStock();
            Controls.Add(dealButton);

            winLabel = new Label { Text = "", Location = new Point(LeftMargin + 280, 10), AutoSize = true, Font = new Font("Segoe UI", 14, FontStyle.Bold), ForeColor = Color.Green };
            Controls.Add(winLabel);

            suitLabel = new Label { Text = $"SpiderSolitaireSuits: {suitCount}", Location = new Point(LeftMargin + 350, 10), AutoSize = true, Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = Color.White };
            Controls.Add(suitLabel);

            scoreLabel = new Label { Text = $"Score: {score}", Location = new Point(LeftMargin + 540, 10), AutoSize = true, Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = Color.White };
            Controls.Add(scoreLabel);

            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 15;
            animationTimer.Tick += AnimationTimer_Tick;

            StartNewGame();
        }

        private void RestartButton_Click(object? sender, EventArgs e)
        {
            using var difficultyDialog = new SpiderSolitaireDifficulty(suitCount);
            var dialogResult = difficultyDialog.ShowDialog(this);
            if (dialogResult == DialogResult.OK)
            {
                suitCount = difficultyDialog.SelectedSuitCount;
                suitLabel.Text = $"SpiderSolitaireSuits: {suitCount}";
                StartNewGame();
            }
            // If cancelled, do nothing (game continues as is)
        }

        private void UpdateDealButtonState()
        {
            dealButton.Enabled = stock.Count >= StockDealCount;
        }

        private void StartNewGame()
        {
            var suits = suitCount switch
            {
                1 => new[] { SpiderSolitaireSuit.Spades },
                2 => new[] { SpiderSolitaireSuit.Spades, SpiderSolitaireSuit.Hearts },
                3 => new[] { SpiderSolitaireSuit.Spades, SpiderSolitaireSuit.Hearts, SpiderSolitaireSuit.Diamonds },
                4 => new[] { SpiderSolitaireSuit.Spades, SpiderSolitaireSuit.Hearts, SpiderSolitaireSuit.Diamonds, SpiderSolitaireSuit.Clubs },
                _ => new[] { SpiderSolitaireSuit.Spades }
            };

            // Distribute 8 decks as evenly as possible among the suits
            int[] decksPerSuit = new int[suits.Length];
            int baseDecks = 8 / suits.Length;
            int remainder = 8 % suits.Length;
            for (int i = 0; i < suits.Length; i++)
                decksPerSuit[i] = baseDecks + (i < remainder ? 1 : 0);

            var cards = new List<SpiderSolitaireCard>();
            for (int i = 0; i < suits.Length; i++)
            {
                for (int d = 0; d < decksPerSuit[i]; d++)
                {
                    for (int r = 1; r <= 13; r++)
                    {
                        cards.Add(new SpiderSolitaireCard(suits[i], r));
                    }
                }
            }

            var round = new Random();
            cards = cards.OrderBy(_ => round.Next()).ToList();

            for (int i = 0; i < TableauCount; i++)
                tableau[i] = new List<SpiderSolitaireCard>();

            int cardIdx = 0;
            for (int i = 0; i < TableauCount; i++)
            {
                int count = (i < 4) ? 6 : 5;
                for (int j = 0; j < count; j++)
                {
                    var card = cards[cardIdx++];
                    card.FaceUp = (j == count - 1);
                    tableau[i].Add(card);
                }
            }

            stock = new Stack<SpiderSolitaireCard>(cards.Skip(cardIdx).Reverse());
            foundations.Clear();
            selectedCol = null;
            selectedRow = null;
            undoStack.Clear();
            winLabel.Text = "";
            currentAnimations.Clear();
            animationOnComplete = null;
            animationTimer.Stop();
            score = 500;
            UpdateScoreLabel();
            UpdateDealButtonState();
            isDragging = false;
            draggingCards = null;
            dragSourceCol = null;
            dragSourceRow = null;
            Invalidate();
        }

        private void UpdateScoreLabel()
        {
            scoreLabel.Text = $"Score: {score}";
        }

        private void Undo()
        {
            if (animationTimer.Enabled) return;
            if (undoStack.Count > 0)
            {
                var state = undoStack.Pop();
                for (int i = 0; i < TableauCount; i++)
                    tableau[i] = new List<SpiderSolitaireCard>(state.Tableau[i].Select(c => c.Clone()));
                stock = new Stack<SpiderSolitaireCard>(state.Stock.Select(c => c.Clone()).Reverse());
                foundations = state.Foundations.Select(f => f.Select(c => c.Clone()).ToList()).ToList();
                selectedCol = state.SelectedCol;
                selectedRow = state.SelectedRow;
                winLabel.Text = state.WinLabel;
                score = state.Score;
                UpdateScoreLabel();
                UpdateDealButtonState();
                isDragging = false;
                draggingCards = null;
                dragSourceCol = null;
                dragSourceRow = null;
                Invalidate();
            }
        }

        private void SaveStateForUndo()
        {
            undoStack.Push(new GameState
            {
                Tableau = tableau.Select(col => col.Select(c => c.Clone()).ToList()).ToArray(),
                Stock = stock.Select(c => c.Clone()).ToList(),
                Foundations = foundations.Select(f => f.Select(c => c.Clone()).ToList()).ToList(),
                SelectedCol = selectedCol,
                SelectedRow = selectedRow,
                WinLabel = winLabel.Text,
                Score = score
            });
        }

        private void DealStock()
        {
            if (animationTimer.Enabled) return;
            if (stock.Count < StockDealCount) return;
            if (tableau.Any(col => col.Count == 0)) return;
            SaveStateForUndo();
            var cardsToDeal = new List<SpiderSolitaireCard>();
            for (int i = 0; i < TableauCount; i++)
            {
                var card = stock.Pop();
                card.FaceUp = true;
                cardsToDeal.Add(card);
            }
            var froms = Enumerable.Repeat(new Point(LeftMargin + TableauCount * (CardWidth + CardSpacing), TopMargin), TableauCount).ToList();
            var tos = new List<Point>();
            for (int i = 0; i < TableauCount; i++)
            {
                int x = LeftMargin + i * (CardWidth + CardSpacing);
                int y = TopMargin + tableau[i].Count * 25;
                tos.Add(new Point(x, y));
            }
            AnimateMultiCardMove(cardsToDeal, froms, tos, () =>
            {
                for (int i = 0; i < TableauCount; i++)
                    tableau[i].Add(cardsToDeal[i]);
                selectedCol = null;
                selectedRow = null;
                score -= 10;
                UpdateScoreLabel();
                UpdateDealButtonState();
                Invalidate();
            });
        }

        private void SpiderSolitaire_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            var font = new Font("Segoe UI", 11, FontStyle.Bold);

            int stockX = LeftMargin + TableauCount * (CardWidth + CardSpacing);
            int stockY = TopMargin;
            g.FillRectangle(stock.Count > 0 ? Brushes.DarkGreen : Brushes.Gray, stockX, stockY, CardWidth, CardHeight);
            g.DrawRectangle(Pens.Black, stockX, stockY, CardWidth, CardHeight);
            g.DrawString("Stock", font, Brushes.White, stockX + 5, stockY + 5);
            g.DrawString($"{stock.Count / 10}", font, Brushes.White, stockX + 5, stockY + 30);

            int foundX = stockX + CardWidth + CardSpacing;
            int foundY = TopMargin;
            for (int i = 0; i < foundations.Count; i++)
            {
                g.FillRectangle(Brushes.White, foundX, foundY + i * (CardHeight + 5), CardWidth, CardHeight);
                g.DrawRectangle(Pens.Black, foundX, foundY + i * (CardHeight + 5), CardWidth, CardHeight);
                if (foundations[i].Count > 0)
                {
                    var card = foundations[i].Last();
                    DrawCard(g, card, foundX, foundY + i * (CardHeight + 5), font, false);
                }
            }

            for (int i = 0; i < TableauCount; i++)
            {
                int x = LeftMargin + i * (CardWidth + CardSpacing);
                int y = TopMargin;
                for (int j = 0; j < tableau[i].Count; j++)
                {
                    bool highlight = selectedCol == i && selectedRow.HasValue && j >= selectedRow.Value;
                    // Don't draw cards being dragged
                    if (isDragging && dragSourceCol == i && dragSourceRow.HasValue && j >= dragSourceRow.Value)
                        continue;
                    DrawCard(g, tableau[i][j], x, y + j * 25, font, highlight);
                }
                g.DrawRectangle(Pens.Black, x, y, CardWidth, CardHeight + Math.Max(0, (tableau[i].Count - 1) * 25));
            }

            if (currentAnimations.Count > 0)
            {
                foreach (var anim in currentAnimations)
                {
                    DrawCard(g, anim.SpiderSolitaireCard, (int)anim.CurrentX, (int)anim.CurrentY, font, true);
                }
            }

            // Draw dragging cards on top if dragging
            if (isDragging && draggingCards != null)
            {
                for (int i = 0; i < draggingCards.Count; i++)
                {
                    int x = dragCurrentPoint.X;
                    int y = dragCurrentPoint.Y + i * 25;
                    DrawCard(g, draggingCards[i], x, y, font, true);
                }
            }
        }

        private void DrawCard(Graphics g, SpiderSolitaireCard card, int x, int y, Font font, bool highlight)
        {
            if (card == null)
            {
                g.FillRectangle(Brushes.White, x, y, CardWidth, CardHeight);
                return;
            }
            Color faceColor = card.FaceUp ? Color.White : Color.DarkGray;
            if (highlight) faceColor = Color.LightYellow;
            using (var brush = new SolidBrush(faceColor))
                g.FillRectangle(brush, x, y, CardWidth, CardHeight);
            g.DrawRectangle(Pens.Black, x, y, CardWidth, CardHeight);
            if (card.FaceUp)
            {
                Brush brush = card.SpiderSolitaireSuit switch
                {
                    SpiderSolitaireSuit.Hearts => Brushes.Red,
                    SpiderSolitaireSuit.Diamonds => Brushes.Red,
                    _ => Brushes.Black
                };
                g.DrawString(card.ToString(), font, brush, x + 5, y + 5);
            }
        }

        private void AnimateMultiCardMove(List<SpiderSolitaireCard> cards, List<Point> froms, List<Point> tos, Action onComplete)
        {
            currentAnimations.Clear();
            for (int i = 0; i < cards.Count; i++)
            {
                currentAnimations.Add(new AnimationStep
                {
                    SpiderSolitaireCard = cards[i],
                    From = froms[i],
                    To = tos[i],
                    CurrentX = froms[i].X,
                    CurrentY = froms[i].Y
                });
            }
            animationOnComplete = onComplete;
            animationTimer.Start();
        }

        private void AnimateFoundationFly(List<SpiderSolitaireCard> cards, int tableauIndex, Action onComplete)
        {
            int foundX = LeftMargin + TableauCount * (CardWidth + CardSpacing) + CardWidth + CardSpacing;
            int foundY = TopMargin + (foundations.Count) * (CardHeight + 5);
            var froms = new List<Point>();
            var tos = new List<Point>();
            for (int k = 0; k < cards.Count; k++)
            {
                froms.Add(new Point(
                    LeftMargin + tableauIndex * (CardWidth + CardSpacing),
                    TopMargin + (tableau[tableauIndex].Count - cards.Count + k) * 25));
                tos.Add(new Point(
                    foundX,
                    foundY));
            }
            AnimateMultiCardMove(cards, froms, tos, onComplete);
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

        private void SpiderSolitaire_MouseDown(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(winLabel.Text) || animationTimer.Enabled) return;

            int stockX = LeftMargin + TableauCount * (CardWidth + CardSpacing);
            int stockY = TopMargin;
            if (IsPointInRect(e.Location, stockX, stockY, CardWidth, CardHeight))
            {
                DealStock();
                return;
            }

            // Drag from tableau
            for (int i = 0; i < TableauCount; i++)
            {
                int x = LeftMargin + i * (CardWidth + CardSpacing);
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

            // Fallback to click-to-select if not dragging
            selectedCol = null;
            selectedRow = null;
            Invalidate();
        }

        private void SpiderSolitaire_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                dragCurrentPoint = e.Location;
                Invalidate();
            }
        }

        private void SpiderSolitaire_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDragging || draggingCards == null)
                return;

            // Try to drop on tableau
            for (int i = 0; i < TableauCount; i++)
            {
                int x = LeftMargin + i * (CardWidth + CardSpacing);
                int y = TopMargin;
                int colHeight = CardHeight + Math.Max(0, (tableau[i].Count - 1) * 25);
                if (IsPointInRect(e.Location, x, y, CardWidth, colHeight) && (dragSourceCol != i || dragSourceCol == null))
                {
                    if (CanMoveSequenceToTableau(draggingCards, i))
                    {
                        SaveStateForUndo();
                        tableau[dragSourceCol.Value].RemoveRange(dragSourceRow.Value, draggingCards.Count);
                        tableau[i].AddRange(draggingCards);
                        score -= 1;
                        bool flipped = false;
                        if (tableau[dragSourceCol.Value].Count > 0 && !tableau[dragSourceCol.Value].Last().FaceUp)
                        {
                            tableau[dragSourceCol.Value].Last().FaceUp = true;
                            score += 2;
                            flipped = true;
                        }
                        TryMoveToFoundationWithAnimation(i);
                        selectedCol = null;
                        selectedRow = null;
                        EndDrag();
                        UpdateScoreLabel();
                        Invalidate();
                        CheckWin();
                        return;
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
            Capture = false;
        }

        private bool IsPointInRect(Point p, int x, int y, int w, int h)
        {
            return p.X >= x && p.X <= x + w && p.Y >= y && p.Y <= y + h;
        }

        private bool CanPickUpSequence(List<SpiderSolitaireCard> col, int startRow)
        {
            for (int i = startRow; i < col.Count - 1; i++)
            {
                if (!col[i].FaceUp || !col[i + 1].FaceUp) return false;
                if (col[i].SpiderSolitaireSuit != col[i + 1].SpiderSolitaireSuit) return false;
                if (col[i].Rank != col[i + 1].Rank + 1) return false;
            }
            return col[startRow].FaceUp;
        }

        private bool CanMoveSequenceToTableau(List<SpiderSolitaireCard> moving, int tableauIndex)
        {
            if (moving == null || moving.Count == 0) return false;
            var col = tableau[tableauIndex];
            if (col.Count == 0)
                return moving[0].Rank == 13;
            var top = col.Last();
            return top.FaceUp && moving[0].SpiderSolitaireSuit == top.SpiderSolitaireSuit && moving[0].Rank == top.Rank - 1;
        }

        private void TryMoveToFoundationWithAnimation(int tableauIndex)
        {
            var col = tableau[tableauIndex];
            if (col.Count < 13) return;
            var seq = col.Skip(col.Count - 13).ToList();
            if (seq.Count == 13 && seq.All(c => c.FaceUp) && seq[0].Rank == 13 && seq.Last().Rank == 1 && seq.All(c => c.SpiderSolitaireSuit == seq[0].SpiderSolitaireSuit))
            {
                AnimateFoundationFly(seq, tableauIndex, () =>
                {
                    foundations.Add(seq);
                    col.RemoveRange(col.Count - 13, 13);
                    score += 100;
                    if (col.Count > 0 && !col.Last().FaceUp)
                    {
                        col.Last().FaceUp = true;
                        score += 2;
                    }
                    UpdateScoreLabel();
                    Invalidate();
                });
            }
        }

        private void CheckWin()
        {
            if (foundations.Count == 8)
            {
                score += 1000;
                UpdateScoreLabel();
                winLabel.Text = "You Win!";
            }
        }

        private class AnimationStep
        {
            public SpiderSolitaireCard SpiderSolitaireCard;
            public Point From;
            public Point To;
            public float CurrentX;
            public float CurrentY;
        }

        private class GameState
        {
            public List<SpiderSolitaireCard>[] Tableau { get; set; }
            public List<SpiderSolitaireCard> Stock { get; set; }
            public List<List<SpiderSolitaireCard>> Foundations { get; set; }
            public int? SelectedCol { get; set; }
            public int? SelectedRow { get; set; }
            public string WinLabel { get; set; }
            public int Score { get; set; }
        }
    }

    public class SpiderSolitaireCard
    {
        public SpiderSolitaireSuit SpiderSolitaireSuit { get; }
        public int Rank { get; }
        public bool FaceUp { get; set; }
        public SpiderSolitaireCard(SpiderSolitaireSuit suit, int rank)
        {
            SpiderSolitaireSuit = suit;
            Rank = rank;
            FaceUp = false;
        }
        public SpiderSolitaireCard Clone() => new SpiderSolitaireCard(SpiderSolitaireSuit, Rank) { FaceUp = this.FaceUp };
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
            return $"{rankStr}{SpiderSolitaireSuitToChar(SpiderSolitaireSuit)}";
        }
        private char SpiderSolitaireSuitToChar(SpiderSolitaireSuit suit) => suit switch
        {
            SpiderSolitaireSuit.Clubs => '♣',
            SpiderSolitaireSuit.Diamonds => '♦',
            SpiderSolitaireSuit.Hearts => '♥',
            SpiderSolitaireSuit.Spades => '♠',
            _ => '?'
        };
    }

    public enum SpiderSolitaireSuit { Clubs, Diamonds, Hearts, Spades }
}