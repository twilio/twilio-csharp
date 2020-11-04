using Twilio.Clients;
using Twilio.Exceptions;

namespace Twilio
{
    /// <summary>
    /// Default Twilio Client
    /// </summary>
    public class TwilioClient
    {
        private static string _username;
        private static string _password;
        private static string _accountSid;
        private static string _region;
        private static string _edge;
        private static ITwilioRestClient _restClient;
        private static string _logLevel;

        private TwilioClient() { }

        /// <summary>
        /// Initialize base client with username and password
        /// </summary>
        /// <param name="username">Auth username</param>
        /// <param name="password">Auth password</param>
        public static void Init(string username, string password)
        {
            SetUsername(username);
            SetPassword(password);
        }

        /// <summary>
        /// Initialize base client with separate account SID
        /// </summary>
        /// <param name="username">Auth username</param>
        /// <param name="password">Auth password</param>
        /// <param name="accountSid">Account SID to use</param>
        public static void Init(string username, string password, string accountSid)
        {
            SetUsername(username);
            SetPassword(password);
            SetAccountSid(accountSid);
        }

        /// <summary>
        /// Set the client username
        /// </summary>
        /// <param name="username">Auth username</param>
        public static void SetUsername(string username)
        {
            if (username == null)
            {
                throw new AuthenticationException("Username can not be null");
            }

            if (username != _username)
            {
                Invalidate();
            }

            _username = username;
        }

        /// <summary>
        /// Set the client password
        /// </summary>
        /// <param name="password">Auth password</param>
        public static void SetPassword(string password)
        {
            if (password == null)
            {
                throw new AuthenticationException("Password can not be null");
            }

            if (password != _password)
            {
                Invalidate();
            }

            _password = password;
        }

        /// <summary>
        /// Set the client Account SID
        /// </summary>
        /// <param name="accountSid">Client Account SID</param>
        public static void SetAccountSid(string accountSid)
        {
            if (accountSid == null)
            {
                throw new AuthenticationException("AccountSid can not be null");
            }

            if (accountSid != _accountSid)
            {
                Invalidate();
            }

            _accountSid = accountSid;
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

            _logLevel = loglevel;
        }

        /// <summary>
        /// Get the rest client
        /// </summary>
        /// <returns>The rest client</returns>
        public static ITwilioRestClient GetRestClient()
        {
            if (_restClient != null)
            {
                return _restClient;
            }

            if (_username == null || _password == null)
            {
                throw new AuthenticationException(
                    "TwilioRestClient was used before AccountSid and AuthToken were set, please call TwilioClient.init()"
                );
            }

            _restClient = new TwilioRestClient(_username, _password, accountSid: _accountSid, region: _region, edge: _edge)
            {
                LogLevel = _logLevel
            };
            return _restClient;
        }

        /// <summary>
        /// Set the rest client
        /// </summary>
        /// <param name="restClient">Rest Client to use</param>
        public static void SetRestClient(ITwilioRestClient restClient)
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
        /// Validates that the Twilio Client can connect to api.twilio.com with
        /// a new SSL certificate posted at api.twilio.com:8443
        /// </summary>
        public static void ValidateSslCertificate()
        {
            TwilioRestClient.ValidateSslCertificate();
        }
    }
}
