using System;
using System.Collections.Generic;

namespace FunWithQuadTrees.Logic
{
    public static class DataPointHelpers
    {
        private const float _epsilon = 0.000001f;

        /// <summary>
        /// Compares to another list of data points and returns true if they are identical
        /// </summary>
        /// <returns>True if both lists are identical</returns>
        public static bool Identical(this IList<DataPoint> dataPoints1, IList<DataPoint> dataPoints2)
        {
            if (dataPoints1.Count != dataPoints2.Count)
            {
                return false;
            }

            for (int i = 0; i < dataPoints1.Count; i++)
            {
                if (!dataPoints1[i].Identical(dataPoints2[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Compares to another data point and returns true if it is identical
        /// </summary>
        /// <returns>True if both data points are identical</returns>
        public static bool Identical(this DataPoint dataPoint1, object obj)
        {
            if (obj.GetType() == typeof(DataPoint))
            {
                var dataPoint2 = (DataPoint)obj;
                return Math.Abs(dataPoint1.X - dataPoint2.X) < _epsilon
                && Math.Abs(dataPoint1.Y - dataPoint2.Y) < _epsilon;
            }

            return false;
        }
    }
}
