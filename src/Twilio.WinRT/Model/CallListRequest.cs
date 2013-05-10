using System;

namespace Twilio
{
	/// <summary>
	/// Search filter options for Call list request
	/// </summary>
	public sealed class CallListRequest
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
		public DateTimeOffset? StartTime { get; set; }
		/// <summary>
		/// Comparison type for start time
		/// </summary>
		public ComparisonType StartTimeComparison { get; set; }
		/// <summary>
		/// Only show calls that ended on this date
		/// </summary>
		public DateTimeOffset? EndTime { get; set; }
		/// <summary>
		/// Comparison type for end time
		/// </summary>
		public ComparisonType EndTimeComparison { get; set; }
		/// <summary>
		/// What page number to start retrieving results from
		/// </summary>
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