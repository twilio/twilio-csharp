using System;
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// Twilio API call result with paging information.
	/// </summary>
	public class AddressResult : TwilioListBase
	{
		/// <summary>
		/// List of Address results returned from Twilio API call.
		/// </summary>
		public List<Address> Addresses { get; set; }
	}
}

