using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Cryptography
{
    public static class Crypto
    {
        
        /// <summary>
        /// Generates a 64 bytelength hash for a given string and its salt
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string GenerateHash(string password, string salt)
        {
            //Append generated salt to given password
            string saltedpw = password + salt;
            StringBuilder sb = new StringBuilder();

            //Gets the bytes of the salted password
            var data = Encoding.UTF8.GetBytes(saltedpw);

            //SHA512 hash calculator
            using (var sha512 = new SHA512CryptoServiceProvider())
            {
                //Computes a hash from the data variable which contains the salted password in byte format
                var hashedInputBytes = sha512.ComputeHash(data);
                foreach (byte b in hashedInputBytes)
                {
                    //Convert the bytes and append to a string in 2 hexadecimal characters
                    sb.Append(b.ToString("X2"));
                }
                Console.WriteLine(sb.ToString());
                return sb.ToString();
            }
        }

        /// <summary>
        /// Generates a 64 bytelength salt for a user
        /// </summary>
        /// <param name="rng"></param>
        /// <returns>Returns a salt in string format</returns>
        public static string GenerateSalt()
        {
            //Cryptographically secure pseudo-random number generator (CSPRNG)
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            StringBuilder sb = new StringBuilder();

            //Creates an array of bytes (length of the salt)
            var bytes = new Byte[64];

            //Disposes of object automatically when done
            using (rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);

                foreach (byte b in bytes)
                {
                    //Convert the bytes and append to a string in 2 hexadecimal characters
                    sb.Append(b.ToString("X2"));
                }
                Console.WriteLine("Salt: " + sb.ToString());
                return sb.ToString();
            }
        }
    }
}
