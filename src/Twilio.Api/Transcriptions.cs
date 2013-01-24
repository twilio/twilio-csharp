using System;
using RestSharp;
using RestSharp.Extensions;

namespace Twilio
{
	public partial class TwilioRestClient
	{
		/// <summary>
		/// Returns a set of Transcriptions that includes paging information.
		/// Makes a GET request to the Transcriptions List resource.
		/// </summary>
		public TranscriptionResult ListTranscriptions()
		{
			return ListTranscriptions(null, null);
		}

		/// <summary>
		/// Returns a paged set of Transcriptions that includes paging information.
		/// Makes a GET request to the Transcriptions List resource.
		/// </summary>
		/// <param name="pageNumber">The page to start retrieving results from</param>
		/// <param name="count">The number of results to retrieve</param>
		public TranscriptionResult ListTranscriptions(int? pageNumber, int? count)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Transcriptions.json";
			if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
			if (count.HasValue) request.AddParameter("PageSize", count.Value);

			return Execute<TranscriptionResult>(request);
		}

		/// <summary>
		/// Returns a set of Transcriptions for a specific recording that includes paging information.
		/// Makes a GET request to a Recording Transcriptions List resource.
		/// </summary>
		/// <param name="recordingSid">The Sid of the recording to retrieve transcriptions for</param>
		/// <param name="pageNumber">The page to start retrieving results from</param>
		/// <param name="count">The number of results to retrieve</param>
		public TranscriptionResult ListTranscriptions(string recordingSid, int? pageNumber, int? count)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Recordings/{RecordingSid}/Transcriptions.json";
			request.AddUrlSegment("RecordingSid", recordingSid);

			if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
			if (count.HasValue) request.AddParameter("PageSize", count.Value);

			return Execute<TranscriptionResult>(request);
		}

		/// <summary>
		/// Retrieve the details of a single transcription. 
		/// Makes a GET request to a Transcription Instance resource.
		/// </summary>
		/// <param name="transcriptionSid">The Sid of the transcription to retrieve</param>
		public Transcription GetTranscription(string transcriptionSid)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Transcriptions/{TranscriptionSid}.json";
						request.AddParameter("TranscriptionSid", transcriptionSid, ParameterType.UrlSegment);

			return Execute<Transcription>(request);
		}

		/// <summary>
		/// Retrieve the text of a single transcription.
		/// Makes a GET request to a Transcription Instance resource.
		/// </summary>
		/// <param name="transcriptionSid">The Sid of the transcription to retrieve</param>
		public string GetTranscriptionText(string transcriptionSid)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Transcriptions/{TranscriptionSid}.txt.json";
			request.AddParameter("TranscriptionSid", transcriptionSid, ParameterType.UrlSegment);

			var response = Execute(request);
			return response.Content;
		}
	}
}