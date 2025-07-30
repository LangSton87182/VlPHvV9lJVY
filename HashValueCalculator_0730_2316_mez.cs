// 代码生成时间: 2025-07-30 23:16:22
// 哈希值计算工具类
using System;
using System.Security.Cryptography;
using System.Text;

namespace XamarinApp
{
    public class HashValueCalculator
    {
        // 计算指定字符串的哈希值
        public string CalculateHash(string input)
        {
            // 检查输入是否为空
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("输入不能为空。");
            }

            // 使用SHA256算法计算哈希值
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder();

                // 将字节数组转换为十六进制字符串
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
