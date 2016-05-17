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
        /// Returns a list of Recordings, each representing a recording generated during the course of a phone call.
        /// The list includes paging information.
        /// Makes a GET request to the Recordings List resource.
        /// </summary>
        public IAsyncOperation<RecordingResult> ListRecordingsAsync()
        {
            return (IAsyncOperation<RecordingResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListRecordingsAsyncInternal(null,null,null,null));
        }

        /// <summary>
        /// Returns a filtered list of Recordings, each representing a recording generated during the course of a phone call.
        /// The list includes paging information.
        /// Makes a GET request to the Recordings List resource.
        /// </summary>
        /// <param name="callSid">(Optional) The CallSid to retrieve recordings for</param>
        /// <param name="dateCreated">(Optional) The date the recording was created (GMT)</param>
        /// <param name="pageNumber">The page to start retrieving results from</param>
        /// <param name="count">How many results to retrieve</param>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public IAsyncOperation<RecordingResult> ListRecordingsAsync(string callSid, DateTimeOffset? dateCreated, int? pageNumber, int? count)
        {
            return (IAsyncOperation<RecordingResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListRecordingsAsyncInternal(callSid, dateCreated, pageNumber, count));
        }
        private async Task<RecordingResult> ListRecordingsAsyncInternal(string callSid, DateTimeOffset? dateCreated, int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Recordings.json";

            if (callSid.HasValue()) request.AddParameter("CallSid", callSid);
            if (dateCreated.HasValue) request.AddParameter("DateCreated", dateCreated.Value.ToString("yyyy-MM-dd"));
            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            var result = await ExecuteAsync(request, typeof(RecordingResult));
            return (RecordingResult)result;
        }

        /// <summary>
        /// Retrieve the details for the specified recording instance.
        /// Makes a GET request to a Recording Instance resource.
        /// </summary>
        /// <param name="recordingSid">The Sid of the recording to retrieve</param>
        public IAsyncOperation<Recording> GetRecordingAsync(string recordingSid)
        {
            return (IAsyncOperation<Recording>)AsyncInfo.Run((System.Threading.CancellationToken ct) => GetRecordingAsyncInternal(recordingSid));
        }
        private async Task<Recording> GetRecordingAsyncInternal(string recordingSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Recordings/{RecordingSid}.json";

            request.AddParameter("RecordingSid", recordingSid, ParameterType.UrlSegment);

            var result = await ExecuteAsync(request, typeof(Recording));
            return (Recording)result;

        }

        /// <summary>
        /// Delete the specified recording instance. Makes a DELETE request to a Recording Instance resource.
        /// </summary>
        /// <param name="recordingSid">The Sid of the recording to delete</param>
        public IAsyncOperation<DeleteStatus> DeleteRecordingAsync(string recordingSid)
        {
            return (IAsyncOperation<DeleteStatus>)AsyncInfo.Run((System.Threading.CancellationToken ct) => DeleteRecordingAsyncInternal(recordingSid));
        }
        private async Task<DeleteStatus> DeleteRecordingAsyncInternal(string recordingSid)
        {
            var request = new RestRequest();
            request.Method = Method.DELETE;
            request.Resource = "Accounts/{AccountSid}/Recordings/{RecordingSid}.json";

            request.AddParameter("RecordingSid", recordingSid, ParameterType.UrlSegment);

            var response = (RestResponse)await ExecuteAsync(request);
            return response.StatusCode == (int)System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }

        /// <summary>
        /// Retrieves the transcription text for the specified recording, if it was transcribed.
        /// Makes a GET request to a Recording Instance resource.
        /// </summary>
        /// <param name="recordingSid">The Sid of the recording to retreive the transcription for</param>
        public IAsyncOperation<string> GetRecordingTextAsync(string recordingSid)
        {
            return (IAsyncOperation<string>)AsyncInfo.Run((System.Threading.CancellationToken ct) => GetRecordingTextAsyncInternal(recordingSid));
        }
        private async Task<string> GetRecordingTextAsyncInternal(string recordingSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Recordings/{RecordingSid}.txt";
            request.AddParameter("RecordingSid", recordingSid, ParameterType.UrlSegment);

            var result = await ExecuteAsync(request, typeof(string));
            return (string)result;
        }
    }
}
