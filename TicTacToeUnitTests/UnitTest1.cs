using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PacteraInterviewQuestion_TicTacToe;

namespace TicTacToeUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestVerticalWin()
        {
            int size = 3; // 3x3

            var board = new TicTacToe(size);

            Player p1 = Player.X;
            //Player p2 = Player.O;

            bool result = default(bool);

            result = board.Move(point: new Point(row: 1, column: 1), player: p1);
            Assert.IsFalse(result);

            result = board.Move(point: new Point(row: 2, column: 1), player: p1);
            Assert.IsFalse(result);

            result = board.Move(point: new Point(row: 0, column: 1), player: p1);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestHorizontalWin()
        {
            int size = 3; // 3x3

            var board = new TicTacToe(size);

            Player p1 = Player.X;
            //Player p2 = Player.O;

            bool result = default(bool);

            result = board.Move(point: new Point(row: 2, column: 2), player: p1);
            Assert.IsFalse(result);

            result = board.Move(point: new Point(row: 2, column: 1), player: p1);
            Assert.IsFalse(result);

            result = board.Move(point: new Point(row: 2, column: 0), player: p1);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestHorizontalNoneWin()
        {
            int size = 3; // 3x3

            var board = new TicTacToe(size);

            Player p1 = Player.X;
            Player p2 = Player.O;

            bool result = default(bool);

            result = board.Move(point: new Point(row: 2, column: 2), player: p1);
            Assert.IsFalse(result);

            result = board.Move(point: new Point(row: 2, column: 1), player: p2);
            Assert.IsFalse(result);

            result = board.Move(point: new Point(row: 2, column: 0), player: p1);
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void TestDiagonalWinLeftToRight()
        {
            int size = 3; // 3x3

            var board = new TicTacToe(size);

            Player p1 = Player.X;
            //Player p2 = Player.O;

            bool result = default(bool);

            result = board.Move(point: new Point(row: 0, column: 0), player: p1);
            Assert.IsFalse(result);

            result = board.Move(point: new Point(row: 2, column: 2), player: p1);
            Assert.IsFalse(result);

            result = board.Move(point: new Point(row: 1, column: 1), player: p1);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestDiagonalWinRightToLeft()
        {
            int size = 3; // 3x3

            var board = new TicTacToe(size);

            Player p1 = Player.X;
            //Player p2 = Player.O;

            bool result = default(bool);

            result = board.Move(point: new Point(row: 0, column: 2), player: p1);
            Assert.IsFalse(result);

            result = board.Move(point: new Point(row: 2, column: 0), player: p1);
            Assert.IsFalse(result);

            result = board.Move(point: new Point(row: 1, column: 1), player: p1);
            Assert.IsTrue(result);
        }
    }
}
