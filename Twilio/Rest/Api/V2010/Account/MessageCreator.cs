using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class MessageCreator : Creator<MessageResource> 
    {
        public string AccountSid { get; set; }
        public Types.PhoneNumber To { get; }
        public Types.PhoneNumber From { get; }
        public string MessagingServiceSid { get; }
        public string Body { get; }
        public List<Uri> MediaUrl { get; }
        public Uri StatusCallback { get; set; }
        public string ApplicationSid { get; set; }
        public decimal? MaxPrice { get; set; }
        public bool? ProvideFeedback { get; set; }
    
        /// <summary>
        /// Construct a new MessageCreator
        /// </summary>
        ///
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="from"> The phone number that initiated the message </param>
        /// <param name="body"> The body </param>
        public MessageCreator(Types.PhoneNumber to, Types.PhoneNumber from, string body)
        {
            To = to;
            From = from;
            Body = body;
        }
    
        /// <summary>
        /// Construct a new MessageCreator
        /// </summary>
        ///
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="from"> The phone number that initiated the message </param>
        /// <param name="mediaUrl"> The media_url </param>
        public MessageCreator(Types.PhoneNumber to, Types.PhoneNumber from, List<Uri> mediaUrl)
        {
            To = to;
            From = from;
            MediaUrl = mediaUrl;
        }
    
        /// <summary>
        /// Construct a new MessageCreator
        /// </summary>
        ///
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="body"> The body </param>
        public MessageCreator(Types.PhoneNumber to, string messagingServiceSid, string body)
        {
            To = to;
            MessagingServiceSid = messagingServiceSid;
            Body = body;
        }
    
        /// <summary>
        /// Construct a new MessageCreator
        /// </summary>
        ///
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="mediaUrl"> The media_url </param>
        public MessageCreator(Types.PhoneNumber to, string messagingServiceSid, List<Uri> mediaUrl)
        {
            To = to;
            MessagingServiceSid = messagingServiceSid;
            MediaUrl = mediaUrl;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created MessageResource </returns> 
        public override async System.Threading.Tasks.Task<MessageResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/Messages.json"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("MessageResource creation failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return MessageResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created MessageResource </returns> 
        public override MessageResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/Messages.json"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("MessageResource creation failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return MessageResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (To != null)
            {
                request.AddPostParam("To", To.ToString());
            }
            
            if (From != null)
            {
                request.AddPostParam("From", From.ToString());
            }
            
            if (MessagingServiceSid != null)
            {
                request.AddPostParam("MessagingServiceSid", MessagingServiceSid);
            }
            
            if (Body != null)
            {
                request.AddPostParam("Body", Body);
            }
            
            if (MediaUrl != null)
            {
                request.AddPostParam("MediaUrl", MediaUrl.ToString());
            }
            
            if (StatusCallback != null)
            {
                request.AddPostParam("StatusCallback", StatusCallback.ToString());
            }
            
            if (ApplicationSid != null)
            {
                request.AddPostParam("ApplicationSid", ApplicationSid);
            }
            
            if (MaxPrice != null)
            {
                request.AddPostParam("MaxPrice", MaxPrice.ToString());
            }
            
            if (ProvideFeedback != null)
            {
                request.AddPostParam("ProvideFeedback", ProvideFeedback.ToString());
            }
        }
    }
}