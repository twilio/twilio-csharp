using System;
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// Twilio API call result with paging information
	/// </summary>
	public class AvailablePhoneNumberResult : TwilioListBase
	{
		/// <summary>
		/// List of AvailablePhoneNumbers search results
		/// </summary>
		public List<AvailablePhoneNumber> AvailablePhoneNumbers { get; set; }
	}
}