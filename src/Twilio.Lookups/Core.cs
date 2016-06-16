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
        /// <param name="includeCallerInfo">Whether to retrieve caller information (see twilio.com for pricing).</param>
        /// <returns></returns>
        public Number GetPhoneNumber(string phoneNumber, string countryCode, bool includeCarrierInfo, bool includeCallerInfo)
        {
            var request = BuildPhoneNumberRequest(phoneNumber, countryCode, includeCarrierInfo, includeCallerInfo);

            return Execute<Number>(request);
        }

        public Number GetPhoneNumber(string phoneNumber, bool includeCarrierInfo, bool includeCallerInfo)
        {
            return GetPhoneNumber(phoneNumber, null, includeCarrierInfo, includeCallerInfo);
        }

        public Number GetPhoneNumber(string phoneNumber)
        {
            return GetPhoneNumber(phoneNumber, null, false, false);
        }

        public void GetPhoneNumber(string phoneNumber, string countryCode, bool includeCarrierInfo, bool includeCallerInfo, Action<Number> callback)
        {
            var request = BuildPhoneNumberRequest(phoneNumber, countryCode, includeCarrierInfo, includeCallerInfo);

            ExecuteAsync<Number>(request, (response) => { callback(response); });
        }

        public void GetPhoneNumber(string phoneNumber, bool includeCarrierInfo, bool includeCallerInfo, Action<Number> callback)
        {
            GetPhoneNumber(phoneNumber, null, includeCarrierInfo, includeCallerInfo, callback);
        }

        public void GetPhoneNumber(string phoneNumber, Action<Number> callback)
        {
            GetPhoneNumber(phoneNumber, null, false, false, callback);
        }

        private static RestRequest BuildPhoneNumberRequest(string phoneNumber, string countryCode, bool includeCarrierInfo, bool includeCallerInfo)
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
            if (includeCallerInfo)
            {
                request.AddQueryParameter("Type", "caller-name");
            }
            return request;
        }
    }
}
