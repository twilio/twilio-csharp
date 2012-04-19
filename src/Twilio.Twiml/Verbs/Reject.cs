using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Rejects an incoming call to your Twilio number without billing you
    /// </summary>
	public class Reject : ElementBase
	{
        /// <summary>
        /// Initializes a new instance of the Reject class.
        /// </summary>
		public Reject()
		{
			Element = new XElement("Reject");
			AllowedAttributes.Add("reason");
		}

        /// <summary>
        /// Initializes a new instance of the Reject class using the specified Reason
        /// </summary>
        /// <param name="reason">Tells Twilio what message to play when rejecting a call.  Takes the values "rejected" and "busy."</param>
		public Reject(string reason) : this()
		{
			SetAttributeValue("reason", reason);	
		}
	}
}
