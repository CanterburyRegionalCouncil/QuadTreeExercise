using System;
using System.Collections;
using System.Collections.Generic;
using FunWithQuadTrees.Logic;
using Xunit;

namespace FunWithQuadTrees.Testing
{
    /// <summary>
    /// Tests to ensure that <see cref="DataPoint.CompareTo(object)" /> returns correctly
    /// </summary>
    public class DataPointCompareToTests
    {
        [Fact]
        public void ComparingToADifferentTypeShallThrowException()
        {
            // Arrange
            DataPoint dataPoint = new DataPoint();
            object obj = new object();

            // Act and Assert
            Assert.Throws<Exception>(() => dataPoint.CompareTo(obj));
        }


        [Theory]
        [ClassData(typeof(DataPointTestData))]
        public void DataPointCompareToShallReturnAsExpected(DataPoint dataPoint1, DataPoint dataPoint2, bool expectZero)
        {
            // Act
            var actualResult = dataPoint1.CompareTo(dataPoint2);

            // Assert
            if(expectZero)
                Assert.Equal(0, actualResult);
            else
                Assert.NotEqual(0, actualResult);
        }

        private class DataPointTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new DataPoint(), new DataPoint(), true };
                yield return new object[] { new DataPoint(1, 1), new DataPoint(0, 0), false };
                //yield return new object[] { new DataPoint(1, 1), new DataPoint(-1, -1), true }; // Compare squares X and Y so negative makes no difference
                yield return new object[] { new DataPoint(1, 1), new DataPoint(-2, -2), false }; 
                yield return new object[] { new DataPoint(1, 1), new DataPoint(1, 1), true };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
