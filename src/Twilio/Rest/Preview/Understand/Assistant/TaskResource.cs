/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /
/// <summary>
/// PLEASE NOTE that this class contains preview products that are subject to change. Use them with caution. If you
/// currently do not have developer preview access, please contact help@twilio.com.
///
/// TaskResource
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

    public class TaskResource : Resource
    {
        private static Request BuildFetchRequest(FetchTaskOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/understand/Assistants/" + options.PathAssistantSid + "/Tasks/" + options.PathSid + "",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="options"> Fetch Task parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Task </returns>
        public static TaskResource Fetch(FetchTaskOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="options"> Fetch Task parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Task </returns>
        public static async System.Threading.Tasks.Task<TaskResource> FetchAsync(FetchTaskOptions options,
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
        /// <returns> A single instance of Task </returns>
        public static TaskResource Fetch(string pathAssistantSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchTaskOptions(pathAssistantSid, pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Task </returns>
        public static async System.Threading.Tasks.Task<TaskResource> FetchAsync(string pathAssistantSid,
                                                                                 string pathSid,
                                                                                 ITwilioRestClient client = null)
        {
            var options = new FetchTaskOptions(pathAssistantSid, pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildReadRequest(ReadTaskOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/understand/Assistants/" + options.PathAssistantSid + "/Tasks",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// read
        /// </summary>
        /// <param name="options"> Read Task parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Task </returns>
        public static ResourceSet<TaskResource> Read(ReadTaskOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<TaskResource>.FromJson("tasks", response.Content);
            return new ResourceSet<TaskResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        /// <param name="options"> Read Task parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Task </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<TaskResource>> ReadAsync(ReadTaskOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<TaskResource>.FromJson("tasks", response.Content);
            return new ResourceSet<TaskResource>(page, options, client);
        }
        #endif

        /// <summary>
        /// read
        /// </summary>
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Task </returns>
        public static ResourceSet<TaskResource> Read(string pathAssistantSid,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadTaskOptions(pathAssistantSid){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Task </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<TaskResource>> ReadAsync(string pathAssistantSid,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadTaskOptions(pathAssistantSid){PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        /// <summary>
        /// Fetch the target page of records
        /// </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<TaskResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<TaskResource>.FromJson("tasks", response.Content);
        }

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<TaskResource> NextPage(Page<TaskResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Preview)
            );

            var response = client.Request(request);
            return Page<TaskResource>.FromJson("tasks", response.Content);
        }

        /// <summary>
        /// Fetch the previous page of records
        /// </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<TaskResource> PreviousPage(Page<TaskResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Preview)
            );

            var response = client.Request(request);
            return Page<TaskResource>.FromJson("tasks", response.Content);
        }

        private static Request BuildCreateRequest(CreateTaskOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/understand/Assistants/" + options.PathAssistantSid + "/Tasks",
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// create
        /// </summary>
        /// <param name="options"> Create Task parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Task </returns>
        public static TaskResource Create(CreateTaskOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        /// <param name="options"> Create Task parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Task </returns>
        public static async System.Threading.Tasks.Task<TaskResource> CreateAsync(CreateTaskOptions options,
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
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="uniqueName"> A user-provided string that uniquely identifies this resource as an alternative to the
        ///                  sid. Unique up to 64 characters long. </param>
        /// <param name="friendlyName"> A user-provided string that identifies this resource. It is non-unique and can up to
        ///                    255 characters long. </param>
        /// <param name="actions"> A user-provided JSON object encoded as a string to specify the actions for this task. It is
        ///               optional and non-unique. </param>
        /// <param name="actionsUrl"> User-provided HTTP endpoint where from the assistant fetches actions </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Task </returns>
        public static TaskResource Create(string pathAssistantSid,
                                          string uniqueName,
                                          string friendlyName = null,
                                          object actions = null,
                                          Uri actionsUrl = null,
                                          ITwilioRestClient client = null)
        {
            var options = new CreateTaskOptions(pathAssistantSid, uniqueName){FriendlyName = friendlyName, Actions = actions, ActionsUrl = actionsUrl};
            return Create(options, client);
        }

        #if !NET35
        /// <summary>
        /// create
        /// </summary>
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="uniqueName"> A user-provided string that uniquely identifies this resource as an alternative to the
        ///                  sid. Unique up to 64 characters long. </param>
        /// <param name="friendlyName"> A user-provided string that identifies this resource. It is non-unique and can up to
        ///                    255 characters long. </param>
        /// <param name="actions"> A user-provided JSON object encoded as a string to specify the actions for this task. It is
        ///               optional and non-unique. </param>
        /// <param name="actionsUrl"> User-provided HTTP endpoint where from the assistant fetches actions </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Task </returns>
        public static async System.Threading.Tasks.Task<TaskResource> CreateAsync(string pathAssistantSid,
                                                                                  string uniqueName,
                                                                                  string friendlyName = null,
                                                                                  object actions = null,
                                                                                  Uri actionsUrl = null,
                                                                                  ITwilioRestClient client = null)
        {
            var options = new CreateTaskOptions(pathAssistantSid, uniqueName){FriendlyName = friendlyName, Actions = actions, ActionsUrl = actionsUrl};
            return await CreateAsync(options, client);
        }
        #endif

        private static Request BuildUpdateRequest(UpdateTaskOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/understand/Assistants/" + options.PathAssistantSid + "/Tasks/" + options.PathSid + "",
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// update
        /// </summary>
        /// <param name="options"> Update Task parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Task </returns>
        public static TaskResource Update(UpdateTaskOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// update
        /// </summary>
        /// <param name="options"> Update Task parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Task </returns>
        public static async System.Threading.Tasks.Task<TaskResource> UpdateAsync(UpdateTaskOptions options,
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
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="friendlyName"> A user-provided string that identifies this resource. It is non-unique and can up to
        ///                    255 characters long. </param>
        /// <param name="uniqueName"> A user-provided string that uniquely identifies this resource as an alternative to the
        ///                  sid. Unique up to 64 characters long. </param>
        /// <param name="actions"> A user-provided JSON object encoded as a string to specify the actions for this task. It is
        ///               optional and non-unique. </param>
        /// <param name="actionsUrl"> User-provided HTTP endpoint where from the assistant fetches actions </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Task </returns>
        public static TaskResource Update(string pathAssistantSid,
                                          string pathSid,
                                          string friendlyName = null,
                                          string uniqueName = null,
                                          object actions = null,
                                          Uri actionsUrl = null,
                                          ITwilioRestClient client = null)
        {
            var options = new UpdateTaskOptions(pathAssistantSid, pathSid){FriendlyName = friendlyName, UniqueName = uniqueName, Actions = actions, ActionsUrl = actionsUrl};
            return Update(options, client);
        }

        #if !NET35
        /// <summary>
        /// update
        /// </summary>
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="friendlyName"> A user-provided string that identifies this resource. It is non-unique and can up to
        ///                    255 characters long. </param>
        /// <param name="uniqueName"> A user-provided string that uniquely identifies this resource as an alternative to the
        ///                  sid. Unique up to 64 characters long. </param>
        /// <param name="actions"> A user-provided JSON object encoded as a string to specify the actions for this task. It is
        ///               optional and non-unique. </param>
        /// <param name="actionsUrl"> User-provided HTTP endpoint where from the assistant fetches actions </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Task </returns>
        public static async System.Threading.Tasks.Task<TaskResource> UpdateAsync(string pathAssistantSid,
                                                                                  string pathSid,
                                                                                  string friendlyName = null,
                                                                                  string uniqueName = null,
                                                                                  object actions = null,
                                                                                  Uri actionsUrl = null,
                                                                                  ITwilioRestClient client = null)
        {
            var options = new UpdateTaskOptions(pathAssistantSid, pathSid){FriendlyName = friendlyName, UniqueName = uniqueName, Actions = actions, ActionsUrl = actionsUrl};
            return await UpdateAsync(options, client);
        }
        #endif

        private static Request BuildDeleteRequest(DeleteTaskOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Preview,
                "/understand/Assistants/" + options.PathAssistantSid + "/Tasks/" + options.PathSid + "",
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="options"> Delete Task parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Task </returns>
        public static bool Delete(DeleteTaskOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="options"> Delete Task parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Task </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteTaskOptions options,
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
        /// <returns> A single instance of Task </returns>
        public static bool Delete(string pathAssistantSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteTaskOptions(pathAssistantSid, pathSid);
            return Delete(options, client);
        }

        #if !NET35
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Task </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathAssistantSid,
                                                                          string pathSid,
                                                                          ITwilioRestClient client = null)
        {
            var options = new DeleteTaskOptions(pathAssistantSid, pathSid);
            return await DeleteAsync(options, client);
        }
        #endif

        /// <summary>
        /// Converts a JSON string into a TaskResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TaskResource object represented by the provided JSON </returns>
        public static TaskResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<TaskResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

        /// <summary>
        /// The unique ID of the Account that created this Task.
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
        /// A user-provided string that identifies this resource. It is non-unique and can up to 255 characters long.
        /// </summary>
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        /// <summary>
        /// The links
        /// </summary>
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }
        /// <summary>
        /// The unique ID of the Assistant.
        /// </summary>
        [JsonProperty("assistant_sid")]
        public string AssistantSid { get; private set; }
        /// <summary>
        /// A 34 character string that uniquely identifies this resource.
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// A user-provided string that uniquely identifies this resource as an alternative to the sid. Unique up to 64 characters long.
        /// </summary>
        [JsonProperty("unique_name")]
        public string UniqueName { get; private set; }
        /// <summary>
        /// User-provided HTTP endpoint where from the assistant fetches actions
        /// </summary>
        [JsonProperty("actions_url")]
        public Uri ActionsUrl { get; private set; }
        /// <summary>
        /// The url
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        private TaskResource()
        {

        }
    }

}