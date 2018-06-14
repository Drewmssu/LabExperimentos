using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace DemoLogic
{
    public static class CipherLogic
    {
        private static string Salt => string.Join("", ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), true)[0]).Value.ToUpper().Split('-'));
        private static byte[] iv = Encoding.UTF8.GetBytes("5u8x/A?D(G+KbPeS");
        private static byte[] key = Encoding.UTF8.GetBytes("cRfUjXn2r5u8x!A%D*G-KaPdSgVkYp3s");

        public static string Encrypt(string plainText)
        {
            var plainBytes = Encoding.UTF8.GetBytes($"{Salt}{plainText}");

            var rijndael = Rijndael.Create();
            var encryptor = rijndael.CreateEncryptor(key, iv);
            var memoryStream = new MemoryStream(plainBytes.Length);
            var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

            cryptoStream.Write(plainBytes, 0, plainBytes.Length);
            cryptoStream.FlushFinalBlock();

            var cipherBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();

            return Convert.ToBase64String(cipherBytes);
        }

        public static string Decrypt(string cipherText)
        {
            var cipherBytes = Convert.FromBase64String(cipherText);
            var plainBytes = new byte[cipherBytes.Length];

            var rijndael = Rijndael.Create();
            var decryptor = rijndael.CreateDecryptor(key, iv);
            var memoryStream = new MemoryStream(cipherBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            var decryptedByteCount = cryptoStream.Read(plainBytes, 0, plainBytes.Length);

            memoryStream.Close();
            cryptoStream.Close();

            var plainText = Encoding.UTF8.GetString(plainBytes, 0, decryptedByteCount);
            plainText = plainText.Split(new string[] { Salt }, StringSplitOptions.None)[1];

            return plainText;
        }

    }
}
