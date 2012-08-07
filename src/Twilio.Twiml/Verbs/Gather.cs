using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Collects digits that a caller enters into his or her telephone keypad. 
    /// </summary>
    /// <remarks>
    /// When the caller is done entering data, Twilio submits that data to the 
    /// provided 'action' URL in an HTTP GET or POST request, just like a web browser 
    /// submits data from an HTML form.  If no input is received before 
    /// timeout, &lt;Gather&gt; falls through to the next verb in the TwiML document.
    /// You may optionally nest &lt;Say&gt; and &lt;Play&gt; verbs within a &lt;Gather&gt; verb 
    /// while waiting for input. This allows you to read menu options to the caller while 
    /// letting her enter a menu selection at any time. After the first digit is received 
    /// the audio will stop playing.
    /// </remarks>
	public class Gather : ElementBase
	{
        /// <summary>
        /// Initializes a new instance of the Gather class.
        /// </summary>
		public Gather()
		{
			Element = new XElement("Gather");
			AllowedChildren.Add("Say");
			AllowedChildren.Add("Play");
			AllowedChildren.Add("Pause");

			AllowedAttributes.Add("action");
			AllowedAttributes.Add("finishOnKey");
			AllowedAttributes.Add("method");
			AllowedAttributes.Add("numDigits");
			AllowedAttributes.Add("timeout");
		}

        /// <summary>
        /// Initializes a new instance of the Gather class.
        /// <param name="attributes"></param>
        /// </summary>
		public Gather(object attributes) : this()
		{
			AddAttributesFromObject(attributes);
		}
	}
}
