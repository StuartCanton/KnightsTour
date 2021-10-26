using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour.Models
{

    enum EnumQuadrants
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }

    class Quadrant
    {
        public int Size { get; set; } = 4;
        public int TotalSquares { get; set; } = 16;
        public Axis MinMaxVisits { get; set; } = new();
        public List<Coord> LinksToFirst { get; set; }
        public List<Coord> LinksToSecond { get; set; }
        public List<Coord> LinksToThird { get; set; }
        public EnumQuadrants Corner { get; set; }
        public Range2D Area { get; set; }
        

        public Quadrant()
        {
            //a closed tour can start anywhere.
            //anti-clockwise

            //Get all links to First




        }

    }

    class QuadrantFactory
    {
        private readonly Range2DFactory _range2DFactory;
        private readonly AxisFactory _axisFactory;

        public QuadrantFactory(Range2DFactory range2DFactory, AxisFactory axisFactory)
        {
            _range2DFactory = range2DFactory;
            _axisFactory = axisFactory;
        }


        public Quadrant GetNewQuadrant(Board board, EnumQuadrants enumQuadrant)
        {
            int size = board.BoardSize / 2;
            int quadInt = (int)enumQuadrant;
            //Axis XAxis = new() { };

            if(quadInt < 2)
                //Axis XAxis = new() { };

            switch (enumQuadrant)
            {
                case EnumQuadrants.TopLeft:
                case EnumQuadrants.TopRight:
                    
                    break;
                case EnumQuadrants.BottomLeft:
                case EnumQuadrants.BottomRight:

                    break;

                default:
                    break;
            }

            return new Quadrant() {
                Size = size,
                TotalSquares = size * size,
                MinMaxVisits = _axisFactory.GetNewAxis(min: 2, max: 4),
                Corner = enumQuadrant,
                Area = _range2DFactory.GetNewRange2D(0,0,8,8) 
            };
        }


        public List<Quadrant> GetQuadrants(Board board, EnumQuadrants enumQuadrant)
        {
            //numberd rowwise 1,2,3,4
            // enums TL,TR,BL,BR

            int size = board.BoardSize / 2;
            int total = size * size;
            
            Axis firstAxis = _axisFactory.GetNewAxis(min: 0, max: size);
            Axis secondAxis = _axisFactory.GetNewAxis(min: size, max: board.BoardSize);

            List<Quadrant> result = new();
            result.Add(
                new Quadrant() {
                    Size = size,
                    TotalSquares = size * size,
                    MinMaxVisits = _axisFactory.GetNewAxis(min: 2, max: 4),
            Corner = EnumQuadrants.TopLeft,
                    Area = _range2DFactory.GetNewRange2D(firstAxis,firstAxis)
                });

            result.Add(
                new Quadrant()
                {
                    Size = size,
                    TotalSquares = size * size,
                    MinMaxVisits = _axisFactory.GetNewAxis(min: 2, max: 4),
                    Corner = EnumQuadrants.TopRight,
                    Area = _range2DFactory.GetNewRange2D(firstAxis, secondAxis)
                });
            result.Add(
                new Quadrant()
                {
                    Size = size,
                    TotalSquares = size * size,
                    MinMaxVisits = _axisFactory.GetNewAxis(min: 2, max: 4),
                    Corner = EnumQuadrants.BottomRight,
                    Area = _range2DFactory.GetNewRange2D(secondAxis, secondAxis)
                });
            result.Add(
                new Quadrant()
                {
                    Size = size,
                    TotalSquares = size * size,
                    MinMaxVisits = _axisFactory.GetNewAxis(min: 2, max: 4),
                    Corner = EnumQuadrants.BottomLeft,
                    Area = _range2DFactory.GetNewRange2D(secondAxis, firstAxis)
                });

            return result;
        }

    }
}
