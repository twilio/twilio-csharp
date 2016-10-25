using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Chat.V1.Service.Channel 
{

    public class MessageCreator : Creator<MessageResource> 
    {
        public string serviceSid { get; }
        public string channelSid { get; }
        public string body { get; }
        public string from { get; set; }
        public string attributes { get; set; }
    
        /// <summary>
        /// Construct a new MessageCreator
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="channelSid"> The channel_sid </param>
        /// <param name="body"> The body </param>
        /// <param name="from"> The from </param>
        /// <param name="attributes"> The attributes </param>
        public MessageCreator(string serviceSid, string channelSid, string body, string from=null, string attributes=null)
        {
            this.body = body;
            this.serviceSid = serviceSid;
            this.attributes = attributes;
            this.from = from;
            this.channelSid = channelSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created MessageResource </returns> 
        public override async Task<MessageResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.CHAT,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.channelSid + "/Messages"
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
                HttpMethod.POST,
                Domains.CHAT,
                "/v1/Services/" + this.serviceSid + "/Channels/" + this.channelSid + "/Messages"
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
            if (body != null)
            {
                request.AddPostParam("Body", body);
            }
            
            if (from != null)
            {
                request.AddPostParam("From", from);
            }
            
            if (attributes != null)
            {
                request.AddPostParam("Attributes", attributes);
            }
        }
    }
}