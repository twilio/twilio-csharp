using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.Pricing
{
    public partial class PricingClient
    {
        public virtual PhoneNumberCountryResult ListPhoneNumberCountries()
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "PhoneNumbers/Countries";

            return Execute<PhoneNumberCountryResult>(request);
        }

        public virtual PhoneNumberCountry GetPhoneNumberCountry(string isoCountry)
        {
            var request = new RestRequest(Method.GET);
            request.Resource = "PhoneNumbers/Countries/{IsoCountry}";
            request.AddUrlSegment("IsoCountry", isoCountry);

            return Execute<PhoneNumberCountry>(request);
        }
    }
}