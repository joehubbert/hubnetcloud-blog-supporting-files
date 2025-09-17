namespace CRM.Presentation.Games
{
    public partial class Minesweeper : Form
    {
        private enum Difficulty { Beginner, Intermediate, Expert }
        private readonly Dictionary<Difficulty, (int rows, int cols, int mines)> _levels = new()
        {
            { Difficulty.Beginner, (9, 9, 10) },
            { Difficulty.Intermediate, (16, 16, 40) },
            { Difficulty.Expert, (16, 30, 99) }
        };

        private Button[,] _cells;
        private bool[,] _mines;
        private int[,] _adjacent;
        private bool[,] _revealed;
        private bool _gameOver;
        private int _rows, _cols, _minesCount, _cellsRevealed;
        private Panel _boardPanel;
        private ComboBox _difficultyBox;

        // Animation fields
        private List<(Button btn, int radius, System.Windows.Forms.Timer timer)> _explosions = new();
        private System.Windows.Forms.Timer _sparkleTimer;
        private Random _rand = new();

        public Minesweeper()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeGameUI();
        }

        private void InitializeGameUI()
        {
            // Difficulty selection
            _difficultyBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Location = new Point(10, 10),
                Width = 120
            };
            _difficultyBox.Items.AddRange(Enum.GetNames(typeof(Difficulty)));
            _difficultyBox.SelectedIndex = 0;
            _difficultyBox.SelectedIndexChanged += (s, e) => StartGame();
            Controls.Add(_difficultyBox);

            // Board panel
            _boardPanel = new Panel
            {
                Location = new Point(10, 40),
                AutoSize = true
            };
            Controls.Add(_boardPanel);

            StartGame();
        }

        private void StartGame()
        {
            _gameOver = false;
            _cellsRevealed = 0;
            _boardPanel.Controls.Clear();

            var diff = (Difficulty)_difficultyBox.SelectedIndex;
            (_rows, _cols, _minesCount) = _levels[diff];

            _cells = new Button[_rows, _cols];
            _mines = new bool[_rows, _cols];
            _adjacent = new int[_rows, _cols];
            _revealed = new bool[_rows, _cols];

            // Create grid
            for (int r = 0; r < _rows; r++)
            {
                for (int c = 0; c < _cols; c++)
                {
                    var btn = new Button
                    {
                        Size = new Size(30, 30),
                        Location = new Point(c * 30, r * 30),
                        Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold),
                        FlatStyle = FlatStyle.Flat,
                        BackColor = Color.LightGray,
                        Tag = (r, c)
                    };
                    btn.MouseUp += Cell_MouseUp;
                    _boardPanel.Controls.Add(btn);
                    _cells[r, c] = btn;
                }
            }

            // Place mines and calculate adjacent counts
            PlaceMines();
            CalculateAdjacents();

            // Resize form
            this.ClientSize = new Size(Math.Max(_cols * 30 + 20, 150), _rows * 30 + 60);
            this.CenterToScreen();
        }

        private void PlaceMines()
        {
            var rand = new Random();
            int placed = 0;
            while (placed < _minesCount)
            {
                int r = rand.Next(_rows), c = rand.Next(_cols);
                if (!_mines[r, c])
                {
                    _mines[r, c] = true;
                    placed++;
                }
            }
        }

        private void CalculateAdjacents()
        {
            for (int r = 0; r < _rows; r++)
            {
                for (int c = 0; c < _cols; c++)
                {
                    if (_mines[r, c]) continue;
                    int count = 0;
                    for (int dr = -1; dr <= 1; dr++)
                        for (int dc = -1; dc <= 1; dc++)
                        {
                            int nr = r + dr, nc = c + dc;
                            if (nr >= 0 && nr < _rows && nc >= 0 && nc < _cols && _mines[nr, nc])
                                count++;
                        }
                    _adjacent[r, c] = count;
                }
            }
        }

        private void Cell_MouseUp(object sender, MouseEventArgs e)
        {
            if (_gameOver) return;
            var btn = (Button)sender;
            var (r, c) = ((int, int))btn.Tag;

            if (e.Button == MouseButtons.Right)
            {
                // Flag animation
                if (btn.Text == "")
                {
                    btn.Text = "🚩";
                    btn.ForeColor = Color.Red;
                }
                else if (btn.Text == "🚩")
                {
                    btn.Text = "";
                }
                return;
            }

            if (_revealed[r, c] || btn.Text == "🚩") return;

            RevealCell(r, c);
        }

        private void RevealCell(int r, int c)
        {
            if (_revealed[r, c]) return;
            _revealed[r, c] = true;
            var btn = _cells[r, c];

            if (_mines[r, c])
            {
                btn.Text = "💣";
                btn.BackColor = Color.Red;
                StartExplosionAnimation(btn);
                GameOver(false);
                return;
            }

            // Animation: fade in color
            System.Windows.Forms.Timer anim = new System.Windows.Forms.Timer { Interval = 10 };
            int step = 0;
            anim.Tick += (s, e) =>
            {
                step++;
                btn.BackColor = Color.FromArgb(255, 200 + step, 200 + step, 200 + step);
                if (step >= 55)
                {
                    anim.Stop();
                    btn.BackColor = Color.White;
                }
            };
            anim.Start();

            _cellsRevealed++;
            if (_adjacent[r, c] > 0)
            {
                btn.Text = _adjacent[r, c].ToString();
                btn.ForeColor = GetNumberColor(_adjacent[r, c]);
            }
            else
            {
                // Reveal neighbors recursively
                for (int dr = -1; dr <= 1; dr++)
                    for (int dc = -1; dc <= 1; dc++)
                    {
                        int nr = r + dr, nc = c + dc;
                        if (nr >= 0 && nr < _rows && nc >= 0 && nc < _cols)
                            RevealCell(nr, nc);
                    }
            }

            if (_cellsRevealed == _rows * _cols - _minesCount)
                GameOver(true);
        }

        private void StartExplosionAnimation(Button btn)
        {
            int maxRadius = btn.Width;
            int radius = 0;
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer { Interval = 15 };
            timer.Tick += (s, e) =>
            {
                radius += 4;
                btn.Invalidate();
                if (radius >= maxRadius)
                {
                    timer.Stop();
                    btn.Paint -= ExplosionPaint;
                }
            };
            btn.Paint += ExplosionPaint;
            _explosions.Add((btn, radius, timer));
            timer.Start();

            void ExplosionPaint(object sender, PaintEventArgs pe)
            {
                var (b, r, _) = _explosions.FirstOrDefault(x => x.btn == btn);
                if (r > 0)
                {
                    using var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                        new Rectangle(0, 0, btn.Width, btn.Height),
                        Color.OrangeRed, Color.Yellow, 45f);
                    pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    pe.Graphics.FillEllipse(brush, btn.Width / 2 - r / 2, btn.Height / 2 - r / 2, r, r);
                }
            }
        }

        private Color GetNumberColor(int n) => n switch
        {
            1 => Color.Blue,
            2 => Color.Green,
            3 => Color.Red,
            4 => Color.Navy,
            5 => Color.Maroon,
            6 => Color.Teal,
            7 => Color.Black,
            8 => Color.Gray,
            _ => Color.Black
        };

        private void GameOver(bool won)
        {
            _gameOver = true;
            foreach (var btn in _cells)
            {
                var (r, c) = ((int, int))btn.Tag;
                if (_mines[r, c])
                {
                    btn.Text = "💣";
                    btn.BackColor = won ? Color.LightGreen : Color.OrangeRed;
                    if (!won)
                        StartExplosionAnimation(btn);
                }
            }
            if (won)
                StartSparkleAnimation();

            string msg = won ? "Congratulations! You won!" : "Boom! Game over.";
            MessageBox.Show(msg, "CRM - Minesweeper");
        }

        // --- Sparkle Animation ---
        private void StartSparkleAnimation()
        {
            int sparkleCount = 0;
            _sparkleTimer = new System.Windows.Forms.Timer { Interval = 40 };
            _sparkleTimer.Tick += (s, e) =>
            {
                if (sparkleCount > 60)
                {
                    _sparkleTimer.Stop();
                    foreach (var btn in _cells)
                        btn.Invalidate();
                    return;
                }
                for (int i = 0; i < 8; i++)
                {
                    int r = _rand.Next(_rows), c = _rand.Next(_cols);
                    var btn = _cells[r, c];
                    btn.Paint += SparklePaint;
                    btn.Invalidate();
                }
                sparkleCount++;
            };
            _sparkleTimer.Start();
        }

        private void SparklePaint(object sender, PaintEventArgs pe)
        {
            var btn = (Button)sender;
            int sparkleSize = _rand.Next(4, 10);
            int x = _rand.Next(0, btn.Width - sparkleSize);
            int y = _rand.Next(0, btn.Height - sparkleSize);
            using var brush = new SolidBrush(Color.FromArgb(255, _rand.Next(256), _rand.Next(256), _rand.Next(256)));
            pe.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pe.Graphics.FillEllipse(brush, x, y, sparkleSize, sparkleSize);
        }
    }
}