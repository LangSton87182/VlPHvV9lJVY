// 代码生成时间: 2025-08-23 13:22:10
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace XamarinApp
{
    /// <summary>
    /// A validator class for form data.
    /// </summary>
    public class FormValidator
    {
        /// <summary>
        /// Validates an email address.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns>True if the email is valid, false otherwise.</returns>
        public bool ValidateEmail(string email)
        {
            // Regular expression for validating an email address.
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        /// <summary>
        /// Validates a password with minimum 8 characters and at least one number.
        /// </summary>
        /// <param name="password">The password to validate.</param>
        /// <returns>True if the password is valid, false otherwise.</returns>
        public bool ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            {
                return false;
            }

            // Check for at least one number in the password.
            return Regex.IsMatch(password, @".*\d.*");
        }

        /// <summary>
        /// Validates a non-empty string.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>True if the input is non-empty, false otherwise.</returns>
        public bool ValidateNonEmpty(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        // Add more validation methods as needed.
    }
}
