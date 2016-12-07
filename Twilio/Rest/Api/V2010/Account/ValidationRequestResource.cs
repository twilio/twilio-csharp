using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class ValidationRequestResource : Resource 
    {
        private static Request BuildCreateRequest(CreateValidationRequestOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/OutgoingCallerIds.json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static ValidationRequestResource Create(CreateValidationRequestOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ValidationRequestResource> CreateAsync(CreateValidationRequestOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static ValidationRequestResource Create(Types.PhoneNumber phoneNumber, string accountSid = null, string friendlyName = null, int? callDelay = null, string extension = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, ITwilioRestClient client = null)
        {
            var options = new CreateValidationRequestOptions(phoneNumber){AccountSid = accountSid, FriendlyName = friendlyName, CallDelay = callDelay, Extension = extension, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ValidationRequestResource> CreateAsync(Types.PhoneNumber phoneNumber, string accountSid = null, string friendlyName = null, int? callDelay = null, string extension = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, ITwilioRestClient client = null)
        {
            var options = new CreateValidationRequestOptions(phoneNumber){AccountSid = accountSid, FriendlyName = friendlyName, CallDelay = callDelay, Extension = extension, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod};
            return await CreateAsync(options, client);
        }
        #endif
    
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
        public string AccountSid { get; private set; }
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Types.PhoneNumber PhoneNumber { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("validation_code")]
        public int? ValidationCode { get; private set; }
        [JsonProperty("call_sid")]
        public string CallSid { get; private set; }
    
        private ValidationRequestResource()
        {
        
        }
    }

}