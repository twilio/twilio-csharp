#region License
//   Copyright 2010 John Sheehan
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License. 
#endregion

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
		public void GetOutgoingCallerId(string outgoingCallerIdSid, Action<OutgoingCallerId> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/OutgoingCallerIds/{OutgoingCallerIdSid}";
			request.RootElement = "OutgoingCallerId";
			request.AddParameter("OutgoingCallerIdSid", outgoingCallerIdSid, ParameterType.UrlSegment);

			ExecuteAsync<OutgoingCallerId>(request, (response) => callback(response));
		}

		/// <summary>
		/// Returns a list of validated outgoing caller IDs. The list includes paging information.
		/// </summary>
		/// <param name="callback">Method to call upon successful completion</param>
		public void ListOutgoingCallerIds(Action<OutgoingCallerIdResult> callback)
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
		public void ListOutgoingCallerIds(string phoneNumber, string friendlyName, int? pageNumber, int? count, Action<OutgoingCallerIdResult> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/OutgoingCallerIds";
			//request.RootElement = "OutgoingCallerIds";

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
		/// <param name="callback">Method to call upon successful completion</param>
		public void AddOutgoingCallerId(string phoneNumber, string friendlyName, int? callDelay, Action<ValidationRequestResult> callback)
		{
			Require.Argument("PhoneNumber", phoneNumber);
			if (callDelay.HasValue) Validate.IsBetween(callDelay.Value, 0, 60);

			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/OutgoingCallerIds";
			request.RootElement = "ValidationRequest";
			request.AddParameter("PhoneNumber", phoneNumber);

			if (friendlyName.HasValue()) request.AddParameter("FriendlyName", friendlyName);
			if (callDelay.HasValue) request.AddParameter("CallDelay", callDelay.Value);

			ExecuteAsync<ValidationRequestResult>(request, (response) => callback(response));
		}

		/// <summary>
		/// Update the FriendlyName associated with a validated outgoing caller ID entry
		/// </summary>
		/// <param name="outgoingCallerIdSid">The Sid of the outgoing caller ID entry</param>
		/// <param name="friendlyName">The name to update the FriendlyName to</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public void UpdateOutgoingCallerIdName(string outgoingCallerIdSid, string friendlyName, Action<OutgoingCallerId> callback)
		{
			Require.Argument("OutgoingCallerIdSid", outgoingCallerIdSid);
			Require.Argument("FriendlyName", friendlyName);
			Validate.IsValidLength(friendlyName, 64);

			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/OutgoingCallerIds/{OutgoingCallerIdSid}";
			request.RootElement = "OutgoingCallerId";

			request.AddParameter("OutgoingCallerIdSid", outgoingCallerIdSid, ParameterType.UrlSegment);
			request.AddParameter("FriendlyName", friendlyName);

			ExecuteAsync<OutgoingCallerId>(request, (response) => callback(response));
		}

		/// <summary>
		/// Remove a validated outgoing caller ID from the current account
		/// </summary>
		/// <param name="outgoingCallerIdSid">The Sid to remove</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public void DeleteOutgoingCallerId(string outgoingCallerIdSid, Action<DeleteStatus> callback)
		{
			Require.Argument("OutgoingCallerIdSid", outgoingCallerIdSid);
			var request = new RestRequest(Method.DELETE);
			request.Resource = "Accounts/{AccountSid}/OutgoingCallerIds/{OutgoingCallerIdSid}";

			request.AddParameter("OutgoingCallerIdSid", outgoingCallerIdSid, ParameterType.UrlSegment);

			ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
		}
	}
}