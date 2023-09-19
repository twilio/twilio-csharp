/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Autopilot
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
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;



namespace Twilio.Rest.Autopilot.V1.Assistant
{
    public class QueryResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreateQueryOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Assistants/{AssistantSid}/Queries";

            string PathAssistantSid = options.PathAssistantSid;
            path = path.Replace("{"+"AssistantSid"+"}", PathAssistantSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Autopilot,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> create </summary>
        /// <param name="options"> Create Query parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Query </returns>
        public static QueryResource Create(CreateQueryOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="options"> Create Query parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Query </returns>
        public static async System.Threading.Tasks.Task<QueryResource> CreateAsync(CreateQueryOptions options,
        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> create </summary>
        /// <param name="pathAssistantSid"> The SID of the [Assistant](https://www.twilio.com/docs/autopilot/api/assistant) that is the parent of the new resource. </param>
        /// <param name="language"> The [ISO language-country](https://docs.oracle.com/cd/E13214_01/wli/docs92/xref/xqisocodes.html) string that specifies the language used for the new query. For example: `en-US`. </param>
        /// <param name="query"> The end-user's natural language input. It can be up to 2048 characters long. </param>
        /// <param name="tasks"> The list of tasks to limit the new query to. Tasks are expressed as a comma-separated list of task `unique_name` values. For example, `task-unique_name-1, task-unique_name-2`. Listing specific tasks is useful to constrain the paths that a user can take. </param>
        /// <param name="modelBuild"> The SID or unique name of the [Model Build](https://www.twilio.com/docs/autopilot/api/model-build) to be queried. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Query </returns>
        public static QueryResource Create(
                                          string pathAssistantSid,
                                          string language,
                                          string query,
                                          string tasks = null,
                                          string modelBuild = null,
                                          ITwilioRestClient client = null)
        {
            var options = new CreateQueryOptions(pathAssistantSid, language, query){  Tasks = tasks, ModelBuild = modelBuild };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="pathAssistantSid"> The SID of the [Assistant](https://www.twilio.com/docs/autopilot/api/assistant) that is the parent of the new resource. </param>
        /// <param name="language"> The [ISO language-country](https://docs.oracle.com/cd/E13214_01/wli/docs92/xref/xqisocodes.html) string that specifies the language used for the new query. For example: `en-US`. </param>
        /// <param name="query"> The end-user's natural language input. It can be up to 2048 characters long. </param>
        /// <param name="tasks"> The list of tasks to limit the new query to. Tasks are expressed as a comma-separated list of task `unique_name` values. For example, `task-unique_name-1, task-unique_name-2`. Listing specific tasks is useful to constrain the paths that a user can take. </param>
        /// <param name="modelBuild"> The SID or unique name of the [Model Build](https://www.twilio.com/docs/autopilot/api/model-build) to be queried. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Query </returns>
        public static async System.Threading.Tasks.Task<QueryResource> CreateAsync(
                                                                                  string pathAssistantSid,
                                                                                  string language,
                                                                                  string query,
                                                                                  string tasks = null,
                                                                                  string modelBuild = null,
                                                                                  ITwilioRestClient client = null)
        {
        var options = new CreateQueryOptions(pathAssistantSid, language, query){  Tasks = tasks, ModelBuild = modelBuild };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> delete </summary>
        /// <param name="options"> Delete Query parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Query </returns>
        private static Request BuildDeleteRequest(DeleteQueryOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Assistants/{AssistantSid}/Queries/{Sid}";

            string PathAssistantSid = options.PathAssistantSid;
            path = path.Replace("{"+"AssistantSid"+"}", PathAssistantSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Autopilot,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> delete </summary>
        /// <param name="options"> Delete Query parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Query </returns>
        public static bool Delete(DeleteQueryOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="options"> Delete Query parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Query </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteQueryOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> delete </summary>
        /// <param name="pathAssistantSid"> The SID of the [Assistant](https://www.twilio.com/docs/autopilot/api/assistant) that is the parent of the resources to delete. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Query resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Query </returns>
        public static bool Delete(string pathAssistantSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteQueryOptions(pathAssistantSid, pathSid)        ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="pathAssistantSid"> The SID of the [Assistant](https://www.twilio.com/docs/autopilot/api/assistant) that is the parent of the resources to delete. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Query resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Query </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathAssistantSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteQueryOptions(pathAssistantSid, pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchQueryOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Assistants/{AssistantSid}/Queries/{Sid}";

            string PathAssistantSid = options.PathAssistantSid;
            path = path.Replace("{"+"AssistantSid"+"}", PathAssistantSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Autopilot,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> fetch </summary>
        /// <param name="options"> Fetch Query parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Query </returns>
        public static QueryResource Fetch(FetchQueryOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch Query parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Query </returns>
        public static async System.Threading.Tasks.Task<QueryResource> FetchAsync(FetchQueryOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathAssistantSid"> The SID of the [Assistant](https://www.twilio.com/docs/autopilot/api/assistant) that is the parent of the resource to fetch. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Query resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Query </returns>
        public static QueryResource Fetch(
                                         string pathAssistantSid, 
                                         string pathSid, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchQueryOptions(pathAssistantSid, pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathAssistantSid"> The SID of the [Assistant](https://www.twilio.com/docs/autopilot/api/assistant) that is the parent of the resource to fetch. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Query resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Query </returns>
        public static async System.Threading.Tasks.Task<QueryResource> FetchAsync(string pathAssistantSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchQueryOptions(pathAssistantSid, pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadQueryOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Assistants/{AssistantSid}/Queries";

            string PathAssistantSid = options.PathAssistantSid;
            path = path.Replace("{"+"AssistantSid"+"}", PathAssistantSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Autopilot,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> read </summary>
        /// <param name="options"> Read Query parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Query </returns>
        public static ResourceSet<QueryResource> Read(ReadQueryOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<QueryResource>.FromJson("queries", response.Content);
            return new ResourceSet<QueryResource>(page, options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="options"> Read Query parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Query </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<QueryResource>> ReadAsync(ReadQueryOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<QueryResource>.FromJson("queries", response.Content);
            return new ResourceSet<QueryResource>(page, options, client);
        }
        #endif
        /// <summary> read </summary>
        /// <param name="pathAssistantSid"> The SID of the [Assistant](https://www.twilio.com/docs/autopilot/api/assistant) that is the parent of the resources to read. </param>
        /// <param name="language"> The [ISO language-country](https://docs.oracle.com/cd/E13214_01/wli/docs92/xref/xqisocodes.html) string that specifies the language used by the Query resources to read. For example: `en-US`. </param>
        /// <param name="modelBuild"> The SID or unique name of the [Model Build](https://www.twilio.com/docs/autopilot/api/model-build) to be queried. </param>
        /// <param name="status"> The status of the resources to read. Can be: `pending-review`, `reviewed`, or `discarded` </param>
        /// <param name="dialogueSid"> The SID of the [Dialogue](https://www.twilio.com/docs/autopilot/api/dialogue). </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Query </returns>
        public static ResourceSet<QueryResource> Read(
                                                     string pathAssistantSid,
                                                     string language = null,
                                                     string modelBuild = null,
                                                     string status = null,
                                                     string dialogueSid = null,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadQueryOptions(pathAssistantSid){ Language = language, ModelBuild = modelBuild, Status = status, DialogueSid = dialogueSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="pathAssistantSid"> The SID of the [Assistant](https://www.twilio.com/docs/autopilot/api/assistant) that is the parent of the resources to read. </param>
        /// <param name="language"> The [ISO language-country](https://docs.oracle.com/cd/E13214_01/wli/docs92/xref/xqisocodes.html) string that specifies the language used by the Query resources to read. For example: `en-US`. </param>
        /// <param name="modelBuild"> The SID or unique name of the [Model Build](https://www.twilio.com/docs/autopilot/api/model-build) to be queried. </param>
        /// <param name="status"> The status of the resources to read. Can be: `pending-review`, `reviewed`, or `discarded` </param>
        /// <param name="dialogueSid"> The SID of the [Dialogue](https://www.twilio.com/docs/autopilot/api/dialogue). </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Query </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<QueryResource>> ReadAsync(
                                                                                             string pathAssistantSid,
                                                                                             string language = null,
                                                                                             string modelBuild = null,
                                                                                             string status = null,
                                                                                             string dialogueSid = null,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadQueryOptions(pathAssistantSid){ Language = language, ModelBuild = modelBuild, Status = status, DialogueSid = dialogueSid, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<QueryResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<QueryResource>.FromJson("queries", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<QueryResource> NextPage(Page<QueryResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<QueryResource>.FromJson("queries", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<QueryResource> PreviousPage(Page<QueryResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<QueryResource>.FromJson("queries", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateQueryOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Assistants/{AssistantSid}/Queries/{Sid}";

            string PathAssistantSid = options.PathAssistantSid;
            path = path.Replace("{"+"AssistantSid"+"}", PathAssistantSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Autopilot,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> update </summary>
        /// <param name="options"> Update Query parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Query </returns>
        public static QueryResource Update(UpdateQueryOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> update </summary>
        /// <param name="options"> Update Query parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Query </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<QueryResource> UpdateAsync(UpdateQueryOptions options,
                                                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> update </summary>
        /// <param name="pathAssistantSid"> The SID of the [Assistant](https://www.twilio.com/docs/autopilot/api/assistant) that is the parent of the resource to update. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Query resource to update. </param>
        /// <param name="sampleSid"> The SID of an optional reference to the [Sample](https://www.twilio.com/docs/autopilot/api/task-sample) created from the query. </param>
        /// <param name="status"> The new status of the resource. Can be: `pending-review`, `reviewed`, or `discarded` </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Query </returns>
        public static QueryResource Update(
                                          string pathAssistantSid,
                                          string pathSid,
                                          string sampleSid = null,
                                          string status = null,
                                          ITwilioRestClient client = null)
        {
            var options = new UpdateQueryOptions(pathAssistantSid, pathSid){ SampleSid = sampleSid, Status = status };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> update </summary>
        /// <param name="pathAssistantSid"> The SID of the [Assistant](https://www.twilio.com/docs/autopilot/api/assistant) that is the parent of the resource to update. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Query resource to update. </param>
        /// <param name="sampleSid"> The SID of an optional reference to the [Sample](https://www.twilio.com/docs/autopilot/api/task-sample) created from the query. </param>
        /// <param name="status"> The new status of the resource. Can be: `pending-review`, `reviewed`, or `discarded` </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Query </returns>
        public static async System.Threading.Tasks.Task<QueryResource> UpdateAsync(
                                                                              string pathAssistantSid,
                                                                              string pathSid,
                                                                              string sampleSid = null,
                                                                              string status = null,
                                                                              ITwilioRestClient client = null)
        {
            var options = new UpdateQueryOptions(pathAssistantSid, pathSid){ SampleSid = sampleSid, Status = status };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a QueryResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> QueryResource object represented by the provided JSON </returns>
        public static QueryResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<QueryResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Query resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The date and time in GMT when the resource was created specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the resource was last updated specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The natural language analysis results that include the [Task](https://www.twilio.com/docs/autopilot/api/task) recognized and a list of identified [Fields](https://www.twilio.com/docs/autopilot/api/task-field). </summary> 
        [JsonProperty("results")]
        public object Results { get; private set; }

        ///<summary> The [ISO language-country](https://docs.oracle.com/cd/E13214_01/wli/docs92/xref/xqisocodes.html) string that specifies the language used by the Query. For example: `en-US`. </summary> 
        [JsonProperty("language")]
        public string Language { get; private set; }

        ///<summary> The SID of the [Model Build](https://www.twilio.com/docs/autopilot/api/model-build) queried. </summary> 
        [JsonProperty("model_build_sid")]
        public string ModelBuildSid { get; private set; }

        ///<summary> The end-user's natural language input. </summary> 
        [JsonProperty("query")]
        public string Query { get; private set; }

        ///<summary> The SID of an optional reference to the [Sample](https://www.twilio.com/docs/autopilot/api/task-sample) created from the query. </summary> 
        [JsonProperty("sample_sid")]
        public string SampleSid { get; private set; }

        ///<summary> The SID of the [Assistant](https://www.twilio.com/docs/autopilot/api/assistant) that is the parent of the resource. </summary> 
        [JsonProperty("assistant_sid")]
        public string AssistantSid { get; private set; }

        ///<summary> The unique string that we created to identify the Query resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The status of the Query. Can be: `pending-review`, `reviewed`, or `discarded` </summary> 
        [JsonProperty("status")]
        public string Status { get; private set; }

        ///<summary> The absolute URL of the Query resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> The communication channel from where the end-user input came. </summary> 
        [JsonProperty("source_channel")]
        public string SourceChannel { get; private set; }

        ///<summary> The SID of the [Dialogue](https://www.twilio.com/docs/autopilot/api/dialogue). </summary> 
        [JsonProperty("dialogue_sid")]
        public string DialogueSid { get; private set; }



        private QueryResource() {

        }
    }
}

