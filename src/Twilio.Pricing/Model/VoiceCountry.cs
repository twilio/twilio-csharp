using System;
using System.Collections.Generic;

namespace Twilio.Pricing
{
    /// <summary>
    /// Represents Twilio Voice pricing information for a single country.
    /// 
    /// Price rates are per minute and represent current pricing at the time
    /// of the request both before and after applying discounts available to
    /// the requesting account.
    /// </summary>
    public class VoiceCountry : TwilioBase
    {
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
        /// A list of objects representing per-minute prices for inbound calls to Twilio
        /// numbers in this country.
        /// 
        /// Prices are set per type of number (e.g. local, mobile).
        /// </summary>
        /// <value>Pricing information for inbound calls, by number type.</value>
        public List<InboundCallPrice> InboundCallPrices { get; set; }
        /// <summary>
        /// A list of objects representing per-minute prices for outbound calls, based
        /// on prefixes of dialed numbers.
        /// 
        /// To find the price applying to a specific number, given this list:
        /// - Find the longest prefix that matches the called number (each OutboundPrefixPrice
        /// object has one or more prefixes)
        /// - The matching OutboundPrefixPrice object's price rates will apply.
        /// </summary>
        /// <value>List of objects mapping number prefixes to call prices.</value>
        public List<OutboundPrefixPrice> OutboundPrefixPrices { get; set; }
    }

}

