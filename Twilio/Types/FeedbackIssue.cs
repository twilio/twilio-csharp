using Newtonsoft.Json;

namespace Twilio.Types
{
	public class FeedbackIssue
	{
		[JsonProperty("count")]
		public int Count { get; }
		[JsonProperty("description")]
		public string Description { get; }
		[JsonProperty("percentage_of_total_calls")]
		public string PercentageOfTotalCalls { get; }

		public FeedbackIssue(int count, string description, string percentageOfTotalCalls)
		{
			Count = count;
			Description = description;
			PercentageOfTotalCalls = percentageOfTotalCalls;
		}
	}
}

