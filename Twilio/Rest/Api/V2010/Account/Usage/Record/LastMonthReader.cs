using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Usage.Record {

    public class LastMonthReader : Reader<LastMonthResource> {
        private string accountSid;
        private LastMonthResource.Category category;
        private DateTime? startDate;
        private DateTime? endDate;
    
        /**
         * Construct a new LastMonthReader.
         */
        public LastMonthReader() {
        }
    
        /**
         * Construct a new LastMonthReader
         * 
         * @param accountSid The account_sid
         */
        public LastMonthReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /**
         * The category
         * 
         * @param category The category
         * @return this
         */
        public LastMonthReader ByCategory(LastMonthResource.Category category) {
            this.category = category;
            return this;
        }
    
        /**
         * The start_date
         * 
         * @param startDate The start_date
         * @return this
         */
        public LastMonthReader ByStartDate(DateTime? startDate) {
            this.startDate = startDate;
            return this;
        }
    
        /**
         * The end_date
         * 
         * @param endDate The end_date
         * @return this
         */
        public LastMonthReader ByEndDate(DateTime? endDate) {
            this.endDate = endDate;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return LastMonthResource ResourceSet
         */
        public override Task<ResourceSet<LastMonthResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Usage/Records/LastMonth.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<LastMonthResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return LastMonthResource ResourceSet
         */
        public override ResourceSet<LastMonthResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Usage/Records/LastMonth.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<LastMonthResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<LastMonthResource> NextPage(Page<LastMonthResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.API
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /**
         * Generate a Page of LastMonthResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<LastMonthResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("LastMonthResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                var restException = RestException.FromJson(response.GetContent());
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
            
            return Page<LastMonthResource>.FromJson("usage_records", response.GetContent());
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (category != null) {
                request.AddQueryParam("Category", category.ToString());
            }
            
            if (startDate != null) {
                request.AddQueryParam("StartDate", startDate.ToString());
            }
            
            if (endDate != null) {
                request.AddQueryParam("EndDate", endDate.ToString());
            }
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}