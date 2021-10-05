using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour.Models
{
    class Board
    {
        public Square[,] Grid { get; set; } = null;
        public int BoardSize { get; set; } = 8;
        public int TotalSquares { get; set; } = 64;
        public Coord StartLocation { get; set; } = new();
        public List<Coord> ClosingCoords { get; set; } = null;
        public Coord CurrentLocation { get; set; } = new();
    }

    class BoardFactory
    {
        private readonly SquareFactory _squareFactory;
        private readonly Random _random;

        public BoardFactory(SquareFactory squareFactory, Random random)
        {
            _squareFactory = squareFactory;
            _random = random;
        }

        public Board GetBoard(int size, int startX, int startY)
        {
            return GetBoard(size, new Coord() { X = startX, Y = startY });
        }

        public Board GetBoard(int size, Coord startLocation)
        {
            Board result = new Board()
            {
                Grid = Init2DArray(size),
                BoardSize = size,
                TotalSquares = size * size,
                StartLocation = startLocation,
                ClosingCoords = CalcClosingSquares(startLocation, size)
            };

            result.ValidateSquares();
            result.SetCurrent(startLocation,0);
            return result;

        }

        private List<Coord> CalcClosingSquares(Coord startCoord, int size)
        {
            var start = _squareFactory.GetNewSquare(startCoord, 0);
            return start.OutgoingMoves.Where(e => validCoord(e, size)).ToList();
        }
        public bool validCoord(Coord coord, int size) => (coord.X >= 0 && coord.X < size && coord.Y >= 0 && coord.Y < size);

        private Square[,] Init2DArray(int size)
        {
            var Grid = new Square[size, size];

            //initialize all squares to not visited.
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    //set initial values
                    Grid[i, j] = _squareFactory.GetNewSquare(i, j, _random.Next(100));
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
                    string val = board.Grid[i, j].MoveOrder.ToString("00");
                    if (val == "-01") val = "  ";
                    Console.Write(val + " ");
                }
                Console.WriteLine();
            }
        }

        public static void SetGrid(this Board board, int moveOrder)
        {
            for (int i = 0; i < board.BoardSize; i++)
            {
                for (int j = 0; j < board.BoardSize; j++)
                {
                    board.SetMoveOrder(i, j, moveOrder);
                }
            }
        }


        public static void RollBack(this Board board, Square copyOfPreviousSquare)
        {
            foreach (Square square in board.Grid)
            {
                if (square.IsCurrent && !square.Position.IsEqual(copyOfPreviousSquare.Position))
                {
                    square.IsCurrent = false;
                    square.IsVisited = false;
                    square.MoveOrder = -1;
                }


                if (square.Position.IsEqual(copyOfPreviousSquare.Position))
                {
                    square.IsCurrent = true;
                }
            }
        }

        public static void SetCurrent(this Board board, Coord location, int moveOrder)
        {
            foreach (Square square in board.Grid)
            {
                square.IsCurrent = false;
                if (square.Position.IsEqual(location))
                {
                    square.IsCurrent = true;
                    square.IsVisited = true;
                    square.MoveOrder = moveOrder;
                }
            }
        }
        public static void SetMoveOrder(this Board board, int moveOrder)
        {
            foreach (Square square in board.Grid)
                if (square.IsCurrent) square.MoveOrder = moveOrder;
        }

        public static void SetMoveOrder(this Board board, Coord location, int moveOrder)
        {
            board.Grid[location.X, location.Y].MoveOrder = moveOrder;
        }
        public static void SetMoveOrder(this Board board, int x, int y, int moveOrder)
        {
            board.Grid[x, y].MoveOrder = moveOrder;
        }
        public static void ValidateSquares(this Board board)
        {
            foreach (var item in board.Grid)
            {
                item.ValidateMoves(board);
            }
        }
        public static bool validSquare(this Board board, Coord sq) => (sq.X >= 0 && sq.X < board.BoardSize && sq.Y >= 0 && sq.Y < board.BoardSize);
        public static bool safeSquare(this Board board, Coord sq) => (board.validSquare(sq) && !board.Grid[sq.X, sq.Y].IsVisited);
        public static bool isClosingSquare(this Board board, Coord candidate)
        {
            foreach (Coord position in board.ClosingCoords)
                if (position.IsEqual(candidate)) return true;
            return false;
        }
        public static bool isClosingSquare(this Board board)
        {
            foreach (Square square in board.Grid)
                if (square.IsCurrent) return board.isClosingSquare(square.Position);
            return false;
        }
        public static Coord GetCurrentLocation(this Board board)
        {
            foreach (Square square in board.Grid)
                if (square.IsCurrent) return square.Position.MakeCopy();
            return null;
        }

        public static Square CopyCurrentSquare(this Board board)
        {
            foreach (Square square in board.Grid)
                if (square.IsCurrent) return square.MakeCopy();
            return null;
        }
        public static List<Coord> NextMoves(this Board board)
        {
            foreach (Square square in board.Grid)
                if (square.IsCurrent) return square.CopyMoves();
            return null;
        }
        public static Square GetSquareByPosition(this Board board, Coord position)
        {
            foreach (Square square in board.Grid)
                if (square.Position.IsEqual(position)) return square.MakeCopy();
            return null;
        }
    }
}
