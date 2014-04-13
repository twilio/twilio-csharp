using System;
using Simple;
using System.Threading.Tasks;

namespace Twilio
{
    public partial class TwilioRestClient
    {
        /// <summary>
        /// Search available local phone numbers. Makes a GET request to the AvailablePhoneNumber List resource.
        /// </summary>
        /// <param name="isoCountryCode">Two-character ISO country code (US or CA)</param>
        /// <param name="options">Search filter options. Only properties with values set will be used.</param>
        public virtual async Task<AvailablePhoneNumberResult> ListAvailableLocalPhoneNumbers(string isoCountryCode, AvailablePhoneNumberListRequest options)
        {
            Require.Argument("isoCountryCode", isoCountryCode);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/Local.json";
            request.AddUrlSegment("IsoCountryCode", isoCountryCode);

            AddNumberSearchParameters(options, request);

            return await Execute<AvailablePhoneNumberResult>(request);
        }

        /// <summary>
        /// Search available toll-free phone numbers.  Makes a GET request to the AvailablePhoneNumber List resource.
        /// </summary>
        /// <param name="isoCountryCode">Two-character ISO country code (US or CA)</param>
        public virtual async Task<AvailablePhoneNumberResult> ListAvailableTollFreePhoneNumbers(string isoCountryCode)
        {
            Require.Argument("isoCountryCode", isoCountryCode);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/TollFree.json";
            request.AddUrlSegment("IsoCountryCode", isoCountryCode);

            return await Execute<AvailablePhoneNumberResult>(request);
        }

        /// <summary>
        /// Search available toll-free phone numbers.  Makes a GET request to the AvailablePhoneNumber List resource.
        /// </summary>
        /// <param name="isoCountryCode">Two-character ISO country code (US or CA)</param>
        /// <param name="contains">Value to use when filtering search. Accepts numbers or characters.</param>
        public virtual async Task<AvailablePhoneNumberResult> ListAvailableTollFreePhoneNumbers(string isoCountryCode, string contains)
        {
            Require.Argument("isoCountryCode", isoCountryCode);
            Require.Argument("contains", contains);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/TollFree.json";
            request.AddUrlSegment("IsoCountryCode", isoCountryCode);

            request.AddParameter("Contains", contains);

            return await Execute<AvailablePhoneNumberResult>(request);
        }

        /// <summary>
        /// Search available mobile phone numbers.  Makes a GET request to the AvailablePhoneNumber List resource.
        /// </summary>
        /// <param name="isoCountryCode">Two-character ISO country code (US or CA)</param>
        /// <param name="options">Search filter options. Only properties with values set will be used.</param>
        public virtual async Task<AvailablePhoneNumberResult> ListAvailableMobilePhoneNumbers(string isoCountryCode, AvailablePhoneNumberListRequest options)
        {
            Require.Argument("isoCountryCode", isoCountryCode);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/Mobile.json";
            request.AddUrlSegment("IsoCountryCode", isoCountryCode);

            AddNumberSearchParameters(options, request);

            return await Execute<AvailablePhoneNumberResult>(request);
        }
    }
}
