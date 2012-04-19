using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Rejects an incoming call to your Twilio number without billing you
    /// </summary>
	public class Reject : ElementBase
	{
		public Reject()
		{
			Element = new XElement("Reject");
			AllowedAttributes.Add("reason");
		}

		public Reject(string reason) : this()
		{
			SetAttributeValue("reason", reason);	
		}
	}
}
