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
            var lastMovedSquare = board.FindPiece(board.LastMoved);

            // White piece
            if (Player == Player.White)
            {
                var availableWhiteMoves = new List<Square>();

                if (currentSquare.Row-1<0 ) 
                {
                    return availableWhiteMoves;
                }

                // En passant movement
                if (board.LastMoved is Pawn
                    && board.LastMoved.Player != Player
                    && board.LastMoved.MoveCount==1
                    && lastMovedSquare.Row == 3
                    && currentSquare.Row == 3
                )
                {
                    if (lastMovedSquare.Col == currentSquare.Col + 1
                        && board.GetPiece(Square.At(lastMovedSquare.Row - 1, lastMovedSquare.Col)) == null)
                    {
                        availableWhiteMoves.Add(Square.At(lastMovedSquare.Row - 1, lastMovedSquare.Col));
                    }
                    else if (lastMovedSquare.Col == currentSquare.Col - 1
                             && board.GetPiece(Square.At(lastMovedSquare.Row - 1, lastMovedSquare.Col)) == null)
                    {
                        availableWhiteMoves.Add(Square.At(lastMovedSquare.Row - 1, lastMovedSquare.Col));
                    }
                }

                if (currentSquare.Col - 1 >= 0 &&
                    board.GetPiece(Square.At(currentSquare.Row - 1, currentSquare.Col - 1)) != null &&
                    board.GetPiece(Square.At(currentSquare.Row - 1, currentSquare.Col - 1)).Player != Player)
                {
                    availableWhiteMoves.Add(Square.At(currentSquare.Row - 1, currentSquare.Col - 1));
                }

                if (currentSquare.Col + 1 < 8 &&
                    board.GetPiece(Square.At(currentSquare.Row - 1, currentSquare.Col + 1)) != null &&
                    board.GetPiece(Square.At(currentSquare.Row - 1, currentSquare.Col + 1)).Player != Player)
                {
                    availableWhiteMoves.Add(Square.At(currentSquare.Row - 1, currentSquare.Col + 1));
                }

                if (board.GetPiece(Square.At(currentSquare.Row - 1, currentSquare.Col)) != null) 
                {
                    return availableWhiteMoves;
                }

                availableWhiteMoves.Add(new Square(currentSquare.Row - 1, currentSquare.Col));

                if (HasMoved)
                {
                    return availableWhiteMoves;
                }

                if (currentSquare.Row -2<0 || board.GetPiece(Square.At(currentSquare.Row - 2, currentSquare.Col)) != null)
                {
                    return availableWhiteMoves;
                }

                availableWhiteMoves.Add(new Square(currentSquare.Row - 2, currentSquare.Col));
                return availableWhiteMoves;

            }

            // Black piece

            var availableBlackMoves = new List<Square>();

            if (currentSquare.Row + 1 > 7 )
            {
                return availableBlackMoves;
            }

            // En passant movement
            if (board.LastMoved is Pawn
                && board.LastMoved.Player != Player
                && board.LastMoved.MoveCount == 1
                && lastMovedSquare.Row == 4
                && currentSquare.Row == 4
            )
            {
                if (lastMovedSquare.Col == currentSquare.Col + 1
                    && board.GetPiece(Square.At(lastMovedSquare.Row + 1, lastMovedSquare.Col)) == null)
                {
                    availableBlackMoves.Add(Square.At(lastMovedSquare.Row + 1, lastMovedSquare.Col));
                }
                else if (lastMovedSquare.Col == currentSquare.Col - 1
                         && board.GetPiece(Square.At(lastMovedSquare.Row + 1, lastMovedSquare.Col)) == null)
                {
                    availableBlackMoves.Add(Square.At(lastMovedSquare.Row + 1, lastMovedSquare.Col));
                }
            }

            if (currentSquare.Col -1 >=0 &&
                board.GetPiece(Square.At(currentSquare.Row + 1, currentSquare.Col - 1)) != null &&
                board.GetPiece(Square.At(currentSquare.Row + 1, currentSquare.Col - 1)).Player != Player)
            {
                availableBlackMoves.Add(Square.At(currentSquare.Row + 1, currentSquare.Col - 1));
            }

            if (currentSquare.Col + 1 < 8 &&
                board.GetPiece(Square.At(currentSquare.Row + 1, currentSquare.Col + 1)) != null &&
                board.GetPiece(Square.At(currentSquare.Row + 1, currentSquare.Col + 1)).Player != Player)
            {
                availableBlackMoves.Add(Square.At(currentSquare.Row + 1, currentSquare.Col + 1));
            }

            if (board.GetPiece(Square.At(currentSquare.Row + 1, currentSquare.Col)) != null)
            {
                return availableBlackMoves;
            }

            availableBlackMoves.Add(new Square(currentSquare.Row + 1, currentSquare.Col));

            if (HasMoved)
            {
                return availableBlackMoves;
            }

            if (currentSquare.Row + 2>7 || board.GetPiece(Square.At(currentSquare.Row + 2, currentSquare.Col)) != null)
            {
                return availableBlackMoves;
            }

            availableBlackMoves.Add(new Square(currentSquare.Row + 2, currentSquare.Col));
            return availableBlackMoves;
        }

        public override IEnumerable<Square> GetAttackingMoves(Board board)
        {
            var currentSquare = board.FindPiece(this);
            var availableMoves = GetAvailableMoves(board).ToList();
            availableMoves.RemoveAll(square => square.Col ==currentSquare.Col);
            return availableMoves;
        }
    }
}