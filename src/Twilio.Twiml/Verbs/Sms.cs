using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Sends an SMS message to a phone number.
    /// </summary>
	public class Sms : ElementBase
	{
        /// <summary>
        /// Initializes a new instance of the Sms class.
        /// </summary>
		public Sms()
		{
			Element = new XElement("Sms");

			AllowedAttributes.Add("to");
			AllowedAttributes.Add("from");
			AllowedAttributes.Add("action");
			AllowedAttributes.Add("method");
			AllowedAttributes.Add("statusCallback");
		}

        /// <summary>
        /// Initializes a new instance of the Sms class
        /// </summary>
        /// <param name="message">The Sms message body</param>
		public Sms(string message) : this()
		{
			Element.Add(message);
		}

        /// <summary>
        /// Initializes a new instance of the Sms class
        /// </summary>
        /// <param name="message">The Sms message body</param>
        /// <param name="attributes">Additional parameters of the Sms verb</param>
        public Sms(string message, object attributes)
            : this(message)
		{
			AddAttributesFromObject(attributes);
		}
	}
}
