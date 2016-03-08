using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.Notification;
using com.twilio.sdk.readers.Reader;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Api.V2010.Account {

    public class NotificationReader : Reader<Notification> {
        private String accountSid;
        private Integer log;
        private String messageDate;
    
        /**
         * Construct a new NotificationReader
         * 
         * @param accountSid The account_sid
         */
        public NotificationReader(String accountSid) {
            this.accountSid = accountSid;
        }
    
        /**
         * Only show notifications for this log level
         * 
         * @param log Filter by log level
         * @return this
         */
        public NotificationReader byLog(Integer log) {
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
        public NotificationReader byMessageDate(String messageDate) {
            this.messageDate = messageDate;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Notification ResourceSet
         */
        [Override]
        public ResourceSet<Notification> execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Notifications.json",
                client.getAccountSid()
            );
            
            addQueryParams(request);
            
            Page<Notification> page = pageForRequest(client, request);
            
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
        public Page<Notification> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                nextPageUri,
                client.getAccountSid()
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of Notification Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<Notification> pageForRequest(final TwilioRestClient client, final Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Notification read failed: Unable to connect to server");
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
            
            Page<Notification> result = new Page<>();
            result.deserialize("notifications", response.getContent(), Notification.class, client.getObjectMapper());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void addQueryParams(final Request request) {
            if (log != null) {
                request.addQueryParam("Log", log.toString());
            }
            
            if (messageDate != null) {
                request.addQueryParam("MessageDate", messageDate);
            }
            
            request.addQueryParam("PageSize", Integer.toString(getPageSize()));
        }
    }
}