using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Extensions;

namespace Twilio.Lookups
{
    /// <summary>
    /// The Twilio Lookups API allows you to retrieve information about phone numbers.
    /// </summary>
    public partial class LookupsClient : TwilioClient
    {
        /// <summary>
        /// Initializes a new client with the specified credentials.
        /// </summary>
        /// <param name="accountSid">The AccountSid to authenticate with</param>
        /// <param name="authToken">The AuthToken to authenticate with</param>
        public LookupsClient(string accountSid, string authToken) : this(accountSid, authToken, accountSid) { }

        /// <summary>
        /// Initializes a new client with the specified credentials.
        /// </summary>
        /// <param name="accountSid">The AccountSid to authenticate with</param>
        /// <param name="authToken">The AuthToken to authenticate with</param>
        /// <param name="accountResourceSid"></param>
        public LookupsClient(string accountSid, string authToken, string accountResourceSid)
            : base(accountSid, authToken, accountResourceSid, "v1", "https://lookups.twilio.com/")
        {
            DateFormat = null;
        }

        public LookupsClient(string accountSid, string authToken, string accountResourceSid, string apiVersion, string baseUrl) :
            base(accountSid, authToken, accountResourceSid, apiVersion, baseUrl)
        {
            DateFormat = null;
        }

        /// <summary>
        /// Look up a phone number, optionally including carrier information (see
        /// the Twilio Lookups website for pricing information).
        /// </summary>
        /// <param name="phoneNumber">The phone number to look up, in either E.164 format or localized formatting.</param>
        /// <param name="countryCode">If the number is in a local format, specifies the country to parse it in.</param>
        /// <param name="includeCarrierInfo">Whether to retrieve carrier information (see twilio.com for pricing).</param>
        /// <returns></returns>
        public Number GetPhoneNumber(string phoneNumber, string countryCode, bool includeCarrierInfo)
        {
            var request = BuildPhoneNumberRequest(phoneNumber, countryCode, includeCarrierInfo);

            return Execute<Number>(request);
        }

        public Number GetPhoneNumber(string phoneNumber, bool includeCarrierInfo)
        {
            return GetPhoneNumber(phoneNumber, null, includeCarrierInfo);
        }

        public Number GetPhoneNumber(string phoneNumber)
        {
            return GetPhoneNumber(phoneNumber, null, false);
        }

        public void GetPhoneNumber(string phoneNumber, string countryCode, bool includeCarrierInfo, Action<Number> callback)
        {
            var request = BuildPhoneNumberRequest(phoneNumber, countryCode, includeCarrierInfo);

            ExecuteAsync<Number>(request, (response) => { callback(response); });
        }

        public void GetPhoneNumber(string phoneNumber, bool includeCarrierInfo, Action<Number> callback)
        {
            GetPhoneNumber(phoneNumber, null, includeCarrierInfo, callback);
        }

        public void GetPhoneNumber(string phoneNumber, Action<Number> callback)
        {
            GetPhoneNumber(phoneNumber, null, false, callback);
        }

        private static RestRequest BuildPhoneNumberRequest(string phoneNumber, string countryCode, bool includeCarrierInfo)
        {
            var request = new RestRequest();
            request.Resource = "PhoneNumbers/{PhoneNumber}";
            request.AddUrlSegment("PhoneNumber", phoneNumber);

            if (countryCode.HasValue())
            {
                request.AddQueryParameter("CountryCode", countryCode);
            }
            if (includeCarrierInfo)
            {
                request.AddQueryParameter("Type", "carrier");
            }
            return request;
        }
    }
}
