using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);
            
            // right
            for (var i = 1; currentSquare.Row + i < 8; i++)
            {
                if (board.GetPiece(Square.At(currentSquare.Row + i, currentSquare.Col)) == null)
                {
                    availableMoves.Add(Square.At(currentSquare.Row + i, currentSquare.Col));
                }
                else if (board.GetPiece(Square.At(currentSquare.Row+i, currentSquare.Col)).Player!=this.Player)
                {
                    availableMoves.Add(Square.At(currentSquare.Row + i, currentSquare.Col));
                    break;
                }
                else
                {
                    break;
                }

            }

            // left
            for (var i = 1; currentSquare.Row - i >=0; i++)
            {
                if (board.GetPiece(Square.At(currentSquare.Row - i, currentSquare.Col)) == null)
                {
                    availableMoves.Add(Square.At(currentSquare.Row - i, currentSquare.Col));
                }
                else if (board.GetPiece(Square.At(currentSquare.Row - i, currentSquare.Col)).Player != this.Player)
                {
                    availableMoves.Add(Square.At(currentSquare.Row - i, currentSquare.Col));
                    break;
                }
                else
                {
                    break;
                }

            }

            // up
            for (var i = 1; currentSquare.Col + i < 8; i++)
            {
                if (board.GetPiece(Square.At(currentSquare.Row , currentSquare.Col+i)) == null)
                {
                    availableMoves.Add(Square.At(currentSquare.Row , currentSquare.Col+i));
                }
                else if (board.GetPiece(Square.At(currentSquare.Row , currentSquare.Col+i)).Player != this.Player)
                {
                    availableMoves.Add(Square.At(currentSquare.Row , currentSquare.Col+i));
                    break;
                }
                else
                {
                    break;
                }

            }

            // down
            for (var i = 1; currentSquare.Col - i>=0; i++)
            {
                if (board.GetPiece(Square.At(currentSquare.Row, currentSquare.Col - i)) == null)
                {
                    availableMoves.Add(Square.At(currentSquare.Row, currentSquare.Col - i));
                }
                else if (board.GetPiece(Square.At(currentSquare.Row, currentSquare.Col - i)).Player != this.Player)
                {
                    availableMoves.Add(Square.At(currentSquare.Row, currentSquare.Col - i));
                    break;
                }
                else
                {
                    break;
                }

            }

            //Get rid of our starting location.
            availableMoves.RemoveAll(s => s == Square.At(currentSquare.Row, currentSquare.Col));

            return availableMoves;

        }
    }
}