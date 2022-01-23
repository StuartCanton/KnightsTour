using KnightsTour.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour
{
    internal class CityBackTrack
    {
        private int NUM_OF_CITIES = 200;
        
        private int attemptedMoves = 0;
        private int _startLocation = 1;
        private int[] _visited;
        private int[,] _blankArr;
        private int[,] _mockAllJoined;


        public CityBackTrack()
        {
            _blankArr = new int[NUM_OF_CITIES, NUM_OF_CITIES];
            //fill with 1's
            _mockAllJoined = Fill2DArray(_blankArr, 1);
            Print2DArray(_mockAllJoined);
        }

        public void FindTour()
        {
            //for (int i = 0; i < 244; i++)
            //{
            //    if (!FindTourFrom(i)) continue;
            //    else return;
            //}
            //FindTourFrom(6);
            
        }



        public bool FindTourFrom(int start)
        {
            Console.WriteLine("Find World Tour");
            Console.WriteLine($"{new string('*',30)}");
            Console.WriteLine(new string('*',30));

            
            //int[] visited = new int[244];
            // _boardGrid.SetGrid(-1);
            var adjacency = Fill2DArray(_blankArr, -1);


            //_boardGrid.SetCurrent(_boardGrid.StartLocation, 0);
            _startLocation = start;
            //_boardGrid.SetMoveOrder(0); //start is visited
            _visited = new int[NUM_OF_CITIES];
            _visited[_startLocation] = 1;
            //recursively try all possible legal moves. Backtrack on dead end solutions.

            if (!solveTourUtil(adjacency, _startLocation, 1))
            {
                Console.WriteLine("No solution found for {0}", _startLocation.ToString());
                return false;
            }
            else
            {
                // _boardGrid.PrintBoard();
                Print2DArray(adjacency);


                //Console.WriteLine("Ending_lastSquare {0}", _lastSquare.MyToString());
                //Console.WriteLine("Total profit: {0:N2}", _boardGrid.CalcProfit());
                //if (_isClosingSquare(_lastSquare))
                //    Console.WriteLine("Closed tour");
                //else
                //    Console.WriteLine("Open tour");
                Console.WriteLine("Total attempted moves {0}", attemptedMoves);
                return true;
            }
        }


        private bool solveTourUtil(int[,] globe,int city, int moveCount)
        {
            attemptedMoves++;
            if (attemptedMoves % 1000000 == 0)
                Console.WriteLine($"Attempted {attemptedMoves} moves"); //update the user on progress every 1 million moves
            //Coord next_move; //location for the next move in the recursion.
            //check to see if we have solved the game.


            if (moveCount == NUM_OF_CITIES)
            {
                return true;
            }
            var connections = getConnections(city);
            //cycle through all of the possible next moves for the tour.
            //int currentSquare = board.CopyCurrentSquare();
            foreach (int move in connections)
            {
                if (_visited[move] == 0 && connections[move] == 1)
                {
                    globe[city, move] = moveCount;
                    if (solveTourUtil(globe, move, moveCount + 1))
                        return true;
                    else
                        globe[city, move] = -1;
                    moveCount--;
                }
            }
            return false;
        }


        int[] getConnections(int city)
        {
            var result = new int[NUM_OF_CITIES];
            for (int i = 0;i < result.Length; i++)
            {
                //result[i] = CityAdjacencyMatrix.c_200[city, i];
                result[i] = _mockAllJoined[city, i];
            }
            return result;
        }

        private int[,] Fill2DArray(int[,] arr, int value)
        {
            var x = arr.GetLength(0);
            var y = arr.GetLength(1);
            var result = new int[x, y];
            for (int i = 0; i < x; i++)
                for (int j = 0; j < y; j++)
                    result[i, j] = value;
            return result;
                
        }
        private void Print2DArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write($"{i.ToString("000")}:");
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i, j]}");
                }
                Console.WriteLine();
            }
        }
    }
}
