using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour
{
    public static partial class Extensions
    {
        public static void PrintIntArray(this int[] arr)
        {
            Console.WriteLine($"Array of Length:{arr.Length}");
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 10 == 0) Console.Write("\n");
                Console.Write($"{i}:{arr[i]},");
            }
        }
    }
}
