using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HowManyTriangles
{
    public class Edge : IEnumerable<int>
    {
        public bool IsLine { get { return Indices.Count > 2; } }
        public List<int> Indices { get; protected set; }

        public Edge()
        {
            Indices = new List<int>();
        }

        public Edge(int a, int b)
        {
            Indices = new List<int>() { a, b };
        }

        public string ToStringEdge()
        {
            return $"{A}-{B}";
        }

        public Edge(Edge other) : this(other.A, other.B)
        {
        }

        #region Public API

        public int A { get { return Indices[0]; } }
        public int B { get { return Indices[Indices.Count-1]; } }

        public virtual bool Holds(int i)
        {
            return Indices.Contains(i);
        }
        public virtual bool ConnectedTo(Edge e)
        {
            return Holds(e.A) || Holds(e.B);
        }

        public virtual bool IsConcatOf(Edge e1, Edge e2)
        {
            return false;
        }

        #endregion //Public API



        #region object overrides

        public override string ToString()
        {
            return ToStringEdge();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Edge other))
            {
                return false;
            }
            return Indices.SequenceEqual(other.Indices);
        }

        public override int GetHashCode()
        {
            return Indices.GetHashCode();
        }
        public void Add(int i)
        {
            Indices.Add(i);
        }
        #endregion //object overrides



        #region Private

        public IEnumerator<int> GetEnumerator()
        {
            return Indices.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Indices.GetEnumerator();
        }

        #endregion //Private
    }
}
