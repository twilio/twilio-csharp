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
	/// An Account instance resource represents a single Twilio Account.
	/// </summary>
	public class Account : TwilioBase
	{
		/// <summary>
		/// A 34 character string that uniquely identifies this account.
		/// </summary>
		public string Sid { get; set; }
		/// <summary>
		/// The date that this account was created, given as GMT
		/// </summary>
		public DateTime DateCreated { get; set; }
		/// <summary>
		/// The date that this account was last updated, given in as GMT
		/// </summary>
		public DateTime DateUpdated { get; set; }
		/// <summary>
		/// A human readable description of this account, up to 64 characters long. By default the FriendlyName is your email address.
		/// </summary>
		public string FriendlyName { get; set; }
		/// <summary>
		/// The status of this account. Usually active, but can be suspended if you've been bad.
		/// </summary>
		public string Status { get; set; }
		/// <summary>
		/// The authorization token for this account. This token should be kept a secret, so no sharing.
		/// </summary>
		public string AuthToken { get; set; }
	}

	/// <summary>
	/// Twilio API call result with paging information
	/// </summary>
	public class AccountResult
	{
		/// <summary>
		/// List of accounts returned by API
		/// </summary>
		public TwilioList<Account> Accounts { get; set; }
	}
}