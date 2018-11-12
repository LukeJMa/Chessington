using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);

            //Checking the backwards diagonal, i.e. 0,0 1,1, 2,2
            for (var i = 0; i < 8; i++)
                availableMoves.Add(Square.At(i, i));

            //Checking the forwards diagonal i.e. 5,3 6,2 7,1
            for (var i = 1; i < 8; i++)
                availableMoves.Add(Square.At(i, 8 - i));

            //Get rid of our starting location.
            availableMoves.RemoveAll(s => s == Square.At(currentSquare.Row, currentSquare.Col));

            return availableMoves;
        }
    }
}