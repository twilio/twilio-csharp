using System;
using System.Collections.Generic;

namespace Twilio.Pricing
{
    /// <summary>
    /// Pricing information for Twilio Phone Numbers in a specific country.
    /// 
    /// Prices are per month.
    /// </summary>
    public class PhoneNumberCountry : TwilioBase
    {
        /// <summary>
        /// The name of the country these prices apply to.
        /// </summary>
        /// <value>Country name.</value>
        public string Country { get; set; }
        /// <summary>
        /// The abbreviated identifier for this country.
        /// </summary>
        /// <value>ISO 3166-1 alpha-2 country abbreviation</value>
        public string IsoCountry { get; set; }
        /// <summary>
        /// Currency type for this pricing information, e.g. "USD" for US Dollars.
        /// </summary>
        /// <value>Currency identifier.</value>
        public string PriceUnit { get; set; }
        /// <summary>
        /// A list of objects with pricing information for each type of 
        /// Twilio Number (e.g. Local or Mobile) available in this country.
        /// </summary>
        /// <value>List of phone number prices.</value>
        public List<PhoneNumberPrice> PhoneNumberPrices { get; set; }
    }
}