using FunWithQuadTrees.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FunWithQuadTrees.Testing
{
    public class QuadTreeTests
    {
        [Fact]
        public void QuadTreeIntersectionProcessorShallReturnExpectedIntersection()
        {
            // Arrange
            List<DataPoint> testDataSet = DataSetLoader.ReadDataPoints("InputDataSet.json");
            List<DataPoint> expectedResult = DataSetLoader.ReadDataPoints("ExpectedDataSet.json");
            Rectangle rect = new Rectangle(-0.1m, -0.1m, 0.1m, 0.1m);

            // Act
            List<DataPoint> actualResult = GetIntersectedSetUsingQuadTree(testDataSet, rect);
            
            // Assert
            Assert.True(actualResult.Identical(expectedResult));
        }

        private List<DataPoint> GetIntersectedSetUsingQuadTree(IList<DataPoint> dataset, Rectangle rect)
        {
            // Return the data points that are in the rectangle
            throw new NotImplementedException();
        }
    }
}
