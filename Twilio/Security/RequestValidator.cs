using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Twilio.Security
{
    public class RequestValidator
    {
        private readonly HMACSHA1 _hmac;

        public RequestValidator(string secret)
        {
            _hmac = new HMACSHA1(Encoding.UTF8.GetBytes(secret));
        }

        public bool Validate(string url, Dictionary<string, string> parameters, string expected)
        {
            var signature = GetValidationSignature(url, parameters);
            return SecureCompare(signature, expected);
        }

        private string GetValidationSignature(string url, Dictionary<string, string> parameters)
        {
            var b = new StringBuilder(url);
            if (parameters != null)
            {
                var sortedKeys = new List<string>(parameters.Keys);
                sortedKeys.Sort(StringComparer.Ordinal);

                foreach (var key in sortedKeys)
                {
                    b.Append(key).Append(parameters[key] ?? "");
                }
            }

            var hash = _hmac.ComputeHash(Encoding.UTF8.GetBytes(b.ToString()));
            return Convert.ToBase64String(hash);
        }


        private static bool SecureCompare(string a, string b)
        {
            if (a == null || b == null)
            {
                return false;
            }

            var n = a.Length;
            if (n != b.Length)
            {
                return false;
            }

            var mismatch = 0;
            for (var i = 0; i < n; i++)
            {
                mismatch |= a[i] ^ b[i];
            }

            return mismatch == 0;
        }

    }
}
