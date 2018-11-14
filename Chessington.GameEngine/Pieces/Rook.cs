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
            return GetAttackingMoves(board);
        }

        public override IEnumerable<Square> GetAttackingMoves(Board board)
        {
            return CommonAvailableMovementGetter.GetAvailableLateralMovement(board, this);
        }

        
    }
}