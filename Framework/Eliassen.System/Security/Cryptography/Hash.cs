using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace Eliassen.System.Security.Cryptography
{
    public class Hash : IHash
    {
        public string GetHash(string value)
        {
            var hash = Convert.ToBase64String(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(value)));
            Debug.WriteLine($"{value} => {hash}");
            return hash;
        }
    }
}