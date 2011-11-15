using System;
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// Twilio API call result with paging information
	/// </summary>
	public class AuthorizedConnectAppResult : TwilioListBase
	{
		/// <summary>
		/// List of AuthorizedConnectApp instances returned by API
		/// </summary>
		public List<AuthorizedConnectApp> AuthorizedConnectApps { get; set; }
	}
}