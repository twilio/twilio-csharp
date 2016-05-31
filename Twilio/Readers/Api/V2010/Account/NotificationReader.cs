using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Readers.Api.V2010.Account {

    public class NotificationReader : Reader<NotificationResource> {
        private string accountSid;
        private int? log;
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
        public NotificationReader byLog(int? log) {
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
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return NotificationResource ResourceSet
         */
        public override Task<ResourceSet<NotificationResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Notifications.json"
            );
            
            AddQueryParams(request);
            
            Page<NotificationResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<NotificationResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return NotificationResource ResourceSet
         */
        public override ResourceSet<NotificationResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Notifications.json"
            );
            
            AddQueryParams(request);
            
            Page<NotificationResource> page = PageForRequest(client, request);
            
            return new ResourceSet<NotificationResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<NotificationResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of NotificationResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<NotificationResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("NotificationResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() != System.Net.HttpStatusCode.OK) {
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
            
            Page<NotificationResource> result = new Page<NotificationResource>();
            result.deserialize("notifications", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (log != null) {
                request.AddQueryParam("Log", log.ToString());
            }
            
            if (messageDate != null) {
                request.AddQueryParam("MessageDate", messageDate);
            }
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}