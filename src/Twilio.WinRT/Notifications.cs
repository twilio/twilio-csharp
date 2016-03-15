using System;
using RestRT;
using RestRT.Validation;
using Windows.Foundation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace Twilio
{
    public partial class TwilioRestClient
    {
        /// <summary>
        /// Retrieve the details of a specific notification. Makes a GET request to a Notification Instance resource.
        /// </summary>
        /// <param name="notificationSid">The Sid of the notification to retrieve</param>
        public IAsyncOperation<Notification> GetNotificationAsync(string notificationSid)
        {
            return (IAsyncOperation<Notification>)AsyncInfo.Run((System.Threading.CancellationToken ct) => GetNotificationAsyncInternal(notificationSid));
        }
        private async Task<Notification> GetNotificationAsyncInternal(string notificationSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Notifications/{NotificationSid}.json";

            request.AddParameter("NotificationSid", notificationSid, ParameterType.UrlSegment);

            var result = await ExecuteAsync(request, typeof(Notification));
            return (Notification)result;
        }

        /// <summary>
        /// Returns a list of notifications generated for an account. 
        /// The list includes paging information and is sorted by DateUpdated, with most recent notifications first.
        /// Makes a GET request to a Notifications List resource.
        /// </summary>
        public IAsyncOperation<NotificationResult> ListNotificationsAsync()
        {
            return (IAsyncOperation<NotificationResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListNotificationsAsyncInternal(null,null,null,null));
        }

        /// <summary>
        /// Returns a filtered list of notifications generated for an account. 
        /// The list includes paging information and is sorted by DateUpdated, with most recent notifications first.
        /// Makes a GET request to a Notifications List resource.
        /// </summary>
        /// <param name="log">Only show notifications for this log, using the integer log values: 0 is ERROR, 1 is WARNING</param>
        /// <param name="messageDate">Only show notifications for this date (in GMT)</param>
        /// <param name="pageNumber">The page number to start retrieving results from</param>
        /// <param name="count">How many notifications to return</param>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public IAsyncOperation<NotificationResult> ListNotificationsAsync(int? log, DateTimeOffset? messageDate, int? pageNumber, int? count)
        {
            return (IAsyncOperation<NotificationResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListNotificationsAsyncInternal(log, messageDate, pageNumber, count));
        }
        private async Task<NotificationResult> ListNotificationsAsyncInternal(int? log, DateTimeOffset? messageDate, int? pageNumber, int? count)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Notifications.json";

            if (log.HasValue) request.AddParameter("Log", log);
            if (messageDate.HasValue) request.AddParameter("MessageDate", messageDate.Value.ToString("yyyy-MM-dd"));
            if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
            if (count.HasValue) request.AddParameter("PageSize", count.Value);

            var result = await ExecuteAsync(request, typeof(NotificationResult));
            return (NotificationResult)result;

        }

        /// <summary>
        /// Deletes a notification from your account. Makes a DELETE request to a Notification Instance resource.
        /// </summary>
        /// <param name="notificationSid">The Sid of the notification to delete</param>
        public IAsyncOperation<DeleteStatus> DeleteNotificationAsync(string notificationSid)
        {
            return (IAsyncOperation<DeleteStatus>)AsyncInfo.Run((System.Threading.CancellationToken ct) => DeleteNotificationAsyncInternal(notificationSid));
        }
        private async Task<DeleteStatus> DeleteNotificationAsyncInternal(string notificationSid)
        {
            Require.Argument("NotificationSid", notificationSid);
            var request = new RestRequest();
            request.Method = Method.DELETE;
            request.Resource = "Accounts/{AccountSid}/Notifications/{NotificationSid}.json";

            request.AddParameter("NotificationSid", notificationSid, ParameterType.UrlSegment);

            var response = (RestResponse)await ExecuteAsync(request);
            return response.StatusCode == (int)System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }
    }
}