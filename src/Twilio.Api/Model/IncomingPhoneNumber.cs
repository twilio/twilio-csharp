using System;

namespace Twilio
{
	/// <summary>
	/// An IncomingPhoneNumber instance resource represents a single Twilio IncomingPhoneNumber.
	/// </summary>
	public class IncomingPhoneNumber : TwilioBase
	{
		/// <summary>
		/// A 34 character string that uniquely idetifies this resource.
		/// </summary>
		public string Sid { get; set; }
		/// <summary>
		/// The date that this resource was created, given as GMT
		/// </summary>
		public DateTime DateCreated { get; set; }
		/// <summary>
		/// The date that this resource was last updated, given as GMT
		/// </summary>
		public DateTime DateUpdated { get; set; }
		/// <summary>
		/// A human readable descriptive text for this resource, up to 64 characters long. By default, the FriendlyName is a nicely formatted version of the phone number.
		/// </summary>
		public string FriendlyName { get; set; }
		/// <summary>
		/// The unique id of the Account responsible for this phone number.
		/// </summary>
		public string AccountSid { get; set; }
		/// <summary>
		/// The incoming phone number. e.g., +16175551212 (E.164 format)
		/// </summary>
		public string PhoneNumber { get; set; }
		/// <summary>
		/// Calls to this phone number will start a new TwiML session with this API version.
		/// </summary>
		public string ApiVersion { get; set; }
		/// <summary>
		/// Look up the caller's caller-ID name from the CNAM database (additional charges apply)
		/// </summary>
		public bool VoiceCallerIdLookup { get; set; }
		/// <summary>
		/// The URL Twilio will request when this phone number receives a call.
		/// </summary>
		public string VoiceUrl { get; set; }
		/// <summary>
		/// The HTTP method Twilio will use when requesting the above Url. Either GET or POST.
		/// </summary>
		public string VoiceMethod { get; set; }
		/// <summary>
		/// The URL that Twilio will request if an error occurs retrieving or executing the TwiML requested by Url.
		/// </summary>
		public string VoiceFallbackUrl { get; set; }
		/// <summary>
		/// The HTTP method Twilio will use when requesting the VoiceFallbackUrl. Either GET or POST.
		/// </summary>
		public string VoiceFallbackMethod { get; set; }
		/// <summary>
		/// The URL that Twilio will request to pass status parameters (such as call ended) to your application.
		/// </summary>
		public string StatusCallback { get; set; }
		/// <summary>
		/// The HTTP method Twilio will use to make requests to the StatusCallbackUrl. Either GET or POST.
		/// </summary>
		public string StatusCallbackMethod { get; set; }
		/// <summary>
		/// The URL Twilio will request when receiving an incoming SMS message to this number.
		/// </summary>
		public string SmsUrl { get; set; }
		/// <summary>
		/// The HTTP method Twilio will use when making requests to the SmsUrl. Either GET or POST.
		/// </summary>
		public string SmsMethod { get; set; }
		/// <summary>
		/// The URL that Twilio will request if an error occurs retrieving or executing the TwiML from SmsUrl.
		/// </summary>
		public string SmsFallbackUrl { get; set; }
		/// <summary>
		/// The HTTP method Twilio will use when requesting the above URL. Either GET or POST.
		/// </summary>
		public string SmsFallbackMethod { get; set; }
		/// <summary>
		/// The ApplicationSid assigned to this number for SMS requests
		/// </summary>
		public string SmsApplicationSid { get; set; }
		/// <summary>
		/// The ApplicationSid assigned to this number for voice requests
		/// </summary>
		public string VoiceApplicationSid { get; set; }
		/// <summary>
		/// Indicates whether this number requires an associated physical address.
		/// One of "any", "local", "foreign", or "none".
		/// </summary>
		public string AddressRequirements { get; set; }
                /// <summary>
                /// Whether this number is new to the Twilio platform.
                /// </summary>
                public bool Beta { get; set; }

                public Capabilities Capabilities { get; set; }
	}
}
