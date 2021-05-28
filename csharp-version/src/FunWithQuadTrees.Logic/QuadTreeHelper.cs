using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithQuadTrees.Logic
{
    public static class QuadTreeHelper
    {
        public static void AddLeaf(this QuadTree quadTree, decimal x, decimal y)
        {
            quadTree.Leaves.Add(new DataPoint(x, y));
        }

        public static void AddLeaf(this QuadTree quadTree, DataPoint leaf)
        {
            // Ensure that the leaf falls within our scope
            if (!quadTree.ContainsPoint(leaf)) throw new Exception($"Leaf {leaf.X}, {leaf.X} does not fall within our scope");

            if (quadTree.HasSplit)
                // Pass the leaf on to our child QuadTrees
                AddLeafDownTree(quadTree, leaf);
            else
            {
                quadTree.Leaves.Add(leaf);

                // If over capacity...
                if (IsOverCapacity(quadTree))
                    Split(quadTree);
            }
        }

        public static void AddLeafDownTree(this QuadTree quadTree, DataPoint leaf)
        {
            // What quad does the leaf fall into?
            var allChildren = quadTree.GetAllChildren();

            foreach (var child in allChildren)
            {
                if (child.ContainsPoint(leaf))
                {
                    child.AddLeaf(leaf);
                    return;
                }
            }

            throw new Exception($"Leaf {leaf.X}, {leaf.X} did not find a child node :/");
        }

        public static bool IsOverCapacity(this QuadTree quadTree)
            => quadTree.Leaves.Count > quadTree.Capacity;

        /// <summary>
        /// Our QuadTree is over capacity so it needs to be split up
        /// </summary>
        /// <remarks>Always takes a quadtree with no children and creates 4 children</remarks>
        /// <param name="quadTree">The quad tree to split</param>
        public static void Split(this QuadTree quadTree)
        {
            if (quadTree.HasSplit) return; // Nothing to do here

            quadTree.InitialiseChildren();
            DistributeLeaves(quadTree);
        }

        /// <summary>
        /// Moves all leaves to child QuadTrees
        /// </summary>
        /// <param name="quadTree"></param>
        public static void DistributeLeaves(this QuadTree quadTree)
        {
            // We have split. Now we need to determine where our leaves go
            foreach (var leaf in quadTree.Leaves)
            {
                AddLeafDownTree(quadTree, leaf);
            }

            // Now clear the leaves list
            quadTree.Leaves = null;
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

            quadTree.NorthEast = new QuadTree(mid, northEast, quadTree.Capacity);
            quadTree.SouthEast = new QuadTree(mid, southEast, quadTree.Capacity);
            quadTree.SouthWest = new QuadTree(mid, southWest, quadTree.Capacity);
            quadTree.NorthWest = new QuadTree(mid, northWest, quadTree.Capacity);
        }

        public static List<QuadTree> GetAllChildren(this QuadTree quadTree)
        {
            if (quadTree.NorthEast == null) return new List<QuadTree>();

            return new List<QuadTree>
            {
                quadTree.NorthEast,
                quadTree.SouthEast,
                quadTree.SouthWest,
                quadTree.NorthWest
            };
        }
    }
}
