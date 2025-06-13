namespace CRM_WindowsForms.Presentation
{
    public partial class Sudoku : Form
    {
        private const int TileSize = 40;
        private const int BoardSize = 9;
        private TextBox[,] cells = new TextBox[BoardSize, BoardSize];
        private Button btnCheck;
        private Button btnReset;
        private ComboBox cmbDifficulty;
        private Label lblDifficulty;

        private int[,] puzzle = new int[BoardSize, BoardSize];
        private int[,] solution = new int[BoardSize, BoardSize];

        public Sudoku()
        {
            InitializeComponent();
            InitializeSudokuBoard();
            InitializeControls();
            GeneratePuzzle();
        }

        private void InitializeSudokuBoard()
        {
            this.ClientSize = new Size(BoardSize * TileSize + 20, BoardSize * TileSize + 120);
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    var tb = new TextBox
                    {
                        Size = new Size(TileSize, TileSize),
                        Location = new Point(col * TileSize + 10, row * TileSize + 10),
                        Font = new Font("Segoe UI", 16, FontStyle.Bold),
                        TextAlign = HorizontalAlignment.Center,
                        MaxLength = 1,
                        Tag = new Point(col, row)
                    };
                    tb.KeyPress += Cell_KeyPress;
                    cells[col, row] = tb;
                    this.Controls.Add(tb);
                }
            }
        }

        private void InitializeControls()
        {
            lblDifficulty = new Label
            {
                Text = "Difficulty:",
                Location = new Point(10, BoardSize * TileSize + 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };
            this.Controls.Add(lblDifficulty);

            cmbDifficulty = new ComboBox
            {
                Location = new Point(80, BoardSize * TileSize + 16),
                Size = new Size(100, 28),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };
            cmbDifficulty.Items.AddRange(new[] { "Easy", "Medium", "Hard" });
            cmbDifficulty.SelectedIndex = 0;
            cmbDifficulty.SelectedIndexChanged += (s, e) => GeneratePuzzle();
            this.Controls.Add(cmbDifficulty);

            btnCheck = new Button
            {
                Text = "Check",
                Size = new Size(80, 32),
                Location = new Point(200, BoardSize * TileSize + 16)
            };
            btnCheck.Click += (s, e) => CheckSolution();
            this.Controls.Add(btnCheck);

            btnReset = new Button
            {
                Text = "Reset",
                Size = new Size(80, 32),
                Location = new Point(290, BoardSize * TileSize + 16)
            };
            btnReset.Click += (s, e) => GeneratePuzzle();
            this.Controls.Add(btnReset);
        }

        private void Cell_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits 1-9 and backspace
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < '1' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
        }

        private void GeneratePuzzle()
        {
            // Step 1: Generate a full valid board
            solution = new int[BoardSize, BoardSize];
            FillBoard(solution);

            // Step 2: Copy solution to puzzle and remove random cells based on difficulty
            puzzle = (int[,])solution.Clone();
            int removeCount = GetRemoveCountForDifficulty();
            RemoveCells(puzzle, removeCount);

            // Step 3: Update UI
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    if (puzzle[row, col] != 0)
                    {
                        cells[col, row].Text = puzzle[row, col].ToString();
                        cells[col, row].ReadOnly = true;
                        cells[col, row].BackColor = Color.LightGray;
                    }
                    else
                    {
                        cells[col, row].Text = "";
                        cells[col, row].ReadOnly = false;
                        cells[col, row].BackColor = Color.White;
                    }
                }
            }
        }

        private int GetRemoveCountForDifficulty()
        {
            switch (cmbDifficulty.SelectedIndex)
            {
                case 0: return 30; // Easy
                case 1: return 40; // Medium
                case 2: return 55; // Hard
                default: return 40;
            }
        }

        // Backtracking Sudoku board generator
        private bool FillBoard(int[,] board)
        {
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    if (board[row, col] == 0)
                    {
                        var nums = Enumerable.Range(1, 9).OrderBy(_ => Guid.NewGuid()).ToList();
                        foreach (var num in nums)
                        {
                            if (IsSafe(board, row, col, num))
                            {
                                board[row, col] = num;
                                if (FillBoard(board))
                                    return true;
                                board[row, col] = 0;
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsSafe(int[,] board, int row, int col, int num)
        {
            // Row and column
            for (int i = 0; i < BoardSize; i++)
                if (board[row, i] == num || board[i, col] == num)
                    return false;
            // 3x3 block
            int startRow = (row / 3) * 3, startCol = (col / 3) * 3;
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    if (board[startRow + r, startCol + c] == num)
                        return false;
            return true;
        }

        private void RemoveCells(int[,] board, int count)
        {
            var rand = new Random();
            int removed = 0;
            while (removed < count)
            {
                int row = rand.Next(BoardSize);
                int col = rand.Next(BoardSize);
                if (board[row, col] != 0)
                {
                    board[row, col] = 0;
                    removed++;
                }
            }
        }

        private void CheckSolution()
        {
            // Check if all cells are filled and match the solution
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    string text = cells[col, row].Text;
                    if (string.IsNullOrWhiteSpace(text) || !int.TryParse(text, out int val) || val != solution[row, col])
                    {
                        MessageBox.Show("Incorrect or incomplete solution.", "Sudoku", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            MessageBox.Show("Congratulations! You solved the puzzle!", "Sudoku", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}