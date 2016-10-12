using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Usage {

    public class RecordReader : Reader<RecordResource> {
        private string accountSid;
        private RecordResource.Category category;
        private DateTime? startDate;
        private DateTime? endDate;
    
        /**
         * Construct a new RecordReader.
         */
        public RecordReader() {
        }
    
        /**
         * Construct a new RecordReader
         * 
         * @param accountSid The account_sid
         */
        public RecordReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /**
         * Only include usage of a given category
         * 
         * @param category Only include usage of a given category
         * @return this
         */
        public RecordReader ByCategory(RecordResource.Category category) {
            this.category = category;
            return this;
        }
    
        /**
         * Only include usage that has occurred on or after this date. Format is
         * YYYY-MM-DD in GTM. As a convenience, you can also specify offsets to today,
         * for example, StartDate=-30days, which will make StartDate 30 days before
         * today
         * 
         * @param startDate Filter by start date
         * @return this
         */
        public RecordReader ByStartDate(DateTime? startDate) {
            this.startDate = startDate;
            return this;
        }
    
        /**
         * Only include usage that has occurred on or after this date. Format is
         * YYYY-MM-DD in GTM. As a convenience, you can also specify offsets to today,
         * for example, EndDate=+30days, which will make EndDate 30 days from today
         * 
         * @param endDate Filter by end date
         * @return this
         */
        public RecordReader ByEndDate(DateTime? endDate) {
            this.endDate = endDate;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return RecordResource ResourceSet
         */
        public override Task<ResourceSet<RecordResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Usage/Records.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<RecordResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return RecordResource ResourceSet
         */
        public override ResourceSet<RecordResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Usage/Records.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<RecordResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<RecordResource> NextPage(Page<RecordResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.API
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /**
         * Generate a Page of RecordResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<RecordResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("RecordResource read failed: Unable to connect to server");
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
            
            return Page<RecordResource>.FromJson("usage_records", response.GetContent());
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