using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class King : Piece
    {
        public King(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableMoves = new List<Square>();
            var currentSquare = board.FindPiece(this);

            for (var i=-1; i<=1;i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    availableMoves.Add(Square.At(currentSquare.Row+i,currentSquare.Col+j));
                }
            }
    
            availableMoves.Remove(Square.At(currentSquare.Row, currentSquare.Col));
            return availableMoves;
        }
    }
}