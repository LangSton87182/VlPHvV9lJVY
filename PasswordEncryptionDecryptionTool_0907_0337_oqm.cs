// 代码生成时间: 2025-09-07 03:37:53
// PasswordEncryptionDecryptionTool.cs
// 密码加密解密工具

using System;
using System.Security.Cryptography;
using System.Text;

namespace XamarinPasswordTools
{
    public class PasswordEncryptionDecryptionTool
    {
        private readonly byte[] salt;
        private readonly byte[] iv;
        private readonly byte[] encryptedKey;
        private readonly RijndaelManaged rijndael;

        // 构造函数，初始化加密组件
        public PasswordEncryptionDecryptionTool(byte[] key)
        {
            // 初始化加密算法
            rijndael = new RijndaelManaged
            {
                KeySize = 256,
                BlockSize = 128,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            };

            // 生成加密使用的盐值和IV
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            salt = new byte[16];
            iv = new byte[16];
            rng.GetBytes(salt);
            rng.GetBytes(iv);

            // 从传入的密钥和盐值生成加密密钥
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(key, salt, 1000);
            encryptedKey = pdb.GetBytes(rijndael.KeySize / 8);
        }

        // 加密方法
        public string Encrypt(string plainText)
        {
            try
            {
                // 将明文转换为字节数组
                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

                // 生成加密结果的字节数组
                ICryptoTransform encryptor = rijndael.CreateEncryptor(encryptedKey, iv);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(plainBytes, 0, plainBytes.Length);
                        cs.FlushFinalBlock();
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in encryption process: " + ex.Message);
            }
        }

        // 解密方法
        public string Decrypt(string encryptedText)
        {
            try
            {
                // 将密文转换为字节数组
                byte[] cipherBytes = Convert.FromBase64String(encryptedText);

                // 生成解密结果的字节数组
                ICryptoTransform decryptor = rijndael.CreateDecryptor(encryptedKey, iv);
                using (MemoryStream ms = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in decryption process: " + ex.Message);
            }
        }
    }
}
