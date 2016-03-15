using RestSharp;

namespace Twilio
{
	public partial class TwilioRestClient
	{
		/// <summary>
		/// Returns a list of conferences within an account.
		/// The list includes paging information.
		/// Makes a GET request to the Conferences List resource.
		/// </summary>
        public virtual ConferenceResult ListConferences()
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Conferences.json";

			return Execute<ConferenceResult>(request);
		}

		/// <summary>
		/// Returns a list of conferences within an account.
		/// The list includes paging information.
		/// Makes a POST request to the Conferences List resource.
		/// </summary>
		/// <param name="options">List filter options. Only properties with values are included in request.</param>
		public virtual ConferenceResult ListConferences(ConferenceListRequest options)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Conferences.json";

			AddConferenceListOptions(options, request);

			return Execute<ConferenceResult>(request);
		}

		/// <summary>
		/// Retrieve details for specific conference. Makes a GET request to a Conference Instance resource.
		/// </summary>
		/// <param name="conferenceSid">The Sid of the conference to retrieve</param>
        public virtual Conference GetConference(string conferenceSid)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}.json";

			request.AddUrlSegment("ConferenceSid", conferenceSid);

			return Execute<Conference>(request);
		}

		/// <summary>
		/// Retrieve a list of conference participants. Makes a GET request to a Conference Participants List resource.
		/// </summary>
		/// <param name="conferenceSid">The Sid of the conference</param>
		/// <param name="muted">Set to null to retrieve all, true to retrieve muted, false to retrieve unmuted</param>
		public virtual ParticipantResult ListConferenceParticipants(string conferenceSid, bool? muted)
		{
			return ListConferenceParticipants(conferenceSid, muted, null, null);
		}

		/// <summary>
		/// Retrieve a list of conference participants. Makes a GET request to a Conference Participants List resource.
		/// </summary>
		/// <param name="conferenceSid">The Sid of the conference</param>
		/// <param name="muted">Set to null to retrieve all, true to retrieve muted, false to retrieve unmuted</param>
		/// <param name="pageNumber">Which page number to start retrieving from</param>
		/// <param name="count">How many participants to retrieve</param>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual ParticipantResult ListConferenceParticipants(string conferenceSid, bool? muted, int? pageNumber, int? count)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants.json";

			request.AddUrlSegment("ConferenceSid", conferenceSid);

			if (muted.HasValue) request.AddParameter("Muted", muted.Value);
			if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
			if (count.HasValue) request.AddParameter("PageSize", count.Value);

			return Execute<ParticipantResult>(request);
		}

		/// <summary>
		/// Retrieve a single conference participant by their CallSid. Makes a GET request to a Conference Participant Instance resource.
		/// </summary>
		/// <param name="conferenceSid">The Sid of the conference</param>
		/// <param name="callSid">The Sid of the call instance</param>
        public virtual Participant GetConferenceParticipant(string conferenceSid, string callSid)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants/{CallSid}.json";

			request.AddUrlSegment("ConferenceSid", conferenceSid);
			request.AddUrlSegment("CallSid", callSid);

			return Execute<Participant>(request);
		}

		/// <summary>
		/// Change a participant of a conference to be muted. Makes a GET request to a Conference Participant Instance resource.
		/// </summary>
		/// <param name="conferenceSid">The Sid of the conference</param>
		/// <param name="callSid">The Sid of the call to mute</param>
        public virtual Participant MuteConferenceParticipant(string conferenceSid, string callSid)
		{
			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants/{CallSid}.json";

			request.AddUrlSegment("ConferenceSid", conferenceSid);
			request.AddUrlSegment("CallSid", callSid);
			request.AddParameter("Muted", true);

			return Execute<Participant>(request);
		}

		/// <summary>
		/// Change a participant of a conference to be unmuted. Makes a GET request to a Conference Participant Instance resource.
		/// </summary>
		/// <param name="conferenceSid">The Sid of the conference</param>
		/// <param name="callSid">The Sid of the call to unmute</param>
        public virtual Participant UnmuteConferenceParticipant(string conferenceSid, string callSid)
		{
			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants/{CallSid}.json";

			request.AddUrlSegment("ConferenceSid", conferenceSid);
			request.AddUrlSegment("CallSid", callSid);
			request.AddParameter("Muted", false);

			return Execute<Participant>(request);
		}

		/// <summary>
		/// Remove a caller from a conference. Makes a DELETE request to a Conference Participant Instance resource.
		/// </summary>
		/// <param name="conferenceSid">The Sid of the conference</param>
		/// <param name="callSid">The Sid of the call to remove</param>
        public virtual bool KickConferenceParticipant(string conferenceSid, string callSid)
		{
			var request = new RestRequest(Method.DELETE);
			request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants/{CallSid}.json";
			request.AddUrlSegment("ConferenceSid", conferenceSid);
			request.AddUrlSegment("CallSid", callSid);

			var response = Execute(request);
			return response.StatusCode == System.Net.HttpStatusCode.NoContent;
		}
	}
}
