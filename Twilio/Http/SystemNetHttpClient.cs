#if NET40
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

        public SystemNetHttpClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public SystemNetHttpClient() : this(new System.Net.Http.HttpClient())
        {
            const string libraryVersion = "twilio-csharp/" + 
                AssemblyInfomation.AssemblyInformationalVersion + 
                PlatVersion;

            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.AcceptEncoding.Add(
                new StringWithQualityHeaderValue("utf-8"));
            _httpClient.DefaultRequestHeaders.UserAgent.Add(
                new ProductInfoHeaderValue(libraryVersion));
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
                var stream = await GetStreamAsync(httpRequest);
                await stream.WriteAsync(request.EncodePostParams(), 0, request.EncodePostParams().Length);
            }

            HttpResponseMessage response = null;
            try
            {
                response = await GetResponseAsync(httpRequest);
                var reader = new StreamReader(await response.Content.ReadAsStreamAsync());
                return new Response(response.StatusCode, await reader.ReadToEndAsync());
            }
            catch (AggregateException ae)
            {
                if (ae.InnerExceptions.OfType<HttpRequestException>().Any() &&
                    response != null)
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

        private async Task<Stream> GetStreamAsync(HttpRequestMessage request)
        {
            return await request.Content.ReadAsStreamAsync();
        }

        private async Task<HttpResponseMessage> GetResponseAsync(HttpRequestMessage request)
        {
            return await _httpClient.SendAsync(request);
        }

        private HttpRequestMessage BuildHttpRequest(Request request)
        {
            var httpRequest = new HttpRequestMessage(
                new System.Net.Http.HttpMethod(request.Method.ToString()), 
                request.ConstructUrl());
            var authBytes = Authentication(request.Username, request.Password);
            httpRequest.Headers.Authorization = 
                new AuthenticationHeaderValue("Basic", authBytes);
            httpRequest.Content.Headers.ContentType = 
                new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            return httpRequest;
        }
    }
}
#endif
