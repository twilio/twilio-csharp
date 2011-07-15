using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
	public class Number : ElementBase
	{
		public Number(string number)
		{
			Element = new XElement("Number", number);
			AllowedAttributes.Add("url");
			AllowedAttributes.Add("sendDigits");
		}

		public Number(string number, object attributes) : this(number)
		{
			AddAttributesFromObject(attributes);
		}
	}
}