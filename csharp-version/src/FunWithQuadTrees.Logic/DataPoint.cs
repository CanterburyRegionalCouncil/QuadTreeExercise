using System;

namespace FunWithQuadTrees.Logic
{
    public class DataPoint : IComparable
	{
		public decimal X { get; set; }
		public decimal Y { get; set; }

		public DataPoint() { }

		public DataPoint(decimal _x, decimal _y)
		{
            X = _x;
            Y = _y;
        }

        public int CompareTo(object obj)
        {
            DataPoint other = obj as DataPoint;

			if (other == null) throw new Exception($"{nameof(obj)} needs to be of type {nameof(DataPoint)} when making a comparison");

            return this.Compare(other);
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
