using System;
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// Twilio API call result with paging information
	/// </summary>
	public class ConferenceResult : TwilioListBase
	{
		/// <summary>
		/// List of Conference instances returned from API call
		/// </summary>
		public List<Conference> Conferences { get; set; }
	}
}