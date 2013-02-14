using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Connects the current caller to Sip call
    /// </summary>
	public class Sip : ElementBase
	{
        /// <summary>
        /// Initializes a new instance of the Sip class.
        /// </summary>
		public Sip()
		{
			Element = new XElement("Sip");
			AllowedChildren.Add("Uri");
			AllowedChildren.Add("Headers");

			AllowedAttributes.Add("username");
			AllowedAttributes.Add("password");
			AllowedAttributes.Add("url");
			AllowedAttributes.Add("method");
		}

	}
}

