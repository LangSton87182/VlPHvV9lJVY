// 代码生成时间: 2025-08-09 08:14:37
using System;
using System.Security.Cryptography;
using System.Text;

// 密码加密解密工具类
public class PasswordEncryptDecryptTool
{
    private readonly string encryptionKey;

    // 构造函数，初始化加密密钥
    public PasswordEncryptDecryptTool(string key)
    {
        encryptionKey = key;
    }

    // 加密密码
    public string EncryptPassword(string password)
    {
        try
        {
            // 使用AES算法加密密码
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(encryptionKey);
                aesAlg.IV = Encoding.UTF8.GetBytes(encryptionKey.Substring(0, 16));

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // 将明文密码转换为字节数组
                byte[] inputBuffer = Encoding.UTF8.GetBytes(password);

                // 进行加密操作
                byte[] outputBuffer = encryptor.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);

                // 将加密后的字节数组转换为Base64字符串
                return Convert.ToBase64String(outputBuffer);
            }
        }
        catch (Exception ex)
        {
            // 错误处理
            Console.WriteLine("Encryption Error: " + ex.Message);
            return null;
        }
    }

    // 解密密码
    public string DecryptPassword(string encryptedPassword)
    {
        try
        {
            // 使用AES算法解密密码
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(encryptionKey);
                aesAlg.IV = Encoding.UTF8.GetBytes(encryptionKey.Substring(0, 16));

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // 将加密字符串转换为字节数组
                byte[] inputBuffer = Convert.FromBase64String(encryptedPassword);

                // 进行解密操作
                byte[] outputBuffer = decryptor.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);

                // 将解密后的字节数组转换为明文字符串
                return Encoding.UTF8.GetString(outputBuffer);
            }
        }
        catch (Exception ex)
        {
            // 错误处理
            Console.WriteLine("Decryption Error: " + ex.Message);
            return null;
        }
    }
}
