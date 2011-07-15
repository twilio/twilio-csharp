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
		/// Search available local phone numbers
		/// </summary>
		/// <param name="isoCountryCode">Two-character ISO country code (US or CA)</param>
		/// <param name="options">Search filter options. Only properties with values set will be used.</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public void ListAvailableLocalPhoneNumbers(string isoCountryCode, AvailablePhoneNumberListRequest options, Action<AvailablePhoneNumberResult> callback)
		{
			Require.Argument("isoCountryCode", isoCountryCode);

			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/Local";
			request.AddUrlSegment("IsoCountryCode", isoCountryCode);

			AddNumberSearchParameters(options, request);

			ExecuteAsync<AvailablePhoneNumberResult>(request, (response) => callback(response));
		}

		/// <summary>
		/// Search available toll-free phone numbers
		/// </summary>
		/// <param name="isoCountryCode">Two-character ISO country code (US or CA)</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public void ListAvailableTollFreePhoneNumbers(string isoCountryCode, Action<AvailablePhoneNumberResult> callback)
		{
			Require.Argument("isoCountryCode", isoCountryCode);

			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/TollFree";
			request.AddUrlSegment("IsoCountryCode", isoCountryCode);

			ExecuteAsync<AvailablePhoneNumberResult>(request, (response) => callback(response));
		}

		/// <summary>
		/// Search available toll-free phone numbers
		/// </summary>
		/// <param name="isoCountryCode">Two-character ISO country code (US or CA)</param>
		/// <param name="contains">Value to use when filtering search. Accepts numbers or characters.</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public void ListAvailableTollFreePhoneNumbers(string isoCountryCode, string contains, Action<AvailablePhoneNumberResult> callback)
		{
			Require.Argument("isoCountryCode", isoCountryCode);
			Require.Argument("contains", contains);

			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/TollFree";
			request.AddUrlSegment("IsoCountryCode", isoCountryCode);

			request.AddParameter("Contains", contains);

			ExecuteAsync<AvailablePhoneNumberResult>(request, (response) => callback(response));
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
