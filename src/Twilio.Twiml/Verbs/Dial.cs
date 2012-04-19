using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Connects the current caller to another phone.
    /// </summary>
    /// <remarks>
    /// If the called party picks up, the two parties are connected and can communicate 
    /// until one hangs up. If the called party does not pick up, if a busy signal is 
    /// received, or if the number doesn't exist, the dial verb will finish.  When the 
    /// dialed call ends, Twilio makes a GET or POST request to the 'action' URL if 
    /// provided. Call flow will continue using the TwiML received in response to that 
    /// request.
    /// </remarks>
	public class Dial : ElementBase
	{
		public Dial()
		{
			Element = new XElement("Dial");
			AllowedChildren.Add("Number");
			AllowedChildren.Add("Client");
			AllowedChildren.Add("Conference");

			AllowedAttributes.Add("timeout");
			AllowedAttributes.Add("callerId");
			AllowedAttributes.Add("action");
			AllowedAttributes.Add("method");
			AllowedAttributes.Add("hangupOnStar");
			AllowedAttributes.Add("timeLimit");
		}

		public Dial(string number) : this()
		{
			Element.Add(number);
		}

		public Dial(string number, object attributes) : this(number)
		{
			AddAttributesFromObject(attributes);
		}
	}
}