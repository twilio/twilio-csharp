using System;

namespace Twilio
{
	/// <summary>
	/// An SMSMessage instance resource represents a single Twilio SMSMessage.
	/// </summary>
	public class SMSMessage : TwilioBase
	{
		/// <summary>
		/// A 34 character string that uniquely identifies this resource.
		/// </summary>
		public string Sid { get; set; }
		/// <summary>
		/// The date that this resource was created
		/// </summary>
		public DateTime DateCreated { get; set; }
		/// <summary>
		/// The date that this resource was last updated
		/// </summary>
		public DateTime DateUpdated { get; set; }
		/// <summary>
		/// The date that the SMS was sent
		/// </summary>
		public DateTime DateSent { get; set; }
		/// <summary>
		/// The unique id of the Account that sent this SMS message.
		/// </summary>
		public string AccountSid { get; set; }
		/// <summary>
		/// The phone number that initiated the message in E.164 format. For incoming messages, this will be the remote phone. For outgoing messages, this will be one of your Twilio phone numbers.
		/// </summary>
		public string From { get; set; }
		/// <summary>
		/// The phone number that received the message in E.164 format. For incoming messages, this will be one of your Twilio phone numbers. For outgoing messages, this will be the remote phone.
		/// </summary>
		public string To { get; set; }
		/// <summary>
		/// The text body of the SMS message. Up to 160 characters long.
		/// </summary>
		public string Body { get; set; }
		/// <summary>
		/// The status of this SMS message. Either queued, sending, sent, or failed.
		/// </summary>
		public string Status { get; set; }
		/// <summary>
		/// The direction of this SMS message. incoming for incoming messages, outbound-api for messages initiated via the REST API, outbound-call for messages initiated during a call or outbound-reply for messages initiated in response to an incoming SMS.
		/// </summary>
		public string Direction { get; set; }
		/// <summary>
		/// The amount billed for the message.
		/// </summary>
		public decimal Price { get; set; }
		/// <summary>
		/// The version of the Twilio API used to process the SMS message.
		/// </summary>
		public string ApiVersion { get; set; }
	}
}