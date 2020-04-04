using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HowManyTriangles
{
    public class Line : IEnumerable<int>
    {
        #region Constructors

        public Line()
        {
            Indices = new List<int>();
        }

        public Line(Line other)
        {
            Indices = new List<int>(other.Indices);
        }

        #endregion //Constructors

        #region Properties

        public int A 
        { 
            get 
            { 
                return Indices[0]; 
            } 
        }

        public int B 
        { 
            get
            { 
                return Indices[Indices.Count - 1]; 
            } 
        }

        public List<int> Indices { get; protected set; }

        #endregion //Properties

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

        public override bool Equals(object obj)
        {
            if (!(obj is Line other))
            {
                return false;
            }
            return Indices.SequenceEqual(other.Indices);
        }

        public override int GetHashCode()
        {
            return Indices.GetHashCode();
        }

        #endregion //object overrides

        #region Public API

        public string ToStringAsEdge()
        {
            return $"{A}-{B}";
        }

        public virtual bool Holds(int i)
        {
            return Indices.Contains(i);
        }

        public virtual bool ConnectedTo(Line line)
        {
            return Holds(line.A) || Holds(line.B);
        }

        public List<Line> ToEdges()
        {
            List<Line> edges = new List<Line>();
            for (int i = 2; i <= Indices.Count; i++)
            {
                foreach (IEnumerable<int> combination in Indices.FindConsecutiveGroups(x => true, i))
                {
                    edges.Add(new Line() { combination });
                }
            }
            return edges.Distinct().ToList();
        }

        public virtual bool IsConcatOf(Line e1, Line e2)
        {
            if (Indices.Count < 3)
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

        #region IEnumerable Related
        public IEnumerator<int> GetEnumerator()
        {
            return Indices.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Indices.GetEnumerator();
        }

        public void Add(int i)
        {
            Indices.Add(i);
        }

        public void Add(IEnumerable<int> indices)
        {
            Indices.AddRange(indices);
        }
        #endregion //IEnumerable Related
    }
}
