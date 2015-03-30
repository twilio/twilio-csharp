using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio.Lookups
{
    public class CarrierInfo
    {
        /// <summary>
        /// The mobile country code of the carrier, for mobile numbers only.
        /// </summary>
        public string MobileCountryCode { get; set; }

        /// <summary>
        /// The mobile network code of the carrier, for mobile numbers only.
        /// </summary>
        public string MobileNetworkCode { get; set; }

        /// <summary>
        /// The name of the carrier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The type of the number.
        /// One of "landline", "mobile", or "voip".
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The error code for the carrier lookup, if it failed.
        /// </summary>
        public int? ErrorCode { get; set; }
    }
}
