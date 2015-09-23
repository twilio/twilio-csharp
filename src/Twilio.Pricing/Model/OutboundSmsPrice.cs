using System;
using System.Collections.Generic;

namespace Twilio.Pricing
{
    /// <summary>
    /// Represents pricing for outbound sms messages to the set of numbers
    /// matching the given prefixes.
    ///
    /// Pricing is per sms and reflects the Twilio pricing available at the
    /// time of the request.
    /// </summary>
    public class OutboundSmsPrice
    {
        /// <summary>
        /// Mobile country code.
        /// </summary>
        /// <value>mcc</value>
        public string Mcc { get; set; }

        /// <summary>
        /// Mobile network code.
        /// </summary>
        /// <value>mnc</value>
        public string Mnc { get; set; }

        /// <summary>
        /// Carrier.
        /// </summary>
        /// <value>carrier</value>
        public string Carrier { get; set; }

        /// <summary>
        /// A list of prices for an out bound sms.
        /// </summary>
        /// <value>List of outbound sms prices</value>
        public List<Price> Prices { get; set; }

    }
}
