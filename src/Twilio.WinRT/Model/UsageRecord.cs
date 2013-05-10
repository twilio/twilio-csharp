using System;

namespace Twilio
{
    /// <summary>
    /// The UsageRecords resource provides usage data during any time period and by any usage category
    /// </summary>
    public sealed class UsageRecord //: TwilioBase
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
        /// The Account that accrued the usage
        /// </summary>
        public string AccountSid { get; set; }

        /// <summary>
        /// The category of usage. See Usage Categories.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// A human-readable description of the usage category
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// The first date for which usage is included in this UsageRecord
        /// </summary>
        public string StartDate { get; set; }
        
        /// <summary>
        /// The last date for which usage is included in this UsageRecord
        /// </summary>
        public string EndDate { get; set; }
        
        /// <summary>
        /// The number of usage events (e.g. the number of calls)
        /// </summary>
        public double Count { get; set; }
        
        /// <summary>
        /// The units in which Count is measured. For example calls for calls, messages for SMS
        /// </summary>
        public string CountUnits { get; set; }
        
        /// <summary>
        /// The amount of usage (e.g. the number of call minutes).
        /// </summary>
        /// <remarks>This is frequently the same as Count, but may be different for certain usage categories like calls, where Count represents the number of calls and Usage represents the number of minutes</remarks>
        public double Usage { get; set; }

        /// <summary>
        /// The units in which Usage is measured. For example minutes for calls, messages for SMS
        /// </summary>
        public string UsageUnits { get; set; }
        
        /// <summary>
        /// The total price of the usage, in USD
        /// </summary>
        public double Price { get; set; }
        
        /// <summary>
        /// The currency in which Price is measured. Always USD
        /// </summary>
        public string PriceUnits { get; set; }       
    }
}
