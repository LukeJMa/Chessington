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
                if (HasMoved)
                {
                    return (IEnumerable<Square>) new List<Square>
                        {new Square(currentSquare.Row - 1, currentSquare.Col)};
                }
                
                return (IEnumerable<Square>) new List<Square>
                {
                    new Square(currentSquare.Row - 1, currentSquare.Col),
                    new Square(currentSquare.Row - 2, currentSquare.Col)
                };
            }

            // Black piece
            if (HasMoved)
            {
                return (IEnumerable<Square>)new List<Square>
                    {new Square(currentSquare.Row + 1, currentSquare.Col)};
            }

            return (IEnumerable<Square>)new List<Square>
            {
                new Square(currentSquare.Row + 1, currentSquare.Col),
                new Square(currentSquare.Row + 2, currentSquare.Col)
            };




        }
           
            

        
    }
}