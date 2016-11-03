using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace.Worker 
{

    public class ReservationUpdater : Updater<ReservationResource> 
    {
        public string workspaceSid { get; }
        public string workerSid { get; }
        public string sid { get; }
        public ReservationResource.Status reservationStatus { get; set; }
        public string workerActivitySid { get; set; }
        public string instruction { get; set; }
        public string dequeuePostWorkActivitySid { get; set; }
        public string dequeueFrom { get; set; }
        public string dequeueRecord { get; set; }
        public int? dequeueTimeout { get; set; }
        public string dequeueTo { get; set; }
        public Uri dequeueStatusCallbackUrl { get; set; }
        public string callFrom { get; set; }
        public string callRecord { get; set; }
        public int? callTimeout { get; set; }
        public string callTo { get; set; }
        public Uri callUrl { get; set; }
        public Uri callStatusCallbackUrl { get; set; }
        public bool? callAccept { get; set; }
        public string redirectCallSid { get; set; }
        public bool? redirectAccept { get; set; }
        public Uri redirectUrl { get; set; }
    
        /// <summary>
        /// Construct a new ReservationUpdater
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workerSid"> The worker_sid </param>
        /// <param name="sid"> The sid </param>
        public ReservationUpdater(string workspaceSid, string workerSid, string sid)
        {
            this.workspaceSid = workspaceSid;
            this.workerSid = workerSid;
            this.sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ReservationResource </returns> 
        public override async Task<ReservationResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workers/" + this.workerSid + "/Reservations/" + this.sid + ""
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
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workers/" + this.workerSid + "/Reservations/" + this.sid + ""
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
            if (reservationStatus != null)
            {
                request.AddPostParam("ReservationStatus", reservationStatus.ToString());
            }
            
            if (workerActivitySid != null)
            {
                request.AddPostParam("WorkerActivitySid", workerActivitySid);
            }
            
            if (instruction != null)
            {
                request.AddPostParam("Instruction", instruction);
            }
            
            if (dequeuePostWorkActivitySid != null)
            {
                request.AddPostParam("DequeuePostWorkActivitySid", dequeuePostWorkActivitySid);
            }
            
            if (dequeueFrom != null)
            {
                request.AddPostParam("DequeueFrom", dequeueFrom);
            }
            
            if (dequeueRecord != null)
            {
                request.AddPostParam("DequeueRecord", dequeueRecord);
            }
            
            if (dequeueTimeout != null)
            {
                request.AddPostParam("DequeueTimeout", dequeueTimeout.ToString());
            }
            
            if (dequeueTo != null)
            {
                request.AddPostParam("DequeueTo", dequeueTo);
            }
            
            if (dequeueStatusCallbackUrl != null)
            {
                request.AddPostParam("DequeueStatusCallbackUrl", dequeueStatusCallbackUrl.ToString());
            }
            
            if (callFrom != null)
            {
                request.AddPostParam("CallFrom", callFrom);
            }
            
            if (callRecord != null)
            {
                request.AddPostParam("CallRecord", callRecord);
            }
            
            if (callTimeout != null)
            {
                request.AddPostParam("CallTimeout", callTimeout.ToString());
            }
            
            if (callTo != null)
            {
                request.AddPostParam("CallTo", callTo);
            }
            
            if (callUrl != null)
            {
                request.AddPostParam("CallUrl", callUrl.ToString());
            }
            
            if (callStatusCallbackUrl != null)
            {
                request.AddPostParam("CallStatusCallbackUrl", callStatusCallbackUrl.ToString());
            }
            
            if (callAccept != null)
            {
                request.AddPostParam("CallAccept", callAccept.ToString());
            }
            
            if (redirectCallSid != null)
            {
                request.AddPostParam("RedirectCallSid", redirectCallSid);
            }
            
            if (redirectAccept != null)
            {
                request.AddPostParam("RedirectAccept", redirectAccept.ToString());
            }
            
            if (redirectUrl != null)
            {
                request.AddPostParam("RedirectUrl", redirectUrl.ToString());
            }
        }
    }
}