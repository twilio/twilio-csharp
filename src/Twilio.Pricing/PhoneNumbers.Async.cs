using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.Pricing
{
    public partial class PricingClient
    {
        /// <summary>
        /// Retrieve a list of countries where Twilio hosted Phone Numbers
        /// are available.
        /// </summary>
        /// <param name="callback">Callback to handle response.</param>
		public virtual void ListPhoneNumberCountries(Action<PhoneNumberCountryResult> callback)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "PhoneNumbers/Countries";

            ExecuteAsync<PhoneNumberCountryResult>(request, (response) => callback(response));
        }

        /// <summary>
        /// Retrieve pricing information for Twilio hosted Phone Numbers
        /// in a single country.
        /// </summary>
        /// <param name="isoCountry">The two-letter ISO code for the country.</param>
        /// <param name="callback">Response callback.</param>
        public virtual void GetPhoneNumberCountry(string isoCountry, Action<PhoneNumberCountry> callback)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "PhoneNumbers/Countries/{IsoCountry}";
            request.AddUrlSegment("IsoCountry", isoCountry);

            ExecuteAsync<PhoneNumberCountry>(request, (response) => callback(response));
        }
    }
}
