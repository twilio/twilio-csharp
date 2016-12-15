namespace Twilio.Pricing
{
    /// <summary>
    /// Represents Sms Price.
    /// </summary>
    public class Price : TwilioBase
    {
        /// <summary>
        /// The number type.
        /// </summary>
        /// <value>number type</value>
        public string NumberType { get; set; }

        /// <summary>
        /// Base Price of SMS.
        /// </summary>
        /// <value>SMS base price</value>
        public string BasePrice { get; set; }

        /// <summary>
        /// Current price of SMS.
        /// </summary>
        /// <value>SMS current price</value>
        public string CurrentPrice { get; set; }
    }
}