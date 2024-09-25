/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Intelligence
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




namespace Twilio.Rest.Intelligence.V2
{
    public class ServiceResource : Resource
    {
    

    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class HttpMethodEnum : StringEnum
        {
            private HttpMethodEnum(string value) : base(value) {}
            public HttpMethodEnum() {}
            public static implicit operator HttpMethodEnum(string value)
            {
                return new HttpMethodEnum(value);
            }
            public static readonly HttpMethodEnum Get = new HttpMethodEnum("GET");
            public static readonly HttpMethodEnum Post = new HttpMethodEnum("POST");
            public static readonly HttpMethodEnum Null = new HttpMethodEnum("NULL");

        }

        
        private static Request BuildCreateRequest(CreateServiceOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.Intelligence,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create a new Service for the given Account </summary>
        /// <param name="options"> Create Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        public static ServiceResource Create(CreateServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a new Service for the given Account </summary>
        /// <param name="options"> Create Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns>
        public static async System.Threading.Tasks.Task<ServiceResource> CreateAsync(CreateServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a new Service for the given Account </summary>
        /// <param name="uniqueName"> Provides a unique and addressable name to be assigned to this Service, assigned by the developer, to be optionally used in addition to SID. </param>
        /// <param name="autoTranscribe"> Instructs the Speech Recognition service to automatically transcribe all recordings made on the account. </param>
        /// <param name="dataLogging"> Data logging allows Twilio to improve the quality of the speech recognition & language understanding services through using customer data to refine, fine tune and evaluate machine learning models. Note: Data logging cannot be activated via API, only via www.twilio.com, as it requires additional consent. </param>
        /// <param name="friendlyName"> A human readable description of this resource, up to 64 characters. </param>
        /// <param name="languageCode"> The language code set during Service creation determines the Transcription language for all call recordings processed by that Service. The default is en-US if no language code is set. A Service can only support one language code, and it cannot be updated once it's set. </param>
        /// <param name="autoRedaction"> Instructs the Speech Recognition service to automatically redact PII from all transcripts made on this service. </param>
        /// <param name="mediaRedaction"> Instructs the Speech Recognition service to automatically redact PII from all transcripts media made on this service. The auto_redaction flag must be enabled, results in error otherwise. </param>
        /// <param name="webhookUrl"> The URL Twilio will request when executing the Webhook. </param>
        /// <param name="webhookHttpMethod">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        public static ServiceResource Create(
                                          string uniqueName,
                                          bool? autoTranscribe = null,
                                          bool? dataLogging = null,
                                          string friendlyName = null,
                                          string languageCode = null,
                                          bool? autoRedaction = null,
                                          bool? mediaRedaction = null,
                                          string webhookUrl = null,
                                          ServiceResource.HttpMethodEnum webhookHttpMethod = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateServiceOptions(uniqueName){  AutoTranscribe = autoTranscribe, DataLogging = dataLogging, FriendlyName = friendlyName, LanguageCode = languageCode, AutoRedaction = autoRedaction, MediaRedaction = mediaRedaction, WebhookUrl = webhookUrl, WebhookHttpMethod = webhookHttpMethod };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a new Service for the given Account </summary>
        /// <param name="uniqueName"> Provides a unique and addressable name to be assigned to this Service, assigned by the developer, to be optionally used in addition to SID. </param>
        /// <param name="autoTranscribe"> Instructs the Speech Recognition service to automatically transcribe all recordings made on the account. </param>
        /// <param name="dataLogging"> Data logging allows Twilio to improve the quality of the speech recognition & language understanding services through using customer data to refine, fine tune and evaluate machine learning models. Note: Data logging cannot be activated via API, only via www.twilio.com, as it requires additional consent. </param>
        /// <param name="friendlyName"> A human readable description of this resource, up to 64 characters. </param>
        /// <param name="languageCode"> The language code set during Service creation determines the Transcription language for all call recordings processed by that Service. The default is en-US if no language code is set. A Service can only support one language code, and it cannot be updated once it's set. </param>
        /// <param name="autoRedaction"> Instructs the Speech Recognition service to automatically redact PII from all transcripts made on this service. </param>
        /// <param name="mediaRedaction"> Instructs the Speech Recognition service to automatically redact PII from all transcripts media made on this service. The auto_redaction flag must be enabled, results in error otherwise. </param>
        /// <param name="webhookUrl"> The URL Twilio will request when executing the Webhook. </param>
        /// <param name="webhookHttpMethod">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns>
        public static async System.Threading.Tasks.Task<ServiceResource> CreateAsync(
                                                                                  string uniqueName,
                                                                                  bool? autoTranscribe = null,
                                                                                  bool? dataLogging = null,
                                                                                  string friendlyName = null,
                                                                                  string languageCode = null,
                                                                                  bool? autoRedaction = null,
                                                                                  bool? mediaRedaction = null,
                                                                                  string webhookUrl = null,
                                                                                  ServiceResource.HttpMethodEnum webhookHttpMethod = null,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateServiceOptions(uniqueName){  AutoTranscribe = autoTranscribe, DataLogging = dataLogging, FriendlyName = friendlyName, LanguageCode = languageCode, AutoRedaction = autoRedaction, MediaRedaction = mediaRedaction, WebhookUrl = webhookUrl, WebhookHttpMethod = webhookHttpMethod };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> Delete a specific Service. </summary>
        /// <param name="options"> Delete Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        private static Request BuildDeleteRequest(DeleteServiceOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Intelligence,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Delete a specific Service. </summary>
        /// <param name="options"> Delete Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        public static bool Delete(DeleteServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Delete a specific Service. </summary>
        /// <param name="options"> Delete Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteServiceOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Delete a specific Service. </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Service. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        public static bool Delete(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteServiceOptions(pathSid)     ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Delete a specific Service. </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Service. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteServiceOptions(pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchServiceOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Intelligence,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a specific Service. </summary>
        /// <param name="options"> Fetch Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        public static ServiceResource Fetch(FetchServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a specific Service. </summary>
        /// <param name="options"> Fetch Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns>
        public static async System.Threading.Tasks.Task<ServiceResource> FetchAsync(FetchServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a specific Service. </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Service. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        public static ServiceResource Fetch(
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchServiceOptions(pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a specific Service. </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Service. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns>
        public static async System.Threading.Tasks.Task<ServiceResource> FetchAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchServiceOptions(pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadServiceOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Intelligence,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieves a list of all Services for an account. </summary>
        /// <param name="options"> Read Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        public static ResourceSet<ServiceResource> Read(ReadServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<ServiceResource>.FromJson("services", response.Content);
            return new ResourceSet<ServiceResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieves a list of all Services for an account. </summary>
        /// <param name="options"> Read Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ServiceResource>> ReadAsync(ReadServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<ServiceResource>.FromJson("services", response.Content);
            return new ResourceSet<ServiceResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieves a list of all Services for an account. </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        public static ResourceSet<ServiceResource> Read(
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadServiceOptions(){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieves a list of all Services for an account. </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ServiceResource>> ReadAsync(
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadServiceOptions(){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<ServiceResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<ServiceResource>.FromJson("services", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<ServiceResource> NextPage(Page<ServiceResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ServiceResource>.FromJson("services", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<ServiceResource> PreviousPage(Page<ServiceResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ServiceResource>.FromJson("services", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateServiceOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Intelligence,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: options.GetHeaderParams()
            );
        }

        /// <summary> Update a specific Service. </summary>
        /// <param name="options"> Update Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        public static ServiceResource Update(UpdateServiceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Update a specific Service. </summary>
        /// <param name="options"> Update Service parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<ServiceResource> UpdateAsync(UpdateServiceOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Update a specific Service. </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Service. </param>
        /// <param name="autoTranscribe"> Instructs the Speech Recognition service to automatically transcribe all recordings made on the account. </param>
        /// <param name="dataLogging"> Data logging allows Twilio to improve the quality of the speech recognition & language understanding services through using customer data to refine, fine tune and evaluate machine learning models. Note: Data logging cannot be activated via API, only via www.twilio.com, as it requires additional consent. </param>
        /// <param name="friendlyName"> A human readable description of this resource, up to 64 characters. </param>
        /// <param name="uniqueName"> Provides a unique and addressable name to be assigned to this Service, assigned by the developer, to be optionally used in addition to SID. </param>
        /// <param name="autoRedaction"> Instructs the Speech Recognition service to automatically redact PII from all transcripts made on this service. </param>
        /// <param name="mediaRedaction"> Instructs the Speech Recognition service to automatically redact PII from all transcripts media made on this service. The auto_redaction flag must be enabled, results in error otherwise. </param>
        /// <param name="webhookUrl"> The URL Twilio will request when executing the Webhook. </param>
        /// <param name="webhookHttpMethod">  </param>
        /// <param name="ifMatch"> The If-Match HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Service </returns>
        public static ServiceResource Update(
                                          string pathSid,
                                          bool? autoTranscribe = null,
                                          bool? dataLogging = null,
                                          string friendlyName = null,
                                          string uniqueName = null,
                                          bool? autoRedaction = null,
                                          bool? mediaRedaction = null,
                                          string webhookUrl = null,
                                          ServiceResource.HttpMethodEnum webhookHttpMethod = null,
                                          string ifMatch = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateServiceOptions(pathSid){ AutoTranscribe = autoTranscribe, DataLogging = dataLogging, FriendlyName = friendlyName, UniqueName = uniqueName, AutoRedaction = autoRedaction, MediaRedaction = mediaRedaction, WebhookUrl = webhookUrl, WebhookHttpMethod = webhookHttpMethod, IfMatch = ifMatch };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Update a specific Service. </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Service. </param>
        /// <param name="autoTranscribe"> Instructs the Speech Recognition service to automatically transcribe all recordings made on the account. </param>
        /// <param name="dataLogging"> Data logging allows Twilio to improve the quality of the speech recognition & language understanding services through using customer data to refine, fine tune and evaluate machine learning models. Note: Data logging cannot be activated via API, only via www.twilio.com, as it requires additional consent. </param>
        /// <param name="friendlyName"> A human readable description of this resource, up to 64 characters. </param>
        /// <param name="uniqueName"> Provides a unique and addressable name to be assigned to this Service, assigned by the developer, to be optionally used in addition to SID. </param>
        /// <param name="autoRedaction"> Instructs the Speech Recognition service to automatically redact PII from all transcripts made on this service. </param>
        /// <param name="mediaRedaction"> Instructs the Speech Recognition service to automatically redact PII from all transcripts media made on this service. The auto_redaction flag must be enabled, results in error otherwise. </param>
        /// <param name="webhookUrl"> The URL Twilio will request when executing the Webhook. </param>
        /// <param name="webhookHttpMethod">  </param>
        /// <param name="ifMatch"> The If-Match HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Service </returns>
        public static async System.Threading.Tasks.Task<ServiceResource> UpdateAsync(
                                                                              string pathSid,
                                                                              bool? autoTranscribe = null,
                                                                              bool? dataLogging = null,
                                                                              string friendlyName = null,
                                                                              string uniqueName = null,
                                                                              bool? autoRedaction = null,
                                                                              bool? mediaRedaction = null,
                                                                              string webhookUrl = null,
                                                                              ServiceResource.HttpMethodEnum webhookHttpMethod = null,
                                                                              string ifMatch = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateServiceOptions(pathSid){ AutoTranscribe = autoTranscribe, DataLogging = dataLogging, FriendlyName = friendlyName, UniqueName = uniqueName, AutoRedaction = autoRedaction, MediaRedaction = mediaRedaction, WebhookUrl = webhookUrl, WebhookHttpMethod = webhookHttpMethod, IfMatch = ifMatch };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a ServiceResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ServiceResource object represented by the provided JSON </returns>
        public static ServiceResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<ServiceResource>(json);
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

    
        ///<summary> The unique SID identifier of the Account the Service belongs to. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> Instructs the Speech Recognition service to automatically redact PII from all transcripts made on this service. </summary> 
        [JsonProperty("auto_redaction")]
        public bool? AutoRedaction { get; private set; }

        ///<summary> Instructs the Speech Recognition service to automatically redact PII from all transcripts media made on this service. The auto_redaction flag must be enabled, results in error otherwise. </summary> 
        [JsonProperty("media_redaction")]
        public bool? MediaRedaction { get; private set; }

        ///<summary> Instructs the Speech Recognition service to automatically transcribe all recordings made on the account. </summary> 
        [JsonProperty("auto_transcribe")]
        public bool? AutoTranscribe { get; private set; }

        ///<summary> Data logging allows Twilio to improve the quality of the speech recognition & language understanding services through using customer data to refine, fine tune and evaluate machine learning models. Note: Data logging cannot be activated via API, only via www.twilio.com, as it requires additional consent. </summary> 
        [JsonProperty("data_logging")]
        public bool? DataLogging { get; private set; }

        ///<summary> The date that this Service was created, given in ISO 8601 format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date that this Service was updated, given in ISO 8601 format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> A human readable description of this resource, up to 64 characters. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> The language code set during Service creation determines the Transcription language for all call recordings processed by that Service. The default is en-US if no language code is set. A Service can only support one language code, and it cannot be updated once it's set. </summary> 
        [JsonProperty("language_code")]
        public string LanguageCode { get; private set; }

        ///<summary> A 34 character string that uniquely identifies this Service. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> Provides a unique and addressable name to be assigned to this Service, assigned by the developer, to be optionally used in addition to SID. </summary> 
        [JsonProperty("unique_name")]
        public string UniqueName { get; private set; }

        ///<summary> The URL of this resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> The URL Twilio will request when executing the Webhook. </summary> 
        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; private set; }

        
        [JsonProperty("webhook_http_method")]
        public ServiceResource.HttpMethodEnum WebhookHttpMethod { get; private set; }

        ///<summary> Operator sids attached to this service, read only </summary> 
        [JsonProperty("read_only_attached_operator_sids")]
        public List<string> ReadOnlyAttachedOperatorSids { get; private set; }

        ///<summary> The version number of this Service. </summary> 
        [JsonProperty("version")]
        public int? Version { get; private set; }



        private ServiceResource() {

        }
    }
}

