using CRM_WindowsForms_EnterpriseEdition.Presentation.Functions;

namespace CRM_WindowsForms_EnterpriseEdition.Presentation
{
    public partial class Chess : Form
    {
        private const int TileSize = 60;
        private const int BoardSize = 8;
        private Button[,] tiles = new Button[BoardSize, BoardSize];
        private ChessBoard board;
        private Point? selectedTile = null;
        private Label lblTurn;
        private Label lblScoreWhite;
        private Label lblScoreBlack;
        private Label lblCapturedWhite;
        private Label lblCapturedWhite2;
        private Label lblCapturedBlack;
        private Label lblCapturedBlack2;
        private Button btnReset;
        private int scoreWhite = 0;
        private int scoreBlack = 0;
        private List<ChessPiece> capturedByWhite = new();
        private List<ChessPiece> capturedByBlack = new();

        // Game mode and AI
        private enum GameMode { TwoPlayer, VsComputer }
        private enum Difficulty { Easy, Medium, Hard }
        private GameMode gameMode = GameMode.TwoPlayer;
        private Difficulty aiDifficulty = Difficulty.Easy;
        private ChessColor computerColor = ChessColor.Black;
        private Random rng = new();

        public Chess()
        {
            InitializeComponent();
            ShowGameModeDialog();
            InitializeChessBoard();
            InitializeScoreboard();
            InitializeCapturedLabels();
            InitializeResetButton();
            // If computer is white, let it move first
            if (gameMode == GameMode.VsComputer && board.CurrentTurn == computerColor)
                ComputerMove();
        }

        private void ShowGameModeDialog()
        {
            using (var dialog = new Form())
            {
                dialog.Text = "Choose Game Mode";
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.ClientSize = new Size(320, 180);
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;

                var btn2P = new Button { Text = "2 Player", Location = new Point(30, 30), Size = new Size(110, 40) };
                var btnVsAI = new Button { Text = "Vs Computer", Location = new Point(170, 30), Size = new Size(110, 40) };
                var lblDiff = new Label { Text = "Difficulty:", Location = new Point(30, 90), AutoSize = true };
                var cmbDiff = new ComboBox { Location = new Point(110, 87), Size = new Size(170, 30), DropDownStyle = ComboBoxStyle.DropDownList };
                cmbDiff.Items.AddRange(new[] { "Easy", "Medium", "Hard" });
                cmbDiff.SelectedIndex = 0;
                cmbDiff.Enabled = false;

                btn2P.Click += (s, e) => { gameMode = GameMode.TwoPlayer; dialog.DialogResult = DialogResult.OK; dialog.Close(); };
                btnVsAI.Click += (s, e) => { gameMode = GameMode.VsComputer; cmbDiff.Enabled = true; };

                cmbDiff.SelectedIndexChanged += (s, e) =>
                {
                    aiDifficulty = (Difficulty)cmbDiff.SelectedIndex;
                    if (gameMode == GameMode.VsComputer)
                    {
                        var colorResult = MessageBox.Show("Do you want to play as White?", "Choose Color", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        computerColor = colorResult == DialogResult.Yes ? ChessColor.Black : ChessColor.White;
                        dialog.DialogResult = DialogResult.OK;
                        dialog.Close();
                    }
                };

                dialog.Controls.Add(btn2P);
                dialog.Controls.Add(btnVsAI);
                dialog.Controls.Add(lblDiff);
                dialog.Controls.Add(cmbDiff);

                dialog.ShowDialog();
            }
        }

        private void InitializeChessBoard()
        {
            board = new ChessBoard();
            this.ClientSize = new Size(BoardSize * TileSize, BoardSize * TileSize + 130);

            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    var btn = new Button
                    {
                        Size = new Size(TileSize, TileSize),
                        Location = new Point(col * TileSize, row * TileSize + 40),
                        BackColor = (row + col) % 2 == 0 ? Color.BurlyWood : Color.SaddleBrown,
                        Font = new Font("Segoe UI", 32, FontStyle.Bold),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Tag = new Point(col, row),
                        FlatStyle = FlatStyle.Flat
                    };
                    btn.FlatAppearance.BorderColor = Color.Black;
                    btn.FlatAppearance.BorderSize = 1;
                    btn.Click += Tile_Click;
                    tiles[col, row] = btn;
                    this.Controls.Add(btn);
                }
            }
            UpdateBoardUI();
        }

