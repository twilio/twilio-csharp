using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Clients.NoAuth;

namespace Twilio
{
    /// <summary>
    /// Default Twilio Client
    /// </summary>
    public class TwilioNoAuthClient
    {

        private static string _region;
        private static string _edge;
        private static TwilioNoAuthRestClient _restClient;
        private static string _logLevel;

        private TwilioNoAuthClient() { }

        /// <summary>
        /// Get the rest client
        /// </summary>
        /// <returns>The rest client</returns>
        public static TwilioNoAuthRestClient GetRestClient()
        {
            if (_restClient != null)
            {
                return _restClient;
            }

            _restClient = new TwilioNoAuthRestClient(region: _region, edge: _edge)
            {
                LogLevel = _logLevel
            };
            return _restClient;
        }

        /// <summary>
        /// Set the rest client
        /// </summary>
        /// <param name="restClient">Rest Client to use</param>
        public static void SetRestClient(TwilioNoAuthRestClient restClient)
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
            TwilioNoAuthRestClient.ValidateSslCertificate();
        }
    }
}
