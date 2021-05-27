using System;
using System.Collections.Generic;

namespace FunWithQuadTrees.Logic
{
	/// <summary>
	/// Implementation of the Quad Tree algorithm
	/// </summary>
	/// <remarks>https://en.wikipedia.org/wiki/Quadtree</remarks>
    public class QuadTree : Rectangle
	{
		public QuadTree(float x1, float y1, float x2, float y2) : base(x1, y1, x2, y2)
		{
		}

		public QuadTree(DataPoint point1, DataPoint point2) : base(point1, point2)
        {

        }

		/// <summary>
		/// The top right corner's child node
		/// </summary>
		public QuadTree NorthEast { get; set; }

		/// <summary>
		/// The bottom right corner's child node
		/// </summary>
		public QuadTree SouthEast { get; set; }

		/// <summary>
		/// The bottom left corner's child node
		/// </summary>
		public QuadTree NorthWest { get; set; }

		/// <summary>
		/// The top left corner's child node
		/// </summary>
		public QuadTree SouthWest { get; set; }

        //public Rectangle Scope { get; }

        public IList<DataPoint> Leaves = new List<DataPoint>();

        public static QuadTree ConstructFrom(IList<DataPoint> datapoints)
		{
			throw new NotImplementedException();
		}

		public void Intersect(Rectangle rectangle, IQuadTreeIntersectionProcessor quadTreeIntersectionProcessor)
		{
			throw new NotImplementedException();
		}
	}
}
