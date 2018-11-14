using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using Chessington.GameEngine.Pieces;

namespace Chessington.GameEngine
{
    public class Board
    {
        private readonly Piece[,] board;
        public Player CurrentPlayer { get; private set; }
        public IList<Piece> CapturedPieces { get; private set; }
        public Piece LastMoved { get; set; }

        public Board()
            : this(Player.White) { }

        public Board(Player currentPlayer, Piece[,] boardState = null)
        {
            board = boardState ?? new Piece[GameSettings.BoardSize, GameSettings.BoardSize]; 
            CurrentPlayer = currentPlayer;
            CapturedPieces = new List<Piece>();
        }

        public void AddPiece(Square square, Piece pawn)
        {
            board[square.Row, square.Col] = pawn;
        }
    
        public Piece GetPiece(Square square)
        {
            return board[square.Row, square.Col];
        }
        
        public Square FindPiece(Piece piece)
        {
            for (var row = 0; row < GameSettings.BoardSize; row++)
                for (var col = 0; col < GameSettings.BoardSize; col++)
                    if (board[row, col] == piece)
                        return Square.At(row, col);

            throw new ArgumentException("The supplied piece is not on the board.", "piece");
        }

        public void MovePiece(Square from, Square to)
        {
            var movingPiece = board[from.Row, from.Col];
            if (movingPiece == null) { return; }

            if (movingPiece.Player != CurrentPlayer)
            {
                throw new ArgumentException("The supplied piece does not belong to the current player.");
            }

            //If the space we're moving to is occupied, we need to mark it as captured.
            if (board[to.Row, to.Col] != null)
            {
                OnPieceCaptured(board[to.Row, to.Col]);
            }

            CheckIfEnPassantMove(from,to);
            CheckIfCastlingMove(from, to);

            //Move the piece and set the 'from' square to be empty.
            board[to.Row, to.Col] = board[from.Row, from.Col];
            board[from.Row, from.Col] = null;

            CurrentPlayer = movingPiece.Player == Player.White ? Player.Black : Player.White;
            OnCurrentPlayerChanged(CurrentPlayer);
        }

        private void CheckIfCastlingMove(Square from, Square to)
        {
            var movingPiece = board[from.Row, from.Col];

            if (movingPiece is King)
            {
                if (to.Col - from.Col == 2)
                {
                    MovePiece(Square.At(from.Row, 7), Square.At(from.Row, 5));
                }
                else if (to.Col - from.Col == -2)
                {
                    MovePiece(Square.At(from.Row,0),Square.At(from.Row,3) );
                }
            }
        }

        private void CheckIfEnPassantMove(Square from, Square to)
        {
            var movingPiece = board[from.Row, from.Col];

            if (LastMoved != null
                && movingPiece is Pawn
                && LastMoved is Pawn
                && LastMoved.Player != movingPiece.Player
                && LastMoved.MoveCount == 1)
            {
                var lastMovedSquare = FindPiece(LastMoved);

                switch (movingPiece.Player)
                {
                    case Player.White when lastMovedSquare.Row == 3 && @from.Row == 3 && to.Row == 2 && to.Col == lastMovedSquare.Col:
                        OnPieceCaptured(LastMoved);
                        board[lastMovedSquare.Row, lastMovedSquare.Col] = null;
                        break;
                    case Player.Black when lastMovedSquare.Row == 4 && @from.Row == 4 && to.Row == 5 && to.Col == lastMovedSquare.Col:
                        OnPieceCaptured(LastMoved);
                        board[lastMovedSquare.Row, lastMovedSquare.Col] = null;
                        break;
                }
            }
        }

        public delegate void PieceCapturedEventHandler(Piece piece);
        
        public event PieceCapturedEventHandler PieceCaptured;

        protected virtual void OnPieceCaptured(Piece piece)
        {
            var handler = PieceCaptured;
            if (handler != null) handler(piece);
        }

        public delegate void CurrentPlayerChangedEventHandler(Player player);

        public event CurrentPlayerChangedEventHandler CurrentPlayerChanged;

        protected virtual void OnCurrentPlayerChanged(Player player)
        {
            var handler = CurrentPlayerChanged;
            if (handler != null) handler(player);
        }

        public bool CheckIfOnBoard(Square square)
        {
            return square.Row >= 0
                   && square.Row < GameSettings.BoardSize
                   && square.Col >= 0
                   && square.Col < GameSettings.BoardSize;
        }

        public IEnumerable<Square> GetSquaresAttackedBy(Player attackingPlayer)
        {
            var attackedSquares = new List<Square>();
            foreach (Piece piece in board)
            {
                var availableMoves = new List<Square>();
                if (piece != null && piece.Player == attackingPlayer)
                {
                    availableMoves = availableMoves.Concat(piece.GetAttackingMoves(this)).ToList();
                    foreach (Square square in availableMoves)
                    {
                        attackedSquares.Add(square);
                    }
                }

                attackedSquares = attackedSquares.Concat(availableMoves).ToList();
            }
            return attackedSquares;
        }
    }

    
}
