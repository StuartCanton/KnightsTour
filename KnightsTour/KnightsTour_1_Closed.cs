using System;
using System.Collections.Generic;
using KnightsTour.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour
{
    class KnightsTour_1_Closed
    {

        private int attemptedMoves = 0;
        private SquareFactory sf = new();
        private BoardFactory bf = new();

        private Coord _startSquare = new();
        private Coord _lastSquare = new();
        private Board _boardGrid = new();

        private List<Coord> KnightMoves = new();
        private int[,] KnightMovesArray =
        {
            {2,1},{1,2},{-1,2},{-2,1},{-2,-1},{-1,-2},{1,-2},{2,-1}
        };


        public KnightsTour_1_Closed(int boardSize = 8)
        {
            _boardGrid = bf.GetBoard(boardSize);
            KnightMoves = sf.FromRange(KnightMovesArray);
        }

        public void FindKT(int startX = 0, int startY = 0)
        {
            _boardGrid.SetGrid(-1);
            _startSquare = sf.GetNewCoord(startX, startY);
            _boardGrid.SetValue(_startSquare, 0); //start is visited
            //recursively try all possible legal moves. Backtrack on dead end solutions.
            if (!solveKTUtil(_startSquare, 1))
            {
                Console.WriteLine("No solution found for {0}", _startSquare.ToString());
            }
            else
            {
                _boardGrid.PrintBoard();
                Console.WriteLine("Ending_lastSquare {0}", _lastSquare.MyToString());
                if (_isClosingSquare(_lastSquare))
                    Console.WriteLine("Closed tour");
                else
                    Console.WriteLine("Open tour");
                Console.WriteLine("Total attempted moves {0}", attemptedMoves);
            }
        }

        private bool solveKTUtil(Coord square, int moveCount)
        {
            attemptedMoves++;
            if (attemptedMoves % 1000000 == 0)
                Console.WriteLine($"Attempted {attemptedMoves} moves"); //update the user on progress every 1 million moves
            Coord next_move; //location for the next move in the recursion.

            //check to see if we have solved the game.

            if (_isClosingSquare(square) && moveCount > 3)
            {
                _lastSquare = square;
                return true;
            }

            if (moveCount == _boardGrid.TotalSquares)
            {
                _lastSquare = square;
                return true;
            }

            if (moveCount == _boardGrid.TotalSquares - 1) //last move
            {

                if (_isClosingSquare(_boardGrid.LastSquare()))
                {
                    return true;
                }
                else
                    return false;
            }


            //cycle through all of the possible next moves for the knight.
            for (int k = 0; k < 8; k++)
            {
                next_move = square.Add(KnightMoves[k]);

                if (_boardGrid.safeSquare(next_move))
                {
                    _boardGrid.SetValue(next_move, moveCount);
                    if (solveKTUtil(next_move, moveCount + 1))
                        return true;
                    else
                        _boardGrid.SetValue(next_move,-1);
                }
            }
            return false;
        }

        public void TestLandingSquare()
        {
            List<Coord> t1 = LandingSquares(sf.GetNewCoord(4,4));
            foreach (Coord item in t1)
                Console.WriteLine(item.MyToString());
        }

        private List<Coord> LandingSquares(Coord startSquare)
        {
            List<Coord> moves = new();

            for (int k = 0; k < 8; k++)
            {
                Coord nextSq = startSquare.Add(KnightMoves[k]);
                if (_boardGrid.validSquare(nextSq))
                    moves.Add(nextSq);
            }
            return moves;
        }
        private bool _isClosingSquare(Coord candidate)
        {
            foreach (var square in LandingSquares(_startSquare))
            {
                if (square.IsEqual(candidate))
                {
                    return true;
                }
            }
            return false;
        }
    }
}

