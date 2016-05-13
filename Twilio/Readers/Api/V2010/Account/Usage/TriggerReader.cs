using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account.Usage;

namespace Twilio.Readers.Api.V2010.Account.Usage {

    public class TriggerReader : Reader<TriggerResource> {
        private string accountSid;
        private TriggerResource.Recurring recurring;
        private TriggerResource.TriggerField triggerBy;
        private TriggerResource.UsageCategory usageCategory;
    
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
        public TriggerReader byRecurring(TriggerResource.Recurring recurring) {
            this.recurring = recurring;
            return this;
        }
    
        /**
         * Only show UsageTriggers that trigger by this field in the UsagRecord
         * 
         * @param triggerBy Filter by trigger by
         * @return this
         */
        public TriggerReader byTriggerBy(TriggerResource.TriggerField triggerBy) {
            this.triggerBy = triggerBy;
            return this;
        }
    
        /**
         * Only show UsageTriggers that watch this usage category
         * 
         * @param usageCategory Filter by Usage Category
         * @return this
         */
        public TriggerReader byUsageCategory(TriggerResource.UsageCategory usageCategory) {
            this.usageCategory = usageCategory;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return TriggerResource ResourceSet
         */
        public override async Task<ResourceSet<TriggerResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Usage/Triggers.json"
            );
            
            AddQueryParams(request);
            
            Page<TriggerResource> page = await PageForRequest(client, request);
            
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
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            
            var task = PageForRequest(client, request);
            task.Wait();
            
            return task.Result;
        }
    
        /**
         * Generate a Page of TriggerResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected async Task<Page<TriggerResource>> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TriggerResource read failed: Unable to connect to server");
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