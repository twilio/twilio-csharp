using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Monitor.V1;

namespace Twilio.Readers.Monitor.V1 {

    public class AlertReader : Reader<AlertResource> {
        private string logLevel;
        private string startDate;
        private string endDate;
    
        /**
         * The log_level
         * 
         * @param logLevel The log_level
         * @return this
         */
        public AlertReader byLogLevel(string logLevel) {
            this.logLevel = logLevel;
            return this;
        }
    
        /**
         * The start_date
         * 
         * @param startDate The start_date
         * @return this
         */
        public AlertReader byStartDate(string startDate) {
            this.startDate = startDate;
            return this;
        }
    
        /**
         * The end_date
         * 
         * @param endDate The end_date
         * @return this
         */
        public AlertReader byEndDate(string endDate) {
            this.endDate = endDate;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return AlertResource ResourceSet
         */
        public override async Task<ResourceSet<AlertResource>> ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.MONITOR,
                "/v1/Alerts"
            );
            
            AddQueryParams(request);
            
            Page<AlertResource> page = await PageForRequest(client, request);
            
            return new ResourceSet<AlertResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<AlertResource> NextPage(string nextPageUri, TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            
            var task = PageForRequest(client, request);
            task.Wait();
            
            return task.Result;
        }
    
        /**
         * Generate a Page of AlertResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected async Task<Page<AlertResource>> PageForRequest(TwilioRestClient client, Request request) {
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("AlertResource read failed: Unable to connect to server");
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
            
            Page<AlertResource> result = new Page<AlertResource>();
            result.deserialize("alerts", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (logLevel != null) {
                request.AddQueryParam("LogLevel", logLevel);
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