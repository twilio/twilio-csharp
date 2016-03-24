using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Fetchers;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.Workspace.Task;

namespace Twilio.Fetchers.Taskrouter.V1.Workspace.Task {

    public class ReservationFetcher : Fetcher<ReservationResource> {
        private string workspaceSid;
        private string taskSid;
        private string sid;
    
        /**
         * Construct a new ReservationFetcher
         * 
         * @param workspaceSid The workspace_sid
         * @param taskSid The task_sid
         * @param sid The sid
         */
        public ReservationFetcher(string workspaceSid, string taskSid, string sid) {
            this.workspaceSid = workspaceSid;
            this.taskSid = taskSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the fetch
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Fetched ReservationResource
         */
        public override ReservationResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Tasks/" + this.taskSid + "/Reservations/" + this.sid + ""
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ReservationResource fetch failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.GetContent());
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
            
            return ReservationResource.fromJson(response.GetContent());
        }
    }
}