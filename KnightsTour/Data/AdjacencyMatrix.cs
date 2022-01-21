﻿using KnightsTour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour.Data
{
    public static class AdjacencyMatrix
    {
        //static
        public static int[,] c = new int[64, 64]{
                {0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,1,0,1,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0}
                };

        public static Edge[] edges = new Edge[]{
                new Edge() { Start = 0, End = 10, Distance = 1, Profit = 0},new Edge() { Start = 0, End = 17, Distance = 1, Profit = 0},
                new Edge() { Start = 1, End = 11, Distance = 1, Profit = 0},new Edge() { Start = 1, End = 16, Distance = 1, Profit = 0},new Edge() { Start = 1, End = 18, Distance = 1, Profit = 0},
                new Edge() { Start = 2, End = 8, Distance = 1, Profit = 0},new Edge() { Start = 2, End = 12, Distance = 1, Profit = 0},new Edge() { Start = 2, End = 17, Distance = 1, Profit = 0},new Edge() { Start = 2, End = 19, Distance = 1, Profit = 0},
                new Edge() { Start = 3, End = 9, Distance = 1, Profit = 0},new Edge() { Start = 3, End = 13, Distance = 1, Profit = 0},new Edge() { Start = 3, End = 18, Distance = 1, Profit = 0},new Edge() { Start = 3, End = 20, Distance = 1, Profit = 0},
                new Edge() { Start = 4, End = 10, Distance = 1, Profit = 0},new Edge() { Start = 4, End = 14, Distance = 1, Profit = 0},new Edge() { Start = 4, End = 19, Distance = 1, Profit = 0},new Edge() { Start = 4, End = 21, Distance = 1, Profit = 0},
                new Edge() { Start = 5, End = 11, Distance = 1, Profit = 0},new Edge() { Start = 5, End = 15, Distance = 1, Profit = 0},new Edge() { Start = 5, End = 20, Distance = 1, Profit = 0},new Edge() { Start = 5, End = 22, Distance = 1, Profit = 0},
                new Edge() { Start = 6, End = 12, Distance = 1, Profit = 0},new Edge() { Start = 6, End = 21, Distance = 1, Profit = 0},new Edge() { Start = 6, End = 23, Distance = 1, Profit = 0},
                new Edge() { Start = 7, End = 13, Distance = 1, Profit = 0},new Edge() { Start = 7, End = 22, Distance = 1, Profit = 0},
                new Edge() { Start = 8, End = 2, Distance = 1, Profit = 0},new Edge() { Start = 8, End = 18, Distance = 1, Profit = 0},new Edge() { Start = 8, End = 25, Distance = 1, Profit = 0},
                new Edge() { Start = 9, End = 3, Distance = 1, Profit = 0},new Edge() { Start = 9, End = 19, Distance = 1, Profit = 0},new Edge() { Start = 9, End = 24, Distance = 1, Profit = 0},new Edge() { Start = 9, End = 26, Distance = 1, Profit = 0},
                new Edge() { Start = 10, End = 0, Distance = 1, Profit = 0},new Edge() { Start = 10, End = 4, Distance = 1, Profit = 0},new Edge() { Start = 10, End = 16, Distance = 1, Profit = 0},new Edge() { Start = 10, End = 20, Distance = 1, Profit = 0},new Edge() { Start = 10, End = 25, Distance = 1, Profit = 0},new Edge() { Start = 10, End = 27, Distance = 1, Profit = 0},
                new Edge() { Start = 11, End = 1, Distance = 1, Profit = 0},new Edge() { Start = 11, End = 5, Distance = 1, Profit = 0},new Edge() { Start = 11, End = 17, Distance = 1, Profit = 0},new Edge() { Start = 11, End = 21, Distance = 1, Profit = 0},new Edge() { Start = 11, End = 26, Distance = 1, Profit = 0},new Edge() { Start = 11, End = 28, Distance = 1, Profit = 0},
                new Edge() { Start = 12, End = 2, Distance = 1, Profit = 0},new Edge() { Start = 12, End = 6, Distance = 1, Profit = 0},new Edge() { Start = 12, End = 18, Distance = 1, Profit = 0},new Edge() { Start = 12, End = 22, Distance = 1, Profit = 0},new Edge() { Start = 12, End = 27, Distance = 1, Profit = 0},new Edge() { Start = 12, End = 29, Distance = 1, Profit = 0},
                new Edge() { Start = 13, End = 3, Distance = 1, Profit = 0},new Edge() { Start = 13, End = 7, Distance = 1, Profit = 0},new Edge() { Start = 13, End = 19, Distance = 1, Profit = 0},new Edge() { Start = 13, End = 23, Distance = 1, Profit = 0},new Edge() { Start = 13, End = 28, Distance = 1, Profit = 0},new Edge() { Start = 13, End = 30, Distance = 1, Profit = 0},
                new Edge() { Start = 14, End = 4, Distance = 1, Profit = 0},new Edge() { Start = 14, End = 20, Distance = 1, Profit = 0},new Edge() { Start = 14, End = 29, Distance = 1, Profit = 0},new Edge() { Start = 14, End = 31, Distance = 1, Profit = 0},
                new Edge() { Start = 15, End = 5, Distance = 1, Profit = 0},new Edge() { Start = 15, End = 21, Distance = 1, Profit = 0},new Edge() { Start = 15, End = 30, Distance = 1, Profit = 0},
                new Edge() { Start = 16, End = 1, Distance = 1, Profit = 0},new Edge() { Start = 16, End = 10, Distance = 1, Profit = 0},new Edge() { Start = 16, End = 26, Distance = 1, Profit = 0},new Edge() { Start = 16, End = 33, Distance = 1, Profit = 0},
                new Edge() { Start = 17, End = 0, Distance = 1, Profit = 0},new Edge() { Start = 17, End = 2, Distance = 1, Profit = 0},new Edge() { Start = 17, End = 11, Distance = 1, Profit = 0},new Edge() { Start = 17, End = 27, Distance = 1, Profit = 0},new Edge() { Start = 17, End = 32, Distance = 1, Profit = 0},new Edge() { Start = 17, End = 34, Distance = 1, Profit = 0},
                new Edge() { Start = 18, End = 1, Distance = 1, Profit = 0},new Edge() { Start = 18, End = 3, Distance = 1, Profit = 0},new Edge() { Start = 18, End = 8, Distance = 1, Profit = 0},new Edge() { Start = 18, End = 12, Distance = 1, Profit = 0},new Edge() { Start = 18, End = 24, Distance = 1, Profit = 0},new Edge() { Start = 18, End = 28, Distance = 1, Profit = 0},new Edge() { Start = 18, End = 33, Distance = 1, Profit = 0},new Edge() { Start = 18, End = 35, Distance = 1, Profit = 0},
                new Edge() { Start = 19, End = 2, Distance = 1, Profit = 0},new Edge() { Start = 19, End = 4, Distance = 1, Profit = 0},new Edge() { Start = 19, End = 9, Distance = 1, Profit = 0},new Edge() { Start = 19, End = 13, Distance = 1, Profit = 0},new Edge() { Start = 19, End = 25, Distance = 1, Profit = 0},new Edge() { Start = 19, End = 29, Distance = 1, Profit = 0},new Edge() { Start = 19, End = 34, Distance = 1, Profit = 0},new Edge() { Start = 19, End = 36, Distance = 1, Profit = 0},
                new Edge() { Start = 20, End = 3, Distance = 1, Profit = 0},new Edge() { Start = 20, End = 5, Distance = 1, Profit = 0},new Edge() { Start = 20, End = 10, Distance = 1, Profit = 0},new Edge() { Start = 20, End = 14, Distance = 1, Profit = 0},new Edge() { Start = 20, End = 26, Distance = 1, Profit = 0},new Edge() { Start = 20, End = 30, Distance = 1, Profit = 0},new Edge() { Start = 20, End = 35, Distance = 1, Profit = 0},new Edge() { Start = 20, End = 37, Distance = 1, Profit = 0},
                new Edge() { Start = 21, End = 4, Distance = 1, Profit = 0},new Edge() { Start = 21, End = 6, Distance = 1, Profit = 0},new Edge() { Start = 21, End = 11, Distance = 1, Profit = 0},new Edge() { Start = 21, End = 15, Distance = 1, Profit = 0},new Edge() { Start = 21, End = 27, Distance = 1, Profit = 0},new Edge() { Start = 21, End = 31, Distance = 1, Profit = 0},new Edge() { Start = 21, End = 36, Distance = 1, Profit = 0},new Edge() { Start = 21, End = 38, Distance = 1, Profit = 0},
                new Edge() { Start = 22, End = 5, Distance = 1, Profit = 0},new Edge() { Start = 22, End = 7, Distance = 1, Profit = 0},new Edge() { Start = 22, End = 12, Distance = 1, Profit = 0},new Edge() { Start = 22, End = 28, Distance = 1, Profit = 0},new Edge() { Start = 22, End = 37, Distance = 1, Profit = 0},new Edge() { Start = 22, End = 39, Distance = 1, Profit = 0},
                new Edge() { Start = 23, End = 6, Distance = 1, Profit = 0},new Edge() { Start = 23, End = 13, Distance = 1, Profit = 0},new Edge() { Start = 23, End = 29, Distance = 1, Profit = 0},new Edge() { Start = 23, End = 38, Distance = 1, Profit = 0},
                new Edge() { Start = 24, End = 9, Distance = 1, Profit = 0},new Edge() { Start = 24, End = 18, Distance = 1, Profit = 0},new Edge() { Start = 24, End = 34, Distance = 1, Profit = 0},new Edge() { Start = 24, End = 41, Distance = 1, Profit = 0},
                new Edge() { Start = 25, End = 8, Distance = 1, Profit = 0},new Edge() { Start = 25, End = 10, Distance = 1, Profit = 0},new Edge() { Start = 25, End = 19, Distance = 1, Profit = 0},new Edge() { Start = 25, End = 35, Distance = 1, Profit = 0},new Edge() { Start = 25, End = 40, Distance = 1, Profit = 0},new Edge() { Start = 25, End = 42, Distance = 1, Profit = 0},
                new Edge() { Start = 26, End = 9, Distance = 1, Profit = 0},new Edge() { Start = 26, End = 11, Distance = 1, Profit = 0},new Edge() { Start = 26, End = 16, Distance = 1, Profit = 0},new Edge() { Start = 26, End = 20, Distance = 1, Profit = 0},new Edge() { Start = 26, End = 32, Distance = 1, Profit = 0},new Edge() { Start = 26, End = 36, Distance = 1, Profit = 0},new Edge() { Start = 26, End = 41, Distance = 1, Profit = 0},new Edge() { Start = 26, End = 43, Distance = 1, Profit = 0},
                new Edge() { Start = 27, End = 10, Distance = 1, Profit = 0},new Edge() { Start = 27, End = 12, Distance = 1, Profit = 0},new Edge() { Start = 27, End = 17, Distance = 1, Profit = 0},new Edge() { Start = 27, End = 21, Distance = 1, Profit = 0},new Edge() { Start = 27, End = 33, Distance = 1, Profit = 0},new Edge() { Start = 27, End = 37, Distance = 1, Profit = 0},new Edge() { Start = 27, End = 42, Distance = 1, Profit = 0},new Edge() { Start = 27, End = 44, Distance = 1, Profit = 0},
                new Edge() { Start = 28, End = 11, Distance = 1, Profit = 0},new Edge() { Start = 28, End = 13, Distance = 1, Profit = 0},new Edge() { Start = 28, End = 18, Distance = 1, Profit = 0},new Edge() { Start = 28, End = 22, Distance = 1, Profit = 0},new Edge() { Start = 28, End = 34, Distance = 1, Profit = 0},new Edge() { Start = 28, End = 38, Distance = 1, Profit = 0},new Edge() { Start = 28, End = 43, Distance = 1, Profit = 0},new Edge() { Start = 28, End = 45, Distance = 1, Profit = 0},
                new Edge() { Start = 29, End = 12, Distance = 1, Profit = 0},new Edge() { Start = 29, End = 14, Distance = 1, Profit = 0},new Edge() { Start = 29, End = 19, Distance = 1, Profit = 0},new Edge() { Start = 29, End = 23, Distance = 1, Profit = 0},new Edge() { Start = 29, End = 35, Distance = 1, Profit = 0},new Edge() { Start = 29, End = 39, Distance = 1, Profit = 0},new Edge() { Start = 29, End = 44, Distance = 1, Profit = 0},new Edge() { Start = 29, End = 46, Distance = 1, Profit = 0},
                new Edge() { Start = 30, End = 13, Distance = 1, Profit = 0},new Edge() { Start = 30, End = 15, Distance = 1, Profit = 0},new Edge() { Start = 30, End = 20, Distance = 1, Profit = 0},new Edge() { Start = 30, End = 36, Distance = 1, Profit = 0},new Edge() { Start = 30, End = 45, Distance = 1, Profit = 0},new Edge() { Start = 30, End = 47, Distance = 1, Profit = 0},
                new Edge() { Start = 31, End = 14, Distance = 1, Profit = 0},new Edge() { Start = 31, End = 21, Distance = 1, Profit = 0},new Edge() { Start = 31, End = 37, Distance = 1, Profit = 0},new Edge() { Start = 31, End = 46, Distance = 1, Profit = 0},
                new Edge() { Start = 32, End = 17, Distance = 1, Profit = 0},new Edge() { Start = 32, End = 26, Distance = 1, Profit = 0},new Edge() { Start = 32, End = 42, Distance = 1, Profit = 0},new Edge() { Start = 32, End = 49, Distance = 1, Profit = 0},
                new Edge() { Start = 33, End = 16, Distance = 1, Profit = 0},new Edge() { Start = 33, End = 18, Distance = 1, Profit = 0},new Edge() { Start = 33, End = 27, Distance = 1, Profit = 0},new Edge() { Start = 33, End = 43, Distance = 1, Profit = 0},new Edge() { Start = 33, End = 48, Distance = 1, Profit = 0},new Edge() { Start = 33, End = 50, Distance = 1, Profit = 0},
                new Edge() { Start = 34, End = 17, Distance = 1, Profit = 0},new Edge() { Start = 34, End = 19, Distance = 1, Profit = 0},new Edge() { Start = 34, End = 24, Distance = 1, Profit = 0},new Edge() { Start = 34, End = 28, Distance = 1, Profit = 0},new Edge() { Start = 34, End = 40, Distance = 1, Profit = 0},new Edge() { Start = 34, End = 44, Distance = 1, Profit = 0},new Edge() { Start = 34, End = 49, Distance = 1, Profit = 0},new Edge() { Start = 34, End = 51, Distance = 1, Profit = 0},
                new Edge() { Start = 35, End = 18, Distance = 1, Profit = 0},new Edge() { Start = 35, End = 20, Distance = 1, Profit = 0},new Edge() { Start = 35, End = 25, Distance = 1, Profit = 0},new Edge() { Start = 35, End = 29, Distance = 1, Profit = 0},new Edge() { Start = 35, End = 41, Distance = 1, Profit = 0},new Edge() { Start = 35, End = 45, Distance = 1, Profit = 0},new Edge() { Start = 35, End = 50, Distance = 1, Profit = 0},new Edge() { Start = 35, End = 52, Distance = 1, Profit = 0},
                new Edge() { Start = 36, End = 19, Distance = 1, Profit = 0},new Edge() { Start = 36, End = 21, Distance = 1, Profit = 0},new Edge() { Start = 36, End = 26, Distance = 1, Profit = 0},new Edge() { Start = 36, End = 30, Distance = 1, Profit = 0},new Edge() { Start = 36, End = 42, Distance = 1, Profit = 0},new Edge() { Start = 36, End = 46, Distance = 1, Profit = 0},new Edge() { Start = 36, End = 51, Distance = 1, Profit = 0},new Edge() { Start = 36, End = 53, Distance = 1, Profit = 0},
                new Edge() { Start = 37, End = 20, Distance = 1, Profit = 0},new Edge() { Start = 37, End = 22, Distance = 1, Profit = 0},new Edge() { Start = 37, End = 27, Distance = 1, Profit = 0},new Edge() { Start = 37, End = 31, Distance = 1, Profit = 0},new Edge() { Start = 37, End = 43, Distance = 1, Profit = 0},new Edge() { Start = 37, End = 47, Distance = 1, Profit = 0},new Edge() { Start = 37, End = 52, Distance = 1, Profit = 0},new Edge() { Start = 37, End = 54, Distance = 1, Profit = 0},
                new Edge() { Start = 38, End = 21, Distance = 1, Profit = 0},new Edge() { Start = 38, End = 23, Distance = 1, Profit = 0},new Edge() { Start = 38, End = 28, Distance = 1, Profit = 0},new Edge() { Start = 38, End = 44, Distance = 1, Profit = 0},new Edge() { Start = 38, End = 53, Distance = 1, Profit = 0},new Edge() { Start = 38, End = 55, Distance = 1, Profit = 0},
                new Edge() { Start = 39, End = 22, Distance = 1, Profit = 0},new Edge() { Start = 39, End = 29, Distance = 1, Profit = 0},new Edge() { Start = 39, End = 45, Distance = 1, Profit = 0},new Edge() { Start = 39, End = 54, Distance = 1, Profit = 0},
                new Edge() { Start = 40, End = 25, Distance = 1, Profit = 0},new Edge() { Start = 40, End = 34, Distance = 1, Profit = 0},new Edge() { Start = 40, End = 50, Distance = 1, Profit = 0},new Edge() { Start = 40, End = 57, Distance = 1, Profit = 0},
                new Edge() { Start = 41, End = 24, Distance = 1, Profit = 0},new Edge() { Start = 41, End = 26, Distance = 1, Profit = 0},new Edge() { Start = 41, End = 35, Distance = 1, Profit = 0},new Edge() { Start = 41, End = 51, Distance = 1, Profit = 0},new Edge() { Start = 41, End = 56, Distance = 1, Profit = 0},new Edge() { Start = 41, End = 58, Distance = 1, Profit = 0},
                new Edge() { Start = 42, End = 25, Distance = 1, Profit = 0},new Edge() { Start = 42, End = 27, Distance = 1, Profit = 0},new Edge() { Start = 42, End = 32, Distance = 1, Profit = 0},new Edge() { Start = 42, End = 36, Distance = 1, Profit = 0},new Edge() { Start = 42, End = 48, Distance = 1, Profit = 0},new Edge() { Start = 42, End = 52, Distance = 1, Profit = 0},new Edge() { Start = 42, End = 57, Distance = 1, Profit = 0},new Edge() { Start = 42, End = 59, Distance = 1, Profit = 0},
                new Edge() { Start = 43, End = 26, Distance = 1, Profit = 0},new Edge() { Start = 43, End = 28, Distance = 1, Profit = 0},new Edge() { Start = 43, End = 33, Distance = 1, Profit = 0},new Edge() { Start = 43, End = 37, Distance = 1, Profit = 0},new Edge() { Start = 43, End = 49, Distance = 1, Profit = 0},new Edge() { Start = 43, End = 53, Distance = 1, Profit = 0},new Edge() { Start = 43, End = 58, Distance = 1, Profit = 0},new Edge() { Start = 43, End = 60, Distance = 1, Profit = 0},
                new Edge() { Start = 44, End = 27, Distance = 1, Profit = 0},new Edge() { Start = 44, End = 29, Distance = 1, Profit = 0},new Edge() { Start = 44, End = 34, Distance = 1, Profit = 0},new Edge() { Start = 44, End = 38, Distance = 1, Profit = 0},new Edge() { Start = 44, End = 50, Distance = 1, Profit = 0},new Edge() { Start = 44, End = 54, Distance = 1, Profit = 0},new Edge() { Start = 44, End = 59, Distance = 1, Profit = 0},new Edge() { Start = 44, End = 61, Distance = 1, Profit = 0},
                new Edge() { Start = 45, End = 28, Distance = 1, Profit = 0},new Edge() { Start = 45, End = 30, Distance = 1, Profit = 0},new Edge() { Start = 45, End = 35, Distance = 1, Profit = 0},new Edge() { Start = 45, End = 39, Distance = 1, Profit = 0},new Edge() { Start = 45, End = 51, Distance = 1, Profit = 0},new Edge() { Start = 45, End = 55, Distance = 1, Profit = 0},new Edge() { Start = 45, End = 60, Distance = 1, Profit = 0},new Edge() { Start = 45, End = 62, Distance = 1, Profit = 0},
                new Edge() { Start = 46, End = 29, Distance = 1, Profit = 0},new Edge() { Start = 46, End = 31, Distance = 1, Profit = 0},new Edge() { Start = 46, End = 36, Distance = 1, Profit = 0},new Edge() { Start = 46, End = 52, Distance = 1, Profit = 0},new Edge() { Start = 46, End = 61, Distance = 1, Profit = 0},new Edge() { Start = 46, End = 63, Distance = 1, Profit = 0},
                new Edge() { Start = 47, End = 30, Distance = 1, Profit = 0},new Edge() { Start = 47, End = 37, Distance = 1, Profit = 0},new Edge() { Start = 47, End = 53, Distance = 1, Profit = 0},new Edge() { Start = 47, End = 62, Distance = 1, Profit = 0},
                new Edge() { Start = 48, End = 33, Distance = 1, Profit = 0},new Edge() { Start = 48, End = 42, Distance = 1, Profit = 0},new Edge() { Start = 48, End = 58, Distance = 1, Profit = 0},
                new Edge() { Start = 49, End = 32, Distance = 1, Profit = 0},new Edge() { Start = 49, End = 34, Distance = 1, Profit = 0},new Edge() { Start = 49, End = 43, Distance = 1, Profit = 0},new Edge() { Start = 49, End = 59, Distance = 1, Profit = 0},
                new Edge() { Start = 50, End = 33, Distance = 1, Profit = 0},new Edge() { Start = 50, End = 35, Distance = 1, Profit = 0},new Edge() { Start = 50, End = 40, Distance = 1, Profit = 0},new Edge() { Start = 50, End = 44, Distance = 1, Profit = 0},new Edge() { Start = 50, End = 56, Distance = 1, Profit = 0},new Edge() { Start = 50, End = 60, Distance = 1, Profit = 0},
                new Edge() { Start = 51, End = 34, Distance = 1, Profit = 0},new Edge() { Start = 51, End = 36, Distance = 1, Profit = 0},new Edge() { Start = 51, End = 41, Distance = 1, Profit = 0},new Edge() { Start = 51, End = 45, Distance = 1, Profit = 0},new Edge() { Start = 51, End = 57, Distance = 1, Profit = 0},new Edge() { Start = 51, End = 61, Distance = 1, Profit = 0},
                new Edge() { Start = 52, End = 35, Distance = 1, Profit = 0},new Edge() { Start = 52, End = 37, Distance = 1, Profit = 0},new Edge() { Start = 52, End = 42, Distance = 1, Profit = 0},new Edge() { Start = 52, End = 46, Distance = 1, Profit = 0},new Edge() { Start = 52, End = 58, Distance = 1, Profit = 0},new Edge() { Start = 52, End = 62, Distance = 1, Profit = 0},
                new Edge() { Start = 53, End = 36, Distance = 1, Profit = 0},new Edge() { Start = 53, End = 38, Distance = 1, Profit = 0},new Edge() { Start = 53, End = 43, Distance = 1, Profit = 0},new Edge() { Start = 53, End = 47, Distance = 1, Profit = 0},new Edge() { Start = 53, End = 59, Distance = 1, Profit = 0},new Edge() { Start = 53, End = 63, Distance = 1, Profit = 0},
                new Edge() { Start = 54, End = 37, Distance = 1, Profit = 0},new Edge() { Start = 54, End = 39, Distance = 1, Profit = 0},new Edge() { Start = 54, End = 44, Distance = 1, Profit = 0},new Edge() { Start = 54, End = 60, Distance = 1, Profit = 0},
                new Edge() { Start = 55, End = 38, Distance = 1, Profit = 0},new Edge() { Start = 55, End = 45, Distance = 1, Profit = 0},new Edge() { Start = 55, End = 61, Distance = 1, Profit = 0},
                new Edge() { Start = 56, End = 41, Distance = 1, Profit = 0},new Edge() { Start = 56, End = 50, Distance = 1, Profit = 0},
                new Edge() { Start = 57, End = 40, Distance = 1, Profit = 0},new Edge() { Start = 57, End = 42, Distance = 1, Profit = 0},new Edge() { Start = 57, End = 51, Distance = 1, Profit = 0},
                new Edge() { Start = 58, End = 41, Distance = 1, Profit = 0},new Edge() { Start = 58, End = 43, Distance = 1, Profit = 0},new Edge() { Start = 58, End = 48, Distance = 1, Profit = 0},new Edge() { Start = 58, End = 52, Distance = 1, Profit = 0},
                new Edge() { Start = 59, End = 42, Distance = 1, Profit = 0},new Edge() { Start = 59, End = 44, Distance = 1, Profit = 0},new Edge() { Start = 59, End = 49, Distance = 1, Profit = 0},new Edge() { Start = 59, End = 53, Distance = 1, Profit = 0},
                new Edge() { Start = 60, End = 43, Distance = 1, Profit = 0},new Edge() { Start = 60, End = 45, Distance = 1, Profit = 0},new Edge() { Start = 60, End = 50, Distance = 1, Profit = 0},new Edge() { Start = 60, End = 54, Distance = 1, Profit = 0},
                new Edge() { Start = 61, End = 44, Distance = 1, Profit = 0},new Edge() { Start = 61, End = 46, Distance = 1, Profit = 0},new Edge() { Start = 61, End = 51, Distance = 1, Profit = 0},new Edge() { Start = 61, End = 55, Distance = 1, Profit = 0},
                new Edge() { Start = 62, End = 45, Distance = 1, Profit = 0},new Edge() { Start = 62, End = 47, Distance = 1, Profit = 0},new Edge() { Start = 62, End = 52, Distance = 1, Profit = 0},
                new Edge() { Start = 63, End = 46, Distance = 1, Profit = 0},new Edge() { Start = 63, End = 53, Distance = 1, Profit = 0},
                };
        //public static int[] Profits = new int[64]
        //{

        //};

    }
}
