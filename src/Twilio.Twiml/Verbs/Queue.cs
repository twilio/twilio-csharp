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
        public Queue(string name)
        {
            Element = new XElement("Queue", name);

            AllowedAttributes.Add("url");
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
