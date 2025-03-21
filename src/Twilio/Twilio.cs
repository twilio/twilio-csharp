using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Credential;
using Twilio.AuthStrategies;
using Twilio.Annotations;

namespace Twilio
{
    /// <summary>
    /// Default Twilio Client
    /// </summary>
    public class TwilioClient
    {
        private static string _username;
        private static string _password;
        private static AuthStrategy _authstrategy;
        private static string _accountSid;
        private static string _region;
        private static string _edge;
        private static ITwilioRestClient _restClient;
        private static ITwilioRestClient _noAuthRestClient;
        private static string _logLevel;
        private static CredentialProvider _credentialProvider;

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
        /// Initialize base client with credentialProvider
        /// </summary>
        /// <param name="credentialProvider">credentialProvider with credential information</param>
        public static void Init(CredentialProvider credentialProvider)
        {
            SetCredentialProvider(credentialProvider);
        }

        /// <summary>
        /// Initialize base client with credentialProvider and account sid
        /// </summary>
        /// <param name="credentialProvider">credentialProvider with credential information</param>
        public static void Init(CredentialProvider credentialProvider, string accountSid)
        {
            SetCredentialProvider(credentialProvider);
            SetAccountSid(accountSid);
        }

        /// <summary>
        /// Set the credential provider
        /// </summary>
        /// <param name="credentialProvider">credentialProvider with credential information</param>
        public static void SetCredentialProvider(CredentialProvider credentialProvider)
        {
            if (credentialProvider == null)
            {
                throw new AuthenticationException("Credential Provider can not be null");
            }

            if (credentialProvider != _credentialProvider)
            {
                Invalidate();
            }
            InvalidateBasicCreds();

            _credentialProvider = credentialProvider;
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
            InvalidateOAuthCreds();

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
            InvalidateOAuthCreds();

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
                InvalidateNoAuth();
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
                InvalidateNoAuth();
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
                InvalidateNoAuth();
            }

            _logLevel = loglevel;
        }


        /// <summary>
        /// Get the no auth rest client
        /// </summary>
        /// <returns>The no auth rest client</returns>
        public static ITwilioRestClient GetNoAuthRestClient()
        {
            if (_noAuthRestClient != null)
            {
                return _noAuthRestClient;
            }

            AuthStrategy noauthstrategy = new NoAuthStrategy();
           _noAuthRestClient = new TwilioRestClient(_username, _password, authstrategy: noauthstrategy, accountSid: _accountSid, region: _region, edge: _edge)
           {
               LogLevel = _logLevel
           };

            return _noAuthRestClient;
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
                if(_credentialProvider == null){
                    throw new AuthenticationException(
                                    "Credentials have not been initialized or changed, please call TwilioClient.init()"
                                );
                }
            }

            if(_username != null && _password != null){
                _restClient = new TwilioRestClient(_username, _password, accountSid: _accountSid, region: _region, edge: _edge)
                {
                    LogLevel = _logLevel
                };
            }
            else if(_credentialProvider != null){
                AuthStrategy authstrategy = _credentialProvider.ToAuthStrategy();
               _restClient = new TwilioRestClient(_username, _password, authstrategy: _credentialProvider.ToAuthStrategy(), accountSid: _accountSid, region: _region, edge: _edge)
               {
                   LogLevel = _logLevel
               };
            }

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
        /// Clear out the No Auth Rest Client
        /// </summary>
        public static void InvalidateNoAuth()
        {
            _noAuthRestClient = null;
        }

        /// <summary>
        /// Clear out the credential provider
        /// </summary>
        public static void InvalidateOAuthCreds()
        {
            _credentialProvider = null;
        }

        /// <summary>
        /// Clear out the basic credentials username and password
        /// </summary>
        public static void InvalidateBasicCreds()
        {
            _username = null;
            _password = null;
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
