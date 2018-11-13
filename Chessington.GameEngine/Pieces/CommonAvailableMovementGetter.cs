using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public static class CommonAvailableMovementGetter
    {
        public static List<Square> GetAvailableLateralMovement(Board board, Piece piece)
        {
            var currentSquare = board.FindPiece(piece);
            var availableMoves = new List<Square>();

            var availableRightMoves = GetAvailableRightMoves(board, piece);
            
            var availableLeftMoves = GetAvailableLeftMoves(board, piece);

            var availableUpMoves = GetAvailableUpMoves(board, piece);

            var availableDownMoves = GetAvailableDownMoves(board, piece);

            availableMoves = availableMoves
                .Concat(availableRightMoves)
                .Concat(availableLeftMoves)
                .Concat(availableUpMoves)
                .Concat(availableDownMoves).ToList();

            availableMoves.RemoveAll(s => s == Square.At(currentSquare.Row, currentSquare.Col));

            return availableMoves;

        }

        private static List<Square> GetAvailableUpMoves(Board board, Piece piece)
        {
            return GetAvailableMovesInDirection(board, piece, -1, 0);

        }

        private static List<Square> GetAvailableDownMoves(Board board, Piece piece)
        {
            return GetAvailableMovesInDirection(board, piece, 1, 0);

        }

        private static List<Square> GetAvailableLeftMoves(Board board, Piece piece)
        {
            return GetAvailableMovesInDirection(board, piece, 0, -1);
  
        }

        private static List<Square> GetAvailableUpLeftMoves(Board board, Piece piece)
        {
            return GetAvailableMovesInDirection(board, piece, -1, -1);

        }

        private static List<Square> GetAvailableDownLeftMoves(Board board, Piece piece)
        {
            return GetAvailableMovesInDirection(board, piece, 1, -1);

        }

        private static List<Square> GetAvailableUpRightMoves(Board board, Piece piece)
        {
            return GetAvailableMovesInDirection(board, piece, -1, 1);

        }

        private static List<Square> GetAvailableDownRightMoves(Board board, Piece piece)
        {
            return GetAvailableMovesInDirection(board, piece, 1, 1);

        }

        private static List<Square> GetAvailableMovesInDirection(Board board, Piece piece, int rowDirection, int colDirection)
        {
            var currentSquare = board.FindPiece(piece);
            var availableMoves = new List<Square>();

            for (var square = new Square(currentSquare.Row+rowDirection, currentSquare.Col+colDirection);
                board.CheckIfOnBoard(square); 
                square = new Square(square.Row + rowDirection, square.Col + colDirection))
            {
                if (board.GetPiece(square) == null)
                {
                    availableMoves.Add(square);
                }
                else if (board.GetPiece(square).Player != piece.Player)
                {
                    availableMoves.Add(square);
                    break;
                }
                else
                {
                    break;
                }

            }
            return availableMoves;
        }

        private static List<Square> GetAvailableRightMoves(Board board, Piece piece)
        {
            return GetAvailableMovesInDirection(board, piece, 0, 1);
        }

        public static List<Square> GetAvailableDiagonalMovement(Board board, Piece piece)
        {
            var currentSquare = board.FindPiece(piece);
            var availableMoves = new List<Square>();

            var availableUpRightMoves = GetAvailableUpRightMoves(board, piece);
            var availableUpLeftMoves = GetAvailableUpLeftMoves(board, piece);
            var availableDownRightMoves = GetAvailableDownRightMoves(board, piece);
            var availableDownLeftMoves = GetAvailableDownLeftMoves(board, piece);

            availableMoves = availableMoves
                .Concat(availableUpRightMoves)
                .Concat(availableUpLeftMoves)
                .Concat(availableDownRightMoves)
                .Concat(availableDownLeftMoves).ToList();

            return availableMoves;
        }
    }
}