using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Recording {

    public class TranscriptionResource : Resource {
        public sealed class Status : IStringEnum {
            public const string InProgress = "in-progress";
            public const string Completed = "completed";
            public const string Failed = "failed";
        
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
        /// fetch
        /// </summary>
        ///
        /// <param name="recordingSid"> The recording_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> TranscriptionFetcher capable of executing the fetch </returns> 
        public static TranscriptionFetcher Fetcher(string recordingSid, string sid, string accountSid=null) {
            return new TranscriptionFetcher(recordingSid, sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="recordingSid"> The recording_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> TranscriptionDeleter capable of executing the delete </returns> 
        public static TranscriptionDeleter Deleter(string recordingSid, string sid, string accountSid=null) {
            return new TranscriptionDeleter(recordingSid, sid, accountSid:accountSid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="recordingSid"> The recording_sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> TranscriptionReader capable of executing the read </returns> 
        public static TranscriptionReader Reader(string recordingSid, string accountSid=null) {
            return new TranscriptionReader(recordingSid, accountSid:accountSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a TranscriptionResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TranscriptionResource object represented by the provided JSON </returns> 
        public static TranscriptionResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<TranscriptionResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("api_version")]
        public string apiVersion { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("duration")]
        public string duration { get; }
        [JsonProperty("price")]
        public decimal? price { get; }
        [JsonProperty("price_unit")]
        public string priceUnit { get; }
        [JsonProperty("recording_sid")]
        public string recordingSid { get; }
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TranscriptionResource.Status status { get; }
        [JsonProperty("transcription_text")]
        public string transcriptionText { get; }
        [JsonProperty("type")]
        public string type { get; }
        [JsonProperty("uri")]
        public string uri { get; }
    
        public TranscriptionResource() {
        
        }
    
        private TranscriptionResource([JsonProperty("account_sid")]
                                      string accountSid, 
                                      [JsonProperty("api_version")]
                                      string apiVersion, 
                                      [JsonProperty("date_created")]
                                      string dateCreated, 
                                      [JsonProperty("date_updated")]
                                      string dateUpdated, 
                                      [JsonProperty("duration")]
                                      string duration, 
                                      [JsonProperty("price")]
                                      decimal? price, 
                                      [JsonProperty("price_unit")]
                                      string priceUnit, 
                                      [JsonProperty("recording_sid")]
                                      string recordingSid, 
                                      [JsonProperty("sid")]
                                      string sid, 
                                      [JsonProperty("status")]
                                      TranscriptionResource.Status status, 
                                      [JsonProperty("transcription_text")]
                                      string transcriptionText, 
                                      [JsonProperty("type")]
                                      string type, 
                                      [JsonProperty("uri")]
                                      string uri) {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.duration = duration;
            this.price = price;
            this.priceUnit = priceUnit;
            this.recordingSid = recordingSid;
            this.sid = sid;
            this.status = status;
            this.transcriptionText = transcriptionText;
            this.type = type;
            this.uri = uri;
        }
    }
}