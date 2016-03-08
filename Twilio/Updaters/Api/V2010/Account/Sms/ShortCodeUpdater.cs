using Twilio.Clients.TwilioRestClient;
using Twilio.Converters.Promoter;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.sms.ShortCode;
using com.twilio.sdk.http.HttpMethod;
using com.twilio.sdk.updaters.Updater;
using java.net.URI;

namespace Twilio.Updaters.Api.V2010.Account.Sms {

    public class ShortCodeUpdater : Updater<ShortCode> {
        private String accountSid;
        private String sid;
        private String friendlyName;
        private String apiVersion;
        private URI smsUrl;
        private HttpMethod smsMethod;
        private URI smsFallbackUrl;
        private HttpMethod smsFallbackMethod;
    
        /**
         * Construct a new ShortCodeUpdater
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         */
        public ShortCodeUpdater(String accountSid, String sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /**
         * A human readable descriptive text for this resource, up to 64 characters
         * long. By default, the `FriendlyName` is just the short code.
         * 
         * @param friendlyName A human readable description of this resource
         * @return this
         */
        public ShortCodeUpdater setFriendlyName(String friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * SMSs to this short code will start a new TwiML session with this API version.
         * 
         * @param apiVersion The API version to use
         * @return this
         */
        public ShortCodeUpdater setApiVersion(String apiVersion) {
            this.apiVersion = apiVersion;
            return this;
        }
    
        /**
         * The URL Twilio will request when receiving an incoming SMS message to this
         * short code.
         * 
         * @param smsUrl URL Twilio will request when receiving an SMS
         * @return this
         */
        public ShortCodeUpdater setSmsUrl(URI smsUrl) {
            this.smsUrl = smsUrl;
            return this;
        }
    
        /**
         * The URL Twilio will request when receiving an incoming SMS message to this
         * short code.
         * 
         * @param smsUrl URL Twilio will request when receiving an SMS
         * @return this
         */
        public ShortCodeUpdater setSmsUrl(String smsUrl) {
            return setSmsUrl(Promoter.uriFromString(smsUrl));
        }
    
        /**
         * The HTTP method Twilio will use when making requests to the `SmsUrl`. Either
         * `GET` or `POST`.
         * 
         * @param smsMethod HTTP method to use when requesting the sms url
         * @return this
         */
        public ShortCodeUpdater setSmsMethod(HttpMethod smsMethod) {
            this.smsMethod = smsMethod;
            return this;
        }
    
        /**
         * The URL that Twilio will request if an error occurs retrieving or executing
         * the TwiML from `SmsUrl`.
         * 
         * @param smsFallbackUrl URL Twilio will request if an error occurs in
         *                       executing TwiML
         * @return this
         */
        public ShortCodeUpdater setSmsFallbackUrl(URI smsFallbackUrl) {
            this.smsFallbackUrl = smsFallbackUrl;
            return this;
        }
    
        /**
         * The URL that Twilio will request if an error occurs retrieving or executing
         * the TwiML from `SmsUrl`.
         * 
         * @param smsFallbackUrl URL Twilio will request if an error occurs in
         *                       executing TwiML
         * @return this
         */
        public ShortCodeUpdater setSmsFallbackUrl(String smsFallbackUrl) {
            return setSmsFallbackUrl(Promoter.uriFromString(smsFallbackUrl));
        }
    
        /**
         * The HTTP method Twilio will use when requesting the above URL. Either `GET`
         * or `POST`.
         * 
         * @param smsFallbackMethod HTTP method Twilio will use with sms fallback url
         * @return this
         */
        public ShortCodeUpdater setSmsFallbackMethod(HttpMethod smsFallbackMethod) {
            this.smsFallbackMethod = smsFallbackMethod;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated ShortCode
         */
        [Override]
        public ShortCode execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SMS/ShortCodes/" + this.sid + ".json",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ShortCode update failed: Unable to connect to server");
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
            
            return ShortCode.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (apiVersion != null) {
                request.addPostParam("ApiVersion", apiVersion);
            }
            
            if (smsUrl != null) {
                request.addPostParam("SmsUrl", smsUrl.toString());
            }
            
            if (smsMethod != null) {
                request.addPostParam("SmsMethod", smsMethod.toString());
            }
            
            if (smsFallbackUrl != null) {
                request.addPostParam("SmsFallbackUrl", smsFallbackUrl.toString());
            }
            
            if (smsFallbackMethod != null) {
                request.addPostParam("SmsFallbackMethod", smsFallbackMethod.toString());
            }
        }
    }
}