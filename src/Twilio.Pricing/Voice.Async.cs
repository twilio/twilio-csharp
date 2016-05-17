using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.Pricing
{
    public partial class PricingClient
    {

		public virtual void ListVoiceCountries(Action<VoiceCountryResult> callback)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "Voice/Countries";

            ExecuteAsync<VoiceCountryResult>(request, (response) => callback(response));
        }

        public virtual void GetVoiceCountry(string isoCountry, Action<VoiceCountry> callback)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "Voice/Countries/{IsoCountry}";
            request.AddUrlSegment("IsoCountry", isoCountry);

            ExecuteAsync<VoiceCountry>(request, (response) => callback(response));
        }

        public virtual void GetVoiceNumber(string number, Action<VoiceNumber> callback)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "Voice/Numbers/{Number}";
            request.AddUrlSegment("Number", number);

            ExecuteAsync<VoiceNumber>(request, (response) => callback(response));
        }
    }
}
