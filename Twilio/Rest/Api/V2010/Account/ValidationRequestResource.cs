using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class ValidationRequestResource : Resource 
    {
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="phoneNumber"> The phone_number </param>
        /// <returns> ValidationRequestCreator capable of executing the create </returns> 
        public static ValidationRequestCreator Creator(Types.PhoneNumber phoneNumber)
        {
            return new ValidationRequestCreator(phoneNumber);
        }
    
        /// <summary>
        /// Converts a JSON string into a ValidationRequestResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ValidationRequestResource object represented by the provided JSON </returns> 
        public static ValidationRequestResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<ValidationRequestResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Types.PhoneNumber PhoneNumber { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("validation_code")]
        public int? ValidationCode { get; set; }
        [JsonProperty("call_sid")]
        public string CallSid { get; set; }
    
        public ValidationRequestResource()
        {
        
        }
    
        private ValidationRequestResource([JsonProperty("account_sid")]
                                          string accountSid, 
                                          [JsonProperty("phone_number")]
                                          Types.PhoneNumber phoneNumber, 
                                          [JsonProperty("friendly_name")]
                                          string friendlyName, 
                                          [JsonProperty("validation_code")]
                                          int? validationCode, 
                                          [JsonProperty("call_sid")]
                                          string callSid)
                                          {
            AccountSid = accountSid;
            PhoneNumber = phoneNumber;
            FriendlyName = friendlyName;
            ValidationCode = validationCode;
            CallSid = callSid;
        }
    }
}