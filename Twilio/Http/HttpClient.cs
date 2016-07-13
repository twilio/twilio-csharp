using System;
namespace Twilio.Http
{
    public abstract class HttpClient
    {
        public abstract Response MakeRequest(Request request);

#if NET40
        public abstract System.Threading.Tasks.Task<Response> MakeRequestAsync(Request request);
#endif
        protected string Authentication(string username, string password)
        {
            string credentials = username + ":" + password;
            var encoded = System.Text.Encoding.UTF8.GetBytes(credentials);
            return Convert.ToBase64String(encoded);
        }
    }
}
