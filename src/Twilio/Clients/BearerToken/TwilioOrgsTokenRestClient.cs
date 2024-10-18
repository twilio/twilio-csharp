using System;
using System.Net;
using System.Linq;
using Newtonsoft.Json;
using Twilio.Exceptions;
using Twilio.Http.BearerToken;
using Twilio.Jwt;
using Twilio.Clients;
using Twilio.Annotations;

#if !NET35
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
#endif

using Twilio.Http;
using Twilio.Http.BearerToken;
#if NET35
using Twilio.Http.Net35;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;
#endif


namespace Twilio.Clients.BearerToken
{
    /// <summary>
    /// Implementation of a TwilioRestClient.
    /// </summary>
    [Deprecated]
    public class TwilioOrgsTokenRestClient
    {
        /// <summary>
        /// Client to make HTTP requests
        /// </summary>
        public TokenHttpClient HttpClient { get; }

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
        /// Token Manage for managing and refreshing tokens
        /// </summary>
        private TokenManager _tokenManager { get; set; }

        /// <summary>
        /// Access token used for rest calls with bearer token authentication method
        /// </summary>
        private string _accessToken;

        private readonly object lockObject = new object();

        /// <summary>
        /// Constructor for a TwilioRestClient
        /// </summary>
        ///
        /// <param name="tokenManager">to manage access token for requests</param>
        /// <param name="accountSid">account sid to make requests for</param>
        /// <param name="region">region to make requests for</param>
        /// <param name="httpClient">http client used to make the requests</param>
        /// <param name="edge">edge to make requests for</param>
        public TwilioOrgsTokenRestClient(
            TokenManager tokenManager,
            string region = null,
            TokenHttpClient httpClient = null,
            string edge = null
        )
        {
            _tokenManager = tokenManager;

            HttpClient = httpClient ?? DefaultClient();

            Region = region;
            Edge = edge;
        }

        /// <summary>
        /// Check if an access token is expired or not. Use the System.IdentityModel.Tokens.Jwt; for versions other
        /// than net35 and use redirect to custom function if net35
        /// </summary>
        ///
        /// <param name="accessToken">access token for which expiry have to be checked</param>
        /// <returns>true if expired, false otherwise</returns>
        public bool tokenExpired(String accessToken){
            #if NET35
            return IsTokenExpired(accessToken);
            #else
            return isTokenExpired(accessToken);
            #endif
        }

        /// <summary>
        /// Make a request to the Twilio API
        /// </summary>
        ///
        /// <param name="request">request to make</param>
        /// <returns>response of the request</returns>
        public Response Request(TokenRequest request)
        {
            if ((_accessToken == null )|| tokenExpired(_accessToken)) {
                lock (lockObject){
                    if ((_accessToken == null) || tokenExpired(_accessToken)) {
                        _accessToken = _tokenManager.fetchAccessToken();
                    }
                }
            }
            request.SetAuth(_accessToken);

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

#if NET35
    public static bool IsTokenExpired(string token)
        {
            try
            {
                // Split the token into its components
                var parts = token.Split('.');
                if (parts.Length != 3)
                    throw new ArgumentException("Malformed token received");

                // Decode the payload (the second part of the JWT)
                string payload = Base64UrlEncoder.Decode(parts[1]);

                // Parse the payload JSON
                var serializer = new JavaScriptSerializer();
                var payloadData = serializer.Deserialize<Dictionary<string, object>>(payload);

                // Check the 'exp' claim
                if (payloadData.TryGetValue("exp", out object expObj))
                {
                    if (long.TryParse(expObj.ToString(), out long exp))
                    {
                        DateTime expirationDate = UnixTimeStampToDateTime(exp);
                        return DateTime.UtcNow > expirationDate;
                    }
                }

                // If 'exp' claim is missing or not a valid timestamp, consider the token expired
                throw new ApiConnectionException("token expired 1");
                return true;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., malformed token or invalid JSON)
                Console.WriteLine($"Error checking token expiration: {ex.Message}");
                throw new ApiConnectionException("token expired 2");
                return true; // Consider as expired if there's an error
            }
        }

        private static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTimeStamp);
        }
#endif

#if !NET35
        public bool isTokenExpired(string token){
            var handler = new JwtSecurityTokenHandler();
            try{
                var jwtToken = handler.ReadJwtToken(token);
                var exp = jwtToken.Payload.Exp;
                if (exp.HasValue)
                    {
                        var expirationDate = DateTimeOffset.FromUnixTimeSeconds(exp.Value).UtcDateTime;
                        return DateTime.UtcNow > expirationDate;
                    }
                else
                {
                    return true; // Assuming token is expired if exp claim is missing
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading token: {ex.Message}");

                return true; // Treat as expired if there is an error
            }
        }
#endif

#if !NET35
        /// <summary>
        /// Make a request to the Twilio API
        /// </summary>
        ///
        /// <param name="request">request to make</param>
        /// <returns>Task that resolves to the response of the request</returns>
        public async Task<Response> RequestAsync(TokenRequest request)
        {
            request.SetAuth(_accessToken);

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

        private static TokenHttpClient DefaultClient()
        {
            return new SystemNetTokenHttpClient();
        }
#else
        private static TokenHttpClient DefaultClient()
        {
            return new WebBearerTokenRequestClient();
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
        public static void ValidateSslCertificate(TokenHttpClient client)
        {
            TokenRequest request = new TokenRequest("GET", "tls-test", ":443/", null);

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
        private static void LogRequest(TokenRequest request)
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
