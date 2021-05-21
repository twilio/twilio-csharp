﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Twilio.Security
{
    /// <summary>
    /// Twilio request validator
    /// </summary>
    public class RequestValidator
    {
        private readonly HMACSHA1 _hmac;
        private readonly SHA256 _sha;
        private const string URL_REGEX = "^(([^:/?#]+):)?(//([^/?#]*))?([^?#]*)(\\?([^#]*))?(#(.*))?";

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
            // check signature of url with and without port, since sig generation on back end is inconsistent
            var signatureWithoutPort = GetValidationSignature(RemovePort(url), parameters);
            var signatureWithPort = GetValidationSignature(AddPort(url), parameters);
            // If either url produces a valid signature, we accept the request as valid
            return SecureCompare(signatureWithoutPort, expected) || SecureCompare(signatureWithPort, expected);
        }

        public bool Validate(string url, string body, string expected)
        {
            var paramString = new UriBuilder(url).Query.TrimStart('?');
            var bodyHash = "";
            foreach (var param in paramString.Split('&'))
            {
                var split = param.Split('=');
                if (split[0] == "bodySHA256")
                {
                    bodyHash = Uri.UnescapeDataString(split[1]);
                }
            }

            return Validate(url, new Dictionary<string, string>(), expected) && ValidateBody(body, bodyHash);
        }

        public bool ValidateBody(string rawBody, string expected)
        {
            var signature = _sha.ComputeHash(Encoding.UTF8.GetBytes(rawBody));
            return SecureCompare(BitConverter.ToString(signature).Replace("-","").ToLower(), expected);
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

        private string RemovePort(string url)
        {
            var uri = new UriBuilder(url);
            uri.Host = PreserveHostnameCasing(url);
            uri.Port = -1;
            var scheme = PreserveSchemeCasing(url);
            return uri.Uri.OriginalString.Replace(uri.Scheme, scheme);
        }

        private string AddPort(string url)
        {
            var uri = new UriBuilder(url);
            uri.Host = PreserveHostnameCasing(url);
            if (uri.Port != -1)
            {
                return uri.Uri.OriginalString;
            }
            var scheme = PreserveSchemeCasing(url);
            uri.Port = uri.Scheme == "https" ? 443 : 80;
            return uri.Uri.OriginalString.Replace(uri.Scheme, scheme);
        }

        private string PreserveHostnameCasing(string url)
        {
            // Preserve host name casing, regex source: https://datatracker.ietf.org/doc/html/rfc3986#appendix-B
            var m = Regex.Match(url, URL_REGEX);
            var hostName = m.Groups[4].ToString();
            var preservedHostName = System.String.Empty;
            // Do we have credentials in the URL?
            if (hostName.Split('@').Length == 2)
            {
                preservedHostName = hostName.Split('@')[1].Split(':')[0];
            } else {
                preservedHostName = hostName.Split(':')[0];
            }
            return preservedHostName;
        }

        private string PreserveSchemeCasing(string url)
        {
            // Preserve scheme casing, regex source: https://datatracker.ietf.org/doc/html/rfc3986#appendix-B
            var m = Regex.Match(url, URL_REGEX);
            var scheme = m.Groups[2].ToString();
            return scheme;
        }
    }
}
