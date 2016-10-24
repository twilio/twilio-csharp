using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace.Task {

    public class ReservationUpdater : Updater<ReservationResource> {
        public string workspaceSid { get; }
        public string taskSid { get; }
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
        /// <param name="taskSid"> The task_sid </param>
        /// <param name="sid"> The sid </param>
        public ReservationUpdater(string workspaceSid, string taskSid, string sid) {
            this.workspaceSid = workspaceSid;
            this.taskSid = taskSid;
            this.sid = sid;
        }
    
        /// <summary>
        /// The reservation_status
        /// </summary>
        ///
        /// <param name="reservationStatus"> The reservation_status </param>
        /// <returns> this </returns> 
        public ReservationUpdater setReservationStatus(ReservationResource.Status reservationStatus) {
            this.reservationStatus = reservationStatus;
            return this;
        }
    
        /// <summary>
        /// The worker_activity_sid
        /// </summary>
        ///
        /// <param name="workerActivitySid"> The worker_activity_sid </param>
        /// <returns> this </returns> 
        public ReservationUpdater setWorkerActivitySid(string workerActivitySid) {
            this.workerActivitySid = workerActivitySid;
            return this;
        }
    
        /// <summary>
        /// The instruction
        /// </summary>
        ///
        /// <param name="instruction"> The instruction </param>
        /// <returns> this </returns> 
        public ReservationUpdater setInstruction(string instruction) {
            this.instruction = instruction;
            return this;
        }
    
        /// <summary>
        /// The dequeue_post_work_activity_sid
        /// </summary>
        ///
        /// <param name="dequeuePostWorkActivitySid"> The dequeue_post_work_activity_sid </param>
        /// <returns> this </returns> 
        public ReservationUpdater setDequeuePostWorkActivitySid(string dequeuePostWorkActivitySid) {
            this.dequeuePostWorkActivitySid = dequeuePostWorkActivitySid;
            return this;
        }
    
        /// <summary>
        /// The dequeue_from
        /// </summary>
        ///
        /// <param name="dequeueFrom"> The dequeue_from </param>
        /// <returns> this </returns> 
        public ReservationUpdater setDequeueFrom(string dequeueFrom) {
            this.dequeueFrom = dequeueFrom;
            return this;
        }
    
        /// <summary>
        /// The dequeue_record
        /// </summary>
        ///
        /// <param name="dequeueRecord"> The dequeue_record </param>
        /// <returns> this </returns> 
        public ReservationUpdater setDequeueRecord(string dequeueRecord) {
            this.dequeueRecord = dequeueRecord;
            return this;
        }
    
        /// <summary>
        /// The dequeue_timeout
        /// </summary>
        ///
        /// <param name="dequeueTimeout"> The dequeue_timeout </param>
        /// <returns> this </returns> 
        public ReservationUpdater setDequeueTimeout(int? dequeueTimeout) {
            this.dequeueTimeout = dequeueTimeout;
            return this;
        }
    
        /// <summary>
        /// The dequeue_to
        /// </summary>
        ///
        /// <param name="dequeueTo"> The dequeue_to </param>
        /// <returns> this </returns> 
        public ReservationUpdater setDequeueTo(string dequeueTo) {
            this.dequeueTo = dequeueTo;
            return this;
        }
    
        /// <summary>
        /// The dequeue_status_callback_url
        /// </summary>
        ///
        /// <param name="dequeueStatusCallbackUrl"> The dequeue_status_callback_url </param>
        /// <returns> this </returns> 
        public ReservationUpdater setDequeueStatusCallbackUrl(Uri dequeueStatusCallbackUrl) {
            this.dequeueStatusCallbackUrl = dequeueStatusCallbackUrl;
            return this;
        }
    
        /// <summary>
        /// The dequeue_status_callback_url
        /// </summary>
        ///
        /// <param name="dequeueStatusCallbackUrl"> The dequeue_status_callback_url </param>
        /// <returns> this </returns> 
        public ReservationUpdater setDequeueStatusCallbackUrl(string dequeueStatusCallbackUrl) {
            return setDequeueStatusCallbackUrl(Promoter.UriFromString(dequeueStatusCallbackUrl));
        }
    
        /// <summary>
        /// The call_from
        /// </summary>
        ///
        /// <param name="callFrom"> The call_from </param>
        /// <returns> this </returns> 
        public ReservationUpdater setCallFrom(string callFrom) {
            this.callFrom = callFrom;
            return this;
        }
    
        /// <summary>
        /// The call_record
        /// </summary>
        ///
        /// <param name="callRecord"> The call_record </param>
        /// <returns> this </returns> 
        public ReservationUpdater setCallRecord(string callRecord) {
            this.callRecord = callRecord;
            return this;
        }
    
        /// <summary>
        /// The call_timeout
        /// </summary>
        ///
        /// <param name="callTimeout"> The call_timeout </param>
        /// <returns> this </returns> 
        public ReservationUpdater setCallTimeout(int? callTimeout) {
            this.callTimeout = callTimeout;
            return this;
        }
    
        /// <summary>
        /// The call_to
        /// </summary>
        ///
        /// <param name="callTo"> The call_to </param>
        /// <returns> this </returns> 
        public ReservationUpdater setCallTo(string callTo) {
            this.callTo = callTo;
            return this;
        }
    
        /// <summary>
        /// The call_url
        /// </summary>
        ///
        /// <param name="callUrl"> The call_url </param>
        /// <returns> this </returns> 
        public ReservationUpdater setCallUrl(Uri callUrl) {
            this.callUrl = callUrl;
            return this;
        }
    
        /// <summary>
        /// The call_url
        /// </summary>
        ///
        /// <param name="callUrl"> The call_url </param>
        /// <returns> this </returns> 
        public ReservationUpdater setCallUrl(string callUrl) {
            return setCallUrl(Promoter.UriFromString(callUrl));
        }
    
        /// <summary>
        /// The call_status_callback_url
        /// </summary>
        ///
        /// <param name="callStatusCallbackUrl"> The call_status_callback_url </param>
        /// <returns> this </returns> 
        public ReservationUpdater setCallStatusCallbackUrl(Uri callStatusCallbackUrl) {
            this.callStatusCallbackUrl = callStatusCallbackUrl;
            return this;
        }
    
        /// <summary>
        /// The call_status_callback_url
        /// </summary>
        ///
        /// <param name="callStatusCallbackUrl"> The call_status_callback_url </param>
        /// <returns> this </returns> 
        public ReservationUpdater setCallStatusCallbackUrl(string callStatusCallbackUrl) {
            return setCallStatusCallbackUrl(Promoter.UriFromString(callStatusCallbackUrl));
        }
    
        /// <summary>
        /// The call_accept
        /// </summary>
        ///
        /// <param name="callAccept"> The call_accept </param>
        /// <returns> this </returns> 
        public ReservationUpdater setCallAccept(bool? callAccept) {
            this.callAccept = callAccept;
            return this;
        }
    
        /// <summary>
        /// The redirect_call_sid
        /// </summary>
        ///
        /// <param name="redirectCallSid"> The redirect_call_sid </param>
        /// <returns> this </returns> 
        public ReservationUpdater setRedirectCallSid(string redirectCallSid) {
            this.redirectCallSid = redirectCallSid;
            return this;
        }
    
        /// <summary>
        /// The redirect_accept
        /// </summary>
        ///
        /// <param name="redirectAccept"> The redirect_accept </param>
        /// <returns> this </returns> 
        public ReservationUpdater setRedirectAccept(bool? redirectAccept) {
            this.redirectAccept = redirectAccept;
            return this;
        }
    
        /// <summary>
        /// The redirect_url
        /// </summary>
        ///
        /// <param name="redirectUrl"> The redirect_url </param>
        /// <returns> this </returns> 
        public ReservationUpdater setRedirectUrl(Uri redirectUrl) {
            this.redirectUrl = redirectUrl;
            return this;
        }
    
        /// <summary>
        /// The redirect_url
        /// </summary>
        ///
        /// <param name="redirectUrl"> The redirect_url </param>
        /// <returns> this </returns> 
        public ReservationUpdater setRedirectUrl(string redirectUrl) {
            return setRedirectUrl(Promoter.UriFromString(redirectUrl));
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
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks/" + this.taskSid + "/Reservations/" + this.sid + ""
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
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks/" + this.taskSid + "/Reservations/" + this.sid + ""
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