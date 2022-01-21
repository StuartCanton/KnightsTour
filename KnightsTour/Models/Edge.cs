using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsTour.Models
{
    public class Edge
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int Distance { get; set; }
        public decimal Profit { get; set; }
        public bool Visited { get; set; } = false;

    }

    public class Node
    {
        public int ID { get; set; }
        public bool Visited { get; set; } = false;
        public bool Spanned { get; set; } = false;
        public decimal Profit { get; set; }
    }


    static partial class Extensions
    {
        public static void PrintEdge(this Edge edge)
        {
            string result = $"from:{edge.Start},to:{edge.End},profit:{edge.Profit}";

            Console.WriteLine($"Edge: {result}");

        }
        public static void PrintEdges(this List<Edge> edges)
        {
            foreach (Edge edge in edges)
            {
                edge.PrintEdge();
            }
        }
        public static decimal GetTotalProfit(this List<Edge> edges)
        {
            return edges.Sum(e => e.Profit);
        }

    }
    static partial class Extensions //for nodes
    {
        public static void PrintNode(this Node node)
        {
           string result = $"ID:{node.ID},profit:{node.Profit}";

            Console.WriteLine($"Node: {result}");

        }
        public static void PrintNodes(this List<Node> nodes)
        {
            foreach (Node node in nodes)
            {
                node.PrintNode();
            }
        }

        //public static int[] Address(this Node node, )
        //{

        //}
        public static decimal GetTotalProfit(this List<Node> nodes)
        {
            return nodes.Sum(n => n.Profit);
        }
    }
}
