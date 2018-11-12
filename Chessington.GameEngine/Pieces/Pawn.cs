using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Chessington.GameEngine.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Player player) 
            : base(player) { }

        public override IEnumerable<Square> GetAvailableMoves(Board board)
        {
            if (Player == Player.White)
            {
                return (IEnumerable<Square>) new List<Square> {new Square(6,0)};
            }

            return (IEnumerable<Square>)new List<Square> { new Square(2, 0) };

        }
    }
}