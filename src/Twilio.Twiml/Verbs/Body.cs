using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    public class Body : ElementBase, IMessageNoun
    {
        /// <summary>
        /// Initializes a new instance of the Body class.
        /// </summary>
        /// <param name="body"></param>
		public Body(string body)
		{
			Element = new XElement("Body", body);
		}
    }
}
