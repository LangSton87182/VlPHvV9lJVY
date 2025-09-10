// 代码生成时间: 2025-09-11 07:37:13
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace JsonDataConverterApp
{
    /// <summary>
    /// This class is responsible for converting JSON data formats.
    /// </summary>
    public class JsonDataConverter
    {
        /// <summary>
        /// Converts a JSON string to a dictionary of strings.
        /// </summary>
        /// <param name="jsonData">The JSON string to convert.</param>
        /// <returns>A dictionary representing the JSON data.</returns>
        /// <exception cref="JsonReaderException">Thrown when the JSON data is not valid.</exception>
        public static Dictionary<string, string> ConvertJsonStringToDictionary(string jsonData)
        {
            try
            {
                // Parse the JSON string into a JObject
                JObject jObject = JObject.Parse(jsonData);

                // Convert the JObject to a dictionary of strings
                var dictionary = jObject.ToObject<Dictionary<string, string>>();

                return dictionary;
            }
            catch (JsonReaderException ex)
            {
                // Handle the exception and rethrow if necessary
                throw new JsonReaderException("Invalid JSON data provided.", ex);
            }
        }

        /// <summary>
        /// Converts a dictionary of strings to a JSON string.
        /// </summary>
        /// <param name="dictionary">The dictionary to convert.</param>
        /// <returns>A JSON string representing the dictionary.</returns>
        public static string ConvertDictionaryToJsonString(Dictionary<string, string> dictionary)
        {
            try
            {
                // Convert the dictionary to a JObject
                JObject jObject = new JObject();
                foreach (var kvp in dictionary)
                {
                    jObject[kvp.Key] = kvp.Value;
                }

                // Convert the JObject to a JSON string
                return jObject.ToString();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the conversion
                throw new InvalidOperationException("Failed to convert dictionary to JSON string.", ex);
            }
        }
    }
}
