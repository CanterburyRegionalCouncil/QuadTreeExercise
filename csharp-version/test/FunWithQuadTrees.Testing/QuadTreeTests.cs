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
            //List<DataPoint> actualResult = GetIntersectedSetUsingQuadTree(testDataSet, rect);
            
            //List<DataPoint> actualResult = testDataSet
            //    .Where(i => i.X > -0.1m && i.X < 0.1m)
            //    .Where(i => i.Y > -0.1m && i.Y < 0.1m)
            //    .ToList();

            List<DataPoint> actualResult = testDataSet
                .Where(i => i.X >= -0.1m && i.X <= 0.1m)
                .Where(i => i.Y >= -0.1m && i.Y <= 0.1m)
                .ToList();

            //actualResult.Sort();

            //var unexpectedResult = expectedResult
            //    .Where(i => i.X < -0.1m || i.X > 0.1m ||
            //        i.Y < -0.1m || i.Y > 0.1m)
            //    .ToList();

            //var expectedResultYDescending = expectedResult.OrderByDescending(i => i.Y).ToList();
            //var testDataSetYDescending = testDataSet.OrderByDescending(i => i.Y).ToList();

            // 25417 using > and <
            // 25417 using >= and <=

            // Assert
            Assert.True(actualResult.Identical(expectedResult));
        }

        private List<DataPoint> GetIntersectedSetUsingQuadTree(IList<DataPoint> dataset, Rectangle rect)
        {
            // Return the data points that are in the rectangle

            return dataset.Where(i => rect.ContainsPoint(i)).ToList();
        }

        private class DataSetTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                // Add test fixtures in-line within code
                //yield return new object[]
                //{
                //    new List<DataPoint>(),
                //    new List<DataPoint>()
                //};
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
