using System;

namespace Twilio
{
	/// <summary>
	/// Available options when purchasing phone numbers via the API. NOTE: you can only request phone numbers with a full Twilio account, not in the Twilio Free Trial. If you would like to buy a Twilio phone number, you must upgrade your account.
	/// </summary>
	public class PhoneNumberOptions
	{
		/// <summary>
		/// The AccountSid to assign this number to. Only used for moving phone numbers betweeen subaccounts.
		/// </summary>
		public string AccountSid { get; set; }
        /// <summary>
        /// The Twilio REST API version to use for incoming calls made to this number.
        /// </summary>
        public string ApiVersion { get; set; }
		/// <summary>
		/// The area code in which you'd like a new incoming phone number. Any three digit, US area code is valid. Twilio will provision a random phone number within this area code for you. You must include either this or a PhoneNumber parameter to have your POST succeed.
		/// </summary>
		public string AreaCode { get; set; }
		/// <summary>
		/// The phone number you want to purchase. The number should be formated starting with a '+' followed by the country code and the number in E.164 format e.g., '+15105555555'. You must include either this or an AreaCode parameter to have your POST succeed.
		/// </summary>
		public string PhoneNumber { get; set; }
		/// <summary>
		/// A human readable description of the new incoming phone number. Maximum 64 characters. Defaults to a formatted version of the number.
		/// </summary>
		public string FriendlyName { get; set; }
		/// <summary>
		/// The 34 character sid of the application Twilio should use to handle SMSs sent to this number. If a SmsApplicationSid is present, Twilio will ignore all of the SMS urls above and use those set on the application.
		/// </summary>
		public string SmsApplicationSid { get; set; }
		/// <summary>
		/// The 34 character sid of the application Twilio should use to handle phone calls to this number. If a VoiceApplicationSid is present, Twilio will ignore all of the voice urls above and use those set on the application.
		/// </summary>
		public string VoiceApplicationSid { get; set; }
		/// <summary>
		/// The URL that Twilio should request when somebody dials the new phone number.
		/// </summary>
		public string VoiceUrl { get; set; }
		/// <summary>
		/// The HTTP method that should be used to request the VoiceUrl. Must be either GET or POST. Defaults to POST.
		/// </summary>
		public string VoiceMethod { get; set; }
		/// <summary>
		/// A URL that Twilio will request if an error occurs requesting or executing the TwiML at Url.
		/// </summary>
		public string VoiceFallbackUrl { get; set; }
		/// <summary>
		/// The HTTP method that should be used to request the VoiceFallbackUrl. Either GET or POST. Defaults to POST.
		/// </summary>
		public string VoiceFallbackMethod { get; set; }
		/// <summary>
		/// The URL that Twilio should request when somebody sends an SMS to the phone number.
		/// </summary>
		public string SmsUrl { get; set; }
		/// <summary>
		/// The HTTP method that should be used to request the SmsUrl. Must be either GET or POST. Defaults to POST.
		/// </summary>
		public string SmsMethod { get; set; }
		/// <summary>
		/// A URL that Twilio will request if an error occurs requesting or executing the TwiML defined by SmsUrl.
		/// </summary>
		public string SmsFallbackUrl { get; set; }
		/// <summary>
		/// The HTTP method that should be used to request the SmsFallbackUrl. Must be either GET or POST. Defaults to POST.
		/// </summary>
		public string SmsFallbackMethod { get; set; }
		/// <summary>
		/// Do a lookup of a caller's name from the CNAM database and post it to your app. Either true or false. Defaults to false.
		/// </summary>
		public bool? VoiceCallerIdLookup { get; set; }
		/// <summary>
		/// The URL that Twilio will request to pass status parameters (such as call ended) to your application.
		/// </summary>
		public string StatusCallback { get; set; }
		/// <summary>
		/// The HTTP method Twilio will use to make requests to the StatusCallback URL. Either GET or POST. Defaults to POST.
		/// </summary>
		public string StatusCallbackMethod { get; set; }
        /// <summary>
        /// The 34 character sid of the Trunk Twilio should use to handle phone calls to this number
        /// </summary>
        public string TrunkSid { get; set; }
	}
}