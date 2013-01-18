using System;

namespace Twilio
{
	/// <summary>
	/// Result of making a request to validate an OutgoingCallerId
	/// </summary>
	public sealed class ValidationRequestResult //: TwilioListBase
	{
        /// <summary>
        /// The current page number. Zero-indexed, so the first page is 0.
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// The total number of pages.
        /// </summary>
        public int NumPages { get; set; }
        /// <summary>
        /// How many items are in each page
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// The total number of items in the list.
        /// </summary>
        public int Total { get; set; }
        /// <summary>
        /// The position in the overall list of the first item in this page.
        /// </summary>
        public int Start { get; set; }
        /// <summary>
        /// The position in the overall list of the last item in this page.
        /// </summary>
        public int End { get; set; }
        /// <summary>
        /// The URI for the first page of this list.
        /// </summary>
        public Uri FirstPageUri { get; set; }
        /// <summary>
        /// The URI for the next page of this list.
        /// </summary>
        public Uri NextPageUri { get; set; }
        /// <summary>
        /// The URI for the previous page of this list.
        /// </summary>
        public Uri PreviousPageUri { get; set; }
        /// <summary>
        /// The URI for the last page of this list.
        /// </summary>
        public Uri LastPageUri { get; set; }



		/// <summary>
		/// The unique id of the Account to which the Validation Request belongs.
		/// </summary>
		public string AccountSid { get; set; }
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