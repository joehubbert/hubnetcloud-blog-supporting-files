namespace CRM_WindowsForms_EnterpriseEdition.Presentation.Functions
{
    public class ChessBoard
    {
        private ChessPiece[,] board = new ChessPiece[8, 8];
        public ChessColor CurrentTurn { get; private set; } = ChessColor.White;

        public ChessBoard()
        {
            SetupBoard();
        }

        public ChessPiece GetPiece(int x, int y) => board[x, y];

        public void MovePiece(int fromX, int fromY, int toX, int toY)
        {
            var piece = board[fromX, fromY];
            board[toX, toY] = piece;
            board[fromX, fromY] = null;
            // Pawn promotion (to queen for simplicity)
            if (piece is Pawn && (toY == 0 || toY == 7))
                board[toX, toY] = new Queen(piece.Color);
            CurrentTurn = CurrentTurn == ChessColor.White ? ChessColor.Black : ChessColor.White;
        }

        public List<Point> GetValidMoves(int x, int y)
        {
            var piece = board[x, y];
            if (piece == null) return new();
            var moves = piece.GetMoves(x, y, this);
            // Remove moves that would leave king in check (not implemented for brevity)
            return moves;
        }

        public List<Point> GetSlidingMoves(int x, int y, ChessColor color, (int dx, int dy)[] directions)
        {
            var moves = new List<Point>();
            foreach (var (dx, dy) in directions)
            {
                int nx = x + dx, ny = y + dy;
                while (nx >= 0 && nx < 8 && ny >= 0 && ny < 8)
                {
                    var p = board[nx, ny];
                    if (p == null)
                        moves.Add(new Point(nx, ny));
                    else
                    {
                        if (p.Color != color)
                            moves.Add(new Point(nx, ny));
                        break;
                    }
                    nx += dx; ny += dy;
                }
            }
            return moves;
        }

        public bool IsCheckmate()
        {
            // Simple checkmate detection: if current player has no moves (not full rules)
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++)
                {
                    var p = board[x, y];
                    if (p != null && p.Color == CurrentTurn && GetValidMoves(x, y).Count > 0)
                        return false;
                }
            return true;
        }

        public bool IsStalemate()
        {
            // Simple stalemate: no moves but not in check (not full rules)
            return false;
        }

        private void SetupBoard()
        {
            // Pawns
            for (int i = 0; i < 8; i++)
            {
                board[i, 1] = new Pawn(ChessColor.Black);
                board[i, 6] = new Pawn(ChessColor.White);
            }
            // Rooks
            board[0, 0] = new Rook(ChessColor.Black); board[7, 0] = new Rook(ChessColor.Black);
            board[0, 7] = new Rook(ChessColor.White); board[7, 7] = new Rook(ChessColor.White);
            // Knights
            board[1, 0] = new Knight(ChessColor.Black); board[6, 0] = new Knight(ChessColor.Black);
            board[1, 7] = new Knight(ChessColor.White); board[6, 7] = new Knight(ChessColor.White);
            // Bishops
            board[2, 0] = new Bishop(ChessColor.Black); board[5, 0] = new Bishop(ChessColor.Black);
            board[2, 7] = new Bishop(ChessColor.White); board[5, 7] = new Bishop(ChessColor.White);
            // Queens
            board[3, 0] = new Queen(ChessColor.Black); board[3, 7] = new Queen(ChessColor.White);
            // Kings
            board[4, 0] = new King(ChessColor.Black); board[4, 7] = new King(ChessColor.White);
            // Empty
            for (int x = 0; x < 8; x++)
                for (int y = 2; y < 6; y++)
                    board[x, y] = null;
            CurrentTurn = ChessColor.White;
        }
    }
}