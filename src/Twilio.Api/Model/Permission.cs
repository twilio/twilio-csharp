using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    /// <summary>
    /// A single Connect App permission
    /// </summary>
	public class Permission
	{
        /// <summary>
        /// The value of the Permission.  Valid values are get-all or post-all.
        /// </summary>
		public string Value { get; set; }
	}
}
