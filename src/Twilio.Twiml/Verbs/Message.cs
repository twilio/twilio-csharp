using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Sends a message to a phone number
    /// </summary>
    public class Message : ElementBase
    {
        /// <summary>
        /// Initializes a new instance of the Message class.
        /// </summary>
        public Message() 
        {
        	Element = new XElement("Message");
            AllowedChildren.Add("Body");
            AllowedChildren.Add("Media");

			AllowedAttributes.Add("to");
			AllowedAttributes.Add("from");
			AllowedAttributes.Add("action");
			AllowedAttributes.Add("method");
			AllowedAttributes.Add("statusCallback");
        }

        /// <summary>
        /// Initializes a new instance of the Message class
        /// </summary>
        /// <param name="body">The Message body</param>
		public Message(string body) : this()
		{
			Element.Add(body);
		}

        /// <summary>
        /// Initializes a new instance of the Message class
        /// </summary>
        /// <param name="attributes">The Message body</param>
        public Message(object attributes)
            : this()
        {
            Element.Add();

            AddAttributesFromObject(attributes);
        }

        /// <summary>
        /// Initializes a new instance of the Message class
        /// </summary>
        /// <param name="body">The Message body</param>
        /// <param name="attributes">Additional parameters of the Message verb</param>
        public Message(string body, object attributes)
            : this(body)
		{
			AddAttributesFromObject(attributes);
		}
    }
}
