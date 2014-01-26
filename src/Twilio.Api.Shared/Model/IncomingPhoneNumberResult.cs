using System;
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// Twilio API call result with paging information
	/// </summary>
	public class IncomingPhoneNumberResult : TwilioListBase
	{
		/// <summary>
		/// List of IncomingPhoneNumber instances returned by API
		/// </summary>
		public List<IncomingPhoneNumber> IncomingPhoneNumbers { get; set; }
	}
}