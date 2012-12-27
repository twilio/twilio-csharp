namespace Twilio
{
	/// <summary>
	/// Available options when creating a Twilio Application via the API. 
	/// </summary>
	public class ApplicationOptions
	{
		/// <summary>
		/// The URL that Twilio should request when somebody dials the a phone number using this application.
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
		/// The URL that Twilio should request when somebody sends an SMS to the phone number using this application.
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
        /// Twilio will make a POST request to this URL to pass status parameters (such as sent or failed) to your application if you specify this application's Sid as the ApplicationSid on an outgoing SMS request.
        /// </summary>
        public string SmsStatusCallback { get; set; }
        /// <summary>
		/// The HTTP method Twilio will use to make requests to the StatusCallback URL. Either GET or POST. Defaults to POST.
		/// </summary>
		public string StatusCallbackMethod { get; set; }
    }
}
