using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
	public class Gather : ElementBase
	{
		public Gather()
		{
			Element = new XElement("Gather");
			AllowedChildren.Add("Say");
			AllowedChildren.Add("Play");
			AllowedChildren.Add("Pause");

			AllowedAttributes.Add("action");
			AllowedAttributes.Add("finishOnKey");
			AllowedAttributes.Add("method");
			AllowedAttributes.Add("numDigits");
			AllowedAttributes.Add("timeout");
		}

		public Gather(object attributes) : this()
		{
			AddAttributesFromObject(attributes);
		}
	}
}
