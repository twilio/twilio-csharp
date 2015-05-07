using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twilio.TwiML;
using System.Xml.Linq;

namespace Twilio.TwiML
{

    /// <summary>
    /// 
    /// </summary>
    public class Queue : ElementBase, IDialNoun
    {
        /// <summary>
        /// Initializes a new instance of the Queue class
        /// </summary>
        /// <param name="name">The name of the queue</param>
        public Queue()
        {
            Element = new XElement("Queue");

            AllowedAttributes.Add("url");
            AllowedAttributes.Add("reservationSid");
            AllowedAttributes.Add("postworkActivitySid");
        }

        public Queue(string name) : this()
        {
            Element.SetValue(name);
        }

        public Queue(object attributes)
            : this()
        {
            AddAttributesFromObject(attributes);
        }

        /// <summary>
        /// Initializes a new instance of the Queue class
        /// </summary>
        /// <param name="name">The name of the queue</param>
        /// <param name="attributes">Additional parameters of the Queue verb</param>
        public Queue(string name, object attributes)
            : this(name)
        {
            AddAttributesFromObject(attributes);
        }
    }
}
