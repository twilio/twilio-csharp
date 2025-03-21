/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Flex
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



namespace Twilio.Rest.FlexApi.V1
{
    public class PluginConfigurationResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreatePluginConfigurationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/PluginService/Configurations";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.FlexApi,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: options.GetHeaderParams()
            );
        }

        /// <summary> create </summary>
        /// <param name="options"> Create PluginConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PluginConfiguration </returns>
        public static PluginConfigurationResource Create(CreatePluginConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="options"> Create PluginConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PluginConfiguration </returns>
        public static async System.Threading.Tasks.Task<PluginConfigurationResource> CreateAsync(CreatePluginConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> create </summary>
        /// <param name="name"> The Flex Plugin Configuration's name. </param>
        /// <param name="plugins"> A list of objects that describe the plugin versions included in the configuration. Each object contains the sid of the plugin version. </param>
        /// <param name="description"> The Flex Plugin Configuration's description. </param>
        /// <param name="flexMetadata"> The Flex-Metadata HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PluginConfiguration </returns>
        public static PluginConfigurationResource Create(
                                          string name,
                                          List<object> plugins = null,
                                          string description = null,
                                          string flexMetadata = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreatePluginConfigurationOptions(name){  Plugins = plugins, Description = description, FlexMetadata = flexMetadata };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="name"> The Flex Plugin Configuration's name. </param>
        /// <param name="plugins"> A list of objects that describe the plugin versions included in the configuration. Each object contains the sid of the plugin version. </param>
        /// <param name="description"> The Flex Plugin Configuration's description. </param>
        /// <param name="flexMetadata"> The Flex-Metadata HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PluginConfiguration </returns>
        public static async System.Threading.Tasks.Task<PluginConfigurationResource> CreateAsync(
                                                                                  string name,
                                                                                  List<object> plugins = null,
                                                                                  string description = null,
                                                                                  string flexMetadata = null,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreatePluginConfigurationOptions(name){  Plugins = plugins, Description = description, FlexMetadata = flexMetadata };
            return await CreateAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchPluginConfigurationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/PluginService/Configurations/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.FlexApi,
                path,
                queryParams: options.GetParams(),
                headerParams: options.GetHeaderParams()
            );
        }

        /// <summary> fetch </summary>
        /// <param name="options"> Fetch PluginConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PluginConfiguration </returns>
        public static PluginConfigurationResource Fetch(FetchPluginConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch PluginConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PluginConfiguration </returns>
        public static async System.Threading.Tasks.Task<PluginConfigurationResource> FetchAsync(FetchPluginConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathSid"> The SID of the Flex Plugin Configuration resource to fetch. </param>
        /// <param name="flexMetadata"> The Flex-Metadata HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PluginConfiguration </returns>
        public static PluginConfigurationResource Fetch(
                                         string pathSid, 
                                         string flexMetadata = null, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchPluginConfigurationOptions(pathSid){ FlexMetadata = flexMetadata };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathSid"> The SID of the Flex Plugin Configuration resource to fetch. </param>
        /// <param name="flexMetadata"> The Flex-Metadata HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PluginConfiguration </returns>
        public static async System.Threading.Tasks.Task<PluginConfigurationResource> FetchAsync(string pathSid, string flexMetadata = null, ITwilioRestClient client = null)
        {
            var options = new FetchPluginConfigurationOptions(pathSid){ FlexMetadata = flexMetadata };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadPluginConfigurationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/PluginService/Configurations";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.FlexApi,
                path,
                queryParams: options.GetParams(),
                headerParams: options.GetHeaderParams()
            );
        }
        /// <summary> read </summary>
        /// <param name="options"> Read PluginConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PluginConfiguration </returns>
        public static ResourceSet<PluginConfigurationResource> Read(ReadPluginConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<PluginConfigurationResource>.FromJson("configurations", response.Content);
            return new ResourceSet<PluginConfigurationResource>(page, options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="options"> Read PluginConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PluginConfiguration </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<PluginConfigurationResource>> ReadAsync(ReadPluginConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<PluginConfigurationResource>.FromJson("configurations", response.Content);
            return new ResourceSet<PluginConfigurationResource>(page, options, client);
        }
        #endif
        /// <summary> read </summary>
        /// <param name="flexMetadata"> The Flex-Metadata HTTP request header </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PluginConfiguration </returns>
        public static ResourceSet<PluginConfigurationResource> Read(
                                                     string flexMetadata = null,
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadPluginConfigurationOptions(){ FlexMetadata = flexMetadata, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="flexMetadata"> The Flex-Metadata HTTP request header </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PluginConfiguration </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<PluginConfigurationResource>> ReadAsync(
                                                                                             string flexMetadata = null,
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadPluginConfigurationOptions(){ FlexMetadata = flexMetadata, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<PluginConfigurationResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<PluginConfigurationResource>.FromJson("configurations", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<PluginConfigurationResource> NextPage(Page<PluginConfigurationResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<PluginConfigurationResource>.FromJson("configurations", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<PluginConfigurationResource> PreviousPage(Page<PluginConfigurationResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<PluginConfigurationResource>.FromJson("configurations", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a PluginConfigurationResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> PluginConfigurationResource object represented by the provided JSON </returns>
        public static PluginConfigurationResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<PluginConfigurationResource>(json);
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

    
        ///<summary> The unique string that we created to identify the Flex Plugin Configuration resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Flex Plugin Configuration resource and owns this resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The name of this Flex Plugin Configuration. </summary> 
        [JsonProperty("name")]
        public string Name { get; private set; }

        ///<summary> The description of the Flex Plugin Configuration resource. </summary> 
        [JsonProperty("description")]
        public string Description { get; private set; }

        ///<summary> Whether the Flex Plugin Configuration is archived. The default value is false. </summary> 
        [JsonProperty("archived")]
        public bool? Archived { get; private set; }

        ///<summary> The date and time in GMT when the Flex Plugin Configuration was created specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The absolute URL of the Flex Plugin Configuration resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> The links </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }



        private PluginConfigurationResource() {

        }
    }
}

