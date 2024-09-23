using System;
using System.Net;
using System.Linq;
using Newtonsoft.Json;
using Twilio.Exceptions;
using Twilio.Http.BearerToken;
using Twilio.Jwt;
using Twilio.Annotations;


#if !NET35
using System.Threading.Tasks;
#endif

using Twilio.Http;
using Twilio.Http.NoAuth;
#if NET35
using Twilio.Http.Net35;
#endif


namespace Twilio.Clients.NoAuth
{
    /// <summary>
    /// Implementation of a TwilioRestClient.
    /// </summary>
    [Beta]
    public class TwilioNoAuthRestClient
    {
        /// <summary>
        /// Client to make HTTP requests
        /// </summary>
        public NoAuthHttpClient HttpClient { get; }

        /// <summary>
        /// Twilio region to make requests to
        /// </summary>
        public string Region { get; }

        /// <summary>
        /// Twilio edge to make requests to
        /// </summary>
        public string Edge { get; set; }

        /// <summary>
        /// Additions to the user agent string
        /// </summary>
        public string[] UserAgentExtensions { get; set; }

        /// <summary>
        /// Log level for logging
        /// </summary>
        public string LogLevel { get; set; } = Environment.GetEnvironmentVariable("TWILIO_LOG_LEVEL");

        /// <summary>
        /// Constructor for a TwilioRestClient
        /// </summary>
        ///
        /// <param name="region">Region to make requests for</param>
        /// <param name="httpClient">HTTP client used to make the requests</param>
        /// <param name="edge">Edge to make requests for</param>
        public TwilioNoAuthRestClient(
            string region = null,
            NoAuthHttpClient httpClient = null,
            string edge = null
        )
        {

            HttpClient = httpClient ?? DefaultClient();

            Region = region;
            Edge = edge;
        }

        /// <summary>
        /// Make a request to the Twilio API
        /// </summary>
        ///
        /// <param name="request">request to make</param>
        /// <returns>response of the request</returns>
        public Response Request(NoAuthRequest request)
        {

            if (LogLevel == "debug")
                LogRequest(request);

            if (Region != null)
                request.Region = Region;

            if (Edge != null)
                request.Edge = Edge;

            if (UserAgentExtensions != null)
                request.UserAgentExtensions = UserAgentExtensions;

            Response response;
            try
            {
                response = HttpClient.MakeRequest(request);
                if (LogLevel == "debug")
                {
                    Console.WriteLine("response.status: " + response.StatusCode);
                    Console.WriteLine("response.headers: " + response.Headers);
                }
            }
            catch (Exception clientException)
            {
                throw new ApiConnectionException(
                    "Connection Error: " + request.Method + request.ConstructUrl(),
                    clientException
                );
            }
            return ProcessResponse(response);
        }


#if !NET35
        /// <summary>
        /// Make a request to the Twilio API
        /// </summary>
        ///
        /// <param name="request">request to make</param>
        /// <returns>Task that resolves to the response of the request</returns>
        public async Task<Response> RequestAsync(NoAuthRequest request)
        {

            if (Region != null)
                request.Region = Region;

            if (Edge != null)
                request.Edge = Edge;

            if (UserAgentExtensions != null)
                request.UserAgentExtensions = UserAgentExtensions;

            Response response;
            try
            {
                response = await HttpClient.MakeRequestAsync(request);
            }
            catch (Exception clientException)
            {
                throw new ApiConnectionException(
                    "Connection Error: " + request.Method + request.ConstructUrl(),
                    clientException
                );
            }
            return ProcessResponse(response);
        }

        private static NoAuthHttpClient DefaultClient()
        {
            return new SystemNetNoAuthHttpClient();
        }
#else
        private static NoAuthHttpClient DefaultClient()
        {
            return new WebNoAuthRequestClient();
        }
#endif

        private static Response ProcessResponse(Response response)
        {
            if (response == null)
            {
                throw new ApiConnectionException("Connection Error: No response received.");
            }

            if (response.StatusCode >= HttpStatusCode.OK && response.StatusCode < HttpStatusCode.BadRequest)
            {
                return response;
            }

            // Deserialize and throw exception
            RestException restException = null;
            try
            {
                restException = RestException.FromJson(response.Content);
            }
            catch (JsonReaderException) { /* Allow null check below to handle */ }

            if (restException == null)
            {
                throw new ApiException("Api Error: " + response.StatusCode + " - " + (response.Content ?? "[no content]"));
            }

            throw new ApiException(
                restException.Code,
                (int)response.StatusCode,
                restException.Message ?? "Unable to make request, " + response.StatusCode,
                restException.MoreInfo,
                restException.Details
            );
        }

        /// <summary>
        /// Test if your environment is impacted by a TLS or certificate change 
        /// by sending an HTTP request to the test endpoint tls-test.twilio.com:443
        /// It's a bit easier to call this method from TwilioClient.ValidateSslCertificate().
        /// </summary>
        public static void ValidateSslCertificate()
        {
            ValidateSslCertificate(DefaultClient());
        }

        /// <summary>
        /// Test that this application can use updated SSL certificates on
        /// tls-test.twilio.com:443. Generally, you'll want to use the version of this
        /// function that takes no parameters unless you have a reason not to.
        /// </summary>
        ///
        /// <param name="client">HTTP Client to use for testing the request</param>
        public static void ValidateSslCertificate(NoAuthHttpClient client)
        {
            NoAuthRequest request = new NoAuthRequest("GET", "tls-test", ":443/", null);

            try
            {
                Response response = client.MakeRequest(request);

                if (!response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    throw new CertificateValidationException(
                        "Unexpected response from certificate endpoint",
                        null,
                        response
                    );
                }
            }
            catch (CertificateValidationException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new CertificateValidationException(
                    "Connection to tls-test.twilio.com:443 failed",
                    e,
                    null
                );
            }
        }

        /// <summary>
        /// Format request information when LogLevel is set to debug
        /// </summary>
        ///
        /// <param name="request">HTTP request</param>
        private static void LogRequest(NoAuthRequest request)
        {
            Console.WriteLine("-- BEGIN Twilio API Request --");
            Console.WriteLine("request.method: " + request.Method);
            Console.WriteLine("request.URI: " + request.Uri);

            if (request.QueryParams != null)
            {
                request.QueryParams.ForEach(parameter => Console.WriteLine(parameter.Key + ":" + parameter.Value));
            }

            if (request.HeaderParams != null)
            {
                for (int i = 0; i < request.HeaderParams.Count; i++)
                {
                    var lowercaseHeader = request.HeaderParams[i].Key.ToLower();
                    if (lowercaseHeader.Contains("authorization") == false)
                    {
                        Console.WriteLine(request.HeaderParams[i].Key + ":" + request.HeaderParams[i].Value);
                    }
                }
            }

            Console.WriteLine("-- END Twilio API Request --");
        }
    }
}
