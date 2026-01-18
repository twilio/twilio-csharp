
using System;
using System.Net;
using Newtonsoft.Json;
using Twilio.Exceptions;
using Twilio.AuthStrategies;
using System.Collections.Generic;

#if !NET35
using System.Threading.Tasks;
#endif

using Twilio.Http;
#if NET35
using Twilio.Http.Net35;
#endif

namespace Twilio.Clients
{
    /// <summary>
    /// Implementation of a TwilioRestClient.
    /// </summary>
    public class TwilioRestClient : ITwilioRestClient
    {
        /// <summary>
        /// Client to make HTTP requests
        /// </summary>
        public HttpClient HttpClient { get; }

        /// <summary>
        /// Account SID to use for requests
        /// </summary>
        public string AccountSid { get; }

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
        private readonly string _username;
        private readonly string _password;
        private readonly AuthStrategy _authstrategy;

        /// <summary>
        /// Constructor for a TwilioRestClient
        /// </summary>
        ///
        /// <param name="username">username for requests</param>
        /// <param name="password">password for requests</param>
        /// <param name="accountSid">account sid to make requests for</param>
        /// <param name="region">region to make requests for</param>
        /// <param name="httpClient">http client used to make the requests</param>
        /// <param name="edge">edge to make requests for</param>
        public TwilioRestClient(
            string username,
            string password,
            string accountSid = null,
            string region = null,
            HttpClient httpClient = null,
            string edge = null
        )
        {
            _username = username;
            _password = password;

            AccountSid = accountSid ?? username;
            HttpClient = httpClient ?? DefaultClient();

            if (GlobalConstants.IsOnlyOneSet(edge,region))
                Console.WriteLine("Deprecation Warning: For regional processing, DNS is of format product.edge.region.twilio.com;otherwise use product.twilio.com");

            Region = region;
            Edge = edge;
        }

        /// <summary>
        /// Constructor for a TwilioRestClient
        /// </summary>
        ///
        /// <param name="username">username for requests</param>
        /// <param name="password">password for requests</param>
        /// <param name="accountSid">account sid to make requests for</param>
        /// <param name="region">region to make requests for</param>
        /// <param name="httpClient">http client used to make the requests</param>
        /// <param name="edge">edge to make requests for</param>
        /// <param name="authstrategy">authentication strategy that will be used to make requests for</param>
        public TwilioRestClient(
            string username,
            string password,
            AuthStrategy authstrategy,
            string accountSid = null,
            string region = null,
            HttpClient httpClient = null,
            string edge = null
        )
        {
            _username = username;
            _password = password;
            _authstrategy = authstrategy;

            AccountSid = accountSid ?? username;
            HttpClient = httpClient ?? DefaultClient();

            if (GlobalConstants.IsOnlyOneSet(edge,region))
                 Console.WriteLine("Deprecation Warning: For regional processing, DNS is of format product.edge.region.twilio.com;otherwise use product.twilio.com");

            Region = region;
            Edge = edge;
        }

        /// <summary>
        /// Make a request to the Twilio API
        /// </summary>
        ///
        /// <param name="request">request to make</param>
        /// <returns>response of the request</returns>
        public Response Request(Request request)
        {

            if (string.IsNullOrEmpty(Edge) && !string.IsNullOrEmpty(Region) && GlobalConstants.RegionToEdgeMap.TryGetValue(Region, out var edge))
            {
                Console.WriteLine("Deprecation Warning: Setting default `edge` for provided `region`");
                Edge = edge;
            }

            if(_username != null && _password != null){
                request.SetAuth(_username, _password);
            }
            else if(_authstrategy != null){
                request.SetAuth(_authstrategy);
            }

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
        public async Task<Response> RequestAsync(Request request)
        {
            if(_username != null && _password != null){
                request.SetAuth(_username, _password);
            }
            else if(_authstrategy != null){
                request.SetAuth(_authstrategy);
            }

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

        private static HttpClient DefaultClient()
        {
            return new SystemNetHttpClient();
        }
#else
        private static HttpClient DefaultClient()
        {
            return new WebRequestClient();
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

            if (restException != null)
            {
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to make request, " + response.StatusCode,
                    restException.MoreInfo,
                    restException.Details
                );
            }

            
            // Try to deserialize as RFC 9457 format first (RestApiStandardException)
            RestApiStandardException restApiStandardException = null;
            try
            {
                restApiStandardException = RestApiStandardException.FromJson(response.Content);
            }
            catch (JsonReaderException) { /* Allow fallback to legacy format */ }

            // Check if it's a valid RFC 9457 response (has 'type' field)
            if (restApiStandardException != null)
            {
                throw new ApiStandardException(
                    restApiStandardException.Code,
                    (int)response.StatusCode,
                    restApiStandardException.Detail ?? restApiStandardException.Title ?? "Unable to make request, " + response.StatusCode,
                    restApiStandardException.Type,
                    restApiStandardException.Title,
                    restApiStandardException.Instance,
                    restApiStandardException.Errors
                );
            }
            
            // If both RestException and RestApiStandardException are null and throw default exception
            throw new ApiException("Api Error: " + response.StatusCode + " - " + (response.Content ?? "[no content]"));
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
        public static void ValidateSslCertificate(HttpClient client)
        {
            Request request = new Request("GET", "tls-test", ":443/", null);

            try
            {
                Response response = client.MakeRequest(request);

                if (!response.StatusCode.Equals(HttpStatusCode.OK))
                {
                    throw new CertificateValidationException(
                        "Unexpected response from certificate endpoint",
                        request,
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
                    request
                );
            }
        }

        /// <summary>
        /// Format request information when LogLevel is set to debug
        /// </summary>
        ///
        /// <param name="request">HTTP request</param>
        private static void LogRequest(Request request)
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
