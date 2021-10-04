using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour
{
    class KnightsTour_fromShad
    {
        private int _boardSize = 8;
        private int attemptedMoves = 0;
        private int[,] boardGrid = null;

        private int _startX = 0;
        private int _startY = 0;


        private int[] xMove = { 2, 1, -1, -2, -2, -1, 1, 2 };
        private int[] yMove = { 1, 2, 2, 1, -1, -2, -2, -1 };

        public KnightsTour_fromShad(int boardSize = 8)
        {
            _boardSize = boardSize;
            boardGrid = Init2DArray(_boardSize);
        }

        public void FindKT(int startX = 0, int startY = 0)
        {
            boardGrid = Init2DArray(_boardSize);
            _startX = startX;
            _startY = startY;
            boardGrid[_startX, _startY] = 0; //start is visited
            //recursively try all possible legal moves. Backtrack on dead end solutions.
            if (!solveKTUtil(_startX, _startY, 1))
            {
                Console.WriteLine("No solution found for {0} {1}", _startX, _startY);
            }
            else
            {
                printBoard(boardGrid);
                Console.WriteLine("Total attempted moves {0}", attemptedMoves);
            }
        }


        private void printBoard(int[,] boardToPrint)
        {
            for (int i = 0; i < boardToPrint.GetLength(0); i++)
            {
                for (int j = 0; j < boardToPrint.GetLength(1); j++)
                {
                    string val = boardToPrint[i, j].ToString("00");
                    Console.Write(val + " ");
                }
                Console.WriteLine();
            }
        }
        private bool solveKTUtil(int x, int y, int moveCount)
        {
            attemptedMoves++;
            if (attemptedMoves % 1000000 == 0)
                Console.WriteLine($"Attempted {attemptedMoves} moves"); //update the user on progress every 1 million moves
            //int k; //counter for moving through the nextX and nextY arrays
            int next_x, next_y; //location for the next move in the recursion.


            //check to see if we have solved the game.
            if (moveCount == _boardSize * _boardSize) return true;

            //cycle through all of the possible next moves for the knight.
            for (int k = 0; k < 8; k++)
            {
                next_x = x + xMove[k];
                next_y = y + yMove[k];
                if (safeSquare(next_x, next_y))
                {
                    boardGrid[next_x, next_y] = moveCount;
                    if (solveKTUtil(next_x, next_y, moveCount + 1))
                        return true;
                    else
                        boardGrid[next_x, next_y] = -1;


                }
            }
            return false;
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

        private bool safeSquare(int x, int y) => (x >= 0 && x < _boardSize && y >= 0 && y < _boardSize && boardGrid[x, y] == -1);
    }
}
