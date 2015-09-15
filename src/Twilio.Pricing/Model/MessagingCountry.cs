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
    public class MessagingCountry : TwilioBase
    {

        /// <summary>
        /// The Absolute Url of the country.
        /// </summary>
        /// <value>Absolute country Url.</value>
        public string Url { get; set; }

        /// <summary>
        /// The full name of the country.
        /// </summary>
        /// <value>Country name.</value>
        public string Country { get; set; }

        /// <summary>
        /// The abbreviated country identifier according to ISO 3166-1 alpha-2,
        /// e.g. "US" for United States or "GB" for Great Britain.
        /// </summary>
        /// <value>Two-letter ISO country abbreviation.</value>
        public string IsoCountry { get; set; }

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
