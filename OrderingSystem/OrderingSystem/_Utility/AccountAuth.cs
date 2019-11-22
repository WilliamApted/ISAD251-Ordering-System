using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace OrderingSystem._Utility
{
    public class AccountAuth
    {
        /// <summary>
        /// Runs the salt and password through a SHA512 hash function.
        /// </summary>
        /// <param name="salt">Salt for the password</param>
        /// <param name="password">Plain password</param>
        /// <returns>Hashed and salted password.</returns>
        public static string HashPass(string salt, string password)
        {
            string input = salt + password;
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }

        /// <summary>
        /// Generates a salt to hash the password with. 
        /// </summary>
        /// <returns>A 128bit/32character random string.</returns>
        public static string GenerateSalt() 
        {
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[32];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        /// <summary>
        /// Checks the password matches that of the salted password.
        /// </summary>
        /// <param name="inputPassword"></param>
        /// <param name="saltedPassword"></param>
        /// <param name="salt"></param>
        /// <returns>Returns true if the input and hashed password match.</returns>
        public static bool CheckPassword(string inputPassword, string saltedPassword, string salt) 
        {
            if (HashPass(salt, inputPassword) == saltedPassword)
                return true;
            else
                return false;
        }
    }
}
