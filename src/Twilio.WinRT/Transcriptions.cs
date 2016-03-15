using System;
using RestRT;
using RestRT.Extensions;
using Windows.Foundation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace Twilio
{
    public partial class TwilioRestClient
    {
        /// <summary>
        /// Returns a set of Transcriptions that includes paging information, sorted by 'DateUpdated', with most recent transcripts first.
        /// Makes a GET request to the Transcriptions List resource.
        /// </summary>
        public IAsyncOperation<TranscriptionResult> ListTranscriptionsAsync()
        {
            return (IAsyncOperation<TranscriptionResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListTranscriptionsAsyncInternal(null,null));
        }

        /// <summary>
        /// Returns a paged set of Transcriptions that includes paging information, sorted by 'DateUpdated', with most recent transcripts first.
        /// Makes a GET request to the Transcriptions List resource.
        /// </summary>
        /// <param name="pageNumber">The page to start retrieving results from</param>
        /// <param name="count">The number of results to retrieve</param>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public IAsyncOperation<TranscriptionResult> ListTranscriptionsAsync(int? pageNumber, int? count)
        {
            return (IAsyncOperation<TranscriptionResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListTranscriptionsAsyncInternal(pageNumber, count));
        }
        private async Task<TranscriptionResult> ListTranscriptionsAsyncInternal(int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Transcriptions.json";
            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            var result = await ExecuteAsync(request, typeof(TranscriptionResult));
            return (TranscriptionResult)result;

        }

        /// <summary>
        /// Returns a set of Transcriptions for a specific recording that includes paging information, sorted by 'DateUpdated',
        /// with most recent transcripts first. Makes a GET request to a Recording Transcriptions List resource.
        /// </summary>
        /// <param name="recordingSid">The Sid of the recording to retrieve transcriptions for</param>
        /// <param name="pageNumber">The page to start retrieving results from</param>
        /// <param name="count">The number of results to retrieve</param>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public IAsyncOperation<TranscriptionResult> ListTranscriptionsAsync(string recordingSid, int? pageNumber, int? count)
        {
            return (IAsyncOperation<TranscriptionResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListTranscriptionsAsyncInternal(recordingSid, pageNumber, count));
        }
        private async Task<TranscriptionResult> ListTranscriptionsAsyncInternal(string recordingSid, int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Recordings/{RecordingSid}/Transcriptions.json";
            request.AddUrlSegment("RecordingSid", recordingSid);

            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            var result = await ExecuteAsync(request, typeof(TranscriptionResult));
            return (TranscriptionResult)result;

        }

        /// <summary>
        /// Retrieve the details of a single transcription. 
        /// Makes a GET request to a Transcription Instance resource.
        /// </summary>
        /// <param name="transcriptionSid">The Sid of the transcription to retrieve</param>
        public IAsyncOperation<Transcription> GetTranscriptionAsync(string transcriptionSid)
        {
            return (IAsyncOperation<Transcription>)AsyncInfo.Run((System.Threading.CancellationToken ct) => GetTranscriptionAsyncInternal(transcriptionSid));
        }
        private async Task<Transcription> GetTranscriptionAsyncInternal(string transcriptionSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Transcriptions/{TranscriptionSid}.json";
            request.AddParameter("TranscriptionSid", transcriptionSid, ParameterType.UrlSegment);

            var result = await ExecuteAsync(request, typeof(Transcription));
            return (Transcription)result;

        }

        /// <summary>
        /// Retrieve the text of a single transcription.
        /// Makes a GET request to a Transcription Instance resource.
        /// </summary>
        /// <param name="transcriptionSid">The Sid of the transcription to retrieve</param>
        public IAsyncOperation<string> GetTranscriptionTextAsync(string transcriptionSid)
        {
            return (IAsyncOperation<string>)AsyncInfo.Run((System.Threading.CancellationToken ct) => GetTranscriptionTextAsyncInternal(transcriptionSid));
        }
        private async Task<string> GetTranscriptionTextAsyncInternal(string transcriptionSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Transcriptions/{TranscriptionSid}.txt.json";
            request.AddParameter("TranscriptionSid", transcriptionSid, ParameterType.UrlSegment);

            var response = (RestResponse)await ExecuteAsync(request);
            return response.Content;
        }
    }
}