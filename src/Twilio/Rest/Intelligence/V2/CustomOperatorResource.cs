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
    public class CustomOperatorResource : Resource
    {
    

    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class AvailabilityEnum : StringEnum
        {
            private AvailabilityEnum(string value) : base(value) {}
            public AvailabilityEnum() {}
            public static implicit operator AvailabilityEnum(string value)
            {
                return new AvailabilityEnum(value);
            }
            public static readonly AvailabilityEnum Internal = new AvailabilityEnum("internal");
            public static readonly AvailabilityEnum Beta = new AvailabilityEnum("beta");
            public static readonly AvailabilityEnum Public = new AvailabilityEnum("public");
            public static readonly AvailabilityEnum Retired = new AvailabilityEnum("retired");

        }

        
        private static Request BuildCreateRequest(CreateCustomOperatorOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Operators/Custom";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.Intelligence,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create a new Custom Operator for the given Account </summary>
        /// <param name="options"> Create CustomOperator parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomOperator </returns>
        public static CustomOperatorResource Create(CreateCustomOperatorOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a new Custom Operator for the given Account </summary>
        /// <param name="options"> Create CustomOperator parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of CustomOperator </returns>
        public static async System.Threading.Tasks.Task<CustomOperatorResource> CreateAsync(CreateCustomOperatorOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a new Custom Operator for the given Account </summary>
        /// <param name="friendlyName"> A human readable description of the new Operator, up to 64 characters. </param>
        /// <param name="operatorType"> Operator Type for this Operator. References an existing Operator Type resource. </param>
        /// <param name="config"> Operator configuration, following the schema defined by the Operator Type. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomOperator </returns>
        public static CustomOperatorResource Create(
                                          string friendlyName,
                                          string operatorType,
                                          object config,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateCustomOperatorOptions(friendlyName, operatorType, config){  };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a new Custom Operator for the given Account </summary>
        /// <param name="friendlyName"> A human readable description of the new Operator, up to 64 characters. </param>
        /// <param name="operatorType"> Operator Type for this Operator. References an existing Operator Type resource. </param>
        /// <param name="config"> Operator configuration, following the schema defined by the Operator Type. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of CustomOperator </returns>
        public static async System.Threading.Tasks.Task<CustomOperatorResource> CreateAsync(
                                                                                  string friendlyName,
                                                                                  string operatorType,
                                                                                  object config,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateCustomOperatorOptions(friendlyName, operatorType, config){  };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> Delete a specific Custom Operator. </summary>
        /// <param name="options"> Delete CustomOperator parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomOperator </returns>
        private static Request BuildDeleteRequest(DeleteCustomOperatorOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Operators/Custom/{Sid}";

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

        /// <summary> Delete a specific Custom Operator. </summary>
        /// <param name="options"> Delete CustomOperator parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomOperator </returns>
        public static bool Delete(DeleteCustomOperatorOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Delete a specific Custom Operator. </summary>
        /// <param name="options"> Delete CustomOperator parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of CustomOperator </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteCustomOperatorOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Delete a specific Custom Operator. </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Custom Operator. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomOperator </returns>
        public static bool Delete(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteCustomOperatorOptions(pathSid)     ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Delete a specific Custom Operator. </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Custom Operator. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of CustomOperator </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteCustomOperatorOptions(pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchCustomOperatorOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Operators/Custom/{Sid}";

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

        /// <summary> Fetch a specific Custom Operator. </summary>
        /// <param name="options"> Fetch CustomOperator parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomOperator </returns>
        public static CustomOperatorResource Fetch(FetchCustomOperatorOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a specific Custom Operator. </summary>
        /// <param name="options"> Fetch CustomOperator parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of CustomOperator </returns>
        public static async System.Threading.Tasks.Task<CustomOperatorResource> FetchAsync(FetchCustomOperatorOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a specific Custom Operator. </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Custom Operator. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomOperator </returns>
        public static CustomOperatorResource Fetch(
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchCustomOperatorOptions(pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a specific Custom Operator. </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Custom Operator. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of CustomOperator </returns>
        public static async System.Threading.Tasks.Task<CustomOperatorResource> FetchAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchCustomOperatorOptions(pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadCustomOperatorOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Operators/Custom";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Intelligence,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieves a list of all Custom Operators for an Account. </summary>
        /// <param name="options"> Read CustomOperator parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomOperator </returns>
        public static ResourceSet<CustomOperatorResource> Read(ReadCustomOperatorOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<CustomOperatorResource>.FromJson("operators", response.Content);
            return new ResourceSet<CustomOperatorResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieves a list of all Custom Operators for an Account. </summary>
        /// <param name="options"> Read CustomOperator parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of CustomOperator </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<CustomOperatorResource>> ReadAsync(ReadCustomOperatorOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<CustomOperatorResource>.FromJson("operators", response.Content);
            return new ResourceSet<CustomOperatorResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieves a list of all Custom Operators for an Account. </summary>
        /// <param name="availability"> Returns Custom Operators with the provided availability type. Possible values: internal, beta, public, retired. </param>
        /// <param name="languageCode"> Returns Custom Operators that support the provided language code. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomOperator </returns>
        public static ResourceSet<CustomOperatorResource> Read(
                                                     CustomOperatorResource.AvailabilityEnum availability = null,
                                                     string languageCode = null,
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadCustomOperatorOptions(){ Availability = availability, LanguageCode = languageCode, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieves a list of all Custom Operators for an Account. </summary>
        /// <param name="availability"> Returns Custom Operators with the provided availability type. Possible values: internal, beta, public, retired. </param>
        /// <param name="languageCode"> Returns Custom Operators that support the provided language code. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of CustomOperator </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<CustomOperatorResource>> ReadAsync(
                                                                                             CustomOperatorResource.AvailabilityEnum availability = null,
                                                                                             string languageCode = null,
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadCustomOperatorOptions(){ Availability = availability, LanguageCode = languageCode, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<CustomOperatorResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<CustomOperatorResource>.FromJson("operators", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<CustomOperatorResource> NextPage(Page<CustomOperatorResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<CustomOperatorResource>.FromJson("operators", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<CustomOperatorResource> PreviousPage(Page<CustomOperatorResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<CustomOperatorResource>.FromJson("operators", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateCustomOperatorOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Operators/Custom/{Sid}";

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

        /// <summary> Update a specific Custom Operator. </summary>
        /// <param name="options"> Update CustomOperator parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomOperator </returns>
        public static CustomOperatorResource Update(UpdateCustomOperatorOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Update a specific Custom Operator. </summary>
        /// <param name="options"> Update CustomOperator parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of CustomOperator </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<CustomOperatorResource> UpdateAsync(UpdateCustomOperatorOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Update a specific Custom Operator. </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Custom Operator. </param>
        /// <param name="friendlyName"> A human-readable name of this resource, up to 64 characters. </param>
        /// <param name="config"> Operator configuration, following the schema defined by the Operator Type. </param>
        /// <param name="ifMatch"> The If-Match HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of CustomOperator </returns>
        public static CustomOperatorResource Update(
                                          string pathSid,
                                          string friendlyName,
                                          object config,
                                          string ifMatch = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateCustomOperatorOptions(pathSid, friendlyName, config){ IfMatch = ifMatch };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Update a specific Custom Operator. </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Custom Operator. </param>
        /// <param name="friendlyName"> A human-readable name of this resource, up to 64 characters. </param>
        /// <param name="config"> Operator configuration, following the schema defined by the Operator Type. </param>
        /// <param name="ifMatch"> The If-Match HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of CustomOperator </returns>
        public static async System.Threading.Tasks.Task<CustomOperatorResource> UpdateAsync(
                                                                              string pathSid,
                                                                              string friendlyName,
                                                                              object config,
                                                                              string ifMatch = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateCustomOperatorOptions(pathSid, friendlyName, config){ IfMatch = ifMatch };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a CustomOperatorResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CustomOperatorResource object represented by the provided JSON </returns>
        public static CustomOperatorResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<CustomOperatorResource>(json);
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

    
        ///<summary> The unique SID identifier of the Account the Custom Operator belongs to. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> A 34 character string that uniquely identifies this Custom Operator. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> A human-readable name of this resource, up to 64 characters. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> A human-readable description of this resource, longer than the friendly name. </summary> 
        [JsonProperty("description")]
        public string Description { get; private set; }

        ///<summary> The creator of the Custom Operator. Custom Operators can only be created by a Twilio Account. </summary> 
        [JsonProperty("author")]
        public string Author { get; private set; }

        ///<summary> Operator Type for this Operator. References an existing Operator Type resource. </summary> 
        [JsonProperty("operator_type")]
        public string OperatorType { get; private set; }

        ///<summary> Numeric Custom Operator version. Incremented with each update on the resource, used to ensure integrity when updating the Custom Operator. </summary> 
        [JsonProperty("version")]
        public int? Version { get; private set; }

        
        [JsonProperty("availability")]
        public CustomOperatorResource.AvailabilityEnum Availability { get; private set; }

        ///<summary> Operator configuration, following the schema defined by the Operator Type. Only available on Operators created by the Account. </summary> 
        [JsonProperty("config")]
        public object Config { get; private set; }

        ///<summary> The date that this Custom Operator was created, given in ISO 8601 format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date that this Custom Operator was updated, given in ISO 8601 format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The URL of this resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private CustomOperatorResource() {

        }
    }
}

