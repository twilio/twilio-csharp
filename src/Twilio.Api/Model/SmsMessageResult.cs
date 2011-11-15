using System;
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// Twilio API call result with paging information
	/// </summary>
	public class SmsMessageResult : TwilioListBase
	{
		/// <summary>
		/// List of SMSMessage resources returned by API
		/// </summary>
		public List<SMSMessage> SMSMessages { get; set; }
	}
}