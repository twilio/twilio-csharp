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
		/// Retrieve the details for an ConnectApp instance. Makes a GET request to an ConnectApp Instance resource.
		/// </summary>
		/// <param name="connectAppSid">The Sid of the ConnectApp to retrieve</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public void GetConnectApp(string connectAppSid, Action<ConnectApp> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/ConnectApps/{ConnectAppSid}";
			request.RootElement = "ConnectApp";

			request.AddUrlSegment("ConnectAppSid", connectAppSid);

			ExecuteAsync<ConnectApp>(request, (response) => { callback(response); });
		}

		/// <summary>
		/// List ConnectApps on current account
		/// </summary>
		/// <param name="callback">Method to call upon successful completion</param>
		public void ListConnectApps(Action<ConnectAppResult> callback)
		{
			ListConnectApps(null, null, (response) => { callback(response); });
		}

		/// <summary>
		/// List ConnectApps on current account with filters
		/// </summary>
		/// <param name="pageNumber">Page number to start retrieving results from</param>
		/// <param name="count">How many results to return</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public void ListConnectApps(int? pageNumber, int? count, Action<ConnectAppResult> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/ConnectApps";

			if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
			if (count.HasValue) request.AddParameter("PageSize", count.Value);

			ExecuteAsync<ConnectAppResult>(request, (response) => { callback(response); });
		}

		/// <summary>
		/// Tries to update the ConnectApp's properties, and returns the updated resource representation if successful.
		/// </summary>
		/// <param name="connectAppSid">The Sid of the ConnectApp to update</param>
		/// <param name="friendlyName">A human readable description of the Connect App, with maximum length 64 characters. (optional, null to leave as-is)</param>
		/// <param name="authorizeRedirectUrl">The URL the user's browser will redirect to after Twilio authenticates the user and obtains authorization for this Connect App. (optional, null to leave as-is)</param>
		/// <param name="deauthorizeCallbackUrl">The URL to which Twilio will send a request when a user de-authorizes this Connect App. (optional, null to leave as-is)</param>
		/// <param name="deauthorizeCallbackMethod">The HTTP method to be used when making a request to the DeauthorizeCallbackUrl. Either GET or POST. (optional, null to leave as-is)</param>
		/// <param name="permissions">A comma-separated list of permssions you will request from users of this ConnectApp. Valid permssions are get-all or post-all. (optional, null to leave as-is)</param>
		/// <param name="description">A more detailed human readable description of the Connect App. (optional, null to leave as-is)</param>
		/// <param name="companyName">The company name for this Connect App. (optional, null to leave as-is)</param>
		/// <param name="homepageUrl">The public URL where users can obtain more information about this Connect App. (optional, null to leave as-is)</param>
		/// <param name="callback">Method to call upon successful completion</param>
		public void UpdateConnectApp(string connectAppSid, string friendlyName, string authorizeRedirectUrl, string deauthorizeCallbackUrl,
			string deauthorizeCallbackMethod, string permissions, string description, string companyName, string homepageUrl, Action<ConnectApp> callback)
		{
			Require.Argument("ConnectAppSid", connectAppSid);

			var request = new RestRequest(Method.POST);
			request.Resource = "Accounts/{AccountSid}/ConnectApps/{ConnectAppSid}";
			request.AddUrlSegment("ConnectAppSid", connectAppSid);
			request.RootElement = "ConnectApp";

			if (friendlyName.HasValue()) request.AddParameter("FriendlyName", friendlyName);
			if (authorizeRedirectUrl.HasValue()) request.AddParameter("AuthorizeRedirectUrl", authorizeRedirectUrl);
			if (deauthorizeCallbackUrl.HasValue()) request.AddParameter("DeauthorizeCallbackUrl", deauthorizeCallbackUrl);
			if (deauthorizeCallbackMethod.HasValue()) request.AddParameter("DeauthorizeCallbackMethod", deauthorizeCallbackMethod);
			if (permissions.HasValue()) request.AddParameter("Permissions", permissions);
			if (description.HasValue()) request.AddParameter("Description", description);
			if (companyName.HasValue()) request.AddParameter("CompanyName", companyName);
			if (homepageUrl.HasValue()) request.AddParameter("HomepageUrl", homepageUrl);

			ExecuteAsync<ConnectApp>(request, (response) => { callback(response); });
		}
	}
}