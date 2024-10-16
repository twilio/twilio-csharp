#if NET35
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;
using Twilio.Annotations;

namespace Twilio.AuthStrategies{

    [Beta]
    public abstract class Base64UrlEncode
    {
        public static string Decode(string base64Url)
        {
            // Replace URL-safe characters with Base64 characters
            string base64 = base64Url
                .Replace('-', '+')
                .Replace('_', '/');

            // Add padding if necessary
            switch (base64.Length % 4)
            {
                case 2: base64 += "=="; break;
                case 3: base64 += "="; break;
            }

            byte[] bytes = Convert.FromBase64String(base64);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
#endif
