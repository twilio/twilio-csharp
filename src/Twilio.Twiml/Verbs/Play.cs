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
        /// <summary>
        /// Initializes a new instance of the Play class
        /// </summary>
        /// <param name="url">The URL of the audio file to be played</param>
		public Play(string url)
		{
			Element = new XElement("Play", url);
		}

        /// <summary>
        /// Initializes a new instance of the Play class
        /// </summary>
        /// <param name="url">The URL of the audio file to be played</param>
        /// <param name="attributes">Additional parameters of the Play verb</param>
        public Play(string url, object attributes)
            : this(url)
		{
			AddAttributesFromObject(attributes);
		}
	}
}
