using System;

namespace Twilio
{
	/// <summary>
	/// An Call instance resource represents a single Twilio Call.
	/// </summary>
	public sealed class Call //: TwilioBase
	{
        /// <summary>
        /// Exception encountered during API request
        /// </summary>
        public RestException RestException { get; set; }
        /// <summary>
        /// The URI for this resource, relative to https://api.twilio.com
        /// </summary>
        public Uri Uri { get; set; }

		/// <summary>
		/// A 34 character string that uniquely identifies this resource.
		/// </summary>
		public string Sid { get; set; }
		/// <summary>
		/// A 34 character string that uniquely identifies the call that created this leg.
		/// </summary>
		public string ParentCallSid { get; set; }
		/// <summary>
		/// The date that this resource was created, given as GMT
		/// </summary>
		public DateTimeOffset DateCreated { get; set; }
		/// <summary>
		/// The date that this resource was last updated, given as GMT 
		/// </summary>
		public DateTimeOffset DateUpdated { get; set; }
		/// <summary>
		/// The unique Sid of the Account responsible for creating this call.
		/// </summary>
		public string AccountSid { get; set; }
		/// <summary>
		/// The phone number that received this call. e.g., +16175551212 (E.164 format)
		/// </summary>
		public string To { get; set; }
		/// <summary>
		/// The phone number that made this call. e.g., +16175551212 (E.164 format)
		/// </summary>
		public string From { get; set; }
		/// <summary>
		/// If the call was inbound, this is the Sid of the IncomingPhoneNumber that received the call. If the call was outbound, it is the Sid of the OutgoingCallerId from which the call was placed.
		/// </summary>
		public string PhoneNumberSid { get; set; }
		/// <summary>
		/// A string representing the status of the call. May be queued, ringing, in-progress, completed, failed, busy or no-answer.
		/// </summary>
		public string Status { get; set; }
		/// <summary>
		/// The start time of the call, given as GMT in RFC 2822 format. Empty if the call has not yet been dialed.
		/// </summary>
		public DateTimeOffset? StartTime { get; set; }
		/// <summary>
		/// The end time of the call, given as GMT in RFC 2822 format. Empty if the call did not complete successfully.
		/// </summary>
		public DateTimeOffset? EndTime { get; set; }
		/// <summary>
		/// The length of the call in seconds. This value is empty for busy, failed, unanswered or ongoing calls.
		/// </summary>
		public int? Duration { get; set; }
		/// <summary>
		/// The charge for this call in USD. Populated after the call is completed. May not be immediately available.
		/// </summary>
		public double? Price { get; set; }
		/// <summary>
		/// A string describing the direction of the call. inbound for inbound calls, outbound-api for calls initiated via the REST API or outbound-dial for calls initiated by a Dial verb.
		/// </summary>
		public string Direction { get; set; }
		/// <summary>
		/// If this call was initiated with answering machine detection, either human or machine. Empty otherwise.
		/// </summary>
		public string AnsweredBy { get; set; }
		/// <summary>
		/// If this call was an incoming call forwarded from another number, the forwarding phone number (depends on carrier supporting forwarding). Empty otherwise.
		/// </summary>
		public string ForwardedFrom { get; set; }
		/// <summary>
		/// If this call was an incoming call from a phone number with Caller ID Lookup enabled, the caller's name. Empty otherwise.
		/// </summary>
		public string CallerName { get; set; }
	}
}