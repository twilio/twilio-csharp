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
        /// <summary>
        /// Initializes a new instance of the Redirect class.
        /// </summary>
		public Redirect()
		{
			Element = new XElement("Redirect");
			AllowedAttributes.Add("method");
		}

        /// <summary>
        /// Initializes a new instance of the Redirect class using the specified Url
        /// </summary>
        /// <param name="url">An absolute or relative URL for a different TwiML document</param>
		public Redirect(string url) : this()
		{
			Element.Add(url);
		}

        /// <summary>
        /// Initializes a new instance of the Redirect class using the specified Url and Method
        /// </summary>
        /// <param name="url">An absolute or relative URL for a different TwiML document</param>
        /// <param name="method">This tells Twilio whether to request the &lt;Redirect&gt; URL via HTTP GET or POST. 'POST' is the default.</param>
		public Redirect(string url, string method) : this(url)
		{
			SetAttributeValue("method", method);
		}
	}
}
