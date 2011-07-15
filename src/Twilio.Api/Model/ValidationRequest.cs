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

namespace Twilio
{
	/// <summary>
	/// Result of making a request to validate an OutgoingCallerId
	/// </summary>
	public class ValidationRequestResult : TwilioBase
	{
		/// <summary>
		/// The unique id of the Account to which the Validation Request belongs.
		/// </summary>
		public string AccountSid { get; set; }
		/// <summary>
		/// The friendly name you provided, if any.
		/// </summary>
		public string FriendlyName { get; set; }
		/// <summary>
		/// The incoming phone number being validated, formatted with a '+' and country code e.g., +16175551212 (E.164 format).
		/// </summary>
		public string PhoneNumber { get; set; }
		/// <summary>
		/// The 6 digit validation code that must be entered via the phone to validate this phone number for Caller ID.
		/// </summary>
		public string ValidationCode { get; set; }
	}
}