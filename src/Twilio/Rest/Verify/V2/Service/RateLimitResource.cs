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
    public class RateLimitResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreateRateLimitOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/RateLimits";

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

        /// <summary> Create a new Rate Limit for a Service </summary>
        /// <param name="options"> Create RateLimit parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RateLimit </returns>
        public static RateLimitResource Create(CreateRateLimitOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a new Rate Limit for a Service </summary>
        /// <param name="options"> Create RateLimit parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of RateLimit </returns>
        public static async System.Threading.Tasks.Task<RateLimitResource> CreateAsync(CreateRateLimitOptions options, ITwilioRestClient client = null,  System.Threading.CancellationToken cancellationToken = default)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client), cancellationToken);
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a new Rate Limit for a Service </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) the resource is associated with. </param>
        /// <param name="uniqueName"> Provides a unique and addressable name to be assigned to this Rate Limit, assigned by the developer, to be optionally used in addition to SID. **This value should not contain PII.** </param>
        /// <param name="description"> Description of this Rate Limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RateLimit </returns>
        public static RateLimitResource Create(
                                          string pathServiceSid,
                                          string uniqueName,
                                          string description = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateRateLimitOptions(pathServiceSid, uniqueName){  Description = description };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a new Rate Limit for a Service </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) the resource is associated with. </param>
        /// <param name="uniqueName"> Provides a unique and addressable name to be assigned to this Rate Limit, assigned by the developer, to be optionally used in addition to SID. **This value should not contain PII.** </param>
        /// <param name="description"> Description of this Rate Limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of RateLimit </returns>
        public static async System.Threading.Tasks.Task<RateLimitResource> CreateAsync(
                                                                                  string pathServiceSid,
                                                                                  string uniqueName,
                                                                                  string description = null,
                                                                                    ITwilioRestClient client = null , System.Threading.CancellationToken cancellationToken = default)
        {
        var options = new CreateRateLimitOptions(pathServiceSid, uniqueName){  Description = description };
            return await CreateAsync(options, client, cancellationToken);
        }
        #endif
        
        /// <summary> Delete a specific Rate Limit. </summary>
        /// <param name="options"> Delete RateLimit parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RateLimit </returns>
        private static Request BuildDeleteRequest(DeleteRateLimitOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/RateLimits/{Sid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Verify,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Delete a specific Rate Limit. </summary>
        /// <param name="options"> Delete RateLimit parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RateLimit </returns>
        public static bool Delete(DeleteRateLimitOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Delete a specific Rate Limit. </summary>
        /// <param name="options"> Delete RateLimit parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of RateLimit </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteRateLimitOptions options, 
                                                                        ITwilioRestClient client = null,
                                                                        System.Threading.CancellationToken cancellationToken = default)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client), cancellationToken);
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Delete a specific Rate Limit. </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) the resource is associated with. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Rate Limit resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RateLimit </returns>
        public static bool Delete(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteRateLimitOptions(pathServiceSid, pathSid)        ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Delete a specific Rate Limit. </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) the resource is associated with. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Rate Limit resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of RateLimit </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid, string pathSid, ITwilioRestClient client = null , System.Threading.CancellationToken cancellationToken = default)
        {
            var options = new DeleteRateLimitOptions(pathServiceSid, pathSid) ;
            return await DeleteAsync(options, client, cancellationToken);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchRateLimitOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/RateLimits/{Sid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Verify,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a specific Rate Limit. </summary>
        /// <param name="options"> Fetch RateLimit parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RateLimit </returns>
        public static RateLimitResource Fetch(FetchRateLimitOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a specific Rate Limit. </summary>
        /// <param name="options"> Fetch RateLimit parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of RateLimit </returns>
        public static async System.Threading.Tasks.Task<RateLimitResource> FetchAsync(FetchRateLimitOptions options, ITwilioRestClient client = null,  System.Threading.CancellationToken cancellationToken = default)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client), cancellationToken);
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a specific Rate Limit. </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) the resource is associated with. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Rate Limit resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RateLimit </returns>
        public static RateLimitResource Fetch(
                                         string pathServiceSid, 
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchRateLimitOptions(pathServiceSid, pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a specific Rate Limit. </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) the resource is associated with. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Rate Limit resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of RateLimit </returns>
        public static async System.Threading.Tasks.Task<RateLimitResource> FetchAsync(string pathServiceSid, string pathSid, ITwilioRestClient client = null , System.Threading.CancellationToken cancellationToken = default)
        {
            var options = new FetchRateLimitOptions(pathServiceSid, pathSid){  };
            return await FetchAsync(options, client, cancellationToken);
        }
        #endif
        
        private static Request BuildReadRequest(ReadRateLimitOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/RateLimits";

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
        /// <summary> Retrieve a list of all Rate Limits for a service. </summary>
        /// <param name="options"> Read RateLimit parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RateLimit </returns>
        public static ResourceSet<RateLimitResource> Read(ReadRateLimitOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<RateLimitResource>.FromJson("rate_limits", response.Content);
            return new ResourceSet<RateLimitResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Rate Limits for a service. </summary>
        /// <param name="options"> Read RateLimit parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of RateLimit </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<RateLimitResource>> ReadAsync(ReadRateLimitOptions options, ITwilioRestClient client = null,  System.Threading.CancellationToken cancellationToken = default)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client), cancellationToken);

            var page = Page<RateLimitResource>.FromJson("rate_limits", response.Content);
            return new ResourceSet<RateLimitResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of all Rate Limits for a service. </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) the resource is associated with. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RateLimit </returns>
        public static ResourceSet<RateLimitResource> Read(
                                                     string pathServiceSid,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadRateLimitOptions(pathServiceSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Rate Limits for a service. </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) the resource is associated with. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of RateLimit </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<RateLimitResource>> ReadAsync(
                                                                                             string pathServiceSid,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null , System.Threading.CancellationToken cancellationToken = default)
        {
            var options = new ReadRateLimitOptions(pathServiceSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client, cancellationToken);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<RateLimitResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<RateLimitResource>.FromJson("rate_limits", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<RateLimitResource> NextPage(Page<RateLimitResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<RateLimitResource>.FromJson("rate_limits", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<RateLimitResource> PreviousPage(Page<RateLimitResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<RateLimitResource>.FromJson("rate_limits", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateRateLimitOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/RateLimits/{Sid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Verify,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Update a specific Rate Limit. </summary>
        /// <param name="options"> Update RateLimit parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RateLimit </returns>
        public static RateLimitResource Update(UpdateRateLimitOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Update a specific Rate Limit. </summary>
        /// <param name="options"> Update RateLimit parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of RateLimit </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<RateLimitResource> UpdateAsync(UpdateRateLimitOptions options, 
                                                                                                    ITwilioRestClient client = null,
                                                                                                    System.Threading.CancellationToken cancellationToken = default)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client), cancellationToken);
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Update a specific Rate Limit. </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) the resource is associated with. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Rate Limit resource to fetch. </param>
        /// <param name="description"> Description of this Rate Limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of RateLimit </returns>
        public static RateLimitResource Update(
                                          string pathServiceSid,
                                          string pathSid,
                                          string description = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateRateLimitOptions(pathServiceSid, pathSid){ Description = description };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Update a specific Rate Limit. </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) the resource is associated with. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Rate Limit resource to fetch. </param>
        /// <param name="description"> Description of this Rate Limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of RateLimit </returns>
        public static async System.Threading.Tasks.Task<RateLimitResource> UpdateAsync(
                                                                              string pathServiceSid,
                                                                              string pathSid,
                                                                              string description = null,
                                                                                ITwilioRestClient client = null , System.Threading.CancellationToken cancellationToken = default)
        {
            var options = new UpdateRateLimitOptions(pathServiceSid, pathSid){ Description = description };
            return await UpdateAsync(options, client, cancellationToken);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a RateLimitResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> RateLimitResource object represented by the provided JSON </returns>
        public static RateLimitResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<RateLimitResource>(json);
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

    
        ///<summary> A 34 character string that uniquely identifies this Rate Limit. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) the resource is associated with. </summary> 
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Rate Limit resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> Provides a unique and addressable name to be assigned to this Rate Limit, assigned by the developer, to be optionally used in addition to SID. **This value should not contain PII.** </summary> 
        [JsonProperty("unique_name")]
        public string UniqueName { get; private set; }

        ///<summary> Description of this Rate Limit </summary> 
        [JsonProperty("description")]
        public string Description { get; private set; }

        ///<summary> The date and time in GMT when the resource was created specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the resource was last updated specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The URL of this resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> The URLs of related resources. </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }



        private RateLimitResource() {

        }
    }
}

