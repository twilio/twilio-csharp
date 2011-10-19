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
		public AuthorizedConnectApp GetAuthorizedConnectApp(string authorizedConnectAppSid)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/AuthorizedConnectApps/{AuthorizedConnectAppSid}";
			request.RootElement = "AuthorizedConnectApp";

			request.AddUrlSegment("AuthorizedConnectAppSid", authorizedConnectAppSid);

			return Execute<AuthorizedConnectApp>(request);
		}

		/// <summary>
		/// List AuthorizedConnectApps on current account
		/// </summary>
		public AuthorizedConnectAppResult ListAuthorizedConnectApps()
		{
			return ListAuthorizedConnectApps(null, null);
		}

		/// <summary>
		/// List AuthorizedConnectApps on current account with filters
		/// </summary>
		/// <param name="pageNumber">Page number to start retrieving results from</param>
		/// <param name="count">How many results to return</param>
		public AuthorizedConnectAppResult ListAuthorizedConnectApps(int? pageNumber, int? count)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/AuthorizedConnectApps";

			if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
			if (count.HasValue) request.AddParameter("PageSize", count.Value);

			return Execute<AuthorizedConnectAppResult>(request);
		}
	}
}