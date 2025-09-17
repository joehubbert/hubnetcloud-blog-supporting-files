namespace CRM.Helpers
{
    public enum ChessColor { White, Black }

    public abstract class ChessPieceHelper
    {
        public ChessColor Color { get; }
        public ChessPieceHelper(ChessColor color) { Color = color; }
        public abstract List<Point> GetMoves(int x, int y, ChessBoardHelper board);
        public abstract string GetUnicodeSymbol();
    }

    public class ChessPieceKing : ChessPieceHelper
    {
        public ChessPieceKing(ChessColor color) : base(color) { }
        public override List<Point> GetMoves(int x, int y, ChessBoardHelper board)
        {
            var moves = new List<Point>();
            for (int dx = -1; dx <= 1; dx++)
                for (int dy = -1; dy <= 1; dy++)
                    if (dx != 0 || dy != 0)
                    {
                        int nx = x + dx, ny = y + dy;
                        if (nx >= 0 && nx < 8 && ny >= 0 && ny < 8)
                        {
                            var p = board.GetPiece(nx, ny);
                            if (p == null || p.Color != Color)
                                moves.Add(new Point(nx, ny));
                        }
                    }
            return moves;
        }
        public override string GetUnicodeSymbol() => Color == ChessColor.White ? "♚" : "♚";
    }

    public class ChessPieceQueen : ChessPieceHelper
    {
        public ChessPieceQueen(ChessColor color) : base(color) { }
        public override List<Point> GetMoves(int x, int y, ChessBoardHelper board)
        {
            var moves = new List<Point>();
            moves.AddRange(board.GetSlidingMoves(x, y, Color, new[] { (1, 0), (0, 1), (-1, 0), (0, -1), (1, 1), (-1, 1), (1, -1), (-1, -1) }));
            return moves;
        }
        public override string GetUnicodeSymbol() => Color == ChessColor.White ? "♛" : "♛";
    }

    public class ChessPieceRook : ChessPieceHelper
    {
        public ChessPieceRook(ChessColor color) : base(color) { }
        public override List<Point> GetMoves(int x, int y, ChessBoardHelper board)
        {
            return board.GetSlidingMoves(x, y, Color, new[] { (1, 0), (0, 1), (-1, 0), (0, -1) });
        }
        public override string GetUnicodeSymbol() => Color == ChessColor.White ? "♜" : "♜";
    }

    public class ChessPieceBishop : ChessPieceHelper
    {
        public ChessPieceBishop(ChessColor color) : base(color) { }
        public override List<Point> GetMoves(int x, int y, ChessBoardHelper board)
        {
            return board.GetSlidingMoves(x, y, Color, new[] { (1, 1), (-1, 1), (1, -1), (-1, -1) });
        }
        public override string GetUnicodeSymbol() => Color == ChessColor.White ? "♝" : "♝";
    }

    public class ChessPieceKnight : ChessPieceHelper
    {
        public ChessPieceKnight(ChessColor color) : base(color) { }
        public override List<Point> GetMoves(int x, int y, ChessBoardHelper board)
        {
            var moves = new List<Point>();
            int[] dx = { 1, 2, 2, 1, -1, -2, -2, -1 };
            int[] dy = { 2, 1, -1, -2, -2, -1, 1, 2 };
            for (int i = 0; i < 8; i++)
            {
                int nx = x + dx[i], ny = y + dy[i];
                if (nx >= 0 && nx < 8 && ny >= 0 && ny < 8)
                {
                    var p = board.GetPiece(nx, ny);
                    if (p == null || p.Color != Color)
                        moves.Add(new Point(nx, ny));
                }
            }
            return moves;
        }
        public override string GetUnicodeSymbol() => Color == ChessColor.White ? "♞" : "♞";
    }

    public class ChessPiecePawn : ChessPieceHelper
    {
        public ChessPiecePawn(ChessColor color) : base(color) { }
        public override List<Point> GetMoves(int x, int y, ChessBoardHelper board)
        {
            var moves = new List<Point>();
            int dir = Color == ChessColor.White ? -1 : 1;
            int startRow = Color == ChessColor.White ? 6 : 1;
            // Forward
            int ny = y + dir;
            if (ny >= 0 && ny < 8 && board.GetPiece(x, ny) == null)
            {
                moves.Add(new Point(x, ny));
                if (y == startRow && board.GetPiece(x, y + 2 * dir) == null)
                    moves.Add(new Point(x, y + 2 * dir));
            }
            // Captures
            foreach (int dx in new[] { -1, 1 })
            {
                int nx = x + dx;
                if (nx >= 0 && nx < 8 && ny >= 0 && ny < 8)
                {
                    var p = board.GetPiece(nx, ny);
                    if (p != null && p.Color != Color)
                        moves.Add(new Point(nx, ny));
                }
            }
            return moves;
        }
        public override string GetUnicodeSymbol() => Color == ChessColor.White ? "♟" : "♟";
    }
}