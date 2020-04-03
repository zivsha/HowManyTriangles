using System;
using System.Collections.Generic;
using System.Linq;

namespace HowManyTriangles
{
    internal class Line : Edge
    {
        public List<int> _pointsOnEdge = new List<int>();

        public Line(List<int> orderedNodesThatFormAline) : 
            base(orderedNodesThatFormAline.First(), orderedNodesThatFormAline.Last())
        {
            A = orderedNodesThatFormAline.First();
            B = orderedNodesThatFormAline.Last();
            IsLine = orderedNodesThatFormAline.Count > 2;
            _pointsOnEdge = orderedNodesThatFormAline.Distinct().ToList();
        }

        public override bool Holds(int i)
        {
            return _pointsOnEdge.Contains(i);
        }

        public Line(Edge e1, Edge e2) : this(CreateFrom(e1, e2))
        {
        }

        public List<Edge> ToEdges()
        {
            List<Edge> edges = new List<Edge>();
            for (int i = 2; i <= _pointsOnEdge.Count; i++)
            {
                foreach (IEnumerable<int> combination in _pointsOnEdge.FindConsecutiveGroups(x => true, i))
                {
                    edges.Add(new Line(combination.ToList()));
                }
            }
            return edges.Distinct().ToList();
        }

        private static List<int> CreateFrom(Edge e1, Edge e2)
        {
            if (e1.A == e2.A)
            {
                return new List<int>() { e1.B, e1.A, e2.B };
            }
            else if (e1.A == e2.B)
            {
                return new List<int>() { e1.B, e1.A, e2.A };
            }
            else if (e1.B == e2.A)
            {
                return new List<int>() { e1.A, e1.B, e2.B };
            }
            else if (e1.B == e2.B)
            {
                return new List<int>() { e1.A, e1.B, e2.A };
            }
            else
            {
                throw new ArgumentException($"{e1} is not connected to {e2}");
            }
        }

        internal override bool IsConcatOf(Edge e1, Edge e2)
        {
            if (!e1.ConnectedTo(e2))
            {
                return false;
            }

            return Holds(e1.A) &&
                   Holds(e1.B) &&
                   Holds(e2.A) &&
                   Holds(e2.B);
        }
    }
}
