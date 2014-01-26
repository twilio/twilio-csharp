using System;
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// Twilio API call result with paging information
	/// </summary>
	public class TranscriptionResult : TwilioListBase
	{
		/// <summary>
		/// List of Transcription resources returned by API
		/// </summary>
		public List<Transcription> Transcriptions { get; set; }
	}
}