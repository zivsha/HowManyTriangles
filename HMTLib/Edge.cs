using System;
using System.Collections.Generic;
using System.Linq;

namespace HowManyTriangles
{
    public class Edge
    {
        public bool IsLine { get; protected set; }
        public List<int> Indices { get; protected set; }

        public Edge(int a, int b)
        {
            Assign(a, b);
            Indices = new List<int>() { A, B };
            IsLine = false;
        }

        public string ToStringEdge()
        {
            return $"{A}-{B}";
        }

        public Edge(Edge other) : this(other.A, other.B)
        {
        }

        #region Public API

        public int A { get; private set; }

        public int B { get; private set; }
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

        #endregion //object overrides



        #region Private

        private void Assign(int a, int b)
        {
            if (a < b)
            {
                A = a;
                B = b;
            }
            else if (a > b)
            {
                A = b;
                B = a;
            }
            else
            {
                throw new ArgumentException("Cannot assign esge with a single point");
            }
        }

        #endregion //Private
    }
}
