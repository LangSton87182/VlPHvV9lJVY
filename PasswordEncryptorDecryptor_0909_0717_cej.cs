// 代码生成时间: 2025-09-09 07:17:28
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SecurityUtilities
{
    public class PasswordEncryptorDecryptor
    {
        // Use a secure key and IV for encryption/decryption.
        // In a real-world application, these should be securely generated and stored.
        private const string Key = "32char!@#$%^&*()-_+=`~[]{}";
        private const string IV = "16char!@#$%^&*()-_+=`~[]{}";

        public string Encrypt(string plainText)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Encoding.UTF8.GetBytes(Key);
                    aesAlg.IV = Encoding.UTF8.GetBytes(IV);

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(plainText);
                            }
                            return Convert.ToBase64String(msEncrypt.ToArray());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception and re-throw to be handled by the caller
                throw new CryptographicException("An error occurred during encryption.", ex);
            }
        }

        public string Decrypt(string cipherText)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Encoding.UTF8.GetBytes(Key);
                    aesAlg.IV = Encoding.UTF8.GetBytes(IV);

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception and re-throw to be handled by the caller
                throw new CryptographicException("An error occurred during decryption.", ex);
            }
        }
    }
}