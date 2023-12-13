using System.Security.Cryptography;
using System.Text;

namespace ScissorRockPaperGame
{
    public class Security
    {
        public string GenerateKey()
        {
            var rndvalue = RandomNumberGenerator.Create();
            byte[] bytes = new byte[16];
            rndvalue.GetBytes(bytes);
            return BitConverter.ToString(bytes).Replace("-", "");
        }

        public string GenerateHMAC(string key, string message)
        {
            HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(key));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}
