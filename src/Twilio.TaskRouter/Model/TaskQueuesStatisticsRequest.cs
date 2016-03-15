using System;

namespace Twilio.TaskRouter
{
    /// <summary>
    /// Filtering and time-interval options for listing TaskQueue statistics.
    /// </summary>
    public class TaskQueuesStatisticsRequest : StatisticsRequest
    {
        /// <summary>
        /// Filter statistics results by TaskQueue FriendlyName
        /// </summary>
        /// <value>TaskQueue name to filter results on</value>
        public string FriendlyName { get; set; }

        /// <summary>
        /// What page number to start retrieving results from.
        /// </summary>
        /// <value>The page number.</value>
		[System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
        public int? PageNumber { get; set; }

        /// <summary>
        /// Number of results to retrieve per page.
        /// </summary>
        /// <value>Result page size.</value>
        public int? Count { get; set; }

        /// <summary>
        /// Get statistics for queues before this sid.
        /// </summary>
        public string BeforeSid { get; set; }

        /// <summary>
        /// Get statistics for queues after this sid.
        /// </summary>
        public string AfterSid { get; set; }

    }
}

