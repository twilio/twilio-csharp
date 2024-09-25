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
using Twilio.Types;




namespace Twilio.Rest.FlexApi.V1
{
    public class WebChannelResource : Resource
    {
    

    
        public sealed class ChatStatusEnum : StringEnum
        {
            private ChatStatusEnum(string value) : base(value) {}
            public ChatStatusEnum() {}
            public static implicit operator ChatStatusEnum(string value)
            {
                return new ChatStatusEnum(value);
            }
            public static readonly ChatStatusEnum Inactive = new ChatStatusEnum("inactive");

        }

        
        private static Request BuildCreateRequest(CreateWebChannelOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/WebChannels";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.FlexApi,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> create </summary>
        /// <param name="options"> Create WebChannel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of WebChannel </returns>
        public static WebChannelResource Create(CreateWebChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="options"> Create WebChannel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of WebChannel </returns>
        public static async System.Threading.Tasks.Task<WebChannelResource> CreateAsync(CreateWebChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> create </summary>
        /// <param name="flexFlowSid"> The SID of the Flex Flow. </param>
        /// <param name="identity"> The chat identity. </param>
        /// <param name="customerFriendlyName"> The chat participant's friendly name. </param>
        /// <param name="chatFriendlyName"> The chat channel's friendly name. </param>
        /// <param name="chatUniqueName"> The chat channel's unique name. </param>
        /// <param name="preEngagementData"> The pre-engagement data. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of WebChannel </returns>
        public static WebChannelResource Create(
                                          string flexFlowSid,
                                          string identity,
                                          string customerFriendlyName,
                                          string chatFriendlyName,
                                          string chatUniqueName = null,
                                          string preEngagementData = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateWebChannelOptions(flexFlowSid, identity, customerFriendlyName, chatFriendlyName){  ChatUniqueName = chatUniqueName, PreEngagementData = preEngagementData };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="flexFlowSid"> The SID of the Flex Flow. </param>
        /// <param name="identity"> The chat identity. </param>
        /// <param name="customerFriendlyName"> The chat participant's friendly name. </param>
        /// <param name="chatFriendlyName"> The chat channel's friendly name. </param>
        /// <param name="chatUniqueName"> The chat channel's unique name. </param>
        /// <param name="preEngagementData"> The pre-engagement data. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of WebChannel </returns>
        public static async System.Threading.Tasks.Task<WebChannelResource> CreateAsync(
                                                                                  string flexFlowSid,
                                                                                  string identity,
                                                                                  string customerFriendlyName,
                                                                                  string chatFriendlyName,
                                                                                  string chatUniqueName = null,
                                                                                  string preEngagementData = null,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateWebChannelOptions(flexFlowSid, identity, customerFriendlyName, chatFriendlyName){  ChatUniqueName = chatUniqueName, PreEngagementData = preEngagementData };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> delete </summary>
        /// <param name="options"> Delete WebChannel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of WebChannel </returns>
        private static Request BuildDeleteRequest(DeleteWebChannelOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/WebChannels/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.FlexApi,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> delete </summary>
        /// <param name="options"> Delete WebChannel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of WebChannel </returns>
        public static bool Delete(DeleteWebChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="options"> Delete WebChannel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of WebChannel </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteWebChannelOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> delete </summary>
        /// <param name="pathSid"> The SID of the WebChannel resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of WebChannel </returns>
        public static bool Delete(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteWebChannelOptions(pathSid)     ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="pathSid"> The SID of the WebChannel resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of WebChannel </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteWebChannelOptions(pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchWebChannelOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/WebChannels/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.FlexApi,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> fetch </summary>
        /// <param name="options"> Fetch WebChannel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of WebChannel </returns>
        public static WebChannelResource Fetch(FetchWebChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch WebChannel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of WebChannel </returns>
        public static async System.Threading.Tasks.Task<WebChannelResource> FetchAsync(FetchWebChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathSid"> The SID of the WebChannel resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of WebChannel </returns>
        public static WebChannelResource Fetch(
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchWebChannelOptions(pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathSid"> The SID of the WebChannel resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of WebChannel </returns>
        public static async System.Threading.Tasks.Task<WebChannelResource> FetchAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchWebChannelOptions(pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadWebChannelOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/WebChannels";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.FlexApi,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> read </summary>
        /// <param name="options"> Read WebChannel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of WebChannel </returns>
        public static ResourceSet<WebChannelResource> Read(ReadWebChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<WebChannelResource>.FromJson("flex_chat_channels", response.Content);
            return new ResourceSet<WebChannelResource>(page, options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="options"> Read WebChannel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of WebChannel </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<WebChannelResource>> ReadAsync(ReadWebChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<WebChannelResource>.FromJson("flex_chat_channels", response.Content);
            return new ResourceSet<WebChannelResource>(page, options, client);
        }
        #endif
        /// <summary> read </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of WebChannel </returns>
        public static ResourceSet<WebChannelResource> Read(
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadWebChannelOptions(){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of WebChannel </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<WebChannelResource>> ReadAsync(
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadWebChannelOptions(){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<WebChannelResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<WebChannelResource>.FromJson("flex_chat_channels", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<WebChannelResource> NextPage(Page<WebChannelResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<WebChannelResource>.FromJson("flex_chat_channels", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<WebChannelResource> PreviousPage(Page<WebChannelResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<WebChannelResource>.FromJson("flex_chat_channels", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateWebChannelOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/WebChannels/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.FlexApi,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> update </summary>
        /// <param name="options"> Update WebChannel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of WebChannel </returns>
        public static WebChannelResource Update(UpdateWebChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> update </summary>
        /// <param name="options"> Update WebChannel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of WebChannel </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<WebChannelResource> UpdateAsync(UpdateWebChannelOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> update </summary>
        /// <param name="pathSid"> The SID of the WebChannel resource to update. </param>
        /// <param name="chatStatus">  </param>
        /// <param name="postEngagementData"> The post-engagement data. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of WebChannel </returns>
        public static WebChannelResource Update(
                                          string pathSid,
                                          WebChannelResource.ChatStatusEnum chatStatus = null,
                                          string postEngagementData = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateWebChannelOptions(pathSid){ ChatStatus = chatStatus, PostEngagementData = postEngagementData };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> update </summary>
        /// <param name="pathSid"> The SID of the WebChannel resource to update. </param>
        /// <param name="chatStatus">  </param>
        /// <param name="postEngagementData"> The post-engagement data. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of WebChannel </returns>
        public static async System.Threading.Tasks.Task<WebChannelResource> UpdateAsync(
                                                                              string pathSid,
                                                                              WebChannelResource.ChatStatusEnum chatStatus = null,
                                                                              string postEngagementData = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateWebChannelOptions(pathSid){ ChatStatus = chatStatus, PostEngagementData = postEngagementData };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a WebChannelResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WebChannelResource object represented by the provided JSON </returns>
        public static WebChannelResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<WebChannelResource>(json);
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

    
        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the WebChannel resource and owns this Workflow. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The SID of the Flex Flow. </summary> 
        [JsonProperty("flex_flow_sid")]
        public string FlexFlowSid { get; private set; }

        ///<summary> The unique string that we created to identify the WebChannel resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The absolute URL of the WebChannel resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> The date and time in GMT when the resource was created specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the resource was last updated specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }



        private WebChannelResource() {

        }
    }
}

