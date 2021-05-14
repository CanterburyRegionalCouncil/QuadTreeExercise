using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text.Json;

namespace FunWithQuadTrees.Logic
{
    /// <summary>
    /// Loads DataSets from text files containing an array of DataPoint serialised to Json
    /// </summary>
    public static class DataSetLoader
    {
        /// <summary>
        /// Loads a list of data points from a text json file
        /// </summary>
        /// <param name="filePath">The path to a text file containing an array of DataPoint serialised to Json</param>
        /// <returns>A deserialised list of DataPoints</returns>
        /// <exception cref="DataException" />
        public static List<DataPoint> ReadDataPoints(string filePath)
        {
            string jsonData;

            try
            {
                // Read the file to Json
                using (var sr = new StreamReader(filePath))
                {
                    // Read the stream as a string, and write the string to the console.
                    jsonData = sr.ReadToEnd();
                }
            }
            catch (IOException ex)
            {
                throw new DataException("Can't open input stream", ex);
            }

            return DeserialiseDataPoints(jsonData);
        }

        public static List<DataPoint> DeserialiseDataPoints(string jsonData)
        {
            try
            {
                return JsonSerializer.Deserialize<List<DataPoint>>(jsonData);
            }
            catch (SerializationException ex)
            {
                throw new DataException(ex.Message, ex);
            }
        }
    }
}
