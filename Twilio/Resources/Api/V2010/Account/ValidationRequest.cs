using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources;

namespace Twilio.Resources.Api.V2010.Account {

    public class ValidationRequest : Resource {
        /**
         * create
         * 
         * @param accountSid The account_sid
         * @param phoneNumber The phone_number
         * @return ValidationRequestCreator capable of executing the create
         */
        public static ValidationRequestCreator create(String accountSid, com.twilio.types.PhoneNumber phoneNumber) {
            return new ValidationRequestCreator(accountSid, phoneNumber);
        }
    
        /**
         * Converts a JSON string into a ValidationRequest object
         * 
         * @param json Raw JSON string
         * @return ValidationRequest object represented by the provided JSON
         */
        public static ValidationRequest fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ValidationRequest>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("phone_number")]
        private readonly com.twilio.types.PhoneNumber phoneNumber;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("validation_code")]
        private readonly Integer validationCode;
        [JsonProperty("call_sid")]
        private readonly String callSid;
    
        private ValidationRequest([JsonProperty("account_sid")]
                                  String accountSid, 
                                  [JsonProperty("phone_number")]
                                  com.twilio.types.PhoneNumber phoneNumber, 
                                  [JsonProperty("friendly_name")]
                                  String friendlyName, 
                                  [JsonProperty("validation_code")]
                                  Integer validationCode, 
                                  [JsonProperty("call_sid")]
                                  String callSid) {
            this.accountSid = accountSid;
            this.phoneNumber = phoneNumber;
            this.friendlyName = friendlyName;
            this.validationCode = validationCode;
            this.callSid = callSid;
        }
    
        /**
         * @return The account_sid
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The phone_number
         */
        public com.twilio.types.PhoneNumber GetPhoneNumber() {
            return this.phoneNumber;
        }
    
        /**
         * @return The friendly_name
         */
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The validation_code
         */
        public Integer GetValidationCode() {
            return this.validationCode;
        }
    
        /**
         * @return The call_sid
         */
        public String GetCallSid() {
            return this.callSid;
        }
    }
}