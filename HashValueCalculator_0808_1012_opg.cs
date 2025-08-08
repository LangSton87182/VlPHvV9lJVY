// 代码生成时间: 2025-08-08 10:12:36
using System;
using System.Security.Cryptography;
using System.Text;

namespace HashCalculator
{
    public class HashValueCalculator
    {
        // 计算字符串的MD5哈希值
        public string CalculateMD5Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input), "输入字符串不能为空。");
            }

            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
        }

        // 计算字符串的SHA256哈希值
        public string CalculateSHA256Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException(nameof(input), "输入字符串不能为空。");
            }

            using (var sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            }
        }
    }
}
