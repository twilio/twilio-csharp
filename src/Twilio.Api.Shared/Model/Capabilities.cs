using System;
using System.Collections.Generic;
using System.Text;

namespace Twilio
{
    /// <summary>
    /// A set of boolean properties that indicate whether a phone number can receive calls or messages. Possible capabilities are Voice, SMS, and MMS with each having a value of either true or false.
    /// </summary>
    public class Capabilities
    {
        /// <summary>
        /// Set or set the Voice capability
        /// </summary>
        public bool Voice { get; set; }
        /// <summary>
        /// Set or set the SMS capability
        /// </summary>
        public bool SMS { get; set; }
        /// <summary>
        /// Set or set the MMS capability
        /// </summary>
        public bool MMS { get; set; }
    }
}
