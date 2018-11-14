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
            return GetAttackingMoves(board);
        }

        public override IEnumerable<Square> GetAttackingMoves(Board board)
        {
            return CommonAvailableMovementGetter.GetAvailableDiagonalMovement(board, this);
        }
    }
}