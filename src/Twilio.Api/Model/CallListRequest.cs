using System;

namespace Twilio
{
	/// <summary>
	/// Search filter options for Call list request
	/// </summary>
	public class CallListRequest
	{
		/// <summary>
		/// Only show calls from this phone number.
		/// </summary>
		public string From { get; set; }
		/// <summary>
		/// Only show calls to this phone number.
		/// </summary>
		public string To { get; set; }
		/// <summary>
		/// Only show calls currently in this status. May be queued, ringing, in-progress, completed, failed, busy, or no-answer.
		/// </summary>
		public string Status { get; set; }
		/// <summary>
		/// Only show calls that started on this date
		/// </summary>
		public DateTime? StartTime { get; set; }
		/// <summary>
		/// Comparison type for start time
		/// </summary>
		public ComparisonType StartTimeComparison { get; set; }
		/// <summary>
		/// Only show calls that ended on this date
		/// </summary>
		public DateTime? EndTime { get; set; }
		/// <summary>
		/// Comparison type for end time
		/// </summary>
		public ComparisonType EndTimeComparison { get; set; }
		/// <summary>
		/// What page number to start retrieving results from
		/// </summary>
		[System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public int? PageNumber { get; set; }
		/// <summary>
		/// How many results to retrieve
		/// </summary>
		public int? Count { get; set; }
		/// <summary>
		/// Only show calls that belong to this parent call (e.g. Dial legs)
		/// </summary>
		public string ParentCallSid { get; set; }
	}
}
