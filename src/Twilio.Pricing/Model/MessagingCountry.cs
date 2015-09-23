using System;
using System.Collections.Generic;

namespace Twilio.Pricing
{
    /// <summary>
    /// Represents Twilio Messaging pricing information for a single country.
    ///
    /// Price rates are per minute and represent current pricing at the time
    /// of the request both before and after applying discounts available to
    /// the requesting account.
    /// </summary>
    public class MessagingCountry : Country
    {
        /// <summary>
        /// The currency for the pricing information, e.g. "USD" for US Dollars.
        /// </summary>
        /// <value>Currency identifier</value>
        public string PriceUnit { get; set; }

        /// <summary>
        /// A list of outbound sms prices.
        /// </summary>
        /// <value>List of SMS outbound prices</value>
        public List<OutboundSmsPrice> OutboundSmsPrices { get; set; }

        /// <summary>
        /// A list of inbound sms prices.
        /// </summary>
        /// <value>List of SMS inbound prices</value>
        public List<Price> InboundSmsPrices { get; set; }
    }

}
