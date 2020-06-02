using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFramework.Core.Security
{
    public interface IHashProvider
    {
        void GetHashAndSalt(byte[] data, out byte[] hash, out byte[] salt);
        void GetHashAndSaltString(string data, out string hash, out string salt);
        bool VerifyHash(byte[] data, byte[] hash, byte[] salt);
        bool VerifyHashString(string data, string hash, string salt);
        bool VerifyHashString(string password, object passwordHash, object passwordSalt);
    }
}
