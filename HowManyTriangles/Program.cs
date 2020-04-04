using HowManyTriangles;
using System;
using System.Collections.Generic;

namespace HowManyTrianglesApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IEnumerable<Line> riddle1 = Riddles.Riddle1;
            IEnumerable<Line> riddle2 = Riddles.Riddle2;
            IEnumerable<Line> riddle3 = Riddles.Riddle3;

            HMTSolver solver = new HMTSolver(riddle3);
            IEnumerable<Triangle> result = solver.Solve();
            PrintResult(result);
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
