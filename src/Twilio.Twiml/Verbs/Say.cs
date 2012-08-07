using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Converts text to speech that is read back to the caller.
    /// </summary>
    /// <remarks>
    /// Useful for development or saying dynamic text that is difficult to pre-record.
    /// </remarks>
	public class Say : ElementBase
	{
        /// <summary>
        /// Initializes a new instance of the Say class
        /// </summary>
        /// <param name="text">The text to convert to voice</param>
		public Say(string text)
		{
			Element = new XElement("Say", text);

			AllowedAttributes.Add("voice");
			AllowedAttributes.Add("language");
			AllowedAttributes.Add("loop");
		}

        /// <summary>
        /// Initializes a new instance of the Say class
        /// </summary>
        /// <param name="text">The text to convert to voice</param>
        /// <param name="attributes">Additional parameters of the Say verb</param>
        public Say(string text, object attributes)
            : this(text)
		{
			AddAttributesFromObject(attributes);
		}
	}
}
