#if !NET35
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Text;
using Twilio.Constant;
using Twilio.Annotations;

namespace Twilio.Http.NoAuth
{
    /// <summary>
    /// Sample client to make HTTP requests
    /// </summary>
    [Deprecated]
    public class SystemNetNoAuthHttpClient : NoAuthHttpClient
    {
#if NET462
        private string PlatVersion = ".NET Framework 4.6.2+";
#else
        private string PlatVersion = RuntimeInformation.FrameworkDescription;
#endif

        private readonly System.Net.Http.HttpClient _httpClient;

        /// <summary>
        /// Create new HttpClient
        /// </summary>
        /// <param name="httpClient">HTTP client to use</param>
        public SystemNetNoAuthHttpClient(System.Net.Http.HttpClient httpClient = null)
        {
            _httpClient = httpClient ?? new System.Net.Http.HttpClient(new HttpClientHandler() { AllowAutoRedirect = false });
        }

        /// <summary>
        /// Make a synchronous request
        /// </summary>
        /// <param name="request">Twilio request</param>
        /// <returns>Twilio response</returns>
        public override Response MakeRequest(NoAuthRequest request)
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
        public override async Task<Response> MakeRequestAsync(NoAuthRequest request)
        {
            var httpRequest = BuildHttpRequest(request);
            if (!Equals(request.Method, HttpMethod.Get))
            {
                if (request.ContentType == null)
                    request.ContentType = EnumConstants.ContentTypeEnum.FORM_URLENCODED;

                if (Equals(request.ContentType, EnumConstants.ContentTypeEnum.JSON))
                    httpRequest.Content = new StringContent(request.Body, Encoding.UTF8, "application/json");

                else if (Equals(request.ContentType, EnumConstants.ContentTypeEnum.SCIM))
                    httpRequest.Content = new StringContent(request.Body, Encoding.UTF8, "application/scim");
                
                else if(Equals(request.ContentType, EnumConstants.ContentTypeEnum.FORM_URLENCODED))
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

        private HttpRequestMessage BuildHttpRequest(NoAuthRequest request)
        {
            var httpRequest = new HttpRequestMessage(
                new System.Net.Http.HttpMethod(request.Method.ToString()),
                request.ConstructUrl()
            );

            httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpRequest.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("utf-8"));

            int lastSpaceIndex = PlatVersion.LastIndexOf(" ");
            System.Text.StringBuilder PlatVersionSb= new System.Text.StringBuilder(PlatVersion);
            PlatVersionSb[lastSpaceIndex] = '/';

            string helperLibVersion = AssemblyInfomation.AssemblyInformationalVersion;

            string osName = "Unknown";
            osName = Environment.OSVersion.Platform.ToString();

            string osArch;
#if !NET462
            osArch = RuntimeInformation.OSArchitecture.ToString();
#else
            osArch = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE") ?? "Unknown"; 
#endif
            var libraryVersion = String.Format("twilio-csharp/{0} ({1} {2}) {3}", helperLibVersion, osName, osArch, PlatVersionSb);

            if (request.UserAgentExtensions != null)
            {
                foreach (var extension in request.UserAgentExtensions)
                {
                    libraryVersion += " " + extension;
                }
            }

            httpRequest.Headers.TryAddWithoutValidation("User-Agent", libraryVersion);

            foreach (var header in request.HeaderParams)
            {
                httpRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }

            return httpRequest;
        }
    }
}
#endif
