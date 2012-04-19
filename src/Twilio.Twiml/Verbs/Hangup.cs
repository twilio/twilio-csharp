using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Ends a call.
    /// </summary>
    /// <remarks>
    /// If used as the first verb in a TwiML response it does not prevent Twilio from answering the call and billing your account. The only way to not answer a call and prevent billing is to use the &lt;Reject&gt; verb.
    /// </remarks>
	public class Hangup : ElementBase
	{
        /// <summary>
        /// Initializes a new instance of the Hangup class.
        /// </summary>
		public Hangup()
		{
			Element = new XElement("Hangup");
		}
	}
}
