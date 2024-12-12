using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;


namespace ZaloPay.Helper.Crypto
{
    public class RSAHelper
    {
        public static string Encrypt(string plainText, X509Certificate2 cert)
        {
            RSACryptoServiceProvider publicKey = (RSACryptoServiceProvider)cert.PublicKey.Key;
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = publicKey.Encrypt(plainBytes, false);
            string encryptedText = Convert.ToBase64String(encryptedBytes);
            return encryptedText;
        }

        public static string Decrypt(string encryptedText, X509Certificate2 cert)
        {
            RSACryptoServiceProvider privateKey = (RSACryptoServiceProvider)cert.PrivateKey;
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            byte[] decryptedBytes = privateKey.Decrypt(encryptedBytes, false);
            string decryptedText = Encoding.UTF8.GetString(decryptedBytes);
            return decryptedText;
        }
    }
}