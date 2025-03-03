﻿using System.Security.Cryptography;
using System.Text;

namespace Authentication.Core.Utilities.Security
{
    public class PasswordHelper
    {
        public static string HashSHA256(string input)
        {
            using (var sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public string HashWithSalt(string password, string salt)
        {
            return HashSHA256(password) + salt;
        }
    }
}
