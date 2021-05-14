using FunWithQuadTrees.Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace FunWithQuadTrees.Testing
{
    public class QuadTreeTests
    {
        [Theory]
        [ClassData(typeof(DataSetTestData))]
        public void QuadTreeIntersectionProcessorShallReturnExpectedIntersection(IList<DataPoint> testDataSet, IList<DataPoint> expectedResult)
        {
            // Arrange
            Rectangle rect = new Rectangle(-0.1f, -0.1f, 0.1f, 0.1f);

            // Act
            List<DataPoint> actualResult = GetIntersectedSetUsingQuadTree(testDataSet, rect);
            actualResult.Sort();

            // Assert
            Assert.True(actualResult.Identical(expectedResult));
        }

        private List<DataPoint> GetIntersectedSetUsingQuadTree(IList<DataPoint> dataset, Rectangle rect)
        {
            throw new NotImplementedException();
        }

        private class DataSetTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                // Add test fixtures in-line within code
                yield return new object[]
                {
                    new List<DataPoint>(),
                    new List<DataPoint>()
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
