using System;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Transfers control of a call to the TwiML at a different URL.
    /// </summary>
    /// <remarks>
    /// All verbs after &lt;Redirect&gt; are unreachable and ignored
    /// </remarks>
	public class Redirect : ElementBase
	{
		public Redirect()
		{
			Element = new XElement("Redirect");
			AllowedAttributes.Add("method");
		}

		public Redirect(string url) : this()
		{
			Element.Add(url);
		}

		public Redirect(string url, string method) : this(url)
		{
			SetAttributeValue("method", method);
		}
	}
}
