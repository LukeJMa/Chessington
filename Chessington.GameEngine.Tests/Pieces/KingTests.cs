﻿using System.Collections.Generic;
using Chessington.GameEngine.Pieces;
using FluentAssertions;
using NUnit.Framework;

namespace Chessington.GameEngine.Tests.Pieces
{
    [TestFixture]
    public class KingTests
    {
        [Test]
        public void KingsCanMoveToAdjacentSquares()
        {
            var board = new Board();
            var king = new King(Player.White);
            board.AddPiece(Square.At(4, 4), king);

            var moves = king.GetAvailableMoves(board);

            var expectedMoves = new List<Square>
            {
                Square.At(3, 3),
                Square.At(3, 4),
                Square.At(3, 5),
                Square.At(4, 3),
                Square.At(4, 5),
                Square.At(5, 3),
                Square.At(5, 4),
                Square.At(5, 5)
            };

            moves.ShouldAllBeEquivalentTo(expectedMoves);
        }

        [Test]
        public void Kings_CannotLeaveTheBoard()
        {
            var board = new Board();
            var king = new King(Player.White);
            board.AddPiece(Square.At(0, 0), king);

            var moves = king.GetAvailableMoves(board);

            var expectedMoves = new List<Square>
            {
                Square.At(1, 0),
                Square.At(1, 1),
                Square.At(0, 1)
            };

            moves.ShouldAllBeEquivalentTo(expectedMoves);
        }

        [Test]
        public void Kings_CanTakeOpposingPieces()
        {
            var board = new Board();
            var king = new King(Player.White);
            board.AddPiece(Square.At(4, 4), king);
            var pawn = new Pawn(Player.Black);
            board.AddPiece(Square.At(4, 5), pawn);

            var moves = king.GetAvailableMoves(board);
            moves.Should().Contain(Square.At(4, 5));
        }

        [Test]
        public void Kings_CannotTakeFriendlyPieces()
        {
            var board = new Board();
            var king = new King(Player.White);
            board.AddPiece(Square.At(4, 4), king);
            var pawn = new Pawn(Player.White);
            board.AddPiece(Square.At(4, 5), pawn);

            var moves = king.GetAvailableMoves(board);
            moves.Should().NotContain(Square.At(4, 5));
        }

        [Test]
        public void WhiteKings_CanCastle_EitherSide_InEmptyRow()
        {
            var board = new Board();

            var king = new King(Player.White);
            board.AddPiece(Square.At(7, 4), king);

            var leftRook = new Rook(Player.White);
            board.AddPiece(Square.At(7,0),leftRook);

            var rightRook = new Rook(Player.White);
            board.AddPiece(Square.At(7,7),rightRook );

            var moves = king.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(7, 2));
            moves.Should().Contain(Square.At(7, 6));
        }

        [Test]
        public void BlackKings_CanCastle_EitherSide_InEmptyRow()
        {
            var board = new Board();

            var king = new King(Player.Black);
            board.AddPiece(Square.At(0, 4), king);

            var leftRook = new Rook(Player.Black);
            board.AddPiece(Square.At(0, 0), leftRook);

            var rightRook = new Rook(Player.Black);
            board.AddPiece(Square.At(0, 7), rightRook);

            var moves = king.GetAvailableMoves(board);

            moves.Should().Contain(Square.At(0, 2));
            moves.Should().Contain(Square.At(0, 6));
        }

        [Test]
        public void WhiteKings_CannotCastle_PastObstruction()
        {
            var board = new Board();

            var king = new King(Player.White);
            board.AddPiece(Square.At(7, 4), king);

            var leftRook = new Rook(Player.White);
            board.AddPiece(Square.At(7, 0), leftRook);

            var rightRook = new Rook(Player.White);
            board.AddPiece(Square.At(7, 7), rightRook);

            var whiteObstruction = new Bishop(Player.White);
            board.AddPiece(Square.At(7, 1), whiteObstruction);

            var blackObstruction = new Bishop(Player.Black);
            board.AddPiece(Square.At(7, 5), blackObstruction);

            var moves = king.GetAvailableMoves(board);

            var disallowedMoves = new List<Square>
            {
                Square.At(7,1),
                Square.At(7,2),
                Square.At(7,6)
            };

            moves.Should().NotIntersectWith(disallowedMoves);
        }

        [Test]
        public void BlackKings_CannotCastle_PastObstruction()
        {
            var board = new Board();

            var king = new King(Player.Black);
            board.AddPiece(Square.At(0, 4), king);

            var leftRook = new Rook(Player.Black);
            board.AddPiece(Square.At(0, 0), leftRook);

            var rightRook = new Rook(Player.Black);
            board.AddPiece(Square.At(0, 7), rightRook);

            var whiteObstruction = new Bishop(Player.White);
            board.AddPiece(Square.At(0,1),whiteObstruction);

            var blackObstruction = new Bishop(Player.Black);
            board.AddPiece(Square.At(0, 5), blackObstruction);

            var moves = king.GetAvailableMoves(board);

            var disallowedMoves = new List<Square>
            {
                Square.At(0,0),
                Square.At(0,1),
                Square.At(0,2),
                Square.At(0,5),
                Square.At(0,6)
            };

            moves.Should().NotIntersectWith(disallowedMoves);
        }
    }
}