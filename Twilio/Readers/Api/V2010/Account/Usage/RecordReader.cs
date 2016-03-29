using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account.Usage;

namespace Twilio.Readers.Api.V2010.Account.Usage {

    public class RecordReader : Reader<RecordResource> {
        private string accountSid;
        private RecordResource.Category category;
        private string startDate;
        private string endDate;
    
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
        public RecordReader byCategory(RecordResource.Category category) {
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
        public RecordReader byStartDate(string startDate) {
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
        public RecordReader byEndDate(string endDate) {
            this.endDate = endDate;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return RecordResource ResourceSet
         */
        public override async Task<ResourceSet<RecordResource>> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Usage/Records.json"
            );
            
            AddQueryParams(request);
            
            Page<RecordResource> page = await pageForRequest(client, request);
            
            return new ResourceSet<RecordResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<RecordResource> nextPage(string nextPageUri, TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            
            var task = pageForRequest(client, request);
            task.Wait();
            
            return task.Result;
        }
    
        /**
         * Generate a Page of RecordResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected async Task<Page<RecordResource>> pageForRequest(TwilioRestClient client, Request request) {
            Response response = await client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("RecordResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
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
            
            Page<RecordResource> result = new Page<RecordResource>();
            result.deserialize("usage_records", response.GetContent());
            
            return result;
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
                request.AddQueryParam("StartDate", startDate);
            }
            
            if (endDate != null) {
                request.AddQueryParam("EndDate", endDate);
            }
            
            request.AddQueryParam("PageSize", getPageSize().ToString());
        }
    }
}