using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class RecordingResource : SidResource {
        public sealed class Source : IStringEnum {
            public const string DIALVERB="DialVerb";
            public const string CONFERENCE="Conference";
            public const string OUTBOUNDAPI="OutboundAPI";
            public const string TRUNKING="Trunking";
            public const string RECORDVERB="RecordVerb";
        
            private string value;
            
            public Source() { }
            
            public Source(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Source(string value) {
                return new Source(value);
            }
            
            public static implicit operator string(Source value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        public sealed class Status : IStringEnum {
            public const string PROCESSING="processing";
            public const string COMPLETED="completed";
        
            private string value;
            
            public Status() { }
            
            public Status(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Status(string value) {
                return new Status(value);
            }
            
            public static implicit operator string(Status value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        /**
         * Fetch an instance of a recording
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique recording Sid
         * @return RecordingFetcher capable of executing the fetch
         */
        public static RecordingFetcher Fetch(string accountSid, string sid) {
            return new RecordingFetcher(accountSid, sid);
        }
    
        /**
         * Create a RecordingFetcher to execute fetch.
         * 
         * @param sid Fetch by unique recording Sid
         * @return RecordingFetcher capable of executing the fetch
         */
        public static RecordingFetcher Fetch(string sid) {
            return new RecordingFetcher(sid);
        }
    
        /**
         * Delete a recording from your account
         * 
         * @param accountSid The account_sid
         * @param sid Delete by unique recording Sid
         * @return RecordingDeleter capable of executing the delete
         */
        public static RecordingDeleter Delete(string accountSid, string sid) {
            return new RecordingDeleter(accountSid, sid);
        }
    
        /**
         * Create a RecordingDeleter to execute delete.
         * 
         * @param sid Delete by unique recording Sid
         * @return RecordingDeleter capable of executing the delete
         */
        public static RecordingDeleter Delete(string sid) {
            return new RecordingDeleter(sid);
        }
    
        /**
         * Retrieve a list of recordings belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @return RecordingReader capable of executing the read
         */
        public static RecordingReader Read(string accountSid) {
            return new RecordingReader(accountSid);
        }
    
        /**
         * Create a RecordingReader to execute read.
         * 
         * @return RecordingReader capable of executing the read
         */
        public static RecordingReader Read() {
            return new RecordingReader();
        }
    
        /**
         * Converts a JSON string into a RecordingResource object
         * 
         * @param json Raw JSON string
         * @return RecordingResource object represented by the provided JSON
         */
        public static RecordingResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<RecordingResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("call_sid")]
        private readonly string callSid;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("duration")]
        private readonly string duration;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("price")]
        private readonly string price;
        [JsonProperty("price_unit")]
        private readonly string priceUnit;
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly RecordingResource.Status status;
        [JsonProperty("channels")]
        private readonly int? channels;
        [JsonProperty("source")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly RecordingResource.Source source;
        [JsonProperty("uri")]
        private readonly string uri;
    
        public RecordingResource() {
        
        }
    
        private RecordingResource([JsonProperty("account_sid")]
                                  string accountSid, 
                                  [JsonProperty("api_version")]
                                  string apiVersion, 
                                  [JsonProperty("call_sid")]
                                  string callSid, 
                                  [JsonProperty("date_created")]
                                  string dateCreated, 
                                  [JsonProperty("date_updated")]
                                  string dateUpdated, 
                                  [JsonProperty("duration")]
                                  string duration, 
                                  [JsonProperty("sid")]
                                  string sid, 
                                  [JsonProperty("price")]
                                  string price, 
                                  [JsonProperty("price_unit")]
                                  string priceUnit, 
                                  [JsonProperty("status")]
                                  RecordingResource.Status status, 
                                  [JsonProperty("channels")]
                                  int? channels, 
                                  [JsonProperty("source")]
                                  RecordingResource.Source source, 
                                  [JsonProperty("uri")]
                                  string uri) {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.callSid = callSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.duration = duration;
            this.sid = sid;
            this.price = price;
            this.priceUnit = priceUnit;
            this.status = status;
            this.channels = channels;
            this.source = source;
            this.uri = uri;
        }
    
        /**
         * @return The unique sid that identifies this account
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The version of the API in use during the recording.
         */
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The call during which the recording was made.
         */
        public string GetCallSid() {
            return this.callSid;
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
         * @return The length of the recording, in seconds.
         */
        public string GetDuration() {
            return this.duration;
        }
    
        /**
         * @return A string that uniquely identifies this recording
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The price
         */
        public string GetPrice() {
            return this.price;
        }
    
        /**
         * @return The price_unit
         */
        public string GetPriceUnit() {
            return this.priceUnit;
        }
    
        /**
         * @return The status
         */
        public RecordingResource.Status GetStatus() {
            return this.status;
        }
    
        /**
         * @return The channels
         */
        public int? GetChannels() {
            return this.channels;
        }
    
        /**
         * @return The source
         */
        public RecordingResource.Source GetSource() {
            return this.source;
        }
    
        /**
         * @return The URI for this resource
         */
        public string GetUri() {
            return this.uri;
        }
    }
}