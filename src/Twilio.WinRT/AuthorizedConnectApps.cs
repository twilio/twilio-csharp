using RestRT;
using RestRT.Extensions;
using RestRT.Validation;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Twilio
{
    public partial class TwilioRestClient
    {
        /// <summary>
        /// Retrieve the details for an AuthorizedConnectApp instance. Makes a GET request to an AuthorizedConnectApp Instance resource.
        /// </summary>
        /// <param name="authorizedConnectAppSid">The Sid of the AuthorizedConnectApp to retrieve</param>
        public IAsyncOperation<AuthorizedConnectApp> GetAuthorizedConnectAppAsync(string authorizedConnectAppSid)
        {
            return (IAsyncOperation<AuthorizedConnectApp>)AsyncInfo.Run((System.Threading.CancellationToken ct) => GetAuthorizedConnectAppAsyncInternal(authorizedConnectAppSid));
        }
        private async Task<AuthorizedConnectApp> GetAuthorizedConnectAppAsyncInternal(string authorizedConnectAppSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/AuthorizedConnectApps/{AuthorizedConnectAppSid}.json";

            request.AddUrlSegment("AuthorizedConnectAppSid", authorizedConnectAppSid);

            var result = await ExecuteAsync(request, typeof(AuthorizedConnectApp));
            return (AuthorizedConnectApp)result;

        }

        /// <summary>
        /// List AuthorizedConnectApps on current account
        /// </summary>
        public IAsyncOperation<AuthorizedConnectAppResult> ListAuthorizedConnectAppsAsync()
        {
            return (IAsyncOperation<AuthorizedConnectAppResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListAuthorizedConnectAppsAsyncInternal(null, null));
        }

        /// <summary>
        /// List AuthorizedConnectApps on current account with filters
        /// </summary>
        /// <param name="pageNumber">Page number to start retrieving results from</param>
        /// <param name="count">How many results to return</param>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public IAsyncOperation<AuthorizedConnectAppResult> ListAuthorizedConnectAppsAsync(int? pageNumber, int? count)
        {
            return (IAsyncOperation<AuthorizedConnectAppResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListAuthorizedConnectAppsAsyncInternal(pageNumber, count));
        }
        private async Task<AuthorizedConnectAppResult> ListAuthorizedConnectAppsAsyncInternal(int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/AuthorizedConnectApps.json";

            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            var result = await ExecuteAsync(request, typeof(AuthorizedConnectAppResult));
            return (AuthorizedConnectAppResult)result;

        }
    }
}