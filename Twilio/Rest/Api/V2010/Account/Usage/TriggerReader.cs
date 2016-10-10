using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Usage {

    public class TriggerReader : Reader<TriggerResource> {
        private string accountSid;
        private TriggerResource.Recurring recurring;
        private TriggerResource.TriggerField triggerBy;
        private TriggerResource.UsageCategory usageCategory;
    
        /**
         * Construct a new TriggerReader.
         */
        public TriggerReader() {
        }
    
        /**
         * Construct a new TriggerReader
         * 
         * @param accountSid The account_sid
         */
        public TriggerReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /**
         * Only show UsageTriggers that count over this interval. One of daily, monthly,
         * or yearly
         * 
         * @param recurring Filter by recurring
         * @return this
         */
        public TriggerReader ByRecurring(TriggerResource.Recurring recurring) {
            this.recurring = recurring;
            return this;
        }
    
        /**
         * Only show UsageTriggers that trigger by this field in the UsagRecord
         * 
         * @param triggerBy Filter by trigger by
         * @return this
         */
        public TriggerReader ByTriggerBy(TriggerResource.TriggerField triggerBy) {
            this.triggerBy = triggerBy;
            return this;
        }
    
        /**
         * Only show UsageTriggers that watch this usage category
         * 
         * @param usageCategory Filter by Usage Category
         * @return this
         */
        public TriggerReader ByUsageCategory(TriggerResource.UsageCategory usageCategory) {
            this.usageCategory = usageCategory;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return TriggerResource ResourceSet
         */
        public override Task<ResourceSet<TriggerResource>> ReadAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Usage/Triggers.json"
            );
            
            AddQueryParams(request);
            
            Page<TriggerResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<TriggerResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return TriggerResource ResourceSet
         */
        public override ResourceSet<TriggerResource> Read(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Usage/Triggers.json"
            );
            
            AddQueryParams(request);
            
            Page<TriggerResource> page = PageForRequest(client, request);
            
            return new ResourceSet<TriggerResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<TriggerResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of TriggerResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<TriggerResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TriggerResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to read records, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
                    null
                );
            }
            
            Page<TriggerResource> result = new Page<TriggerResource>();
            result.deserialize("usage_triggers", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (recurring != null) {
                request.AddQueryParam("Recurring", recurring.ToString());
            }
            
            if (triggerBy != null) {
                request.AddQueryParam("TriggerBy", triggerBy.ToString());
            }
            
            if (usageCategory != null) {
                request.AddQueryParam("UsageCategory", usageCategory.ToString());
            }
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}