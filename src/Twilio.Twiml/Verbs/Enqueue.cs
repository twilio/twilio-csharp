using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twilio.TwiML;
using System.Xml.Linq;

namespace Twilio.TwiML
{

	/// <summary>
	/// TODO: Update summary.
	/// </summary>
	public class Enqueue : ElementBase
	{
        /// <summary>
        /// Initializes a new instance of the Enqueue class.
        /// </summary>
        /// <param name="name"></param>
		public Enqueue(string name)
		{
			Element = new XElement("Enqueue", name);
<<<<<<< HEAD
            AllowedChildren.Add("TaskAttributes");
=======
>>>>>>> origin/pricing

            AllowedAttributes.Add("action");
            AllowedAttributes.Add("method");
            AllowedAttributes.Add("waitUrl");
            AllowedAttributes.Add("waitUrlMethod");
<<<<<<< HEAD
            AllowedAttributes.Add("workflowSid");
=======
>>>>>>> origin/pricing
		}

        public Enqueue(string name, object attributes) : this(name)
		{
			AddAttributesFromObject(attributes);
		}

	}
}
