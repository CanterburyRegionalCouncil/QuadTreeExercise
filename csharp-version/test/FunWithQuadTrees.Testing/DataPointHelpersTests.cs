using FunWithQuadTrees.Logic;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace FunWithQuadTrees.Testing
{
    /// <summary>
    /// Tests to ensure that our <see cref="DataPointHelper"/> comparisons are correct
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

        [Fact]
        public void SortShallArrangeByXThenByY()
        {
            // Arrange
            var dataPointList = new List<DataPoint>{
                            new DataPoint(3, 2),
                            new DataPoint(3, 1),
                            new DataPoint(0, 0),
                        };

            // Act
            dataPointList.Sort();

            // Assert
            Assert.Equal(0, dataPointList[0].X); // We expect the 0, 0 to be first
            Assert.Equal(0, dataPointList[0].Y); // We expect the 0, 0 to be first
            Assert.Equal(3, dataPointList[1].X); // We expect the 3, 1 to be second
            Assert.Equal(1, dataPointList[1].Y); // We expect the 3, 1 to be second
            Assert.Equal(3, dataPointList[2].X); // We expect the 3, 2 to be second
            Assert.Equal(2, dataPointList[2].Y); // We expect the 3, 2 to be second
        }

        [Fact]
        public void SortShallPutNegativeValuesFirst()
        {
            // Arrange
            var dataPointList = new List<DataPoint>{
                            new DataPoint(3, 1),
                            new DataPoint(-1, -1),
                            new DataPoint(0, 0),
                        };

            // Act
            dataPointList.Sort();

            // Assert
            Assert.Equal(-1, dataPointList[0].X); // We expect the -1, -1 to be first
            Assert.Equal(-1, dataPointList[0].Y); // We expect the -1, -1 to be first
            Assert.Equal(0, dataPointList[1].X); // We expect the 0, 0 to be second
            Assert.Equal(0, dataPointList[1].Y); // We expect the 0, 0 to be second
            Assert.Equal(3, dataPointList[2].X); // We expect the 3, 2 to be second
            Assert.Equal(1, dataPointList[2].Y); // We expect the 3, 2 to be second
        }

        [Fact]
        public void SortingMultipleTimeShallReturnTheSameResult()
        {
            // Arrange
            var dataPointList = new List<DataPoint>{
                            new DataPoint(3, 1),
                            new DataPoint(-1, -1),
                            new DataPoint(0, 0),
                        };

            // Act
            dataPointList.Sort();
            dataPointList.Sort();

            // Assert
            Assert.Equal(-1, dataPointList[0].X); // We expect the -1, -1 to be first
            Assert.Equal(-1, dataPointList[0].Y); // We expect the -1, -1 to be first
            Assert.Equal(0, dataPointList[1].X); // We expect the 0, 0 to be second
            Assert.Equal(0, dataPointList[1].Y); // We expect the 0, 0 to be second
            Assert.Equal(3, dataPointList[2].X); // We expect the 3, 2 to be second
            Assert.Equal(1, dataPointList[2].Y); // We expect the 3, 2 to be second
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
