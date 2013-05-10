using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
	/// <summary>
	/// Represents a single ShortCode Instance resource
	/// </summary>
	public sealed class SMSShortCode //: TwilioBase
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
		/// A 34 character string that uniquely idetifies this resource.
		/// </summary>
		public string Sid { get; set; }
		/// <summary>
		/// The unique id of the Account that owns this short code.
		/// </summary>
		public string AccountSid { get; set; }
		/// <summary>
		/// A human readable descriptive text for this resource, up to 64 characters long. By default, the FriendlyName is just the short code.
		/// </summary>
		public string FriendlyName { get; set; }
		/// <summary>
		/// The short code. e.g., 894546.
		/// </summary>
		public string ShortCode { get; set; }
		/// <summary>
		/// The date that this resource was created.
		/// </summary>
		public string DateCreated { get; set; }
		/// <summary>
		/// The date that this resource was last updated.
		/// </summary>
		public string DateUpdated { get; set; }
		/// <summary>
		/// The URL Twilio will request when receiving an incoming SMS message to this short code.
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
		/// SMSs to this short code will start a new TwiML session with this API version.
		/// </summary>
		public string ApiVersion { get; set; }
	}
}
