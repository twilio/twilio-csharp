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
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;



namespace Twilio.Rest.Events.V1.Schema
{
    public class SchemaVersionResource : Resource
    {
    

        
        private static Request BuildFetchRequest(FetchSchemaVersionOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Schemas/{Id}/Versions/{SchemaVersion}";

            string PathId = options.PathId;
            path = path.Replace("{"+"Id"+"}", PathId);
            string PathSchemaVersion = options.PathSchemaVersion.ToString();
            path = path.Replace("{"+"SchemaVersion"+"}", PathSchemaVersion);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Events,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a specific schema and version. </summary>
        /// <param name="options"> Fetch SchemaVersion parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SchemaVersion </returns>
        public static SchemaVersionResource Fetch(FetchSchemaVersionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a specific schema and version. </summary>
        /// <param name="options"> Fetch SchemaVersion parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SchemaVersion </returns>
        public static async System.Threading.Tasks.Task<SchemaVersionResource> FetchAsync(FetchSchemaVersionOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a specific schema and version. </summary>
        /// <param name="pathId"> The unique identifier of the schema. Each schema can have multiple versions, that share the same id. </param>
        /// <param name="pathSchemaVersion"> The version of the schema </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SchemaVersion </returns>
        public static SchemaVersionResource Fetch(
                                         string pathId, 
                                         int? pathSchemaVersion, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchSchemaVersionOptions(pathId, pathSchemaVersion){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a specific schema and version. </summary>
        /// <param name="pathId"> The unique identifier of the schema. Each schema can have multiple versions, that share the same id. </param>
        /// <param name="pathSchemaVersion"> The version of the schema </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SchemaVersion </returns>
        public static async System.Threading.Tasks.Task<SchemaVersionResource> FetchAsync(string pathId, int? pathSchemaVersion, ITwilioRestClient client = null)
        {
            var options = new FetchSchemaVersionOptions(pathId, pathSchemaVersion){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadSchemaVersionOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Schemas/{Id}/Versions";

            string PathId = options.PathId;
            path = path.Replace("{"+"Id"+"}", PathId);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Events,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a paginated list of versions of the schema. </summary>
        /// <param name="options"> Read SchemaVersion parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SchemaVersion </returns>
        public static ResourceSet<SchemaVersionResource> Read(ReadSchemaVersionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<SchemaVersionResource>.FromJson("schema_versions", response.Content);
            return new ResourceSet<SchemaVersionResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a paginated list of versions of the schema. </summary>
        /// <param name="options"> Read SchemaVersion parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SchemaVersion </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<SchemaVersionResource>> ReadAsync(ReadSchemaVersionOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<SchemaVersionResource>.FromJson("schema_versions", response.Content);
            return new ResourceSet<SchemaVersionResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a paginated list of versions of the schema. </summary>
        /// <param name="pathId"> The unique identifier of the schema. Each schema can have multiple versions, that share the same id. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <param name="limit"> Record limit </param>
        /// <returns> A single instance of SchemaVersion </returns>
        public static ResourceSet<SchemaVersionResource> Read(
                                                     string pathId,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadSchemaVersionOptions(pathId){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a paginated list of versions of the schema. </summary>
        /// <param name="pathId"> The unique identifier of the schema. Each schema can have multiple versions, that share the same id. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <param name="limit"> Record limit </param>
        /// <returns> Task that resolves to A single instance of SchemaVersion </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<SchemaVersionResource>> ReadAsync(
                                                                                             string pathId,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadSchemaVersionOptions(pathId){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<SchemaVersionResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<SchemaVersionResource>.FromJson("schema_versions", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<SchemaVersionResource> NextPage(Page<SchemaVersionResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<SchemaVersionResource>.FromJson("schema_versions", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<SchemaVersionResource> PreviousPage(Page<SchemaVersionResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<SchemaVersionResource>.FromJson("schema_versions", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a SchemaVersionResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SchemaVersionResource object represented by the provided JSON </returns>
        public static SchemaVersionResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<SchemaVersionResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> The unique identifier of the schema. </summary> 
        [JsonProperty("id")]
        public string Id { get; private set; }

        ///<summary> The version of this schema. </summary> 
        [JsonProperty("schema_version")]
        public int? SchemaVersion { get; private set; }

        ///<summary> The date the schema version was created. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The URL of this resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> The raw </summary> 
        [JsonProperty("raw")]
        public Uri Raw { get; private set; }



        private SchemaVersionResource() {

        }
    }
}

