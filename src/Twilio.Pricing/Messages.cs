using RestSharp;

namespace Twilio.Pricing
{
    public partial class PricingClient
    {
        /// <summary>
        /// Returns a paged list of SMS message supported countries.
        /// Makes a GET request to the Messaging/Countries List resource.
        /// </summary>
        public virtual MessagingCountryResult ListMessagingCountries()
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = "Messaging/Countries"
            };

            return Execute<MessagingCountryResult>(request);
        }

        /// <summary>
        /// Returns the single SMS message supported country by
        /// ISO country code.
        /// Makes a GET request to a Messaging/Countries/{IsoCountry}
        /// Instance resource.
        /// </summary>
        /// <param name="isoCountry">ISO Country code</param>
        public virtual MessagingCountry GetMessagingCountry(string isoCountry)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = "Messaging/Countries/{IsoCountry}"
            };
            request.AddUrlSegment("IsoCountry", isoCountry);

            return Execute<MessagingCountry>(request);
        }
    }
}
