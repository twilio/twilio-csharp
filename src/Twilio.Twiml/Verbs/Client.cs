using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
	public class Client : ElementBase, IDialNoun
	{
		public Client(string clientName)
		{
			Element = new XElement("Client", clientName);
		}
	}
}