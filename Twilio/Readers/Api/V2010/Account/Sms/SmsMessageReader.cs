using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account.Sms;

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
        public SmsMessageReader byTo(Twilio.Types.PhoneNumber to) {
            this.to = to;
            return this;
        }
    
        /**
         * The from
         * 
         * @param from The from
         * @return this
         */
        public SmsMessageReader byFrom(Twilio.Types.PhoneNumber from) {
            this.from = from;
            return this;
        }
    
        /**
         * The date_sent
         * 
         * @param dateSent The date_sent
         * @return this
         */
        public SmsMessageReader byDateSent(string dateSent) {
            this.dateSent = dateSent;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return SmsMessageResource ResourceSet
         */
        public override async Task<ResourceSet<SmsMessageResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SMS/Messages.json"
            );
            
            AddQueryParams(request);
            
            Page<SmsMessageResource> page = await PageForRequest(client, request);
            
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
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            
            var task = PageForRequest(client, request);
            task.Wait();
            
            return task.Result;
        }
    
        /**
         * Generate a Page of SmsMessageResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected async Task<Page<SmsMessageResource>> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("SmsMessageResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() != HttpStatus.HTTP_STATUS_CODE_OK) {
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