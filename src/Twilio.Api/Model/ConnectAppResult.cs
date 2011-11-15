using System;
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// Twilio API call result with paging information
	/// </summary>
	public class ConnectAppResult : TwilioListBase
	{
		/// <summary>
		/// List of ConnectApp instances returned by API
		/// </summary>
		public List<ConnectApp> ConnectApps { get; set; }
	}
}