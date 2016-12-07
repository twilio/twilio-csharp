using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class MessageResource : Resource 
    {
        public sealed class StatusEnum : StringEnum 
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}
        
            public static readonly StatusEnum Queued = new StatusEnum("queued");
            public static readonly StatusEnum Sending = new StatusEnum("sending");
            public static readonly StatusEnum Sent = new StatusEnum("sent");
            public static readonly StatusEnum Failed = new StatusEnum("failed");
            public static readonly StatusEnum Delivered = new StatusEnum("delivered");
            public static readonly StatusEnum Undelivered = new StatusEnum("undelivered");
            public static readonly StatusEnum Receiving = new StatusEnum("receiving");
            public static readonly StatusEnum Received = new StatusEnum("received");
        }
    
        public sealed class DirectionEnum : StringEnum 
        {
            private DirectionEnum(string value) : base(value) {}
            public DirectionEnum() {}
        
            public static readonly DirectionEnum Inbound = new DirectionEnum("inbound");
            public static readonly DirectionEnum OutboundApi = new DirectionEnum("outbound-api");
            public static readonly DirectionEnum OutboundCall = new DirectionEnum("outbound-call");
            public static readonly DirectionEnum OutboundReply = new DirectionEnum("outbound-reply");
        }
    
        private static Request BuildCreateRequest(CreateMessageOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Messages.json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Send a message from the account used to make the request
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
        /// Send a message from the account used to make the request
        /// </summary>
        public static MessageResource Create(Types.PhoneNumber to, string accountSid = null, Types.PhoneNumber from = null, string messagingServiceSid = null, string body = null, List<Uri> mediaUrl = null, Uri statusCallback = null, string applicationSid = null, decimal? maxPrice = null, bool? provideFeedback = null, ITwilioRestClient client = null)
        {
            var options = new CreateMessageOptions(to){AccountSid = accountSid, From = from, MessagingServiceSid = messagingServiceSid, Body = body, MediaUrl = mediaUrl, StatusCallback = statusCallback, ApplicationSid = applicationSid, MaxPrice = maxPrice, ProvideFeedback = provideFeedback};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<MessageResource> CreateAsync(Types.PhoneNumber to, string accountSid = null, Types.PhoneNumber from = null, string messagingServiceSid = null, string body = null, List<Uri> mediaUrl = null, Uri statusCallback = null, string applicationSid = null, decimal? maxPrice = null, bool? provideFeedback = null, ITwilioRestClient client = null)
        {
            var options = new CreateMessageOptions(to){AccountSid = accountSid, From = from, MessagingServiceSid = messagingServiceSid, Body = body, MediaUrl = mediaUrl, StatusCallback = statusCallback, ApplicationSid = applicationSid, MaxPrice = maxPrice, ProvideFeedback = provideFeedback};
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteMessageOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Messages/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Deletes a message record from your account
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
        /// Deletes a message record from your account
        /// </summary>
        public static bool Delete(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteMessageOptions(sid){AccountSid = accountSid};
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteMessageOptions(sid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        private static Request BuildFetchRequest(FetchMessageOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Messages/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Fetch a message belonging to the account used to make the request
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
        /// Fetch a message belonging to the account used to make the request
        /// </summary>
        public static MessageResource Fetch(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchMessageOptions(sid){AccountSid = accountSid};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<MessageResource> FetchAsync(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchMessageOptions(sid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildReadRequest(ReadMessageOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Messages.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Retrieve a list of messages belonging to the account used to make the request
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
        /// Retrieve a list of messages belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<MessageResource> Read(string accountSid = null, Types.PhoneNumber to = null, Types.PhoneNumber from = null, string dateSent = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadMessageOptions{AccountSid = accountSid, To = to, From = from, DateSent = dateSent, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<MessageResource>> ReadAsync(string accountSid = null, Types.PhoneNumber to = null, Types.PhoneNumber from = null, string dateSent = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadMessageOptions{AccountSid = accountSid, To = to, From = from, DateSent = dateSent, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<MessageResource> NextPage(Page<MessageResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<MessageResource>.FromJson("messages", response.Content);
        }
    
        private static Request BuildUpdateRequest(UpdateMessageOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Messages/" + options.Sid + ".json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// To redact a message-body from a post-flight message record, post to the message instance resource with an empty body
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
        /// To redact a message-body from a post-flight message record, post to the message instance resource with an empty body
        /// </summary>
        public static MessageResource Update(string sid, string body, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new UpdateMessageOptions(sid, body){AccountSid = accountSid};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<MessageResource> UpdateAsync(string sid, string body, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new UpdateMessageOptions(sid, body){AccountSid = accountSid};
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
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("api_version")]
        public string ApiVersion { get; private set; }
        [JsonProperty("body")]
        public string Body { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("date_sent")]
        public DateTime? DateSent { get; private set; }
        [JsonProperty("direction")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageResource.DirectionEnum Direction { get; private set; }
        [JsonProperty("error_code")]
        public int? ErrorCode { get; private set; }
        [JsonProperty("error_message")]
        public string ErrorMessage { get; private set; }
        [JsonProperty("from")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Types.PhoneNumber From { get; private set; }
        [JsonProperty("messaging_service_sid")]
        public string MessagingServiceSid { get; private set; }
        [JsonProperty("num_media")]
        public string NumMedia { get; private set; }
        [JsonProperty("num_segments")]
        public string NumSegments { get; private set; }
        [JsonProperty("price")]
        public decimal? Price { get; private set; }
        [JsonProperty("price_unit")]
        public string PriceUnit { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageResource.StatusEnum Status { get; private set; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> SubresourceUris { get; private set; }
        [JsonProperty("to")]
        public string To { get; private set; }
        [JsonProperty("uri")]
        public string Uri { get; private set; }
    
        private MessageResource()
        {
        
        }
    }

}