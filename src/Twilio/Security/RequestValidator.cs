using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;
using System.Runtime.CompilerServices;

namespace Twilio.Security
{
    /// <summary>
    /// Twilio request validator
    /// </summary>
    public class RequestValidator
    {
        private readonly byte[] _secret;

        /// <summary>
        /// Create a new RequestValidator
        /// </summary>
        /// <param name="secret">Signing secret</param>
        public RequestValidator(string secret)
        {
            _secret = Encoding.UTF8.GetBytes(secret);
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
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException("Parameter 'url' cannot be null or empty.", nameof(url));
            if (string.IsNullOrEmpty(expected))
                throw new ArgumentException("Parameter 'expected' cannot be null or empty.", nameof(url));

#if NET6_0_OR_GREATER
            {
                byte[] computeHash(byte[] buffer) => HMACSHA1.HashData(_secret, buffer);
#else
            using (var hmac = new HMACSHA1(_secret))
            {
                Func<byte[], byte[]> computeHash = hmac.ComputeHash;
#endif
                if (parameters == null || parameters.Count == 0)
                {
                    var signature = GetValidationSignature(url, computeHash);
                    if (SecureCompare(signature, expected)) return true;

                    // check signature of url with and without port, since sig generation on back end is inconsistent
                    // If either url produces a valid signature, we accept the request as valid
                    url = GetUriVariation(url);
                    signature = GetValidationSignature(url, computeHash);
                    if (SecureCompare(signature, expected)) return true;
                    return false;
                }
                else
                {
                    var parameterStringBuilder = GetJoinedParametersStringBuilder(parameters);
                    parameterStringBuilder.Insert(0, url);
                    var signature = GetValidationSignature(parameterStringBuilder.ToString(), computeHash);
                    if (SecureCompare(signature, expected)) return true;
                    parameterStringBuilder.Remove(0, url.Length);

                    // check signature of url with and without port, since sig generation on back end is inconsistent
                    // If either url produces a valid signature, we accept the request as valid
                    url = GetUriVariation(url);
                    parameterStringBuilder.Insert(0, url);
                    signature = GetValidationSignature(parameterStringBuilder.ToString(), computeHash);
                    if (SecureCompare(signature, expected)) return true;

                    return false;
                }
            }
        }

        private StringBuilder GetJoinedParametersStringBuilder(IDictionary<string, string> parameters)
        {
            var keys = parameters.Keys.ToArray();
            Array.Sort(keys, StringComparer.Ordinal);

            var b = new StringBuilder();
            foreach (var key in keys)
            {
                b.Append(key).Append(parameters[key] ?? "");
            }

            return b;
        }

        public bool Validate(string url, string body, string expected)
        {
            if (string.IsNullOrEmpty(url))
                throw new ArgumentException("Parameter 'url' cannot be null or empty.", nameof(url));
            if (string.IsNullOrEmpty(expected))
                throw new ArgumentException("Parameter 'expected' cannot be null or empty.", nameof(expected));

            var paramString = new Uri(url, UriKind.Absolute).Query.TrimStart('?');
            var bodyHash = "";
            foreach (var param in paramString.Split('&'))
            {
                var split = param.Split('=');
                if (split[0] == "bodySHA256")
                {
                    bodyHash = Uri.UnescapeDataString(split[1]);
                }
            }

            return Validate(url, (IDictionary<string, string>)null, expected) && ValidateBody(body, bodyHash);
        }

        public static bool ValidateBody(string rawBody, string expected)
        {
#if NET6_0_OR_GREATER
            {
                var signature = SHA256.HashData(Encoding.UTF8.GetBytes(rawBody));
#else
            using (var sha = SHA256.Create())
            {
                var signature = sha.ComputeHash(Encoding.UTF8.GetBytes(rawBody));
#endif
                return SecureCompare(BitConverter.ToString(signature).Replace("-", "").ToLower(), expected);
            }
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

        private string GetValidationSignature(string urlWithParameters, Func<byte[], byte[]> computeHash)
        {
            var hash = computeHash(Encoding.UTF8.GetBytes(urlWithParameters));
            return Convert.ToBase64String(hash);
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
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

        /// <summary>
        /// Returns URL without port if given URL has port, returns URL with port if given URL has no port
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string GetUriVariation(string url)
        {
            var uri = new Uri(url);
            var uriBuilder = new UriBuilder(uri);
            var port = uri.GetComponents(UriComponents.Port, UriFormat.UriEscaped);
            // if port already removed
            if (port == "")
            {
                return SetPort(url, uriBuilder, uriBuilder.Port);
            }

            return SetPort(url, uriBuilder, -1);
        }

        private static string SetPort(string url, UriBuilder uri, int newPort)
        {
            if (newPort == -1)
            {
                uri.Port = newPort;
            }
            else if (newPort != 443 && newPort != 80)
            {
                uri.Port = newPort;
            }
            else
            {
                uri.Port = uri.Scheme == "https" ? 443 : 80;
            }

            var uriStringBuilder = new StringBuilder(uri.ToString());

            var host = PreserveCase(url, uri.Host);
            uriStringBuilder.Replace(uri.Host, host);

            var scheme = PreserveCase(url, uri.Scheme);
            uriStringBuilder.Replace(uri.Scheme, scheme);

            return uriStringBuilder.ToString();
        }

        private static string PreserveCase(string url, string replacementString)
        {
            var startIndex = url.IndexOf(replacementString, StringComparison.OrdinalIgnoreCase);
            return url.Substring(startIndex, replacementString.Length);
        }
    }
}