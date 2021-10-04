using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour.Models
{
    class Board
    {
        public int[,] Grid { get; set; }
        public int BoardSize { get; set; } = 8;
        public int TotalSquares { get; set; } = 64;
    }

    class BoardFactory
    {
        public Board GetBoard(int size)
        {
            return new Board()
            {
                Grid = Init2DArray(size),
                BoardSize = size,
                TotalSquares = size * size
            };
        }

        private int[,] Init2DArray(int size)
        {
            var Grid = new int[size, size];

            //initialize all squares to not visited.
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //set initial value to -1. not visited status
                    Grid[i, j] = -1;
                }
            }
            return Grid;
        }
    }

    static partial class Extensions
    {
        public static void PrintBoard(this Board board)
        {
            for (int i = 0; i < board.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < board.Grid.GetLength(1); j++)
                {
                    string val = board.Grid[i, j].ToString("00");
                    if (val == "-01") val = "  ";
                    Console.Write(val + " ");
                }
                Console.WriteLine();
            }
        }

        public static void SetGrid(this Board board,int value)
        {
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    board.Grid[i, j] = value;
                }
            }
        }
        public static void SetValue(this Board board, Coord location, int value)
        {
            board.Grid[location.X, location.Y] = value;
        }

        public static Coord LastSquare(this Board board)
        {
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    if (board.Grid[i, j] == -1)
                        return new Coord() { X = i, Y = j };
                }
            }
            return new Coord() { X = -1, Y = -1 };
        }

        public static bool validSquare(this Board board, Coord sq) => (sq.X >= 0 && sq.X < board.BoardSize && sq.Y >= 0 && sq.Y < board.BoardSize);
        public static bool safeSquare(this Board board, Coord sq) => (board.validSquare(sq) && board.Grid[sq.X, sq.Y] == -1);

    }
}
