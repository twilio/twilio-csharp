using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
	/// <summary>
	/// A URI for your Sip call
	/// </summary>
	public class Headers : ElementBase
	{
		/// <summary>
		/// Initializes a new instance of the Headers class.
		/// </summary>
		public Headers()
		{
			Element = new XElement("Headers");
			AllowedChildren.Add("Header");
		}
	}
}

