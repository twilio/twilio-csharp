using System;
using System.Threading.Tasks;

namespace Twilio.Http
{
    public abstract class HttpClient
    {
        public abstract Response MakeRequest(Request request);

        protected string Authentication(string username, string password)
        {
            string credentials = username + ":" + password;
            var encoded = System.Text.Encoding.UTF8.GetBytes(credentials);
            return Convert.ToBase64String(encoded);
        }
    }
}
