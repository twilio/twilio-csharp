#if !NET35
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Twilio.Exceptions;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Twilio.Http
{
    /// <summary>
    /// Sample client to make HTTP requests
    /// </summary>
    public class SystemNetHttpClient : HttpClient
    {
        private const string PlatVersion = " (.NET 4+)";

        private readonly System.Net.Http.HttpClient _httpClient;

        /// <summary>
        /// Create new HttpClient
        /// </summary>
        /// <param name="httpClient">HTTP client to use</param>
        public SystemNetHttpClient(System.Net.Http.HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new System.Net.Http.HttpClient();
        }

        /// <summary>
        /// Make a synchronous request
        /// </summary>
        /// <param name="request">Twilio request</param>
        /// <returns>Twilio response</returns>
        public override Response MakeRequest(Request request)
        {
            var task = MakeRequestAysnc(request);
            task.Wait();
            return task.Result;
        }

        /// <summary>
        /// Make an asynchronous request
        /// </summary>
        /// <param name="request">Twilio response</param>
        /// <returns>Task that resolves to the response</returns>
        public override async Task<Response> MakeRequestAysnc(Request request)
        {
            var httpRequest = BuildHttpRequest(request);
            if (!Equals(request.Method, HttpMethod.Get))
            {
                httpRequest.Content = new FormUrlEncodedContent(request.PostParams);
            }

            HttpResponseMessage response = null;
            try
            {
                response = await _httpClient.SendAsync(httpRequest).ConfigureAwait(false); 
                var reader = new StreamReader(await response.Content.ReadAsStreamAsync().ConfigureAwait(false));
                return new Response(response.StatusCode, await reader.ReadToEndAsync().ConfigureAwait(false));
            }
            catch (AggregateException ae)
            {
                if (ae.InnerExceptions.OfType<HttpRequestException>().Any() && response != null)
                {
                    throw await HandleErrorResponse(response).ConfigureAwait(false);
                }
            }
            return null;
        }

        private async Task<Exception> HandleErrorResponse(HttpResponseMessage errorResponse)
        {
            if (errorResponse.StatusCode >= HttpStatusCode.InternalServerError &&
                errorResponse.StatusCode < HttpStatusCode.HttpVersionNotSupported)
            {
                return new TwilioException("Internal Server error: " + errorResponse.StatusCode);
            }

            var responseStream = await errorResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
            var errorReader = new StreamReader(responseStream);
            var errorContent = errorReader.ReadToEnd();

            try
            {
                var restEx = RestException.FromJson(errorContent);
                return restEx ?? new TwilioException("Error: " + errorResponse.StatusCode + " - " + errorContent);
            }
            catch (JsonReaderException)
            {
                return new TwilioException("Error: " + errorResponse.StatusCode + " - " + errorContent);
            }
        }

        private HttpRequestMessage BuildHttpRequest(Request request)
        {
            var httpRequest = new HttpRequestMessage(
                new System.Net.Http.HttpMethod(request.Method.ToString()), 
                request.ConstructUrl()
            );

            var authBytes = Authentication(request.Username, request.Password);
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", authBytes);

            httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpRequest.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("utf-8"));

            const string libraryVersion = "twilio-csharp/" + AssemblyInfomation.AssemblyInformationalVersion + PlatVersion;
            httpRequest.Headers.TryAddWithoutValidation("User-Agent", libraryVersion);

            return httpRequest;
        }
    }
}
#endif
