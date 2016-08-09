using System;

namespace Twilio.Types
{
    public class Client : Endpoint
    {
        private string client;

        public Client(string client) {
            this.client = client;
        }

        public override string ToString() {
            return this.client;
        }
    }
}

