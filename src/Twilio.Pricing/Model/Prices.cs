using System;
using System.Collections.Generic;

namespace Twilio.Pricing
{
    /// <summary>
    /// Represents Sms Price.
    /// </summary>
    public class Price : TwilioBase
    {
        /// <summary>
        /// The number type.
        /// </summary>
        /// <value>number type</value>
        public string NumberType { get; set; }

        /// <summary>
        /// Base Price of SMS.
        /// </summary>
        /// <value>sms base price</value>
        public string BasePrice { get; set; }

        /// <summary>
        /// Current price of SMS.
        /// </summary>
        /// <value>sms current price</value>
        public string CurrentPrice { get; set; }
}
