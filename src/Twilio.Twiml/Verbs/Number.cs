using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Specifies a phone number to dial.
    /// </summary>
    /// <remarks>
    /// Using the noun's attributes you can specify particular behaviors that Twilio should apply when dialing the number.  You can use multiple &lt;Number&gt; nouns within a &lt;Dial&gt; verb to simultaneously call all of them at once. The first call to pick up is connected to the current call and the rest are hung up.
    /// </remarks>
	public class Number : ElementBase, IDialNoun
	{
		public Number(string number)
		{
			Element = new XElement("Number", number);
			AllowedAttributes.Add("url");
			AllowedAttributes.Add("sendDigits");
		}

		public Number(string number, object attributes) : this(number)
		{
			AddAttributesFromObject(attributes);
		}
	}
}