using HowManyTriangles;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HowManyTrianglesApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IEnumerable<Line> riddle1 = Riddles.Riddle1;
            IEnumerable<Line> riddle2 = Riddles.Riddle2;
            IEnumerable<Line> riddle3 = Riddles.Riddle3;

            //Benchmark();

            HMTSolver solver = new HMTSolver(riddle3);
            IEnumerable<Triangle> result = solver.Solve();
            PrintResult(result);
        }

        private static void Benchmark()
        {
            List<long> runs = new List<long>();

            for (int i = 0; i < 100; i++)
            {
                HMTSolver solver = new HMTSolver(Riddles.Riddle3);
                System.Diagnostics.Stopwatch s = System.Diagnostics.Stopwatch.StartNew();
                IEnumerable<Triangle> result = solver.Solve();
                runs.Add(s.ElapsedMilliseconds);
            }
            Console.WriteLine($"Min:    {runs.Min()}");
            Console.WriteLine($"Max:    {runs.Max()}");
            Console.WriteLine($"Avg:    {runs.Average()}");
            Console.WriteLine($"Median: {runs.OrderBy(l => l).ElementAt(runs.Count / 2)}");
        }

        private static void PrintResult(IEnumerable<Triangle> found)
        {
            int i = 0;
            foreach (Triangle t in found)
            {
                Console.WriteLine($"{++i} : {t}");
            }
        }
    }
}
