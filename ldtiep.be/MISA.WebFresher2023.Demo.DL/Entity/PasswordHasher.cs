using System;
using System.Security.Cryptography;

namespace ldtiep.be.DL.Entity
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            // Generate a random salt
            byte[] salt = GetSalt();

            // Derive the key using PBKDF2
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            // Combine salt and hash
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Convert to a base64 string
            return Convert.ToBase64String(hashBytes);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);

            // Extract salt and hash
            byte[] salt = GetSalt();
            Array.Copy(hashBytes, 0, salt, 0, 16);
            byte[] hash = new byte[20];
            Array.Copy(hashBytes, 16, hash, 0, 20);

            // Derive the key using PBKDF2
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] testHash = pbkdf2.GetBytes(20);
                return testHash.SequenceEqual(hash);
            }
        }
        private static byte[] GetSalt()
        {
            byte[] salt = new byte[16];
            for (int i = 0; i < salt.Length; i++)
            {
                salt[i] = 0x20;
            }
            return salt;
        }
    }
}