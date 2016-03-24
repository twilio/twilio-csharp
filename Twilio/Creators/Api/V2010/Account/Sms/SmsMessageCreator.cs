using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters.Promoter;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Sms;

namespace Twilio.Creators.Api.V2010.Account.Sms {

    public class SmsMessageCreator : Creator<SmsMessageResource> {
        private string accountSid;
        private Twilio.Types.PhoneNumber to;
        private Twilio.Types.PhoneNumber from;
        private string body;
        private List<Uri> mediaUrl;
        private Uri statusCallback;
        private string applicationSid;
    
        /**
         * Construct a new SmsMessageCreator
         * 
         * @param accountSid The account_sid
         * @param to The to
         * @param from The from
         * @param body The body
         */
        public SmsMessageCreator(string accountSid, Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, string body) {
            this.accountSid = accountSid;
            this.to = to;
            this.from = from;
            this.body = body;
        }
    
        /**
         * Construct a new SmsMessageCreator
         * 
         * @param accountSid The account_sid
         * @param to The to
         * @param from The from
         * @param mediaUrl The media_url
         */
        public SmsMessageCreator(string accountSid, Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, List<Uri> mediaUrl) {
            this.accountSid = accountSid;
            this.to = to;
            this.from = from;
            this.mediaUrl = mediaUrl;
        }
    
        /**
         * The status_callback
         * 
         * @param statusCallback The status_callback
         * @return this
         */
        public SmsMessageCreator setStatusCallback(Uri statusCallback) {
            this.statusCallback = statusCallback;
            return this;
        }
    
        /**
         * The status_callback
         * 
         * @param statusCallback The status_callback
         * @return this
         */
        public SmsMessageCreator setStatusCallback(string statusCallback) {
            return setStatusCallback(Promoter.UriFromString(statusCallback));
        }
    
        /**
         * The application_sid
         * 
         * @param applicationSid The application_sid
         * @return this
         */
        public SmsMessageCreator setApplicationSid(string applicationSid) {
            this.applicationSid = applicationSid;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created SmsMessageResource
         */
        public override SmsMessageResource execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SMS/Messages.json"
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("SmsMessageResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
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
            
            return SmsMessageResource.fromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (to != null) {
                request.addPostParam("To", to.ToString());
            }
            
            if (from != null) {
                request.addPostParam("From", from.ToString());
            }
            
            if (body != null) {
                request.addPostParam("Body", body);
            }
            
            if (mediaUrl != null) {
                request.addPostParam("MediaUrl", mediaUrl.ToString());
            }
            
            if (statusCallback != null) {
                request.addPostParam("StatusCallback", statusCallback.ToString());
            }
            
            if (applicationSid != null) {
                request.addPostParam("ApplicationSid", applicationSid);
            }
        }
    }
}