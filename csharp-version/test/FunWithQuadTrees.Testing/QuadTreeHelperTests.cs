using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FunWithQuadTrees.Logic;

namespace FunWithQuadTrees.Testing
{
    public class QuadTreequadTreeTests
    {
        [Fact]
        public void AddSingleLeafShallPopulateLeavesProperty()
        {
            // Arrange
            var quadTree = new QuadTree();

            // Act
            quadTree.AddLeaf(new DataPoint());

            // Assert
            Assert.NotNull(quadTree);
            Assert.NotNull(quadTree.Leaves);
            Assert.Single(quadTree.Leaves);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(10)]
        [InlineData(20)]
        public void SplitShallAlwaysSetLeavesNull(int numberOfLeaves)
        {
            // Arrange
            var quadTree = new QuadTree(numberOfLeaves * 2); // We need to stay under capacity for this test

            for (int i = 0; i < numberOfLeaves; i++)
            {
                quadTree.AddLeaf(new DataPoint());
            }

            // Act
            quadTree.Split();

            // Assert
            Assert.Null(quadTree.Leaves);
        }

        [Fact]
        public void SplitShallInitialiseChildren()
        {
            // Arrange
            var quadTree = new QuadTree();

            // Act
            quadTree.Split();

            // Assert
            Assert.NotNull(quadTree.NorthEast);
            Assert.NotNull(quadTree.SouthEast);
            Assert.NotNull(quadTree.SouthWest);
            Assert.NotNull(quadTree.NorthWest);
        }

        [Fact]
        public void AddLeavesOverCapacityShallResultInSplit()
        {
            // Arrange
            var quadTree = new QuadTree();

            // Act
            quadTree.Split();

            // Assert
            Assert.NotNull(quadTree.NorthEast);
            Assert.NotNull(quadTree.SouthEast);
            Assert.NotNull(quadTree.SouthWest);
            Assert.NotNull(quadTree.NorthWest);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(-5)]
        public void CapacityShallPassToChildrenOnSplit(int capacity)
        {
            // Arrange
            var quadTree = new QuadTree(capacity: capacity);

            // Act
            quadTree.Split();

            // Assert
            var allChildren = quadTree.GetAllChildren();
            Assert.True(allChildren.All(i => i.Capacity == capacity));
        }
    }
}
