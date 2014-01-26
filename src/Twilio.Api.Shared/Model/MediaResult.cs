using System;
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// Twilio API call result with paging information
	/// </summary>
	public class MediaResult : TwilioListBase
	{
		/// <summary>
		/// List of Media resources returned by API
		/// </summary>  
		public List<Media> Medias { get; set; }
	}
}

