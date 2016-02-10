using System;
using System.Threading.Tasks;

namespace Twilio.Http
{
    public abstract class HttpClient
    {
        public abstract Task<Response> makeRequest(Request request);

        protected string authentication(string username, string password)
        {
            string credentials = username + ":" + password;
            var encoded = System.Text.Encoding.UTF8.GetBytes(credentials);
            return Convert.ToBase64String(encoded);
        }
    }
}
