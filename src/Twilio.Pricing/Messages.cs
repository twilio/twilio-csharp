using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.Pricing
{
    public partial class PricingClient
    {
        public virtual MessagingCountryResult ListMessagingCountries()
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "Messaging/Countries";

            return Execute<MessagingCountryResult>(request);
        }

        public virtual MessagingCountry GetMessagingCountry(string isoCountry)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "Messaging/Countries/{IsoCountry}";
            request.AddUrlSegment("IsoCountry", isoCountry);

            return Execute<MessagingCountry>(request);
        }
    }
}
