using RestSharp;
using RestSharp.Validation;

namespace Twilio
{
	public partial class TwilioRestClient
	{
		/// <summary>
		/// Search available local phone numbers. Makes a GET request to the AvailablePhoneNumber List resource.
		/// </summary>
		/// <param name="isoCountryCode">Two-character ISO country code (US or CA)</param>
		/// <param name="options">Search filter options. Only properties with values set will be used.</param>
		public AvailablePhoneNumberResult ListAvailableLocalPhoneNumbers(string isoCountryCode, AvailablePhoneNumberListRequest options)
		{
			Require.Argument("isoCountryCode", isoCountryCode);

			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/Local.json";
			request.AddUrlSegment("IsoCountryCode", isoCountryCode);

			AddNumberSearchParameters(options, request);

			return Execute<AvailablePhoneNumberResult>(request);
		}

		/// <summary>
		/// Search available toll-free phone numbers.  Makes a GET request to the AvailablePhoneNumber List resource.
		/// </summary>
		/// <param name="isoCountryCode">Two-character ISO country code (US or CA)</param>
		public AvailablePhoneNumberResult ListAvailableTollFreePhoneNumbers(string isoCountryCode)
		{
			var options = new AvailablePhoneNumberListRequest();
			return ListAvailableTollFreePhoneNumbers(isoCountryCode, options);
		}

		/// <summary>
		/// Search available toll-free phone numbers.  Makes a GET request to the AvailablePhoneNumber List resource.
		/// </summary>
		/// <param name="isoCountryCode">Two-character ISO country code (US or CA)</param>
		/// <param name="contains">Value to use when filtering search. Accepts numbers or characters.</param>
		public AvailablePhoneNumberResult ListAvailableTollFreePhoneNumbers(string isoCountryCode, string contains)
		{
			var options = new AvailablePhoneNumberListRequest();
			options.Contains = contains;

			return ListAvailableTollFreePhoneNumbers(isoCountryCode, options);
		}

		/// <summary>
		/// Search available toll-free phone numbers.  Makes a GET request to the AvailablePhoneNumber List resource.
		/// </summary>
		/// <param name="isoCountryCode">Two-character ISO country code (US or CA)</param>
		/// <param name="options">Search filter options</param>
		public AvailablePhoneNumberResult ListAvailableTollFreePhoneNumbers(string isoCountryCode, AvailablePhoneNumberListRequest options)
		{
			Require.Argument("isoCountryCode", isoCountryCode);

			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/AvailablePhoneNumbers/{IsoCountryCode}/TollFree.json";
			request.AddUrlSegment("IsoCountryCode", isoCountryCode);

			if (options != null) 
			{
				if (options.AreaCode != null) request.AddParameter("AreaCode", options.AreaCode);
				if (options.Contains != null) request.AddParameter("Contains", options.Contains);
			}

			return Execute<AvailablePhoneNumberResult>(request);
		}
	}
}
