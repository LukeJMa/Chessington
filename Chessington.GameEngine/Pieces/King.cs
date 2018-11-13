using System.Collections;
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
                for (var j = -1; j <= 1; j++)
                {
                    if (0<= currentSquare.Row+i && currentSquare.Row +i <8 && 0<= currentSquare.Col + j && currentSquare.Col + j<8)
                    availableMoves.Add(Square.At(currentSquare.Row+i,currentSquare.Col+j));
                }
            }

            var availableCastlingMoves = GetCastlingMoves(board);
            availableMoves=availableMoves.Concat(availableCastlingMoves).ToList();
    
            availableMoves.Remove(Square.At(currentSquare.Row, currentSquare.Col));
            availableMoves.RemoveAll(s => board.GetPiece(s) != null && board.GetPiece(s).Player == Player);

            return availableMoves;
        }

        public IEnumerable<Square> GetCastlingMoves(Board board)
        {
            var availableCastlingMoves = new List<Square>();

            if (!HasMoved)
            {
                // White 
                switch (Player)
                {
                    case Player.White:
                    {
                        var leftRook = board.GetPiece(Square.At(7, 0));
                        var rightRook = board.GetPiece(Square.At(7, 7));

                        if (leftRook != null && !leftRook.HasMoved)
                        {
                            availableCastlingMoves.Add(Square.At(7, 2));
                        }

                        if (rightRook != null && !rightRook.HasMoved)
                        {
                            availableCastlingMoves.Add(Square.At(7, 6));
                        }
                        break;
                    }

                    case Player.Black:
                    {
                        var leftRook = board.GetPiece(Square.At(0, 0));
                        var rightRook = board.GetPiece(Square.At(0, 7));

                        if (leftRook != null && !leftRook.HasMoved)
                        {
                            availableCastlingMoves.Add(Square.At(0, 2));
                        }

                        if (rightRook != null && !rightRook.HasMoved)
                        {
                            availableCastlingMoves.Add(Square.At(0,6));
                        }
                        break;
                    }
                }
            }

            return availableCastlingMoves;
        }
    }
}