using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.Api.V2010.Account.Message 
{

    public class FeedbackResource : Resource 
    {
        public sealed class OutcomeEnum : IStringEnum 
        {
            public const string Confirmed = "confirmed";
            public const string Umconfirmed = "umconfirmed";
        
            private string _value;
            
            public OutcomeEnum() {}
            
            public OutcomeEnum(string value)
            {
                _value = value;
            }
            
            public override string ToString()
            {
                return _value;
            }
            
            public static implicit operator OutcomeEnum(string value)
            {
                return new OutcomeEnum(value);
            }
            
            public static implicit operator string(OutcomeEnum value)
            {
                return value.ToString();
            }
            
            public void FromString(string value)
            {
                _value = value;
            }
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="messageSid"> The message_sid </param>
        /// <returns> FeedbackCreator capable of executing the create </returns> 
        public static FeedbackCreator Creator(string messageSid)
        {
            return new FeedbackCreator(messageSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a FeedbackResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> FeedbackResource object represented by the provided JSON </returns> 
        public static FeedbackResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<FeedbackResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("message_sid")]
        public string MessageSid { get; set; }
        [JsonProperty("outcome")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FeedbackResource.OutcomeEnum Outcome { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
    
        public FeedbackResource()
        {
        
        }
    
        private FeedbackResource([JsonProperty("account_sid")]
                                 string accountSid, 
                                 [JsonProperty("message_sid")]
                                 string messageSid, 
                                 [JsonProperty("outcome")]
                                 FeedbackResource.OutcomeEnum outcome, 
                                 [JsonProperty("date_created")]
                                 string dateCreated, 
                                 [JsonProperty("date_updated")]
                                 string dateUpdated, 
                                 [JsonProperty("uri")]
                                 string uri)
                                 {
            AccountSid = accountSid;
            MessageSid = messageSid;
            Outcome = outcome;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            Uri = uri;
        }
    }
}