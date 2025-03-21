/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Verify
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



namespace Twilio.Rest.Verify.V2.Service
{
    public class EntityResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreateEntityOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/Entities";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Verify,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create a new Entity for the Service </summary>
        /// <param name="options"> Create Entity parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Entity </returns>
        public static EntityResource Create(CreateEntityOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a new Entity for the Service </summary>
        /// <param name="options"> Create Entity parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Entity </returns>
        public static async System.Threading.Tasks.Task<EntityResource> CreateAsync(CreateEntityOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a new Entity for the Service </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="identity"> The unique external identifier for the Entity of the Service. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Entity </returns>
        public static EntityResource Create(
                                          string pathServiceSid,
                                          string identity,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateEntityOptions(pathServiceSid, identity){  };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a new Entity for the Service </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="identity"> The unique external identifier for the Entity of the Service. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Entity </returns>
        public static async System.Threading.Tasks.Task<EntityResource> CreateAsync(
                                                                                  string pathServiceSid,
                                                                                  string identity,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateEntityOptions(pathServiceSid, identity){  };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> Delete a specific Entity. </summary>
        /// <param name="options"> Delete Entity parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Entity </returns>
        private static Request BuildDeleteRequest(DeleteEntityOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/Entities/{Identity}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathIdentity = options.PathIdentity;
            path = path.Replace("{"+"Identity"+"}", PathIdentity);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Verify,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Delete a specific Entity. </summary>
        /// <param name="options"> Delete Entity parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Entity </returns>
        public static bool Delete(DeleteEntityOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Delete a specific Entity. </summary>
        /// <param name="options"> Delete Entity parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Entity </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteEntityOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Delete a specific Entity. </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathIdentity"> The unique external identifier for the Entity of the Service. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Entity </returns>
        public static bool Delete(string pathServiceSid, string pathIdentity, ITwilioRestClient client = null)
        {
            var options = new DeleteEntityOptions(pathServiceSid, pathIdentity)        ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Delete a specific Entity. </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathIdentity"> The unique external identifier for the Entity of the Service. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Entity </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid, string pathIdentity, ITwilioRestClient client = null)
        {
            var options = new DeleteEntityOptions(pathServiceSid, pathIdentity) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchEntityOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/Entities/{Identity}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathIdentity = options.PathIdentity;
            path = path.Replace("{"+"Identity"+"}", PathIdentity);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Verify,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a specific Entity. </summary>
        /// <param name="options"> Fetch Entity parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Entity </returns>
        public static EntityResource Fetch(FetchEntityOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a specific Entity. </summary>
        /// <param name="options"> Fetch Entity parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Entity </returns>
        public static async System.Threading.Tasks.Task<EntityResource> FetchAsync(FetchEntityOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a specific Entity. </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathIdentity"> The unique external identifier for the Entity of the Service. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Entity </returns>
        public static EntityResource Fetch(
                                         string pathServiceSid, 
                                         string pathIdentity, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchEntityOptions(pathServiceSid, pathIdentity){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a specific Entity. </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pathIdentity"> The unique external identifier for the Entity of the Service. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Entity </returns>
        public static async System.Threading.Tasks.Task<EntityResource> FetchAsync(string pathServiceSid, string pathIdentity, ITwilioRestClient client = null)
        {
            var options = new FetchEntityOptions(pathServiceSid, pathIdentity){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadEntityOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/Entities";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Verify,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of all Entities for a Service. </summary>
        /// <param name="options"> Read Entity parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Entity </returns>
        public static ResourceSet<EntityResource> Read(ReadEntityOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<EntityResource>.FromJson("entities", response.Content);
            return new ResourceSet<EntityResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Entities for a Service. </summary>
        /// <param name="options"> Read Entity parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Entity </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<EntityResource>> ReadAsync(ReadEntityOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<EntityResource>.FromJson("entities", response.Content);
            return new ResourceSet<EntityResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of all Entities for a Service. </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Entity </returns>
        public static ResourceSet<EntityResource> Read(
                                                     string pathServiceSid,
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadEntityOptions(pathServiceSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Entities for a Service. </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Service. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Entity </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<EntityResource>> ReadAsync(
                                                                                             string pathServiceSid,
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadEntityOptions(pathServiceSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<EntityResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<EntityResource>.FromJson("entities", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<EntityResource> NextPage(Page<EntityResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<EntityResource>.FromJson("entities", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<EntityResource> PreviousPage(Page<EntityResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<EntityResource>.FromJson("entities", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a EntityResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> EntityResource object represented by the provided JSON </returns>
        public static EntityResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<EntityResource>(json);
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

    
        ///<summary> A 34 character string that uniquely identifies this Entity. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The unique external identifier for the Entity of the Service. This identifier should be immutable, not PII, length between 8 and 64 characters, and generated by your external system, such as your user's UUID, GUID, or SID. It can only contain dash (-) separated alphanumeric characters. </summary> 
        [JsonProperty("identity")]
        public string Identity { get; private set; }

        ///<summary> The unique SID identifier of the Account. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The unique SID identifier of the Service. </summary> 
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }

        ///<summary> The date that this Entity was created, given in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date that this Entity was updated, given in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The URL of this resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> Contains a dictionary of URL links to nested resources of this Entity. </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }



        private EntityResource() {

        }
    }
}

