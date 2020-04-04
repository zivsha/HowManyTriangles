namespace HowManyTriangles
{
    public class Triangle
    {
        public Triangle(Edge a, Edge b, Edge c)
        {
            A = a;
            B = b;
            C = c;
        }
        public Edge A { get; set; }
        public Edge B { get; set; }
        public Edge C { get; set; }
        public override string ToString()
        {
            return $"{A.ToStringEdge()}, {B.ToStringEdge()}, {C.ToStringEdge()}";
        }
        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            Triangle other = obj as Triangle;
            if (other == null)
            {
                return false;
            }
            return A == other.A && B == other.B && C == other.C ||
                A == other.A && B == other.C && C == other.B ||
                A == other.B && B == other.A && C == other.C ||
                A == other.B && B == other.C && C == other.A ||
                A == other.C && B == other.B && C == other.A ||
                A == other.C && B == other.A && C == other.B;
        }
        public override int GetHashCode()
        {
            return A.GetHashCode() ^ B.GetHashCode() ^ C.GetHashCode();
        }
    }
}
