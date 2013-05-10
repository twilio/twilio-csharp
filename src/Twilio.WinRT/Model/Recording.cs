using System;

namespace Twilio
{
	/// <summary>
	/// An Recording instance resource represents a single Twilio Recording.
	/// </summary>
	public sealed class Recording //: TwilioBase
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
		/// The date that this resource was created
		/// </summary>
		public DateTimeOffset DateCreated { get; set; }
		/// <summary>
		/// The date that this resource was last updated
		/// </summary>
		public DateTimeOffset DateUpdated { get; set; }
		/// <summary>
		/// The unique id of the Account responsible for this recording.
		/// </summary>
		public string AccountSid { get; set; }
		/// <summary>
		/// The call during which the recording was made.
		/// </summary>
		public string CallSid { get; set; }
		/// <summary>
		/// The length of the recording, in seconds.
		/// </summary>
		public int Duration { get; set; }
		/// <summary>
		/// The version of the API in use during the recording.
		/// </summary>
		public string ApiVersion { get; set; }
	}
}