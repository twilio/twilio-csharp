using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.Pricing
{
    public partial class PricingClient
    {
        /// <summary>
        /// Returns a paged list of sms message supported countries.
        /// Makes a GET request to the Messaging/Countries List resource.
        /// </summary>
        /// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListMessagingCountries(Action<MessagingCountryResult> callback)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "Messaging/Countries";

            ExecuteAsync<MessagingCountryResult>(request, (response) => callback(response));
        }

        /// <summary>
        /// Returns the single sms message supported country by
        /// ISO country code.
        /// Makes a GET request to a Messaging/Countries/{IsoCountry}
        /// Instance resource.
        /// </summary>
        /// <param name="isoCountry">ISO Country code</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void GetMessagingCountry(string isoCountry, Action<MessagingCountry> callback)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "Messaging/Countries/{IsoCountry}";
            request.AddUrlSegment("IsoCountry", isoCountry);

            ExecuteAsync<MessagingCountry>(request, (response) => callback(response));
        }
    }
}
