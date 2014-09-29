using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

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
        [DeserializeAs(Name="media_list")]
		public List<Media> Medias { get; set; }
	}
}

