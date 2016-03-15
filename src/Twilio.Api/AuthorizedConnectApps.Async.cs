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
        public virtual void GetAuthorizedConnectApp(string authorizedConnectAppSid, Action<AuthorizedConnectApp> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/AuthorizedConnectApps/{AuthorizedConnectAppSid}.json";

			request.AddUrlSegment("AuthorizedConnectAppSid", authorizedConnectAppSid);

			ExecuteAsync<AuthorizedConnectApp>(request, (response) => { callback(response); });
		}

		/// <summary>
		/// List AuthorizedConnectApps on current account
		/// </summary>
		/// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListAuthorizedConnectApps(Action<AuthorizedConnectAppResult> callback)
		{
			ListAuthorizedConnectApps(null, null, (response) => { callback(response); });
		}

		/// <summary>
		/// List AuthorizedConnectApps on current account with filters
		/// </summary>
		/// <param name="pageNumber">Page number to start retrieving results from</param>
		/// <param name="count">How many results to return</param>
		/// <param name="callback">Method to call upon successful completion</param>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual void ListAuthorizedConnectApps(int? pageNumber, int? count, Action<AuthorizedConnectAppResult> callback)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/AuthorizedConnectApps.json";

			if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
			if (count.HasValue) request.AddParameter("PageSize", count.Value);

			ExecuteAsync<AuthorizedConnectAppResult>(request, (response) => { callback(response); });
		}
	}
}
