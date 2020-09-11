/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
/// currently do not have developer preview access, please contact help@twilio.com.
///
/// QueryResource
/// </summary>

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Understand.Assistant
{

    public class QueryResource : Resource
    {
        private static Request BuildFetchRequest(FetchQueryOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/understand/Assistants/" + options.PathAssistantSid + "/Queries/" + options.PathSid + "",
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// fetch
        /// </summary>
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
        /// <summary>
        /// fetch
        /// </summary>
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

        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Query </returns>
        public static QueryResource Fetch(string pathAssistantSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchQueryOptions(pathAssistantSid, pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Query </returns>
        public static async System.Threading.Tasks.Task<QueryResource> FetchAsync(string pathAssistantSid,
                                                                                  string pathSid,
                                                                                  ITwilioRestClient client = null)
        {
            var options = new FetchQueryOptions(pathAssistantSid, pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadQueryOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/understand/Assistants/" + options.PathAssistantSid + "/Queries",
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// read
        /// </summary>
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
        /// <summary>
        /// read
        /// </summary>
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

        /// <summary>
        /// read
        /// </summary>
        /// <param name="pathAssistantSid"> The unique ID of the parent Assistant. </param>
        /// <param name="language"> An ISO language-country string of the sample. </param>
        /// <param name="modelBuild"> The Model Build Sid or unique name of the Model Build to be queried. </param>
        /// <param name="status"> A string that described the query status. The values can be: pending_review, reviewed,
        ///              discarded </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Query </returns>
        public static ResourceSet<QueryResource> Read(string pathAssistantSid,
                                                      string language = null,
                                                      string modelBuild = null,
                                                      string status = null,
                                                      int? pageSize = null,
                                                      long? limit = null,
                                                      ITwilioRestClient client = null)
        {
            var options = new ReadQueryOptions(pathAssistantSid){Language = language, ModelBuild = modelBuild, Status = status, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        /// <param name="pathAssistantSid"> The unique ID of the parent Assistant. </param>
        /// <param name="language"> An ISO language-country string of the sample. </param>
        /// <param name="modelBuild"> The Model Build Sid or unique name of the Model Build to be queried. </param>
        /// <param name="status"> A string that described the query status. The values can be: pending_review, reviewed,
        ///              discarded </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Query </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<QueryResource>> ReadAsync(string pathAssistantSid,
                                                                                              string language = null,
                                                                                              string modelBuild = null,
                                                                                              string status = null,
                                                                                              int? pageSize = null,
                                                                                              long? limit = null,
                                                                                              ITwilioRestClient client = null)
        {
            var options = new ReadQueryOptions(pathAssistantSid){Language = language, ModelBuild = modelBuild, Status = status, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        /// <summary>
        /// Fetch the target page of records
        /// </summary>
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

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<QueryResource> NextPage(Page<QueryResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Preview)
            );

            var response = client.Request(request);
            return Page<QueryResource>.FromJson("queries", response.Content);
        }

        /// <summary>
        /// Fetch the previous page of records
        /// </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<QueryResource> PreviousPage(Page<QueryResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Preview)
            );

            var response = client.Request(request);
            return Page<QueryResource>.FromJson("queries", response.Content);
        }

        private static Request BuildCreateRequest(CreateQueryOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/understand/Assistants/" + options.PathAssistantSid + "/Queries",
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// create
        /// </summary>
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
        /// <summary>
        /// create
        /// </summary>
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

        /// <summary>
        /// create
        /// </summary>
        /// <param name="pathAssistantSid"> The unique ID of the parent Assistant. </param>
        /// <param name="language"> An ISO language-country string of the sample. </param>
        /// <param name="query"> A user-provided string that uniquely identifies this resource as an alternative to the sid. It
        ///             can be up to 2048 characters long. </param>
        /// <param name="tasks"> Constraints the query to a set of tasks. Useful when you need to constrain the paths the user
        ///             can take. Tasks should be comma separated task-unique-name-1, task-unique-name-2 </param>
        /// <param name="modelBuild"> The Model Build Sid or unique name of the Model Build to be queried. </param>
        /// <param name="field"> Constraints the query to a given Field with an task. Useful when you know the Field you are
        ///             expecting. It accepts one field in the format task-unique-name-1:field-unique-name </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Query </returns>
        public static QueryResource Create(string pathAssistantSid,
                                           string language,
                                           string query,
                                           string tasks = null,
                                           string modelBuild = null,
                                           string field = null,
                                           ITwilioRestClient client = null)
        {
            var options = new CreateQueryOptions(pathAssistantSid, language, query){Tasks = tasks, ModelBuild = modelBuild, Field = field};
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        /// <param name="pathAssistantSid"> The unique ID of the parent Assistant. </param>
        /// <param name="language"> An ISO language-country string of the sample. </param>
        /// <param name="query"> A user-provided string that uniquely identifies this resource as an alternative to the sid. It
        ///             can be up to 2048 characters long. </param>
        /// <param name="tasks"> Constraints the query to a set of tasks. Useful when you need to constrain the paths the user
        ///             can take. Tasks should be comma separated task-unique-name-1, task-unique-name-2 </param>
        /// <param name="modelBuild"> The Model Build Sid or unique name of the Model Build to be queried. </param>
        /// <param name="field"> Constraints the query to a given Field with an task. Useful when you know the Field you are
        ///             expecting. It accepts one field in the format task-unique-name-1:field-unique-name </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Query </returns>
        public static async System.Threading.Tasks.Task<QueryResource> CreateAsync(string pathAssistantSid,
                                                                                   string language,
                                                                                   string query,
                                                                                   string tasks = null,
                                                                                   string modelBuild = null,
                                                                                   string field = null,
                                                                                   ITwilioRestClient client = null)
        {
            var options = new CreateQueryOptions(pathAssistantSid, language, query){Tasks = tasks, ModelBuild = modelBuild, Field = field};
            return await CreateAsync(options, client);
        }
        #endif

        private static Request BuildUpdateRequest(UpdateQueryOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/understand/Assistants/" + options.PathAssistantSid + "/Queries/" + options.PathSid + "",
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// update
        /// </summary>
        /// <param name="options"> Update Query parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Query </returns>
        public static QueryResource Update(UpdateQueryOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// update
        /// </summary>
        /// <param name="options"> Update Query parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Query </returns>
        public static async System.Threading.Tasks.Task<QueryResource> UpdateAsync(UpdateQueryOptions options,
                                                                                   ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary>
        /// update
        /// </summary>
        /// <param name="pathAssistantSid"> The unique ID of the parent Assistant. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="sampleSid"> An optional reference to the Sample created from this query. </param>
        /// <param name="status"> A string that described the query status. The values can be: pending_review, reviewed,
        ///              discarded </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Query </returns>
        public static QueryResource Update(string pathAssistantSid,
                                           string pathSid,
                                           string sampleSid = null,
                                           string status = null,
                                           ITwilioRestClient client = null)
        {
            var options = new UpdateQueryOptions(pathAssistantSid, pathSid){SampleSid = sampleSid, Status = status};
            return Update(options, client);
        }

        #if !NET35
        /// <summary>
        /// update
        /// </summary>
        /// <param name="pathAssistantSid"> The unique ID of the parent Assistant. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="sampleSid"> An optional reference to the Sample created from this query. </param>
        /// <param name="status"> A string that described the query status. The values can be: pending_review, reviewed,
        ///              discarded </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Query </returns>
        public static async System.Threading.Tasks.Task<QueryResource> UpdateAsync(string pathAssistantSid,
                                                                                   string pathSid,
                                                                                   string sampleSid = null,
                                                                                   string status = null,
                                                                                   ITwilioRestClient client = null)
        {
            var options = new UpdateQueryOptions(pathAssistantSid, pathSid){SampleSid = sampleSid, Status = status};
            return await UpdateAsync(options, client);
        }
        #endif

        private static Request BuildDeleteRequest(DeleteQueryOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Preview,
                "/understand/Assistants/" + options.PathAssistantSid + "/Queries/" + options.PathSid + "",
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// delete
        /// </summary>
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
        /// <summary>
        /// delete
        /// </summary>
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

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Query </returns>
        public static bool Delete(string pathAssistantSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteQueryOptions(pathAssistantSid, pathSid);
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Query </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathAssistantSid,
                                                                          string pathSid,
                                                                          ITwilioRestClient client = null)
        {
            var options = new DeleteQueryOptions(pathAssistantSid, pathSid);
            return await DeleteAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a QueryResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> QueryResource object represented by the provided JSON </returns>
        public static QueryResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<QueryResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// The unique ID of the Account that created this Query.
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The date that this resource was created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The date that this resource was last updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// The natural language analysis results which include the Task recognized, the confidence score and a list of identified Fields.
        /// </summary>
        [JsonProperty("results")]
        public object Results { get; private set; }
        /// <summary>
        /// An ISO language-country string of the sample.
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; private set; }
        /// <summary>
        /// The unique ID of the Model Build queried.
        /// </summary>
        [JsonProperty("model_build_sid")]
        public string ModelBuildSid { get; private set; }
        /// <summary>
        /// The end-user's natural language input.
        /// </summary>
        [JsonProperty("query")]
        public string Query { get; private set; }
        /// <summary>
        /// An optional reference to the Sample created from this query.
        /// </summary>
        [JsonProperty("sample_sid")]
        public string SampleSid { get; private set; }
        /// <summary>
        /// The unique ID of the parent Assistant.
        /// </summary>
        [JsonProperty("assistant_sid")]
        public string AssistantSid { get; private set; }
        /// <summary>
        /// A 34 character string that uniquely identifies this resource.
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// A string that described the query status. The values can be: pending_review, reviewed, discarded
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; private set; }
        /// <summary>
        /// The url
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        /// <summary>
        /// The communication channel where this end-user input came from
        /// </summary>
        [JsonProperty("source_channel")]
        public string SourceChannel { get; private set; }

        private QueryResource()
        {

        }
    }

}