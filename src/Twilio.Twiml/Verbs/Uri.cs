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
	public class Uri : ElementBase
	{
		/// <summary>
		/// Initializes a new instance of the Uri class.
		/// </summary>
		public Uri(string uri)
		{
			Element = new XElement("Uri");
            Element.Add(uri);

			AllowedAttributes.Add("username");
			AllowedAttributes.Add("password");
		}

        public Uri(string uri, object attributes) : this (uri) 
        {
            AddAttributesFromObject(attributes);
        }

	}
}

