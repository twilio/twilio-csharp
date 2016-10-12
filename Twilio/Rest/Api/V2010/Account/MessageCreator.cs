using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class MessageCreator : Creator<MessageResource> {
        private string accountSid;
        private Twilio.Types.PhoneNumber to;
        private Twilio.Types.PhoneNumber from;
        private string messagingServiceSid;
        private string body;
        private List<Uri> mediaUrl;
        private Uri statusCallback;
        private string applicationSid;
        private decimal? maxPrice;
        private bool? provideFeedback;
    
        /**
         * Construct a new MessageCreator.
         * 
         * @param to The phone number to receive the message
         * @param from The phone number that initiated the message
         * @param body The body
         */
        public MessageCreator(Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, string body) {
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
         * @param body The body
         */
        public MessageCreator(string accountSid, Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, string body) {
            this.accountSid = accountSid;
            this.to = to;
            this.from = from;
            this.body = body;
        }
    
        /**
         * Construct a new MessageCreator.
         * 
         * @param to The phone number to receive the message
         * @param from The phone number that initiated the message
         * @param mediaUrl The media_url
         */
        public MessageCreator(Twilio.Types.PhoneNumber to, Twilio.Types.PhoneNumber from, List<Uri> mediaUrl) {
            this.to = to;
            this.from = from;
            this.mediaUrl = mediaUrl;
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
         * Construct a new MessageCreator.
         * 
         * @param to The phone number to receive the message
         * @param messagingServiceSid The messaging_service_sid
         * @param body The body
         */
        public MessageCreator(Twilio.Types.PhoneNumber to, string messagingServiceSid, string body) {
            this.to = to;
            this.messagingServiceSid = messagingServiceSid;
            this.body = body;
        }
    
        /**
         * Construct a new MessageCreator
         * 
         * @param accountSid The account_sid
         * @param to The phone number to receive the message
         * @param messagingServiceSid The messaging_service_sid
         * @param body The body
         */
        public MessageCreator(string accountSid, Twilio.Types.PhoneNumber to, string messagingServiceSid, string body) {
            this.accountSid = accountSid;
            this.to = to;
            this.messagingServiceSid = messagingServiceSid;
            this.body = body;
        }
    
        /**
         * Construct a new MessageCreator.
         * 
         * @param to The phone number to receive the message
         * @param messagingServiceSid The messaging_service_sid
         * @param mediaUrl The media_url
         */
        public MessageCreator(Twilio.Types.PhoneNumber to, string messagingServiceSid, List<Uri> mediaUrl) {
            this.to = to;
            this.messagingServiceSid = messagingServiceSid;
            this.mediaUrl = mediaUrl;
        }
    
        /**
         * Construct a new MessageCreator
         * 
         * @param accountSid The account_sid
         * @param to The phone number to receive the message
         * @param messagingServiceSid The messaging_service_sid
         * @param mediaUrl The media_url
         */
        public MessageCreator(string accountSid, Twilio.Types.PhoneNumber to, string messagingServiceSid, List<Uri> mediaUrl) {
            this.accountSid = accountSid;
            this.to = to;
            this.messagingServiceSid = messagingServiceSid;
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
         * The max_price
         * 
         * @param maxPrice The max_price
         * @return this
         */
        public MessageCreator setMaxPrice(decimal? maxPrice) {
            this.maxPrice = maxPrice;
            return this;
        }
    
        /**
         * The provide_feedback
         * 
         * @param provideFeedback The provide_feedback
         * @return this
         */
        public MessageCreator setProvideFeedback(bool? provideFeedback) {
            this.provideFeedback = provideFeedback;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created MessageResource
         */
        public override async Task<MessageResource> CreateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Messages.json"
            );
            
            addPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("MessageResource creation failed: Unable to connect to server");
            }
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to create record, " + response.GetStatusCode(),
                    restException.MoreInfo
                );
            }
            
            return MessageResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created MessageResource
         */
        public override MessageResource Create(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Messages.json"
            );
            
            addPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("MessageResource creation failed: Unable to connect to server");
            }
            
            if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.GetStatusCode(),
                    restException.Message ?? "Unable to create record, " + response.GetStatusCode(),
                    restException.MoreInfo
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
            
            if (messagingServiceSid != null) {
                request.AddPostParam("MessagingServiceSid", messagingServiceSid);
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
            
            if (maxPrice != null) {
                request.AddPostParam("MaxPrice", maxPrice.ToString());
            }
            
            if (provideFeedback != null) {
                request.AddPostParam("ProvideFeedback", provideFeedback.ToString());
            }
        }
    }
}