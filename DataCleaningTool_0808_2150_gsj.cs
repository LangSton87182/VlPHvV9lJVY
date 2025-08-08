// 代码生成时间: 2025-08-08 21:50:08
// <summary>
// DataCleaningTool.cs - A class that provides data cleaning and preprocessing functionalities.
// </summary>

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace DataPreprocessingApp
{
    /// <summary>
    /// A tool for data cleaning and preprocessing.
    /// </summary>
    public class DataCleaningTool
    {
        /// <summary>
        /// Removes any non-alphanumeric characters from the input string.
        /// </summary>
        /// <param name="input">The input string to clean.</param>
        /// <returns>A cleaned string with only alphanumeric characters.</returns>
        public string CleanNonAlphanumericCharacters(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.", nameof(input));
            }

            return Regex.Replace(input, "[^a-zA-Z0-9]", "");
        }

        /// <summary>
        /// Converts all characters of the input string to lower case.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The input string in lower case.</returns>
        public string ConvertToLower(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.", nameof(input));
            }

            return input.ToLower();
        }

        /// <summary>
        /// Trims any leading or trailing white spaces from the input string.
        /// </summary>
        /// <param name="input">The input string to trim.</param>
        /// <returns>The trimmed string.</returns>
        public string TrimWhiteSpaces(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.", nameof(input));
            }

            return input.Trim();
        }

        /// <summary>
        /// Replaces specified characters in the input string with their replacements.
        /// </summary>
        /// <param name="input">The input string to replace characters in.</param>
        /// <param name="replacements">A dictionary of characters to replace and their replacements.</param>
        /// <returns>The modified string with replacements.</returns>
        public string ReplaceCharacters(string input, Dictionary<char, char> replacements)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.", nameof(input));
            }
            if (replacements == null)
            {
                throw new ArgumentNullException(nameof(replacements), "Replacements dictionary cannot be null.");
            }

            return new string(replacements.Aggregate(input, (current, pair) => current.Replace(pair.Key, pair.Value)).ToArray());
        }

        /// <summary>
        /// Cleans a list of strings by applying a series of cleaning operations.
        /// </summary>
        /// <param name="inputs">The list of strings to clean.</param>
        /// <returns>A list of cleaned strings.</returns>
        public List<string> CleanList(List<string> inputs)
        {
            if (inputs == null)
            {
                throw new ArgumentNullException(nameof(inputs), "Input list cannot be null.");
            }

            return inputs
                .Select(input => CleanNonAlphanumericCharacters(input))
                .Select(input => ConvertToLower(input))
                .Select(input => TrimWhiteSpaces(input))
                .ToList();
        }
    }
}
