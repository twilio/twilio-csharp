/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Bulkexports
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



namespace Twilio.Rest.Bulkexports.V1.Export
{
    public class ExportCustomJobResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreateExportCustomJobOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Exports/{ResourceType}/Jobs";

            string PathResourceType = options.PathResourceType;
            path = path.Replace("{"+"ResourceType"+"}", PathResourceType);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Bulkexports,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> create </summary>
        /// <param name="options"> Create ExportCustomJob parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ExportCustomJob </returns>
        public static ExportCustomJobResource Create(CreateExportCustomJobOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="options"> Create ExportCustomJob parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ExportCustomJob </returns>
        public static async System.Threading.Tasks.Task<ExportCustomJobResource> CreateAsync(CreateExportCustomJobOptions options, ITwilioRestClient client = null,  System.Threading.CancellationToken cancellationToken = default)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client), cancellationToken);
            return FromJson(response.Content);
        }
        #endif

        /// <summary> create </summary>
        /// <param name="pathResourceType"> The type of communication – Messages or Calls, Conferences, and Participants </param>
        /// <param name="startDay"> The start day for the custom export specified as a string in the format of yyyy-mm-dd </param>
        /// <param name="endDay"> The end day for the custom export specified as a string in the format of yyyy-mm-dd. End day is inclusive and must be 2 days earlier than the current UTC day. </param>
        /// <param name="friendlyName"> The friendly name specified when creating the job </param>
        /// <param name="webhookUrl"> The optional webhook url called on completion of the job. If this is supplied, `WebhookMethod` must also be supplied. If you set neither webhook nor email, you will have to check your job's status manually. </param>
        /// <param name="webhookMethod"> This is the method used to call the webhook on completion of the job. If this is supplied, `WebhookUrl` must also be supplied. </param>
        /// <param name="email"> The optional email to send the completion notification to. You can set both webhook, and email, or one or the other. If you set neither, the job will run but you will have to query to determine your job's status. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ExportCustomJob </returns>
        public static ExportCustomJobResource Create(
                                          string pathResourceType,
                                          string startDay,
                                          string endDay,
                                          string friendlyName,
                                          string webhookUrl = null,
                                          string webhookMethod = null,
                                          string email = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateExportCustomJobOptions(pathResourceType, startDay, endDay, friendlyName){  WebhookUrl = webhookUrl, WebhookMethod = webhookMethod, Email = email };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="pathResourceType"> The type of communication – Messages or Calls, Conferences, and Participants </param>
        /// <param name="startDay"> The start day for the custom export specified as a string in the format of yyyy-mm-dd </param>
        /// <param name="endDay"> The end day for the custom export specified as a string in the format of yyyy-mm-dd. End day is inclusive and must be 2 days earlier than the current UTC day. </param>
        /// <param name="friendlyName"> The friendly name specified when creating the job </param>
        /// <param name="webhookUrl"> The optional webhook url called on completion of the job. If this is supplied, `WebhookMethod` must also be supplied. If you set neither webhook nor email, you will have to check your job's status manually. </param>
        /// <param name="webhookMethod"> This is the method used to call the webhook on completion of the job. If this is supplied, `WebhookUrl` must also be supplied. </param>
        /// <param name="email"> The optional email to send the completion notification to. You can set both webhook, and email, or one or the other. If you set neither, the job will run but you will have to query to determine your job's status. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ExportCustomJob </returns>
        public static async System.Threading.Tasks.Task<ExportCustomJobResource> CreateAsync(
                                                                                  string pathResourceType,
                                                                                  string startDay,
                                                                                  string endDay,
                                                                                  string friendlyName,
                                                                                  string webhookUrl = null,
                                                                                  string webhookMethod = null,
                                                                                  string email = null,
                                                                                    ITwilioRestClient client = null , System.Threading.CancellationToken cancellationToken = default)
        {
        var options = new CreateExportCustomJobOptions(pathResourceType, startDay, endDay, friendlyName){  WebhookUrl = webhookUrl, WebhookMethod = webhookMethod, Email = email };
            return await CreateAsync(options, client, cancellationToken);
        }
        #endif
        
        private static Request BuildReadRequest(ReadExportCustomJobOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Exports/{ResourceType}/Jobs";

            string PathResourceType = options.PathResourceType;
            path = path.Replace("{"+"ResourceType"+"}", PathResourceType);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Bulkexports,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> read </summary>
        /// <param name="options"> Read ExportCustomJob parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ExportCustomJob </returns>
        public static ResourceSet<ExportCustomJobResource> Read(ReadExportCustomJobOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<ExportCustomJobResource>.FromJson("jobs", response.Content);
            return new ResourceSet<ExportCustomJobResource>(page, options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="options"> Read ExportCustomJob parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ExportCustomJob </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ExportCustomJobResource>> ReadAsync(ReadExportCustomJobOptions options, ITwilioRestClient client = null,  System.Threading.CancellationToken cancellationToken = default)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client), cancellationToken);

            var page = Page<ExportCustomJobResource>.FromJson("jobs", response.Content);
            return new ResourceSet<ExportCustomJobResource>(page, options, client);
        }
        #endif
        /// <summary> read </summary>
        /// <param name="pathResourceType"> The type of communication – Messages, Calls, Conferences, and Participants </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ExportCustomJob </returns>
        public static ResourceSet<ExportCustomJobResource> Read(
                                                     string pathResourceType,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadExportCustomJobOptions(pathResourceType){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="pathResourceType"> The type of communication – Messages, Calls, Conferences, and Participants </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ExportCustomJob </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ExportCustomJobResource>> ReadAsync(
                                                                                             string pathResourceType,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null , System.Threading.CancellationToken cancellationToken = default)
        {
            var options = new ReadExportCustomJobOptions(pathResourceType){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client, cancellationToken);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<ExportCustomJobResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<ExportCustomJobResource>.FromJson("jobs", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<ExportCustomJobResource> NextPage(Page<ExportCustomJobResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ExportCustomJobResource>.FromJson("jobs", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<ExportCustomJobResource> PreviousPage(Page<ExportCustomJobResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ExportCustomJobResource>.FromJson("jobs", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a ExportCustomJobResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ExportCustomJobResource object represented by the provided JSON </returns>
        public static ExportCustomJobResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<ExportCustomJobResource>(json);
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

    
        ///<summary> The friendly name specified when creating the job </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> The type of communication – Messages, Calls, Conferences, and Participants </summary> 
        [JsonProperty("resource_type")]
        public string ResourceType { get; private set; }

        ///<summary> The start day for the custom export specified when creating the job </summary> 
        [JsonProperty("start_day")]
        public string StartDay { get; private set; }

        ///<summary> The end day for the export specified when creating the job </summary> 
        [JsonProperty("end_day")]
        public string EndDay { get; private set; }

        ///<summary> The optional webhook url called on completion of the job. If this is supplied, `WebhookMethod` must also be supplied. </summary> 
        [JsonProperty("webhook_url")]
        public string WebhookUrl { get; private set; }

        ///<summary> This is the method used to call the webhook on completion of the job. If this is supplied, `WebhookUrl` must also be supplied. </summary> 
        [JsonProperty("webhook_method")]
        public string WebhookMethod { get; private set; }

        ///<summary> The optional email to send the completion notification to </summary> 
        [JsonProperty("email")]
        public string Email { get; private set; }

        ///<summary> The unique job_sid returned when the custom export was created </summary> 
        [JsonProperty("job_sid")]
        public string JobSid { get; private set; }

        ///<summary> The details of a job which is an object that contains an array of status grouped by `status` state.  Each `status` object has a `status` string, a count which is the number of days in that `status`, and list of days in that `status`. The day strings are in the format yyyy-MM-dd. As an example, a currently running job may have a status object for COMPLETED and a `status` object for SUBMITTED each with its own count and list of days. </summary> 
        [JsonProperty("details")]
        public object Details { get; private set; }

        ///<summary> This is the job position from the 1st in line. Your queue position will never increase. As jobs ahead of yours in the queue are processed, the queue position number will decrease </summary> 
        [JsonProperty("job_queue_position")]
        public string JobQueuePosition { get; private set; }

        ///<summary> this is the time estimated until your job is complete. This is calculated each time you request the job list. The time is calculated based on the current rate of job completion (which may vary) and your job queue position </summary> 
        [JsonProperty("estimated_completion_time")]
        public string EstimatedCompletionTime { get; private set; }



        private ExportCustomJobResource() {

        }
    }
}

