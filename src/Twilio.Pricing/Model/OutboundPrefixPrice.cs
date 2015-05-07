using System;
using System.Collections.Generic;

namespace Twilio.Pricing
{
    /// <summary>
    /// Represents pricing for outbound calls to the set of numbers matching
    /// the given prefixes.
    /// 
    /// Pricing is per minute and reflects the Twilio pricing available at the
    /// time of the request.
    /// </summary>
    public class OutboundPrefixPrice
    {
        /// <summary>
        /// A list of one or more prefixes for which this pricing applies.
        /// 
        /// When calculating call pricing, the longest prefix that matches the
        /// called number will have its corresponding price applied.
        /// </summary>
        /// <value>List of number prefixes this price applies to.</value>
        public List<string> PrefixList { get; set; }

        /// <summary>
        /// A human-readable description of this pricing group.
        /// </summary>
        /// <value>Price group description.</value>
        public string FriendlyName { get; set; }

        /// <summary>
        /// Price per minute for outbound calls to this set of prefixes,
        /// before any discounts have been applied.
        /// </summary>
        /// <value>Undiscounted price/minute for outbound calls.</value>
        public decimal BasePrice { get; set; }

        /// <summary>
        /// Price per minute for outbound calls to this set of prefixes,
        /// after applying available discounts for your account.
        /// </summary>
        /// <value>Discounted outbound price per minute.</value>
        public decimal CurrentPrice { get; set; }
    }
}