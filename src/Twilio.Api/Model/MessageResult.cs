using System;
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// Twilio API call result with paging information
	/// </summary>
	public class MessageResult : TwilioListBase
	{
		/// <summary>
		/// List of Message resources returned by API
		/// </summary>  
		public List<Message> Messages { get; set; }
	}
}
