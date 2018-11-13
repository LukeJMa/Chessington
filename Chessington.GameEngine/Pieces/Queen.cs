using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Queen : Piece
    {
        public Queen(Player player)
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            var availableLateralMoves = CommonAvailableMovementGetter.GetAvailableLateralMovement(board, this);
            var availableDiagonalMoves = CommonAvailableMovementGetter.GetAvailableDiagonalMovement(board, this);
            
            return availableLateralMoves.Concat(availableDiagonalMoves);
        }
    }
}