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
    
        /// <summary>
        /// Fetch an instance of a recording
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Fetch by unique recording Sid </param>
        /// <returns> RecordingFetcher capable of executing the fetch </returns> 
        public static RecordingFetcher Fetcher(string accountSid, string sid) {
            return new RecordingFetcher(accountSid, sid);
        }
    
        /// <summary>
        /// Create a RecordingFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique recording Sid </param>
        /// <returns> RecordingFetcher capable of executing the fetch </returns> 
        public static RecordingFetcher Fetcher(string sid) {
            return new RecordingFetcher(sid);
        }
    
        /// <summary>
        /// Delete a recording from your account
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Delete by unique recording Sid </param>
        /// <returns> RecordingDeleter capable of executing the delete </returns> 
        public static RecordingDeleter Deleter(string accountSid, string sid) {
            return new RecordingDeleter(accountSid, sid);
        }
    
        /// <summary>
        /// Create a RecordingDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique recording Sid </param>
        /// <returns> RecordingDeleter capable of executing the delete </returns> 
        public static RecordingDeleter Deleter(string sid) {
            return new RecordingDeleter(sid);
        }
    
        /// <summary>
        /// Retrieve a list of recordings belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> RecordingReader capable of executing the read </returns> 
        public static RecordingReader Reader(string accountSid) {
            return new RecordingReader(accountSid);
        }
    
        /// <summary>
        /// Create a RecordingReader to execute read.
        /// </summary>
        ///
        /// <returns> RecordingReader capable of executing the read </returns> 
        public static RecordingReader Reader() {
            return new RecordingReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a RecordingResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> RecordingResource object represented by the provided JSON </returns> 
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
    
        /// <returns> The unique sid that identifies this account </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The version of the API in use during the recording. </returns> 
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /// <returns> The call during which the recording was made. </returns> 
        public string GetCallSid() {
            return this.callSid;
        }
    
        /// <returns> The date this resource was created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date this resource was last updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The length of the recording, in seconds. </returns> 
        public string GetDuration() {
            return this.duration;
        }
    
        /// <returns> A string that uniquely identifies this recording </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The price </returns> 
        public string GetPrice() {
            return this.price;
        }
    
        /// <returns> The price_unit </returns> 
        public string GetPriceUnit() {
            return this.priceUnit;
        }
    
        /// <returns> The status </returns> 
        public RecordingResource.Status GetStatus() {
            return this.status;
        }
    
        /// <returns> The channels </returns> 
        public int? GetChannels() {
            return this.channels;
        }
    
        /// <returns> The source </returns> 
        public RecordingResource.Source GetSource() {
            return this.source;
        }
    
        /// <returns> The URI for this resource </returns> 
        public string GetUri() {
            return this.uri;
        }
    }
}