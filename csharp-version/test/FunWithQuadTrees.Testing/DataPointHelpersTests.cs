using FunWithQuadTrees.Logic;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace FunWithQuadTrees.Testing
{
    /// <summary>
    /// Tests to ensure that our <see cref="DataPointHelpersTests"/> comparisons are correct
    /// </summary>
    public class DataPointHelpersTests
    {
        [Theory]
        [ClassData(typeof(DataPointTestData))]
        public void DataPointIdenticalShallReturnAsExpected(DataPoint dataPoint1, DataPoint dataPoint2, bool expectedResult)
        {
            // Act
            var actualResult = dataPoint1.Identical(dataPoint2);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void NonDataPointComparisonShallReturnFalse()
        {
            // Arrange
            DataPoint dataPoint1 = new DataPoint();
            object obj = new object();

            // Act
            var actualResult = dataPoint1.Identical(obj);

            // Assert
            Assert.False(actualResult);
        }

        private class DataPointTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new DataPoint(), new DataPoint(), true };
                yield return new object[] { new DataPoint(1, 1), new DataPoint(0, 0), false };
                yield return new object[] { new DataPoint(1, 1), new DataPoint(-1, -1), false };
                yield return new object[] { new DataPoint(1, 1), new DataPoint(1, 1), true };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        [Theory]
        [ClassData(typeof(DataPointsTestData))]
        public void DataPointsIdenticalShallReturnAsExpected(List<DataPoint> dataPoints1, List<DataPoint> dataPoints2, bool expectedResult)
        {
            // Act
            var actualResult = dataPoints1.Identical(dataPoints2);

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        private class DataPointsTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                    {
                        new List<DataPoint>{},
                        new List<DataPoint>{},
                        true
                    };
                yield return new object[] 
                    { 
                        new List<DataPoint>{
                            new DataPoint()
                        },
                        new List<DataPoint>{
                            new DataPoint()
                        }, 
                        true 
                    };
                yield return new object[]
                    {
                        new List<DataPoint>{
                            new DataPoint()
                        },
                        new List<DataPoint>{
                            new DataPoint(),
                            new DataPoint(),
                        },
                        false
                    };
                yield return new object[]
                    {
                        new List<DataPoint>{
                            new DataPoint(),
                            new DataPoint()
                        },
                        new List<DataPoint>{
                            new DataPoint(),
                        },
                        false
                    };
                yield return new object[]
                    {
                        new List<DataPoint>{
                            new DataPoint(1, 1)
                        },
                        new List<DataPoint>{
                            new DataPoint(1, 1),
                        },
                        true
                    };
                yield return new object[]
                    {
                        new List<DataPoint>{
                            new DataPoint(1, 1)
                        },
                        new List<DataPoint>{
                            new DataPoint(0, 0),
                        },
                        false
                    };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
