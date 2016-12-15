using System;
using RestSharp;

namespace Twilio.Pricing
{
    public partial class PricingClient
    {
        /// <summary>
        /// Returns a paged list of SMS message supported countries.
        /// Makes a GET request to the Messaging/Countries List resource.
        /// </summary>
        /// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListMessagingCountries(Action<MessagingCountryResult> callback)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = "Messaging/Countries"
            };

            ExecuteAsync(request, callback);
        }

        /// <summary>
        /// Returns the single SMS message supported country by
        /// ISO country code.
        /// Makes a GET request to a Messaging/Countries/{IsoCountry}
        /// Instance resource.
        /// </summary>
        /// <param name="isoCountry">ISO Country code</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void GetMessagingCountry(string isoCountry, Action<MessagingCountry> callback)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = "Messaging/Countries/{IsoCountry}"
            };
            request.AddUrlSegment("IsoCountry", isoCountry);

            ExecuteAsync(request, callback);
        }
    }
}
