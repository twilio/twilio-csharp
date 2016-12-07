using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Chat.V1.Service.Channel 
{

    public class MessageResource : Resource 
    {
        private static Request BuildFetchRequest(FetchMessageOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Chat,
                "/v1/Services/" + options.ServiceSid + "/Channels/" + options.ChannelSid + "/Messages/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static MessageResource Fetch(FetchMessageOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<MessageResource> FetchAsync(FetchMessageOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static MessageResource Fetch(string serviceSid, string channelSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchMessageOptions(serviceSid, channelSid, sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<MessageResource> FetchAsync(string serviceSid, string channelSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchMessageOptions(serviceSid, channelSid, sid);
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildCreateRequest(CreateMessageOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Chat,
                "/v1/Services/" + options.ServiceSid + "/Channels/" + options.ChannelSid + "/Messages",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static MessageResource Create(CreateMessageOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<MessageResource> CreateAsync(CreateMessageOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static MessageResource Create(string serviceSid, string channelSid, string body, string from = null, string attributes = null, ITwilioRestClient client = null)
        {
            var options = new CreateMessageOptions(serviceSid, channelSid, body){From = from, Attributes = attributes};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<MessageResource> CreateAsync(string serviceSid, string channelSid, string body, string from = null, string attributes = null, ITwilioRestClient client = null)
        {
            var options = new CreateMessageOptions(serviceSid, channelSid, body){From = from, Attributes = attributes};
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        private static Request BuildReadRequest(ReadMessageOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Chat,
                "/v1/Services/" + options.ServiceSid + "/Channels/" + options.ChannelSid + "/Messages",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<MessageResource> Read(ReadMessageOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<MessageResource>.FromJson("messages", response.Content);
            return new ResourceSet<MessageResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<MessageResource>> ReadAsync(ReadMessageOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<MessageResource> Read(string serviceSid, string channelSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadMessageOptions(serviceSid, channelSid){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<MessageResource>> ReadAsync(string serviceSid, string channelSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadMessageOptions(serviceSid, channelSid){PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<MessageResource> NextPage(Page<MessageResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Chat,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<MessageResource>.FromJson("messages", response.Content);
        }
    
        private static Request BuildDeleteRequest(DeleteMessageOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Chat,
                "/v1/Services/" + options.ServiceSid + "/Channels/" + options.ChannelSid + "/Messages/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeleteMessageOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteMessageOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(string serviceSid, string channelSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteMessageOptions(serviceSid, channelSid, sid);
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string serviceSid, string channelSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteMessageOptions(serviceSid, channelSid, sid);
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateMessageOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Chat,
                "/v1/Services/" + options.ServiceSid + "/Channels/" + options.ChannelSid + "/Messages/" + options.Sid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static MessageResource Update(UpdateMessageOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<MessageResource> UpdateAsync(UpdateMessageOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static MessageResource Update(string serviceSid, string channelSid, string sid, string body, string attributes = null, ITwilioRestClient client = null)
        {
            var options = new UpdateMessageOptions(serviceSid, channelSid, sid, body){Attributes = attributes};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<MessageResource> UpdateAsync(string serviceSid, string channelSid, string sid, string body, string attributes = null, ITwilioRestClient client = null)
        {
            var options = new UpdateMessageOptions(serviceSid, channelSid, sid, body){Attributes = attributes};
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a MessageResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> MessageResource object represented by the provided JSON </returns> 
        public static MessageResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<MessageResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("attributes")]
        public string Attributes { get; private set; }
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }
        [JsonProperty("to")]
        public string To { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("was_edited")]
        public bool? WasEdited { get; private set; }
        [JsonProperty("from")]
        public string From { get; private set; }
        [JsonProperty("body")]
        public string Body { get; private set; }
        [JsonProperty("index")]
        public int? Index { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private MessageResource()
        {
        
        }
    }

}