using System.Collections.Generic;

namespace Chessington.GameEngine.Pieces
{
    public static class MovementChecker
    {
        public static List<Square> CheckLateralMovement(Board board, Piece piece)
        {
            var currentSquare = board.FindPiece(piece);
            var availableMoves = new List<Square>();

            // right
            for (var i = 1; currentSquare.Row + i < 8; i++)
            {
                if (board.GetPiece(Square.At(currentSquare.Row + i, currentSquare.Col)) == null)
                {
                    availableMoves.Add(Square.At(currentSquare.Row + i, currentSquare.Col));
                }
                else if (board.GetPiece(Square.At(currentSquare.Row + i, currentSquare.Col)).Player != piece.Player)
                {
                    availableMoves.Add(Square.At(currentSquare.Row + i, currentSquare.Col));
                    break;
                }
                else
                {
                    break;
                }

            }

            // left
            for (var i = 1; currentSquare.Row - i >= 0; i++)
            {
                if (board.GetPiece(Square.At(currentSquare.Row - i, currentSquare.Col)) == null)
                {
                    availableMoves.Add(Square.At(currentSquare.Row - i, currentSquare.Col));
                }
                else if (board.GetPiece(Square.At(currentSquare.Row - i, currentSquare.Col)).Player != piece.Player)
                {
                    availableMoves.Add(Square.At(currentSquare.Row - i, currentSquare.Col));
                    break;
                }
                else
                {
                    break;
                }

            }

            // up
            for (var i = 1; currentSquare.Col + i < 8; i++)
            {
                if (board.GetPiece(Square.At(currentSquare.Row, currentSquare.Col + i)) == null)
                {
                    availableMoves.Add(Square.At(currentSquare.Row, currentSquare.Col + i));
                }
                else if (board.GetPiece(Square.At(currentSquare.Row, currentSquare.Col + i)).Player != piece.Player)
                {
                    availableMoves.Add(Square.At(currentSquare.Row, currentSquare.Col + i));
                    break;
                }
                else
                {
                    break;
                }

            }

            // down
            for (var i = 1; currentSquare.Col - i >= 0; i++)
            {
                if (board.GetPiece(Square.At(currentSquare.Row, currentSquare.Col - i)) == null)
                {
                    availableMoves.Add(Square.At(currentSquare.Row, currentSquare.Col - i));
                }
                else if (board.GetPiece(Square.At(currentSquare.Row, currentSquare.Col - i)).Player != piece.Player)
                {
                    availableMoves.Add(Square.At(currentSquare.Row, currentSquare.Col - i));
                    break;
                }
                else
                {
                    break;
                }

            }

            availableMoves.RemoveAll(s => s == Square.At(currentSquare.Row, currentSquare.Col));

            return availableMoves;

        }

        public static List<Square> CheckDiagonalMovement(Board board, Piece piece)
        {
            var currentSquare = board.FindPiece(piece);
            var availableMoves = new List<Square>();

            // right-up
            for (var i = 1; currentSquare.Row + i <8 && currentSquare.Col+i < 8; i++)
            {
                    if (board.GetPiece(Square.At(currentSquare.Row + i, currentSquare.Col+i)) == null)
                    {
                        availableMoves.Add(Square.At(currentSquare.Row + i, currentSquare.Col+i));
                    }
                    else if (board.GetPiece(Square.At(currentSquare.Row + i, currentSquare.Col+i)).Player != piece.Player)
                    {
                        availableMoves.Add(Square.At(currentSquare.Row + i, currentSquare.Col+i));
                        break;
                    }
                    else
                    {
                        break;
                }

                
            }

            // right-down
            for (var i = 1; currentSquare.Row + i < 8 && currentSquare.Col - i >= 0; i++)
            {
                if (board.GetPiece(Square.At(currentSquare.Row + i, currentSquare.Col - i)) == null)
                {
                    availableMoves.Add(Square.At(currentSquare.Row + i, currentSquare.Col - i));
                }
                else if (board.GetPiece(Square.At(currentSquare.Row + i, currentSquare.Col - i)).Player != piece.Player)
                {
                    availableMoves.Add(Square.At(currentSquare.Row + i, currentSquare.Col - i));
                    break;
                }
                else
                {
                    break;
                }


            }

            // left-up
            for (var i = 1; currentSquare.Row - i >= 0 && currentSquare.Col + i <8; i++)
            {
                if (board.GetPiece(Square.At(currentSquare.Row - i, currentSquare.Col + i)) == null)
                {
                    availableMoves.Add(Square.At(currentSquare.Row - i, currentSquare.Col + i));
                }
                else if (board.GetPiece(Square.At(currentSquare.Row - i, currentSquare.Col + i)).Player != piece.Player)
                {
                    availableMoves.Add(Square.At(currentSquare.Row - i, currentSquare.Col + i));
                    break;
                }
                else
                {
                    break;
                }


            }

            // left-down
            for (var i = 1; currentSquare.Row -i >= 0 && currentSquare.Col - i >= 0; i++)
            {
                if (board.GetPiece(Square.At(currentSquare.Row - i, currentSquare.Col - i)) == null)
                {
                    availableMoves.Add(Square.At(currentSquare.Row - i, currentSquare.Col - i));
                }
                else if (board.GetPiece(Square.At(currentSquare.Row - i, currentSquare.Col - i)).Player != piece.Player)
                {
                    availableMoves.Add(Square.At(currentSquare.Row - i, currentSquare.Col - i));
                    break;
                }
                else
                {
                    break;
                }


            }

            availableMoves.RemoveAll(s => s == Square.At(currentSquare.Row, currentSquare.Col));

            return availableMoves;
        }
    }
}