using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account {

    public class ValidationRequestResource : Resource {
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="phoneNumber"> The phone_number </param>
        /// <returns> ValidationRequestCreator capable of executing the create </returns> 
        public static ValidationRequestCreator Creator(string accountSid, Twilio.Types.PhoneNumber phoneNumber) {
            return new ValidationRequestCreator(accountSid, phoneNumber);
        }
    
        /// <summary>
        /// Create a ValidationRequestCreator to execute create.
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone_number </param>
        /// <returns> ValidationRequestCreator capable of executing the create </returns> 
        public static ValidationRequestCreator Creator(Twilio.Types.PhoneNumber phoneNumber) {
            return new ValidationRequestCreator(phoneNumber);
        }
    
        /// <summary>
        /// Converts a JSON string into a ValidationRequestResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ValidationRequestResource object represented by the provided JSON </returns> 
        public static ValidationRequestResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ValidationRequestResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Twilio.Types.PhoneNumber phoneNumber { get; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; }
        [JsonProperty("validation_code")]
        public int? validationCode { get; }
        [JsonProperty("call_sid")]
        public string callSid { get; }
    
        public ValidationRequestResource() {
        
        }
    
        private ValidationRequestResource([JsonProperty("account_sid")]
                                          string accountSid, 
                                          [JsonProperty("phone_number")]
                                          Twilio.Types.PhoneNumber phoneNumber, 
                                          [JsonProperty("friendly_name")]
                                          string friendlyName, 
                                          [JsonProperty("validation_code")]
                                          int? validationCode, 
                                          [JsonProperty("call_sid")]
                                          string callSid) {
            this.accountSid = accountSid;
            this.phoneNumber = phoneNumber;
            this.friendlyName = friendlyName;
            this.validationCode = validationCode;
            this.callSid = callSid;
        }
    }
}