using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;
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
    
        /// <summary>
        /// Send a message from the account used to make the request
        /// </summary>
        ///
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="from"> The phone number that initiated the message </param>
        /// <param name="body"> The body </param>
        /// <returns> MessageCreator capable of executing the create </returns> 
        public static MessageCreator Creator(Types.PhoneNumber to, Types.PhoneNumber from, string body)
        {
            return new MessageCreator(to, from, body);
        }
    
        /// <summary>
        /// Send a message from the account used to make the request
        /// </summary>
        ///
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="from"> The phone number that initiated the message </param>
        /// <param name="mediaUrl"> The media_url </param>
        /// <returns> MessageCreator capable of executing the create </returns> 
        public static MessageCreator Creator(Types.PhoneNumber to, Types.PhoneNumber from, List<Uri> mediaUrl)
        {
            return new MessageCreator(to, from, mediaUrl);
        }
    
        /// <summary>
        /// Send a message from the account used to make the request
        /// </summary>
        ///
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="body"> The body </param>
        /// <returns> MessageCreator capable of executing the create </returns> 
        public static MessageCreator Creator(Types.PhoneNumber to, string messagingServiceSid, string body)
        {
            return new MessageCreator(to, messagingServiceSid, body);
        }
    
        /// <summary>
        /// Send a message from the account used to make the request
        /// </summary>
        ///
        /// <param name="to"> The phone number to receive the message </param>
        /// <param name="messagingServiceSid"> The messaging_service_sid </param>
        /// <param name="mediaUrl"> The media_url </param>
        /// <returns> MessageCreator capable of executing the create </returns> 
        public static MessageCreator Creator(Types.PhoneNumber to, string messagingServiceSid, List<Uri> mediaUrl)
        {
            return new MessageCreator(to, messagingServiceSid, mediaUrl);
        }
    
        /// <summary>
        /// Deletes a message record from your account
        /// </summary>
        ///
        /// <param name="sid"> The message to delete </param>
        /// <returns> MessageDeleter capable of executing the delete </returns> 
        public static MessageDeleter Deleter(string sid)
        {
            return new MessageDeleter(sid);
        }
    
        /// <summary>
        /// Fetch a message belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique message Sid </param>
        /// <returns> MessageFetcher capable of executing the fetch </returns> 
        public static MessageFetcher Fetcher(string sid)
        {
            return new MessageFetcher(sid);
        }
    
        /// <summary>
        /// Retrieve a list of messages belonging to the account used to make the request
        /// </summary>
        ///
        /// <returns> MessageReader capable of executing the read </returns> 
        public static MessageReader Reader()
        {
            return new MessageReader();
        }
    
        /// <summary>
        /// To redact a message-body from a post-flight message record, post to the message instance resource with an empty body
        /// </summary>
        ///
        /// <param name="sid"> The message to redact </param>
        /// <param name="body"> The body </param>
        /// <returns> MessageUpdater capable of executing the update </returns> 
        public static MessageUpdater Updater(string sid, string body)
        {
            return new MessageUpdater(sid, body);
        }
    
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
        public string AccountSid { get; set; }
        [JsonProperty("api_version")]
        public string ApiVersion { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("date_sent")]
        public DateTime? DateSent { get; set; }
        [JsonProperty("direction")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageResource.DirectionEnum Direction { get; set; }
        [JsonProperty("error_code")]
        public int? ErrorCode { get; set; }
        [JsonProperty("error_message")]
        public string ErrorMessage { get; set; }
        [JsonProperty("from")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Types.PhoneNumber From { get; set; }
        [JsonProperty("messaging_service_sid")]
        public string MessagingServiceSid { get; set; }
        [JsonProperty("num_media")]
        public string NumMedia { get; set; }
        [JsonProperty("num_segments")]
        public string NumSegments { get; set; }
        [JsonProperty("price")]
        public decimal? Price { get; set; }
        [JsonProperty("price_unit")]
        public string PriceUnit { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageResource.StatusEnum Status { get; set; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> SubresourceUris { get; set; }
        [JsonProperty("to")]
        public string To { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
    
        public MessageResource()
        {
        
        }
    
        private MessageResource([JsonProperty("account_sid")]
                                string accountSid, 
                                [JsonProperty("api_version")]
                                string apiVersion, 
                                [JsonProperty("body")]
                                string body, 
                                [JsonProperty("date_created")]
                                string dateCreated, 
                                [JsonProperty("date_updated")]
                                string dateUpdated, 
                                [JsonProperty("date_sent")]
                                string dateSent, 
                                [JsonProperty("direction")]
                                MessageResource.DirectionEnum direction, 
                                [JsonProperty("error_code")]
                                int? errorCode, 
                                [JsonProperty("error_message")]
                                string errorMessage, 
                                [JsonProperty("from")]
                                Types.PhoneNumber from, 
                                [JsonProperty("messaging_service_sid")]
                                string messagingServiceSid, 
                                [JsonProperty("num_media")]
                                string numMedia, 
                                [JsonProperty("num_segments")]
                                string numSegments, 
                                [JsonProperty("price")]
                                decimal? price, 
                                [JsonProperty("price_unit")]
                                string priceUnit, 
                                [JsonProperty("sid")]
                                string sid, 
                                [JsonProperty("status")]
                                MessageResource.StatusEnum status, 
                                [JsonProperty("subresource_uris")]
                                Dictionary<string, string> subresourceUris, 
                                [JsonProperty("to")]
                                string to, 
                                [JsonProperty("uri")]
                                string uri)
                                {
            AccountSid = accountSid;
            ApiVersion = apiVersion;
            Body = body;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            DateSent = MarshalConverter.DateTimeFromString(dateSent);
            Direction = direction;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            From = from;
            MessagingServiceSid = messagingServiceSid;
            NumMedia = numMedia;
            NumSegments = numSegments;
            Price = price;
            PriceUnit = priceUnit;
            Sid = sid;
            Status = status;
            SubresourceUris = subresourceUris;
            To = to;
            Uri = uri;
        }
    }
}