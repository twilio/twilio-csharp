using System;
using Newtonsoft.Json;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Constant;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.PreviewMessaging
{
    public class MessageCreator: Resource
    {
        public Message.CreateMessagesRequest CreateMessagesRequest { get; set; }
        public MessageCreator(Message.CreateMessagesRequest createMessagesRequest)
        {
            this.CreateMessagesRequest = createMessagesRequest;
        }

        private Request BuildCreateRequest(ITwilioRestClient client)
        {
            String path = "/v1/Messages";
            
            string PathAccountSid = client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            
            Request request = new Request(
                HttpMethod.Post,
                Rest.Domain.PreviewMessaging.ToString(),
                path,
                headerParams: null
            );

            request.ContentType = EnumConstants.ContentTypeEnum.JSON;
            AddPostParams(request, client);
            return request;
        }
        
        public Message Create(ITwilioRestClient client = null) 
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(client));
            return Message.FromJson(response.Content);
        }

        public void AddPostParams(Request request, ITwilioRestClient client) {
            if (this.CreateMessagesRequest != null) {
                request.Body = JsonConvert.SerializeObject(this.CreateMessagesRequest);
            }
        }
    }
}