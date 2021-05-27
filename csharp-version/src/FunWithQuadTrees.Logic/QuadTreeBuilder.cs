using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithQuadTrees.Logic
{
    public static class QuadTreeBuilder
    {
        public static QuadTree AddLeaf(this QuadTree quadTree, DataPoint leaf)// IList<DataPoint> datapoints)
        {            
            quadTree.Leaves.Add(leaf);

            // If over capacity...
            if (quadTree.IsOverCapacity())
                quadTree.Split();

            return quadTree;
        }

        public static bool IsOverCapacity(this QuadTree quadTree, int capacity = Constants.DefaultCapacity)
            => quadTree.Leaves.Count > capacity;

        /// <summary>
        /// Our QuadTree is over capacity so it needs to be split up
        /// </summary>
        /// <remarks>Always takes a quadtree with no children and creates 4 children</remarks>
        /// <param name="quadTree">The quad tree to split</param>
        public static void Split(this QuadTree quadTree)
        {
            quadTree.InitialiseChildren();
            quadTree.DistributeLeaves();
        }

        /// <summary>
        /// Takes the children of 
        /// </summary>
        /// <param name="quadTree"></param>
        public static void DistributeLeaves(this QuadTree quadTree)
        {
            // We have split. Now we need to determine where our leaves go

        }

        /// <summary>
        /// Instantiates children
        /// </summary>
        /// <param name="quadTree">The QuadTree to initialise</param>
        public static void InitialiseChildren(this QuadTree quadTree)
        {
            var northEast = quadTree.GetNorthEast();
            var southEast = quadTree.GetSouthEast();
            var southWest = quadTree.GetSouthWest();
            var northWest = quadTree.GetNorthWest();

            var mid = new DataPoint(_x: northEast.X - southWest.X, _y: northEast.Y - southWest.Y);

            quadTree.NorthEast = new QuadTree(mid, northEast);
            quadTree.SouthEast = new QuadTree(mid, southEast);
            quadTree.SouthWest = new QuadTree(mid, southWest);
            quadTree.NorthWest = new QuadTree(mid, northWest);
        }
    }
}
