using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Taskrouter.V1.Workspace.Task;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Readers.Taskrouter.V1.Workspace.Task {

    public class ReservationReader : Reader<ReservationResource> {
        private string workspaceSid;
        private string taskSid;
        private string status;
        private string assignmentStatus;
        private string reservationStatus;
    
        /**
         * Construct a new ReservationReader
         * 
         * @param workspaceSid The workspace_sid
         * @param taskSid The task_sid
         */
        public ReservationReader(string workspaceSid, string taskSid) {
            this.workspaceSid = workspaceSid;
            this.taskSid = taskSid;
        }
    
        /**
         * The status
         * 
         * @param status The status
         * @return this
         */
        public ReservationReader ByStatus(string status) {
            this.status = status;
            return this;
        }
    
        /**
         * The assignment_status
         * 
         * @param assignmentStatus The assignment_status
         * @return this
         */
        public ReservationReader ByAssignmentStatus(string assignmentStatus) {
            this.assignmentStatus = assignmentStatus;
            return this;
        }
    
        /**
         * The reservation_status
         * 
         * @param reservationStatus The reservation_status
         * @return this
         */
        public ReservationReader ByReservationStatus(string reservationStatus) {
            this.reservationStatus = reservationStatus;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return ReservationResource ResourceSet
         */
        public override Task<ResourceSet<ReservationResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks/" + this.taskSid + "/Reservations"
            );
            
            AddQueryParams(request);
            
            Page<ReservationResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<ReservationResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return ReservationResource ResourceSet
         */
        public override ResourceSet<ReservationResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks/" + this.taskSid + "/Reservations"
            );
            
            AddQueryParams(request);
            
            Page<ReservationResource> page = PageForRequest(client, request);
            
            return new ResourceSet<ReservationResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<ReservationResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of ReservationResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<ReservationResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ReservationResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() != System.Net.HttpStatusCode.OK) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.GetMessage(),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    restException.GetStatus(),
                    null
                );
            }
            
            Page<ReservationResource> result = new Page<ReservationResource>();
            result.deserialize("reservations", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (status != null) {
                request.AddQueryParam("Status", status);
            }
            
            if (assignmentStatus != null) {
                request.AddQueryParam("AssignmentStatus", assignmentStatus);
            }
            
            if (reservationStatus != null) {
                request.AddQueryParam("ReservationStatus", reservationStatus);
            }
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}