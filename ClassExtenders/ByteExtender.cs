using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassExtenders
{
    public static class ByteExtender
    {
        public static string GetMD5Hash(this byte[] input)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider provider = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = input;

            data = provider.ComputeHash(data);
            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            foreach (byte b in data)
            {
                builder.Append(b.ToString("x2").ToLower());
            }
            return builder.ToString();
        }
    }
}
