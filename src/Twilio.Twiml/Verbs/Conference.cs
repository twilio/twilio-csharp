using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
	public class Conference : ElementBase
	{
		public Conference()
		{
			Element = new XElement("Conference");

			AllowedAttributes.Add("muted");
			AllowedAttributes.Add("beep");
			AllowedAttributes.Add("waitUrl");
			AllowedAttributes.Add("waitMethod");
			AllowedAttributes.Add("startConferenceOnEnter");
			AllowedAttributes.Add("endConferenceOnExit");
		}

		public Conference(string room) : this()
		{
			Element = new XElement("Conference", room);
		}

		public Conference(string room, object attributes) : this(room)
		{
			AddAttributesFromObject(attributes);
		}
	}
}
