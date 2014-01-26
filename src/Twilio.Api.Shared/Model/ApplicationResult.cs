using System;
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// Twilio API call result with paging information
	/// </summary>
	public class ApplicationResult : TwilioListBase
	{
		/// <summary>
		/// List of Application instances returned by API
		/// </summary>
		public List<Application> Applications { get; set; }
	}
}