using System;

namespace Twilio.Jwt.Client
{
    public class IncomingClientScope : IScope
    {
        private static readonly string Scope = "scope:client:incoming";

        private readonly string _clientName;

        public IncomingClientScope(string clientName)
        {
            this._clientName = clientName;
        }

        public string Payload
        {
            get
            {
                var query = $"clientName={_clientName}";
                return $"{Scope}?{query}";
            }
        }
    }
}
