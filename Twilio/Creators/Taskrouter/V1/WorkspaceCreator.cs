using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Taskrouter.V1;

namespace Twilio.Creators.Taskrouter.V1 {

    public class WorkspaceCreator : Creator<WorkspaceResource> {
        private string friendlyName;
        private string eventCallbackUrl;
        private string template;
    
        /**
         * Construct a new WorkspaceCreator
         * 
         * @param friendlyName The friendly_name
         */
        public WorkspaceCreator(string friendlyName) {
            this.friendlyName = friendlyName;
        }
    
        /**
         * The event_callback_url
         * 
         * @param eventCallbackUrl The event_callback_url
         * @return this
         */
        public WorkspaceCreator setEventCallbackUrl(string eventCallbackUrl) {
            this.eventCallbackUrl = eventCallbackUrl;
            return this;
        }
    
        /**
         * The template
         * 
         * @param template The template
         * @return this
         */
        public WorkspaceCreator setTemplate(string template) {
            this.template = template;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created WorkspaceResource
         */
        public override async Task<WorkspaceResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                Domains.TASKROUTER,
                "/v1/Workspaces"
            );
            
            addPostParams(request);
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("WorkspaceResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_CREATED) {
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
            
            return WorkspaceResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (eventCallbackUrl != null) {
                request.AddPostParam("EventCallbackUrl", eventCallbackUrl);
            }
            
            if (template != null) {
                request.AddPostParam("Template", template);
            }
        }
    }
}