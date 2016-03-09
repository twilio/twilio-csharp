using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.usage.Trigger;
using com.twilio.sdk.readers.Reader;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Api.V2010.Account.Usage {

    public class TriggerReader : Reader<Trigger> {
        private string accountSid;
        private Trigger.Recurring recurring;
        private Trigger.TriggerField triggerBy;
        private Trigger.UsageCategory usageCategory;
    
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
        public TriggerReader byRecurring(Trigger.Recurring recurring) {
            this.recurring = recurring;
            return this;
        }
    
        /**
         * Only show UsageTriggers that trigger by this field in the UsagRecord
         * 
         * @param triggerBy Filter by trigger by
         * @return this
         */
        public TriggerReader byTriggerBy(Trigger.TriggerField triggerBy) {
            this.triggerBy = triggerBy;
            return this;
        }
    
        /**
         * Only show UsageTriggers that watch this usage category
         * 
         * @param usageCategory Filter by Usage Category
         * @return this
         */
        public TriggerReader byUsageCategory(Trigger.UsageCategory usageCategory) {
            this.usageCategory = usageCategory;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Trigger ResourceSet
         */
        [Override]
        public ResourceSet<Trigger> execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Usage/Triggers.json",
                client.getAccountSid()
            );
            
            addQueryParams(request);
            
            Page<Trigger> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        [Override]
        public Page<Trigger> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                nextPageUri,
                client.getAccountSid()
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of Trigger Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<Trigger> pageForRequest(final TwilioRestClient client, final Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Trigger read failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.getStream(), client.getObjectMapper());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.getMessage(),
                    restException.getCode(),
                    restException.getMoreInfo(),
                    restException.getStatus(),
                    null
                );
            }
            
            Page<Trigger> result = new Page<>();
            result.deserialize("usage_triggers", response.getContent(), Trigger.class, client.getObjectMapper());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void addQueryParams(final Request request) {
            if (recurring != null) {
                request.addQueryParam("Recurring", recurring.ToString());
            }
            
            if (triggerBy != null) {
                request.addQueryParam("TriggerBy", triggerBy.ToString());
            }
            
            if (usageCategory != null) {
                request.addQueryParam("UsageCategory", usageCategory.ToString());
            }
            
            request.addQueryParam("PageSize", Integer.toString(getPageSize()));
        }
    }
}