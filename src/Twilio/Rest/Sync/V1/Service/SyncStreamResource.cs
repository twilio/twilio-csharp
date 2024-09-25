/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Sync
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





namespace Twilio.Rest.Sync.V1.Service
{
    public class SyncStreamResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreateSyncStreamOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Streams";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Sync,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create a new Stream. </summary>
        /// <param name="options"> Create SyncStream parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncStream </returns>
        public static SyncStreamResource Create(CreateSyncStreamOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a new Stream. </summary>
        /// <param name="options"> Create SyncStream parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncStream </returns>
        public static async System.Threading.Tasks.Task<SyncStreamResource> CreateAsync(CreateSyncStreamOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a new Stream. </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) to create the new Stream in. </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the resource. This value must be unique within its Service and it can be up to 320 characters long. The `unique_name` value can be used as an alternative to the `sid` in the URL path to address the resource. </param>
        /// <param name="ttl"> How long, [in seconds](https://www.twilio.com/docs/sync/limits#sync-payload-limits), before the Stream expires and is deleted (time-to-live). </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncStream </returns>
        public static SyncStreamResource Create(
                                          string pathServiceSid,
                                          string uniqueName = null,
                                          int? ttl = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateSyncStreamOptions(pathServiceSid){  UniqueName = uniqueName, Ttl = ttl };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a new Stream. </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) to create the new Stream in. </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the resource. This value must be unique within its Service and it can be up to 320 characters long. The `unique_name` value can be used as an alternative to the `sid` in the URL path to address the resource. </param>
        /// <param name="ttl"> How long, [in seconds](https://www.twilio.com/docs/sync/limits#sync-payload-limits), before the Stream expires and is deleted (time-to-live). </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncStream </returns>
        public static async System.Threading.Tasks.Task<SyncStreamResource> CreateAsync(
                                                                                  string pathServiceSid,
                                                                                  string uniqueName = null,
                                                                                  int? ttl = null,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateSyncStreamOptions(pathServiceSid){  UniqueName = uniqueName, Ttl = ttl };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> Delete a specific Stream. </summary>
        /// <param name="options"> Delete SyncStream parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncStream </returns>
        private static Request BuildDeleteRequest(DeleteSyncStreamOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Streams/{Sid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Sync,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Delete a specific Stream. </summary>
        /// <param name="options"> Delete SyncStream parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncStream </returns>
        public static bool Delete(DeleteSyncStreamOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Delete a specific Stream. </summary>
        /// <param name="options"> Delete SyncStream parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncStream </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteSyncStreamOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Delete a specific Stream. </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Sync Stream resource to delete. </param>
        /// <param name="pathSid"> The SID of the Stream resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncStream </returns>
        public static bool Delete(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteSyncStreamOptions(pathServiceSid, pathSid)        ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Delete a specific Stream. </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Sync Stream resource to delete. </param>
        /// <param name="pathSid"> The SID of the Stream resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncStream </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteSyncStreamOptions(pathServiceSid, pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchSyncStreamOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Streams/{Sid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Sync,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a specific Stream. </summary>
        /// <param name="options"> Fetch SyncStream parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncStream </returns>
        public static SyncStreamResource Fetch(FetchSyncStreamOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a specific Stream. </summary>
        /// <param name="options"> Fetch SyncStream parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncStream </returns>
        public static async System.Threading.Tasks.Task<SyncStreamResource> FetchAsync(FetchSyncStreamOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a specific Stream. </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Sync Stream resource to fetch. </param>
        /// <param name="pathSid"> The SID of the Stream resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncStream </returns>
        public static SyncStreamResource Fetch(
                                         string pathServiceSid, 
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchSyncStreamOptions(pathServiceSid, pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a specific Stream. </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Sync Stream resource to fetch. </param>
        /// <param name="pathSid"> The SID of the Stream resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncStream </returns>
        public static async System.Threading.Tasks.Task<SyncStreamResource> FetchAsync(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchSyncStreamOptions(pathServiceSid, pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadSyncStreamOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Streams";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Sync,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of all Streams in a Service Instance. </summary>
        /// <param name="options"> Read SyncStream parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncStream </returns>
        public static ResourceSet<SyncStreamResource> Read(ReadSyncStreamOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<SyncStreamResource>.FromJson("streams", response.Content);
            return new ResourceSet<SyncStreamResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Streams in a Service Instance. </summary>
        /// <param name="options"> Read SyncStream parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncStream </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<SyncStreamResource>> ReadAsync(ReadSyncStreamOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<SyncStreamResource>.FromJson("streams", response.Content);
            return new ResourceSet<SyncStreamResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of all Streams in a Service Instance. </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Stream resources to read. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncStream </returns>
        public static ResourceSet<SyncStreamResource> Read(
                                                     string pathServiceSid,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadSyncStreamOptions(pathServiceSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Streams in a Service Instance. </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Stream resources to read. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncStream </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<SyncStreamResource>> ReadAsync(
                                                                                             string pathServiceSid,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadSyncStreamOptions(pathServiceSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<SyncStreamResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<SyncStreamResource>.FromJson("streams", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<SyncStreamResource> NextPage(Page<SyncStreamResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<SyncStreamResource>.FromJson("streams", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<SyncStreamResource> PreviousPage(Page<SyncStreamResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<SyncStreamResource>.FromJson("streams", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateSyncStreamOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Streams/{Sid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Sync,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Update a specific Stream. </summary>
        /// <param name="options"> Update SyncStream parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncStream </returns>
        public static SyncStreamResource Update(UpdateSyncStreamOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Update a specific Stream. </summary>
        /// <param name="options"> Update SyncStream parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncStream </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<SyncStreamResource> UpdateAsync(UpdateSyncStreamOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Update a specific Stream. </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Sync Stream resource to update. </param>
        /// <param name="pathSid"> The SID of the Stream resource to update. </param>
        /// <param name="ttl"> How long, [in seconds](https://www.twilio.com/docs/sync/limits#sync-payload-limits), before the Stream expires and is deleted (time-to-live). </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncStream </returns>
        public static SyncStreamResource Update(
                                          string pathServiceSid,
                                          string pathSid,
                                          int? ttl = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateSyncStreamOptions(pathServiceSid, pathSid){ Ttl = ttl };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Update a specific Stream. </summary>
        /// <param name="pathServiceSid"> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) with the Sync Stream resource to update. </param>
        /// <param name="pathSid"> The SID of the Stream resource to update. </param>
        /// <param name="ttl"> How long, [in seconds](https://www.twilio.com/docs/sync/limits#sync-payload-limits), before the Stream expires and is deleted (time-to-live). </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncStream </returns>
        public static async System.Threading.Tasks.Task<SyncStreamResource> UpdateAsync(
                                                                              string pathServiceSid,
                                                                              string pathSid,
                                                                              int? ttl = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateSyncStreamOptions(pathServiceSid, pathSid){ Ttl = ttl };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a SyncStreamResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SyncStreamResource object represented by the provided JSON </returns>
        public static SyncStreamResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<SyncStreamResource>(json);
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

    
        ///<summary> The unique string that we created to identify the Sync Stream resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> An application-defined string that uniquely identifies the resource. It can be used in place of the resource's `sid` in the URL to address the resource. </summary> 
        [JsonProperty("unique_name")]
        public string UniqueName { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Sync Stream resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The SID of the [Sync Service](https://www.twilio.com/docs/sync/api/service) the resource is associated with. </summary> 
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }

        ///<summary> The absolute URL of the Message Stream resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> The URLs of the Stream's nested resources. </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }

        ///<summary> The date and time in GMT when the Message Stream expires and will be deleted, specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. If the Message Stream does not expire, this value is `null`. The Stream might not be deleted immediately after it expires. </summary> 
        [JsonProperty("date_expires")]
        public DateTime? DateExpires { get; private set; }

        ///<summary> The date and time in GMT when the resource was created specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the resource was last updated specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The identity of the Stream's creator. If the Stream is created from the client SDK, the value matches the Access Token's `identity` field. If the Stream was created from the REST API, the value is 'system'. </summary> 
        [JsonProperty("created_by")]
        public string CreatedBy { get; private set; }



        private SyncStreamResource() {

        }
    }
}

