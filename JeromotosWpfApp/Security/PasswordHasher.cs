using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace JeromotosWpfApp.Security
{
    public class PasswordHasher
    {
        public static string HashPassword(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);

                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder builder = new StringBuilder();

                foreach (byte b in hash)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public static bool VerifyPassword(string password, string passwordHash)
        {
            string hash = HashPassword(password);

            return hash == passwordHash;
        }
    }
}
