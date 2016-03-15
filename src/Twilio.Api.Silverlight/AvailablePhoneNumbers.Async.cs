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
		public virtual void ListAvailableLocalPhoneNumbers(string isoCountryCode, AvailablePhoneNumberListRequest options, Action<AvailablePhoneNumberResult> callback)
		{
			Require.Argument("isoCountryCode", isoCountryCode);

			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/Local.json";
			request.AddUrlSegment("IsoCountryCode", isoCountryCode);

			AddNumberSearchParameters(options, request);

			ExecuteAsync<AvailablePhoneNumberResult>(request, (response) => callback(response));
		}

		/// <summary>
		/// Search available toll-free phone numbers
		/// </summary>
		/// <param name="isoCountryCode">Two-character ISO country code (US or CA)</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListAvailableTollFreePhoneNumbers(string isoCountryCode, Action<AvailablePhoneNumberResult> callback)
		{
			Require.Argument("isoCountryCode", isoCountryCode);

			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/TollFree.json";
			request.AddUrlSegment("IsoCountryCode", isoCountryCode);

			ExecuteAsync<AvailablePhoneNumberResult>(request, (response) => callback(response));
		}

		/// <summary>
		/// Search available toll-free phone numbers
		/// </summary>
		/// <param name="isoCountryCode">Two-character ISO country code (US or CA)</param>
		/// <param name="contains">Value to use when filtering search. Accepts numbers or characters.</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListAvailableTollFreePhoneNumbers(string isoCountryCode, string contains, Action<AvailablePhoneNumberResult> callback)
		{
			Require.Argument("isoCountryCode", isoCountryCode);
			Require.Argument("contains", contains);

			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/TollFree.json";
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

            if (options.SmsEnabled.HasValue) request.AddParameter("SmsEnabled", options.SmsEnabled.Value);
            if (options.VoiceEnabled.HasValue) request.AddParameter("VoiceEnabled", options.VoiceEnabled.Value);
			if (options.MmsEnabled.HasValue) request.AddParameter("MmsEnabled", options.MmsEnabled.Value);
		}

	}
}
