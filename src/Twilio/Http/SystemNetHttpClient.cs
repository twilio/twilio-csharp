#if !NET35
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Text;

namespace Twilio.Http
{
    /// <summary>
    /// Sample client to make HTTP requests
    /// </summary>
    public class SystemNetHttpClient : HttpClient
    {
        private static readonly string LibraryVersion = BuildLibraryVersion();
        private readonly System.Net.Http.HttpClient _httpClient;

        /// <summary>
        /// Create new HttpClient
        /// </summary>
        /// <param name="httpClient">HTTP client to use</param>
        public SystemNetHttpClient(System.Net.Http.HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new System.Net.Http.HttpClient(new HttpClientHandler() { AllowAutoRedirect = false });
        }

        /// <summary>
        /// Make a synchronous request
        /// </summary>
        /// <param name="request">Twilio request</param>
        /// <returns>Twilio response</returns>
        public override Response MakeRequest(Request request)
        {
            try
            {
                var task = MakeRequestAsync(request);
                task.Wait();
                return task.Result;
            }
            catch (AggregateException ae)
            {
                // Combine nested AggregateExceptions
                ae = ae.Flatten();
                throw ae.InnerExceptions[0];
            }
        }

        /// <summary>
        /// Make an asynchronous request
        /// </summary>
        /// <param name="request">Twilio response</param>
        /// <returns>Task that resolves to the response</returns>
        public override async Task<Response> MakeRequestAsync(Request request)
        {
            var httpRequest = BuildHttpRequest(request);
            if (!Equals(request.Method, HttpMethod.Get))
            {
                httpRequest.Content = new FormUrlEncodedContent(request.PostParams);
            }

            this.LastRequest = request;
            this.LastResponse = null;

            var httpResponse = await _httpClient.SendAsync(httpRequest).ConfigureAwait(false);
            var reader = new StreamReader(await httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false));

            // Create and return a new Response. Keep a reference to the last
            // response for debugging, but don't return it as it may be shared
            // among threads.
            var response = new Response(httpResponse.StatusCode, await reader.ReadToEndAsync().ConfigureAwait(false), httpResponse.Headers);
            this.LastResponse = response;
            return response;
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

            var userAgent = LibraryVersion;
            if (request.UserAgentExtensions != null)
            {
                var userAgentBuilder = new StringBuilder(userAgent);
                foreach (var extension in request.UserAgentExtensions)
                {
                    userAgentBuilder.Append($" {extension}");
                }

                userAgent = userAgentBuilder.ToString();
            }

            httpRequest.Headers.TryAddWithoutValidation("User-Agent", userAgent);

            foreach (var header in request.HeaderParams)
            {
                httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return httpRequest;
        }

        private static string BuildLibraryVersion()
        {
            var frameworkDescription = RuntimeInformation.FrameworkDescription;
            var platformVersionSb = new StringBuilder(frameworkDescription);
            
            // Twilio runs CI tests on Mono, where the framework description looks like this:
            // Mono 6.12.0.182 (tarball Tue Jun 14 22:35:00 UTC/2022)
            // The following code removes the (tarball ...) part from the framework description.
            if (frameworkDescription.StartsWith("Mono ", StringComparison.Ordinal))
            {
                var tarbalDateIndex = frameworkDescription.IndexOf(" (tarball");
                platformVersionSb.Remove(tarbalDateIndex, frameworkDescription.Length - tarbalDateIndex);
                frameworkDescription = platformVersionSb.ToString();
            }
            platformVersionSb[frameworkDescription.LastIndexOf(" ", StringComparison.Ordinal)] = '/';

            const string helperLibraryVersion = AssemblyInfomation.AssemblyInformationalVersion;

            var osName = "Unknown";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                osName = "Windows";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                osName = "MacOS";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                osName = "Linux";
            }

            var osArch = RuntimeInformation.OSArchitecture.ToString();
            return $"twilio-csharp/{helperLibraryVersion} ({osName} {osArch}) {platformVersionSb}";
        }
    }
}
#endif