using System;
using RestSharp;
using RestSharp.Extensions;

namespace Twilio
{
	public partial class TwilioRestClient
	{
		/// <summary>
		/// Returns a list of Recordings, each representing a recording generated during the course of a phone call. The list includes paging information.
		/// </summary>
		/// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListRecordings(Action<RecordingResult> callback)
		{
			ListRecordings(null, null, null, null, callback);
		}

		/// <summary>
		/// Returns a filtered list of Recordings, each representing a recording generated during the course of a phone call. The list includes paging information.
		/// </summary>
		/// <param name="callSid">(Optional) The CallSid to retrieve recordings for</param>
		/// <param name="dateCreated">(Optional) The date the recording was created (GMT)</param>
		/// <param name="pageNumber">The page to start retrieving results from</param>
		/// <param name="count">How many results to retrieve</param>
		/// <param name="callback">Method to call upon successful completion</param>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual void ListRecordings(string callSid, DateTime? dateCreated, int? pageNumber, int? count, Action<RecordingResult> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Recordings.json";

			if (callSid.HasValue()) request.AddParameter("CallSid", callSid);
			if (dateCreated.HasValue) request.AddParameter("DateCreated", dateCreated.Value.ToString("yyyy-MM-dd"));
			if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
			if (count.HasValue) request.AddParameter("PageSize", count.Value);

			ExecuteAsync<RecordingResult>(request, (response) => callback(response));
		}

		/// <summary>
		/// Retrieve the details for the specified recording instance
		/// </summary>
		/// <param name="recordingSid">The Sid of the recording to retrieve</param>
		/// <param name="callback">Method to call upon successful completion</param>
        public virtual void GetRecording(string recordingSid, Action<Recording> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Recordings/{RecordingSid}.json";

			request.AddParameter("RecordingSid", recordingSid, ParameterType.UrlSegment);

			ExecuteAsync<Recording>(request, (response) => callback(response));
		}

		/// <summary>
		/// Delete the specified recording instance
		/// </summary>
		/// <param name="recordingSid">The Sid of the recording to delete</param>
		/// <param name="callback">Method to call upon successful completion</param>
        public virtual void DeleteRecording(string recordingSid, Action<DeleteStatus> callback)
		{
			var request = new RestRequest(Method.DELETE);
			request.Resource = "Accounts/{AccountSid}/Recordings/{RecordingSid}.json";

			request.AddParameter("RecordingSid", recordingSid, ParameterType.UrlSegment);

			ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
		}

		/// <summary>
		/// Retrieves the transcription text for the specified recording, if it was transcribed
		/// </summary>
		/// <param name="recordingSid">The Sid of the recording to retreive the transcription for</param>
		/// <param name="callback">Method to call upon successful completion</param>
        public virtual void GetRecordingText(string recordingSid, Action<string> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Recordings/{RecordingSid}.txt";
			request.AddParameter("RecordingSid", recordingSid, ParameterType.UrlSegment);

			ExecuteAsync(request, (response) => callback(response.Content));
		}
	}
}
