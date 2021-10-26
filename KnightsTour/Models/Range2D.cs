using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour.Models
{
    class Range2D
    {
        public int Xmin { get; set; }
        public int Xmax { get; set; }
        public int Ymin { get; set; }
        public int Ymax { get; set; }

        public Axis Xaxis { get; set; }
        public Axis Yaxis { get; set; }
    }

    class Range2DFactory
    {
        private readonly AxisFactory _axisFactory;

        public Range2DFactory(AxisFactory axisFactory)
        {
            _axisFactory = axisFactory;
        }

        public Range2D GetNewRange2D(int minX, int minY, int maxX, int maxY)
        {
            return new Range2D()
            {
                Xmin = minX,
                Xmax = maxX,
                Ymin = minY,
                Ymax = maxY,
                Xaxis = _axisFactory.GetNewAxis(minX, maxX),
                Yaxis = _axisFactory.GetNewAxis(minY, maxY)

            };
        }

        public Range2D GetNewRange2D(Axis xAxis, Axis yAxis)
        {
            return GetNewRange2D(xAxis.Min, yAxis.Min, xAxis.Max, yAxis.Max);
        }
    }

    static partial class Extensions
    {
        public static bool IsWithin(this Range2D range2D, Coord coord)
        {
            return coord.X >= range2D.Xmin && coord.X <= range2D.Xmax && coord.Y >= range2D.Ymin && coord.Y <= range2D.Ymax;


        }
    }

}
