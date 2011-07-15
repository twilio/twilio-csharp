using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
	public class Hangup : ElementBase
	{
		public Hangup()
		{
			Element = new XElement("Hangup");
		}
	}
}
