﻿using System.Security.Cryptography;
using System.Text;

namespace Facebook.Infrastructure.Helper
{
    public static class HashHelper
    {
        public static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); 
                }
                return builder.ToString();
            }
        }

        public static bool VerifySha256Hash(string inputData, string storedHash)
        {
            string hashOfInput = ComputeSha256Hash(inputData);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashOfInput, storedHash) == 0;
        }
    }
}
