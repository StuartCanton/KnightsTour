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
            return GetQuadrants(board.BoardSize);
        }


        public List<Quadrant> GetQuadrants(int boardSize)
        {
            //numberd rowwise 1,2,3,4
            // enums TL,TR,BL,BR

            int size = boardSize / 2;
            int total = size * size;
            
            Axis firstAxis = _axisFactory.GetNewAxis(min: 0, max: size-1);
            Axis secondAxis = _axisFactory.GetNewAxis(min: size, max: boardSize);

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

    //__________________________________________________________________________________________________________
    static partial class Extensions
    {
        public static void PrintQuadrant(this Quadrant quadrant,Board board)
        {
            for (int i = 0; i < board.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < board.Grid.GetLength(1); j++)
                {
                    Square sq = board.Grid[i, j];
                    if (quadrant.QuadContains(sq))
                    {
                        //string val = sq.MoveOrder.ToString("00");
                        string val = sq.Profit.ToString("00");
                        if (val == "-01") val = "  ";
                        Console.Write(val + " ");
                    }
                    else
                    {
                        Console.Write("-- ");
                    }

                }
                Console.WriteLine();
            }
        }

        public static bool QuadContains(this Quadrant quadrant, Square candidate)
        {
            return QuadContains(quadrant, candidate.Position);
        }

        public static bool QuadContains(this Quadrant quadrant, Coord position)
        {
            return quadrant.Area.Xaxis.DoesContain(position.X) && quadrant.Area.Yaxis.DoesContain(position.Y);
            
        }
        public static void CreateMaxST(this Quadrant quadrant)
        {
            //List<Square> tree
        }
        public static List<Square> SortSquares(this Quadrant quadrant, Board board)
        {
            List<Square> result = GetSquares(quadrant, board);
            foreach (var item in result) item.PrintSquare();
            Console.WriteLine("");
            result = result.OrderByDescending(e=>e.Profit).ToList();
            foreach (var item in result) item.PrintSquare();
 
            return result;
        }
        public static List<Square> GetSquares(this Quadrant quadrant, Board board)
        {
            List<Square> result = new();
            for (int i = 0; i < board.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < board.Grid.GetLength(1); j++)
                {
                    Square sq = board.Grid[i, j].MakeCopy();
                    if (quadrant.QuadContains(sq))
                    {
                        result.Add(sq);

                    }
                }
            }
            return result;
        }
    }

}
