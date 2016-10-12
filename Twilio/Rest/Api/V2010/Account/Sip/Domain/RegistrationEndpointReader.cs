using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Sip.Domain {

    public class RegistrationEndpointReader : Reader<RegistrationEndpointResource> {
        private string accountSid;
        private string domainSid;
        private string region;
        private string registrant;
    
        /**
         * Construct a new RegistrationEndpointReader.
         * 
         * @param domainSid The domain_sid
         * @param region The region
         * @param registrant The registrant
         */
        public RegistrationEndpointReader(string domainSid, string region, string registrant) {
            this.domainSid = domainSid;
            this.region = region;
            this.registrant = registrant;
        }
    
        /**
         * Construct a new RegistrationEndpointReader
         * 
         * @param accountSid The account_sid
         * @param domainSid The domain_sid
         * @param region The region
         * @param registrant The registrant
         */
        public RegistrationEndpointReader(string accountSid, string domainSid, string region, string registrant) {
            this.accountSid = accountSid;
            this.domainSid = domainSid;
            this.region = region;
            this.registrant = registrant;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return RegistrationEndpointResource ResourceSet
         */
        public override Task<ResourceSet<RegistrationEndpointResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/SIP/Domains/" + this.domainSid + "/Registrations/" + this.region + "/" + this.registrant + ".json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<RegistrationEndpointResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return RegistrationEndpointResource ResourceSet
         */
        public override ResourceSet<RegistrationEndpointResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/SIP/Domains/" + this.domainSid + "/Registrations/" + this.region + "/" + this.registrant + ".json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<RegistrationEndpointResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<RegistrationEndpointResource> NextPage(Page<RegistrationEndpointResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.API
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /**
         * Generate a Page of RegistrationEndpointResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<RegistrationEndpointResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("RegistrationEndpointResource read failed: Unable to connect to server");
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
            
            return Page<RegistrationEndpointResource>.FromJson("registrations", response.GetContent());
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}