using System;
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// An Account instance resource represents a single Twilio Account.
	/// </summary>
	public sealed class Account //: TwilioBase, IDirectlyAddressable
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
		/// A 34 character string that uniquely identifies this account.
		/// </summary>
		public string Sid { get; set; }
		/// <summary>
		/// The date that this account was created, given as GMT
		/// </summary>
		public DateTimeOffset DateCreated { get; set; }
		/// <summary>
		/// The date that this account was last updated, given in as GMT
		/// </summary>
		public DateTimeOffset DateUpdated { get; set; }
		/// <summary>
		/// A human readable description of this account, up to 64 characters long. By default the FriendlyName is your email address.
		/// </summary>
		public string FriendlyName { get; set; }
		/// <summary>
		/// The status of this account. Usually active, but can be suspended if you've been bad.
		/// </summary>
		public string Status { get; set; }
		/// <summary>
		/// The authorization token for this account. This token should be kept a secret, so no sharing.
		/// </summary>
		public string AuthToken { get; set; }
	}
}