// 代码生成时间: 2025-09-18 20:22:37
// <copyright file="HashValueCalculator.cs" company="YourCompany">
//   Copyright (c) YourCompany. All rights reserved.
// </copyright>

using System;
using System.Security.Cryptography;
using System.Text;

namespace YourApp
{
    /// <summary>
    /// A utility class for calculating hash values.
    /// </summary>
    public static class HashValueCalculator
    {
        /// <summary>
        /// Calculates the hash value of the input data using the specified hash algorithm.
        /// </summary>
        /// <param name="inputData">The data to be hashed.</param>
        /// <param name="hashAlgorithm">The hash algorithm to use.</param>
        /// <returns>The hash value as a hexadecimal string.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="inputData"/> is null.</exception>
        public static string CalculateHash(string inputData, HashAlgorithm hashAlgorithm)
        {
            if (inputData == null)
                throw new ArgumentNullException(nameof(inputData), "Input data cannot be null.");

            // Convert the input data to a byte array.
            byte[] data = Encoding.UTF8.GetBytes(inputData);

            // Compute the hash of the data.
            byte[] hashBytes = hashAlgorithm.ComputeHash(data);

            // Convert the hash bytes to a hexadecimal string.
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Calculates the hash value of the input data using SHA256 algorithm.
        /// </summary>
        /// <param name="inputData">The data to be hashed.</param>
        /// <returns>The hash value as a hexadecimal string.</returns>
        public static string CalculateSHA256Hash(string inputData)
        {
            return CalculateHash(inputData, SHA256.Create());
        }

        /// <summary>
        /// Calculates the hash value of the input data using SHA512 algorithm.
        /// </summary>
        /// <param name="inputData">The data to be hashed.</param>
        /// <returns>The hash value as a hexadecimal string.</returns>
        public static string CalculateSHA512Hash(string inputData)
        {
            return CalculateHash(inputData, SHA512.Create());
        }
    }
}
