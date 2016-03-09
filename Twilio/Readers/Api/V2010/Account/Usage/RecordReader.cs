using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.usage.Record;
using com.twilio.sdk.readers.Reader;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Api.V2010.Account.Usage {

    public class RecordReader : Reader<Record> {
        private string accountSid;
        private Record.Category category;
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
        public RecordReader byCategory(Record.Category category) {
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
         * @return Record ResourceSet
         */
        [Override]
        public ResourceSet<Record> execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Usage/Records.json",
                client.getAccountSid()
            );
            
            addQueryParams(request);
            
            Page<Record> page = pageForRequest(client, request);
            
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
        public Page<Record> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                nextPageUri,
                client.getAccountSid()
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of Record Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<Record> pageForRequest(final TwilioRestClient client, final Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Record read failed: Unable to connect to server");
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
            
            Page<Record> result = new Page<>();
            result.deserialize("usage_records", response.getContent(), Record.class, client.getObjectMapper());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void addQueryParams(final Request request) {
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