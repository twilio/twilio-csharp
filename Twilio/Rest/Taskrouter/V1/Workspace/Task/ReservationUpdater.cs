using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Task 
{

    public class ReservationUpdater : Updater<ReservationResource> 
    {
        public string WorkspaceSid { get; }
        public string TaskSid { get; }
        public string Sid { get; }
        public ReservationResource.StatusEnum ReservationStatus { get; set; }
        public string WorkerActivitySid { get; set; }
        public string Instruction { get; set; }
        public string DequeuePostWorkActivitySid { get; set; }
        public string DequeueFrom { get; set; }
        public string DequeueRecord { get; set; }
        public int? DequeueTimeout { get; set; }
        public string DequeueTo { get; set; }
        public Uri DequeueStatusCallbackUrl { get; set; }
        public string CallFrom { get; set; }
        public string CallRecord { get; set; }
        public int? CallTimeout { get; set; }
        public string CallTo { get; set; }
        public Uri CallUrl { get; set; }
        public Uri CallStatusCallbackUrl { get; set; }
        public bool? CallAccept { get; set; }
        public string RedirectCallSid { get; set; }
        public bool? RedirectAccept { get; set; }
        public Uri RedirectUrl { get; set; }
    
        /// <summary>
        /// Construct a new ReservationUpdater
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="taskSid"> The task_sid </param>
        /// <param name="sid"> The sid </param>
        public ReservationUpdater(string workspaceSid, string taskSid, string sid)
        {
            WorkspaceSid = workspaceSid;
            TaskSid = taskSid;
            Sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ReservationResource </returns> 
        public override async System.Threading.Tasks.Task<ReservationResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + WorkspaceSid + "/Tasks/" + TaskSid + "/Reservations/" + Sid + ""
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("ReservationResource update failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return ReservationResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ReservationResource </returns> 
        public override ReservationResource Update(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + WorkspaceSid + "/Tasks/" + TaskSid + "/Reservations/" + Sid + ""
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ReservationResource update failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return ReservationResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (ReservationStatus != null)
            {
                request.AddPostParam("ReservationStatus", ReservationStatus.ToString());
            }
            
            if (WorkerActivitySid != null)
            {
                request.AddPostParam("WorkerActivitySid", WorkerActivitySid);
            }
            
            if (Instruction != null)
            {
                request.AddPostParam("Instruction", Instruction);
            }
            
            if (DequeuePostWorkActivitySid != null)
            {
                request.AddPostParam("DequeuePostWorkActivitySid", DequeuePostWorkActivitySid);
            }
            
            if (DequeueFrom != null)
            {
                request.AddPostParam("DequeueFrom", DequeueFrom);
            }
            
            if (DequeueRecord != null)
            {
                request.AddPostParam("DequeueRecord", DequeueRecord);
            }
            
            if (DequeueTimeout != null)
            {
                request.AddPostParam("DequeueTimeout", DequeueTimeout.ToString());
            }
            
            if (DequeueTo != null)
            {
                request.AddPostParam("DequeueTo", DequeueTo);
            }
            
            if (DequeueStatusCallbackUrl != null)
            {
                request.AddPostParam("DequeueStatusCallbackUrl", DequeueStatusCallbackUrl.ToString());
            }
            
            if (CallFrom != null)
            {
                request.AddPostParam("CallFrom", CallFrom);
            }
            
            if (CallRecord != null)
            {
                request.AddPostParam("CallRecord", CallRecord);
            }
            
            if (CallTimeout != null)
            {
                request.AddPostParam("CallTimeout", CallTimeout.ToString());
            }
            
            if (CallTo != null)
            {
                request.AddPostParam("CallTo", CallTo);
            }
            
            if (CallUrl != null)
            {
                request.AddPostParam("CallUrl", CallUrl.ToString());
            }
            
            if (CallStatusCallbackUrl != null)
            {
                request.AddPostParam("CallStatusCallbackUrl", CallStatusCallbackUrl.ToString());
            }
            
            if (CallAccept != null)
            {
                request.AddPostParam("CallAccept", CallAccept.ToString());
            }
            
            if (RedirectCallSid != null)
            {
                request.AddPostParam("RedirectCallSid", RedirectCallSid);
            }
            
            if (RedirectAccept != null)
            {
                request.AddPostParam("RedirectAccept", RedirectAccept.ToString());
            }
            
            if (RedirectUrl != null)
            {
                request.AddPostParam("RedirectUrl", RedirectUrl.ToString());
            }
        }
    }
}