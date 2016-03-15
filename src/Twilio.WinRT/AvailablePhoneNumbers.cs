using RestRT;
using RestRT.Extensions;
using RestRT.Validation;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Twilio
{
    public partial class TwilioRestClient
    {
        /// <summary>
        /// Search available local phone numbers. Makes a GET request to the AvailablePhoneNumber List resource.
        /// </summary>
        /// <param name="isoCountryCode">Two-character ISO country code (US or CA)</param>
        /// <param name="options">Search filter options. Only properties with values set will be used.</param>
		public IAsyncOperation<AvailablePhoneNumberResult> ListAvailableLocalPhoneNumbersAsync(string isoCountryCode, AvailablePhoneNumberListRequest options)
        {
            return (IAsyncOperation<AvailablePhoneNumberResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListAvailableLocalPhoneNumbersAsyncInternal(isoCountryCode, options));
        }
        private async Task<AvailablePhoneNumberResult> ListAvailableLocalPhoneNumbersAsyncInternal(string isoCountryCode, AvailablePhoneNumberListRequest options)
        {
            Require.Argument("isoCountryCode", isoCountryCode);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/Local.json";
            request.AddUrlSegment("IsoCountryCode", isoCountryCode);

            AddNumberSearchParameters(options, request);

            var result = await ExecuteAsync(request, typeof(AvailablePhoneNumberResult));
            return (AvailablePhoneNumberResult)result;

        }

        /// <summary>
        /// Search available toll-free phone numbers.  Makes a GET request to the AvailablePhoneNumber List resource.
        /// </summary>
        /// <param name="isoCountryCode">Two-character ISO country code (US or CA)</param>
		public IAsyncOperation<AvailablePhoneNumberResult> ListAvailableTollFreePhoneNumbersAsync(string isoCountryCode)
        {
            return (IAsyncOperation<AvailablePhoneNumberResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListAvailableTollFreePhoneNumbersAsyncInternal(isoCountryCode));
        }
        private async Task<AvailablePhoneNumberResult> ListAvailableTollFreePhoneNumbersAsyncInternal(string isoCountryCode)
        {
            Require.Argument("isoCountryCode", isoCountryCode);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/TollFree.json";
            request.AddUrlSegment("IsoCountryCode", isoCountryCode);

            var result = await ExecuteAsync(request, typeof(AvailablePhoneNumberResult));
            return (AvailablePhoneNumberResult)result;

        }

        /// <summary>
        /// Search available toll-free phone numbers.  Makes a GET request to the AvailablePhoneNumber List resource.
        /// </summary>
        /// <param name="isoCountryCode">Two-character ISO country code (US or CA)</param>
        /// <param name="contains">Value to use when filtering search. Accepts numbers or characters.</param>
		public IAsyncOperation<AvailablePhoneNumberResult> ListAvailableTollFreePhoneNumbersAsync(string isoCountryCode, string contains)
        {
            return (IAsyncOperation<AvailablePhoneNumberResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListAvailableTollFreePhoneNumbersAsyncInternal(isoCountryCode, contains));
        }
        private async Task<AvailablePhoneNumberResult> ListAvailableTollFreePhoneNumbersAsyncInternal(string isoCountryCode, string contains)
        {
            Require.Argument("isoCountryCode", isoCountryCode);
            Require.Argument("contains", contains);

            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/TollFree.json";
            request.AddUrlSegment("IsoCountryCode", isoCountryCode);

            request.AddParameter("Contains", contains);

            var result = await ExecuteAsync(request, typeof(AvailablePhoneNumberResult));
            return (AvailablePhoneNumberResult)result;

        }

        private void AddNumberSearchParameters(AvailablePhoneNumberListRequest options, RestRequest request)
        {
            if (options.AreaCode.HasValue()) request.AddParameter("AreaCode", options.AreaCode);
            if (options.Contains.HasValue()) request.AddParameter("Contains", options.Contains);
            if (options.Distance.HasValue) request.AddParameter("Distance", options.Distance);
            if (options.InLata.HasValue()) request.AddParameter("InLata", options.InLata);
            if (options.InPostalCode.HasValue()) request.AddParameter("InPostalCode", options.InPostalCode);
            if (options.InRateCenter.HasValue()) request.AddParameter("InRateCenter", options.InRateCenter);
            if (options.InRegion.HasValue()) request.AddParameter("InRegion", options.InRegion);
            if (options.NearLatLong.HasValue()) request.AddParameter("NearLatLong", options.NearLatLong);
            if (options.NearNumber.HasValue()) request.AddParameter("NearNumber", options.NearNumber);
        }
    }
}
