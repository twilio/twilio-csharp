using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Taskrouter.V1.Workspace;

namespace Twilio.Readers.Taskrouter.V1.Workspace {

    public class ActivityReader : Reader<ActivityResource> {
        private string workspaceSid;
        private string friendlyName;
        private string available;
    
        /**
         * Construct a new ActivityReader
         * 
         * @param workspaceSid The workspace_sid
         */
        public ActivityReader(string workspaceSid) {
            this.workspaceSid = workspaceSid;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public ActivityReader byFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The available
         * 
         * @param available The available
         * @return this
         */
        public ActivityReader byAvailable(string available) {
            this.available = available;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return ActivityResource ResourceSet
         */
        public override Task<ResourceSet<ActivityResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Activities"
            );
            
            AddQueryParams(request);
            
            Page<ActivityResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<ActivityResource>(this, client, page));
        }
        #endif
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return ActivityResource ResourceSet
         */
        public override ResourceSet<ActivityResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Activities"
            );
            
            AddQueryParams(request);
            
            Page<ActivityResource> page = PageForRequest(client, request);
            
            return new ResourceSet<ActivityResource>(this, client, page);
        }
        #endif
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<ActivityResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of ActivityResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<ActivityResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ActivityResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_OK) {
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
            
            Page<ActivityResource> result = new Page<ActivityResource>();
            result.deserialize("activities", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (friendlyName != null) {
                request.AddQueryParam("FriendlyName", friendlyName);
            }
            
            if (available != null) {
                request.AddQueryParam("Available", available);
            }
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}