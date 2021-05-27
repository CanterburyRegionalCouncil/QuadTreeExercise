using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FunWithQuadTrees.Logic;

namespace FunWithQuadTrees.Testing
{
    public class QuadTreeBuilderTests
    {
        [Fact]
        public void QuadTreeBuilderConstructsSimpleCase()
        {
            // Act
            var quadTree = new QuadTree(0, 0, 100, 100);// { Leaves = new List<DataPoint>() };

            // Assert
            Assert.Null(quadTree.Leaves);
            Assert.NotEmpty(quadTree.Leaves);
        }

        [Fact]
        public void DistributeLeavesShallAlwaysSetLeavesNull()
        {
            // Arrange
            var quadTree = new QuadTree(0, 0, 100, 100);// { Leaves = new List<DataPoint>() };

            // Act
            quadTree.DistributeLeaves();

            // Assert
            Assert.Null(quadTree.Leaves);
        }
    }
}
