using System;
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// Twilio API call result with paging information
	/// </summary>
	public class OutgoingCallerIdResult : TwilioListBase
	{
		/// <summary>
		/// List of OutgoingCallerId instances returned by API
		/// </summary>
		public List<OutgoingCallerId> OutgoingCallerIds { get; set; }
	}
}