// 代码生成时间: 2025-08-31 19:33:54
using System;
# 优化算法效率
using System.Text.RegularExpressions;

namespace ValidationApp
{
    /// <summary>
# 优化算法效率
    /// A class responsible for validating form data.
    /// </summary>
    public class FormDataValidator
    {
        /// <summary>
        /// Validates the email address.
        /// </summary>
        /// <param name="email">The email to validate.</param>
# TODO: 优化性能
        /// <returns>True if the email is valid, otherwise false.</returns>
        public bool ValidateEmail(string email)
        {
            // Regular expression for basic email validation
# 扩展功能模块
            string pattern = @"^([\w-]+\.)*?[\w-]+@[\w-]+\.[a-zA-Z]{2,3}$";
            return Regex.IsMatch(email, pattern);
        }

        /// <summary>
        /// Validates that the input is a positive integer.
        /// </summary>
        /// <param name="input">The input to validate.</param>
        /// <returns>True if the input is a positive integer, otherwise false.</returns>
        public bool ValidatePositiveInteger(string input)
        {
# 增强安全性
            if (int.TryParse(input, out int number))
            {
# 优化算法效率
                return number > 0;
            }
            return false;
# 添加错误处理
        }
# 增强安全性

        /// <summary>
        /// Validates that the password meets certain criteria.
        /// </summary>
        /// <param name="password">The password to validate.</param>
        /// <returns>True if the password is valid, otherwise false.</returns>
        public bool ValidatePassword(string password)
# 添加错误处理
        {
            // Password must be at least 8 characters long, include a digit and an uppercase letter
            bool hasDigit = password.Any(char.IsDigit);
            bool hasUpper = password.Any(char.IsUpper);
            return password.Length >= 8 && hasDigit && hasUpper;
        }

        /// <summary>
        /// Validates the form data.
        /// </summary>
        /// <param name="email">The email address from the form.</param>
        /// <param name="age">The age from the form.</param>
        /// <param name="password">The password from the form.</param>
        /// <returns>A string containing any validation errors or an empty string if no errors.</returns>
        public string ValidateFormData(string email, string age, string password)
        {
            string errors = string.Empty;

            if (!ValidateEmail(email))
            {
                errors += "Email is invalid. ";
            }

            if (!ValidatePositiveInteger(age))
            {
                errors += "Age must be a positive integer. ";
            }

            if (!ValidatePassword(password))
# 改进用户体验
            {
                errors += "Password must be at least 8 characters long and include a digit and an uppercase letter. ";
            }

            return errors.TrimEnd();
        }
# 增强安全性
    }
}
# 扩展功能模块
