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
                if (currentSquare.Row-1<0)
                {
                    return Enumerable.Empty<Square>();
                }

                if (board.GetPiece(Square.At(currentSquare.Row - 1, currentSquare.Col)) != null)
                {
                    return Enumerable.Empty<Square>();
                }

                if (HasMoved)
                {
                        return new List<Square>
                        {new Square(currentSquare.Row - 1, currentSquare.Col)};
                }

                if (currentSquare.Row -2<0 || board.GetPiece(Square.At(currentSquare.Row - 2, currentSquare.Col)) != null)
                {
                    return new List<Square> {new Square(currentSquare.Row - 1, currentSquare.Col)};
                }

                return new List<Square>
                {
                    new Square(currentSquare.Row - 1, currentSquare.Col),
                    new Square(currentSquare.Row - 2, currentSquare.Col)
                };

            }

            // Black piece

            if (currentSquare.Row + 1 > 7)
            {
                return Enumerable.Empty<Square>();
            }

            if (board.GetPiece(Square.At(currentSquare.Row + 1, currentSquare.Col)) != null)
            {
                return Enumerable.Empty<Square>();
            }

            if (HasMoved)
            {
                if (currentSquare.Row+1<8)
                {
                    return new List<Square>
                    {new Square(currentSquare.Row + 1, currentSquare.Col)};
                }
                return Enumerable.Empty<Square>();
            }

            if (currentSquare.Row + 2>7 || board.GetPiece(Square.At(currentSquare.Row + 2, currentSquare.Col)) != null)
            {
                return new List<Square> {new Square(currentSquare.Row + 1, currentSquare.Col)};
            }

            return new List<Square>
            {
                new Square(currentSquare.Row + 1, currentSquare.Col),
                new Square(currentSquare.Row + 2, currentSquare.Col)
            };
        }
          
    }
}