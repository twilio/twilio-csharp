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
        private string workspaceSid;
        private string taskSid;
        private string sid;
        private ReservationResource.Status reservationStatus;
        private string workerActivitySid;
        private string instruction;
        private string dequeuePostWorkActivitySid;
        private string dequeueFrom;
        private string dequeueRecord;
        private int? dequeueTimeout;
        private string dequeueTo;
        private Uri dequeueStatusCallbackUrl;
        private string callFrom;
        private string callRecord;
        private int? callTimeout;
        private string callTo;
        private Uri callUrl;
        private Uri callStatusCallbackUrl;
        private bool? callAccept;
        private string redirectCallSid;
        private bool? redirectAccept;
        private Uri redirectUrl;
    
        /**
         * Construct a new ReservationUpdater
         * 
         * @param workspaceSid The workspace_sid
         * @param taskSid The task_sid
         * @param sid The sid
         */
        public ReservationUpdater(string workspaceSid, string taskSid, string sid) {
            this.workspaceSid = workspaceSid;
            this.taskSid = taskSid;
            this.sid = sid;
        }
    
        /**
         * The reservation_status
         * 
         * @param reservationStatus The reservation_status
         * @return this
         */
        public ReservationUpdater setReservationStatus(ReservationResource.Status reservationStatus) {
            this.reservationStatus = reservationStatus;
            return this;
        }
    
        /**
         * The worker_activity_sid
         * 
         * @param workerActivitySid The worker_activity_sid
         * @return this
         */
        public ReservationUpdater setWorkerActivitySid(string workerActivitySid) {
            this.workerActivitySid = workerActivitySid;
            return this;
        }
    
        /**
         * The instruction
         * 
         * @param instruction The instruction
         * @return this
         */
        public ReservationUpdater setInstruction(string instruction) {
            this.instruction = instruction;
            return this;
        }
    
        /**
         * The dequeue_post_work_activity_sid
         * 
         * @param dequeuePostWorkActivitySid The dequeue_post_work_activity_sid
         * @return this
         */
        public ReservationUpdater setDequeuePostWorkActivitySid(string dequeuePostWorkActivitySid) {
            this.dequeuePostWorkActivitySid = dequeuePostWorkActivitySid;
            return this;
        }
    
        /**
         * The dequeue_from
         * 
         * @param dequeueFrom The dequeue_from
         * @return this
         */
        public ReservationUpdater setDequeueFrom(string dequeueFrom) {
            this.dequeueFrom = dequeueFrom;
            return this;
        }
    
        /**
         * The dequeue_record
         * 
         * @param dequeueRecord The dequeue_record
         * @return this
         */
        public ReservationUpdater setDequeueRecord(string dequeueRecord) {
            this.dequeueRecord = dequeueRecord;
            return this;
        }
    
        /**
         * The dequeue_timeout
         * 
         * @param dequeueTimeout The dequeue_timeout
         * @return this
         */
        public ReservationUpdater setDequeueTimeout(int? dequeueTimeout) {
            this.dequeueTimeout = dequeueTimeout;
            return this;
        }
    
        /**
         * The dequeue_to
         * 
         * @param dequeueTo The dequeue_to
         * @return this
         */
        public ReservationUpdater setDequeueTo(string dequeueTo) {
            this.dequeueTo = dequeueTo;
            return this;
        }
    
        /**
         * The dequeue_status_callback_url
         * 
         * @param dequeueStatusCallbackUrl The dequeue_status_callback_url
         * @return this
         */
        public ReservationUpdater setDequeueStatusCallbackUrl(Uri dequeueStatusCallbackUrl) {
            this.dequeueStatusCallbackUrl = dequeueStatusCallbackUrl;
            return this;
        }
    
        /**
         * The dequeue_status_callback_url
         * 
         * @param dequeueStatusCallbackUrl The dequeue_status_callback_url
         * @return this
         */
        public ReservationUpdater setDequeueStatusCallbackUrl(string dequeueStatusCallbackUrl) {
            return setDequeueStatusCallbackUrl(Promoter.UriFromString(dequeueStatusCallbackUrl));
        }
    
        /**
         * The call_from
         * 
         * @param callFrom The call_from
         * @return this
         */
        public ReservationUpdater setCallFrom(string callFrom) {
            this.callFrom = callFrom;
            return this;
        }
    
        /**
         * The call_record
         * 
         * @param callRecord The call_record
         * @return this
         */
        public ReservationUpdater setCallRecord(string callRecord) {
            this.callRecord = callRecord;
            return this;
        }
    
        /**
         * The call_timeout
         * 
         * @param callTimeout The call_timeout
         * @return this
         */
        public ReservationUpdater setCallTimeout(int? callTimeout) {
            this.callTimeout = callTimeout;
            return this;
        }
    
        /**
         * The call_to
         * 
         * @param callTo The call_to
         * @return this
         */
        public ReservationUpdater setCallTo(string callTo) {
            this.callTo = callTo;
            return this;
        }
    
        /**
         * The call_url
         * 
         * @param callUrl The call_url
         * @return this
         */
        public ReservationUpdater setCallUrl(Uri callUrl) {
            this.callUrl = callUrl;
            return this;
        }
    
        /**
         * The call_url
         * 
         * @param callUrl The call_url
         * @return this
         */
        public ReservationUpdater setCallUrl(string callUrl) {
            return setCallUrl(Promoter.UriFromString(callUrl));
        }
    
        /**
         * The call_status_callback_url
         * 
         * @param callStatusCallbackUrl The call_status_callback_url
         * @return this
         */
        public ReservationUpdater setCallStatusCallbackUrl(Uri callStatusCallbackUrl) {
            this.callStatusCallbackUrl = callStatusCallbackUrl;
            return this;
        }
    
        /**
         * The call_status_callback_url
         * 
         * @param callStatusCallbackUrl The call_status_callback_url
         * @return this
         */
        public ReservationUpdater setCallStatusCallbackUrl(string callStatusCallbackUrl) {
            return setCallStatusCallbackUrl(Promoter.UriFromString(callStatusCallbackUrl));
        }
    
        /**
         * The call_accept
         * 
         * @param callAccept The call_accept
         * @return this
         */
        public ReservationUpdater setCallAccept(bool? callAccept) {
            this.callAccept = callAccept;
            return this;
        }
    
        /**
         * The redirect_call_sid
         * 
         * @param redirectCallSid The redirect_call_sid
         * @return this
         */
        public ReservationUpdater setRedirectCallSid(string redirectCallSid) {
            this.redirectCallSid = redirectCallSid;
            return this;
        }
    
        /**
         * The redirect_accept
         * 
         * @param redirectAccept The redirect_accept
         * @return this
         */
        public ReservationUpdater setRedirectAccept(bool? redirectAccept) {
            this.redirectAccept = redirectAccept;
            return this;
        }
    
        /**
         * The redirect_url
         * 
         * @param redirectUrl The redirect_url
         * @return this
         */
        public ReservationUpdater setRedirectUrl(Uri redirectUrl) {
            this.redirectUrl = redirectUrl;
            return this;
        }
    
        /**
         * The redirect_url
         * 
         * @param redirectUrl The redirect_url
         * @return this
         */
        public ReservationUpdater setRedirectUrl(string redirectUrl) {
            return setRedirectUrl(Promoter.UriFromString(redirectUrl));
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated ReservationResource
         */
        public override async Task<ReservationResource> UpdateAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks/" + this.taskSid + "/Reservations/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("ReservationResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to update record, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
                    null
                );
            }
            
            return ReservationResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated ReservationResource
         */
        public override ReservationResource Update(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks/" + this.taskSid + "/Reservations/" + this.sid + ""
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ReservationResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to update record, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
                    null
                );
            }
            
            return ReservationResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
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