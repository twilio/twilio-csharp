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
        public virtual AuthorizedConnectApp GetAuthorizedConnectApp(string authorizedConnectAppSid)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/AuthorizedConnectApps/{AuthorizedConnectAppSid}.json";
			
			request.AddUrlSegment("AuthorizedConnectAppSid", authorizedConnectAppSid);

			return Execute<AuthorizedConnectApp>(request);
		}

		/// <summary>
		/// List AuthorizedConnectApps on current account
		/// </summary>
        public virtual AuthorizedConnectAppResult ListAuthorizedConnectApps()
		{
			return ListAuthorizedConnectApps(null, null);
		}

		/// <summary>
		/// List AuthorizedConnectApps on current account with filters
		/// </summary>
		/// <param name="pageNumber">Page number to start retrieving results from</param>
		/// <param name="count">How many results to return</param>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual AuthorizedConnectAppResult ListAuthorizedConnectApps(int? pageNumber, int? count)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/AuthorizedConnectApps.json";

			if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
			if (count.HasValue) request.AddParameter("PageSize", count.Value);

			return Execute<AuthorizedConnectAppResult>(request);
		}
	}
}