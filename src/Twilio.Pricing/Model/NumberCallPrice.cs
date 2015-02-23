using System;

namespace Twilio.Pricing
{
    /// <summary>
    /// Pricing information for a single type of Twilio Number.
    /// 
    /// Prices are per month and reflect current Twilio pricing.
    /// </summary>
    public class NumberCallPrice
    {
        /// <summary>
        /// The type of number this price applies to.
        /// Either "local", "mobile", "national", or "toll_free".
        /// </summary>
        /// <value>Number type for this pricing information.</value>
        public string NumberType { get; set; }

        /// <summary>
        /// The base price per month for this type of number, before
        /// any discounts have been applied.
        /// </summary>
        /// <value>Undiscounted monthly price for this type of phone number.</value>
        public decimal BasePrice { get; set; }

        /// <summary>
        /// The price per month for this type of number after applying any
        /// discounts available for your account.
        /// </summary>
        /// <value>Discounted monthly phone number price.</value>
        public decimal CurrentPrice { get; set; }
    }
}