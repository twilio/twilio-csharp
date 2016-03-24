using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources.Api.V2010.Account;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Api.V2010.Account {

    public class NotificationReader : Reader<NotificationResource> {
        private string accountSid;
        private int log;
        private string messageDate;
    
        /**
         * Construct a new NotificationReader
         * 
         * @param accountSid The account_sid
         */
        public NotificationReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /**
         * Only show notifications for this log level
         * 
         * @param log Filter by log level
         * @return this
         */
        public NotificationReader byLog(int log) {
            this.log = log;
            return this;
        }
    
        /**
         * Only show notifications for this date. Should be formatted as YYYY-MM-DD. You
         * can also specify inequalities.
         * 
         * @param messageDate Filter by date
         * @return this
         */
        public NotificationReader byMessageDate(string messageDate) {
            this.messageDate = messageDate;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return NotificationResource ResourceSet
         */
        public override ResourceSet<NotificationResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Notifications.json"
            );
            
            addQueryParams(request);
            
            Page<NotificationResource> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<NotificationResource> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of NotificationResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<NotificationResource> pageForRequest(TwilioRestClient client, Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("NotificationResource read failed: Unable to connect to server");
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
            
            Page<NotificationResource> result = new Page<>();
            result.deserialize("notifications", response.GetContent(), NotificationResource.class, client.getObjectMapper());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void addQueryParams(Request request) {
            if (log != null) {
                request.addQueryParam("Log", log.ToString());
            }
            
            if (messageDate != null) {
                request.addQueryParam("MessageDate", messageDate);
            }
            
            request.addQueryParam("PageSize", Integer.toString(getPageSize()));
        }
    }
}