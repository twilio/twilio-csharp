using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;

namespace Twilio.Security
{
    /// <summary>
    /// Twilio request validator
    /// </summary>
    public class RequestValidator
    {
        private readonly HMACSHA1 _hmac;
        private readonly SHA256 _sha;

        /// <summary>
        /// Create a new RequestValidator
        /// </summary>
        /// <param name="secret">Signing secret</param>
        public RequestValidator(string secret)
        {
            _hmac = new HMACSHA1(Encoding.UTF8.GetBytes(secret));
            _sha = SHA256.Create();
        }

        /// <summary>
        /// Validate against a request
        /// </summary>
        /// <param name="url">Request URL</param>
        /// <param name="parameters">Request parameters</param>
        /// <param name="expected">Expected result</param>
        /// <returns>true if the signature matches the result; false otherwise</returns>
        public bool Validate(string url, NameValueCollection parameters, string expected)
        {
            return Validate(url, ToDictionary(parameters), expected);
        }

        /// <summary>
        /// Validate against a request
        /// </summary>
        /// <param name="url">Request URL</param>
        /// <param name="parameters">Request parameters</param>
        /// <param name="expected">Expected result</param>
        /// <returns>true if the signature matches the result; false otherwise</returns>
        public bool Validate(string url, IDictionary<string, string> parameters, string expected)
        {
            var signature = GetValidationSignature(url, parameters);
            return SecureCompare(signature, expected);
        }

        public bool Validate(string url, NameValueCollection parameters, string body, string expected)
        {
            return Validate(url, ToDictionary(parameters), body, expected);
        }

        public bool Validate(string url, IDictionary<string, string> parameters, string body, string expected)
        {
            return Validate(url, parameters, expected) && ValidateBody(body, parameters["bodySHA256"]);
        }

        public bool ValidateBody(string rawBody, string expected)
        {
            var signature = _sha.ComputeHash(Encoding.UTF8.GetBytes(rawBody));
            return SecureCompare(Convert.ToBase64String(signature), expected);
        }

        private static IDictionary<string, string> ToDictionary(NameValueCollection col)
        {
            var dict = new Dictionary<string, string>();
            foreach (var k in col.AllKeys)
            {
                dict.Add(k, col[k]);
            }
            return dict;
        }

        private string GetValidationSignature(string url, IDictionary<string, string> parameters)
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
