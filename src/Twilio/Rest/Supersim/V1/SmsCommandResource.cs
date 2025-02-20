/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Supersim
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


namespace Twilio.Rest.Supersim.V1
{
    public class SmsCommandResource : Resource
    {
    

    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class StatusEnum : StringEnum
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}
            public static implicit operator StatusEnum(string value)
            {
                return new StatusEnum(value);
            }
            public static readonly StatusEnum Queued = new StatusEnum("queued");
            public static readonly StatusEnum Sent = new StatusEnum("sent");
            public static readonly StatusEnum Delivered = new StatusEnum("delivered");
            public static readonly StatusEnum Received = new StatusEnum("received");
            public static readonly StatusEnum Failed = new StatusEnum("failed");

        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class DirectionEnum : StringEnum
        {
            private DirectionEnum(string value) : base(value) {}
            public DirectionEnum() {}
            public static implicit operator DirectionEnum(string value)
            {
                return new DirectionEnum(value);
            }
            public static readonly DirectionEnum ToSim = new DirectionEnum("to_sim");
            public static readonly DirectionEnum FromSim = new DirectionEnum("from_sim");

        }

        
        private static Request BuildCreateRequest(CreateSmsCommandOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/SmsCommands";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.Supersim,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Send SMS Command to a Sim. </summary>
        /// <param name="options"> Create SmsCommand parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SmsCommand </returns>
        public static SmsCommandResource Create(CreateSmsCommandOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Send SMS Command to a Sim. </summary>
        /// <param name="options"> Create SmsCommand parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SmsCommand </returns>
        public static async System.Threading.Tasks.Task<SmsCommandResource> CreateAsync(CreateSmsCommandOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Send SMS Command to a Sim. </summary>
        /// <param name="sim"> The `sid` or `unique_name` of the [SIM](https://www.twilio.com/docs/iot/supersim/api/sim-resource) to send the SMS Command to. </param>
        /// <param name="payload"> The message body of the SMS Command. </param>
        /// <param name="callbackMethod"> The HTTP method we should use to call `callback_url`. Can be: `GET` or `POST` and the default is POST. </param>
        /// <param name="callbackUrl"> The URL we should call using the `callback_method` after we have sent the command. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SmsCommand </returns>
        public static SmsCommandResource Create(
                                          string sim,
                                          string payload,
                                          Twilio.Http.HttpMethod callbackMethod = null,
                                          Uri callbackUrl = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateSmsCommandOptions(sim, payload){  CallbackMethod = callbackMethod, CallbackUrl = callbackUrl };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Send SMS Command to a Sim. </summary>
        /// <param name="sim"> The `sid` or `unique_name` of the [SIM](https://www.twilio.com/docs/iot/supersim/api/sim-resource) to send the SMS Command to. </param>
        /// <param name="payload"> The message body of the SMS Command. </param>
        /// <param name="callbackMethod"> The HTTP method we should use to call `callback_url`. Can be: `GET` or `POST` and the default is POST. </param>
        /// <param name="callbackUrl"> The URL we should call using the `callback_method` after we have sent the command. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SmsCommand </returns>
        public static async System.Threading.Tasks.Task<SmsCommandResource> CreateAsync(
                                                                                  string sim,
                                                                                  string payload,
                                                                                  Twilio.Http.HttpMethod callbackMethod = null,
                                                                                  Uri callbackUrl = null,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateSmsCommandOptions(sim, payload){  CallbackMethod = callbackMethod, CallbackUrl = callbackUrl };
            return await CreateAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchSmsCommandOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/SmsCommands/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Supersim,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch SMS Command instance from your account. </summary>
        /// <param name="options"> Fetch SmsCommand parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SmsCommand </returns>
        public static SmsCommandResource Fetch(FetchSmsCommandOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch SMS Command instance from your account. </summary>
        /// <param name="options"> Fetch SmsCommand parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SmsCommand </returns>
        public static async System.Threading.Tasks.Task<SmsCommandResource> FetchAsync(FetchSmsCommandOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch SMS Command instance from your account. </summary>
        /// <param name="pathSid"> The SID of the SMS Command resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SmsCommand </returns>
        public static SmsCommandResource Fetch(
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchSmsCommandOptions(pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch SMS Command instance from your account. </summary>
        /// <param name="pathSid"> The SID of the SMS Command resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SmsCommand </returns>
        public static async System.Threading.Tasks.Task<SmsCommandResource> FetchAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchSmsCommandOptions(pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadSmsCommandOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/SmsCommands";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Supersim,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of SMS Commands from your account. </summary>
        /// <param name="options"> Read SmsCommand parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SmsCommand </returns>
        public static ResourceSet<SmsCommandResource> Read(ReadSmsCommandOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<SmsCommandResource>.FromJson("sms_commands", response.Content);
            return new ResourceSet<SmsCommandResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of SMS Commands from your account. </summary>
        /// <param name="options"> Read SmsCommand parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SmsCommand </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<SmsCommandResource>> ReadAsync(ReadSmsCommandOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<SmsCommandResource>.FromJson("sms_commands", response.Content);
            return new ResourceSet<SmsCommandResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of SMS Commands from your account. </summary>
        /// <param name="sim"> The SID or unique name of the Sim resource that SMS Command was sent to or from. </param>
        /// <param name="status"> The status of the SMS Command. Can be: `queued`, `sent`, `delivered`, `received` or `failed`. See the [SMS Command Status Values](https://www.twilio.com/docs/iot/supersim/api/smscommand-resource#status-values) for a description of each. </param>
        /// <param name="direction"> The direction of the SMS Command. Can be `to_sim` or `from_sim`. The value of `to_sim` is synonymous with the term `mobile terminated`, and `from_sim` is synonymous with the term `mobile originated`. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SmsCommand </returns>
        public static ResourceSet<SmsCommandResource> Read(
                                                     string sim = null,
                                                     SmsCommandResource.StatusEnum status = null,
                                                     SmsCommandResource.DirectionEnum direction = null,
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadSmsCommandOptions(){ Sim = sim, Status = status, Direction = direction, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of SMS Commands from your account. </summary>
        /// <param name="sim"> The SID or unique name of the Sim resource that SMS Command was sent to or from. </param>
        /// <param name="status"> The status of the SMS Command. Can be: `queued`, `sent`, `delivered`, `received` or `failed`. See the [SMS Command Status Values](https://www.twilio.com/docs/iot/supersim/api/smscommand-resource#status-values) for a description of each. </param>
        /// <param name="direction"> The direction of the SMS Command. Can be `to_sim` or `from_sim`. The value of `to_sim` is synonymous with the term `mobile terminated`, and `from_sim` is synonymous with the term `mobile originated`. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SmsCommand </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<SmsCommandResource>> ReadAsync(
                                                                                             string sim = null,
                                                                                             SmsCommandResource.StatusEnum status = null,
                                                                                             SmsCommandResource.DirectionEnum direction = null,
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadSmsCommandOptions(){ Sim = sim, Status = status, Direction = direction, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<SmsCommandResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<SmsCommandResource>.FromJson("sms_commands", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<SmsCommandResource> NextPage(Page<SmsCommandResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<SmsCommandResource>.FromJson("sms_commands", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<SmsCommandResource> PreviousPage(Page<SmsCommandResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<SmsCommandResource>.FromJson("sms_commands", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a SmsCommandResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SmsCommandResource object represented by the provided JSON </returns>
        public static SmsCommandResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<SmsCommandResource>(json);
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

    
        ///<summary> The unique string that we created to identify the SMS Command resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the SMS Command resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The SID of the [SIM](https://www.twilio.com/docs/iot/supersim/api/sim-resource) that this SMS Command was sent to or from. </summary> 
        [JsonProperty("sim_sid")]
        public string SimSid { get; private set; }

        ///<summary> The message body of the SMS Command sent to or from the SIM. For text mode messages, this can be up to 160 characters. </summary> 
        [JsonProperty("payload")]
        public string Payload { get; private set; }

        
        [JsonProperty("status")]
        public SmsCommandResource.StatusEnum Status { get; private set; }

        
        [JsonProperty("direction")]
        public SmsCommandResource.DirectionEnum Direction { get; private set; }

        ///<summary> The date and time in GMT when the resource was created specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the resource was last updated specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The absolute URL of the SMS Command resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private SmsCommandResource() {

        }
    }
}

