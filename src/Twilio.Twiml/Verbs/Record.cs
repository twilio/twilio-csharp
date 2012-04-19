using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Records the caller's voice and returns to you the URL of a file containing the audio recording.
    /// </summary>
    /// <remarks>
    /// You can optionally generate text transcriptions of recorded calls by setting the 'transcribe' attribute of the &lt;Record&gt; verb to 'true'
    /// </remarks>
	public class Record : ElementBase
	{
        /// <summary>
        /// Initializes a new instance of the Record class.
        /// </summary>
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

        /// <summary>
        /// Initializes a new instance of the Record class using the provided attributes
        /// </summary>
        /// <param name="attributes">An anonymous type containing the Record attributes and their values</param>
		public Record(object attributes) : this()
		{
			AddAttributesFromObject(attributes);
		}
	}
}