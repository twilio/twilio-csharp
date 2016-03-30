using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;

namespace Twilio.Creators.Api.V2010.Account {

    public class MessageCreator : Creator<MessageResource> {
        private string accountSid;
        private Twilio.Types.PhoneNumber to;
        private Twilio.Types.PhoneNumber from;
        private string body;
        private List<Uri> mediaUrl;
        private Uri statusCallback;
        private string applicationSid;
    
        /**
         * Construct a new MessageCreator
         * 
         * @param accountSid The account_sid
         * @param to The phone number to receive the message
         * @param from The phone number that initiated the message
         * @param body The body
         */
        public MessageCreator(string accountSid, Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, string body) {
            this.accountSid = accountSid;
            this.to = to;
            this.from = from;
            this.body = body;
        }
    
        /**
         * Construct a new MessageCreator
         * 
         * @param accountSid The account_sid
         * @param to The phone number to receive the message
         * @param from The phone number that initiated the message
         * @param mediaUrl The media_url
         */
        public MessageCreator(string accountSid, Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, List<Uri> mediaUrl) {
            this.accountSid = accountSid;
            this.to = to;
            this.from = from;
            this.mediaUrl = mediaUrl;
        }
    
        /**
         * The URL that Twilio will POST to each time your message status changes
         * 
         * @param statusCallback URL Twilio will request when the status changes
         * @return this
         */
        public MessageCreator setStatusCallback(Uri statusCallback) {
            this.statusCallback = statusCallback;
            return this;
        }
    
        /**
         * The URL that Twilio will POST to each time your message status changes
         * 
         * @param statusCallback URL Twilio will request when the status changes
         * @return this
         */
        public MessageCreator setStatusCallback(string statusCallback) {
            return setStatusCallback(Promoter.UriFromString(statusCallback));
        }
    
        /**
         * Twilio the POST MessageSid as well as MessageStatus to the URL in the
         * MessageStatusCallback property of this Application
         * 
         * @param applicationSid The application to use for callbacks
         * @return this
         */
        public MessageCreator setApplicationSid(string applicationSid) {
            this.applicationSid = applicationSid;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Created MessageResource
         */
        public override async Task<MessageResource> ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Post,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Messages.json"
            );
            
            addPostParams(request);
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("MessageResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_CREATED) {
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
            
            return MessageResource.FromJson(response.GetContent());
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