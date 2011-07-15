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
	/// An OutgoingCallerId instance resource represents a single Twilio OutgoingCallerId.
	/// </summary>
	public class OutgoingCallerId : TwilioBase
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
		/// The date that this resource last updated
		/// </summary>
		public DateTime DateUpdated { get; set; }
		/// <summary>
		/// A human readable descriptive text for this resource, up to 64 characters long. By default, the FriendlyName is a nicely formatted version of the phone number.
		/// </summary>
		public string FriendlyName { get; set; }
		/// <summary>
		/// The unique id of the Account responsible for this Caller Id.
		/// </summary>
		public string AccountSid { get; set; }
		/// <summary>
		/// The incoming phone number. Formatted with a '+' and country code e.g., +16175551212 (E.164 format).
		/// </summary>
		public string PhoneNumber { get; set; }
	}
}