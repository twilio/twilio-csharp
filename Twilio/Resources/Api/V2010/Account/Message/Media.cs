using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Deleters.Api.V2010.Account.Message;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Message;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Message;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account.Message {

    public class Media : SidResource {
        /**
         * Delete media from your account. Once delete, you will no longer be billed
         * 
         * @param accountSid The account_sid
         * @param messageSid The message_sid
         * @param sid Delete by unique media Sid
         * @return MediaDeleter capable of executing the delete
         */
        public static MediaDeleter delete(String accountSid, String messageSid, String sid) {
            return new MediaDeleter(accountSid, messageSid, sid);
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
        public static MediaFetcher fetch(String accountSid, String messageSid, String sid) {
            return new MediaFetcher(accountSid, messageSid, sid);
        }
    
        /**
         * Retrieve a list of medias belonging to the account used to make the request
         * 
         * @param accountSid The account_sid
         * @param messageSid The message_sid
         * @return MediaReader capable of executing the read
         */
        public static MediaReader read(String accountSid, String messageSid) {
            return new MediaReader(accountSid, messageSid);
        }
    
        /**
         * Converts a JSON string into a Media object
         * 
         * @param json Raw JSON string
         * @return Media object represented by the provided JSON
         */
        public static Media fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Media>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("content_type")]
        private readonly String contentType;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("parent_sid")]
        private readonly String parentSid;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("uri")]
        private readonly String uri;
    
        private Media([JsonProperty("account_sid")]
                      String accountSid, 
                      [JsonProperty("content_type")]
                      String contentType, 
                      [JsonProperty("date_created")]
                      String dateCreated, 
                      [JsonProperty("date_updated")]
                      String dateUpdated, 
                      [JsonProperty("parent_sid")]
                      String parentSid, 
                      [JsonProperty("sid")]
                      String sid, 
                      [JsonProperty("uri")]
                      String uri) {
            this.accountSid = accountSid;
            this.contentType = contentType;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.parentSid = parentSid;
            this.sid = sid;
            this.uri = uri;
        }
    
        /**
         * @return The unique sid that identifies this account
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The default mime-type of the media
         */
        public String GetContentType() {
            return this.contentType;
        }
    
        /**
         * @return The date this resource was created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date this resource was last updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The unique id of the resource that created the media.
         */
        public String GetParentSid() {
            return this.parentSid;
        }
    
        /**
         * @return A string that uniquely identifies this media
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The URI for this resource
         */
        public String GetUri() {
            return this.uri;
        }
    }
}