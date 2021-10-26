using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour.Models
{
    class Square
    {
        public Coord Position { get; set; }
        public decimal Profit { get; set; }
        public int MoveOrder { get; set; }
        public bool IsVisited { get; set; }
        public bool IsCurrent { get; set; }
        
        public List<Coord> OutgoingMoves { get; set; }
        
        
    }

    class SquareFactory
    {
        private readonly CoordFactory _coordFactory;
        private int[,] KnightMovesArray = { { 2, 1 }, { 1, 2 }, { -1, 2 }, { -2, 1 }, { -2, -1 }, { -1, -2 }, { 1, -2 }, { 2, -1 } };

        public SquareFactory(CoordFactory coordFactory)
        {
            _coordFactory = coordFactory;
        }

        public Square GetNewSquare(Coord coord, decimal profit)
        {
            return GetNewSquare(coord.X, coord.Y, profit);
        }

        public Square GetNewSquare(int x, int y, decimal profit) => new Square() 
        { 
            Position = _coordFactory.GetNewCoord(x,y),
            Profit = profit,
            MoveOrder = -1,
            IsVisited = false,
            IsCurrent = false,
            OutgoingMoves = CreateMoves(KnightMovesArray,x,y)
        };

        public List<Coord> CreateMoves(int[,] arr2D, int x,int y)
        {
            List<Coord> result = FromRange(arr2D);
            return result.Select(p => p.Add(x,y))
                        .ToList();
        }
        public List<Coord> FromRange(int[,] arr2D)
        {
            List<Coord> result = new();
            for (int i = 0; i < arr2D.GetLength(0); i++)
            {
                result.Add(new Coord() { X = arr2D[i, 0], Y = arr2D[i, 1] });
            }
            return result;
        }

    }
    static partial class Extensions
    {
        public static void PrintSquare(this Square square)
        {
            Console.Write($"({square.Position.X.ToString("00")},{square.Position.Y.ToString("00")})");
        }
        public static string ToString(this Square square)
        {
            return $"({square.Position.X.ToString("00")},{square.Position.Y.ToString("00")})";
        }

        public static void PrintMoves(this Square square)
        {
            Console.WriteLine("square:");
            square.PrintSquare();
            foreach (var item in square.OutgoingMoves)
            {
                item.PrintCoord();
            }
            Console.WriteLine();
        }

        public static void ValidateMoves(this Square square, Board board)
        {
            square.OutgoingMoves = square.OutgoingMoves.Where(e => board.validSquare(e)).ToList();
        }
        public static List<Coord> CopyMoves(this Square square)
        {
            return square.OutgoingMoves.Select(e => e.MakeCopy()).ToList();
        }
        public static Square MakeCopy(this Square square)
        {
           return new Square()
            {
                Position = square.Position.MakeCopy(),
                Profit = square.Profit,
                MoveOrder = square.MoveOrder,
                IsVisited = square.IsVisited,
                IsCurrent = square.IsCurrent,
                OutgoingMoves = square.CopyMoves()
           };
        }
    }
}
