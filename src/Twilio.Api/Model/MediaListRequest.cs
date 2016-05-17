using System;

namespace Twilio
{
    /// <summary>
    /// Search filter options for a list of Media
    /// </summary>
    public class MediaListRequest
    {

        /// <summary>
        /// Only show media with a parent Message Sid matching this sid.
        /// </summary>
        public string ParentSid { get; set; }
        /// <summary>
        /// Only show media that were created on this date
        /// </summary>
        public DateTime? DateCreated { get; set; }
        /// <summary>
        /// Comparison type for created date
        /// </summary>
        public ComparisonType DateCreatedComparison { get; set; }

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

