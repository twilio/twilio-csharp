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
        /// Retrieve the details for an existing validated Outgoing Caller ID entry.
        /// Makes a GET request to an OutgoingCallerId Instance resource.
        /// </summary>
        /// <param name="outgoingCallerIdSid">The Sid of the entry to retrieve</param>
        public IAsyncOperation<OutgoingCallerId> GetOutgoingCallerIdAsync(string outgoingCallerIdSid)
        {
            return (IAsyncOperation<OutgoingCallerId>)AsyncInfo.Run((System.Threading.CancellationToken ct) => GetOutgoingCallerIdAsyncInternal(outgoingCallerIdSid));
        }
        private async Task<OutgoingCallerId> GetOutgoingCallerIdAsyncInternal(string outgoingCallerIdSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/OutgoingCallerIds/{OutgoingCallerIdSid}.json";
            request.AddParameter("OutgoingCallerIdSid", outgoingCallerIdSid, ParameterType.UrlSegment);

            var result = await ExecuteAsync(request, typeof(OutgoingCallerId));
            return (OutgoingCallerId)result;
        }

        /// <summary>
        /// Returns a list of validated outgoing caller IDs. The list includes paging information.
        /// Makes a GET request to an OutgoingCallerIds List resource.
        /// </summary>
        public IAsyncOperation<OutgoingCallerIdResult> ListOutgoingCallerIdsAsync()
        {
            return (IAsyncOperation<OutgoingCallerIdResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListOutgoingCallerIdsAsyncInternal(null,null,null,null));
        }

        /// <summary>
        /// Returns a filtered list of validated outgoing caller IDs. The list includes paging information.
        /// Makes a GET request to an OutgoingCallerIds List resource.
        /// </summary>
        /// <param name="phoneNumber">If present, filter the list by the value provided</param>
        /// <param name="friendlyName">If present, filter the list by the value provided</param>
        /// <param name="pageNumber">If present, start the results from the specified page</param>
        /// <param name="count">If present, return the specified number of results, up to 1000</param>
        /// <returns></returns>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public IAsyncOperation<OutgoingCallerIdResult> ListOutgoingCallerIdsAsync(string phoneNumber, string friendlyName, int? pageNumber, int? count)
        {
            return (IAsyncOperation<OutgoingCallerIdResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListOutgoingCallerIdsAsyncInternal(phoneNumber, friendlyName, pageNumber, count));
        }
        private async Task<OutgoingCallerIdResult> ListOutgoingCallerIdsAsyncInternal(string phoneNumber, string friendlyName, int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/OutgoingCallerIds.json";

            if (phoneNumber.HasValue()) request.AddParameter("PhoneNumber", phoneNumber);
            if (friendlyName.HasValue()) request.AddParameter("FriendlyName", friendlyName);
            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            var result = await ExecuteAsync(request, typeof(OutgoingCallerIdResult));
            return (OutgoingCallerIdResult)result;
        }

        /// <summary>
        /// Adds a new validated CallerID to your account. 
        /// After making this request, Twilio will return to you a validation code and dial the phone number given to perform validation. 
        /// The code returned must be entered via the phone before the CallerID will be added to your account.
        /// Makes a POST request to an OutgoingCallerIds List resource.
        /// </summary>
        /// <param name="phoneNumber">The phone number to verify. Should be formatted with a '+' and country code e.g., +16175551212 (E.164 format). Twilio will also accept unformatted US numbers e.g., (415) 555-1212, 415-555-1212.</param>
        /// <param name="friendlyName">A human readable description for the new caller ID with maximum length 64 characters. Defaults to a nicely formatted version of the number.</param>
        /// <param name="callDelay">The number of seconds, between 0 and 60, to delay before initiating the validation call. Defaults to 0.</param>
        /// <param name="extension">Digits to dial after connecting the validation call.</param>
        public IAsyncOperation<ValidationRequestResult> AddOutgoingCallerIdAsync(string phoneNumber, string friendlyName, int? callDelay, string extension)
        {
            return (IAsyncOperation<ValidationRequestResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => AddOutgoingCallerIdAsyncInternal(phoneNumber, new OutgoingCallerIdOptions()
            {
                FriendlyName = friendlyName,
                CallDelay = callDelay,
                Extension = extension
            }));
        }

        /// <summary>
        /// Adds a new validated CallerID to your account. 
        /// After making this request, Twilio will return to you a validation code and dial the phone number given to perform validation. 
        /// The code returned must be entered via the phone before the CallerID will be added to your account.
        /// Makes a POST request to an OutgoingCallerIds List resource.
        /// </summary>
        /// <param name="phoneNumber">The phone number to verify. Should be formatted with a '+' and country code e.g., +16175551212 (E.164 format). Twilio will also accept unformatted US numbers e.g., (415) 555-1212, 415-555-1212.</param>
        /// <param name="options">Optional parameters to use when purchasing number</param>
        public IAsyncOperation<ValidationRequestResult> AddOutgoingCallerIdAsync(string phoneNumber, OutgoingCallerIdOptions options)
        {
            return (IAsyncOperation<ValidationRequestResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => AddOutgoingCallerIdAsyncInternal(phoneNumber, options));
        }
        private async Task<ValidationRequestResult> AddOutgoingCallerIdAsyncInternal(string phoneNumber, OutgoingCallerIdOptions options)
        {
            Require.Argument("PhoneNumber", phoneNumber);
            if (options.CallDelay.HasValue) Validate.IsBetween(options.CallDelay.Value, 0, 60);

            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "Accounts/{AccountSid}/OutgoingCallerIds.json";
            request.AddParameter("PhoneNumber", phoneNumber);

            if (options.FriendlyName.HasValue()) request.AddParameter("FriendlyName", options.FriendlyName);
            if (options.CallDelay.HasValue) request.AddParameter("CallDelay", options.CallDelay.Value);
            if (options.Extension.HasValue()) request.AddParameter("Extension", options.Extension);

            if (options.StatusCallback.HasValue()) request.AddParameter("StatusCallback", options.StatusCallback);
            if (options.StatusCallbackMethod.HasValue()) request.AddParameter("StatusCallbackMethod", options.StatusCallbackMethod);

            var result = await ExecuteAsync(request, typeof(ValidationRequestResult));
            return (ValidationRequestResult)result;
        }

        /// <summary>
        /// Update the FriendlyName associated with a validated outgoing caller ID entry.
        /// Makes a POST request to an OutgoingCallerId Instance resource.
        /// </summary>
        /// <param name="outgoingCallerIdSid">The Sid of the outgoing caller ID entry</param>
        /// <param name="friendlyName">The name to update the FriendlyName to</param>
        public IAsyncOperation<OutgoingCallerId> UpdateOutgoingCallerIdNameAsync(string outgoingCallerIdSid, string friendlyName)
        {
            return (IAsyncOperation<OutgoingCallerId>)AsyncInfo.Run((System.Threading.CancellationToken ct) => UpdateOutgoingCallerIdNameAsyncInternal(outgoingCallerIdSid, friendlyName));
        }
        private async Task<OutgoingCallerId> UpdateOutgoingCallerIdNameAsyncInternal(string outgoingCallerIdSid, string friendlyName)
        {
            Require.Argument("OutgoingCallerIdSid", outgoingCallerIdSid);
            Require.Argument("FriendlyName", friendlyName);
            Validate.IsValidLength(friendlyName, 64);

            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "Accounts/{AccountSid}/OutgoingCallerIds/{OutgoingCallerIdSid}.json";

            request.AddParameter("OutgoingCallerIdSid", outgoingCallerIdSid, ParameterType.UrlSegment);
            request.AddParameter("FriendlyName", friendlyName);

            var result = await ExecuteAsync(request, typeof(OutgoingCallerId));
            return (OutgoingCallerId)result;

        }

        /// <summary>
        /// Remove a validated outgoing caller ID from the current account.
        /// Makes a DELETE request to an OutgoingCallerId Instance resource.
        /// </summary>
        /// <param name="outgoingCallerIdSid">The Sid to remove</param>
        public IAsyncOperation<DeleteStatus> DeleteOutgoingCallerIdAsync(string outgoingCallerIdSid)
        {
            return (IAsyncOperation<DeleteStatus>)AsyncInfo.Run((System.Threading.CancellationToken ct) => DeleteOutgoingCallerIdAsyncInternal(outgoingCallerIdSid));
        }
        private async Task<DeleteStatus> DeleteOutgoingCallerIdAsyncInternal(string outgoingCallerIdSid)
        {
            Require.Argument("OutgoingCallerIdSid", outgoingCallerIdSid);
            var request = new RestRequest();
            request.Method = Method.DELETE;
            request.Resource = "Accounts/{AccountSid}/OutgoingCallerIds/{OutgoingCallerIdSid}.json";

            request.AddParameter("OutgoingCallerIdSid", outgoingCallerIdSid, ParameterType.UrlSegment);

            var response = (RestResponse)await ExecuteAsync(request);
            return response.StatusCode == (int)System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }
    }
}