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
using RestSharp.Validation;


namespace Twilio
{
	public partial class TwilioRestClient
	{
		/// <summary>
		/// Retrieve the details of a specific notification. Makes a GET request to a Notification Instance resource.
		/// </summary>
		/// <param name="notificationSid">The Sid of the notification to retrieve</param>
		public Notification GetNotification(string notificationSid)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Notifications/{NotificationSid}";
			request.RootElement = "Notification";

			request.AddParameter("NotificationSid", notificationSid, ParameterType.UrlSegment);

			return Execute<Notification>(request);
		}

		/// <summary>
		/// Returns a list of notifications generated for an account. 
		/// The list includes paging information and is sorted by DateUpdated, with most recent notifications first.
		/// Makes a GET request to a Notifications List resource.
		/// </summary>
		public NotificationResult ListNotifications()
		{
			return ListNotifications(null, null, null, null);
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
		public NotificationResult ListNotifications(int? log, DateTime? messageDate, int? pageNumber, int? count)
		{
			var request = new RestRequest();
			request.Resource = "Accounts/{AccountSid}/Notifications";

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
		public DeleteStatus DeleteNotification(string notificationSid)
		{
			Require.Argument("NotificationSid", notificationSid);
			var request = new RestRequest(Method.DELETE);
			request.Resource = "Accounts/{AccountSid}/Notifications/{NotificationSid}";

			request.AddParameter("NotificationSid", notificationSid, ParameterType.UrlSegment);

			var response = Execute(request);
			return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
		}
	}
}