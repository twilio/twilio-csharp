using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Deleters.Api.V2010.Account.Recording;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Recording;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Recording;

namespace Twilio.Rest.Api.V2010.Account.Recording {

    public class Transcription : SidResource {
        public sealed class Status : IStringEnum {
            public const string IN_PROGRESS="in-progress";
            public const string COMPLETED="completed";
            public const string FAILED="failed";
        
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
         * fetch
         * 
         * @param accountSid The account_sid
         * @param recordingSid The recording_sid
         * @param sid The sid
         * @return TranscriptionFetcher capable of executing the fetch
         */
        public static TranscriptionFetcher Fetch(string accountSid, string recordingSid, string sid) {
            return new TranscriptionFetcher(accountSid, recordingSid, sid);
        }
    
        /**
         * Create a TranscriptionFetcher to execute fetch.
         * 
         * @param recordingSid The recording_sid
         * @param sid The sid
         * @return TranscriptionFetcher capable of executing the fetch
         */
        public static TranscriptionFetcher Fetch(string recordingSid, 
                                                 string sid) {
            return new TranscriptionFetcher(recordingSid, sid);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param recordingSid The recording_sid
         * @param sid The sid
         * @return TranscriptionDeleter capable of executing the delete
         */
        public static TranscriptionDeleter Delete(string accountSid, string recordingSid, string sid) {
            return new TranscriptionDeleter(accountSid, recordingSid, sid);
        }
    
        /**
         * Create a TranscriptionDeleter to execute delete.
         * 
         * @param recordingSid The recording_sid
         * @param sid The sid
         * @return TranscriptionDeleter capable of executing the delete
         */
        public static TranscriptionDeleter Delete(string recordingSid, 
                                                  string sid) {
            return new TranscriptionDeleter(recordingSid, sid);
        }
    
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @param recordingSid The recording_sid
         * @return TranscriptionReader capable of executing the read
         */
        public static TranscriptionReader Read(string accountSid, string recordingSid) {
            return new TranscriptionReader(accountSid, recordingSid);
        }
    
        /**
         * Create a TranscriptionReader to execute read.
         * 
         * @param recordingSid The recording_sid
         * @return TranscriptionReader capable of executing the read
         */
        public static TranscriptionReader Read(string recordingSid) {
            return new TranscriptionReader(recordingSid);
        }
    
        /**
         * Converts a JSON string into a Transcription object
         * 
         * @param json Raw JSON string
         * @return Transcription object represented by the provided JSON
         */
        public static Transcription FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Transcription>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("api_version")]
        private readonly string apiVersion;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("duration")]
        private readonly string duration;
        [JsonProperty("price")]
        private readonly decimal? price;
        [JsonProperty("price_unit")]
        private readonly string priceUnit;
        [JsonProperty("recording_sid")]
        private readonly string recordingSid;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly Transcription.Status status;
        [JsonProperty("transcription_text")]
        private readonly string transcriptionText;
        [JsonProperty("type")]
        private readonly string type;
        [JsonProperty("uri")]
        private readonly string uri;
    
        public Transcription() {
        
        }
    
        private Transcription([JsonProperty("account_sid")]
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
                              Transcription.Status status, 
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
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The api_version
         */
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /**
         * @return The date_created
         */
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The duration
         */
        public string GetDuration() {
            return this.duration;
        }
    
        /**
         * @return The price
         */
        public decimal? GetPrice() {
            return this.price;
        }
    
        /**
         * @return The price_unit
         */
        public string GetPriceUnit() {
            return this.priceUnit;
        }
    
        /**
         * @return The recording_sid
         */
        public string GetRecordingSid() {
            return this.recordingSid;
        }
    
        /**
         * @return The sid
         */
        public override string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The status
         */
        public Transcription.Status GetStatus() {
            return this.status;
        }
    
        /**
         * @return The transcription_text
         */
        public string GetTranscriptionText() {
            return this.transcriptionText;
        }
    
        /**
         * @return The type
         */
        public string GetTranscriptionType() {
            return this.type;
        }
    
        /**
         * @return The uri
         */
        public string GetUri() {
            return this.uri;
        }
    }
}