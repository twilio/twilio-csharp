using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account.Usage;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Readers.Api.V2010.Account.Usage {

    public class RecordReader : Reader<RecordResource> {
        private string accountSid;
        private RecordResource.Category category;
        private string startDate;
        private string endDate;
    
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
        public RecordReader ByStartDate(string startDate) {
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
        public RecordReader ByEndDate(string endDate) {
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
        public override Task<ResourceSet<RecordResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Usage/Records.json"
            );
            
            AddQueryParams(request);
            
            Page<RecordResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<RecordResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return RecordResource ResourceSet
         */
        public override ResourceSet<RecordResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Usage/Records.json"
            );
            
            AddQueryParams(request);
            
            Page<RecordResource> page = PageForRequest(client, request);
            
            return new ResourceSet<RecordResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<RecordResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of RecordResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<RecordResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("RecordResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
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
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}