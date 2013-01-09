using System;
using RestSharp;
using RestSharp.Extensions;

namespace Twilio
{
	public partial class TwilioRestClient
	{
		/// <summary>
		/// Returns a list of conferences within an account. The list includes paging information and is sorted by DateUpdated, with most recent conferences first.
		/// </summary>
		/// <param name="callback">Method to call upon successful completion</param>
		public void ListConferences(Action<ConferenceResult> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Conferences.json";

			ExecuteAsync<ConferenceResult>(request, (response) => callback(response));
		}

		/// <summary>
		/// Returns a list of conferences within an account. The list includes paging information and is sorted by DateUpdated, with most recent conferences first.
		/// </summary>
		/// <param name="options">List filter options. Only properties with values are included in request.</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public void ListConferences(ConferenceListRequest options, Action<ConferenceResult> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Conferences.json";

			AddConferenceListOptions(options, request);

			ExecuteAsync<ConferenceResult>(request, (response) => callback(response));
		}

		private void AddConferenceListOptions(ConferenceListRequest options, RestRequest request)
		{
			if (options.Status != null) request.AddParameter("Status", options.Status);
			if (options.FriendlyName.HasValue()) request.AddParameter("FriendlyName", options.FriendlyName);

			var dateCreatedParameterName = GetParameterNameWithEquality(options.DateCreatedComparison, "DateCreated");
			var dateUpdatedParameterName = GetParameterNameWithEquality(options.DateUpdatedComparison, "DateUpdated");

			if (options.DateCreated.HasValue) request.AddParameter(dateCreatedParameterName, options.DateCreated.Value.ToString("yyyy-MM-dd"));
			if (options.DateUpdated.HasValue) request.AddParameter(dateUpdatedParameterName, options.DateUpdated.Value.ToString("yyyy-MM-dd"));

			if (options.Count.HasValue) request.AddParameter("PageSize", options.Count.Value);
			if (options.PageNumber.HasValue) request.AddParameter("Page", options.PageNumber.Value);
		}

		/// <summary>
		/// Retrieve details for specific conference
		/// </summary>
		/// <param name="conferenceSid">The Sid of the conference to retrieve</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public void GetConference(string conferenceSid, Action<Conference> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}.json";
			
			request.AddUrlSegment("ConferenceSid", conferenceSid);

			ExecuteAsync<Conference>(request, (response) => callback(response));
		}

		/// <summary>
		/// Retrieve a list of conference participants
		/// </summary>
		/// <param name="conferenceSid">The Sid of the conference</param>
		/// <param name="muted">Set to null to retrieve all, true to retrieve muted, false to retrieve unmuted</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public void ListConferenceParticipants(string conferenceSid, bool? muted, Action<ParticipantResult> callback)
		{
			ListConferenceParticipants(conferenceSid, muted, null, null, callback);
		}

		/// <summary>
		/// Retrieve a list of conference participants
		/// </summary>
		/// <param name="conferenceSid">The Sid of the conference</param>
		/// <param name="muted">Set to null to retrieve all, true to retrieve muted, false to retrieve unmuted</param>
		/// <param name="pageNumber">Which page number to start retrieving from</param>
		/// <param name="count">How many participants to retrieve</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public void ListConferenceParticipants(string conferenceSid, bool? muted, int? pageNumber, int? count, Action<ParticipantResult> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants.json";

			request.AddUrlSegment("ConferenceSid", conferenceSid);

			if (muted.HasValue) request.AddParameter("Muted", muted.Value);
			if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
			if (count.HasValue) request.AddParameter("PageSize", count.Value);

			ExecuteAsync<ParticipantResult>(request, (response) => callback(response));
		}

		/// <summary>
		/// Retrieve a single conference participant by their CallSid
		/// </summary>
		/// <param name="conferenceSid">The Sid of the conference</param>
		/// <param name="callSid">The Sid of the call instance</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public void GetConferenceParticipant(string conferenceSid, string callSid, Action<Participant> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants/{CallSid}.json";
			
			request.AddUrlSegment("ConferenceSid", conferenceSid);
			request.AddUrlSegment("CallSid", callSid);

			ExecuteAsync<Participant>(request, (response) => callback(response));
		}

		/// <summary>
		/// Change a participant of a conference to be muted
		/// </summary>
		/// <param name="conferenceSid">The Sid of the conference</param>
		/// <param name="callSid">The Sid of the call to mute</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public void MuteConferenceParticipant(string conferenceSid, string callSid, Action<Participant> callback)
		{
			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants/{CallSid}.json";
			
			request.AddUrlSegment("ConferenceSid", conferenceSid);
			request.AddUrlSegment("CallSid", callSid);
			request.AddParameter("Muted", true);

			ExecuteAsync<Participant>(request, (response) => callback(response));
		}

		/// <summary>
		/// Change a participant of a conference to be unmuted
		/// </summary>
		/// <param name="conferenceSid">The Sid of the conference</param>
		/// <param name="callSid">The Sid of the call to unmute</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public void UnmuteConferenceParticipant(string conferenceSid, string callSid, Action<Participant> callback)
		{
			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants/{CallSid}.json";
			
			request.AddUrlSegment("ConferenceSid", conferenceSid);
			request.AddUrlSegment("CallSid", callSid);
			request.AddParameter("Muted", false);

			ExecuteAsync<Participant>(request, (response) => callback(response));
		}

		/// <summary>
		/// Remove a caller from a conference
		/// </summary>
		/// <param name="conferenceSid">The Sid of the conference</param>
		/// <param name="callSid">The Sid of the call to remove</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public void KickConferenceParticipant(string conferenceSid, string callSid, Action<bool> callback)
		{
			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants/{CallSid}.json";
			request.AddUrlSegment("ConferenceSid", conferenceSid);
			request.AddUrlSegment("CallSid", callSid);

			ExecuteAsync(request, (response) => callback(response.StatusCode == System.Net.HttpStatusCode.NoContent));
		}
	}
}
