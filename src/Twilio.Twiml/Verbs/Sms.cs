using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
	public class Sms : ElementBase
	{
		public Sms()
		{
			Element = new XElement("Sms");

			AllowedAttributes.Add("to");
			AllowedAttributes.Add("from");
			AllowedAttributes.Add("action");
			AllowedAttributes.Add("method");
			AllowedAttributes.Add("statusCallback");
		}

		public Sms(string message) : this()
		{
			Element.Add(message);
		}

		public Sms(string message, object attributes) : this(message)
		{
			AddAttributesFromObject(attributes);
		}
	}
}
