using Twilio.Clients;
using Twilio.Clients.NoAuth;
using Twilio.Clients.BearerToken;
using Twilio.Exceptions;
using Twilio.Http.BearerToken;
using Twilio.Annotations;


namespace Twilio
{
    /// <summary>
    /// Default Twilio Client for bearer token authentication
    /// </summary>
    [Beta]
    public class TwilioOrgsTokenAuthClient
    {
        private static string _accessToken;
        private static string _region;
        private static string _edge;
        private static TwilioOrgsTokenRestClient _restClient;
        private static TwilioNoAuthRestClient _noAuthRestClient;
        private static string _logLevel;
        private static TokenManager _tokenManager;
        private static string _clientId;
        private static string _clientSecret;

        private TwilioOrgsTokenAuthClient() { }

        /// <summary>
        /// Initialize base client with username and password
        /// </summary>
        public static void Init(string clientId, string clientSecret)
        {
            SetClientId(clientId);
            SetClientSecret(clientSecret);
            SetTokenManager(new OrgsTokenManager(clientId, clientSecret));
        }


        /// <summary>
        /// Initialize base client
        /// </summary>
        public static void Init(string clientId, string clientSecret,
                               string code = null,
                               string redirectUri = null,
                               string audience = null,
                               string refreshToken = null,
                               string scope = null)
        {
            SetClientId(clientId);
            SetClientSecret(clientSecret);
            SetTokenManager(new OrgsTokenManager(clientId, clientSecret, code, redirectUri, audience, refreshToken, scope));
        }

        /// <summary>
        /// Set the token manager
        /// </summary>
        /// <param name="tokenManager">token manager</param>
        public static void SetTokenManager(TokenManager tokenManager)
        {
            if (tokenManager == null)
            {
                throw new AuthenticationException("Token Manager  can not be null");
            }

            if (tokenManager != _tokenManager)
            {
                Invalidate();
            }

            _tokenManager = tokenManager;
        }

        /// <summary>
        /// Set the client id
        /// </summary>
        /// <param name="clientId">client id of the organisation</param>
        public static void SetClientId(string clientId)
        {
            if (clientId == null)
            {
                throw new AuthenticationException("Client Id  can not be null");
            }

            if (clientId != _clientId)
            {
                Invalidate();
            }

            _clientId = clientId;
        }

        /// <summary>
        /// Set the client secret
        /// </summary>
        /// <param name="clientSecret">client secret of the organisation</param>
        public static void SetClientSecret(string clientSecret)
        {
            if (clientSecret == null)
            {
                throw new AuthenticationException("Client Secret  can not be null");
            }

            if (clientSecret != _clientSecret)
            {
                Invalidate();
            }

            _clientSecret = clientSecret;
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
                InvalidateNoAuthClient();
            }
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
                InvalidateNoAuthClient();
            }
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
                InvalidateNoAuthClient();
            }
            _logLevel = loglevel;
        }

        /// <summary>
        /// Get the rest client
        /// </summary>
        /// <returns>The rest client</returns>
        public static TwilioOrgsTokenRestClient GetRestClient()
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

            _restClient = new TwilioOrgsTokenRestClient(_tokenManager, region: _region, edge: _edge)
            {
                LogLevel = _logLevel
            };
            return _restClient;
        }


        /// <summary>
        /// Get the noauth rest client
        /// </summary>
        /// <returns>The not auth rest client</returns>
        public static TwilioNoAuthRestClient GetNoAuthRestClient()
        {
            if (_noAuthRestClient != null)
            {
                return _noAuthRestClient;
            }

            _noAuthRestClient = new TwilioNoAuthRestClient(region: _region, edge: _edge)
            {
                LogLevel = _logLevel
            };
            return _noAuthRestClient;
        }

        /// <summary>
        /// Set the rest client
        /// </summary>
        /// <param name="restClient">Rest Client to use</param>
        public static void SetRestClient(TwilioOrgsTokenRestClient restClient)
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
        /// Clear out the Rest Client
        /// </summary>
        public static void InvalidateNoAuthClient()
        {
            _noAuthRestClient = null;
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
