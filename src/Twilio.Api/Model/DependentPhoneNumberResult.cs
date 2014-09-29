using System;
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// Twilio API call result with paging information.
	/// </summary>
	public class DependentPhoneNumberResult : TwilioListBase
	{
		public List<DependentPhoneNumber> DependentPhoneNumbers { get; set; }
	}
}

