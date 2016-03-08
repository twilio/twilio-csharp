using Newtonsoft.Json;
using Newtonsoft.Json.JsonDeserialize;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Deleters.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using java.math.BigDecimal;
using java.util.Currency;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account {

    public class Transcription : SidResource {
        public enum Status {
            IN_PROGRESS="in-progress",
            COMPLETED="completed",
            FAILED="failed"
        };
    
        /**
         * Fetch and instance of a Transcription
         * 
         * @param accountSid The account_sid
         * @param sid Fetch by unique transcription Sid
         * @return TranscriptionFetcher capable of executing the fetch
         */
        public static TranscriptionFetcher fetch(String accountSid, String sid) {
            return new TranscriptionFetcher(accountSid, sid);
        }
    
        /**
         * Delete a transcription from the account used to make the request
         * 
         * @param accountSid The account_sid
         * @param sid Delete by unique transcription Sid
         * @return TranscriptionDeleter capable of executing the delete
         */
        public static TranscriptionDeleter delete(String accountSid, String sid) {
            return new TranscriptionDeleter(accountSid, sid);
        }
    
        /**
         * Retrieve a list of transcriptions belonging to the account used to make the
         * request
         * 
         * @param accountSid The account_sid
         * @return TranscriptionReader capable of executing the read
         */
        public static TranscriptionReader read(String accountSid) {
            return new TranscriptionReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a Transcription object
         * 
         * @param json Raw JSON string
         * @return Transcription object represented by the provided JSON
         */
        public static Transcription fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Transcription>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("api_version")]
        private readonly String apiVersion;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("duration")]
        private readonly String duration;
        [JsonProperty("price")]
        private readonly BigDecimal price;
        [JsonProperty("price_unit")]
        private readonly Currency priceUnit;
        [JsonProperty("recording_sid")]
        private readonly String recordingSid;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("status")]
        private readonly Transcription.Status status;
        [JsonProperty("transcription_text")]
        private readonly String transcriptionText;
        [JsonProperty("type")]
        private readonly String type;
        [JsonProperty("uri")]
        private readonly String uri;
    
        private Transcription([JsonProperty("account_sid")]
                              String accountSid, 
                              [JsonProperty("api_version")]
                              String apiVersion, 
                              [JsonProperty("date_created")]
                              String dateCreated, 
                              [JsonProperty("date_updated")]
                              String dateUpdated, 
                              [JsonProperty("duration")]
                              String duration, 
                              [JsonProperty("price")]
                              BigDecimal price, 
                              [JsonProperty("price_unit")]
                              [JsonDeserialize(using = com.twilio.sdk.converters.CurrencyDeserializer.class)]
                              Currency priceUnit, 
                              [JsonProperty("recording_sid")]
                              String recordingSid, 
                              [JsonProperty("sid")]
                              String sid, 
                              [JsonProperty("status")]
                              Transcription.Status status, 
                              [JsonProperty("transcription_text")]
                              String transcriptionText, 
                              [JsonProperty("type")]
                              String type, 
                              [JsonProperty("uri")]
                              String uri) {
            this.accountSid = accountSid;
            this.apiVersion = apiVersion;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
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
         * @return The unique sid that identifies this account
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The api_version
         */
        public String GetApiVersion() {
            return this.apiVersion;
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
         * @return The duration of the transcribed audio, in seconds.
         */
        public String GetDuration() {
            return this.duration;
        }
    
        /**
         * @return The charge for this transcription
         */
        public BigDecimal GetPrice() {
            return this.price;
        }
    
        /**
         * @return The currency in which Price is measured
         */
        public Currency GetPriceUnit() {
            return this.priceUnit;
        }
    
        /**
         * @return The string that uniquely identifies the recording
         */
        public String GetRecordingSid() {
            return this.recordingSid;
        }
    
        /**
         * @return A string that uniquely identifies this transcription
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The status of the transcription
         */
        public Transcription.Status GetStatus() {
            return this.status;
        }
    
        /**
         * @return The text content of the transcription.
         */
        public String GetTranscriptionText() {
            return this.transcriptionText;
        }
    
        /**
         * @return The type
         */
        public String GetType() {
            return this.type;
        }
    
        /**
         * @return The URI for this resource
         */
        public String GetUri() {
            return this.uri;
        }
    }
}