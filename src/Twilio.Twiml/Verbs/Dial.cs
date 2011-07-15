using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
	public class Dial : ElementBase
	{
		public Dial()
		{
			Element = new XElement("Dial");
			AllowedChildren.Add("Number");
			AllowedChildren.Add("Conference");

			AllowedAttributes.Add("timeout");
			AllowedAttributes.Add("callerId");
			AllowedAttributes.Add("action");
			AllowedAttributes.Add("method");
			AllowedAttributes.Add("hangupOnStar");
			AllowedAttributes.Add("timeLimit");
		}

		public Dial(string number) : this()
		{
			Element.Add(number);
		}

		public Dial(string number, object attributes) : this(number)
		{
			AddAttributesFromObject(attributes);
		}
	}
}