using System;
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// Twilio API call result with paging information
	/// </summary>
	public class ParticipantResult : TwilioListBase
	{
		/// <summary>
		/// List of conference Participant resources returned by API
		/// </summary>
		public List<Participant> Participants { get; set; }
	}
}