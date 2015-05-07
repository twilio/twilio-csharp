using System;

namespace Twilio
{
    /// <summary>
    /// Pricing information for a single type of Twilio Number.
    /// </summary>
    public class PhoneNumberPrice
    {
        /// <summary>
        /// The type of number this price applies to.
        /// One of "local", "mobile", "national", or "toll_free".
        /// </summary>
        /// <value>Number type.</value>
        public string NumberType { get; set; }
        /// <summary>
        /// The base price per month for this type of number, before
        /// any discounts have been applied.
        /// </summary>
        /// <value>Undiscounted monthly price for this number type.</value>
        public decimal BasePrice { get; set; }
        /// <summary>
        /// Price per month for this type of number after applying
        /// any discounts available for your account.
        /// </summary>
        /// <value>Discounted monthly number price.</value>
        public decimal CurrentPrice { get; set; }
    }
}

