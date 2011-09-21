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
using System.Collections.Generic;

namespace Twilio
{
	/// <summary>
	/// An ConnectApp instance resource.
	/// </summary>
	public class ConnectApp : TwilioBase
	{
		/// <summary>
		/// A 34 character string that uniquely identifies this account.
		/// </summary>
		public string Sid { get; set; }
		/// <summary>
		/// The AccountSid of the SubAccount this Connect App has access to.
		/// </summary>
		public string AccountSid { get; set; }
		/// <summary>
		/// The date that this account was created, given as GMT
		/// </summary>
		public DateTime DateCreated { get; set; }
		/// <summary>
		/// The date that this account was last updated, given in as GMT
		/// </summary>
		public DateTime DateUpdated { get; set; }
		/// <summary>
		/// The set of permissions that you have authorized for this Connect App. Valid permisisons are get-all or post-all.
		/// </summary>
		public List<Permission> Permissions { get; set; }
		/// <summary>
		/// A human readable name for the Connect App.
		/// </summary>
		public string FriendlyName { get; set; }
		/// <summary>
		/// A more detailed human readable description of the Connect App.
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// The company name set for this Connect App.
		/// </summary>
		public string CompanyName { get; set; }
		/// <summary>
		/// The public URL where users can obtain more information about this Connect App.
		/// </summary>
		public string HomepageUrl { get; set; }
		/// <summary>
		/// The URL the user's browser will redirect to after Twilio authenticates the user and obtains authorization for this Connect App.
		/// </summary>
		public string AuthorizeRedirectUrl { get; set; }
		/// <summary>
		/// The URL to which Twilio will send a request when a user de-authorizes this Connect App.
		/// </summary>
		public string DeauthorizeCallbackUrl { get; set; }
		/// <summary>
		/// The HTTP method to be used when making a request to the DeauthorizeCallbackUrl.
		/// </summary>
		public string DeauthorizeCallbackMethod { get; set; }
	}
}