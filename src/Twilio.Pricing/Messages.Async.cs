using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.Pricing
{
    public partial class PricingClient
    {
        public virtual void ListMessagingCountries(Action<MessagingCountryResult> callback)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "Messaging/Countries";

            ExecuteAsync<MessagingCountryResult>(request, (response) => callback(response));
        }

        public virtual void GetMessagingCountry(string isoCountry, Action<MessagingCountry> callback)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "Messaging/Countries/{IsoCountry}";
            request.AddUrlSegment("IsoCountry", isoCountry);

            ExecuteAsync<MessagingCountry>(request, (response) => callback(response));
        }
    }
}
