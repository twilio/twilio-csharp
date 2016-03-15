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
        /// <param name="available">Optional available.</param>
        public virtual Activity AddActivity(string workspaceSid, string friendlyName, bool available)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("FriendlyName", friendlyName);

            var request = new RestRequest(Method.POST);
            request.Resource = "Workspaces/{WorkspaceSid}/Activities";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("Available", available);

            return Execute<Activity>(request);
        }

        /// <summary>
        /// Delete an activity.
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="activitySid">Activity sid.</param>
        public virtual DeleteStatus DeleteActivity(string workspaceSid, string activitySid)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("ActivitySid", activitySid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "Workspaces/{WorkspaceSid}/Activities/{ActivitySid}";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("ActivitySid", activitySid);

            var response = Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }

        /// <summary>
        /// Retrieve the details for an activity instance. Makes a GET request to an Activity Instance resource.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the activity belongs to</param>
        /// <param name="activitySid">The Sid of the activity to retrieve</param>
        public virtual Activity GetActivity(string workspaceSid, string activitySid)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("ActivitySid", activitySid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/Activities/{ActivitySid}";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("ActivitySid", activitySid);

            return Execute<Activity>(request);
        }

        /// <summary>
        /// List activities on current workspace.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the activities belong to</param>
		public virtual ActivityResult ListActivities(string workspaceSid)
        {
            return ListActivities(workspaceSid, null, null, null, null, null);
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
		public virtual ActivityResult ListActivities(string workspaceSid, bool? available, string friendlyName, string afterSid, string beforeSid, int? count)
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

            return Execute<ActivityResult>(request);
        }

        /// <summary>
        /// Update an activity.
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="activitySid">Activity sid.</param>
        /// <param name="friendlyName">Optional friendly name.</param>
        public virtual Activity UpdateActivity(string workspaceSid, string activitySid, string friendlyName)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("ActivitySid", activitySid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Workspaces/{WorkspaceSid}/Activities/{ActivitySid}";
            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("ActivitySid", activitySid);

            if (friendlyName.HasValue())
                request.AddParameter("FriendlyName", friendlyName);

            return Execute<Activity>(request);
        }
    }
}
