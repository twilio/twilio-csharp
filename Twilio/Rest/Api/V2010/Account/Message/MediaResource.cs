using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Message {

    public class MediaResource : Resource {
        /// <summary>
        /// Delete media from your account. Once delete, you will no longer be billed
        /// </summary>
        ///
        /// <param name="messageSid"> The message_sid </param>
        /// <param name="sid"> Delete by unique media Sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> MediaDeleter capable of executing the delete </returns> 
        public static MediaDeleter Deleter(string messageSid, string sid, string accountSid=null) {
            return new MediaDeleter(messageSid, sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// Fetch a single media instance belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="messageSid"> The message_sid </param>
        /// <param name="sid"> Fetch by unique media Sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> MediaFetcher capable of executing the fetch </returns> 
        public static MediaFetcher Fetcher(string messageSid, string sid, string accountSid=null) {
            return new MediaFetcher(messageSid, sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// Retrieve a list of medias belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="messageSid"> The message_sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="dateCreated"> Filter by date created </param>
        /// <returns> MediaReader capable of executing the read </returns> 
        public static MediaReader Reader(string messageSid, string accountSid=null, string dateCreated=null) {
            return new MediaReader(messageSid, accountSid:accountSid, dateCreated:dateCreated);
        }
    
        /// <summary>
        /// Converts a JSON string into a MediaResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> MediaResource object represented by the provided JSON </returns> 
        public static MediaResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<MediaResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("content_type")]
        public string contentType { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("parent_sid")]
        public string parentSid { get; }
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("uri")]
        public string uri { get; }
    
        public MediaResource() {
        
        }
    
        private MediaResource([JsonProperty("account_sid")]
                              string accountSid, 
                              [JsonProperty("content_type")]
                              string contentType, 
                              [JsonProperty("date_created")]
                              string dateCreated, 
                              [JsonProperty("date_updated")]
                              string dateUpdated, 
                              [JsonProperty("parent_sid")]
                              string parentSid, 
                              [JsonProperty("sid")]
                              string sid, 
                              [JsonProperty("uri")]
                              string uri) {
            this.accountSid = accountSid;
            this.contentType = contentType;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.parentSid = parentSid;
            this.sid = sid;
            this.uri = uri;
        }
    }
}