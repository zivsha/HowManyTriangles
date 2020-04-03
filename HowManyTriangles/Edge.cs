using System;

namespace HowManyTriangles
{
    internal class Edge
    {
        public bool IsLine { get; set; } = false;

        public Edge(int a, int b)
        {
            Assign(a, b);
        }

        public Edge(Edge other) : this(other.A, other.B)
        {
        }

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

        public int A { get; set; }

        public int B { get; set; }

        public virtual bool Holds(int i)
        {
            return A == i || B == i;
        }

        public virtual bool ConnectedTo(Edge e)
        {
            return Holds(e.A) || Holds(e.B);
        }

        public override string ToString()
        {
            return $"{A}-{B}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Edge other))
            {
                return false;
            }
            return A.Equals(other.A) && B.Equals(other.B);
        }

        public override int GetHashCode()
        {
            return A ^ B;
        }

        //public virtual int CompareTo(Edge other)
        //{
        //    if (Equals(other))
        //    {
        //        return 0;
        //    }
        //    if (A == other.A)
        //    {
        //        return B - other.B;
        //    }
        //    return A - other.B;
        //}

        internal virtual bool IsConcatOf(Edge e1, Edge e2)
        {
            return false;
        }
    }
}
