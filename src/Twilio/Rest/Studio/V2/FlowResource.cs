/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Studio
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




namespace Twilio.Rest.Studio.V2
{
    public class FlowResource : Resource
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
            public static readonly StatusEnum Draft = new StatusEnum("draft");
            public static readonly StatusEnum Published = new StatusEnum("published");

        }

        
        private static Request BuildCreateRequest(CreateFlowOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Flows";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.Studio,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create a Flow. </summary>
        /// <param name="options"> Create Flow parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Flow </returns>
        public static FlowResource Create(CreateFlowOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a Flow. </summary>
        /// <param name="options"> Create Flow parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Flow </returns>
        public static async System.Threading.Tasks.Task<FlowResource> CreateAsync(CreateFlowOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a Flow. </summary>
        /// <param name="friendlyName"> The string that you assigned to describe the Flow. </param>
        /// <param name="status">  </param>
        /// <param name="definition"> JSON representation of flow definition. </param>
        /// <param name="commitMessage"> Description of change made in the revision. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Flow </returns>
        public static FlowResource Create(
                                          string friendlyName,
                                          FlowResource.StatusEnum status,
                                          object definition,
                                          string commitMessage = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateFlowOptions(friendlyName, status, definition){  CommitMessage = commitMessage };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a Flow. </summary>
        /// <param name="friendlyName"> The string that you assigned to describe the Flow. </param>
        /// <param name="status">  </param>
        /// <param name="definition"> JSON representation of flow definition. </param>
        /// <param name="commitMessage"> Description of change made in the revision. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Flow </returns>
        public static async System.Threading.Tasks.Task<FlowResource> CreateAsync(
                                                                                  string friendlyName,
                                                                                  FlowResource.StatusEnum status,
                                                                                  object definition,
                                                                                  string commitMessage = null,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateFlowOptions(friendlyName, status, definition){  CommitMessage = commitMessage };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> Delete a specific Flow. </summary>
        /// <param name="options"> Delete Flow parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Flow </returns>
        private static Request BuildDeleteRequest(DeleteFlowOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Flows/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Studio,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Delete a specific Flow. </summary>
        /// <param name="options"> Delete Flow parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Flow </returns>
        public static bool Delete(DeleteFlowOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Delete a specific Flow. </summary>
        /// <param name="options"> Delete Flow parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Flow </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteFlowOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Delete a specific Flow. </summary>
        /// <param name="pathSid"> The SID of the Flow resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Flow </returns>
        public static bool Delete(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteFlowOptions(pathSid)     ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Delete a specific Flow. </summary>
        /// <param name="pathSid"> The SID of the Flow resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Flow </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteFlowOptions(pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchFlowOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Flows/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Studio,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Retrieve a specific Flow. </summary>
        /// <param name="options"> Fetch Flow parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Flow </returns>
        public static FlowResource Fetch(FetchFlowOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Retrieve a specific Flow. </summary>
        /// <param name="options"> Fetch Flow parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Flow </returns>
        public static async System.Threading.Tasks.Task<FlowResource> FetchAsync(FetchFlowOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Retrieve a specific Flow. </summary>
        /// <param name="pathSid"> The SID of the Flow resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Flow </returns>
        public static FlowResource Fetch(
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchFlowOptions(pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a specific Flow. </summary>
        /// <param name="pathSid"> The SID of the Flow resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Flow </returns>
        public static async System.Threading.Tasks.Task<FlowResource> FetchAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchFlowOptions(pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadFlowOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Flows";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Studio,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of all Flows. </summary>
        /// <param name="options"> Read Flow parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Flow </returns>
        public static ResourceSet<FlowResource> Read(ReadFlowOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<FlowResource>.FromJson("flows", response.Content);
            return new ResourceSet<FlowResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Flows. </summary>
        /// <param name="options"> Read Flow parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Flow </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<FlowResource>> ReadAsync(ReadFlowOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<FlowResource>.FromJson("flows", response.Content);
            return new ResourceSet<FlowResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of all Flows. </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Flow </returns>
        public static ResourceSet<FlowResource> Read(
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadFlowOptions(){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Flows. </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Flow </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<FlowResource>> ReadAsync(
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadFlowOptions(){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<FlowResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<FlowResource>.FromJson("flows", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<FlowResource> NextPage(Page<FlowResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<FlowResource>.FromJson("flows", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<FlowResource> PreviousPage(Page<FlowResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<FlowResource>.FromJson("flows", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateFlowOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Flows/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Studio,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Update a Flow. </summary>
        /// <param name="options"> Update Flow parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Flow </returns>
        public static FlowResource Update(UpdateFlowOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Update a Flow. </summary>
        /// <param name="options"> Update Flow parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Flow </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<FlowResource> UpdateAsync(UpdateFlowOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Update a Flow. </summary>
        /// <param name="pathSid"> The SID of the Flow resource to fetch. </param>
        /// <param name="status">  </param>
        /// <param name="friendlyName"> The string that you assigned to describe the Flow. </param>
        /// <param name="definition"> JSON representation of flow definition. </param>
        /// <param name="commitMessage"> Description of change made in the revision. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Flow </returns>
        public static FlowResource Update(
                                          string pathSid,
                                          FlowResource.StatusEnum status,
                                          string friendlyName = null,
                                          object definition = null,
                                          string commitMessage = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateFlowOptions(pathSid, status){ FriendlyName = friendlyName, Definition = definition, CommitMessage = commitMessage };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Update a Flow. </summary>
        /// <param name="pathSid"> The SID of the Flow resource to fetch. </param>
        /// <param name="status">  </param>
        /// <param name="friendlyName"> The string that you assigned to describe the Flow. </param>
        /// <param name="definition"> JSON representation of flow definition. </param>
        /// <param name="commitMessage"> Description of change made in the revision. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Flow </returns>
        public static async System.Threading.Tasks.Task<FlowResource> UpdateAsync(
                                                                              string pathSid,
                                                                              FlowResource.StatusEnum status,
                                                                              string friendlyName = null,
                                                                              object definition = null,
                                                                              string commitMessage = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateFlowOptions(pathSid, status){ FriendlyName = friendlyName, Definition = definition, CommitMessage = commitMessage };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a FlowResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> FlowResource object represented by the provided JSON </returns>
        public static FlowResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<FlowResource>(json);
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

    
        ///<summary> The unique string that we created to identify the Flow resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Flow resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The string that you assigned to describe the Flow. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> JSON representation of flow definition. </summary> 
        [JsonProperty("definition")]
        public object Definition { get; private set; }

        
        [JsonProperty("status")]
        public FlowResource.StatusEnum Status { get; private set; }

        ///<summary> The latest revision number of the Flow's definition. </summary> 
        [JsonProperty("revision")]
        public int? Revision { get; private set; }

        ///<summary> Description of change made in the revision. </summary> 
        [JsonProperty("commit_message")]
        public string CommitMessage { get; private set; }

        ///<summary> Boolean if the flow definition is valid. </summary> 
        [JsonProperty("valid")]
        public bool? Valid { get; private set; }

        ///<summary> List of error in the flow definition. </summary> 
        [JsonProperty("errors")]
        public List<object> Errors { get; private set; }

        ///<summary> List of warnings in the flow definition. </summary> 
        [JsonProperty("warnings")]
        public List<object> Warnings { get; private set; }

        ///<summary> The date and time in GMT when the resource was created specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the resource was last updated specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The webhook_url </summary> 
        [JsonProperty("webhook_url")]
        public Uri WebhookUrl { get; private set; }

        ///<summary> The absolute URL of the resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> The URLs of the Flow's nested resources. </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }



        private FlowResource() {

        }
    }
}

