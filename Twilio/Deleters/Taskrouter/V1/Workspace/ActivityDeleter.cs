using Twilio.Clients;
using Twilio.Deleters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1.Workspace;

namespace Twilio.Deleters.Taskrouter.V1.Workspace {

    public class ActivityDeleter : Deleter<ActivityResource> {
        private string workspaceSid;
        private string sid;
    
        /**
         * Construct a new ActivityDeleter
         * 
         * @param workspaceSid The workspace_sid
         * @param sid The sid
         */
        public ActivityDeleter(string workspaceSid, string sid) {
            this.workspaceSid = workspaceSid;
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the delete
         * 
         * @param client TwilioRestClient with which to make the request
         */
        public override void execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Delete,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Activities/" + this.sid + ""
            );
            
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ActivityResource delete failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_NO_CONTENT) {
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
        }
    }
}