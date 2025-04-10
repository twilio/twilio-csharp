/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Events
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



namespace Twilio.Rest.Events.V1
{
    public class EventTypeResource : Resource
    {
    

    

        
        private static Request BuildFetchRequest(FetchEventTypeOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Types/{Type}";

            string PathType = options.PathType;
            path = path.Replace("{"+"Type"+"}", PathType);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Events,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a specific Event Type. </summary>
        /// <param name="options"> Fetch EventType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of EventType </returns>
        public static EventTypeResource Fetch(FetchEventTypeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a specific Event Type. </summary>
        /// <param name="options"> Fetch EventType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of EventType </returns>
        public static async System.Threading.Tasks.Task<EventTypeResource> FetchAsync(FetchEventTypeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a specific Event Type. </summary>
        /// <param name="pathType"> A string that uniquely identifies this Event Type. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of EventType </returns>
        public static EventTypeResource Fetch(
                                         string pathType, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchEventTypeOptions(pathType){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a specific Event Type. </summary>
        /// <param name="pathType"> A string that uniquely identifies this Event Type. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of EventType </returns>
        public static async System.Threading.Tasks.Task<EventTypeResource> FetchAsync(string pathType, ITwilioRestClient client = null)
        {
            var options = new FetchEventTypeOptions(pathType){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadEventTypeOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Types";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Events,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a paginated list of all the available Event Types. </summary>
        /// <param name="options"> Read EventType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of EventType </returns>
        public static ResourceSet<EventTypeResource> Read(ReadEventTypeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<EventTypeResource>.FromJson("types", response.Content);
            return new ResourceSet<EventTypeResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a paginated list of all the available Event Types. </summary>
        /// <param name="options"> Read EventType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of EventType </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<EventTypeResource>> ReadAsync(ReadEventTypeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<EventTypeResource>.FromJson("types", response.Content);
            return new ResourceSet<EventTypeResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a paginated list of all the available Event Types. </summary>
        /// <param name="schemaId"> A string parameter filtering the results to return only the Event Types using a given schema. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of EventType </returns>
        public static ResourceSet<EventTypeResource> Read(
                                                     string schemaId = null,
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadEventTypeOptions(){ SchemaId = schemaId, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a paginated list of all the available Event Types. </summary>
        /// <param name="schemaId"> A string parameter filtering the results to return only the Event Types using a given schema. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of EventType </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<EventTypeResource>> ReadAsync(
                                                                                             string schemaId = null,
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadEventTypeOptions(){ SchemaId = schemaId, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<EventTypeResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<EventTypeResource>.FromJson("types", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<EventTypeResource> NextPage(Page<EventTypeResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<EventTypeResource>.FromJson("types", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<EventTypeResource> PreviousPage(Page<EventTypeResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<EventTypeResource>.FromJson("types", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a EventTypeResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> EventTypeResource object represented by the provided JSON </returns>
        public static EventTypeResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<EventTypeResource>(json);
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

    
        ///<summary> A string that uniquely identifies this Event Type. </summary> 
        [JsonProperty("type")]
        public string Type { get; private set; }

        ///<summary> A string that uniquely identifies the Schema this Event Type adheres to. </summary> 
        [JsonProperty("schema_id")]
        public string SchemaId { get; private set; }

        ///<summary> The date that this Event Type was created, given in ISO 8601 format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date that this Event Type was updated, given in ISO 8601 format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> A human readable description for this Event Type. </summary> 
        [JsonProperty("description")]
        public string Description { get; private set; }

        ///<summary> A string that describes how this Event Type can be used. For example: `available`, `deprecated`, `restricted`, `discontinued`. When the status is `available`, the Event Type can be used normally. </summary> 
        [JsonProperty("status")]
        public string Status { get; private set; }

        ///<summary> The URL to the documentation or to the most relevant Twilio Changelog entry of this Event Type. </summary> 
        [JsonProperty("documentation_url")]
        public string DocumentationUrl { get; private set; }

        ///<summary> The URL of this resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> The links </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }



        private EventTypeResource() {

        }
    }
}

