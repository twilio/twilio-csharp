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

using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;


namespace Twilio
{
	public partial class TwilioRestClient
	{
		/// <summary>
		/// Retrieve the details for an incoming phone number
		/// </summary>
		/// <param name="incomingPhoneNumberSid">The Sid of the number to retrieve</param>
		public IncomingPhoneNumber GetIncomingPhoneNumber(string incomingPhoneNumberSid)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/IncomingPhoneNumbers/{IncomingPhoneNumberSid}";
			request.RootElement = "IncomingPhoneNumber";

			request.AddUrlSegment("IncomingPhoneNumberSid", incomingPhoneNumberSid);

			return Execute<IncomingPhoneNumber>(request);
		}

		/// <summary>
		/// List all incoming phone numbers on current account
		/// </summary>
		public IncomingPhoneNumberResult ListIncomingPhoneNumbers()
		{
			return ListIncomingPhoneNumbers(null, null, null, null);
		}

		/// <summary>
		/// List incoming phone numbers on current account with filters
		/// </summary>
		/// <param name="phoneNumber">Optional phone number to match</param>
		/// <param name="friendlyName">Optional friendly name to match</param>
		/// <param name="pageNumber">Page number to start retrieving results from</param>
		/// <param name="count">How many results to return</param>
		public IncomingPhoneNumberResult ListIncomingPhoneNumbers(string phoneNumber, string friendlyName, int? pageNumber, int? count)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/IncomingPhoneNumbers";

			if (phoneNumber.HasValue()) request.AddParameter("PhoneNumber", phoneNumber);
			if (friendlyName.HasValue()) request.AddParameter("FriendlyName", friendlyName);

			if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
			if (count.HasValue) request.AddParameter("PageSize", count.Value);

			return Execute<IncomingPhoneNumberResult>(request);
		}

		/// <summary>
		/// Purchase/provision a local phone number
		/// </summary>
		/// <param name="options">Optional parameters to use when purchasing number</param>
		public IncomingPhoneNumber AddIncomingPhoneNumber(PhoneNumberOptions options)
		{
			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/IncomingPhoneNumbers";
			request.RootElement = "IncomingPhoneNumber";

			if (options.PhoneNumber.HasValue())
			{
				request.AddParameter("PhoneNumber", options.PhoneNumber);
			}
			else
			{
				if (options.AreaCode.HasValue()) request.AddParameter("AreaCode", options.AreaCode);
			}

			AddPhoneNumberOptionsToRequest(request, options);
			AddSmsOptionsToRequest(request, options);

			return Execute<IncomingPhoneNumber>(request);
		}

		/// <summary>
		/// Update the settings of an incoming phone number
		/// </summary>
		/// <param name="incomingPhoneNumberSid">The Sid of the phone number to update</param>
		/// <param name="options">Which settings to update. Only properties with values set will be updated.</param>
		public IncomingPhoneNumber UpdateIncomingPhoneNumber(string incomingPhoneNumberSid, PhoneNumberOptions options)
		{
			Require.Argument("IncomingPhoneNumberSid", incomingPhoneNumberSid);

			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/IncomingPhoneNumbers/{IncomingPhoneNumberSid}";
			request.RootElement = "IncomingPhoneNumber";

			request.AddParameter("IncomingPhoneNumberSid", incomingPhoneNumberSid, ParameterType.UrlSegment);
			AddPhoneNumberOptionsToRequest(request, options);
			AddSmsOptionsToRequest(request, options);

			return Execute<IncomingPhoneNumber>(request);
		}

		/// <summary>
		/// Remove (deprovision) a phone number from the current account
		/// </summary>
		/// <param name="incomingPhoneNumberSid">The Sid of the number to remove</param>
		public DeleteStatus DeleteIncomingPhoneNumber(string incomingPhoneNumberSid)
		{
			Require.Argument("IncomingPhoneNumberSid", incomingPhoneNumberSid);
			var request = new RestRequest(Method.DELETE);
			request.Resource = "Accounts/{AccountSid}/IncomingPhoneNumbers/{IncomingPhoneNumberSid}";

			request.AddParameter("IncomingPhoneNumberSid", incomingPhoneNumberSid, ParameterType.UrlSegment);

			var response = Execute(request);
			return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
		}
	}
}