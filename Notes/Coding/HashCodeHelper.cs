using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;

namespace Notes.Coding
{
    public class HashCodeHelper
    {
        public static string HashString(string str)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(str));
                var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return hash;
            }
        }
    }
}
