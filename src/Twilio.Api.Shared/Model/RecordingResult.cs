using System;
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// Twilio API call result with paging information
	/// </summary>
	public class RecordingResult : TwilioListBase
	{
		/// <summary>
		/// List of Recording instances returned by API
		/// </summary>
		public List<Recording> Recordings { get; set; }
	}
}