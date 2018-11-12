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
                if (board.GetPiece(Square.At(currentSquare.Row - 1, currentSquare.Col)) != null)
                {
                    return Enumerable.Empty<Square>();
                }

                if (HasMoved)
                {
                    return new List<Square>
                        {new Square(currentSquare.Row - 1, currentSquare.Col)};
                }

                if (board.GetPiece(Square.At(currentSquare.Row - 2, currentSquare.Col)) != null)
                {
                    return Enumerable.Empty<Square>();
                }

                return new List<Square>
                {
                    new Square(currentSquare.Row - 1, currentSquare.Col),
                    new Square(currentSquare.Row - 2, currentSquare.Col)
                };
            }

            // Black piece

            if (board.GetPiece(Square.At(currentSquare.Row + 1, currentSquare.Col)) != null)
            {
                return Enumerable.Empty<Square>();
            }

            if (HasMoved)
            {
                return new List<Square>
                    {new Square(currentSquare.Row + 1, currentSquare.Col)};
            }

            if (board.GetPiece(Square.At(currentSquare.Row + 2, currentSquare.Col)) != null)
            {
                return Enumerable.Empty<Square>();
            }

            return new List<Square>
            {
                new Square(currentSquare.Row + 1, currentSquare.Col),
                new Square(currentSquare.Row + 2, currentSquare.Col)
            };
        }
          
    }
}