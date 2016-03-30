using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Deleters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1;

namespace Twilio.Deleters.Taskrouter.V1 {

    public class WorkspaceDeleter : Deleter<WorkspaceResource> {
        private string sid;
    
        /**
         * Construct a new WorkspaceDeleter
         * 
         * @param sid The sid
         */
        public WorkspaceDeleter(string sid) {
            this.sid = sid;
        }
    
        /**
         * Make the request to the Twilio API to perform the delete
         * 
         * @param client TwilioRestClient with which to make the request
         */
        public override async void ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Delete,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.sid + ""
            );
            
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("WorkspaceResource delete failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_NO_CONTENT) {
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
        }
    }
}