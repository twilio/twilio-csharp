using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources.Api.V2010.Account.Usage;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

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
        public override ResourceSet<RecordResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Usage/Records.json"
            );
            
            addQueryParams(request);
            
            Page<RecordResource> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<RecordResource> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of RecordResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<RecordResource> pageForRequest(TwilioRestClient client, Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("RecordResource read failed: Unable to connect to server");
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
            
            Page<RecordResource> result = new Page<>();
            result.deserialize("usage_records", response.GetContent(), RecordResource.class, client.getObjectMapper());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void addQueryParams(Request request) {
            if (category != null) {
                request.addQueryParam("Category", category.ToString());
            }
            
            if (startDate != null) {
                request.addQueryParam("StartDate", startDate);
            }
            
            if (endDate != null) {
                request.addQueryParam("EndDate", endDate);
            }
            
            request.addQueryParam("PageSize", Integer.toString(getPageSize()));
        }
    }
}