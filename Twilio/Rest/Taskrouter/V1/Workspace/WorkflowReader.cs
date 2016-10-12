using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class WorkflowReader : Reader<WorkflowResource> {
        private string workspaceSid;
        private string friendlyName;
    
        /**
         * Construct a new WorkflowReader
         * 
         * @param workspaceSid The workspace_sid
         */
        public WorkflowReader(string workspaceSid) {
            this.workspaceSid = workspaceSid;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public WorkflowReader ByFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return WorkflowResource ResourceSet
         */
        public override Task<ResourceSet<WorkflowResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workflows"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<WorkflowResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return WorkflowResource ResourceSet
         */
        public override ResourceSet<WorkflowResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Workflows"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<WorkflowResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<WorkflowResource> NextPage(Page<WorkflowResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.TASKROUTER
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /**
         * Generate a Page of WorkflowResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<WorkflowResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("WorkflowResource read failed: Unable to connect to server");
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
            
            return Page<WorkflowResource>.FromJson("workflows", response.GetContent());
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
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}