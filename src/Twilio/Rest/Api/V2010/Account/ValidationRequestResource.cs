/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// ValidationRequestResource
/// </summary>

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
                "/2010-04-01/Accounts/" + (options.PathAccountSid ?? client.AccountSid) + "/OutgoingCallerIds.json",
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// create
        /// </summary>
        /// <param name="options"> Create ValidationRequest parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ValidationRequest </returns>
        public static ValidationRequestResource Create(CreateValidationRequestOptions options,
                                                       ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        /// <param name="options"> Create ValidationRequest parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ValidationRequest </returns>
        public static async System.Threading.Tasks.Task<ValidationRequestResource> CreateAsync(CreateValidationRequestOptions options,
                                                                                               ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// create
        /// </summary>
        /// <param name="phoneNumber"> The phone number to verify in E.164 format </param>
        /// <param name="pathAccountSid"> The SID of the Account responsible for the new Caller ID </param>
        /// <param name="friendlyName"> A string to describe the resource </param>
        /// <param name="callDelay"> The number of seconds to delay before initiating the verification call </param>
        /// <param name="extension"> The digits to dial after connecting the verification call </param>
        /// <param name="statusCallback"> The URL we should call to send status information to your application </param>
        /// <param name="statusCallbackMethod"> The HTTP method we should use to call status_callback </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ValidationRequest </returns>
        public static ValidationRequestResource Create(Types.PhoneNumber phoneNumber,
                                                       string pathAccountSid = null,
                                                       string friendlyName = null,
                                                       int? callDelay = null,
                                                       string extension = null,
                                                       Uri statusCallback = null,
                                                       Twilio.Http.HttpMethod statusCallbackMethod = null,
                                                       ITwilioRestClient client = null)
        {
            var options = new CreateValidationRequestOptions(phoneNumber){PathAccountSid = pathAccountSid, FriendlyName = friendlyName, CallDelay = callDelay, Extension = extension, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod};
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        /// <param name="phoneNumber"> The phone number to verify in E.164 format </param>
        /// <param name="pathAccountSid"> The SID of the Account responsible for the new Caller ID </param>
        /// <param name="friendlyName"> A string to describe the resource </param>
        /// <param name="callDelay"> The number of seconds to delay before initiating the verification call </param>
        /// <param name="extension"> The digits to dial after connecting the verification call </param>
        /// <param name="statusCallback"> The URL we should call to send status information to your application </param>
        /// <param name="statusCallbackMethod"> The HTTP method we should use to call status_callback </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ValidationRequest </returns>
        public static async System.Threading.Tasks.Task<ValidationRequestResource> CreateAsync(Types.PhoneNumber phoneNumber,
                                                                                               string pathAccountSid = null,
                                                                                               string friendlyName = null,
                                                                                               int? callDelay = null,
                                                                                               string extension = null,
                                                                                               Uri statusCallback = null,
                                                                                               Twilio.Http.HttpMethod statusCallbackMethod = null,
                                                                                               ITwilioRestClient client = null)
        {
            var options = new CreateValidationRequestOptions(phoneNumber){PathAccountSid = pathAccountSid, FriendlyName = friendlyName, CallDelay = callDelay, Extension = extension, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod};
            return await CreateAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a ValidationRequestResource object
        /// </summary>
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

        /// <summary>
        /// The SID of the Account that created the resource
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The SID of the Call the resource is associated with
        /// </summary>
        [JsonProperty("call_sid")]
        public string CallSid { get; private set; }
        /// <summary>
        /// The string that you assigned to describe the resource
        /// </summary>
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        /// <summary>
        /// The phone number to verify in E.164 format
        /// </summary>
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Types.PhoneNumber PhoneNumber { get; private set; }
        /// <summary>
        /// The 6 digit validation code that someone must enter to validate the Caller ID  when `phone_number` is called
        /// </summary>
        [JsonProperty("validation_code")]
        public string ValidationCode { get; private set; }

        private ValidationRequestResource()
        {

        }
    }

}