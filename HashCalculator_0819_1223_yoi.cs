// 代码生成时间: 2025-08-19 12:23:28
using System;
using System.Security.Cryptography;
using System.Text;

namespace XamarinHashTool
{
    /// <summary>
    /// A class to calculate hash values for strings.
    /// </summary>
    public class HashCalculator
    {
        /// <summary>
        /// Calculates the SHA256 hash of the given string.
        /// </summary>
        /// <param name="input">The input string to hash.</param>
        /// <returns>The SHA256 hash of the input string.</returns>
        /// <exception cref="ArgumentNullException">Thrown if input is null.</exception>
        public string CalculateSha256Hash(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Input cannot be null.");

            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash of the input string
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        /// <summary>
        /// Calculates the SHA512 hash of the given string.
        /// </summary>
        /// <param name="input">The input string to hash.</param>
        /// <returns>The SHA512 hash of the input string.</returns>
        /// <exception cref="ArgumentNullException">Thrown if input is null.</exception>
        public string CalculateSha512Hash(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Input cannot be null.");

            using (SHA512 sha512 = SHA512.Create())
            {
                // Compute the hash of the input string
                byte[] bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}