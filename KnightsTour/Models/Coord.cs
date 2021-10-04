using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour.Models
{
    class Coord
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
    }

    class SquareFactory
    {
        public Coord GetNewCoord(int x, int y) => new Coord() { X = x, Y = y };

        public List<Coord> FromRange(int[,] arr2D)
        {
            List<Coord> result = new();
            for(int i = 0; i<arr2D.GetLength(0); i++)
            {
                result.Add(new Coord() { X=arr2D[i,0], Y=arr2D[i,1] });
            }
            return result;
        }
    }

    static partial class Extensions
    {
        public static void PrintCoord(this Coord square)
        {
            Console.Write($"({square.X},{square.Y})");
        }
        public static string MyToString(this Coord square)
        {
           return $"({square.X},{square.Y})";
        }
        public static Coord Add(this Coord sq1, Coord sq2) => new() { X = sq1.X + sq2.X, Y = sq1.Y + sq2.Y };
        public static bool IsEqual(this Coord sq1, Coord sq2) => sq1.X == sq2.X && sq1.Y == sq2.Y;

    }
}
