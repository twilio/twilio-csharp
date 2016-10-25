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
        /// <param name="phoneNumber"> The phone_number </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="callDelay"> The call_delay </param>
        /// <param name="extension"> The extension </param>
        /// <param name="statusCallback"> The status_callback </param>
        /// <param name="statusCallbackMethod"> The status_callback_method </param>
        /// <returns> ValidationRequestCreator capable of executing the create </returns> 
        public static ValidationRequestCreator Creator(Twilio.Types.PhoneNumber phoneNumber, string accountSid=null, string friendlyName=null, int? callDelay=null, string extension=null, Uri statusCallback=null, Twilio.Http.HttpMethod statusCallbackMethod=null) {
            return new ValidationRequestCreator(phoneNumber, accountSid:accountSid, friendlyName:friendlyName, callDelay:callDelay, extension:extension, statusCallback:statusCallback, statusCallbackMethod:statusCallbackMethod);
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