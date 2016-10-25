using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Message {

    public class FeedbackResource : Resource {
        public sealed class Outcome : IStringEnum {
            public const string Confirmed = "confirmed";
            public const string Umconfirmed = "umconfirmed";
        
            private string _value;
            
            public Outcome() { }
            
            public Outcome(string value) {
                _value = value;
            }
            
            public override string ToString() {
                return _value;
            }
            
            public static implicit operator Outcome(string value) {
                return new Outcome(value);
            }
            
            public static implicit operator string(Outcome value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                _value = value;
            }
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="messageSid"> The message_sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="outcome"> The outcome </param>
        /// <returns> FeedbackCreator capable of executing the create </returns> 
        public static FeedbackCreator Creator(string messageSid, string accountSid=null, FeedbackResource.Outcome outcome=null) {
            return new FeedbackCreator(messageSid, accountSid:accountSid, outcome:outcome);
        }
    
        /// <summary>
        /// Converts a JSON string into a FeedbackResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> FeedbackResource object represented by the provided JSON </returns> 
        public static FeedbackResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<FeedbackResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("message_sid")]
        public string messageSid { get; }
        [JsonProperty("outcome")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FeedbackResource.Outcome outcome { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("uri")]
        public string uri { get; }
    
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
    }
}