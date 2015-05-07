using System;

namespace Twilio.Pricing
{
    /// <summary>
    /// Pricing information for inbound calls to a specific type of Twilio
    /// phone number.
    /// 
    /// Prices are per minute and reflect currently-available Twilio pricing
    /// information.
    /// </summary>
    public class InboundCallPrice
    {
        /// <summary>
        /// A string representing the type of number this pricing applies to.
        /// One of "mobile", "local", "national", or "toll_free".
        /// </summary>
        /// <value>Number type identifier.</value>
        public string NumberType { get; set; }

        /// <summary>
        /// The price per minute for inbound calls to this type of Twilio
        /// number, before any discounts have been applied.
        /// </summary>
        /// <value>Call price/minute without discounts.</value>
        public decimal BasePrice { get; set; }

        /// <summary>
        /// The price per minute for inbound calls to this type of Twilio
        /// number after applying any discounts available for your account.
        /// </summary>
        /// <value>Discounted call price/minute.</value>
        public decimal CurrentPrice { get; set; }
    }
}