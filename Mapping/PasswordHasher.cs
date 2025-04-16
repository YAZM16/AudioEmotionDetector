﻿using System.Security.Cryptography;
using System.Text;

namespace AudioEmotionApp.Mapping
{
    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public static bool Verify(string password, string hash)
        {
            var hashedInput = Hash(password);
            return hashedInput == hash;
        }
    }
}

