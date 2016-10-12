using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace.Task {

    public class ReservationReader : Reader<ReservationResource> {
        private string workspaceSid;
        private string taskSid;
        private ReservationResource.Status reservationStatus;
    
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
         * The reservation_status
         * 
         * @param reservationStatus The reservation_status
         * @return this
         */
        public ReservationReader ByReservationStatus(ReservationResource.Status reservationStatus) {
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
        public override Task<ResourceSet<ReservationResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks/" + this.taskSid + "/Reservations"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<ReservationResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return ReservationResource ResourceSet
         */
        public override ResourceSet<ReservationResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks/" + this.taskSid + "/Reservations"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<ReservationResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<ReservationResource> NextPage(Page<ReservationResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.TASKROUTER
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /**
         * Generate a Page of ReservationResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<ReservationResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ReservationResource read failed: Unable to connect to server");
            }
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to read records, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return Page<ReservationResource>.FromJson("reservations", response.GetContent());
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (reservationStatus != null) {
                request.AddQueryParam("ReservationStatus", reservationStatus.ToString());
            }
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}