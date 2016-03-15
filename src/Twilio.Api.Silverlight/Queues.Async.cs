using RestSharp;
using System;
using RestSharp.Validation;
namespace Twilio
{
    public partial class TwilioRestClient
    {
        /// <summary>
        /// Return a list of all Queue resources
        /// </summary>
        /// <param name="callback">Method to call upon successful completion</param>
        /// <returns></returns>
		public virtual void ListQueues(Action<QueueResult> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Queues.json";

            ExecuteAsync<QueueResult>(request, (response) => callback(response) );
        }

        /// <summary>
        /// Creates a new Queue resource
        /// </summary>
        /// <param name="friendlyName">The name of the Queue</param>
        /// <param name="callback">Method to call upon successful completion</param>
        /// <returns></returns>
        public virtual void CreateQueue(string friendlyName, Action<Queue> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/Queues.json";

            request.AddParameter("FriendlyName", friendlyName);

            ExecuteAsync<Queue>(request, (response) => callback(response));
        }

        /// <summary>
        /// Creates a new Queue resource
        /// </summary>
        /// <param name="friendlyName">The name of the Queue</param>
        /// <param name="maxSize">The maximum number of calls allowed in the queue</param>
        /// <param name="callback">Method to call upon successful completion</param>
        /// <returns></returns>
        public virtual void CreateQueue(string friendlyName, int maxSize, Action<Queue> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/Queues.json";

            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("MaxSize", maxSize);

            ExecuteAsync<Queue>(request, (response) => callback(response));
        }

        /// <summary>
        /// Locates and returns a specific Queue resource
        /// </summary>
        /// <param name="queueSid">The Sid of the Queue to locate</param>
        /// <param name="callback">Method to call upon successful completion</param>
        /// <returns></returns>
        public virtual void GetQueue(string queueSid, Action<Queue> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Queues/{QueueSid}.json";

            request.AddParameter("QueueSid", queueSid, ParameterType.UrlSegment);

            ExecuteAsync<Queue>(request, (response) => callback(response));
        }

        /// <summary>
        /// Updates a specific Queue resource
        /// </summary>
        /// <param name="queueSid">The Sid of the Queue to update</param>
        /// <param name="friendlyName">The name of the Queue</param>
        /// <param name="maxSize">The maximum number of calls allowed in the queue</param>
        /// <param name="callback">Method to call upon successful completion</param>
        /// <returns></returns>
        public virtual void UpdateQueue(string queueSid, string friendlyName, int maxSize, Action<Queue> callback)
        {
            Require.Argument("QueueSid", queueSid);

            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/Queues/{QueueSid}.json";

            request.AddParameter("QueueSid", queueSid, ParameterType.UrlSegment);
            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("MaxSize", maxSize);

            ExecuteAsync<Queue>(request, (response) => callback(response));
        }

