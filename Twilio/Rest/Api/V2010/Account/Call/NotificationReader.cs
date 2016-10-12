using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Call {

    public class NotificationReader : Reader<NotificationResource> {
        private string accountSid;
        private string callSid;
        private int? log;
        private string messageDate;
    
        /**
         * Construct a new NotificationReader.
         * 
         * @param callSid The call_sid
         */
        public NotificationReader(string callSid) {
            this.callSid = callSid;
        }
    
        /**
         * Construct a new NotificationReader
         * 
         * @param accountSid The account_sid
         * @param callSid The call_sid
         */
        public NotificationReader(string accountSid, string callSid) {
            this.accountSid = accountSid;
            this.callSid = callSid;
        }
    
        /**
         * The log
         * 
         * @param log The log
         * @return this
         */
        public NotificationReader ByLog(int? log) {
            this.log = log;
            return this;
        }
    
        /**
         * The message_date
         * 
         * @param messageDate The message_date
         * @return this
         */
        public NotificationReader ByMessageDate(string messageDate) {
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
        public override Task<ResourceSet<NotificationResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Calls/" + this.callSid + "/Notifications.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<NotificationResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return NotificationResource ResourceSet
         */
        public override ResourceSet<NotificationResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Calls/" + this.callSid + "/Notifications.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<NotificationResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<NotificationResource> NextPage(Page<NotificationResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.API
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /**
         * Generate a Page of NotificationResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<NotificationResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("NotificationResource read failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to read records, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return Page<NotificationResource>.FromJson("notifications", response.Content);
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
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}