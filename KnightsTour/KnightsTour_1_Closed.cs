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
        private CoordFactory cf = null;
        private SquareFactory sf = null;
        private BoardFactory bf = null;
        private AxisFactory af = null;
        private Range2DFactory rf = null;
        private QuadrantFactory qf = null;


        private Square _startLocation = new();
        private Coord _lastSquare = new();
        private Board _boardGrid = new();

        private List<Quadrant> _quadrants = new();

        //private List<Coord> KnightMoves = new();
        //private int[,] KnightMovesArray = { { 2, 1 }, { 1, 2 }, { -1, 2 }, { -2, 1 }, { -2, -1 }, { -1, -2 }, { 1, -2 }, { 2, -1 } };

        public KnightsTour_1_Closed(int boardSize = 8, int startX = 0, int startY = 0)
        {
            Random r = new(55);
            cf = new();
            sf = new(cf);           
            af = new();
            rf = new(af);
            qf = new(rf,af);
            bf = new(sf,qf, r);
            _boardGrid = bf.GetBoard(boardSize, startX, startY);          
        }



        public void FindKT()
        {
            _boardGrid.SetGrid(-1);
            _boardGrid.SetCurrent(_boardGrid.StartLocation,0);
            //_startLocation = _boardGrid.StartLocation;
            //_boardGrid.SetMoveOrder(0); //start is visited
            //recursively try all possible legal moves. Backtrack on dead end solutions.
            if (!solveKTUtil(_boardGrid, 1))
            {
                Console.WriteLine("No solution found for {0}", _boardGrid.StartLocation.ToString());
            }
            else
            {
                _boardGrid.PrintBoard();
                Console.WriteLine("Ending_lastSquare {0}", _lastSquare.MyToString());
                Console.WriteLine("Total profit: {0:N2}", _boardGrid.CalcProfit());
                //if (_isClosingSquare(_lastSquare))
                //    Console.WriteLine("Closed tour");
                //else
                //    Console.WriteLine("Open tour");
                Console.WriteLine("Total attempted moves {0}", attemptedMoves);
            }
        }


        private bool solveKTUtil(Board board, int moveCount)
        {
            attemptedMoves++;
            if (attemptedMoves % 1000000 == 0)
                Console.WriteLine($"Attempted {attemptedMoves} moves"); //update the user on progress every 1 million moves
            //Coord next_move; //location for the next move in the recursion.
            //check to see if we have solved the game.

            if (board.isClosingSquare() && moveCount > 3)
            {
                _lastSquare = board.GetCurrentLocation();
                return true;
            }

            if (moveCount == board.TotalSquares)
            {
                _lastSquare = board.GetCurrentLocation();
                return true;
            }

            if (moveCount == board.TotalSquares - 1) //last move
                return board.isClosingSquare();


            //cycle through all of the possible next moves for the knight.
            Square currentSquare = board.CopyCurrentSquare();
            foreach (Coord move in currentSquare.CopyMoves())
            {
                if (!board.GetSquareByPosition(move).IsVisited)
                {
                    board.SetCurrent(move,moveCount);
                    if (solveKTUtil(board, moveCount + 1))
                        return true;
                    else
                        board.RollBack(currentSquare);
                }
            }

            //for (int k = 0; k < 8; k++)
            //{
            //    next_move = square.Add(KnightMoves[k]);

            //    if (_boardGrid.safeSquare(next_move))
            //    {
            //        _boardGrid.SetMoveOrder(next_move, moveCount);
            //        if (solveKTUtil(next_move, moveCount + 1))
            //            return true;
            //        else
            //            _boardGrid.SetMoveOrder(next_move,-1);
            //    }
            //}
            return false;
        }

        public void PrintMoves()
        {
            foreach (var item in _boardGrid.Grid)
            {
                item.PrintMoves();
            }
        }

        //public void TestLandingSquare()
        //{
        //    List<Coord> t1 = LandingSquares(sf.GetNewCoord(4,4));
        //    foreach (Coord item in t1)
        //        Console.WriteLine(item.MyToString());
        //}

        //private List<Coord> LandingSquares(Coord startSquare)
        //{
        //    List<Coord> moves = new();

        //    for (int k = 0; k < 8; k++)
        //    {
        //        Coord nextSq = startSquare.Add(KnightMoves[k]);
        //        if (_boardGrid.validSquare(nextSq))
        //            moves.Add(nextSq);
        //    }
        //    return moves;
        //}
        //private bool _isClosingSquare(Coord candidate)
        //{
        //    foreach (var square in LandingSquares(_startSquare))
        //    {
        //        if (square.IsEqual(candidate))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}

