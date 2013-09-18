using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twilio.TwiML;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Transfers control of a call that is in a queue so that the caller exits the queue and execution continues with the next verb after the original Enqueue
    /// </summary>
    public class Leave : ElementBase
    {
        /// <summary>
        /// Initializes a new instance of the Leave class.
        /// </summary>
        public Leave()
        {
            Element = new XElement("Leave");
        }
    }
}