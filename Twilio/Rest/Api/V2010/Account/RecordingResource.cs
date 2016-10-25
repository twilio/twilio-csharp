using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class RecordingResource : Resource {
        public sealed class Source : IStringEnum {
            public const string Dialverb = "DialVerb";
            public const string Conference = "Conference";
            public const string Outboundapi = "OutboundAPI";
            public const string Trunking = "Trunking";
            public const string Recordverb = "RecordVerb";
        
            private string _value;
            
            public Source() { }
            
            public Source(string value) {
                _value = value;
            }
            
            public override string ToString() {
                return _value;
            }
            
            public static implicit operator Source(string value) {
                return new Source(value);
            }
            
            public static implicit operator string(Source value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                _value = value;
            }
        }
    
        public sealed class Status : IStringEnum {
            public const string Processing = "processing";
            public const string Completed = "completed";
        
            private string _value;
            
            public Status() { }
            
            public Status(string value) {
                _value = value;
            }
            
            public override string ToString() {
                return _value;
            }
            
            public static implicit operator Status(string value) {
                return new Status(value);
            }
            
            public static implicit operator string(Status value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                _value = value;
            }
        }
    
        /// <summary>
        /// Fetch an instance of a recording
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique recording Sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> RecordingFetcher capable of executing the fetch </returns> 
        public static RecordingFetcher Fetcher(string sid, string accountSid=null) {
            return new RecordingFetcher(sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// Delete a recording from your account
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique recording Sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> RecordingDeleter capable of executing the delete </returns> 
        public static RecordingDeleter Deleter(string sid, string accountSid=null) {
            return new RecordingDeleter(sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// Retrieve a list of recordings belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="dateCreated"> Filter by date created </param>
        /// <returns> RecordingReader capable of executing the read </returns> 
        public static RecordingReader Reader(string accountSid=null, string dateCreated=null) {
            return new RecordingReader(accountSid:accountSid, dateCreated:dateCreated);
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
        public string accountSid { get; }
        [JsonProperty("api_version")]
        public string apiVersion { get; }
        [JsonProperty("call_sid")]
        public string callSid { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("duration")]
        public string duration { get; }
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("price")]
        public string price { get; }
        [JsonProperty("price_unit")]
        public string priceUnit { get; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RecordingResource.Status status { get; }
        [JsonProperty("channels")]
        public int? channels { get; }
        [JsonProperty("source")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RecordingResource.Source source { get; }
        [JsonProperty("uri")]
        public string uri { get; }
    
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
    }
}