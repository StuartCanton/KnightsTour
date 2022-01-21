using KnightsTour.Comparers;
using KnightsTour.Data;
using KnightsTour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour
{
    internal class MinimumSpanningTree2
    {
        private Random _random;
        private List<Edge> _edges;
        private List<Node> _nodes;

        public MinimumSpanningTree2()
        {
            Console.WriteLine("Welcome to the MST testing lounge");
            //create random profits
            _random = new(55);


            //adjacency
            Console.WriteLine(AdjacencyMatrix.c[0, 10]);
            _nodes = CreateNodes(64);
            _edges = CreateEdgeList(_nodes).OrderByDescending(e => e.Profit).ToList();
            Console.WriteLine("Total Number of Edges:{0}", _edges.Count);
            //Console.WriteLine(GetQuadrant(8, 15));
            Console.WriteLine("Starting from TL");

            var topLeftStartEdges = _edges.Where(e => GetQuadrant(8, e.Start) == EnumQuadrants.TopLeft || GetQuadrant(8, e.End) == EnumQuadrants.TopLeft).ToList();
            var topLeftNodes = _nodes.Where(e => GetQuadrant(8, e.ID) == EnumQuadrants.TopLeft).ToList();
            Console.WriteLine("Count TLedges:{0}", topLeftStartEdges.Count);
            //topLeftStartEdges.PrintEdges();
            //topLeftNodes.PrintNodes();

            Console.WriteLine(CountNodes(topLeftStartEdges));

            var mTree = MST(topLeftStartEdges, topLeftNodes);
            mTree.PrintEdges();
            
            Console.WriteLine("TreeCount:{0}", CountNodes(mTree));
            Console.WriteLine("TreeProfit:{0}", mTree.GetTotalProfit());
            Console.WriteLine("QuadProfit:{0}", topLeftNodes.GetTotalProfit());

            Console.WriteLine("Thankyou");
        }

        private List<Node> CreateNodes(int size)
        {
            var nodes = new List<Node>();
            for (int i = 0; i < size; i++)
            {
                nodes.Add(new Node { ID = i, Spanned = false, Visited = false, Profit = GenerateRandomProfit() });
            }
            return nodes;
        }



        private List<Edge> CreateEdgeList(List<Node> nodes)
        {
            List<Edge> result = new();

            for (int i = 0; i < AdjacencyMatrix.c.GetLength(0); i++)
            {
                for (int j = 0; j < AdjacencyMatrix.c.GetLength(1); j++)
                {
                    if (AdjacencyMatrix.c[i, j] == 1)
                    {
                        result.Add(new Edge() { Start = i, End = j, Distance = 1, Profit = nodes[j].Profit });
                    }
                }
            }

            return result;
        }

        private List<Edge> MST(List<Edge> edges, List<Node> nodes)
        {

            List<Edge> Tree = new();
            int[] Spanned = new int[64];
            //start at 1
            Spanned[24] = 1;
            //nodes[18].Visited = true;
            //get edges starting at 1

            PriorityQueue<Edge, decimal> queue = new PriorityQueue<Edge, decimal>(new CompareProfit());

            //PrintQueue(queue);
            var count = 0;
            while (SpannedNotComplete(Spanned))
            {
                foreach (Edge edge in edges)
                    queue.Enqueue(edge, edge.Profit);

               // Spanned[count] = 1;


                while (queue.Count != 0)
                {
                    var e = queue.Dequeue();
                    if (e.Start == 18 || e.End == 18)
                    {
                        //Console.Write("check:");
                        //e.PrintEdge();

                    }
                    if (Spanned[e.Start] == 1 && Spanned[e.End] == 0)
                    {
                        Tree.Add(e);
                        Spanned[e.End] = 1;
                    }
                }
            }




            Spanned.PrintIntArray();
            return Tree;
        }

        private bool SpannedNotComplete(int[] s)
        {
            for (int i = 0; i < s.Length; i++)
                if(s[i]==0)return true;
           return false;       
        }

        private bool IsSpanned(List<int> spanned, int nodeID)
        {
            foreach (int id in spanned)
            {
                if (nodeID == id) return true;
            }
            return false;
        }


        //check for loops
        private bool IsClosingALoop(List<int> spanned, Edge edge)
        {
            //if both are in the spanned

            if (IsSpanned(spanned, edge.Start) && IsSpanned(spanned, edge.End))
            {
                return true;
            }

            return false;
        }

        void PrintQueue(PriorityQueue<Edge, decimal> queue)
        {
            
            PriorityQueue<Edge, decimal> result = new(queue.Comparer);
            result.EnqueueRange(queue.UnorderedItems);

            while (result.TryDequeue(out Edge item, out decimal priority))
            {
                Console.WriteLine($"Edge start : {item.Start}. End: {item.End} Priority Was : {priority}");
            }
        }

        public void CreateMST(List<Square> squares)
        {
            //need connected graph
            foreach (var sq in squares)
            {

            }


        }

        private decimal GenerateRandomProfit()
        {
            decimal result = 0m;
            decimal value = _random.Next(1000000);
            result = value / 100;
            return result;
        }

        //private EnumQuadrants? GetQuadrantFromID(int size, int ID)
        //{
        //    EnumQuadrants? result = null;

        //}


        private EnumQuadrants? GetQuadrant(int size, int rowWiseLocation)
        {
            //int Divider(int q, int d) => (int)Math.Floor((double)(q / d));
            Func<int, int, int> Divide = (q, d) => (int)Math.Floor((double)(q / d));

            //size = 8;
            int square = size * size;
            int topLimit = square / 2;
            int quartSize = size / 2;

            //calc if top/bottom
            //int top_bottom = (int)Math.Floor((double)(rowWiseLocation / topLimit));
            int top_bottom = Divide(rowWiseLocation, topLimit);
            int left_right = Divide(rowWiseLocation % size, quartSize);

            if (top_bottom == 0 && left_right == 0) return EnumQuadrants.TopLeft;
            if (top_bottom == 0 && left_right == 1) return EnumQuadrants.TopRight;
            if (top_bottom == 1 && left_right == 0) return EnumQuadrants.BottomLeft;
            if (top_bottom == 1 && left_right == 1) return EnumQuadrants.BottomRight;

            return null;
        }

        private int CountNodes(List<Edge> edges)
        {
            return GetUniqueNodes(edges).Count();
        }
        private List<int> GetUniqueNodes(List<Edge> edges)
        {
            List<int> AllNodes = new();
            foreach (var item in edges)
            {
                AllNodes.Add(item.Start);
                AllNodes.Add(item.End);
            }
            return AllNodes.Distinct().OrderBy(e => e).ToList();
        }
    }
}
