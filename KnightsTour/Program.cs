﻿using System;

namespace KnightsTour
{
    class Program
    {

        static void Main(string[] args)
        {

            //KnightsTour_fromShad KT1 = new(6);
            //KT1.FindKT(0,0);

            KnightsTour_1_Closed KT2 = new(8,0,0);
            KT2.FindKT();

            

            //KT2.TestLandingSquare();
            //KT2.PrintMoves();

            Console.ReadLine();
        }

 

    }
}
