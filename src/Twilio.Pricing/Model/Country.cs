using System;
using System.Collections.Generic;

namespace Twilio.Pricing
{
    /// <summary>
    /// Represents Twilio Messaging pricing country.
    /// </summary>
    public class Country : TwilioBase
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
        /// The Absolute Url of the country.
        /// </summary>
        /// <value>Absolute country Url.</value>
        public string Url { get; set; }
    }

}
