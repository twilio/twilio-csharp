using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace Twilio.UnitTests.Jwt
{
    class DecodedJwt
    {
        private static byte[] Base64UrlDecode(string input) => Convert.FromBase64String(UrlDecode(input));

        private static string UrlDecode(string input)
        {
            var output = input;
            output = output.Replace('-', '+'); // 62nd char of encoding
            output = output.Replace('_', '/'); // 63rd char of encoding

            // Pad with trailing '='s
            switch (output.Length % 4)
            {
                case 0:
                    break; // No pad chars in this case
                case 2:
                    output += "==";
                    break; // Two pad chars
                case 3:
                    output += "=";
                    break; // One pad char
                default:
                    throw new Exception($"Illegal base-64 string: '{input}'.");
            }

            return output;
        }

        private static IDictionary<string, object> DecodeJwtPart(string part)
        {
            var bytes = Base64UrlDecode(part);
            var json = Encoding.UTF8.GetString(bytes);
            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

            return data;
        }

        public IDictionary<string, object> Header
        {
            get
            {
                return _header;
            }
        }

        public IDictionary<string, object> Payload
        {
            get
            {
                return _payload;
            }
        }

        private readonly IDictionary<string, object> _header;
        private readonly IDictionary<string, object> _payload;

        public DecodedJwt(string jwt, string secret)
        {
            var parts = jwt.Split('.');
            _header = DecodeJwtPart(parts[0]);
            _payload = DecodeJwtPart(parts[1]);
        }
    }
}
