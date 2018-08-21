using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacteraInterviewQuestion_TicTacToe;

namespace TicTacToeUnitTests
{
    [TestClass]
    public class TicTacToeUnitTests
    {
        [TestMethod]
        public void TestVerticalWin()
        {
            var board = new TicTacToe(rows: 3);

            bool result = default(bool);

            result = board.Move(point: new Point(row: 1, column: 1), player: Player.X);
            Assert.IsFalse(result);

            result = board.Move(point: new Point(row: 2, column: 1), player: Player.X);
            Assert.IsFalse(result);

            result = board.Move(point: new Point(row: 0, column: 1), player: Player.X);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestHorizontalWin()
        {
            var board = new TicTacToe(rows: 3);

            bool result = default(bool);

            result = board.Move(point: new Point(row: 2, column: 2), player: Player.X);
            Assert.IsFalse(result);

            result = board.Move(point: new Point(row: 2, column: 1), player: Player.X);
            Assert.IsFalse(result);

            result = board.Move(point: new Point(row: 2, column: 0), player: Player.X);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestHorizontalNoneWin()
        {
            var board = new TicTacToe(rows: 3);

            bool result = default(bool);

            result = board.Move(point: new Point(row: 2, column: 2), player: Player.X);
            Assert.IsFalse(result);

            result = board.Move(point: new Point(row: 2, column: 1), player: Player.O);
            Assert.IsFalse(result);

            result = board.Move(point: new Point(row: 2, column: 0), player: Player.X);
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void TestDiagonalWinLeftToRight()
        {
            var board = new TicTacToe(rows: 3);

            bool result = default(bool);

            result = board.Move(point: new Point(row: 0, column: 0), player: Player.X);
            Assert.IsFalse(result);

            result = board.Move(point: new Point(row: 2, column: 2), player: Player.X);
            Assert.IsFalse(result);

            result = board.Move(point: new Point(row: 1, column: 1), player: Player.X);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestDiagonalWinRightToLeft()
        {
            var board = new TicTacToe(rows: 3);

            bool result = default(bool);

            result = board.Move(point: new Point(row: 0, column: 2), player: Player.X);
            Assert.IsFalse(result);

            result = board.Move(point: new Point(row: 2, column: 0), player: Player.X);
            Assert.IsFalse(result);

            result = board.Move(point: new Point(row: 1, column: 1), player: Player.X);
            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestIllegalBoardSize()
        {
            var board = new TicTacToe(rows: 0);
        }

        [TestMethod]
        [ExpectedException(typeof(MoveOutsideBoardException))]
        public void TestIllegalMoveOutsideBoard()
        {
            var board = new TicTacToe(rows: 3);

            board.Move(point: new Point(row: 4, column: 4), player: Player.X);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIllegalMovePreexistingMoveAtSameSpotOnBoard()
        {
            var board = new TicTacToe(rows: 3);

            board.Move(point: new Point(row: 1, column: 1), player: Player.X);
            board.Move(point: new Point(row: 1, column: 1), player: Player.O);
        }

        [TestMethod]
        public void TestResettingBoard()
        {
            // There isn't a great test for this.
            // The individual spots on the board are not exposed outside
            // its class. One approach, fill up all spots, reset board,
            // attempt to refill up all spots. If a spot isn't cleared by
            // the call to ResetBoard() then an Exception should be thrown.
            // This assumes that that Exception mechanism works.
            // We have a unit test for the mechanism elsewhere in this class.
            // So it's possible for this test to fail but show as passing
            // if that Exception mechanism isn't working.

            var board = new TicTacToe(rows: 3);

            board.Move(point: new Point(row: 0, column: 0), player: Player.X);      //  X   O   X
            board.Move(point: new Point(row: 0, column: 1), player: Player.O);
            board.Move(point: new Point(row: 0, column: 2), player: Player.X);
  
            // Validate the Exception Mechanism. Again, this is far from an idea or preferred test practice
            // as this is testing different functionality than the purpose of this specific test's target: ResetBoard()
            // If the Exception Mechanism isn't working, we'd expect to see its test as well as this test to fail.
            Assert.ThrowsException<ArgumentException>(() => board.Move(point: new Point(row: 0, column: 0), player: Player.X));
            Assert.ThrowsException<ArgumentException>(() => board.Move(point: new Point(row: 0, column: 1), player: Player.O));
            Assert.ThrowsException<ArgumentException>(() => board.Move(point: new Point(row: 0, column: 2), player: Player.X));

            board.ResetBoard();

            board.Move(point: new Point(row: 0, column: 0), player: Player.X);      //  X   O   X
            board.Move(point: new Point(row: 0, column: 1), player: Player.O);
            board.Move(point: new Point(row: 0, column: 2), player: Player.X);
        }

    }
}
