using System;
using System.Xml.Linq;

namespace Twilio.TwiML
{
	public class Redirect : ElementBase
	{
		public Redirect()
		{
			Element = new XElement("Redirect");
			AllowedAttributes.Add("method");
		}

		public Redirect(string url) : this()
		{
			Element.Add(url);
		}

		public Redirect(string url, string method) : this(url)
		{
			SetAttributeValue("method", method);
		}
	}
}
