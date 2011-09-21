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
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio
{
	public partial class TwilioRestClient
	{
		/// <summary>
		/// Retrieve the details for an AuthorizedConnectApp instance. Makes a GET request to an AuthorizedConnectApp Instance resource.
		/// </summary>
		/// <param name="authorizedConnectAppSid">The Sid of the AuthorizedConnectApp to retrieve</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public void GetAuthorizedConnectApp(string authorizedConnectAppSid, Action<AuthorizedConnectApp> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/AuthorizedConnectApps/{AuthorizedConnectAppSid}";
			request.RootElement = "AuthorizedConnectApp";

			request.AddUrlSegment("AuthorizedConnectAppSid", authorizedConnectAppSid);

			ExecuteAsync<AuthorizedConnectApp>(request, (response) => { callback(response); });
		}

		/// <summary>
		/// List AuthorizedConnectApps on current account
		/// </summary>
		/// <param name="callback">Method to call upon successful completion</param>
		public void ListAuthorizedConnectApps(Action<AuthorizedConnectAppResult> callback)
		{
			ListAuthorizedConnectApps(null, null, (response) => { callback(response); });
		}

		/// <summary>
		/// List AuthorizedConnectApps on current account with filters
		/// </summary>
		/// <param name="pageNumber">Page number to start retrieving results from</param>
		/// <param name="count">How many results to return</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public void ListAuthorizedConnectApps(int? pageNumber, int? count, Action<AuthorizedConnectAppResult> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/AuthorizedConnectApps";

			if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
			if (count.HasValue) request.AddParameter("PageSize", count.Value);

			ExecuteAsync<AuthorizedConnectAppResult>(request, (response) => { callback(response); });
		}
	}
}