namespace FunWithQuadTrees.Logic
{
    public class Rectangle
    {
        public Rectangle() : this(x1: float.PositiveInfinity, y1: float.PositiveInfinity, x2: float.PositiveInfinity, y2: float.PositiveInfinity)
        {}

        public Rectangle(float x1, float y1, float x2, float y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }
        
        public Rectangle(DataPoint point1, DataPoint point2)
        {
            X1 = point1.X;
            Y1 = point1.Y;
            X2 = point2.X;
            Y2 = point2.Y;
        }

        public float X1 { get; }
        public float Y1 { get; }
        public float X2 { get; }
        public float Y2 { get; }
    }
}
