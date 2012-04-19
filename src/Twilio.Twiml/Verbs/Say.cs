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
		public Say(string text)
		{
			Element = new XElement("Say", text);

			AllowedAttributes.Add("voice");
			AllowedAttributes.Add("language");
			AllowedAttributes.Add("loop");
		}
				
		public Say(string text, object attributes) : this(text)
		{
			AddAttributesFromObject(attributes);
		}
	}
}
