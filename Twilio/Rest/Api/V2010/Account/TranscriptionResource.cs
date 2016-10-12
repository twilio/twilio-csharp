using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class TranscriptionResource : SidResource {
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
    
        /// <summary>
        /// Fetch and instance of a Transcription
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Fetch by unique transcription Sid </param>
        /// <returns> TranscriptionFetcher capable of executing the fetch </returns> 
        public static TranscriptionFetcher Fetcher(string accountSid, string sid) {
            return new TranscriptionFetcher(accountSid, sid);
        }
    
        /// <summary>
        /// Create a TranscriptionFetcher to execute fetch.
        /// </summary>
        ///
        /// <param name="sid"> Fetch by unique transcription Sid </param>
        /// <returns> TranscriptionFetcher capable of executing the fetch </returns> 
        public static TranscriptionFetcher Fetcher(string sid) {
            return new TranscriptionFetcher(sid);
        }
    
        /// <summary>
        /// Delete a transcription from the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> Delete by unique transcription Sid </param>
        /// <returns> TranscriptionDeleter capable of executing the delete </returns> 
        public static TranscriptionDeleter Deleter(string accountSid, string sid) {
            return new TranscriptionDeleter(accountSid, sid);
        }
    
        /// <summary>
        /// Create a TranscriptionDeleter to execute delete.
        /// </summary>
        ///
        /// <param name="sid"> Delete by unique transcription Sid </param>
        /// <returns> TranscriptionDeleter capable of executing the delete </returns> 
        public static TranscriptionDeleter Deleter(string sid) {
            return new TranscriptionDeleter(sid);
        }
    
        /// <summary>
        /// Retrieve a list of transcriptions belonging to the account used to make the request
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <returns> TranscriptionReader capable of executing the read </returns> 
        public static TranscriptionReader Reader(string accountSid) {
            return new TranscriptionReader(accountSid);
        }
    
        /// <summary>
        /// Create a TranscriptionReader to execute read.
        /// </summary>
        ///
        /// <returns> TranscriptionReader capable of executing the read </returns> 
        public static TranscriptionReader Reader() {
            return new TranscriptionReader();
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
        private readonly TranscriptionResource.Status status;
        [JsonProperty("transcription_text")]
        private readonly string transcriptionText;
        [JsonProperty("type")]
        private readonly string type;
        [JsonProperty("uri")]
        private readonly string uri;
    
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
    
        /// <returns> The unique sid that identifies this account </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The api_version </returns> 
        public string GetApiVersion() {
            return this.apiVersion;
        }
    
        /// <returns> The date this resource was created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date this resource was last updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The duration of the transcribed audio, in seconds. </returns> 
        public string GetDuration() {
            return this.duration;
        }
    
        /// <returns> The charge for this transcription </returns> 
        public decimal? GetPrice() {
            return this.price;
        }
    
        /// <returns> The currency in which Price is measured </returns> 
        public string GetPriceUnit() {
            return this.priceUnit;
        }
    
        /// <returns> The string that uniquely identifies the recording </returns> 
        public string GetRecordingSid() {
            return this.recordingSid;
        }
    
        /// <returns> A string that uniquely identifies this transcription </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The status of the transcription </returns> 
        public TranscriptionResource.Status GetStatus() {
            return this.status;
        }
    
        /// <returns> The text content of the transcription. </returns> 
        public string GetTranscriptionText() {
            return this.transcriptionText;
        }
    
        /// <returns> The type </returns> 
        public string GetTranscriptionType() {
            return this.type;
        }
    
        /// <returns> The URI for this resource </returns> 
        public string GetUri() {
            return this.uri;
        }
    }
}