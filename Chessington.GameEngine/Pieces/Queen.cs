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
            var availableLateralMoves = MovementChecker.CheckLateralMovement(board, this);
            var availableDiagonalMoves = MovementChecker.CheckDiagonalMovement(board, this);
            
            return availableLateralMoves.Concat(availableDiagonalMoves);
        }
    }
}