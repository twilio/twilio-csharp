using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class RecordingResource : Resource 
    {
        public sealed class RecordingSource : IStringEnum 
        {
            public const string Dialverb = "DialVerb";
            public const string Conference = "Conference";
            public const string Outboundapi = "OutboundAPI";
            public const string Trunking = "Trunking";
            public const string Recordverb = "RecordVerb";
        
            private string _value;
            
            public RecordingSource() {}
            
            public RecordingSource(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator RecordingSource(string value)
            {
                return new RecordingSource(value);
            }
            
            public static implicit operator string(RecordingSource value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        public sealed class RecordingStatus : IStringEnum 
        {
            public const string Processing = "processing";
            public const string Completed = "completed";
        
            private string _value;
            
            public RecordingStatus() {}
            
            public RecordingStatus(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator RecordingStatus(string value)
            {
                return new RecordingStatus(value);
            }
            
            public static implicit operator string(RecordingStatus value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        /// <summary>
        /// Fetch an instance of a recording
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique recording Sid </param>
        /// <returns> RecordingFetcher capable of executing the fetch </returns> 
        public static RecordingFetcher Fetcher(string sid)
        {
            return new RecordingFetcher(sid);
        }
    
        /// <summary>
        /// Delete a recording from your account
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique recording Sid </param>
        /// <returns> RecordingDeleter capable of executing the delete </returns> 
        public static RecordingDeleter Deleter(string sid)
        {
            return new RecordingDeleter(sid);
        }
    
        /// <summary>
        /// Retrieve a list of recordings belonging to the account used to make the request
        /// </summary>
        ///
        /// <returns> RecordingReader capable of executing the read </returns> 
        public static RecordingReader Reader()
        {
            return new RecordingReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a RecordingResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> RecordingResource object represented by the provided JSON </returns> 
        public static RecordingResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<RecordingResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; set; }
        [JsonProperty("api_version")]
        public string apiVersion { get; set; }
        [JsonProperty("call_sid")]
        public string callSid { get; set; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; set; }
        [JsonProperty("duration")]
        public string duration { get; set; }
        [JsonProperty("sid")]
        public string sid { get; set; }
        [JsonProperty("price")]
        public string price { get; set; }
        [JsonProperty("price_unit")]
        public string priceUnit { get; set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RecordingResource.RecordingStatus status { get; set; }
        [JsonProperty("channels")]
        public int? channels { get; set; }
        [JsonProperty("source")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RecordingResource.RecordingSource source { get; set; }
        [JsonProperty("uri")]
        public string uri { get; set; }
    
        public RecordingResource()
        {
        
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
                                  RecordingResource.RecordingStatus status, 
                                  [JsonProperty("channels")]
                                  int? channels, 
                                  [JsonProperty("source")]
                                  RecordingResource.RecordingSource source, 
                                  [JsonProperty("uri")]
                                  string uri)
                                  {
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