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
	/// An Recording instance resource represents a single Twilio Recording.
	/// </summary>
	public class Recording : TwilioBase
	{
		/// <summary>
		/// A 34 character string that uniquely identifies this resource.
		/// </summary>
		public string Sid { get; set; }
		/// <summary>
		/// The date that this resource was created
		/// </summary>
		public DateTime DateCreated { get; set; }
		/// <summary>
		/// The date that this resource was last updated
		/// </summary>
		public DateTime DateUpdated { get; set; }
		/// <summary>
		/// The unique id of the Account responsible for this recording.
		/// </summary>
		public string AccountSid { get; set; }
		/// <summary>
		/// The call during which the recording was made.
		/// </summary>
		public string CallSid { get; set; }
		/// <summary>
		/// The length of the recording, in seconds.
		/// </summary>
		public int Duration { get; set; }
		/// <summary>
		/// The version of the API in use during the recording.
		/// </summary>
		public string ApiVersion { get; set; }
	}
}