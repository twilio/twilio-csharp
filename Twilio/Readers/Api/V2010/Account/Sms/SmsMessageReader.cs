using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account.Sms;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Readers.Api.V2010.Account.Sms {

    public class SmsMessageReader : Reader<SmsMessageResource> {
        private string accountSid;
        private Twilio.Types.PhoneNumber to;
        private Twilio.Types.PhoneNumber from;
        private string dateSent;
    
        /**
         * Construct a new SmsMessageReader
         * 
         * @param accountSid The account_sid
         */
        public SmsMessageReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /**
         * The to
         * 
         * @param to The to
         * @return this
         */
        public SmsMessageReader ByTo(Twilio.Types.PhoneNumber to) {
            this.to = to;
            return this;
        }
    
        /**
         * The from
         * 
         * @param from The from
         * @return this
         */
        public SmsMessageReader ByFrom(Twilio.Types.PhoneNumber from) {
            this.from = from;
            return this;
        }
    
        /**
         * The date_sent
         * 
         * @param dateSent The date_sent
         * @return this
         */
        public SmsMessageReader ByDateSent(string dateSent) {
            this.dateSent = dateSent;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return SmsMessageResource ResourceSet
         */
        public override Task<ResourceSet<SmsMessageResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SMS/Messages.json"
            );
            
            AddQueryParams(request);
            
            Page<SmsMessageResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<SmsMessageResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return SmsMessageResource ResourceSet
         */
        public override ResourceSet<SmsMessageResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SMS/Messages.json"
            );
            
            AddQueryParams(request);
            
            Page<SmsMessageResource> page = PageForRequest(client, request);
            
            return new ResourceSet<SmsMessageResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<SmsMessageResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of SmsMessageResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<SmsMessageResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("SmsMessageResource read failed: Unable to connect to server");
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
            
            Page<SmsMessageResource> result = new Page<SmsMessageResource>();
            result.deserialize("sms_messages", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (to != null) {
                request.AddQueryParam("To", to.ToString());
            }
            
            if (from != null) {
                request.AddQueryParam("From", from.ToString());
            }
            
            if (dateSent != null) {
                request.AddQueryParam("DateSent", dateSent);
            }
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}