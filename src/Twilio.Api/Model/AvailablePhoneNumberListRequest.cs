using System;

namespace Twilio
{
	/// <summary>
	/// Search filter options for AvailablePhoneNumber search
	/// </summary>
	public class AvailablePhoneNumberListRequest
	{
		/// <summary>
		/// Find phone numbers in the specified Area Code. Only available for North American numbers.
		/// </summary>
		public string AreaCode { get; set; }
		/// <summary>
		/// A pattern to match phone numbers on. Valid characters are '*' and [0-9a-zA-Z]. The '*' character will match any single digit.
		/// </summary>
		public string Contains { get; set; }
		/// <summary>
		/// Limit results to a particular region (i.e. State/Province). Given a phone number, search within the same Region as that number.
		/// </summary>
		public string InRegion { get; set; }
		/// <summary>
		/// Limit results to a particular postal code. Given a phone number, search within the same postal code as that number.
		/// </summary>
		public string InPostalCode { get; set; }
		/// <summary>
		/// Given a latitude/longitude pair lat,long find geographically close numbers within Distance miles.
		/// </summary>
		public string NearLatLong { get; set; }
		/// <summary>
		/// Specifies the search radius for a Near- query in miles. If not specified this defaults to 25 miles.
		/// </summary>
		public int? Distance { get; set; }
		/// <summary>
		/// Given a phone number, find a geographically close number within Distance miles. Distance defaults to 25 miles.
		/// </summary>
		public string NearNumber { get; set; }
		/// <summary>
		/// Limit results to a specific Local access and transport area (LATA). Given a phone number, search within the same LATA as that number.
		/// </summary>
		public string InLata { get; set; }
		/// <summary>
		/// Limit results to a specific rate center, or given a phone number search within the same rate center as that number. Requires InLata to be set as well.
		/// </summary>
		public string InRateCenter { get; set; }
		/// <summary>
		/// Set to 'true' or 'false'. If true, the response will contain SMS
		/// enabled phone numbers. The voice capability is independent of
		/// the SMS capability
		/// </summary>
		public bool? SmsEnabled { get; set; }
		/// <summary>
		/// Set to 'true' or 'false'. If true, the response will contain Voice
		/// enabled phone numbers. The SMS capability is independent of the
		/// Voice capability.
		/// </summary>
		public bool? VoiceEnabled { get; set; }
		/// <summary>
		/// Set to 'true' or 'false'. If true, the response will contain MMS
		/// enabled phone numbers. The MMS capability is independent of the
		/// SMS capability.
		/// </summary>
		public bool? MmsEnabled { get; set; }
		/// <summary>
		/// Indicates whether the response includes phone numbers which require any Address.
		/// Defaults to 'false', meaning results could include phone numbers with an Address
		/// required.
		/// </summary>
		public bool? ExcludeAllAddressRequired { get; set; }
		/// <summary>
		/// Indicates whether the response includes phone numbers which require a local Address.
		/// Defaults to 'false', meaning results could include phone numbers with a local Address required.
		/// </summary>
		public bool? ExcludeForeignAddressRequired { get; set; }
		/// <summary>
		/// Indicates whether the response includes phone numbers which require a foreign Address.
		/// Defaults to 'false', meaning results could include phone numbers with a foreign Address required.
		/// </summary>
		public bool? ExcludeLocalAddressRequired { get; set; }
		/// <summary>
		/// Whether to include new (beta) numbers on the Twilio platform.
		/// Defaults to true.
		/// </summary>
		public bool? Beta { get; set; }
	}
}
