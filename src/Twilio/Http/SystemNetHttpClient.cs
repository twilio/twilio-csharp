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
    public class SystemNetHttpClient : HttpClient
    {
        private const string PlatVersion = " (.NET 4+)";

        private readonly System.Net.Http.HttpClient _httpClient;

        public SystemNetHttpClient(System.Net.Http.HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new System.Net.Http.HttpClient();
        }

        public override Response MakeRequest(Request request)
        {
            var task = MakeRequestAysnc(request);
            task.Wait();
            return task.Result;
        }

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
                response = await _httpClient.SendAsync(httpRequest); 
                var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
                return new Response(response.StatusCode, await reader.ReadToEndAsync());
            }
            catch (AggregateException ae)
            {
                if (ae.InnerExceptions.OfType<HttpRequestException>().Any() && response != null)
                {
                    throw await HandleErrorResponse(response);
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

            var responseStream = await errorResponse.Content.ReadAsStreamAsync();
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