        private void InitializeScoreboard()
        {
            lblTurn = new Label
            {
                Text = "Turn: White",
                Location = new Point(10, 10),
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            this.Controls.Add(lblTurn);

            lblScoreWhite = new Label
            {
                Text = "White: 0",
                Location = new Point(150, 10),
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            this.Controls.Add(lblScoreWhite);

            lblScoreBlack = new Label
            {
                Text = "Black: 0",
                Location = new Point(250, 10),
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            this.Controls.Add(lblScoreBlack);
        }

        private void InitializeCapturedLabels()
        {
            lblCapturedWhite = new Label
            {
                Text = "White captured: ",
                Location = new Point(10, BoardSize * TileSize + 50),
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Regular)
            };
            this.Controls.Add(lblCapturedWhite);

            lblCapturedWhite2 = new Label
            {
                Text = "",
                Location = new Point(10, BoardSize * TileSize + 70),
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Regular)
            };
            this.Controls.Add(lblCapturedWhite2);

            lblCapturedBlack = new Label
            {
                Text = "Black captured: ",
                Location = new Point(10, BoardSize * TileSize + 90),
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Regular)
            };
            this.Controls.Add(lblCapturedBlack);

            lblCapturedBlack2 = new Label
            {
                Text = "",
                Location = new Point(10, BoardSize * TileSize + 110),
                AutoSize = true,
                Font = new Font("Segoe UI", 12, FontStyle.Regular)
            };
            this.Controls.Add(lblCapturedBlack2);
        }

        private void InitializeResetButton()
        {
            btnReset = new Button
            {
                Text = "Reset Game",
                Size = new Size(120, 32),
                Location = new Point(BoardSize * TileSize - 130, BoardSize * TileSize + 55),
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat
            };
            btnReset.Click += (s, e) => { ResetGame(); if (gameMode == GameMode.VsComputer && board.CurrentTurn == computerColor) ComputerMove(); };
            this.Controls.Add(btnReset);
        }

