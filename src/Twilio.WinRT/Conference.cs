using RestRT;
using RestRT.Extensions;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Twilio
{
    public partial class TwilioRestClient
    {
        /// <summary>
        /// Returns a list of conferences within an account.
        /// The list includes paging information and is sorted by DateUpdated, with most recent conferences first.
        /// Makes a GET request to the Conferences List resource.
        /// </summary>
        public IAsyncOperation<ConferenceResult> ListConferencesAsync()
        {
            return (IAsyncOperation<ConferenceResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListConferencesAsyncInternal());
        }
        private async Task<ConferenceResult> ListConferencesAsyncInternal()
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Conferences.json";

            var result = await ExecuteAsync(request, typeof(ConferenceResult));
            return (ConferenceResult)result;

        }

        /// <summary>
        /// Returns a list of conferences within an account.
        /// The list includes paging information and is sorted by DateUpdated, with most recent conferences first.
        /// Makes a POST request to the Conferences List resource.
        /// </summary>
        /// <param name="options">List filter options. Only properties with values are included in request.</param>
		public IAsyncOperation<ConferenceResult> ListConferencesAsync(ConferenceListRequest options)
        {
            return (IAsyncOperation<ConferenceResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListConferencesAsyncInternal(options));
        }
        private async Task<ConferenceResult> ListConferencesAsyncInternal(ConferenceListRequest options)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Conferences.json";

            AddConferenceListOptions(options, request);

            var result = await ExecuteAsync(request, typeof(ConferenceResult));
            return (ConferenceResult)result;

        }

        /// <summary>
        /// Retrieve details for specific conference. Makes a GET request to a Conference Instance resource.
        /// </summary>
        /// <param name="conferenceSid">The Sid of the conference to retrieve</param>
        public IAsyncOperation<Conference> GetConferenceAsync(string conferenceSid)
        {
            return (IAsyncOperation<Conference>)AsyncInfo.Run((System.Threading.CancellationToken ct) => GetConferenceAsyncInternal(conferenceSid));
        }
        private async Task<Conference> GetConferenceAsyncInternal(string conferenceSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}.json";

            request.AddUrlSegment("ConferenceSid", conferenceSid);

            var result = await ExecuteAsync(request, typeof(Conference));
            return (Conference)result;

        }

        /// <summary>
        /// Retrieve a list of conference participants. Makes a GET request to a Conference Participants List resource.
        /// </summary>
        /// <param name="conferenceSid">The Sid of the conference</param>
        /// <param name="muted">Set to null to retrieve all, true to retrieve muted, false to retrieve unmuted</param>
		public IAsyncOperation<ParticipantResult> ListConferenceParticipantsAsync(string conferenceSid, bool? muted)
        {
            return (IAsyncOperation<ParticipantResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListConferenceParticipantsAsyncInternal(conferenceSid, muted, null, null));
        }

        /// <summary>
        /// Retrieve a list of conference participants. Makes a GET request to a Conference Participants List resource.
        /// </summary>
        /// <param name="conferenceSid">The Sid of the conference</param>
        /// <param name="muted">Set to null to retrieve all, true to retrieve muted, false to retrieve unmuted</param>
        /// <param name="pageNumber">Which page number to start retrieving from</param>
        /// <param name="count">How many participants to retrieve</param>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public IAsyncOperation<ParticipantResult> ListConferenceParticipantsAsync(string conferenceSid, bool? muted, int? pageNumber, int? count)
        {
            return (IAsyncOperation<ParticipantResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListConferenceParticipantsAsyncInternal(conferenceSid, muted, pageNumber, count));
        }
        private async Task<ParticipantResult> ListConferenceParticipantsAsyncInternal(string conferenceSid, bool? muted, int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants.json";

            request.AddUrlSegment("ConferenceSid", conferenceSid);

            if (muted.HasValue) request.AddParameter("Muted", muted.Value);
            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            var result = await ExecuteAsync(request, typeof(ParticipantResult));
            return (ParticipantResult)result;

        }

        /// <summary>
        /// Retrieve a single conference participant by their CallSid. Makes a GET request to a Conference Participant Instance resource.
        /// </summary>
        /// <param name="conferenceSid">The Sid of the conference</param>
        /// <param name="callSid">The Sid of the call instance</param>
        public IAsyncOperation<Participant> GetConferenceParticipantAsync(string conferenceSid, string callSid)
        {
            return (IAsyncOperation<Participant>)AsyncInfo.Run((System.Threading.CancellationToken ct) => GetConferenceParticipantAsyncInternal(conferenceSid, callSid));
        }
        private async Task<Participant> GetConferenceParticipantAsyncInternal(string conferenceSid, string callSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants/{CallSid}.json";

            request.AddUrlSegment("ConferenceSid", conferenceSid);
            request.AddUrlSegment("CallSid", callSid);

            var result = await ExecuteAsync(request, typeof(Participant));
            return (Participant)result;

        }

        /// <summary>
        /// Change a participant of a conference to be muted. Makes a GET request to a Conference Participant Instance resource.
        /// </summary>
        /// <param name="conferenceSid">The Sid of the conference</param>
        /// <param name="callSid">The Sid of the call to mute</param>
        public IAsyncOperation<Participant> MuteConferenceParticipantAsync(string conferenceSid, string callSid)
        {
            return (IAsyncOperation<Participant>)AsyncInfo.Run((System.Threading.CancellationToken ct) => MuteConferenceParticipantAsyncInternal(conferenceSid, callSid));
        }
        private async Task<Participant> MuteConferenceParticipantAsyncInternal(string conferenceSid, string callSid)
        {
            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants/{CallSid}.json";

            request.AddUrlSegment("ConferenceSid", conferenceSid);
            request.AddUrlSegment("CallSid", callSid);
            request.AddParameter("Muted", true);

            var result = await ExecuteAsync(request, typeof(Participant));
            return (Participant)result;

        }

        /// <summary>
        /// Change a participant of a conference to be unmuted. Makes a GET request to a Conference Participant Instance resource.
        /// </summary>
        /// <param name="conferenceSid">The Sid of the conference</param>
        /// <param name="callSid">The Sid of the call to unmute</param>
        public IAsyncOperation<Participant> UnmuteConferenceParticipantAsync(string conferenceSid, string callSid)
        {
            return (IAsyncOperation<Participant>)AsyncInfo.Run((System.Threading.CancellationToken ct) => UnmuteConferenceParticipantAsyncInternal(conferenceSid, callSid));
        }
        private async Task<Participant> UnmuteConferenceParticipantAsyncInternal(string conferenceSid, string callSid)
        {
            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants/{CallSid}.json";

            request.AddUrlSegment("ConferenceSid", conferenceSid);
            request.AddUrlSegment("CallSid", callSid);
            request.AddParameter("Muted", false);

            var result = await ExecuteAsync(request, typeof(Participant));
            return (Participant)result;

        }

        /// <summary>
        /// Remove a caller from a conference. Makes a DELETE request to a Conference Participant Instance resource.
        /// </summary>
        /// <param name="conferenceSid">The Sid of the conference</param>
        /// <param name="callSid">The Sid of the call to remove</param>
        public IAsyncOperation<bool> KickConferenceParticipantAsync(string conferenceSid, string callSid)
        {
            return (IAsyncOperation<bool>)AsyncInfo.Run((System.Threading.CancellationToken ct) => KickConferenceParticipantAsyncInternal(conferenceSid, callSid));
        }
        private async Task<bool> KickConferenceParticipantAsyncInternal(string conferenceSid, string callSid)
        {
            var request = new RestRequest();
            request.Method = Method.DELETE;
            request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants/{CallSid}.json";
            request.AddUrlSegment("ConferenceSid", conferenceSid);
            request.AddUrlSegment("CallSid", callSid);

            var response = (RestResponse)await ExecuteAsync(request);
            return response.StatusCode == (int)System.Net.HttpStatusCode.NoContent;
        }

        private void AddConferenceListOptions(ConferenceListRequest options, RestRequest request)
        {
            if (options.Status.HasValue) request.AddParameter("Status", options.Status);
            if (options.FriendlyName.HasValue()) request.AddParameter("FriendlyName", options.FriendlyName);

            var dateCreatedParameterName = GetParameterNameWithEquality(options.DateCreatedComparison, "DateCreated");
            var dateUpdatedParameterName = GetParameterNameWithEquality(options.DateUpdatedComparison, "DateUpdated");

            if (options.DateCreated.HasValue) request.AddParameter(dateCreatedParameterName, options.DateCreated.Value.ToString("yyyy-MM-dd"));
            if (options.DateUpdated.HasValue) request.AddParameter(dateUpdatedParameterName, options.DateUpdated.Value.ToString("yyyy-MM-dd"));

            if (options.Count.HasValue) request.AddParameter("PageSize", options.Count.Value);
            if (options.PageNumber.HasValue) request.AddParameter("Page", options.PageNumber.Value);
        }
    }
}
