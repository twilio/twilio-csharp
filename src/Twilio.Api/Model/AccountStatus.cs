using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
	public enum AccountStatus
	{
		/// <summary>
		/// Available to be used
		/// </summary>
		Active,
		/// <summary>
		/// Temporarily suspended
		/// </summary>
		Suspended,
		/// <summary>
		/// Closed forever
		/// </summary>
		Closed
	}
}
