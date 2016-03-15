using System;
using RestSharp;
using RestSharp.Extensions;
using RestSharp.Validation;
using System.Collections.Generic;

namespace Twilio.TaskRouter
{
    public partial class TaskRouterClient
    {
        /// <summary>
        /// Create a worker.
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="friendlyName">Friendly name.</param>
        /// <param name="activitySid">Optional activity sid.</param>
        /// <param name="attributes">Optional attributes.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void AddWorker(string workspaceSid, string friendlyName, string activitySid, string attributes, Action<Worker> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("FriendlyName", friendlyName);

            var request = new RestRequest(Method.POST);
            request.Resource = "Workspaces/{WorkspaceSid}/Workers";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("ActivitySid", activitySid);
            request.AddParameter("Attributes", attributes);

            ExecuteAsync<Worker>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// Create a worker.
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="friendlyName">Friendly name.</param>
        /// <param name="activitySid">Optional activity sid.</param>
        /// <param name="attributes">Optional attributes.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void AddWorker(string workspaceSid, string friendlyName, string activitySid, Dictionary<string,string> attributes, Action<Worker> callback)
        {
            string workerAttributesJSON = FromDictionaryToJson(attributes);
            this.AddWorker(workspaceSid, friendlyName, activitySid, workerAttributesJSON, callback);
        }

        /// <summary>
        /// Delete a worker.
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="workerSid">Worker sid.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void DeleteWorker(string workspaceSid, string workerSid, Action<DeleteStatus> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("WorkerSid", workerSid);

            var request = new RestRequest(Method.DELETE);
            request.Resource = "Workspaces/{WorkspaceSid}/Workers/{WorkerSid}";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("WorkerSid", workerSid);

            ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
        }

        /// <summary>
        /// Retrieve the details for a worker instance. Makes a GET request to a Worker Instance resource.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the worker belongs to</param>
        /// <param name="workerSid">The Sid of the worker to retrieve</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void GetWorker(string workspaceSid, string workerSid, Action<Worker> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("WorkerSid", workerSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/Workers/{WorkerSid}";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("WorkerSid", workerSid);

            ExecuteAsync<Worker>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// List workers on current workspace.
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the workers belong to</param>
        /// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListWorkers(string workspaceSid, Action<WorkerResult> callback)
        {
            ListWorkers(workspaceSid, new WorkerListRequest(), callback);
        }

        /// <summary>
        /// List workers on current workspace with filters
        /// </summary>
        /// <param name="workspaceSid">The Sid of the workspace the workers belong to</param>
        /// <param name="options">List filter options. If an property is set the list will be filtered by that value.</param>
        /// <param name="callback">Method to call upon successful completion</param>
		public virtual void ListWorkers(string workspaceSid, WorkerListRequest options, Action<WorkerResult> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);

            var request = new RestRequest();
            request.Resource = "Workspaces/{WorkspaceSid}/Workers";

            request.AddUrlSegment("WorkspaceSid", workspaceSid);

            AddWorkerListOptions(options, request);

            ExecuteAsync<WorkerResult>(request, callback);
        }

        /// <summary>
        /// Update a worker.
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="workerSid">Worker sid.</param>
        /// <param name="activitySid">Optional activity sid.</param>
        /// <param name="attributes">Optional attributes.</param>
        /// <param name="friendlyName">Optional friendly name.</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void UpdateWorker(string workspaceSid, string workerSid, string activitySid, string attributes, string friendlyName, Action<Worker> callback)
        {
            Require.Argument("WorkspaceSid", workspaceSid);
            Require.Argument("WorkerSid", workerSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Workspaces/{WorkspaceSid}/Workers/{WorkerSid}";
            request.AddUrlSegment("WorkspaceSid", workspaceSid);
            request.AddUrlSegment("WorkerSid", workerSid);

            if (activitySid.HasValue())
                request.AddParameter("ActivitySid", activitySid);
            if (attributes.HasValue())
                request.AddParameter("Attributes", attributes);
            if (friendlyName.HasValue())
                request.AddParameter("FriendlyName", friendlyName);

            ExecuteAsync<Worker>(request, (response) => { callback(response); });
        }

        /// <summary>
        /// Update a worker properties
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="workerSid">Worker sid.</param>
        /// <param name="attributes">Optional attributes</param>
        /// <param name="friendlyName">Optional friendly name</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void UpdateWorker(string workspaceSid, string workerSid, Dictionary<string,string> attributes, string friendlyName, Action<Worker> callback)
        {
            string workerAttributesJSON = FromDictionaryToJson(attributes);
            this.UpdateWorker(workspaceSid, workerSid, null, workerAttributesJSON, friendlyName, callback);
        }

        /// <summary>
        /// Update a worker activity
        /// </summary>
        /// <param name="workspaceSid">Workspace sid.</param>
        /// <param name="workerSid">Worker sid.</param>
        /// <param name="activitySid">Activity Sid</param>
        /// <param name="callback">Method to call upon successful completion</param>
        public virtual void UpdateWorkerActivity(string workspaceSid, string workerSid, string activitySid, Action<Worker> callback)
        {
            this.UpdateWorker(workspaceSid, workerSid, activitySid, null, null, callback);
        }
    }
}

