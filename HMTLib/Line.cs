using System;
using System.Collections.Generic;
using System.Linq;

namespace HowManyTriangles
{
    public class Line : Edge
    {
        #region Constructors

        public Line(List<int> orderedNodesThatFormAline) :
            base(orderedNodesThatFormAline.First(), orderedNodesThatFormAline.Last())
        {
            int indicesCount = orderedNodesThatFormAline.Count;
            if (orderedNodesThatFormAline.Distinct().Count() != indicesCount)
            {
                throw new ArgumentException("The given list of indices are not a valid line");
            }
            IsLine = indicesCount > 2;
            Indices = orderedNodesThatFormAline;
        }

        public Line(Edge e1, Edge e2) : this(CreateFrom(e1, e2))
        {
        }

        #endregion //Constructors

        #region object overrides

        public override string ToString()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            bool first = true;
            foreach (int item in Indices)
            {
                sb.Append($"{(first ? "" : "-")}{item}");
                first = false;
            }
            return sb.ToString();
        }

        #endregion //object overrides

        #region Public API

        public List<Edge> ToEdges()
        {
            List<Edge> edges = new List<Edge>();
            for (int i = 2; i <= Indices.Count; i++)
            {
                foreach (IEnumerable<int> combination in Indices.FindConsecutiveGroups(x => true, i))
                {
                    edges.Add(new Line(combination.ToList()));
                }
            }
            return edges.Distinct().ToList();
        }

        public override bool IsConcatOf(Edge e1, Edge e2)
        {
            if (!IsLine)
            {
                return false;
            }

            if (!e1.ConnectedTo(e2)) //e1 and e2 cannot possibly form a line
            {
                return false;
            }

            if (Indices.Count != (e1.Indices.Count + e2.Indices.Count - 1))
            {
                return false;
            }

            if (!Indices.All(e2.Indices.Concat(e1.Indices).Distinct().Contains))
            {
                return false;
            }

            return true;
        }
        #endregion //Public API



        #region Private

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

        #endregion //Private
    }
}
