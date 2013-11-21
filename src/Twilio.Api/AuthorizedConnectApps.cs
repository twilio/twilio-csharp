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
			request.Resource = "Accounts/{AccountSid}/AuthorizedConnectApps/{AuthorizedConnectAppSid}.json";
			
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
			request.Resource = "Accounts/{AccountSid}/AuthorizedConnectApps.json";

			if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
			if (count.HasValue) request.AddParameter("PageSize", count.Value);

			return Execute<AuthorizedConnectAppResult>(request);
		}
	}
}