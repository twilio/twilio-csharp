using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
	public class Record : ElementBase
	{
		public Record()
		{
			Element = new XElement("Record");

			AllowedAttributes.Add("action");
			AllowedAttributes.Add("method");
			AllowedAttributes.Add("timeout");
			AllowedAttributes.Add("finishOnKey");
			AllowedAttributes.Add("maxlength");
			AllowedAttributes.Add("transcribe");
			AllowedAttributes.Add("transcribeCallback");
			AllowedAttributes.Add("playBeep");
		}

		public Record(object attributes) : this()
		{
			AddAttributesFromObject(attributes);
		}
	}
}