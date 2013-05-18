using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace DiplomApp.Helpers
{
    public static class CryptoHelper
    {
        enum CryptoAction : byte
        {
            Encrypt,
            Decrypt
        }

        private const string stringKey = "j9sMvFHCkedh2b8tzs68g0Ydf9ObBVPS"; // 32-digit key
        private const string stringVector = "AWkp5heefB7za3FG";              // 16-digit vector

        public static string Encrypt(string text)
        {
            byte[] textArray = Encoding.UTF8.GetBytes(text);
            byte[] result = ExecuteCryptoAction(textArray, CryptoAction.Encrypt);
            return Convert.ToBase64String(result);
        }
        
        public static string Decrypt(string text)
        {
            byte[] textArray = Encoding.UTF8.GetBytes(text);
            byte[] result = ExecuteCryptoAction(textArray, CryptoAction.Encrypt);
            return null;
        }

        private static byte[] ExecuteCryptoAction(byte[] textArray, CryptoAction action)
        {
            var algorithm = SymmetricAlgorithm.Create();

            using (var memory = new MemoryStream())
            {
                using (var transform = CreateCryptoTransform(algorithm, action))
                {
                    using (var cryptoStream = new CryptoStream(memory, transform, CryptoStreamMode.Write))
                        cryptoStream.Write(textArray, 0, textArray.Length);
                }

                return memory.ToArray();
            }
        }

        private static ICryptoTransform CreateCryptoTransform(SymmetricAlgorithm algorithm, CryptoAction action)
        {
            byte[] key = Encoding.ASCII.GetBytes(stringKey);
            byte[] vector = Encoding.ASCII.GetBytes(stringVector);

            return action == CryptoAction.Encrypt
                ? algorithm.CreateEncryptor(key, vector)
                : algorithm.CreateDecryptor(key, vector);
        }
    }
}
