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

using System;

namespace Twilio
{
	/// <summary>
	/// An Participant instance resource represents a single Twilio conference Participant.
	/// </summary>
	public class Participant : TwilioBase
	{
		/// <summary>
		/// A 34 character string that identifies the conference this participant is in
		/// </summary>
		public string ConferenceSid { get; set; }
		/// <summary>
		/// The unique id of the Account that created this conference
		/// </summary>
		public string AccountSid { get; set; }
		/// <summary>
		/// A 34 character string that uniquely identifies the call that is connected to this conference
		/// </summary>
		public string CallSid { get; set; }
		/// <summary>
		/// true if this participant is currently muted. false otherwise.
		/// </summary>
		public bool Muted { get; set; }
		/// <summary>
		/// Was the startConferenceOnEnter attribute set on this participant (true or false)?
		/// </summary>
		public bool StartConferenceOnEnter { get; set; }
		/// <summary>
		/// Was the endConferenceOnExit attribute set on this participant (true or false)?
		/// </summary>
		public bool EndConferenceOnExit { get; set; }
		/// <summary>
		/// The date that this resource was created
		/// </summary>
		public DateTime DateCreated { get; set; }
		/// <summary>
		/// The date that this resource was last updated
		/// </summary>
		public DateTime DateUpdated { get; set; }
	}
}