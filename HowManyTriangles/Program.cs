using System;
using System.Collections.Generic;
using System.Linq;

namespace HowManyTriangles
{
    static class Riddles
    {
        public static Line[] Riddle1
        {
            get
            {
                return new Line[] {
                    new Line(new List<int>(){ 1, 4, 5}),
                    new Line(new List<int>(){ 1, 9, 11, 6}),
                    new Line(new List<int>(){ 1, 8, 10, 7}),
                    new Line(new List<int>(){ 1, 2, 3}),
                    new Line(new List<int>(){ 2, 8, 9, 4}),
                    new Line(new List<int>(){ 2, 10, 11, 5}),
                    new Line(new List<int>(){ 5, 6, 7, 3})
                };
            }
        }
        public static Line[] Riddle2
        {
            get
            {
                return new Line[]
                {
                    new Line(new List<int>(){ 1,2 ,3 ,4 ,5}),
                    new Line(new List<int>(){ 1,9 ,8 ,7 ,6}),
                    new Line(new List<int>(){ 1,10,11,12,13}),
                    new Line(new List<int>(){ 1,17,16,15,14}),
                    new Line(new List<int>(){ 2,9,10,17}),
                    new Line(new List<int>(){ 3,8,11,16}),
                    new Line(new List<int>(){ 4,7,12,15}),
                    new Line(new List<int>(){ 5,6,13,14})
                };
            }
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var edges = Riddles.Riddle1.SelectMany(l => l.ToEdges()).ToList();
            // Uncomment for a different riddle:
            //var edges = Riddles.Riddle2.SelectMany(l => l.ToEdges()).ToList();

            // Debugging:
            //PrintLines(edges);

            HashSet<Triangle> trianglesFound = new HashSet<Triangle>();

            foreach (Edge e1 in edges)
            {
                foreach (Edge e2 in edges)
                {
                    if (e1 == e2)
                    {
                        continue;
                    }
                    foreach (Edge e3 in edges)
                    {
                        if (e1 == e3 || e2 == e3)
                        {
                            continue;
                        }
                        if (FormsATriangle(e1, e2, e3))
                        {
                            trianglesFound.Add(new Triangle(e1, e2, e3));
                        }
                    }
                }
            }

            PrintResult(trianglesFound);
        }

        private static void PrintLines(List<Edge> edges)
        {
            var sorted = edges.OrderBy(e => e.IsLine);
            foreach (var e in sorted)
            {
                Console.WriteLine($"{e} ({(e.IsLine ? "Line" : "Edge")})");
            }
        }

        private static void PrintResult(HashSet<Triangle> found)
        {
            int i = 0;
            foreach (Triangle t in found)
            {
                Console.WriteLine($"{++i} : {t}");

            }
        }

        private static bool ConnectsInOrder(Edge e1, Edge e2)
        {
            return e1.B == e2.A;
        }

        private static bool FormsATriangle(Edge e1, Edge e2, Edge e3)
        {
            if (e1.IsConcatOf(e2, e3))
            {
                return false;
            }
            if (e2.IsConcatOf(e1, e3))
            {
                return false;
            }
            if (e3.IsConcatOf(e2, e1))
            {
                return false;
            }
            return (e1.B == e2.A && e2.B == e3.A && e3.B == e1.A) ||
                   (e1.A == e2.A && e2.B == e3.A && e3.B == e1.B) ||
                   (e1.B == e2.B && e2.A == e3.A && e3.B == e1.A) ||
                   (e1.A == e2.B && e2.A == e3.A && e3.B == e1.B) ||
                   (e1.B == e2.A && e2.B == e3.B && e3.A == e1.A) ||
                   (e1.A == e2.A && e2.B == e3.B && e3.A == e1.B) ||
                   (e1.B == e2.B && e2.A == e3.B && e3.A == e1.A) ||
                   (e1.A == e2.B && e2.A == e3.B && e3.A == e1.B);
        }
    }
}
