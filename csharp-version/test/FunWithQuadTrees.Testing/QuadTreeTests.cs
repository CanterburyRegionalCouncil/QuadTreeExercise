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
        [Theory]
        [ClassData(typeof(DataSetTestData))]
        public void QuadTreeIntersectionProcessorShallReturnExpectedIntersection(List<DataPoint> testDataSet, List<DataPoint> expectedResult)
        {
            // Arrange
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

        [Theory]
        [ClassData(typeof(DataSetTestData))]
        public void BruteForceCheckShallReturnExpectedIntersection(List<DataPoint> testDataSet, List<DataPoint> expectedResult)
        {
            // Arrange
            Rectangle rect = new Rectangle(-0.1m, -0.1m, 0.1m, 0.1m);

            // Act
            // Simply compare to pick out points within our target x and y ranges
            List<DataPoint> actualResult = testDataSet
                .Where(i => i.X > -0.1m && i.X < 0.1m &&
                    i.Y > -0.1m && i.Y < 0.1m)
                .ToList();

            // Assert
            Assert.True(actualResult.Identical(expectedResult));
        }

        private class DataSetTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                // Add test fixtures in-line within code
                yield return new object[]
                {
                    new List<DataPoint>(){
                        new DataPoint(-0.2m, -0.2m),
                        new DataPoint(-0.099m, -0.098m),
                        new DataPoint(0m, 0m),
                        new DataPoint(0.097m, 0.099m),
                        new DataPoint(0.2m, 0.3m),
                        new DataPoint(200m, 400m),
                    },
                    new List<DataPoint>(){
                        new DataPoint(-0.099m, -0.098m),
                        new DataPoint(0m, 0m),
                        new DataPoint(0.097m, 0.099m),
                    }
                };
                // Or add test fixtures by loading from json test files
                yield return new object[] 
                { 
                    DataSetLoader.ReadDataPoints("InputDataSet.json"),
                    DataSetLoader.ReadDataPoints("ExpectedDataSet.json")
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
