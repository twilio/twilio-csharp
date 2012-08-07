using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    ///  Waits silently for a specific number of seconds.
    /// </summary>
    /// <remarks>
    /// If &lt;Pause&gt; is the first verb in a TwiML document, Twilio will wait the specified number of seconds before picking up the call.
    /// </remarks>
	public class Pause : ElementBase
	{
        /// <summary>
        /// Initializes a new instance of the Pause class.
        /// </summary>
		public Pause()
		{
			Element = new XElement("Pause");
			AllowedAttributes.Add("length");
		}

        /// <summary>
        /// Initializes a new instance of the Pause class, pausing for the specified number of seconds.
        /// </summary>
        /// <param name="seconds">The number of seconds to pause</param>
        public Pause(int seconds)
            : this()
		{
			SetAttributeValue("length", seconds);
		}
	}
}