using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player)
            : base(player)
        {
        }


        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);

            // White piece
            if (Player == Player.White)
            {
                var availableWhiteMoves = new List<Square>();

                if (currentSquare.Row-1<0 ) 
                {
                    return availableWhiteMoves;
                }

                if (currentSquare.Col - 1 >= 0 &&
                    board.GetPiece(Square.At(currentSquare.Row - 1, currentSquare.Col - 1)) != null &&
                    board.GetPiece(Square.At(currentSquare.Row - 1, currentSquare.Col - 1)).Player != Player)
                {
                    availableWhiteMoves.Add(Square.At(currentSquare.Row - 1, currentSquare.Col - 1));
                }

                if (currentSquare.Col + 1 < 8 &&
                    board.GetPiece(Square.At(currentSquare.Row - 1, currentSquare.Col + 1)) != null &&
                    board.GetPiece(Square.At(currentSquare.Row - 1, currentSquare.Col + 1)).Player != Player)
                {
                    availableWhiteMoves.Add(Square.At(currentSquare.Row - 1, currentSquare.Col + 1));
                }

                if (board.GetPiece(Square.At(currentSquare.Row - 1, currentSquare.Col)) != null) 
                {
                    return availableWhiteMoves;
                }

                availableWhiteMoves.Add(new Square(currentSquare.Row - 1, currentSquare.Col));

                if (HasMoved)
                {
                    return availableWhiteMoves;
                }

                if (currentSquare.Row -2<0 || board.GetPiece(Square.At(currentSquare.Row - 2, currentSquare.Col)) != null)
                {
                    return availableWhiteMoves;
                }

                availableWhiteMoves.Add(new Square(currentSquare.Row - 2, currentSquare.Col));
                return availableWhiteMoves;

            }

            // Black piece

            var availableBlackMoves = new List<Square>();

            if (currentSquare.Row + 1 > 7 )
            {
                return availableBlackMoves;
            }

            if (currentSquare.Col -1 >=0 &&
                board.GetPiece(Square.At(currentSquare.Row + 1, currentSquare.Col - 1)) != null &&
                board.GetPiece(Square.At(currentSquare.Row + 1, currentSquare.Col - 1)).Player != Player)
            {
                availableBlackMoves.Add(Square.At(currentSquare.Row + 1, currentSquare.Col - 1));
            }

            if (currentSquare.Col + 1 < 8 &&
                board.GetPiece(Square.At(currentSquare.Row + 1, currentSquare.Col + 1)) != null &&
                board.GetPiece(Square.At(currentSquare.Row + 1, currentSquare.Col + 1)).Player != Player)
            {
                availableBlackMoves.Add(Square.At(currentSquare.Row + 1, currentSquare.Col + 1));
            }

            if (board.GetPiece(Square.At(currentSquare.Row + 1, currentSquare.Col)) != null)
            {
                return availableBlackMoves;
            }

            availableBlackMoves.Add(new Square(currentSquare.Row + 1, currentSquare.Col));

            if (HasMoved)
            {
                return availableBlackMoves;
            }

            if (currentSquare.Row + 2>7 || board.GetPiece(Square.At(currentSquare.Row + 2, currentSquare.Col)) != null)
            {
                return availableBlackMoves;
            }

            availableBlackMoves.Add(new Square(currentSquare.Row + 2, currentSquare.Col));
            return availableBlackMoves;
        }
          
    }
}