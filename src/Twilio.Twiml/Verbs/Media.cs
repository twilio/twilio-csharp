using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    public class Media : ElementBase, IMessageNoun
    {
        /// <summary>
        /// Initializes a new instance of the Media class.
        /// </summary>
        /// <param name="url"></param>
		public Media(string url)
		{
			Element = new XElement("Media", url);
		}

    }
}
