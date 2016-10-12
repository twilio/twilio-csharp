using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Message {

    public class MediaResource : SidResource {
        /// <summary>
        /// Delete media from your account. Once delete, you will no longer be billed
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="messageSid"> The message_sid </param>
        /// <param name="sid"> Delete by unique media Sid </param>
        /// <returns> MediaDeleter capable of executing the delete </returns> 
        public static MediaDeleter Deleter(string accountSid, string messageSid, string sid) {
            return new MediaDeleter(accountSid, messageSid, sid);
        }
    
        /// <summary>
        /// Create a MediaDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="messageSid"> The message_sid </param>
        /// <param name="sid"> Delete by unique media Sid </param>
        /// <returns> MediaDeleter capable of executing the delete </returns> 
        public static MediaDeleter Deleter(string messageSid, 
                                           string sid) {
            return new MediaDeleter(messageSid, sid);
        }
    
        /// <summary>
        /// Fetch a single media instance belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="messageSid"> The message_sid </param>
        /// <param name="sid"> Fetch by unique media Sid </param>
        /// <returns> MediaFetcher capable of executing the fetch </returns> 
        public static MediaFetcher Fetcher(string accountSid, string messageSid, string sid) {
            return new MediaFetcher(accountSid, messageSid, sid);
        }
    
        /// <summary>
        /// Create a MediaFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="messageSid"> The message_sid </param>
        /// <param name="sid"> Fetch by unique media Sid </param>
        /// <returns> MediaFetcher capable of executing the fetch </returns> 
        public static MediaFetcher Fetcher(string messageSid, 
                                           string sid) {
            return new MediaFetcher(messageSid, sid);
        }
    
        /// <summary>
        /// Retrieve a list of medias belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="messageSid"> The message_sid </param>
        /// <returns> MediaReader capable of executing the read </returns> 
        public static MediaReader Reader(string accountSid, string messageSid) {
            return new MediaReader(accountSid, messageSid);
        }
    
        /// <summary>
        /// Create a MediaReader to execute read.
        /// </summary>
        ///
        /// <param name="messageSid"> The message_sid </param>
        /// <returns> MediaReader capable of executing the read </returns> 
        public static MediaReader Reader(string messageSid) {
            return new MediaReader(messageSid);
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
        private readonly string accountSid;
        [JsonProperty("content_type")]
        private readonly string contentType;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("parent_sid")]
        private readonly string parentSid;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("uri")]
        private readonly string uri;
    
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
    
        /// <returns> The unique sid that identifies this account </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The default mime-type of the media </returns> 
        public string GetContentType() {
            return this.contentType;
        }
    
        /// <returns> The date this resource was created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date this resource was last updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The unique id of the resource that created the media. </returns> 
        public string GetParentSid() {
            return this.parentSid;
        }
    
        /// <returns> A string that uniquely identifies this media </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The URI for this resource </returns> 
        public string GetUri() {
            return this.uri;
        }
    }
}