using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;

namespace Twilio.TaskRouter
{
    public partial class TaskRouterClient
    {
        /// <summary>
        /// Create an activity.
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="friendlyName">Friendly name.</param>
        /// <param name="available">Available.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void AddActivity(string workspaceSid, string friendlyName, bool available, Action<Activity> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("FriendlyName", friendlyName);

            var request = new RestRequest(Method.POST);
            request.Resource = "Workspaces/{WorkspaceSid}/Activities";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("Available", available);

            ExecuteAsync<Activity>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// Delete an activity.
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="activitySid">Activity sid.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void DeleteActivity(string workspaceSid, string activitySid, Action<DeleteStatus> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("ActivitySid", activitySid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "Workspaces/{WorkspaceSid}/Activities/{ActivitySid}";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("ActivitySid", activitySid);

            ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
        }

        /// <summary>
        /// Retrieve the details for an activity instance. Makes a GET request to an Activity Instance resource.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the activity belongs to</param>
        /// <param name="activitySid">The Sid of the activity to retrieve</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void GetActivity(string workspaceSid, string activitySid, Action<Activity> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("ActivitySid", activitySid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/Activities/{ActivitySid}";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("ActivitySid", activitySid);

            ExecuteAsync<Activity>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// List activities on current workspace.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the activities belong to</param>
        /// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListActivities(string workspaceSid, Action<ActivityResult> callback)
        {
            ListActivities(workspaceSid, null, null, null, null, null, callback);
        }

        /// <summary>
        /// List activities on current workspace with filters
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the activities belong to</param>
        /// <param name="available">Optional available to match</param>
        /// <param name="friendlyName">Optional friendly name to match</param>
        /// <param name="afterSid">Activity Sid to start retrieving results from</param>
        /// <param name="beforeSid">Activity Sid to stop retrieving results from</param>
        /// <param name="count">How many results to return</param>
        /// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListActivities(string workspaceSid, bool? available, string friendlyName, string afterSid, string beforeSid, int? count, Action<ActivityResult> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/Activities";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);

            if (available.HasValue)
                request.AddParameter("Available", available.Value);
            if (friendlyName.HasValue())
                request.AddParameter("FriendlyName", friendlyName);
            if (afterSid.HasValue())
                request.AddParameter("AfterSid", afterSid);
            if (beforeSid.HasValue())
                request.AddParameter("BeforeSid", beforeSid);
            if (count.HasValue)
                request.AddParameter("PageSize", count.Value);

            ExecuteAsync<ActivityResult>(request, callback);
        }

        /// <summary>
        /// Update an activity.
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="activitySid">Activity sid.</param>
        /// <param name="friendlyName">Optional friendly name.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void UpdateActivity(string workspaceSid, string activitySid, string friendlyName, Action<Activity> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("ActivitySid", activitySid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Workspaces/{WorkspaceSid}/Activities/{ActivitySid}";
            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("ActivitySid", activitySid);

            if (friendlyName.HasValue())
                request.AddParameter("FriendlyName", friendlyName);

            ExecuteAsync<Activity>(request, (response) => { callback(response); });
        }
    }
}

