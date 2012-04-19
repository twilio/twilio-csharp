using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Plays an audio file back to the caller.
    /// </summary>
    /// <remarks>
    /// Twilio retrieves the file from a URL that you provide.
    /// </remarks>
	public class Play : ElementBase
	{
		public Play(string url)
		{
			Element = new XElement("Play", url);
		}

		public Play(string url, object attributes) : this(url)
		{
			AddAttributesFromObject(attributes);
		}
	}
}
