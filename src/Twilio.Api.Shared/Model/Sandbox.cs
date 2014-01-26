using System;

namespace Twilio
{
	/// <summary>
	/// An Call instance resource represents a single Twilio Call.
	/// </summary>
	public class Sandbox : TwilioBase
	{
		/// <summary>
		/// The unique Sid of the Account responsible for creating this call.
		/// </summary>
		public string AccountSid { get; set; }
		/// <summary>
		/// An 8 digit number that gives access to this sandbox.
		/// </summary>
		public string Pin { get; set; }
		/// <summary>
		/// The phone number of the sandbox. Formatted with a '+' and country code e.g., +16175551212 (E.164 format).
		/// </summary>
		public string PhoneNumber { get; set; }
		/// <summary>
		/// The URL Twilio will request when the sandbox number is called.
		/// </summary>
		public string VoiceUrl { get; set; }
		/// <summary>
		/// The HTTP method to use when requesting the above URL. Either GET or POST.
		/// </summary>
		public string VoiceMethod { get; set; }
		/// <summary>
		/// The URL Twilio will request when receiving an incoming SMS message to the sandbox number.
		/// </summary>
		public string SmsUrl { get; set; }
		/// <summary>
		/// The HTTP method to use when requesting the sms URL. Either GET or POST.
		/// </summary>
		public string SmsMethod { get; set; }
		/// <summary>
		/// The date that this resource was created
		/// </summary>
		public DateTime DateCreated { get; set; }
		/// <summary>
		/// The date that this resource was last updated
		/// </summary>
		public DateTime DateUpdated { get; set; }
	}
}