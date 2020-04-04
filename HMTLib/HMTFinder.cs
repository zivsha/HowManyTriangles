using System.Collections.Generic;
using System.Linq;

namespace HowManyTriangles
{
    public class HMTSolver
    {
        public IEnumerable<Line> Edges { get; private set; }

        public HMTSolver(IEnumerable<Line> lines)
        {
            Edges = lines.SelectMany(l => l.ToEdges()).ToList(); //Materialize here is important (for performance and also correctness)

            // Debugging:
            //PrintEdges(Edges);
        }

        public IEnumerable<Triangle> Solve()
        {
            HashSet<Triangle> trianglesFound = new HashSet<Triangle>();

            foreach (Line l1 in Edges)
            {
                foreach (Line l2 in Edges)
                {
                    if (l1 == l2)
                    {
                        continue;
                    }
                    foreach (Line l3 in Edges)
                    {
                        if (l1 == l3 || l2 == l3)
                        {
                            continue;
                        }
                        if (FormsATriangle(l1, l2, l3))
                        {
                            trianglesFound.Add(new Triangle(l1, l2, l3));
                        }
                    }
                }
            }
            return trianglesFound;
        }

        private static bool FormsATriangle(Line e1, Line e2, Line e3)
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

        private static void PrintEdges(IEnumerable<Line> edges)
        {
            foreach (Line e in edges)
            {
                System.Console.WriteLine($"{e}");
            }
        }
    }
}
