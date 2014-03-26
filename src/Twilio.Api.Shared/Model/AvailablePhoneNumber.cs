using System;

namespace Twilio
{
	/// <summary>
	/// An AvailablePhoneNumber instance resource represents a single AvailablePhoneNumber.
	/// </summary>
	public class AvailablePhoneNumber : TwilioBase
	{
		/// <summary>
		/// A nicely-formatted version of the phone number.
		/// </summary>
		public string FriendlyName { get; set; }
		/// <summary>
		/// The phone number, in E.164 (i.e. "+1") format.
		/// </summary>
		public string PhoneNumber { get; set; }
		/// <summary>
		/// The LATA of this phone number.
		/// </summary>
		public string Lata { get; set; }
		/// <summary>
		/// The rate center of this phone number.
		/// </summary>
		public string RateCenter { get; set; }
		/// <summary>
		/// The latitude coordinate of this phone number.
		/// </summary>
		public decimal? Latitude { get; set; }
		/// <summary>
		/// The longitude coordinate of this phone number.
		/// </summary>
		public decimal? Longitude { get; set; }
		/// <summary>
		/// The two-letter state or province abbreviation of this phone number.
		/// </summary>
		public string Region { get; set; }
		/// <summary>
		/// The postal (zip) code of this phone number.
		/// </summary>
		public string PostalCode { get; set; }
		/// <summary>
		/// The ISO country code of this phone number.
		/// </summary>
		public string IsoCountry { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Capabilities Capabilities { get; set; }
	}
}
