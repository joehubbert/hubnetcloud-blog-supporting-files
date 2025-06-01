namespace CRM_WindowsForms.Presentation
{
    public partial class Solitaire : Form
    {
        private List<Card> deck = new List<Card>();
        private Stack<Card> stock = new Stack<Card>();
        private Stack<Card> waste = new Stack<Card>();
        private List<Stack<Card>> tableau = new List<Stack<Card>>();
        private List<Stack<Card>> foundation = new List<Stack<Card>>();
        private Panel[] tableauPanels;
        private Panel[] foundationPanels;
        private PictureBox stockPictureBox;
        private PictureBox wastePictureBox;
        private Label scoreLabel;

        // Drag and drop state
        private List<Card> dragCards = null;
        private int dragFromTableau = -1;
        private int dragFromIndex = -1;
        private int dragFromFoundation = -1;
        private bool dragFromWaste = false;

        private int score = 0;

        public Solitaire()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            this.BackColor = Color.ForestGreen;
            this.ClientSize = new Size(900, 600);

            deck = CreateDeck();
            Shuffle(deck);

            tableau.Clear();
            foundation.Clear();
            for (int i = 0; i < 7; i++) tableau.Add(new Stack<Card>());
            for (int i = 0; i < 4; i++) foundation.Add(new Stack<Card>());

            int deckIndex = 0;
            for (int col = 0; col < 7; col++)
            {
                for (int row = 0; row <= col; row++)
                {
                    var card = deck[deckIndex++];
                    card.FaceUp = (row == col);
                    tableau[col].Push(card);
                }
            }

            stock = new Stack<Card>(deck.Skip(deckIndex).Reverse());
            waste = new Stack<Card>();
            score = 0;

            SetupUIPanels();
            DrawGame();
        }

        private void SetupUIPanels()
        {
            this.Controls.Clear();

            stockPictureBox = new PictureBox
            {
                Location = new Point(30, 30),
                Size = new Size(70, 100),
                BackColor = Color.DarkGreen,
                BorderStyle = BorderStyle.FixedSingle
            };
            stockPictureBox.Click += StockPictureBox_Click;
            this.Controls.Add(stockPictureBox);

            wastePictureBox = new PictureBox
            {
                Location = new Point(120, 30),
                Size = new Size(70, 100),
                BackColor = Color.DarkGreen,
                BorderStyle = BorderStyle.FixedSingle
            };
            wastePictureBox.MouseDown += WastePictureBox_MouseDown;
            wastePictureBox.MouseDoubleClick += WastePictureBox_MouseDoubleClick;
            this.Controls.Add(wastePictureBox);

            foundationPanels = new Panel[4];
            for (int i = 0; i < 4; i++)
            {
                var panel = new Panel
                {
                    Location = new Point(250 + i * 90, 30),
                    Size = new Size(70, 100),
                    BackColor = Color.DarkGreen,
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = i,
                    AllowDrop = true
                };
                panel.Click += FoundationPanel_Click;
                panel.DragEnter += FoundationPanel_DragEnter;
                panel.DragDrop += FoundationPanel_DragDrop;
                foundationPanels[i] = panel;
                this.Controls.Add(panel);
            }

            tableauPanels = new Panel[7];
            for (int i = 0; i < 7; i++)
            {
                var panel = new Panel
                {
                    Location = new Point(30 + i * 120, 160),
                    Size = new Size(100, 350),
                    BackColor = Color.Transparent,
                    BorderStyle = BorderStyle.None,
                    Tag = i,
                    AllowDrop = true
                };
                panel.Click += TableauPanel_Click;
                panel.DragEnter += TableauPanel_DragEnter;
                panel.DragDrop += TableauPanel_DragDrop;
                tableauPanels[i] = panel;
                this.Controls.Add(panel);
            }

            scoreLabel = new Label
            {
                Location = new Point(800, 30),
                Size = new Size(100, 30),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Text = "Score: 0"
            };
            this.Controls.Add(scoreLabel);
        }

        private void DrawGame()
        {
            stockPictureBox.Image = stock.Count > 0 ? DrawCardBack() : null;
            wastePictureBox.Image = waste.Count > 0 ? DrawCard(waste.Peek()) : null;

            for (int i = 0; i < 4; i++)
            {
                foundationPanels[i].Controls.Clear();
                if (foundation[i].Count > 0)
                {
                    var card = foundation[i].Peek();
                    var pb = new PictureBox
                    {
                        Image = DrawCard(card),
                        Size = new Size(70, 100),
                        Location = new Point(0, 0),
                        Tag = i
                    };
                    pb.MouseDown += FoundationCard_MouseDown;
                    pb.MouseDoubleClick += FoundationCard_MouseDoubleClick;
                    foundationPanels[i].Controls.Add(pb);
                }
            }

            for (int i = 0; i < 7; i++)
            {
                tableauPanels[i].Controls.Clear();
                var cards = tableau[i].Reverse().ToList();
                for (int j = 0; j < cards.Count; j++)
                {
                    var card = cards[j];
                    var pb = new PictureBox
                    {
                        Image = card.FaceUp ? DrawCard(card) : DrawCardBack(),
                        Size = new Size(70, 100),
                        Location = new Point(0, j * 25),
                        Tag = new Tuple<int, int>(i, j),
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    pb.MouseDown += TableauCard_MouseDown;
                    pb.MouseDoubleClick += TableauCard_MouseDoubleClick;
                    pb.MouseUp += TableauCard_MouseUp;
                    tableauPanels[i].Controls.Add(pb);
                }
            }

            scoreLabel.Text = $"Score: {score}";

            // Win detection
            if (foundation.All(f => f.Count == 13))
            {
                MessageBox.Show($"Congratulations! You won!\nFinal Score: {score}", "Solitaire", MessageBoxButtons.OK, MessageBoxIcon.Information);
                InitializeGame();
            }
        }

        // Stock and waste
        private void StockPictureBox_Click(object sender, EventArgs e)
        {
            if (stock.Count > 0)
            {
                var card = stock.Pop();
                card.FaceUp = true;
                waste.Push(card);
            }
            else
            {
                while (waste.Count > 0)
                {
                    var card = waste.Pop();
                    card.FaceUp = false;
                    stock.Push(card);
                }
            }
            DrawGame();
        }

        private void WastePictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (waste.Count == 0) return;
            if (e.Button == MouseButtons.Left)
            {
                dragCards = new List<Card> { waste.Peek() };
                dragFromWaste = true;
                wastePictureBox.DoDragDrop("waste", DragDropEffects.Move);
            }
        }

        private void WastePictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (waste.Count == 0) return;
            var card = waste.Peek();
            if (AutoMoveToFoundation(card, fromWaste: true)) return;
            // Try tableau
            for (int i = 0; i < 7; i++)
            {
                if (CanMoveToTableau(card, i))
                {
                    tableau[i].Push(waste.Pop());
                    score += 5;
                    DrawGame();
                    return;
                }
            }
        }

        // Foundation
        private void FoundationPanel_Click(object sender, EventArgs e)
        {
            // Not needed, handled by card events
        }

        private void FoundationCard_MouseDown(object sender, MouseEventArgs e)
        {
            var pb = sender as PictureBox;
            int foundationIndex = (int)pb.Tag;
            if (foundation[foundationIndex].Count == 0) return;
            var card = foundation[foundationIndex].Peek();
            if (e.Button == MouseButtons.Left)
            {
                dragCards = new List<Card> { card };
                dragFromFoundation = foundationIndex;
                pb.DoDragDrop("foundation", DragDropEffects.Move);
            }
        }

        private void FoundationCard_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var pb = sender as PictureBox;
            int foundationIndex = (int)pb.Tag;
            if (foundation[foundationIndex].Count == 0) return;
            var card = foundation[foundationIndex].Peek();
            // Try to move back to tableau if possible
            for (int i = 0; i < 7; i++)
            {
                if (CanMoveToTableau(card, i))
                {
                    foundation[foundationIndex].Pop();
                    tableau[i].Push(card);
                    score -= 15;
                    DrawGame();
                    return;
                }
            }
        }

        private void FoundationPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (dragCards != null && dragCards.Count == 1)
                e.Effect = DragDropEffects.Move;
        }

        private void FoundationPanel_DragDrop(object sender, DragEventArgs e)
        {
            var panel = sender as Panel;
            int destFoundation = (int)panel.Tag;
            if (dragCards == null || dragCards.Count != 1) return;
            var card = dragCards[0];
            if (CanMoveToFoundation(card, destFoundation))
            {
                if (dragFromTableau != -1)
                {
                    tableau[dragFromTableau].Pop();
                    score += 10;
                    // Flip next card if needed
                    var srcCards = tableau[dragFromTableau].Reverse().ToList();
                    if (srcCards.Count > 0 && !srcCards.Last().FaceUp)
                    {
                        srcCards.Last().FaceUp = true;
                        tableau[dragFromTableau] = new Stack<Card>(srcCards.Reverse<Card>());
                        score += 5;
                    }
                }
                else if (dragFromWaste)
                {
                    waste.Pop();
                    score += 10;
                }
                else if (dragFromFoundation != -1)
                {
                    foundation[dragFromFoundation].Pop();
                    score -= 15;
                }
                foundation[destFoundation].Push(card);
            }
            ResetDragState();
            DrawGame();
        }

        // Tableau
        private void TableauPanel_Click(object sender, EventArgs e)
        {
            // Not needed, handled by card events
        }

        private void TableauCard_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var pb = sender as PictureBox;
            var tag = (Tuple<int, int>)pb.Tag;
            int pile = tag.Item1;
            int index = tag.Item2;
            var cards = tableau[pile].Reverse().ToList();
            var card = cards[index];
            if (!card.FaceUp) return;
            dragCards = cards.Skip(index).ToList();
            dragFromTableau = pile;
            dragFromIndex = index;
            pb.DoDragDrop("cards", DragDropEffects.Move);
        }

        private void TableauCard_MouseUp(object sender, MouseEventArgs e)
        {
            // Optional: highlight or feedback
        }

        private void TableauCard_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var pb = sender as PictureBox;
            var tag = (Tuple<int, int>)pb.Tag;
            int pile = tag.Item1;
            int index = tag.Item2;
            var cards = tableau[pile].Reverse().ToList();
            var card = cards[index];
            if (!card.FaceUp) return;
            if (AutoMoveToFoundation(card, fromTableau: pile, tableauIndex: index)) return;
            // Try tableau
            for (int i = 0; i < 7; i++)
            {
                if (i == pile) continue;
                if (CanMoveToTableau(card, i))
                {
                    var movingCards = cards.Skip(index).ToList();
                    for (int j = 0; j < movingCards.Count; j++)
                        tableau[pile].Pop();
                    foreach (var c in movingCards)
                        tableau[i].Push(c);
                    score += 5;
                    DrawGame();
                    return;
                }
            }
        }

        private void TableauPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (dragCards != null && dragCards.Count > 0)
                e.Effect = DragDropEffects.Move;
        }

        private void TableauPanel_DragDrop(object sender, DragEventArgs e)
        {
            var panel = sender as Panel;
            int destPile = (int)panel.Tag;
            if (dragCards == null || dragCards.Count == 0) return;
            var card = dragCards[0];
            if (CanMoveToTableau(card, destPile))
            {
                if (dragFromTableau != -1)
                {
                    for (int j = 0; j < dragCards.Count; j++)
                        tableau[dragFromTableau].Pop();
                    score += 5;
                    // Flip next card if needed
                    var srcCards = tableau[dragFromTableau].Reverse().ToList();
                    if (srcCards.Count > 0 && !srcCards.Last().FaceUp)
                    {
                        srcCards.Last().FaceUp = true;
                        tableau[dragFromTableau] = new Stack<Card>(srcCards.Reverse<Card>());
                        score += 5;
                    }
                }
                else if (dragFromWaste)
                {
                    waste.Pop();
                    score += 5;
                }
                else if (dragFromFoundation != -1)
                {
                    foundation[dragFromFoundation].Pop();
                    score -= 15;
                }
                foreach (var c in dragCards)
                    tableau[destPile].Push(c);
            }
            ResetDragState();
            DrawGame();
        }

        // Auto-move logic
        private bool AutoMoveToFoundation(Card card, bool fromWaste = false, int fromTableau = -1, int tableauIndex = -1)
        {
            for (int i = 0; i < 4; i++)
            {
                if (CanMoveToFoundation(card, i))
                {
                    if (fromWaste)
                    {
                        waste.Pop();
                        score += 10;
                    }
                    else if (fromTableau != -1)
                    {
                        var cards = tableau[fromTableau].Reverse().ToList();
                        if (tableauIndex == cards.Count - 1)
                        {
                            tableau[fromTableau].Pop();
                            score += 10;
                            // Flip next card if needed
                            var srcCards = tableau[fromTableau].Reverse().ToList();
                            if (srcCards.Count > 0 && !srcCards.Last().FaceUp)
                            {
                                srcCards.Last().FaceUp = true;
                                tableau[fromTableau] = new Stack<Card>(srcCards.Reverse<Card>());
                                score += 5;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                    foundation[i].Push(card);
                    DrawGame();
                    return true;
                }
            }
            return false;
        }

        private void ResetDragState()
        {
            dragCards = null;
            dragFromTableau = -1;
            dragFromIndex = -1;
            dragFromFoundation = -1;
            dragFromWaste = false;
        }

        // Game logic
        private List<Card> CreateDeck()
        {
            var deck = new List<Card>();
            foreach (var suit in new[] { "♠", "♥", "♦", "♣" })
                for (int v = 1; v <= 13; v++)
                    deck.Add(new Card { Suit = suit, Value = v, FaceUp = false });
            return deck;
        }

        private void Shuffle(List<Card> deck)
        {
            var rng = new Random();
            for (int i = deck.Count - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                var temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }
        }

        private bool CanMoveToFoundation(Card card, int foundationIndex)
        {
            var pile = foundation[foundationIndex];
            if (pile.Count == 0)
                return card.Value == 1; // Ace
            var top = pile.Peek();
            return top.Suit == card.Suit && card.Value == top.Value + 1;
        }

        private bool CanMoveToTableau(Card card, int tableauIndex)
        {
            var pile = tableau[tableauIndex];
            if (pile.Count == 0)
                return card.Value == 13; // King
            var top = pile.Peek();
            bool oppositeColor = (IsRed(card.Suit) != IsRed(top.Suit));
            return oppositeColor && card.Value == top.Value - 1;
        }

        private bool IsRed(string suit) => suit == "♥" || suit == "♦";

        private Image DrawCard(Card card)
        {
            Bitmap bmp = new Bitmap(70, 100);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                var color = IsRed(card.Suit) ? Brushes.Red : Brushes.Black;
                string valueStr = card.Value switch
                {
                    1 => "A",
                    11 => "J",
                    12 => "Q",
                    13 => "K",
                    _ => card.Value.ToString()
                };
                g.DrawString($"{valueStr}{card.Suit}", new Font("Segoe UI", 16, FontStyle.Bold), color, 5, 5);
            }
            return bmp;
        }

        private Image DrawCardBack()
        {
            Bitmap bmp = new Bitmap(70, 100);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.DarkBlue);
                g.DrawRectangle(Pens.White, 2, 2, 66, 96);
                g.DrawString("🂠", new Font("Segoe UI", 24), Brushes.White, 10, 30);
            }
            return bmp;
        }

        private class Card
        {
            public string Suit { get; set; }
            public int Value { get; set; }
            public bool FaceUp { get; set; }
        }
    }
}