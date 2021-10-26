using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour.Models
{
    class Axis
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }

    class AxisFactory
    {
        public Axis GetNewAxis(int min, int max) => new Axis() { Min = min, Max = max };

    }

    static partial class Extensions
    {
        public static void PrintToConsole(this Axis range)
        {
            Console.Write($"({range.Min},{range.Max})");
        }
        public static string ToString(this Axis range)
        {
            return $"({range.Min},{range.Max})";
        }

        public static Axis Slice(this Axis range, int mid)
        {
            int unsignedMid = Math.Abs(mid);
 
            if (mid < 0) return new Axis() { Max = range.Max + mid, Min = range.Min };

            if (mid > 0) return new Axis() { Min = range.Min + mid, Max = range.Max };
            //Axis result = new() { Min = start, Max = end };
            return null;
        }

        public static bool IsEqual(this Axis a1, Axis a2) => a1.Min == a2.Min && a1.Max == a2.Max;
        public static bool IsWithin(this Axis a1, int val) => a1.Min <= val && a1.Max >= val;
        //public static Axis Span(this Axis a1, Axis a2) => new Axis() { Min = a1.Min<a2.Min}

        //public static Axis Slice(this Axis range, int start, int end)
        //{
        //    Axis result = new();
        //    if (end < 0) result.Max += end;


        //    //Axis result = new() { Min = start, Max = end };

        //    return result;
        //}

        //public static Axis Slice(this Axis range, int start)
        //{
        //    int end = range.Max;
        //    Axis result = new();

        //    if (start >= 0)
        //    {
        //        return range.Slice(start, end);

        //    }
        //    if(start < 0)
        //    {
        //        result.Min = result.Max - start;

        //    }

        //    return result;
        //}

        //public static Coord Add(this Axis a1, Axis a2) => new() { X = a1.X + sq2.X, Y = sq1.Y + sq2.Y };
        //public static Coord Add(this Axis a1, int min, int max) => new() { X = sq1.X + x, Y = sq1.Y + y };
        //
        //public static Coord MakeCopy(this Axis ax) => new Axis() { X = sq.X, Y = sq.Y };

    }
}
