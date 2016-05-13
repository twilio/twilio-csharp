using System;
using Newtonsoft.Json;

namespace Twilio.Types
{
	public class FeedbackIssue
	{
		[JsonProperty("count")]
		private int count;
		[JsonProperty("description")]
		private string description;
		[JsonProperty("percentage_of_total_calls")]
		private string percentageOfTotalCalls;

		public FeedbackIssue(int count, string description, string percentageOfTotalCalls)
		{
			this.count = count;
			this.description = description;
			this.percentageOfTotalCalls = percentageOfTotalCalls;
		}

		public int GetCount() {
			return count;
		}

		public string GetDescription() {
			return description;
		}

		public string GetPercentageOfTotalCalls() {
			return percentageOfTotalCalls;
		}
	}
}

