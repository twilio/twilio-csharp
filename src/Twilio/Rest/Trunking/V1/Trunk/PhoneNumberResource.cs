/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Trunking
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


namespace Twilio.Rest.Trunking.V1.Trunk
{
    public class PhoneNumberResource : Resource
    {
    

    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class AddressRequirementEnum : StringEnum
        {
            private AddressRequirementEnum(string value) : base(value) {}
            public AddressRequirementEnum() {}
            public static implicit operator AddressRequirementEnum(string value)
            {
                return new AddressRequirementEnum(value);
            }
            public static readonly AddressRequirementEnum None = new AddressRequirementEnum("none");
            public static readonly AddressRequirementEnum Any = new AddressRequirementEnum("any");
            public static readonly AddressRequirementEnum Local = new AddressRequirementEnum("local");
            public static readonly AddressRequirementEnum Foreign = new AddressRequirementEnum("foreign");

        }

        
        private static Request BuildCreateRequest(CreatePhoneNumberOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Trunks/{TrunkSid}/PhoneNumbers";

            string PathTrunkSid = options.PathTrunkSid;
            path = path.Replace("{"+"TrunkSid"+"}", PathTrunkSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Trunking,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> create </summary>
        /// <param name="options"> Create PhoneNumber parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PhoneNumber </returns>
        public static PhoneNumberResource Create(CreatePhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="options"> Create PhoneNumber parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PhoneNumber </returns>
        public static async System.Threading.Tasks.Task<PhoneNumberResource> CreateAsync(CreatePhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> create </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk to associate the phone number with. </param>
        /// <param name="phoneNumberSid"> The SID of the [Incoming Phone Number](https://www.twilio.com/docs/phone-numbers/api/incomingphonenumber-resource) that you want to associate with the trunk. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PhoneNumber </returns>
        public static PhoneNumberResource Create(
                                          string pathTrunkSid,
                                          string phoneNumberSid,
                                            ITwilioRestClient client = null)
        {
            var options = new CreatePhoneNumberOptions(pathTrunkSid, phoneNumberSid){  };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk to associate the phone number with. </param>
        /// <param name="phoneNumberSid"> The SID of the [Incoming Phone Number](https://www.twilio.com/docs/phone-numbers/api/incomingphonenumber-resource) that you want to associate with the trunk. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PhoneNumber </returns>
        public static async System.Threading.Tasks.Task<PhoneNumberResource> CreateAsync(
                                                                                  string pathTrunkSid,
                                                                                  string phoneNumberSid,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreatePhoneNumberOptions(pathTrunkSid, phoneNumberSid){  };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> delete </summary>
        /// <param name="options"> Delete PhoneNumber parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PhoneNumber </returns>
        private static Request BuildDeleteRequest(DeletePhoneNumberOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Trunks/{TrunkSid}/PhoneNumbers/{Sid}";

            string PathTrunkSid = options.PathTrunkSid;
            path = path.Replace("{"+"TrunkSid"+"}", PathTrunkSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Trunking,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> delete </summary>
        /// <param name="options"> Delete PhoneNumber parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PhoneNumber </returns>
        public static bool Delete(DeletePhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="options"> Delete PhoneNumber parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PhoneNumber </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeletePhoneNumberOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> delete </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk from which to delete the PhoneNumber resource. </param>
        /// <param name="pathSid"> The unique string that we created to identify the PhoneNumber resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PhoneNumber </returns>
        public static bool Delete(string pathTrunkSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeletePhoneNumberOptions(pathTrunkSid, pathSid)        ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk from which to delete the PhoneNumber resource. </param>
        /// <param name="pathSid"> The unique string that we created to identify the PhoneNumber resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PhoneNumber </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathTrunkSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeletePhoneNumberOptions(pathTrunkSid, pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchPhoneNumberOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Trunks/{TrunkSid}/PhoneNumbers/{Sid}";

            string PathTrunkSid = options.PathTrunkSid;
            path = path.Replace("{"+"TrunkSid"+"}", PathTrunkSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Trunking,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> fetch </summary>
        /// <param name="options"> Fetch PhoneNumber parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PhoneNumber </returns>
        public static PhoneNumberResource Fetch(FetchPhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch PhoneNumber parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PhoneNumber </returns>
        public static async System.Threading.Tasks.Task<PhoneNumberResource> FetchAsync(FetchPhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk from which to fetch the PhoneNumber resource. </param>
        /// <param name="pathSid"> The unique string that we created to identify the PhoneNumber resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PhoneNumber </returns>
        public static PhoneNumberResource Fetch(
                                         string pathTrunkSid, 
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchPhoneNumberOptions(pathTrunkSid, pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk from which to fetch the PhoneNumber resource. </param>
        /// <param name="pathSid"> The unique string that we created to identify the PhoneNumber resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PhoneNumber </returns>
        public static async System.Threading.Tasks.Task<PhoneNumberResource> FetchAsync(string pathTrunkSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchPhoneNumberOptions(pathTrunkSid, pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadPhoneNumberOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Trunks/{TrunkSid}/PhoneNumbers";

            string PathTrunkSid = options.PathTrunkSid;
            path = path.Replace("{"+"TrunkSid"+"}", PathTrunkSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Trunking,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> read </summary>
        /// <param name="options"> Read PhoneNumber parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PhoneNumber </returns>
        public static ResourceSet<PhoneNumberResource> Read(ReadPhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<PhoneNumberResource>.FromJson("phone_numbers", response.Content);
            return new ResourceSet<PhoneNumberResource>(page, options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="options"> Read PhoneNumber parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PhoneNumber </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<PhoneNumberResource>> ReadAsync(ReadPhoneNumberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<PhoneNumberResource>.FromJson("phone_numbers", response.Content);
            return new ResourceSet<PhoneNumberResource>(page, options, client);
        }
        #endif
        /// <summary> read </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk from which to read the PhoneNumber resources. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PhoneNumber </returns>
        public static ResourceSet<PhoneNumberResource> Read(
                                                     string pathTrunkSid,
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadPhoneNumberOptions(pathTrunkSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk from which to read the PhoneNumber resources. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PhoneNumber </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<PhoneNumberResource>> ReadAsync(
                                                                                             string pathTrunkSid,
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadPhoneNumberOptions(pathTrunkSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<PhoneNumberResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<PhoneNumberResource>.FromJson("phone_numbers", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<PhoneNumberResource> NextPage(Page<PhoneNumberResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<PhoneNumberResource>.FromJson("phone_numbers", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<PhoneNumberResource> PreviousPage(Page<PhoneNumberResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<PhoneNumberResource>.FromJson("phone_numbers", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a PhoneNumberResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> PhoneNumberResource object represented by the provided JSON </returns>
        public static PhoneNumberResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<PhoneNumberResource>(json);
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

    
        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the PhoneNumber resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        
        [JsonProperty("address_requirements")]
        public PhoneNumberResource.AddressRequirementEnum AddressRequirements { get; private set; }

        ///<summary> The API version used to start a new TwiML session. </summary> 
        [JsonProperty("api_version")]
        public string ApiVersion { get; private set; }

        ///<summary> Whether the phone number is new to the Twilio platform. Can be: `true` or `false`. </summary> 
        [JsonProperty("beta")]
        public bool? Beta { get; private set; }

        ///<summary> The set of Boolean properties that indicate whether a phone number can receive calls or messages.  Capabilities are  `Voice`, `SMS`, and `MMS` and each capability can be: `true` or `false`. </summary> 
        [JsonProperty("capabilities")]
        public Dictionary<string, string> Capabilities { get; private set; }

        ///<summary> The date and time in GMT when the resource was created specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the resource was last updated specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The string that you assigned to describe the resource. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> The URLs of related resources. </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }

        ///<summary> The phone number in [E.164](https://www.twilio.com/docs/glossary/what-e164) format, which consists of a + followed by the country code and subscriber number. </summary> 
        [JsonProperty("phone_number")]
        [JsonConverter(typeof(PhoneNumberConverter))]
        public Types.PhoneNumber PhoneNumber { get; private set; }

        ///<summary> The unique string that we created to identify the PhoneNumber resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the application that handles SMS messages sent to the phone number. If an `sms_application_sid` is present, we ignore all `sms_*_url` values and use those of the application. </summary> 
        [JsonProperty("sms_application_sid")]
        public string SmsApplicationSid { get; private set; }

        ///<summary> The HTTP method we use to call `sms_fallback_url`. Can be: `GET` or `POST`. </summary> 
        [JsonProperty("sms_fallback_method")]
        public Twilio.Http.HttpMethod SmsFallbackMethod { get; private set; }

        ///<summary> The URL that we call using the `sms_fallback_method` when an error occurs while retrieving or executing the TwiML from `sms_url`. </summary> 
        [JsonProperty("sms_fallback_url")]
        public Uri SmsFallbackUrl { get; private set; }

        ///<summary> The HTTP method we use to call `sms_url`. Can be: `GET` or `POST`. </summary> 
        [JsonProperty("sms_method")]
        public Twilio.Http.HttpMethod SmsMethod { get; private set; }

        ///<summary> The URL we call using the `sms_method` when the phone number receives an incoming SMS message. </summary> 
        [JsonProperty("sms_url")]
        public Uri SmsUrl { get; private set; }

        ///<summary> The URL we call using the `status_callback_method` to send status information to your application. </summary> 
        [JsonProperty("status_callback")]
        public Uri StatusCallback { get; private set; }

        ///<summary> The HTTP method we use to call `status_callback`. Can be: `GET` or `POST`. </summary> 
        [JsonProperty("status_callback_method")]
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; private set; }

        ///<summary> The SID of the Trunk that handles calls to the phone number. If a `trunk_sid` is present, we ignore all of the voice URLs and voice applications and use those set on the Trunk. Setting a `trunk_sid` will automatically delete your `voice_application_sid` and vice versa. </summary> 
        [JsonProperty("trunk_sid")]
        public string TrunkSid { get; private set; }

        ///<summary> The absolute URL of the resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> The SID of the application that handles calls to the phone number. If a `voice_application_sid` is present, we ignore all of the voice URLs and use those set on the application. Setting a `voice_application_sid` will automatically delete your `trunk_sid` and vice versa. </summary> 
        [JsonProperty("voice_application_sid")]
        public string VoiceApplicationSid { get; private set; }

        ///<summary> Whether we look up the caller's caller-ID name from the CNAM database ($0.01 per look up). Can be: `true` or `false`. </summary> 
        [JsonProperty("voice_caller_id_lookup")]
        public bool? VoiceCallerIdLookup { get; private set; }

        ///<summary> The HTTP method that we use to call `voice_fallback_url`. Can be: `GET` or `POST`. </summary> 
        [JsonProperty("voice_fallback_method")]
        public Twilio.Http.HttpMethod VoiceFallbackMethod { get; private set; }

        ///<summary> The URL that we call using the `voice_fallback_method` when an error occurs retrieving or executing the TwiML requested by `url`. </summary> 
        [JsonProperty("voice_fallback_url")]
        public Uri VoiceFallbackUrl { get; private set; }

        ///<summary> The HTTP method we use to call `voice_url`. Can be: `GET` or `POST`. </summary> 
        [JsonProperty("voice_method")]
        public Twilio.Http.HttpMethod VoiceMethod { get; private set; }

        ///<summary> The URL we call using the `voice_method` when the phone number receives a call. The `voice_url` is not be used if a `voice_application_sid` or a `trunk_sid` is set. </summary> 
        [JsonProperty("voice_url")]
        public Uri VoiceUrl { get; private set; }



        private PhoneNumberResource() {

        }
    }
}

