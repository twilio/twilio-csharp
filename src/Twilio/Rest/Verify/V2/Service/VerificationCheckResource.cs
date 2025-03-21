/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Verify
 * This is the public Twilio REST API.
 *
 * NOTE: This class is auto generated by OpenAPI Generator.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Constant;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;


namespace Twilio.Rest.Verify.V2.Service
{
    public class VerificationCheckResource : Resource
    {
    

    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class ChannelEnum : StringEnum
        {
            private ChannelEnum(string value) : base(value) {}
            public ChannelEnum() {}
            public static implicit operator ChannelEnum(string value)
            {
                return new ChannelEnum(value);
            }
            public static readonly ChannelEnum Sms = new ChannelEnum("sms");
            public static readonly ChannelEnum Call = new ChannelEnum("call");
            public static readonly ChannelEnum Email = new ChannelEnum("email");
            public static readonly ChannelEnum Whatsapp = new ChannelEnum("whatsapp");
            public static readonly ChannelEnum Sna = new ChannelEnum("sna");

        }

        
        private static Request BuildCreateRequest(CreateVerificationCheckOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/VerificationCheck";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Verify,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> challenge a specific Verification Check. </summary>
        /// <param name="options"> Create VerificationCheck parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of VerificationCheck </returns>
        public static VerificationCheckResource Create(CreateVerificationCheckOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> challenge a specific Verification Check. </summary>
        /// <param name="options"> Create VerificationCheck parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of VerificationCheck </returns>
        public static async System.Threading.Tasks.Task<VerificationCheckResource> CreateAsync(CreateVerificationCheckOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> challenge a specific Verification Check. </summary>
        /// <param name="pathServiceSid"> The SID of the verification [Service](https://www.twilio.com/docs/verify/api/service) to create the resource under. </param>
        /// <param name="code"> The 4-10 character string being verified. </param>
        /// <param name="to"> The phone number or [email](https://www.twilio.com/docs/verify/email) to verify. Either this parameter or the `verification_sid` must be specified. Phone numbers must be in [E.164 format](https://www.twilio.com/docs/glossary/what-e164). </param>
        /// <param name="verificationSid"> A SID that uniquely identifies the Verification Check. Either this parameter or the `to` phone number/[email](https://www.twilio.com/docs/verify/email) must be specified. </param>
        /// <param name="amount"> The amount of the associated PSD2 compliant transaction. Requires the PSD2 Service flag enabled. </param>
        /// <param name="payee"> The payee of the associated PSD2 compliant transaction. Requires the PSD2 Service flag enabled. </param>
        /// <param name="snaClientToken"> A sna client token received in sna url invocation response needs to be passed in Verification Check request and should match to get successful response. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of VerificationCheck </returns>
        public static VerificationCheckResource Create(
                                          string pathServiceSid,
                                          string code = null,
                                          string to = null,
                                          string verificationSid = null,
                                          string amount = null,
                                          string payee = null,
                                          string snaClientToken = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateVerificationCheckOptions(pathServiceSid){  Code = code, To = to, VerificationSid = verificationSid, Amount = amount, Payee = payee, SnaClientToken = snaClientToken };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> challenge a specific Verification Check. </summary>
        /// <param name="pathServiceSid"> The SID of the verification [Service](https://www.twilio.com/docs/verify/api/service) to create the resource under. </param>
        /// <param name="code"> The 4-10 character string being verified. </param>
        /// <param name="to"> The phone number or [email](https://www.twilio.com/docs/verify/email) to verify. Either this parameter or the `verification_sid` must be specified. Phone numbers must be in [E.164 format](https://www.twilio.com/docs/glossary/what-e164). </param>
        /// <param name="verificationSid"> A SID that uniquely identifies the Verification Check. Either this parameter or the `to` phone number/[email](https://www.twilio.com/docs/verify/email) must be specified. </param>
        /// <param name="amount"> The amount of the associated PSD2 compliant transaction. Requires the PSD2 Service flag enabled. </param>
        /// <param name="payee"> The payee of the associated PSD2 compliant transaction. Requires the PSD2 Service flag enabled. </param>
        /// <param name="snaClientToken"> A sna client token received in sna url invocation response needs to be passed in Verification Check request and should match to get successful response. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of VerificationCheck </returns>
        public static async System.Threading.Tasks.Task<VerificationCheckResource> CreateAsync(
                                                                                  string pathServiceSid,
                                                                                  string code = null,
                                                                                  string to = null,
                                                                                  string verificationSid = null,
                                                                                  string amount = null,
                                                                                  string payee = null,
                                                                                  string snaClientToken = null,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateVerificationCheckOptions(pathServiceSid){  Code = code, To = to, VerificationSid = verificationSid, Amount = amount, Payee = payee, SnaClientToken = snaClientToken };
            return await CreateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a VerificationCheckResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> VerificationCheckResource object represented by the provided JSON </returns>
        public static VerificationCheckResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<VerificationCheckResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
        /// <summary>
    /// Converts an object into a json string
    /// </summary>
    /// <param name="model"> C# model </param>
    /// <returns> JSON string </returns>
    public static string ToJson(object model)
    {
        try
        {
            return JsonConvert.SerializeObject(model);
        }
        catch (JsonException e)
        {
            throw new ApiException(e.Message, e);
        }
    }

    
        ///<summary> The unique string that we created to identify the VerificationCheck resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) the resource is associated with. </summary> 
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the VerificationCheck resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The phone number or [email](https://www.twilio.com/docs/verify/email) being verified. Phone numbers must be in [E.164 format](https://www.twilio.com/docs/glossary/what-e164). </summary> 
        [JsonProperty("to")]
        public string To { get; private set; }

        
        [JsonProperty("channel")]
        public VerificationCheckResource.ChannelEnum Channel { get; private set; }

        ///<summary> The status of the verification. Can be: `pending`, `approved`, `canceled`, `max_attempts_reached`, `deleted`, `failed` or `expired`. </summary> 
        [JsonProperty("status")]
        public string Status { get; private set; }

        ///<summary> Use \"status\" instead. Legacy property indicating whether the verification was successful. </summary> 
        [JsonProperty("valid")]
        public bool? Valid { get; private set; }

        ///<summary> The amount of the associated PSD2 compliant transaction. Requires the PSD2 Service flag enabled. </summary> 
        [JsonProperty("amount")]
        public string Amount { get; private set; }

        ///<summary> The payee of the associated PSD2 compliant transaction. Requires the PSD2 Service flag enabled. </summary> 
        [JsonProperty("payee")]
        public string Payee { get; private set; }

        ///<summary> The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time in GMT when the Verification Check resource was created. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time in GMT when the Verification Check resource was last updated. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> List of error codes as a result of attempting a verification using the `sna` channel. The error codes are chronologically ordered, from the first attempt to the latest attempt. This will be an empty list if no errors occured or `null` if the last channel used wasn't `sna`. </summary> 
        [JsonProperty("sna_attempts_error_codes")]
        public List<object> SnaAttemptsErrorCodes { get; private set; }



        private VerificationCheckResource() {

        }
    }
}

