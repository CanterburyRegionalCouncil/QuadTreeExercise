using System;

namespace FunWithQuadTrees.Logic
{
    public class DataPoint : IComparable
	{
		public float X { get; set; }
		public float Y { get; set; }

		public DataPoint() { }

		public DataPoint(float _x, float _y)
		{
            X = _x;
            Y = _y;
        }

        public int CompareTo(object obj)
        {
            DataPoint other = obj as DataPoint;

			if (other == null) throw new Exception($"{nameof(obj)} needs to be of type {nameof(DataPoint)} when making a comparison");

			float r1 = (float)Math.Sqrt(this.X * this.X + this.Y * this.Y);
			float r2 = (float)Math.Sqrt(other.X * other.X + other.Y * other.Y);

			return r1.Equals(r2) ? 0 :
				r1 > r2 ? 1 : -1;
		}

        /// <summary>
        /// A human readable representation for debugging purposes
        /// </summary>
        /// <returns>A human readable representation</returns>
        public override string ToString()
        {
            return $"x: {X}, y: {Y}";
        }
    }
}
