namespace Twilio
{
    /// <summary>
    /// Available options when creating new Usage Triggers via the API
    /// </summary>
    public sealed class UsageTriggerOptions
    {
        /// <summary>
        /// The trigger will watch this usage category
        /// </summary>
        public string UsageCategory { get; set; }

        /// <summary>
        /// The trigger will fire when usage reaches this value
        /// </summary>
        public double TriggerValue { get; set; }

        /// <summary>
        /// Twilio will make a request to this url when the trigger fires
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// A human readable description of the new trigger. Maximum 64 characters
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// The field in the UsageRecord that will fire the trigger. One of 'count', 'usage', or 'price' as described in the UsageRecords documentation. The default is 'usage'.
        /// </summary>        
        public string TriggerBy { get; set; }

        /// <summary>
        /// The interval the trigger will count over. Must be one of: 'daily', 'monthly', or 'yearly'. Omit this to create a non-recurring trigger.
        /// </summary>
        public string Recurring { get; set; }

        /// <summary>
        /// Twilio will use this HTTP method when making a request to the CallbackUrl. GET or POST. The default is POST.
        /// </summary>
        public string CallbackMethod { get; set; }
    }
}
