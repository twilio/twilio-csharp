using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources.Taskrouter.V1.Workspace;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

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
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return ActivityResource ResourceSet
         */
        public override ResourceSet<ActivityResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Activities"
            );
            
            addQueryParams(request);
            
            Page<ActivityResource> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<ActivityResource> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of ActivityResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<ActivityResource> pageForRequest(TwilioRestClient client, Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ActivityResource read failed: Unable to connect to server");
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
            
            Page<ActivityResource> result = new Page<>();
            result.deserialize("activities", response.GetContent(), ActivityResource.class, client.getObjectMapper());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void addQueryParams(Request request) {
            if (friendlyName != null) {
                request.addQueryParam("FriendlyName", friendlyName);
            }
            
            if (available != null) {
                request.addQueryParam("Available", available);
            }
            
            request.addQueryParam("PageSize", Integer.toString(getPageSize()));
        }
    }
}