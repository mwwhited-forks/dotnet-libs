using System;
using System.Security.Cryptography;
using System.Text;

namespace Eliassen.System.Security.Cryptography
{
    /// <summary>
    /// Default hash of input value.  Base64 encoded MD5 Hash
    /// </summary>
    public class Hash : IHash
    {
        /// <inheritdoc/>
        public string GetHash(string value) =>
            Convert.ToBase64String(MD5.HashData(Encoding.UTF8.GetBytes(value)));
    }
}