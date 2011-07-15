using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
	public class Pause : ElementBase
	{
		public Pause()
		{
			Element = new XElement("Pause");
			AllowedAttributes.Add("length");
		}

		public Pause(int seconds) : this()
		{
			SetAttributeValue("length", seconds);
		}
	}
}