using System;
using RestSharp;
using RestSharp.Extensions;

namespace Twilio
{
	public partial class TwilioRestClient
	{
		/// <summary>
		/// Returns a set of Transcriptions that includes paging information, sorted by 'DateUpdated', with most recent transcripts first.
		/// </summary>
		/// <param name="callback">The method to call upon the completion of the request</param>
		public virtual void ListTranscriptions(Action<TranscriptionResult> callback)
		{
			ListTranscriptions(null, null, null, callback);
		}

		/// <summary>
		/// Returns a paged set of Transcriptions that includes paging information, sorted by 'DateUpdated', with most recent transcripts first.
		/// </summary>
		/// <param name="pageNumber">The page to start retrieving results from</param>
		/// <param name="count">The number of results to retrieve</param>
		/// <param name="callback">The method to call upon the completion of the request</param>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual void ListTranscriptions(int? pageNumber, int? count, Action<TranscriptionResult> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Transcriptions.json";
			if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
			if (count.HasValue) request.AddParameter("PageSize", count.Value);

			ExecuteAsync<TranscriptionResult>(request, (response) => callback(response));
		}

		/// <summary>
		/// Returns a set of Transcriptions for a specific recording that includes paging information, sorted by 'DateUpdated', with most recent transcripts first.
		/// </summary>
		/// <param name="recordingSid">The Sid of the recording to retrieve transcriptions for</param>
		/// <param name="pageNumber">The page to start retrieving results from</param>
		/// <param name="count">The number of results to retrieve</param>
		/// <param name="callback">Method to call upon completion of request</param>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual void ListTranscriptions(string recordingSid, int? pageNumber, int? count, Action<TranscriptionResult> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Recordings/{RecordingSid}/Transcriptions.json";
			request.AddUrlSegment("RecordingSid", recordingSid);

			if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
			if (count.HasValue) request.AddParameter("PageSize", count.Value);

			ExecuteAsync<TranscriptionResult>(request, (response) => callback(response));
		}

		/// <summary>
		/// Retrieve the details of a single transcription
		/// </summary>
		/// <param name="transcriptionSid">The Sid of the transcription to retrieve</param>
		/// <param name="callback">Method to call upon completion of request</param>
        public virtual void GetTranscription(string transcriptionSid, Action<Transcription> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Transcriptions/{TranscriptionSid}.json";
						request.AddParameter("TranscriptionSid", transcriptionSid, ParameterType.UrlSegment);

			ExecuteAsync<Transcription>(request, (response) => callback(response));
		}

		/// <summary>
		/// Retrieve the text of a single transcription
		/// </summary>
		/// <param name="transcriptionSid">The Sid of the transcription to retrieve</param>
		/// <param name="callback">Method to call upon completion of the request</param>
        public virtual void GetTranscriptionText(string transcriptionSid, Action<string> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Transcriptions/{TranscriptionSid}.txt.json";
			request.AddParameter("TranscriptionSid", transcriptionSid, ParameterType.UrlSegment);

			ExecuteAsync(request, (response) => callback(response.Content));
		}
	}
}
