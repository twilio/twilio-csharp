#if NET35
using System.IO;

namespace Twilio.Http.Net35
{

    /// <summary>
    /// Sample client to make requests
    /// </summary>
    public class WebRequestClient : HttpClient
    {
        private const string PlatVersion = " (.NET 3.5)";
        private HttpWebRequestFactory factory;

        public WebRequestClient(HttpWebRequestFactory factory = null)
        {
            this.factory = factory ?? new HttpWebRequestFactory();
        }

        /// <summary>
        /// Make an HTTP request
        /// </summary>
        /// <param name="request">Twilio request</param>
        /// <returns>Twilio response</returns>
        public override Response MakeRequest(Request request)
        {

            IHttpWebRequestWrapper httpRequest = BuildHttpRequest(request);
            if (!Equals(request.Method, HttpMethod.Get))
            {
                httpRequest.WriteBody(request.EncodePostParams());
            }

            this.LastRequest = request;
            this.LastResponse = null;
            try
            {
                IHttpWebResponseWrapper response = httpRequest.GetResponse();
                string content = GetResponseContent(response);
                this.LastResponse = new Response(response.StatusCode, content);
            }
            catch (WebExceptionWrapper e)
            {
                if (e.Response == null)
                {
                    // Network or connection error
                    throw e.RealException;
                }
                // Non 2XX status code
                IHttpWebResponseWrapper errorResponse = e.Response;
                this.LastResponse = new Response(errorResponse.StatusCode, GetResponseContent(errorResponse));
            }
            return this.LastResponse;
        }

        private string GetResponseContent(IHttpWebResponseWrapper response)
        {
            var reader = new StreamReader(response.GetResponseStream());
            return reader.ReadToEnd();
        }

        private IHttpWebRequestWrapper BuildHttpRequest(Request request)
        {
            IHttpWebRequestWrapper httpRequest = this.factory.Create(request.ConstructUrl());

            httpRequest.UserAgent = "twilio-csharp/" + AssemblyInfomation.AssemblyInformationalVersion + PlatVersion;

            httpRequest.Method = request.Method.ToString();
            httpRequest.Accept = "application/json";
            httpRequest.Headers["Accept-Encoding"] = "utf-8";

            var authBytes = Authentication(request.Username, request.Password);
            httpRequest.Headers["Authorization"] = "Basic " + authBytes;
            httpRequest.ContentType = "application/x-www-form-urlencoded";

            return httpRequest;
        }
    }
}
#endif