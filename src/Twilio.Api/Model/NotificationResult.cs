using System;
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// Twilio API call result with paging information
	/// </summary>
	public class NotificationResult : TwilioListBase
	{
		/// <summary>
		/// List of Notification instances returned by API
		/// </summary>
		public List<Notification> Notifications { get; set; }
	}
}