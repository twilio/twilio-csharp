using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
	/// <summary>
	/// A HTTP Header class
	/// </summary>
	public class Header : ElementBase
	{
		/// <summary>
		/// Initializes a new HTTP Header which will be sent with the Sip
		/// request
		/// </summary>
		public Header()
		{
			Element = new XElement("Header");
			AllowedAttributes.Add("name");
			AllowedAttributes.Add("value");
		}
	}
}

