using System.Collections.Generic;
using Newtonsoft.Json;

namespace Twilio.Types
{
    /// <summary>
    /// POCO to represent an outbound SMS price
    /// </summary>
    public class OutboundSmsPrice
    {
        /// <summary>
        /// SMS mcc
        /// </summary>
        [JsonProperty("mcc")]
        public string Mcc { get; }

        /// <summary>
        /// SMS mnc
        /// </summary>
        [JsonProperty("mnc")]
        public string Mnc { get; }

        /// <summary>
        /// Carrier name
        /// </summary>
        [JsonProperty("carrier")]
        public string Carrier { get; }

        /// <summary>
        /// List of prices
        /// </summary>
        [JsonProperty("prices")]
        public List<InboundSmsPrice> Prices { get; }

        /// <summary>
        /// Create a new OutboundSmsPrice
        /// </summary>
        /// <param name="mcc">SMS mcc</param>
        /// <param name="mnc">SMS mnc</param>
        /// <param name="carrier">Carrier name</param>
        /// <param name="prices">List of prices</param>
        public OutboundSmsPrice (
            string mcc,
            string mnc,
            string carrier,
            List<InboundSmsPrice> prices
        )
        {
            Mcc = mcc;
            Mnc = mnc;
            Carrier = carrier;
            Prices = prices;
        }
    }
}