        private int GetPieceValue(ChessPiece piece)
        {
            return piece switch
            {
                Pawn => 1,
                Knight => 3,
                Bishop => 3,
                Rook => 5,
                Queen => 9,
                King => 0,
                _ => 0
            };
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            if (gameMode == GameMode.VsComputer && board.CurrentTurn == computerColor)
                return; // Prevent player from moving during computer's turn

            var btn = sender as Button;
            var pos = (Point)btn.Tag;
            var piece = board.GetPiece(pos.X, pos.Y);

            if (selectedTile == null)
            {
                // Select a piece if it's the player's turn
                if (piece != null && piece.Color == board.CurrentTurn)
                {
                    selectedTile = pos;
                    btn.BackColor = Color.Yellow;
                    // Highlight valid moves
                    foreach (var move in board.GetValidMoves(pos.X, pos.Y))
                    {
                        tiles[move.X, move.Y].BackColor = Color.LightGreen;
                    }
                }
            }
            else
            {
                var from = selectedTile.Value;
                var movingPiece = board.GetPiece(from.X, from.Y);
                var validMoves = board.GetValidMoves(from.X, from.Y);

                if (movingPiece != null && movingPiece.Color == board.CurrentTurn &&
                    validMoves.Exists(p => p.X == pos.X && p.Y == pos.Y))
                {
                    // Capture logic: check if destination has a piece
                    var captured = board.GetPiece(pos.X, pos.Y);
                    if (captured != null)
                    {
                        int value = GetPieceValue(captured);
                        if (captured.Color == ChessColor.White)
                        {
                            capturedByBlack.Add(captured);
                            scoreBlack += value;
                        }
                        else
                        {
                            capturedByWhite.Add(captured);
                            scoreWhite += value;
                        }
                        UpdateScoreboard();

                        // If a king is captured, end the game immediately
                        if (captured is King)
                        {
                            string winner = captured.Color == ChessColor.White ? "Black" : "White";
                            MessageBox.Show($"Checkmate! {winner} wins by capturing the king.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ResetGame();
                            return;
                        }
                    }

                    board.MovePiece(from.X, from.Y, pos.X, pos.Y);
                    selectedTile = null;
                    AfterPlayerMove();
                    return;
                }
                selectedTile = null;
                UpdateBoardUI();
            }
        }

        private void AfterPlayerMove()
        {
            UpdateBoardUI();
            UpdateTurnLabel();
            UpdateCapturedLabels();

            // Check for checkmate
            if (board.IsCheckmate())
            {
                if (board.CurrentTurn == ChessColor.White)
                {
                    UpdateScoreboard();
                    MessageBox.Show("Checkmate! Black wins.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    UpdateScoreboard();
                    MessageBox.Show("Checkmate! White wins.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ResetGame();
                if (gameMode == GameMode.VsComputer && board.CurrentTurn == computerColor)
                    ComputerMove();
                return;
            }
            // Check for stalemate (not implemented in ChessBoard, but placeholder)
            if (board.IsStalemate())
            {
                MessageBox.Show("Stalemate! Draw.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetGame();
                if (gameMode == GameMode.VsComputer && board.CurrentTurn == computerColor)
                    ComputerMove();
                return;
            }
            // Check for check
            if (IsCheck())
            {
                MessageBox.Show("Check!");
            }

            // If vs computer and it's computer's turn, make computer move
            if (gameMode == GameMode.VsComputer && board.CurrentTurn == computerColor)
            {
                ComputerMove();
            }
        }

        private void ComputerMove()
        {
            // Simple AI: pick a move based on difficulty
            var moves = new List<(Point from, Point to)>();
            for (int x = 0; x < BoardSize; x++)
            {
                for (int y = 0; y < BoardSize; y++)
                {
                    var piece = board.GetPiece(x, y);
                    if (piece != null && piece.Color == computerColor)
                    {
                        foreach (var to in board.GetValidMoves(x, y))
                        {
                            moves.Add((new Point(x, y), to));
                        }
                    }
                }
            }
            if (moves.Count == 0) return;

            (Point from, Point to) move;
            switch (aiDifficulty)
            {
                case Difficulty.Easy:
                    move = moves[rng.Next(moves.Count)];
                    break;
                case Difficulty.Medium:
                    // Prefer captures, else random
                    var captureMoves = moves.FindAll(m => board.GetPiece(m.to.X, m.to.Y) != null);
                    move = captureMoves.Count > 0 ? captureMoves[rng.Next(captureMoves.Count)] : moves[rng.Next(moves.Count)];
                    break;
                case Difficulty.Hard:
                    // Prefer captures, else prefer center, else random
                    move = moves[0];
                    int bestScore = int.MinValue;
                    foreach (var m in moves)
                    {
                        int score = 0;
                        if (board.GetPiece(m.to.X, m.to.Y) != null) score += 10;
                        score -= Math.Abs(m.to.X - 3) + Math.Abs(m.to.Y - 3); // prefer center
                        if (score > bestScore)
                        {
                            bestScore = score;
                            move = m;
                        }
                    }
                    break;
                default:
                    move = moves[rng.Next(moves.Count)];
                    break;
            }

            // Capture logic
            var captured = board.GetPiece(move.to.X, move.to.Y);
            if (captured != null)
            {
                int value = GetPieceValue(captured);
                if (captured.Color == ChessColor.White)
                {
                    capturedByBlack.Add(captured);
                    scoreBlack += value;
                }
                else
                {
                    capturedByWhite.Add(captured);
                    scoreWhite += value;
                }
                UpdateScoreboard();

                // If a king is captured, end the game immediately
                if (captured is King)
                {
                    string winner = captured.Color == ChessColor.White ? "Black" : "White";
                    MessageBox.Show($"Checkmate! {winner} wins by capturing the king.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetGame();
                    return;
                }
            }

            board.MovePiece(move.from.X, move.from.Y, move.to.X, move.to.Y);
            AfterPlayerMove();
        }

        private void UpdateBoardUI()
        {
            for (int x = 0; x < BoardSize; x++)
            {
                for (int y = 0; y < BoardSize; y++)
                {
                    var piece = board.GetPiece(x, y);
                    tiles[x, y].Text = piece != null ? GetFilledPieceSymbol(piece) : "";

                    // Restore original background color (no highlights)
                    tiles[x, y].BackColor = (y + x) % 2 == 0 ? Color.BurlyWood : Color.SaddleBrown;

                    // Set ForeColor: White pieces in White, Black pieces in Black
                    if (piece != null)
                    {
                        tiles[x, y].ForeColor = piece.Color == ChessColor.White ? Color.White : Color.Black;
                    }
                    else
                    {
                        tiles[x, y].ForeColor = Color.Black;
                    }
                }
            }
        }

        // Always return the filled (black) Unicode symbol for both colors
        private string GetFilledPieceSymbol(ChessPiece piece)
        {
            // Unicode black pieces: rook, knight, bishop, queen, king, pawn
            // ♜ ♞ ♝ ♛ ♚ ♟
            var type = piece.GetType().Name;
            return type switch
            {
                "King" => "♚",
                "Queen" => "♛",
                "Rook" => "♜",
                "Bishop" => "♝",
                "Knight" => "♞",
                "Pawn" => "♟",
                _ => "?"
            };
        }

        private void UpdateTurnLabel()
        {
            lblTurn.Text = "Turn: " + (board.CurrentTurn == ChessColor.White ? "White" : "Black");
        }

        private void UpdateScoreboard()
        {
            lblScoreWhite.Text = $"White: {scoreWhite}";
            lblScoreBlack.Text = $"Black: {scoreBlack}";
        }

        private void UpdateCapturedLabels()
        {
            var whiteSymbols = capturedByWhite.ConvertAll(GetFilledPieceSymbol);
            var blackSymbols = capturedByBlack.ConvertAll(GetFilledPieceSymbol);

            lblCapturedWhite.Text = "White captured: " + string.Join(" ", whiteSymbols.Take(8));
            lblCapturedWhite2.Text = whiteSymbols.Count > 8 ? string.Join(" ", whiteSymbols.Skip(8).Take(8)) : "";

            lblCapturedBlack.Text = "Black captured: " + string.Join(" ", blackSymbols.Take(8));
            lblCapturedBlack2.Text = blackSymbols.Count > 8 ? string.Join(" ", blackSymbols.Skip(8).Take(8)) : "";
        }

        private void ResetGame()
        {
            board = new ChessBoard();
            capturedByWhite.Clear();
            capturedByBlack.Clear();
            scoreWhite = 0; // Reset white score
            scoreBlack = 0; // Reset black score
            UpdateBoardUI();
            UpdateTurnLabel();
            UpdateScoreboard();
            UpdateCapturedLabels();
            // If computer is white, let it move first
            if (gameMode == GameMode.VsComputer && board.CurrentTurn == computerColor)
                ComputerMove();
        }

        private bool IsCheck()
        {
            // Simple check detection: see if the current player's king is attacked
            ChessColor kingColor = board.CurrentTurn;
            Point? kingPos = null;
            for (int x = 0; x < BoardSize; x++)
                for (int y = 0; y < BoardSize; y++)
                {
                    var p = board.GetPiece(x, y);
                    if (p is King && p.Color == kingColor)
                        kingPos = new Point(x, y);
                }
            if (kingPos == null) return false;
            // Check if any enemy piece can move to king's position
            for (int x = 0; x < BoardSize; x++)
                for (int y = 0; y < BoardSize; y++)
                {
                    var p = board.GetPiece(x, y);
                    if (p != null && p.Color != kingColor)
                    {
                        var moves = p.GetMoves(x, y, board);
                        if (moves.Exists(m => m.X == kingPos.Value.X && m.Y == kingPos.Value.Y))
                            return true;
                    }
                }
            return false;
        }
    }
}