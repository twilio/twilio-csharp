using System;
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// Twilio API call result with paging information
	/// </summary>
	public class CallResult : TwilioListBase
	{
		/// <summary>
		/// List of Calls returned from API request
		/// </summary>
		public List<Call> Calls { get; set; }
	}
}