using Newtonsoft.Json;
using Newtonsoft.Json.JsonDeserialize;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Deleters.Api.V2010.Account.Recording;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account.Recording;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account.Recording;
using Twilio.Resources;
using com.twilio.sdk.converters.MarshalConverter;
using java.math.BigDecimal;
using java.util.Currency;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account.Recording {

    public class Transcription : SidResource {
        public enum Status {
            IN_PROGRESS="in-progress",
            COMPLETED="completed",
            FAILED="failed"
        };
    
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param recordingSid The recording_sid
         * @param sid The sid
         * @return TranscriptionFetcher capable of executing the fetch
         */
        public static TranscriptionFetcher fetch(String accountSid, String recordingSid, String sid) {
            return new TranscriptionFetcher(accountSid, recordingSid, sid);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param recordingSid The recording_sid
         * @param sid The sid
         * @return TranscriptionDeleter capable of executing the delete
         */
        public static TranscriptionDeleter delete(String accountSid, String recordingSid, String sid) {
            return new TranscriptionDeleter(accountSid, recordingSid, sid);
        }
    
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @param recordingSid The recording_sid
         * @return TranscriptionReader capable of executing the read
         */
        public static TranscriptionReader read(String accountSid, String recordingSid) {
            return new TranscriptionReader(accountSid, recordingSid);
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
         * @return The account_sid
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
         * @return The date_created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The duration
         */
        public String GetDuration() {
            return this.duration;
        }
    
        /**
         * @return The price
         */
        public BigDecimal GetPrice() {
            return this.price;
        }
    
        /**
         * @return The price_unit
         */
        public Currency GetPriceUnit() {
            return this.priceUnit;
        }
    
        /**
         * @return The recording_sid
         */
        public String GetRecordingSid() {
            return this.recordingSid;
        }
    
        /**
         * @return The sid
         */
        public String GetSid() {
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
         * @return The uri
         */
        public String GetUri() {
            return this.uri;
        }
    }
}