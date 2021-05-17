using FunWithQuadTrees.Logic;
using System.Linq;
using Xunit;

namespace FunWithQuadTrees.Testing
{
    /// <summary>
    /// We need to ensure that our test data sets are loading correctly
    /// </summary>
    public class DataSetLoaderTests
    {
        [Theory]
        // Arrange
        // Note differing case so that we can deserialise to upper-case property names and follow standard naming convensions
        [InlineData("[{\"x\": -0.0461572, \"y\": -0.0461572}]", -0.0461572, -0.0461572)]
        [InlineData("[{\"X\": -0.0461572, \"Y\": -0.0461572}]", -0.0461572, -0.0461572)]
        public void JsonShallDeserialiseAsExpected(string json, float expectedX, float expectedY)
        {
            // Act
            var dataPoints = DataSetLoader.DeserialiseDataPoints(json);

            // Assert
            Assert.NotNull(dataPoints);
            Assert.Single(dataPoints);
            var targetDataPoint = dataPoints.First();
            Assert.Equal(expectedX, targetDataPoint.X);
            Assert.Equal(expectedY, targetDataPoint.Y);
        }

        [Theory]
        // Arrange
        [InlineData(0, 0, 0)]
        [InlineData(1, 3.1415876E-8, 3.1415876E-8)]
        [InlineData(2, 1.2566288E-7, 1.2566288E-7)]
        public void ExpectedDataSetLoadsAndHasExpectedValues(int index, float expectedX, float expectedY)
        {
            // Act
            var expected_dataset = DataSetLoader.ReadDataPoints("ExpectedDataSet.json");

            // Assert
            Assert.NotNull(expected_dataset);
            Assert.NotEmpty(expected_dataset);
            var targetDataPoint = expected_dataset[index];
            Assert.Equal(expectedX, targetDataPoint.X);
            Assert.Equal(expectedY, targetDataPoint.Y);
        }
    }
}
