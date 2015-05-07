using System;

namespace Twilio.Pricing
{
    /// <summary>
    /// Pricing for Twilio Voice calls to/from a specific phone number.
    /// 
    /// Prices are per minute.
    /// </summary>
    public class VoiceNumber : TwilioBase
    {
        /// <summary>
        /// The E.164-formatted phone number these prices apply to.
        /// </summary>
        /// <value>Phone number.</value>
        public string Number { get; set; }

        /// <summary>
        /// The country where this number is located.
        /// </summary>
        /// <value>Number's country.</value>
        public string Country { get; set; }

        /// <summary>
        /// Abbreviated country where this number is located, in ISO 3166-1
        /// alpha-2 format.
        /// </summary>
        /// <value>Abbreviated country identifier</value>
        public string IsoCountry { get; set; }

        /// <summary>
        /// Currency type for this pricing information, e.g. "USD" for "US Dollars"
        /// </summary>
        /// <value>Currency type.</value>
        public string PriceUnit { get; set; }

        /// <summary>
        /// Price information for outbound calls to this number.
        /// </summary>
        /// <value>Price info for calls to this number.</value>
        public NumberCallPrice OutboundCallPrice { get; set; }

        /// <summary>
        /// Price information for inbound calls to this number,
        /// or null if it is not a Twilio-hosted number.
        /// </summary>
        /// <value>Inbound call pricing information or null</value>
        public NumberCallPrice InboundCallPrice { get; set; }
    }
}