namespace FunWithQuadTrees.Logic
{
    /// <summary>
    /// Encapsulates a Rectangle shape
    /// </summary>
    public class Rectangle
    {
        public Rectangle() : this(x1: decimal.MinValue, y1: decimal.MinValue, x2: decimal.MaxValue, y2: decimal.MaxValue)
        { }

        public Rectangle(decimal x1, decimal y1, decimal x2, decimal y2)
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

        public decimal X1 { get; }
        public decimal Y1 { get; }
        public decimal X2 { get; }
        public decimal Y2 { get; }
    }
}
