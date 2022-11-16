/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Preview
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



namespace Twilio.Rest.Preview.Understand.Assistant.Task
{
    public class SampleResource : Resource
    {
    

        
        private static Request BuildCreateRequest(CreateSampleOptions options, ITwilioRestClient client)
        {
            
            string path = "/understand/Assistants/{AssistantSid}/Tasks/{TaskSid}/Samples";

            string PathAssistantSid = options.PathAssistantSid;
            path = path.Replace("{"+"AssistantSid"+"}", PathAssistantSid);
            string PathTaskSid = options.PathTaskSid;
            path = path.Replace("{"+"TaskSid"+"}", PathTaskSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> create </summary>
        /// <param name="options"> Create Sample parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sample </returns>
        public static SampleResource Create(CreateSampleOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="options"> Create Sample parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Sample </returns>
        public static async System.Threading.Tasks.Task<SampleResource> CreateAsync(CreateSampleOptions options,
        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> create </summary>
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="pathTaskSid"> The unique ID of the Task associated with this Sample. </param>
        /// <param name="language"> An ISO language-country string of the sample. </param>
        /// <param name="taggedText"> The text example of how end-users may express this task. The sample may contain Field tag blocks. </param>
        /// <param name="sourceChannel"> The communication channel the sample was captured. It can be: *voice*, *sms*, *chat*, *alexa*, *google-assistant*, or *slack*. If not included the value will be null </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sample </returns>
        public static SampleResource Create(
                                          string pathAssistantSid,
                                          string pathTaskSid,
                                          string language,
                                          string taggedText,
                                          string sourceChannel = null,
                                          ITwilioRestClient client = null)
        {
            var options = new CreateSampleOptions(pathAssistantSid, pathTaskSid, language, taggedText){  SourceChannel = sourceChannel };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="pathTaskSid"> The unique ID of the Task associated with this Sample. </param>
        /// <param name="language"> An ISO language-country string of the sample. </param>
        /// <param name="taggedText"> The text example of how end-users may express this task. The sample may contain Field tag blocks. </param>
        /// <param name="sourceChannel"> The communication channel the sample was captured. It can be: *voice*, *sms*, *chat*, *alexa*, *google-assistant*, or *slack*. If not included the value will be null </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Sample </returns>
        public static async System.Threading.Tasks.Task<SampleResource> CreateAsync(
                                                                                  string pathAssistantSid,
                                                                                  string pathTaskSid,
                                                                                  string language,
                                                                                  string taggedText,
                                                                                  string sourceChannel = null,
                                                                                  ITwilioRestClient client = null)
        {
        var options = new CreateSampleOptions(pathAssistantSid, pathTaskSid, language, taggedText){  SourceChannel = sourceChannel };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> delete </summary>
        /// <param name="options"> Delete Sample parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sample </returns>
        private static Request BuildDeleteRequest(DeleteSampleOptions options, ITwilioRestClient client)
        {
            
            string path = "/understand/Assistants/{AssistantSid}/Tasks/{TaskSid}/Samples/{Sid}";

            string PathAssistantSid = options.PathAssistantSid;
            path = path.Replace("{"+"AssistantSid"+"}", PathAssistantSid);
            string PathTaskSid = options.PathTaskSid;
            path = path.Replace("{"+"TaskSid"+"}", PathTaskSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Preview,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> delete </summary>
        /// <param name="options"> Delete Sample parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sample </returns>
        public static bool Delete(DeleteSampleOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="options"> Delete Sample parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Sample </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteSampleOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> delete </summary>
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="pathTaskSid"> The unique ID of the Task associated with this Sample. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sample </returns>
        public static bool Delete(string pathAssistantSid, string pathTaskSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteSampleOptions(pathAssistantSid, pathTaskSid, pathSid)           ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="pathTaskSid"> The unique ID of the Task associated with this Sample. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Sample </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathAssistantSid, string pathTaskSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteSampleOptions(pathAssistantSid, pathTaskSid, pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchSampleOptions options, ITwilioRestClient client)
        {
            
            string path = "/understand/Assistants/{AssistantSid}/Tasks/{TaskSid}/Samples/{Sid}";

            string PathAssistantSid = options.PathAssistantSid;
            path = path.Replace("{"+"AssistantSid"+"}", PathAssistantSid);
            string PathTaskSid = options.PathTaskSid;
            path = path.Replace("{"+"TaskSid"+"}", PathTaskSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> fetch </summary>
        /// <param name="options"> Fetch Sample parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sample </returns>
        public static SampleResource Fetch(FetchSampleOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch Sample parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Sample </returns>
        public static async System.Threading.Tasks.Task<SampleResource> FetchAsync(FetchSampleOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="pathTaskSid"> The unique ID of the Task associated with this Sample. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sample </returns>
        public static SampleResource Fetch(
                                         string pathAssistantSid, 
                                         string pathTaskSid, 
                                         string pathSid, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchSampleOptions(pathAssistantSid, pathTaskSid, pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="pathTaskSid"> The unique ID of the Task associated with this Sample. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Sample </returns>
        public static async System.Threading.Tasks.Task<SampleResource> FetchAsync(string pathAssistantSid, string pathTaskSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchSampleOptions(pathAssistantSid, pathTaskSid, pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadSampleOptions options, ITwilioRestClient client)
        {
            
            string path = "/understand/Assistants/{AssistantSid}/Tasks/{TaskSid}/Samples";

            string PathAssistantSid = options.PathAssistantSid;
            path = path.Replace("{"+"AssistantSid"+"}", PathAssistantSid);
            string PathTaskSid = options.PathTaskSid;
            path = path.Replace("{"+"TaskSid"+"}", PathTaskSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> read </summary>
        /// <param name="options"> Read Sample parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sample </returns>
        public static ResourceSet<SampleResource> Read(ReadSampleOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<SampleResource>.FromJson("samples", response.Content);
            return new ResourceSet<SampleResource>(page, options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="options"> Read Sample parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Sample </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<SampleResource>> ReadAsync(ReadSampleOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<SampleResource>.FromJson("samples", response.Content);
            return new ResourceSet<SampleResource>(page, options, client);
        }
        #endif
        /// <summary> read </summary>
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="pathTaskSid"> The unique ID of the Task associated with this Sample. </param>
        /// <param name="language"> An ISO language-country string of the sample. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <param name="limit"> Record limit </param>
        /// <returns> A single instance of Sample </returns>
        public static ResourceSet<SampleResource> Read(
                                                     string pathAssistantSid,
                                                     string pathTaskSid,
                                                     string language = null,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadSampleOptions(pathAssistantSid, pathTaskSid){ Language = language, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="pathTaskSid"> The unique ID of the Task associated with this Sample. </param>
        /// <param name="language"> An ISO language-country string of the sample. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <param name="limit"> Record limit </param>
        /// <returns> Task that resolves to A single instance of Sample </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<SampleResource>> ReadAsync(
                                                                                             string pathAssistantSid,
                                                                                             string pathTaskSid,
                                                                                             string language = null,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadSampleOptions(pathAssistantSid, pathTaskSid){ Language = language, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<SampleResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<SampleResource>.FromJson("samples", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<SampleResource> NextPage(Page<SampleResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<SampleResource>.FromJson("samples", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<SampleResource> PreviousPage(Page<SampleResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<SampleResource>.FromJson("samples", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateSampleOptions options, ITwilioRestClient client)
        {
            
            string path = "/understand/Assistants/{AssistantSid}/Tasks/{TaskSid}/Samples/{Sid}";

            string PathAssistantSid = options.PathAssistantSid;
            path = path.Replace("{"+"AssistantSid"+"}", PathAssistantSid);
            string PathTaskSid = options.PathTaskSid;
            path = path.Replace("{"+"TaskSid"+"}", PathTaskSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> update </summary>
        /// <param name="options"> Update Sample parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sample </returns>
        public static SampleResource Update(UpdateSampleOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> update </summary>
        /// <param name="options"> Update Sample parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Sample </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<SampleResource> UpdateAsync(UpdateSampleOptions options,
                                                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> update </summary>
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="pathTaskSid"> The unique ID of the Task associated with this Sample. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="language"> An ISO language-country string of the sample. </param>
        /// <param name="taggedText"> The text example of how end-users may express this task. The sample may contain Field tag blocks. </param>
        /// <param name="sourceChannel"> The communication channel the sample was captured. It can be: *voice*, *sms*, *chat*, *alexa*, *google-assistant*, or *slack*. If not included the value will be null </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Sample </returns>
        public static SampleResource Update(
                                          string pathAssistantSid,
                                          string pathTaskSid,
                                          string pathSid,
                                          string language = null,
                                          string taggedText = null,
                                          string sourceChannel = null,
                                          ITwilioRestClient client = null)
        {
            var options = new UpdateSampleOptions(pathAssistantSid, pathTaskSid, pathSid){ Language = language, TaggedText = taggedText, SourceChannel = sourceChannel };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> update </summary>
        /// <param name="pathAssistantSid"> The unique ID of the Assistant. </param>
        /// <param name="pathTaskSid"> The unique ID of the Task associated with this Sample. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this resource. </param>
        /// <param name="language"> An ISO language-country string of the sample. </param>
        /// <param name="taggedText"> The text example of how end-users may express this task. The sample may contain Field tag blocks. </param>
        /// <param name="sourceChannel"> The communication channel the sample was captured. It can be: *voice*, *sms*, *chat*, *alexa*, *google-assistant*, or *slack*. If not included the value will be null </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Sample </returns>
        public static async System.Threading.Tasks.Task<SampleResource> UpdateAsync(
                                                                              string pathAssistantSid,
                                                                              string pathTaskSid,
                                                                              string pathSid,
                                                                              string language = null,
                                                                              string taggedText = null,
                                                                              string sourceChannel = null,
                                                                              ITwilioRestClient client = null)
        {
            var options = new UpdateSampleOptions(pathAssistantSid, pathTaskSid, pathSid){ Language = language, TaggedText = taggedText, SourceChannel = sourceChannel };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a SampleResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SampleResource object represented by the provided JSON </returns>
        public static SampleResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<SampleResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> The unique ID of the Account that created this Sample. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The date that this resource was created </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date that this resource was last updated </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The unique ID of the Task associated with this Sample. </summary> 
        [JsonProperty("task_sid")]
        public string TaskSid { get; private set; }

        ///<summary> An ISO language-country string of the sample. </summary> 
        [JsonProperty("language")]
        public string Language { get; private set; }

        ///<summary> The unique ID of the Assistant. </summary> 
        [JsonProperty("assistant_sid")]
        public string AssistantSid { get; private set; }

        ///<summary> A 34 character string that uniquely identifies this resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The text example of how end-users may express this task. The sample may contain Field tag blocks. </summary> 
        [JsonProperty("tagged_text")]
        public string TaggedText { get; private set; }

        ///<summary> The url </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> The communication channel the sample was captured. It can be: voice, sms, chat, alexa, google-assistant, or slack. If not included the value will be null </summary> 
        [JsonProperty("source_channel")]
        public string SourceChannel { get; private set; }



        private SampleResource() {

        }
    }
}

