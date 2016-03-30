using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Creators.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources;

namespace Twilio.Resources.Api.V2010.Account {

    public class ValidationRequestResource : Resource {
        /**
         * create
         * 
         * @param accountSid The account_sid
         * @param phoneNumber The phone_number
         * @return ValidationRequestCreator capable of executing the create
         */
        public static ValidationRequestCreator create(string accountSid, Twilio.Types.PhoneNumber phoneNumber) {
            return new ValidationRequestCreator(accountSid, phoneNumber);
        }
    
        /**
         * Converts a JSON string into a ValidationRequestResource object
         * 
         * @param json Raw JSON string
         * @return ValidationRequestResource object represented by the provided JSON
         */
        public static ValidationRequestResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ValidationRequestResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("phone_number")]
        private readonly Twilio.Types.PhoneNumber phoneNumber;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("validation_code")]
        private readonly int? validationCode;
        [JsonProperty("call_sid")]
        private readonly string callSid;
    
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
    
        /**
         * @return The account_sid
         */
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The phone_number
         */
        public Twilio.Types.PhoneNumber GetPhoneNumber() {
            return this.phoneNumber;
        }
    
        /**
         * @return The friendly_name
         */
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The validation_code
         */
        public int? GetValidationCode() {
            return this.validationCode;
        }
    
        /**
         * @return The call_sid
         */
        public string GetCallSid() {
            return this.callSid;
        }
    }
}