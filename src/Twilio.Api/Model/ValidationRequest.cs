using System;

namespace Twilio
{
	/// <summary>
	/// Result of making a request to validate an OutgoingCallerId
	/// </summary>
	public class ValidationRequestResult : TwilioListBase
	{
		/// <summary>
		/// The unique id of the Account to which the Validation Request belongs.
		/// </summary>
		public string AccountSid { get; set; }
        /// <summary>
        /// The unique id of the Call created for this validation attempt
        /// </summary>
        public string CallSid { get; set; }
        /// <summary>
		/// The friendly name you provided, if any.
		/// </summary>
		public string FriendlyName { get; set; }
		/// <summary>
		/// The incoming phone number being validated, formatted with a '+' and country code e.g., +16175551212 (E.164 format).
		/// </summary>
		public string PhoneNumber { get; set; }
		/// <summary>
		/// The 6 digit validation code that must be entered via the phone to validate this phone number for Caller ID.
		/// </summary>
		public string ValidationCode { get; set; }
	}
}