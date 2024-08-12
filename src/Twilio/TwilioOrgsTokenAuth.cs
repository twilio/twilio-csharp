using Twilio.Clients;
using Twilio.Clients.BearerToken;
using Twilio.Exceptions;
using Twilio.Http.BearerToken;

namespace Twilio
{
    /// <summary>
    /// Default Twilio Client for bearer token authentication
    /// </summary>
    public class TwilioOrgsTokenAuthClient
    {
        private static string _accessToken;
        private static string _region;
        private static string _edge;
        private static TwilioBearerTokenRestClient _restClient;
        private static string _logLevel;
        private static TokenManager _tokenManager;
        private static ClientProperties clientProperties;

        private TwilioOrgsTokenAuthClient() { }

        /// <summary>
        /// Initialize base client with username and password
        /// </summary>
        public static void Init(string grantType, string clientId, string clientSecret)
        {
            validateCredentials(grantType, clientId, clientSecret);
            _tokenManager = new OrgsTokenManager(grantType, clientId, clientSecret);
        }


        /// <summary>
        /// Initialize base client
        /// </summary>
        public static void Init(string grantType, string clientId, string clientSecret,
                               string code = null,
                               string redirectUri = null,
                               string audience = null,
                               string refreshToken = null,
                               string scope = null)
        {
            validateCredentials(grantType, clientId, clientSecret);
            _tokenManager = new OrgsTokenManager(grantType, clientId, clientSecret, code, redirectUri, audience, refreshToken, scope);
        }


        /// <summary>
        /// Validate grant type, client id and client secret and verify none of them are null
        /// </summary>
        public static void validateCredentials(string grantType, string clientId, string clientSecret)
        {
            if (grantType == null)
            {
                throw new AuthenticationException("grantType can not be null");
            }
            if (clientId == null)
            {
                throw new AuthenticationException("clientId can not be null");
            }
            if (clientSecret == null)
            {
                throw new AuthenticationException("clientSecret can not be null");
            }

        }

        /// <summary>
        /// Set the client region
        /// </summary>
        /// <param name="region">Client region</param>
        public static void SetRegion(string region)
        {
            if (region != _region)
            {
                Invalidate();
            }
            ClientProperties.SetRegion(region);
            _region = region;
        }

        /// <summary>
        /// Set the client edge
        /// </summary>
        /// <param name="edge">Client edge</param>
        public static void SetEdge(string edge)
        {
            if (edge != _edge)
            {
                Invalidate();
            }
            ClientProperties.SetEdge(edge);
            _edge = edge;
        }

        /// <summary>
        /// Set the logging level
        /// </summary>
        /// <param name="loglevel">log level</param>
        public static void SetLogLevel(string loglevel)
        {
            if (loglevel != _logLevel)
            {
                Invalidate();
            }
            ClientProperties.SetLogLevel(_logLevel);
            _logLevel = loglevel;
        }

        /// <summary>
        /// Get the rest client
        /// </summary>
        /// <returns>The rest client</returns>
        public static TwilioBearerTokenRestClient GetRestClient()
        {
            if (_restClient != null)
            {
                return _restClient;
            }

            if (_tokenManager == null)
            {
                throw new AuthenticationException(
                    "TwilioBearerTokenRestClient was used before token manager was set, please call TwilioClient.init()"
                );
            }

            _restClient = new TwilioBearerTokenRestClient(_tokenManager, region: _region, edge: _edge)
            {
                LogLevel = _logLevel
            };
            return _restClient;
        }

        /// <summary>
        /// Set the rest client
        /// </summary>
        /// <param name="restClient">Rest Client to use</param>
        public static void SetRestClient(TwilioBearerTokenRestClient restClient)
        {
            _restClient = restClient;
        }

        /// <summary>
        /// Clear out the Rest Client
        /// </summary>
        public static void Invalidate()
        {
            _restClient = null;
        }

        /// <summary>
        /// Test if your environment is impacted by a TLS or certificate change
        /// by sending an HTTP request to the test endpoint tls-test.twilio.com:443
        /// </summary>
        public static void ValidateSslCertificate()
        {
            TwilioRestClient.ValidateSslCertificate();
        }
    }
}
