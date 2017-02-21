namespace Twilio.Types
{
    /// <summary>
    /// Client Endpoint
    /// </summary>
    public class Client : IEndpoint
    {
        private readonly string _client;

        /// <summary>
        /// Create new client
        /// </summary>
        /// <param name="client">Client name</param>
        public Client(string client)
        {
            _client = client;
        }

        /// <summary>
        /// Convert to string
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            return _client;
        }
    }
}

