using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Deleters.Api.V2010.Account.Message;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Message;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Message;

namespace Twilio.Rest.Api.V2010.Account.Message {

    public class Media : SidResource {
        /**
         * Delete media from your account. Once delete, you will no longer be billed
         * 
         * @param accountSid The account_sid
         * @param messageSid The message_sid
         * @param sid Delete by unique media Sid
         * @return MediaDeleter capable of executing the delete
         */
        public static MediaDeleter Delete(string accountSid, string messageSid, string sid) {
            return new MediaDeleter(accountSid, messageSid, sid);
        }
    
        /**
         * Create a MediaDeleter to execute delete.
         * 
         * @param messageSid The message_sid
         * @param sid Delete by unique media Sid
         * @return MediaDeleter capable of executing the delete
         */
        public static MediaDeleter Delete(string messageSid, 
                                          string sid) {
            return new MediaDeleter(messageSid, sid);
        }
    
        /**
         * Fetch a single media instance belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @param messageSid The message_sid
         * @param sid Fetch by unique media Sid
         * @return MediaFetcher capable of executing the fetch
         */
        public static MediaFetcher Fetch(string accountSid, string messageSid, string sid) {
            return new MediaFetcher(accountSid, messageSid, sid);
        }
    
        /**
         * Create a MediaFetcher to execute fetch.
         * 
         * @param messageSid The message_sid
         * @param sid Fetch by unique media Sid
         * @return MediaFetcher capable of executing the fetch
         */
        public static MediaFetcher Fetch(string messageSid, 
                                         string sid) {
            return new MediaFetcher(messageSid, sid);
        }
    
        /**
         * Retrieve a list of medias belonging to the account used to make the request
         * 
         * @param accountSid The account_sid
         * @param messageSid The message_sid
         * @return MediaReader capable of executing the read
         */
        public static MediaReader Read(string accountSid, string messageSid) {
            return new MediaReader(accountSid, messageSid);
        }
    
        /**
         * Create a MediaReader to execute read.
         * 
         * @param messageSid The message_sid
         * @return MediaReader capable of executing the read
         */
        public static MediaReader Read(string messageSid) {
            return new MediaReader(messageSid);
        }
    
        /**
         * Converts a JSON string into a Media object
         * 
         * @param json Raw JSON string
         * @return Media object represented by the provided JSON
         */
        public static Media FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Media>(json);
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
    
        public Media() {
        
        }
    
        private Media([JsonProperty("account_sid")]
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
    
        /**
         * @return The unique sid that identifies this account
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The default mime-type of the media
         */
        public string GetContentType() {
            return this.contentType;
        }
    
        /**
         * @return The date this resource was created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date this resource was last updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The unique id of the resource that created the media.
         */
        public string GetParentSid() {
            return this.parentSid;
        }
    
        /**
         * @return A string that uniquely identifies this media
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The URI for this resource
         */
        public string GetUri() {
            return this.uri;
        }
    }
}