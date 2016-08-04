using Newtonsoft.Json;
using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Api.V2010.Account.Message;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources;

namespace Twilio.Resources.Api.V2010.Account.Message {

    public class FeedbackResource : Resource {
        public sealed class Outcome : IStringEnum {
            public const string CONFIRMED="confirmed";
            public const string UMCONFIRMED="umconfirmed";
        
            private string value;
            
            public Outcome() { }
            
            public Outcome(string value) {
                this.value = value;
            }
            
            public override string ToString() {
                return value;
            }
            
            public static implicit operator Outcome(string value) {
                return new Outcome(value);
            }
            
            public static implicit operator string(Outcome value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                this.value = value;
            }
        }
    
        /**
         * create
         * 
         * @param accountSid The account_sid
         * @param messageSid The message_sid
         * @return FeedbackCreator capable of executing the create
         */
        public static FeedbackCreator Create(string accountSid, string messageSid) {
            return new FeedbackCreator(accountSid, messageSid);
        }
    
        /**
         * Create a FeedbackCreator to execute create.
         * 
         * @param messageSid The message_sid
         * @return FeedbackCreator capable of executing the create
         */
        public static FeedbackCreator Create(string messageSid) {
            return new FeedbackCreator(messageSid);
        }
    
        /**
         * Converts a JSON string into a FeedbackResource object
         * 
         * @param json Raw JSON string
         * @return FeedbackResource object represented by the provided JSON
         */
        public static FeedbackResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<FeedbackResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("message_sid")]
        private readonly string messageSid;
        [JsonProperty("outcome")]
        [JsonConverter(typeof(StringEnumConverter))]
        private readonly FeedbackResource.Outcome outcome;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("uri")]
        private readonly string uri;
    
        public FeedbackResource() {
        
        }
    
        private FeedbackResource([JsonProperty("account_sid")]
                                 string accountSid, 
                                 [JsonProperty("message_sid")]
                                 string messageSid, 
                                 [JsonProperty("outcome")]
                                 FeedbackResource.Outcome outcome, 
                                 [JsonProperty("date_created")]
                                 string dateCreated, 
                                 [JsonProperty("date_updated")]
                                 string dateUpdated, 
                                 [JsonProperty("uri")]
                                 string uri) {
            this.accountSid = accountSid;
            this.messageSid = messageSid;
            this.outcome = outcome;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.uri = uri;
        }
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The message_sid
         */
        public string GetMessageSid() {
            return this.messageSid;
        }
    
        /**
         * @return The outcome
         */
        public FeedbackResource.Outcome GetOutcome() {
            return this.outcome;
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
         * @return The uri
         */
        public string GetUri() {
            return this.uri;
        }
    }
}