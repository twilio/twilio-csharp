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
	/// An Conference instance resource represents a single Twilio Conference.
	/// </summary>
	public class Conference : TwilioBase
	{
		/// <summary>
		/// A 34 character string that uniquely identifies this conference.
		/// </summary>
		public string Sid { get; set; }
		/// <summary>
		/// The unique id of the Account responsible for creating this conference.
		/// </summary>
		public string AccountSid { get; set; }
		/// <summary>
		/// A user provided string that identifies this conference room.
		/// </summary>
		public string FriendlyName { get; set; }
		/// <summary>
		/// A string representing the status of the conference. May be init, in-progress, or completed.
		/// </summary>
		public string Status { get; set; }
		/// <summary>
		/// The date that this conference was created, given as GMT
		/// </summary>
		public DateTime DateCreated { get; set; }
		/// <summary>
		/// The date that this conference was last updated, given as GMT
		/// </summary>
		public DateTime DateUpdated { get; set; }
	}
}