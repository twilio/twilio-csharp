using System;

namespace Twilio
{
	/// <summary>
	/// Available options to include when initiating a phone call
	/// </summary>
	public class CallOptions
	{
		/// <summary>
		/// The phone number to use as the caller id. Format with a '+' and country code e.g., +16175551212 (E.164 format). Must be a Twilio number or a valid outgoing caller id for your account.
		/// </summary>
		public string From { get; set; }
		/// <summary>
		/// The number to call formatted with a '+' and country code e.g., +16175551212 (E.164 format). Twilio will also accept unformatted US numbers e.g., (415) 555-1212, 415-555-1212.
		/// </summary>
		public string To { get; set; }
		/// <summary>
		/// The fully qualified URL that should be consulted when the call connects. Just like when you set a URL for your inbound calls.
		/// </summary>
		public string Url { get; set; }
		/// <summary>
		/// The 34 character sid of the application Twilio should use to handle this phone call. If this parameter is present, Twilio will ignore all of the voice URLs passed and use the URLs set on the application.
		/// </summary>
		public string ApplicationSid { get; set; }
		/// <summary>
		/// A URL that Twilio will request when the call ends to notify your app.
		/// </summary>
		public string StatusCallback { get; set; }
		/// <summary>
		/// The HTTP method Twilio should use when requesting the above URL. Defaults to POST.
		/// </summary>
		public string StatusCallbackMethod { get; set; }
		/// <summary>
		/// The call lifecycle events Twilio should send a StatusCallback request for.
		/// Available event types:
		/// - initiated
		/// - ringing
		/// - answered
		/// - completed
		///
		/// "completed" events are free; see twilio.com for pricing on the other event types.
		/// If not set, defaults to ["completed"].
		/// </summary>
		public string[] StatusCallbackEvents { get; set; }
		/// <summary>
		/// The HTTP method Twilio should use when requesting the required Url parameter's value above. Defaults to POST.
		/// </summary>
		public string Method { get; set; }
		/// <summary>
		/// A string of keys to dial after connecting to the number. Valid digits in the string include: any digit (0-9), '#' and '*'. For example, if you connected to a company phone number, and wanted to dial extension 1234 and then the pound key, use SendDigits=1234#. Remember to URL-encode this string, since the '#' character has special meaning in a URL.
		/// </summary>
		public string SendDigits { get; set; }
		/// <summary>
		/// Tell Twilio to try and determine if a machine (like voicemail) or a human has answered the call. Possible values are Continue and Hangup.
		/// </summary>
		public string IfMachine { get; set; }
		/// <summary>
		/// The integer number of seconds that Twilio should allow the phone to ring before assuming there is no answer. Default is 60 seconds, the maximum is 999 seconds. Note, you could set this to a low value, such as 15, to hangup before reaching an answering machine or voicemail.
		/// </summary>
		public int? Timeout { get; set; }
		/// <summary>
		/// A URL that Twilio will request if an error occurs requesting or executing the TwiML at Url.
		/// </summary>
		public string FallbackUrl { get; set; }
		/// <summary>
		/// The HTTP method that Twilio should use to request the FallbackUrl. Must be either GET or POST. Defaults to POST.
		/// </summary>
		public string FallbackMethod { get; set; }
		/// <summary>
		/// Set this parameter to 'true' to record the entirety of a phone call. The RecordingUrl will be sent to the StatusCallback URL. Defaults to 'false'.
		/// </summary>
		public bool Record { get; set; }
		/// <summary>
		/// If this is a Sip call, set the authorization username for your Sip
		/// endpoint
		/// </summary>
		public string SipAuthUsername { get; set; }
		/// <summary>
		/// If this is a Sip call, set the authorization password for your Sip
		/// endpoint
		/// </summary>
		public string SipAuthPassword { get; set; }
		/// <summary>
		/// Set this parameter to specify the number of channels in the final .wav recording. Defaults to 'mono'.
		/// </summary>
		public string RecordingChannels { get; set; }
		/// <summary>
		/// A URL that Twilio will request when the recording is ready to notify your app.
		/// </summary>
		public string RecordingStatusCallback { get; set; }
		/// <summary>
		/// The HTTP method Twilio should use when requesting the above URL. Defaults to POST.
		/// </summary>
		public string RecordingStatusCallbackMethod { get; set; }
	}
}
