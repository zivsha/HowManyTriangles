using System.Collections.Generic;
using System.Linq;

namespace HowManyTriangles
{
    public class HMTSolver
    {
        public IEnumerable<Edge> Edges { get; private set; }

        public HMTSolver(IEnumerable<Line> lines)
        {
            Edges = lines.SelectMany(l => l.ToEdges()).ToList(); //Materialize here is important (for performance and also correctness)

            // Debugging:
            //PrintEdges(Edges);
        }

        public IEnumerable<Triangle> Solve()
        {
            HashSet<Triangle> trianglesFound = new HashSet<Triangle>();

            foreach (Edge e1 in Edges)
            {
                foreach (Edge e2 in Edges)
                {
                    if (e1 == e2)
                    {
                        continue;
                    }
                    foreach (Edge e3 in Edges)
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
            return trianglesFound;
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

        private static void PrintEdges(IEnumerable<Edge> edges)
        {
            IOrderedEnumerable<Edge> sorted = edges.OrderBy(e => e.IsLine);
            foreach (Edge e in sorted)
            {
                System.Console.WriteLine($"{e} ({(e.IsLine ? "Line" : "Edge")})");
            }
        }
    }
}
