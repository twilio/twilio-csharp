using System;
using System.Collections.Generic;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account.Sms;

#if NET40
using System.Threading.Tasks;
#endif

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
         * Construct a new SmsMessageCreator.
         * 
         * @param to The to
         * @param from The from
         * @param body The body
         */
        public SmsMessageCreator(Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, string body) {
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
         * @param body The body
         */
        public SmsMessageCreator(string accountSid, Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, string body) {
            this.accountSid = accountSid;
            this.to = to;
            this.from = from;
            this.body = body;
        }
    
        /**
         * Construct a new SmsMessageCreator.
         * 
         * @param to The to
         * @param from The from
         * @param mediaUrl The media_url
         */
        public SmsMessageCreator(Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, List<Uri> mediaUrl) {
            this.to = to;
            this.from = from;
            this.mediaUrl = mediaUrl;
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
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created SmsMessageResource
         */
        public override async Task<SmsMessageResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SMS/Messages.json"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("SmsMessageResource creation failed: Unable to connect to server");
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
            
            return SmsMessageResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created SmsMessageResource
         */
        public override SmsMessageResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/SMS/Messages.json"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("SmsMessageResource creation failed: Unable to connect to server");
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
            
            return SmsMessageResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (to != null) {
                request.AddPostParam("To", to.ToString());
            }
            
            if (from != null) {
                request.AddPostParam("From", from.ToString());
            }
            
            if (body != null) {
                request.AddPostParam("Body", body);
            }
            
            if (mediaUrl != null) {
                request.AddPostParam("MediaUrl", mediaUrl.ToString());
            }
            
            if (statusCallback != null) {
                request.AddPostParam("StatusCallback", statusCallback.ToString());
            }
            
            if (applicationSid != null) {
                request.AddPostParam("ApplicationSid", applicationSid);
            }
        }
    }
}