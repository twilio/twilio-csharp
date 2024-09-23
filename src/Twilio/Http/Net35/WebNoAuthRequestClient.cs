#if NET35
using System.IO;
using Twilio.Http.NoAuth;
using Twilio.Annotations;

namespace Twilio.Http.Net35
{

    /// <summary>
    /// Sample client to make requests
    /// </summary>
    [Beta]
    public class WebNoAuthRequestClient : NoAuthHttpClient
    {
        private const string PlatVersion = ".NET/3.5";
        private HttpWebRequestFactory factory;

        public WebNoAuthRequestClient(HttpWebRequestFactory factory = null)
        {
            this.factory = factory ?? new HttpWebRequestFactory();
        }

        /// <summary>
        /// Make an HTTP request
        /// </summary>
        /// <param name="request">Twilio request</param>
        /// <returns>Twilio response</returns>
        public override Response MakeRequest(NoAuthRequest request)
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
                this.LastResponse = new Response(response.StatusCode, content, response.Headers);
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
                this.LastResponse = new Response(errorResponse.StatusCode, GetResponseContent(errorResponse), errorResponse.Headers);
            }
            return this.LastResponse;
        }

        private string GetResponseContent(IHttpWebResponseWrapper response)
        {
            var reader = new StreamReader(response.GetResponseStream());
            return reader.ReadToEnd();
        }

        private IHttpWebRequestWrapper BuildHttpRequest(NoAuthRequest request)
        {
            IHttpWebRequestWrapper httpRequest = this.factory.Create(request.ConstructUrl());

            string helperLibVersion = AssemblyInfomation.AssemblyInformationalVersion;
            string osName = System.Environment.OSVersion.Platform.ToString();
            string osArch = System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE") ?? "Unknown";
            var libraryVersion = System.String.Format("twilio-csharp/{0} ({1} {2}) {3}", helperLibVersion, osName, osArch, PlatVersion);

            if (request.UserAgentExtensions != null)
            {
                foreach (var extension in request.UserAgentExtensions)
                {
                    libraryVersion += " " + extension;
                }
            }

            httpRequest.UserAgent = libraryVersion;

            httpRequest.Method = request.Method.ToString();
            httpRequest.Accept = "application/json";
            httpRequest.Headers["Accept-Encoding"] = "utf-8";
            httpRequest.ContentType = "application/x-www-form-urlencoded";

            return httpRequest;
        }
    }
}
#endif