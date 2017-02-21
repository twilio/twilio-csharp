#if NET35
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Diagnostics;
using Twilio.Exceptions;
using Newtonsoft.Json;

namespace Twilio.Http
{

    /// <summary>
    /// Sample client to make requests
    /// </summary>
    public class WebRequestClient : HttpClient
    {
        private const string PlatVersion = " (.NET 3.5)";

        /// <summary>
        /// Make an HTTP request
        /// </summary>
        /// <param name="request">Twilio request</param>
        /// <returns>Twilio response</returns>
        public override Response MakeRequest(Request request)
        {
            var httpRequest = BuildHttpRequest(request);
            if (!Equals(request.Method, HttpMethod.Get))
            {
                var stream = GetStream(httpRequest);
                stream.Write(request.EncodePostParams(), 0, request.EncodePostParams().Length);
                stream.Close();
            }

            try
            {
                var response = GetResponse(httpRequest);
                var reader = new StreamReader(response.GetResponseStream());
                return new Response(response.StatusCode, reader.ReadToEnd());
            }
            catch (WebException e)
            {
                throw HandleErrorResponse((HttpWebResponse) e.Response);
            }
        }

        private static Exception HandleErrorResponse(HttpWebResponse errorResponse)
        {
            if (errorResponse.StatusCode >= HttpStatusCode.InternalServerError &&
                errorResponse.StatusCode < HttpStatusCode.HttpVersionNotSupported)
            {
                return new TwilioException("Internal Server error: " + errorResponse.StatusDescription);
            }

            var responseStream = errorResponse.GetResponseStream();
            var errorReader = new StreamReader(responseStream);
            var errorContent = errorReader.ReadToEnd();

            try
            {
                var restEx = RestException.FromJson(errorContent);
                return restEx ?? new TwilioException("Error: " + errorResponse.StatusDescription + " - " + errorContent);
            }
            catch (JsonReaderException)
            {
                return new TwilioException("Error: " + errorResponse.StatusDescription + " - " + errorContent);
            }
        }

        private static void SetUserAgent(HttpWebRequest request)
        {
            var property = typeof(HttpWebRequest).GetProperty("UserAgent");
            if (property != null)
            {
                const string libraryVersion = "twilio-csharp/" + AssemblyInfomation.AssemblyInformationalVersion + PlatVersion;
                request.UserAgent = libraryVersion;
            }
        }

        private static Stream GetStream(WebRequest request)
        {
            return request.GetRequestStream();
        }

        private static HttpWebResponse GetResponse(WebRequest request)
        {
            return (HttpWebResponse) request.GetResponse();
        }

        private HttpWebRequest BuildHttpRequest(Request request)
        {
            var httpRequest = (HttpWebRequest) WebRequest.Create(request.ConstructUrl());
            SetUserAgent(httpRequest);

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
