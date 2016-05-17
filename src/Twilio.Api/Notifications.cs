using System;
using RestSharp;
using RestSharp.Validation;

namespace Twilio
{
	public partial class TwilioRestClient
	{
		/// <summary>
		/// Retrieve the details of a specific notification. Makes a GET request to a Notification Instance resource.
		/// </summary>
		/// <param name="notificationSid">The Sid of the notification to retrieve</param>
        public virtual Notification GetNotification(string notificationSid)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Notifications/{NotificationSid}.json";
			
			request.AddParameter("NotificationSid", notificationSid, ParameterType.UrlSegment);

			return Execute<Notification>(request);
		}

		/// <summary>
		/// Returns a list of notifications generated for an account. 
		/// The list includes paging information.
		/// Makes a GET request to a Notifications List resource.
		/// </summary>
        public virtual NotificationResult ListNotifications()
		{
			return ListNotifications(null, null, null, null);
		}

		/// <summary>
		/// Returns a filtered list of notifications generated for an account. 
		/// The list includes paging information.
		/// Makes a GET request to a Notifications List resource.
		/// </summary>
		/// <param name="log">Only show notifications for this log, using the integer log values: 0 is ERROR, 1 is WARNING</param>
		/// <param name="messageDate">Only show notifications for this date (in GMT)</param>
		/// <param name="pageNumber">The page number to start retrieving results from</param>
		/// <param name="count">How many notifications to return</param>
        [System.Obsolete("Use GetNextPage and GetPreviousPage for paging. Page parameter is scheduled for end of life https://www.twilio.com/engineering/2015/04/16/replacing-absolute-paging-with-relative-paging")]
		public virtual NotificationResult ListNotifications(int? log, DateTime? messageDate, int? pageNumber, int? count)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Notifications.json";

			if (log.HasValue) request.AddParameter("Log", log);
			if (messageDate.HasValue) request.AddParameter("MessageDate", messageDate.Value.ToString("yyyy-MM-dd"));
			if (pageNumber.HasValue) request.AddParameter("Page", pageNumber.Value);
			if (count.HasValue) request.AddParameter("PageSize", count.Value);

			return Execute<NotificationResult>(request);
		}

		/// <summary>
		/// Deletes a notification from your account. Makes a DELETE request to a Notification Instance resource.
		/// </summary>
		/// <param name="notificationSid">The Sid of the notification to delete</param>
        public virtual DeleteStatus DeleteNotification(string notificationSid)
		{
			Require.Argument("NotificationSid", notificationSid);
			var request = new RestRequest(Method.DELETE);
			request.Resource = "Accounts/{AccountSid}/Notifications/{NotificationSid}.json";

			request.AddParameter("NotificationSid", notificationSid, ParameterType.UrlSegment);

			var response = Execute(request);
			return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
		}
	}
}