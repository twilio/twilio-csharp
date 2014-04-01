using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    public class Feedback : TwilioBase
    {
        /// <summary>
        /// 1 to 5 quality score where 1 represents imperfect experience and 5 represents a perfect call
        /// </summary>
        public int QualityScore { get; set; }
        /// <summary>
        /// A list of issues experienced during the call.
        /// </summary>
        /// <remarks>Issues can be: imperfect-audio, dropped-call,  incorrect-caller-id,  post-dial-delay,  digits-not-captured, audio-latency, or one-way-audio</remarks>
        public List<string> Issues { get; set; }
        /// <summary>
        /// The date that this resource was created, given as GMT
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// The date that this resource was last updated, given as GMT 
        /// </summary>
        public DateTime DateUpdated { get; set; }
    }
}
