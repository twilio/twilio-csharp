using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio
{
	public partial class TwilioRestClient
	{
		/// <summary>
		/// Retrieve the details for an existing validated Outgoing Caller ID entry
		/// </summary>
		/// <param name="outgoingCallerIdSid">The Sid of the entry to retrieve</param>
		/// <param name="callback">Method to call upon successful completion</param>
        public virtual void GetOutgoingCallerId(string outgoingCallerIdSid, Action<OutgoingCallerId> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/OutgoingCallerIds/{OutgoingCallerIdSid}.json";
						request.AddParameter("OutgoingCallerIdSid", outgoingCallerIdSid, ParameterType.UrlSegment);

			ExecuteAsync<OutgoingCallerId>(request, (response) => callback(response));
		}

		/// <summary>
		/// Returns a list of validated outgoing caller IDs. The list includes paging information.
		/// </summary>
		/// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListOutgoingCallerIds(Action<OutgoingCallerIdResult> callback)
		{
			ListOutgoingCallerIds(null, null, null, null, callback);
		}

		/// <summary>
		/// Returns a filtered list of validated outgoing caller IDs. The list includes paging information.
		/// </summary>
		/// <param name="phoneNumber">If present, filter the list by the value provided</param>
		/// <param name="friendlyName">If present, filter the list by the value provided</param>
		/// <param name="pageNumber">If present, start the results from the specified page</param>
		/// <param name="count">If present, return the specified number of results, up to 1000</param>
		/// <param name="callback">Method to call upon successful completion</param>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual void ListOutgoingCallerIds(string phoneNumber, string friendlyName, int? pageNumber, int? count, Action<OutgoingCallerIdResult> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/OutgoingCallerIds.json";
			//
			if (phoneNumber.HasValue()) request.AddParameter("PhoneNumber", phoneNumber);
			if (friendlyName.HasValue()) request.AddParameter("FriendlyName", friendlyName);
			if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
			if (count.HasValue) request.AddParameter("PageSize", count.Value);

			ExecuteAsync<OutgoingCallerIdResult>(request, (response) => callback(response));
		}

		/// <summary>
		/// Adds a new validated CallerID to your account. After making this request, Twilio will return to you a validation code and dial the phone number given to perform validation. The code returned must be entered via the phone before the CallerID will be added to your account.
		/// </summary>
		/// <param name="phoneNumber">The phone number to verify. Should be formatted with a '+' and country code e.g., +16175551212 (E.164 format). Twilio will also accept unformatted US numbers e.g., (415) 555-1212, 415-555-1212.</param>
		/// <param name="friendlyName">A human readable description for the new caller ID with maximum length 64 characters. Defaults to a nicely formatted version of the number.</param>
		/// <param name="callDelay">The number of seconds, between 0 and 60, to delay before initiating the validation call. Defaults to 0.</param>
		/// <param name="extension">Digits to dial after connecting the validation call.</param>
		/// <param name="callback">Method to call upon successful completion</param>
        public virtual void AddOutgoingCallerId(string phoneNumber, string friendlyName, int? callDelay, string extension, Action<ValidationRequestResult> callback)
		{
            var options = new OutgoingCallerIdOptions()
            {
                FriendlyName = friendlyName,
                CallDelay = callDelay,
                Extension = extension
            };

            AddOutgoingCallerId(phoneNumber, options, callback);
		}

        /// <summary>
        /// Adds a new validated CallerID to your account. After making this request, Twilio will return to you a validation code and dial the phone number given to perform validation. The code returned must be entered via the phone before the CallerID will be added to your account.
        /// </summary>
        /// <param name="phoneNumber">The phone number to verify. Should be formatted with a '+' and country code e.g., +16175551212 (E.164 format). Twilio will also accept unformatted US numbers e.g., (415) 555-1212, 415-555-1212.</param>
        /// <param name="options">Optional parameters to use when purchasing number</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void AddOutgoingCallerId(string phoneNumber, OutgoingCallerIdOptions options, Action<ValidationRequestResult> callback)
        {
            Require.Argument("PhoneNumber", phoneNumber);
            if (options.CallDelay.HasValue) Validate.IsBetween(options.CallDelay.Value, 0, 60);

            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/OutgoingCallerIds.json";
            request.AddParameter("PhoneNumber", phoneNumber);

            if (options.FriendlyName.HasValue()) request.AddParameter("FriendlyName", options.FriendlyName);
            if (options.CallDelay.HasValue) request.AddParameter("CallDelay", options.CallDelay.Value);
            if (options.Extension.HasValue()) request.AddParameter("Extension", options.Extension);

            if (options.StatusCallback.HasValue()) request.AddParameter("StatusCallback", options.StatusCallback);
            if (options.StatusCallbackMethod.HasValue()) request.AddParameter("StatusCallbackMethod", options.StatusCallbackMethod);

            ExecuteAsync<ValidationRequestResult>(request, (response) => callback(response));
        }
        
        /// <summary>
		/// Update the FriendlyName associated with a validated outgoing caller ID entry
		/// </summary>
		/// <param name="outgoingCallerIdSid">The Sid of the outgoing caller ID entry</param>
		/// <param name="friendlyName">The name to update the FriendlyName to</param>
		/// <param name="callback">Method to call upon successful completion</param>
        public virtual void UpdateOutgoingCallerIdName(string outgoingCallerIdSid, string friendlyName, Action<OutgoingCallerId> callback)
		{
			Require.Argument("OutgoingCallerIdSid", outgoingCallerIdSid);
			Require.Argument("FriendlyName", friendlyName);
			Validate.IsValidLength(friendlyName, 64);

			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/OutgoingCallerIds/{OutgoingCallerIdSid}.json";
			
			request.AddParameter("OutgoingCallerIdSid", outgoingCallerIdSid, ParameterType.UrlSegment);
			request.AddParameter("FriendlyName", friendlyName);

			ExecuteAsync<OutgoingCallerId>(request, (response) => callback(response));
		}

		/// <summary>
		/// Remove a validated outgoing caller ID from the current account
		/// </summary>
		/// <param name="outgoingCallerIdSid">The Sid to remove</param>
		/// <param name="callback">Method to call upon successful completion</param>
        public virtual void DeleteOutgoingCallerId(string outgoingCallerIdSid, Action<DeleteStatus> callback)
		{
			Require.Argument("OutgoingCallerIdSid", outgoingCallerIdSid);
			var request = new RestRequest(Method.DELETE);
			request.Resource = "Accounts/{AccountSid}/OutgoingCallerIds/{OutgoingCallerIdSid}.json";

			request.AddParameter("OutgoingCallerIdSid", outgoingCallerIdSid, ParameterType.UrlSegment);

			ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
		}
	}
}
