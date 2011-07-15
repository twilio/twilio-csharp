using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
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
