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