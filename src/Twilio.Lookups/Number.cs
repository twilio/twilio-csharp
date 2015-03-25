using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio.Lookups
{
    /// <summary>
    /// A phone number result from the Twilio Lookups API.
    /// </summary>
    public class Number : TwilioBase
    {
        /// <summary>
        /// The ISO 3166-1 two-letter country code for the number.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// The phone number, in E.164 format (e.g. +15108675309).
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The phone number, in local format (e.g. "(510) 867-5309").
        /// </summary>
        public string NationalFormat { get; set; }

        /// <summary>
        /// Information about the number's carrier, if requested.
        /// </summary>
        public CarrierInfo Carrier { get; set; }


    }
}
