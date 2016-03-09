using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.sms.SmsMessage;
using com.twilio.sdk.readers.Reader;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Api.V2010.Account.Sms {

    public class SmsMessageReader : Reader<SmsMessage> {
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
         * @param client TwilioRestClient with which to make the request
         * @return SmsMessage ResourceSet
         */
        [Override]
        public ResourceSet<SmsMessage> execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SMS/Messages.json",
                client.getAccountSid()
            );
            
            addQueryParams(request);
            
            Page<SmsMessage> page = pageForRequest(client, request);
            
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
        public Page<SmsMessage> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                nextPageUri,
                client.getAccountSid()
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of SmsMessage Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<SmsMessage> pageForRequest(final TwilioRestClient client, final Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("SmsMessage read failed: Unable to connect to server");
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
            
            Page<SmsMessage> result = new Page<>();
            result.deserialize("sms_messages", response.getContent(), SmsMessage.class, client.getObjectMapper());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void addQueryParams(final Request request) {
            if (to != null) {
                request.addQueryParam("To", to.ToString());
            }
            
            if (from != null) {
                request.addQueryParam("From", from.ToString());
            }
            
            if (dateSent != null) {
                request.addQueryParam("DateSent", dateSent);
            }
            
            request.addQueryParam("PageSize", Integer.toString(getPageSize()));
        }
    }
}