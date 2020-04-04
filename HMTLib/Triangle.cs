namespace HowManyTriangles
{
    public class Triangle
    {
        public Triangle(Line a, Line b, Line c)
        {
            A = a;
            B = b;
            C = c;
        }
        public Line A { get; set; }
        public Line B { get; set; }
        public Line C { get; set; }
        public override string ToString()
        {
            return $"{A.ToStringAsEdge()}, {B.ToStringAsEdge()}, {C.ToStringAsEdge()}";
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
