using System;
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// Twilio API call result
	/// </summary>
	public class AvailablePhoneNumberResult : TwilioBase
	{
		/// <summary>
		/// List of AvailablePhoneNumbers search results
		/// </summary>
		public List<AvailablePhoneNumber> AvailablePhoneNumbers { get; set; }
	}
}