// 代码生成时间: 2025-09-08 12:18:48
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace XssProtectionApp
{
    /// <summary>
    /// This service provides functionality to protect against XSS attacks by sanitizing input data.
    /// </summary>
    public class XssProtectionService
    {
        // List of allowed HTML tags
        private readonly List<string> allowedTags = new List<string> { "b", "i", "u", "em", "strong", "p" };

        /// <summary>
        /// Sanitizes the input string to prevent XSS attacks.
        /// </summary>
        /// <param name="input">The input string that may contain potential XSS threats.</param>
        /// <returns>A sanitized string free of XSS threats.</returns>
        public string SanitizeInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                // Return the original input if it is null or empty
                return input;
            }

            // Remove script tags
            input = Regex.Replace(input, "<(script)[^>]*>.*?</(script)[^>]*>", string.Empty, RegexOptions.IgnoreCase);

            // Allow only certain tags
            foreach (var tag in allowedTags)
            {
                input = AllowTag(input, tag);
            }

            return input;
        }

        /// <summary>
        /// Allows only the specified tag in the input string.
        /// </summary>
        /// <param name="input">The input string to be sanitized.</param>
        /// <param name="tag">The allowed HTML tag.</param>
        /// <returns>A sanitized string with only the specified tag allowed.</returns>
        private string AllowTag(string input, string tag)
        {
            // Replace the tag with an empty string if it is not allowed
            if (!allowedTags.Contains(tag))
            {
                return Regex.Replace(input, $"<{tag}[^>]*>.*?</{tag}[^>]*>", string.Empty, RegexOptions.IgnoreCase);
            }

            // Sanitize attributes within the allowed tag
            return Regex.Replace(input, $"<{tag}([^>]*)>"