using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacteraInterviewQuestion_TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nothing to do here..
        }
    }

    public class TicTacToe
    {
        // The board. Represented by [row, column]  aka [y, x].
        private Player?[,] _board;

        public TicTacToe(int rows)
        {
            _board = new Player?[rows, rows];
        }

        public void ResetBoard() => _board = new Player?[_board.GetLength(0), _board.GetLength(1)];

        public bool Move(Point point, Player player)
        {
            // Validate the spot is within the Tic-Tac-Toe board.
            if (point.Row > _board.GetUpperBound(0) || point.Column > _board.GetUpperBound(1))
            {
                throw new ArgumentOutOfRangeException(message: $"Can't play a spot outside the board! (Row: {point.Row}, Column: {point.Column})", paramName: nameof(point));
            }

            // Validate the spot in the Tic-Tac-Toe board is available (current value is null).
            if (_board[point.Row, point.Column] != null)
            {
                throw new ArgumentException(message: $"Can't play a spot already played! (Row: {point.Row}, Column: {point.Column})", paramName: nameof(point));
            }

            // Place 'X' or 'O' on the board in the spot specificed by the 'point' paramter.
            _board[point.Row, point.Column] = player;


            return IsWinner(point);
        }

        private bool IsWinner(Point point)
        {
            bool notAWinner = false;

            // Check the Row where the point was played for a win.
            for (int col = 0; col < _board.GetLength(1); col++)
            {
                notAWinner = (_board[point.Row, point.Column] != _board[point.Row, col]) || notAWinner;
            }
            if (!notAWinner)
                return true;
            else
                notAWinner = false;

            // Check the Column where the point was played for a win.
            for(int row=0; row < _board.GetLength(0); row++)
            {
                notAWinner = (_board[point.Row, point.Column] != _board[row, point.Column]) || notAWinner;
            }

            if (!notAWinner)
                return true;
            else
                notAWinner = false;

            // Check for a diagonal win. (left to right).. Eg., [0,0] [1,1] [2,2] ... [n,n]
            // Check if we're on the diagonal line from [0,0] to [n,n]
            if (point.Row == point.Column)
            {
                for (int rowAndColumn = 0; rowAndColumn < _board.GetLength(0); rowAndColumn++)
                {
                    notAWinner = (_board[point.Row, point.Column] != _board[rowAndColumn, rowAndColumn]) || notAWinner;
                }

                if (!notAWinner)
                    return true;
                else
                    notAWinner = false;
            }

            // Check for a diagonal win. (left to right).. Eg., [0,n] [1,n-1] [2,n-2] ... [n,0]
            // Check if we're on the diagonal line from [0,n] to [n,0]
            if (point.Row == _board.GetUpperBound(0) - point.Column)
            {
                for (int row = 0; row < _board.GetLength(0); row++)
                {
                    notAWinner = (_board[point.Row, point.Column] != _board[row, _board.GetUpperBound(0) - row]) || notAWinner;
                }

                if (!notAWinner)
                    return true;
                else
                    notAWinner = false;
            }

            // If we didn't find a horizontal, vertical, or diagonal winner then we return false
            // as no winner was found.
            return false;
        }


    }

    public enum Player { X, O };

    public struct Point
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Point (int row, int column)
        {
            Row = row;
            Column = column;
        }

    }

}