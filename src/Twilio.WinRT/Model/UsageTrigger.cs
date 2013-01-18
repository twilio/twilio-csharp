using System;

namespace Twilio
{
    /// <summary>
    /// Usage triggers are webhooks that notify your application of usage thresholds
    /// </summary>
    public sealed class UsageTrigger //: TwilioBase
    {
        /// <summary>
        /// Exception encountered during API request
        /// </summary>
        public RestException RestException { get; set; }
        /// <summary>
        /// The URI for this resource, relative to https://api.twilio.com
        /// </summary>
        public Uri Uri { get; set; }


        /// <summary>
        /// The trigger's unique Sid
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// The date the trigger was created
        /// </summary>
        public DateTimeOffset DateCreated { get; set; }

        /// <summary>
        /// The date the trigger was last updated
        /// </summary>
        public DateTimeOffset DateUpdated { get; set; }

        /// <summary>
        /// The account this trigger monitors
        /// </summary>
        public string AccountSid { get; set; }

        /// <summary>
        /// A user-specified, human-readable name for the trigger
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// How this trigger recurs. Empty for non-recurring triggers, or one of daily, monthly, or yearly. A trigger will only fire once during each recurring period
        /// </summary>
        public string Recurring { get; set; }

        /// <summary>
        /// The usage category the trigger watches. One of the supported usage categories
        /// </summary>
        public string UsageCategory { get; set; }

        /// <summary>
        /// The field in the UsageRecord that fires the trigger. One of count, usage, or price, as described in the UsageRecords documentation
        /// </summary>
        public string TriggerBy { get; set; }

        /// <summary>
        /// The value at which the trigger will fire. Must be a positive numeric value
        /// </summary>
        public double TriggerValue { get; set; }

        /// <summary>
        /// The current value of the field the trigger is watching
        /// </summary>
        public double CurrentValue { get; set; }

        /// <summary>
        /// The URI of the UsageRecord this trigger is watching
        /// </summary>
        public string UsageRecordUri { get; set; }
        
        /// <summary>
        /// Twilio will make a request to this url when the trigger fires
        /// </summary>
        public string CallbackUrl { get; set; }

        /// <summary>
        /// The HTTP method Twilio will use when making a request to the CallbackUrl. GET or POST
        /// </summary>
        public string CallbackMethod { get; set; }

        /// <summary>
        /// The date the trigger was last fired
        /// </summary>
        public DateTimeOffset? DateFired { get; set; }
    }
}
