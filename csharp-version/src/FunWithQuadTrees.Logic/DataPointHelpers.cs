using System;
using System.Collections.Generic;
using System.Linq;

namespace FunWithQuadTrees.Logic
{
    public static class DataPointHelpers
    {
        //private const decimal _epsilon = 0.000001f;

        /// <summary>
        /// Compares to another list of data points and returns true if they are identical
        /// </summary>
        /// <returns>True if both lists are identical</returns>
        public static bool Identical(this List<DataPoint> dataPoints1, List<DataPoint> dataPoints2)
        {
            if (dataPoints1.Count != dataPoints2.Count)
            {
                return false;
            }

            // Ensure that each collection is sorted then compare each index
            dataPoints1.Sort();
            dataPoints1.Sort();
            dataPoints2.Sort();

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
                return dataPoint1.Identical((DataPoint)obj);
            }

            return false;
        }

        /// <summary>
        /// Compares to another data point and returns true if it is identical
        /// </summary>
        /// <returns>True if both data points are identical</returns>
        public static bool Identical(this DataPoint dataPoint1, DataPoint dataPoint2)
        {
            return Compare(dataPoint1, dataPoint2) == 0;
        }

        /// <summary>
        /// Compares to another data point and returns true if it is identical
        /// </summary>
        /// <returns>True if both data points are identical</returns>
        public static int Compare(this DataPoint dataPoint1, DataPoint dataPoint2)
        {
            return Math.Abs(decimal.Compare(dataPoint1.X, dataPoint2.X)) +
                Math.Abs(decimal.Compare(dataPoint1.Y, dataPoint2.Y));
        }
    }
}
