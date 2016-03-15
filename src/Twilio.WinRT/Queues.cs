using RestRT;
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
        /// Return a list of all Queue resources
        /// </summary>
        /// <returns></returns>
        public IAsyncOperation<QueueResult> ListQueuesAsync()
        {
            return (IAsyncOperation<QueueResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListQueuesAsyncInternal());
        }
        private async Task<QueueResult> ListQueuesAsyncInternal()
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Queues.json";

            var result = await ExecuteAsync(request, typeof(QueueResult));
            return (QueueResult)result;
        }

        /// <summary>
        /// Creates a new Queue resource
        /// </summary>
        /// <param name="friendlyName">The name of the Queue</param>
        /// <returns></returns>
        public IAsyncOperation<Queue> CreateQueueAsync(string friendlyName)
        {
            return (IAsyncOperation<Queue>)AsyncInfo.Run((System.Threading.CancellationToken ct) => CreateQueueAsyncInternal(friendlyName));
        }
        private async Task<Queue> CreateQueueAsyncInternal(string friendlyName)
        {
            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "Accounts/{AccountSid}/Queues.json";

            request.AddParameter("FriendlyName", friendlyName);

            var result = await ExecuteAsync(request, typeof(Queue));
            return (Queue)result;

        }

        /// <summary>
        /// Creates a new Queue resource
        /// </summary>
        /// <param name="friendlyName">The name of the Queue</param>
        /// <param name="maxSize">The maximum number of calls allowed in the queue</param>
        /// <returns></returns>
        public IAsyncOperation<Queue> CreateQueueAsync(string friendlyName, int maxSize)
        {
            return (IAsyncOperation<Queue>)AsyncInfo.Run((System.Threading.CancellationToken ct) => CreateQueueAsyncInternal(friendlyName, maxSize));
        }
        private async Task<Queue> CreateQueueAsyncInternal(string friendlyName, int maxSize)
        {
            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "Accounts/{AccountSid}/Queues.json";

            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("MaxSize", maxSize);

            var result = await ExecuteAsync(request, typeof(Queue));
            return (Queue)result;

        }

        /// <summary>
        /// Locates and returns a specific Queue resource
        /// </summary>
        /// <param name="queueSid">The Sid of the Queue to locate</param>
        /// <returns></returns>
        public IAsyncOperation<Queue> GetQueueAsync(string queueSid)
        {
            return (IAsyncOperation<Queue>)AsyncInfo.Run((System.Threading.CancellationToken ct) => GetQueueAsyncInternal(queueSid));
        }
        private async Task<Queue> GetQueueAsyncInternal(string queueSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Queues/{QueueSid}.json";

            request.AddParameter("QueueSid", queueSid, ParameterType.UrlSegment);

            var result = await ExecuteAsync(request, typeof(Queue));
            return (Queue)result;

        }

        /// <summary>
        /// Updates a specific Queue resource
        /// </summary>
        /// <param name="queueSid">The Sid of the Queue to update</param>
        /// <param name="friendlyName">The name of the Queue</param>
        /// <param name="maxSize">The maximum number of calls allowed in the queue</param>
        /// <returns></returns>
        public IAsyncOperation<Queue> UpdateQueueAsync(string queueSid, string friendlyName, int maxSize)
        {
            return (IAsyncOperation<Queue>)AsyncInfo.Run((System.Threading.CancellationToken ct) => UpdateQueueAsyncInternal(queueSid, friendlyName, maxSize));
        }
        private async Task<Queue> UpdateQueueAsyncInternal(string queueSid, string friendlyName, int maxSize)
        {
            Require.Argument("QueueSid", queueSid);

            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "Accounts/{AccountSid}/Queues/{QueueSid}.json";

            request.AddParameter("QueueSid", queueSid, ParameterType.UrlSegment);
            request.AddParameter("FriendlyName", friendlyName);
            request.AddParameter("MaxSize", maxSize);

            var result = await ExecuteAsync(request, typeof(Queue));
            return (Queue)result;

        }

        /// <summary>
        /// Deletes a Queue resource
        /// </summary>
        /// <param name="queueSid">The Sid of the Queue to delete</param>
        /// <returns></returns>
        public IAsyncOperation<DeleteStatus> DeleteQueueAsync(string queueSid)
        {
            return (IAsyncOperation<DeleteStatus>)AsyncInfo.Run((System.Threading.CancellationToken ct) => DeleteQueueAsyncInternal(queueSid));
        }
        private async Task<DeleteStatus> DeleteQueueAsyncInternal(string queueSid)
        {
            Require.Argument("QueueSid", queueSid);
            var request = new RestRequest();
            request.Method = Method.DELETE;
            request.Resource = "Accounts/{AccountSid}/Queues/{QueueSid}.json";

            request.AddParameter("QueueSid", queueSid, ParameterType.UrlSegment);

            var response = (RestResponse)await ExecuteAsync(request);
            return response.StatusCode == (int)System.Net.HttpStatusCode.NoContent ? DeleteStatus.Success : DeleteStatus.Failed;
        }

        /// <summary>
        /// Return a List of all Calls currently in the the specified Queue
        /// </summary>
        /// <param name="queueSid">The Sid of the Queue to locate</param>
        /// <returns></returns>
		public IAsyncOperation<QueueMemberResult> ListQueueMembersAsync(string queueSid)
        {
            return (IAsyncOperation<QueueMemberResult>)AsyncInfo.Run((System.Threading.CancellationToken ct) => ListQueueMembersAsyncInternal(queueSid));
        }
        private async Task<QueueMemberResult> ListQueueMembersAsyncInternal(string queueSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Queues/{QueueSid}/Members.json";

            request.AddParameter("QueueSid", queueSid, ParameterType.UrlSegment);

            var result = await ExecuteAsync(request, typeof(QueueMemberResult));
            return (QueueMemberResult)result;

        }

        /// <summary>
        /// Returns the Call in the first position of the wait Queue for the specified Queue
        /// </summary>
        /// <param name="queueSid">The Sid of the Queue to locate</param>
        /// <returns></returns>
        public IAsyncOperation<QueueMember> GetFirstQueueMemberAsync(string queueSid)
        {
            return (IAsyncOperation<QueueMember>)AsyncInfo.Run((System.Threading.CancellationToken ct) => GetFirstQueueMemberAsyncInternal(queueSid));
        }
        private async Task<QueueMember> GetFirstQueueMemberAsyncInternal(string queueSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Queues/{QueueSid}/Members/Front.json";

            request.AddParameter("QueueSid", queueSid, ParameterType.UrlSegment);

            var result = await ExecuteAsync(request, typeof(QueueMember));
            return (QueueMember)result;

        }


        /// <summary>
        /// Locate and return a specific Call in the specified Queue
        /// </summary>
        /// <param name="queueSid">The Sid of the Queue to search</param>
        /// <param name="callSid">The Sid of the Call to locate</param>
        /// <returns></returns>
        public IAsyncOperation<QueueMember> GetQueueMemberAsync(string queueSid, string callSid)
        {
            return (IAsyncOperation<QueueMember>)AsyncInfo.Run((System.Threading.CancellationToken ct) => GetQueueMemberAsyncInternal(queueSid, callSid));
        }
        private async Task<QueueMember> GetQueueMemberAsyncInternal(string queueSid, string callSid)
        {
            var request = new RestRequest();
            request.Resource = "Accounts/{AccountSid}/Queues/{QueueSid}/Members/{CallSid}.json";

            request.AddParameter("QueueSid", queueSid, ParameterType.UrlSegment);
            request.AddParameter("CallSid", callSid, ParameterType.UrlSegment);

            var result = await ExecuteAsync(request, typeof(QueueMember));
            return (QueueMember)result;

        }

        /// <summary>
        /// Dequeues the Caller in the first wait position for the specified Queue
        /// </summary>
        /// <param name="queueSid">The Sid of the Queue to locate</param>
        /// <param name="url">A Url containing TwiML intructions to execute when the call is dequeued</param>
        /// <returns></returns>
        public IAsyncOperation<DequeueStatus> DequeueFirstQueueMemberAsync(string queueSid, string url)
        {
            return (IAsyncOperation<DequeueStatus>)AsyncInfo.Run((System.Threading.CancellationToken ct) => DequeueFirstQueueMemberAsyncInternal(queueSid, url, string.Empty));
        }

        /// <summary>
        /// Dequeues the Caller in the first wait position for the specified Queue
        /// </summary>
        /// <param name="queueSid">The Sid of the Queue to locate</param>
        /// <param name="url">A Url containing TwiML intructions to execute when the call is dequeued</param>
        /// <param name="method">The method to use to request the Url</param>
        /// <returns></returns>
        public IAsyncOperation<DequeueStatus> DequeueFirstQueueMemberAsync(string queueSid, string url, string method)
        {
            return (IAsyncOperation<DequeueStatus>)AsyncInfo.Run((System.Threading.CancellationToken ct) => DequeueFirstQueueMemberAsyncInternal(queueSid, url, method));
        }
        private async Task<DequeueStatus> DequeueFirstQueueMemberAsyncInternal(string queueSid, string url, string method)
        {
            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "Accounts/{AccountSid}/Queues/{QueueSid}/Members/Front.json";

            request.AddParameter("QueueSid", queueSid, ParameterType.UrlSegment);
            request.AddParameter("Url", url);
            if (!string.IsNullOrEmpty(method)) { request.AddParameter("Method", method); }

            var response = (RestResponse)await ExecuteAsync(request);
            return response.StatusCode == (int)System.Net.HttpStatusCode.OK ? DequeueStatus.Success : DequeueStatus.Failed;
        }

        /// <summary>
        /// Dequeues a specific Caller in the specified Queue
        /// </summary>
        /// <param name="queueSid">The Sid of the Queue to locate</param>
        /// <param name="callSid">The Sid of the Caller to dequeue</param>
        /// <param name="url">A Url containing TwiML intructions to execute when the call is dequeued</param>
        /// <returns></returns>
        public IAsyncOperation<DequeueStatus> DequeueQueueMemberAsync(string queueSid, string callSid, string url)
        {
            return (IAsyncOperation<DequeueStatus>)AsyncInfo.Run((System.Threading.CancellationToken ct) => DequeueQueueMemberAsyncInternal(queueSid, callSid, url, string.Empty));
        }

        /// <summary>
        /// Dequeues a specific Caller in the specified Queue
        /// </summary>
        /// <param name="queueSid">The Sid of the Queue to locate</param>
        /// <param name="callSid">The Sid of the Caller to dequeue</param>
        /// <param name="url">A Url containing TwiML intructions to execute when the call is dequeued</param>
        /// <param name="method">The method to use to request the Url</param>
        /// <returns></returns>
        public IAsyncOperation<DequeueStatus> DequeueQueueMemberAsync(string queueSid, string callSid, string url, string method)
        {
            return (IAsyncOperation<DequeueStatus>)AsyncInfo.Run((System.Threading.CancellationToken ct) => DequeueQueueMemberAsyncInternal(queueSid, callSid, url, method));
        }
        private async Task<DequeueStatus> DequeueQueueMemberAsyncInternal(string queueSid, string callSid, string url, string method)
        {
            var request = new RestRequest();
            request.Method = Method.POST;
            request.Resource = "Accounts/{AccountSid}/Queues/{QueueSid}/Members/{CallSid}.json";

            request.AddParameter("QueueSid", queueSid, ParameterType.UrlSegment);
            request.AddParameter("CallSid", callSid, ParameterType.UrlSegment);

            request.AddParameter("Url", url);
            if (!string.IsNullOrEmpty(method)) { request.AddParameter("Method", method); }

            var response = (RestResponse)await ExecuteAsync(request);
            return response.StatusCode == (int)System.Net.HttpStatusCode.OK ? DequeueStatus.Success : DequeueStatus.Failed;
        }
    }
}
