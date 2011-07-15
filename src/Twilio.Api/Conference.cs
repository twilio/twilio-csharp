#region License
//   Copyright 2010 John Sheehan
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License. 
#endregion

using RestSharp;


namespace Twilio
{
	public partial class TwilioRestClient
	{
		/// <summary>
		/// Returns a list of conferences within an account. 
		/// The list includes paging information and is sorted by DateUpdated, with most recent conferences first.
		/// Makes a GET request to the Conferences List resource.
		/// </summary>
		public ConferenceResult ListConferences()
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Conferences";

			return Execute<ConferenceResult>(request);
		}

		/// <summary>
		/// Returns a list of conferences within an account. 
		/// The list includes paging information and is sorted by DateUpdated, with most recent conferences first.
		/// Makes a POST request to the Conferences List resource.
		/// </summary>
		/// <param name="options">List filter options. Only properties with values are included in request.</param>
		public ConferenceResult ListConferences(ConferenceListRequest options)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Conferences";

			AddConferenceListOptions(options, request);

			return Execute<ConferenceResult>(request);
		}

		/// <summary>
		/// Retrieve details for specific conference. Makes a GET request to a Conference Instance resource.
		/// </summary>
		/// <param name="conferenceSid">The Sid of the conference to retrieve</param>
		public Conference GetConference(string conferenceSid)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}";
			request.RootElement = "Conference";

			request.AddParameter("ConferenceSid", conferenceSid);

			return Execute<Conference>(request);
		}

		/// <summary>
		/// Retrieve a list of conference participants. Makes a GET request to a Conference Participants List resource.
		/// </summary>
		/// <param name="conferenceSid">The Sid of the conference</param>
		/// <param name="muted">Set to null to retrieve all, true to retrieve muted, false to retrieve unmuted</param>
		public ParticipantResult ListConferenceParticipants(string conferenceSid, bool? muted)
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
		public ParticipantResult ListConferenceParticipants(string conferenceSid, bool? muted, int? pageNumber, int? count)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants";

			request.AddParameter("ConferenceSid", conferenceSid);

			if (muted.HasValue) request.AddParameter("Muted", muted.Value);
			if (pageNumber.HasValue) request.AddParameter("page", pageNumber.Value);
			if (count.HasValue) request.AddParameter("num", count.Value);

			return Execute<ParticipantResult>(request);
		}

		/// <summary>
		/// Retrieve a single conference participant by their CallSid. Makes a GET request to a Conference Participant Instance resource.
		/// </summary>
		/// <param name="conferenceSid">The Sid of the conference</param>
		/// <param name="callSid">The Sid of the call instance</param>
		public Participant GetConferenceParticipant(string conferenceSid, string callSid)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants/{CallSid}";
			request.RootElement = "Participant";

			request.AddParameter("ConferenceSid", conferenceSid);
			request.AddParameter("CallSid", callSid);

			return Execute<Participant>(request);
		}

		/// <summary>
		/// Change a participant of a conference to be muted. Makes a GET request to a Conference Participant Instance resource.
		/// </summary>
		/// <param name="conferenceSid">The Sid of the conference</param>
		/// <param name="callSid">The Sid of the call to mute</param>
		public Participant MuteConferenceParticipant(string conferenceSid, string callSid)
		{
			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants/{CallSid}";
			request.RootElement = "Participant";

			request.AddParameter("ConferenceSid", conferenceSid);
			request.AddParameter("CallSid", callSid);
			request.AddParameter("Muted", true);

			return Execute<Participant>(request);
		}

		/// <summary>
		/// Change a participant of a conference to be unmuted. Makes a GET request to a Conference Participant Instance resource.
		/// </summary>
		/// <param name="conferenceSid">The Sid of the conference</param>
		/// <param name="callSid">The Sid of the call to unmute</param>
		public Participant UnmuteConferenceParticipant(string conferenceSid, string callSid)
		{
			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants/{CallSid}";
			request.RootElement = "Participant";

			request.AddParameter("ConferenceSid", conferenceSid);
			request.AddParameter("CallSid", callSid);
			request.AddParameter("Muted", false);

			return Execute<Participant>(request);
		}

		/// <summary>
		/// Remove a caller from a conference. Makes a DELETE request to a Conference Participant Instance resource.
		/// </summary>
		/// <param name="conferenceSid">The Sid of the conference</param>
		/// <param name="callSid">The Sid of the call to remove</param>
		public bool KickConferenceParticipant(string conferenceSid, string callSid)
		{
			var request = new RestRequest(Method.DELETE);
			request.Resource = "Accounts/{AccountSid}/Conferences/{ConferenceSid}/Participants/{CallSid}";
			request.AddParameter("ConferenceSid", conferenceSid);
			request.AddParameter("CallSid", callSid);

			var response = Execute(request);
			return response.StatusCode == System.Net.HttpStatusCode.NoContent;
		}
	}
}