// 代码生成时间: 2025-09-16 16:32:42
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataPreprocessingApp
{
    /// <summary>
    /// Provides functionality for data cleaning and preprocessing.
    /// </summary>
    public class DataCleansingTool
    {
        /// <summary>
        /// Removes any non-numeric characters from a string and trims white spaces.
        /// </summary>
        /// <param name="input">The string to clean.</param>
        /// <returns>A cleaned string containing only numeric characters.</returns>
        public string CleanNumericString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input string cannot be null or whitespace.", nameof(input));

            return new string(input.Where(char.IsDigit).ToArray());
        }

        /// <summary>
        /// Replaces or removes special characters and trims white spaces from a string.
        /// </summary>
        /// <param name="input">The string to clean.</param>
        /// <param name="replaceWith">Optional character to replace special characters with.</param>
        /// <returns>A cleaned string with special characters replaced or removed.</returns>
        public string CleanSpecialCharacters(string input, char? replaceWith = null)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input string cannot be null or whitespace.", nameof(input));

            string pattern = "[^a-zA-Z0-9 ]";
            string result = Regex.Replace(input.Trim(), pattern, replaceWith.HasValue ? replaceWith.ToString() : "");
            return result;
        }

        /// <summary>
        /// Standardizes date strings to a specified format.
        /// </summary>
        /// <param name="input">The date string to standardize.</param>
        /// <param name="inputFormat">The format of the input date string.</param>
        /// <param name="outputFormat">The desired format of the standardized date string.</param>
        /// <returns>A standardized date string.</returns>
        public string StandardizeDateString(string input, string inputFormat, string outputFormat)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Input date string cannot be null or whitespace.", nameof(input));

            DateTime date;
            if (!DateTime.TryParseExact(input, inputFormat, System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out date))
                throw new FormatException("Input date string is not in the expected format.");

            return date.ToString(outputFormat);
        }

        // Additional data cleaning and preprocessing methods can be added here.
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DataCleansingTool tool = new DataCleansingTool();

                // Example usage of the tool's methods.
                string numericInput = "123-abc456";
                Console.WriteLine("Cleaned numeric string: " + tool.CleanNumericString(numericInput));

                string specialCharInput = "Hello! How are you?";
                Console.WriteLine("Cleaned special characters: " + tool.CleanSpecialCharacters(specialCharInput));

                string dateInput = "31/12/2023";
                Console.WriteLine("Standardized date string: " + tool.StandardizeDateString(dateInput, "dd/MM/yyyy", "yyyy-MM-dd"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