        /// <summary>
        /// Deletes a Queue resource
        /// </summary>
        /// <param name="queueSid">The Sid of the Queue to delete</param>
        /// <param name="callback">Method to call upon successful completion</param>
        /// <returns></returns>
        public virtual void DeleteQueue(string queueSid, Action<DeleteStatus> callback)
        {
            Require.Argument("QueueSid", queueSid);
            var request = new RestRequest(Method.DELETE);
            request.Resource = "Accounts/{AccountSid}/Queues/{QueueSid}.json";

            request.AddParameter("QueueSid", queueSid, ParameterType.UrlSegment);

            ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed); });
        }

        /// <summary>
        /// Return a List of all Calls currently in the the specified Queue
        /// </summary>
        /// <param name="queueSid">The Sid of the Queue to locate</param>
        /// <param name="callback">Method to call upon successful completion</param>
        /// <returns></returns>
		public virtual void ListQueueMembers(string queueSid, Action<QueueMemberResult> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Queues/{QueueSid}/Members.json";

            request.AddParameter("QueueSid", queueSid, ParameterType.UrlSegment);

            ExecuteAsync<QueueMemberResult>(request, (response) => callback(response));
        }

        /// <summary>
        /// Returns the Call in the first position of the wait Queue for the specified Queue
        /// </summary>
        /// <param name="queueSid">The Sid of the Queue to locate</param>
        /// <param name="callback">Method to call upon successful completion</param>
        /// <returns></returns>
        public virtual void GetFirstQueueMember(string queueSid, Action<QueueMember> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Queues/{QueueSid}/Members/Front.json";

            request.AddParameter("QueueSid", queueSid, ParameterType.UrlSegment);

            ExecuteAsync<QueueMember>(request, (response) => callback(response));
        }

        /// <summary>
        /// Locate and return a specific Call in the specified Queue
        /// </summary>
        /// <param name="queueSid">The Sid of the Queue to search</param>
        /// <param name="callSid">The Sid of the Call to locate</param>
        /// <param name="callback">Method to call upon successful completion</param>
        /// <returns></returns>
        public virtual void GetQueueMember(string queueSid, string callSid, Action<QueueMember> callback)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Queues/{QueueSid}/Members/{CallSid}.json";

            request.AddParameter("QueueSid", queueSid, ParameterType.UrlSegment);
            request.AddParameter("CallSid", callSid, ParameterType.UrlSegment);

            ExecuteAsync<QueueMember>(request, (response) => callback(response));
        }

        /// <summary>
        /// Dequeues the Caller in the first wait position for the specified Queue
        /// </summary>
        /// <param name="queueSid">The Sid of the Queue to locate</param>
        /// <param name="url">A Url containing TwiML intructions to execute when the call is dequeued</param>
        /// <param name="callback">Method to call upon successful completion</param>
        /// <returns></returns>
        public virtual void DequeueFirstQueueMember(string queueSid, string url, Action<DequeueStatus> callback)
        {
            DequeueFirstQueueMember(queueSid, url, string.Empty, callback);
        }

        /// <summary>
        /// Dequeues the Caller in the first wait position for the specified Queue
        /// </summary>
        /// <param name="queueSid">The Sid of the Queue to locate</param>
        /// <param name="url">A Url containing TwiML intructions to execute when the call is dequeued</param>
        /// <param name="method">The method to use to request the Url</param>
        /// <param name="callback">Method to call upon successful completion</param>
        /// <returns></returns>
        public virtual void DequeueFirstQueueMember(string queueSid, string url, string method, Action<DequeueStatus> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/Queues/{QueueSid}/Members/Front.json";

            request.AddParameter("QueueSid", queueSid, ParameterType.UrlSegment);
            request.AddParameter("Url", url);
            if (!string.IsNullOrEmpty(method)) { request.AddParameter("Method", method); }

            ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DequeueStatus.Success : DequeueStatus.Failed); });
        }

        /// <summary>
        /// Dequeues a specific Caller in the specified Queue
        /// </summary>
        /// <param name="queueSid">The Sid of the Queue to locate</param>
        /// <param name="callSid">The Sid of the Caller to dequeue</param>
        /// <param name="url">A Url containing TwiML intructions to execute when the call is dequeued</param>
        /// <param name="callback">Method to call upon successful completion</param>
        /// <returns></returns>
        public virtual void DequeueQueueMember(string queueSid, string callSid, string url, Action<DequeueStatus> callback)
        {
            DequeueQueueMember(queueSid, callSid, url, string.Empty, callback);
        }

        /// <summary>
        /// Dequeues a specific Caller in the specified Queue
        /// </summary>
        /// <param name="queueSid">The Sid of the Queue to locate</param>
        /// <param name="callSid">The Sid of the Caller to dequeue</param>
        /// <param name="url">A Url containing TwiML intructions to execute when the call is dequeued</param>
        /// <param name="method">The method to use to request the Url</param>
        /// <param name="callback">Method to call upon successful completion</param>
        /// <returns></returns>
        public virtual void DequeueQueueMember(string queueSid, string callSid, string url, string method, Action<DequeueStatus> callback)
        {
            var request = new RestRequest(Method.POST);
            request.Resource = "Accounts/{AccountSid}/Queues/{QueueSid}/Members/{CallSid}.json";

            request.AddParameter("QueueSid", queueSid, ParameterType.UrlSegment);
            request.AddParameter("CallSid", callSid, ParameterType.UrlSegment);

            request.AddParameter("Url", url);
            if (!string.IsNullOrEmpty(method)) { request.AddParameter("Method", method); }

            ExecuteAsync(request, (response) => { callback(response.StatusCode == System.Net.HttpStatusCode.NoContent ? DequeueStatus.Success : DequeueStatus.Failed); });
        }
    }
}
