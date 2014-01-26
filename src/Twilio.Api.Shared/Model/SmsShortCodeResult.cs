using System;
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// Twilio API call result with paging information
	/// </summary>
	public class SmsShortCodeResult : TwilioListBase
	{
		/// <summary>
		/// List of ShortCode resources returned by API
		/// </summary>
		public List<SMSShortCode> ShortCodes { get; set; }
	}
}