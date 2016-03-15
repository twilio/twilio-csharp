using System;

namespace Twilio
{
    /// <summary>
    /// Search filter options for a list of Messages
    /// </summary>
    public class MessageListRequest
    {

        /// <summary>
        /// Only show messages from this phone number.
        /// </summary>
        public string From { get; set; }
        /// <summary>
        /// Only show messages to this phone number.
        /// </summary>
        public string To { get; set; }
        /// <summary>
        /// Only show messages that were sent on this date
        /// </summary>
        public DateTime? DateSent { get; set; }
        /// <summary>
        /// Comparison type for sent date
        /// </summary>
        public ComparisonType DateSentComparison { get; set; }

        /// <summary>
        /// What page number to start retrieving results from
        /// </summary>
		[System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
        public int? PageNumber { get; set; }
        /// <summary>
        /// How many results to retrieve
        /// </summary>
        public int? Count { get; set; }
    }
}
