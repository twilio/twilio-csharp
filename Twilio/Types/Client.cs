namespace Twilio.Types
{
    public class Client : IEndpoint
    {
        private readonly string _client;

        public Client(string client)
        {
            _client = client;
        }

        public override string ToString()
        {
            return _client;
        }
    }
}

