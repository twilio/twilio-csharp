using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace.Worker {

    public class ReservationUpdater : Updater<ReservationResource> {
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
        /// <param name="reservationStatus"> The reservation_status </param>
        /// <param name="workerActivitySid"> The worker_activity_sid </param>
        /// <param name="instruction"> The instruction </param>
        /// <param name="dequeuePostWorkActivitySid"> The dequeue_post_work_activity_sid </param>
        /// <param name="dequeueFrom"> The dequeue_from </param>
        /// <param name="dequeueRecord"> The dequeue_record </param>
        /// <param name="dequeueTimeout"> The dequeue_timeout </param>
        /// <param name="dequeueTo"> The dequeue_to </param>
        /// <param name="dequeueStatusCallbackUrl"> The dequeue_status_callback_url </param>
        /// <param name="callFrom"> The call_from </param>
        /// <param name="callRecord"> The call_record </param>
        /// <param name="callTimeout"> The call_timeout </param>
        /// <param name="callTo"> The call_to </param>
        /// <param name="callUrl"> The call_url </param>
        /// <param name="callStatusCallbackUrl"> The call_status_callback_url </param>
        /// <param name="callAccept"> The call_accept </param>
        /// <param name="redirectCallSid"> The redirect_call_sid </param>
        /// <param name="redirectAccept"> The redirect_accept </param>
        /// <param name="redirectUrl"> The redirect_url </param>
        public ReservationUpdater(string workspaceSid, string workerSid, string sid, ReservationResource.Status reservationStatus=null, string workerActivitySid=null, string instruction=null, string dequeuePostWorkActivitySid=null, string dequeueFrom=null, string dequeueRecord=null, int? dequeueTimeout=null, string dequeueTo=null, Uri dequeueStatusCallbackUrl=null, string callFrom=null, string callRecord=null, int? callTimeout=null, string callTo=null, Uri callUrl=null, Uri callStatusCallbackUrl=null, bool? callAccept=null, string redirectCallSid=null, bool? redirectAccept=null, Uri redirectUrl=null) {
            this.dequeueRecord = dequeueRecord;
            this.instruction = instruction;
            this.dequeueFrom = dequeueFrom;
            this.workerSid = workerSid;
            this.workspaceSid = workspaceSid;
            this.callTo = callTo;
            this.redirectCallSid = redirectCallSid;
            this.dequeuePostWorkActivitySid = dequeuePostWorkActivitySid;
            this.redirectAccept = redirectAccept;
            this.sid = sid;
            this.callAccept = callAccept;
            this.dequeueTo = dequeueTo;
            this.callStatusCallbackUrl = callStatusCallbackUrl;
            this.redirectUrl = redirectUrl;
            this.callTimeout = callTimeout;
            this.workerActivitySid = workerActivitySid;
            this.callUrl = callUrl;
            this.callFrom = callFrom;
            this.callRecord = callRecord;
            this.reservationStatus = reservationStatus;
            this.dequeueStatusCallbackUrl = dequeueStatusCallbackUrl;
            this.dequeueTimeout = dequeueTimeout;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated ReservationResource </returns> 
        public override async Task<ReservationResource> UpdateAsync(ITwilioRestClient client) {
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
        public override ReservationResource Update(ITwilioRestClient client) {
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
        private void AddPostParams(Request request) {
            if (reservationStatus != null) {
                request.AddPostParam("ReservationStatus", reservationStatus.ToString());
            }
            
            if (workerActivitySid != null) {
                request.AddPostParam("WorkerActivitySid", workerActivitySid);
            }
            
            if (instruction != null) {
                request.AddPostParam("Instruction", instruction);
            }
            
            if (dequeuePostWorkActivitySid != null) {
                request.AddPostParam("DequeuePostWorkActivitySid", dequeuePostWorkActivitySid);
            }
            
            if (dequeueFrom != null) {
                request.AddPostParam("DequeueFrom", dequeueFrom);
            }
            
            if (dequeueRecord != null) {
                request.AddPostParam("DequeueRecord", dequeueRecord);
            }
            
            if (dequeueTimeout != null) {
                request.AddPostParam("DequeueTimeout", dequeueTimeout.ToString());
            }
            
            if (dequeueTo != null) {
                request.AddPostParam("DequeueTo", dequeueTo);
            }
            
            if (dequeueStatusCallbackUrl != null) {
                request.AddPostParam("DequeueStatusCallbackUrl", dequeueStatusCallbackUrl.ToString());
            }
            
            if (callFrom != null) {
                request.AddPostParam("CallFrom", callFrom);
            }
            
            if (callRecord != null) {
                request.AddPostParam("CallRecord", callRecord);
            }
            
            if (callTimeout != null) {
                request.AddPostParam("CallTimeout", callTimeout.ToString());
            }
            
            if (callTo != null) {
                request.AddPostParam("CallTo", callTo);
            }
            
            if (callUrl != null) {
                request.AddPostParam("CallUrl", callUrl.ToString());
            }
            
            if (callStatusCallbackUrl != null) {
                request.AddPostParam("CallStatusCallbackUrl", callStatusCallbackUrl.ToString());
            }
            
            if (callAccept != null) {
                request.AddPostParam("CallAccept", callAccept.ToString());
            }
            
            if (redirectCallSid != null) {
                request.AddPostParam("RedirectCallSid", redirectCallSid);
            }
            
            if (redirectAccept != null) {
                request.AddPostParam("RedirectAccept", redirectAccept.ToString());
            }
            
            if (redirectUrl != null) {
                request.AddPostParam("RedirectUrl", redirectUrl.ToString());
            }
        }
    }
}