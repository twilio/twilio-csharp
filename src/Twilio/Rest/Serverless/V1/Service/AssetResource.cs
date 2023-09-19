/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Serverless
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



namespace Twilio.Rest.Serverless.V1.Service
{
    public class AssetResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreateAssetOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Assets";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Serverless,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create a new Asset resource. </summary>
        /// <param name="options"> Create Asset parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Asset </returns>
        public static AssetResource Create(CreateAssetOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a new Asset resource. </summary>
        /// <param name="options"> Create Asset parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Asset </returns>
        public static async System.Threading.Tasks.Task<AssetResource> CreateAsync(CreateAssetOptions options,
        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a new Asset resource. </summary>
        /// <param name="pathServiceSid"> The SID of the Service to create the Asset resource under. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the Asset resource. It can be a maximum of 255 characters. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Asset </returns>
        public static AssetResource Create(
                                          string pathServiceSid,
                                          string friendlyName,
                                          ITwilioRestClient client = null)
        {
            var options = new CreateAssetOptions(pathServiceSid, friendlyName){  };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a new Asset resource. </summary>
        /// <param name="pathServiceSid"> The SID of the Service to create the Asset resource under. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the Asset resource. It can be a maximum of 255 characters. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Asset </returns>
        public static async System.Threading.Tasks.Task<AssetResource> CreateAsync(
                                                                                  string pathServiceSid,
                                                                                  string friendlyName,
                                                                                  ITwilioRestClient client = null)
        {
        var options = new CreateAssetOptions(pathServiceSid, friendlyName){  };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> Delete an Asset resource. </summary>
        /// <param name="options"> Delete Asset parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Asset </returns>
        private static Request BuildDeleteRequest(DeleteAssetOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Assets/{Sid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Serverless,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Delete an Asset resource. </summary>
        /// <param name="options"> Delete Asset parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Asset </returns>
        public static bool Delete(DeleteAssetOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Delete an Asset resource. </summary>
        /// <param name="options"> Delete Asset parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Asset </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteAssetOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Delete an Asset resource. </summary>
        /// <param name="pathServiceSid"> The SID of the Service to delete the Asset resource from. </param>
        /// <param name="pathSid"> The SID that identifies the Asset resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Asset </returns>
        public static bool Delete(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteAssetOptions(pathServiceSid, pathSid)        ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Delete an Asset resource. </summary>
        /// <param name="pathServiceSid"> The SID of the Service to delete the Asset resource from. </param>
        /// <param name="pathSid"> The SID that identifies the Asset resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Asset </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteAssetOptions(pathServiceSid, pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchAssetOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Assets/{Sid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Serverless,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Retrieve a specific Asset resource. </summary>
        /// <param name="options"> Fetch Asset parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Asset </returns>
        public static AssetResource Fetch(FetchAssetOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Retrieve a specific Asset resource. </summary>
        /// <param name="options"> Fetch Asset parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Asset </returns>
        public static async System.Threading.Tasks.Task<AssetResource> FetchAsync(FetchAssetOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Retrieve a specific Asset resource. </summary>
        /// <param name="pathServiceSid"> The SID of the Service to fetch the Asset resource from. </param>
        /// <param name="pathSid"> The SID that identifies the Asset resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Asset </returns>
        public static AssetResource Fetch(
                                         string pathServiceSid, 
                                         string pathSid, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchAssetOptions(pathServiceSid, pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a specific Asset resource. </summary>
        /// <param name="pathServiceSid"> The SID of the Service to fetch the Asset resource from. </param>
        /// <param name="pathSid"> The SID that identifies the Asset resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Asset </returns>
        public static async System.Threading.Tasks.Task<AssetResource> FetchAsync(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchAssetOptions(pathServiceSid, pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadAssetOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Assets";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Serverless,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of all Assets. </summary>
        /// <param name="options"> Read Asset parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Asset </returns>
        public static ResourceSet<AssetResource> Read(ReadAssetOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<AssetResource>.FromJson("assets", response.Content);
            return new ResourceSet<AssetResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Assets. </summary>
        /// <param name="options"> Read Asset parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Asset </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<AssetResource>> ReadAsync(ReadAssetOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<AssetResource>.FromJson("assets", response.Content);
            return new ResourceSet<AssetResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of all Assets. </summary>
        /// <param name="pathServiceSid"> The SID of the Service to read the Asset resources from. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Asset </returns>
        public static ResourceSet<AssetResource> Read(
                                                     string pathServiceSid,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadAssetOptions(pathServiceSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Assets. </summary>
        /// <param name="pathServiceSid"> The SID of the Service to read the Asset resources from. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Asset </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<AssetResource>> ReadAsync(
                                                                                             string pathServiceSid,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadAssetOptions(pathServiceSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<AssetResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<AssetResource>.FromJson("assets", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<AssetResource> NextPage(Page<AssetResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<AssetResource>.FromJson("assets", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<AssetResource> PreviousPage(Page<AssetResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<AssetResource>.FromJson("assets", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateAssetOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Assets/{Sid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Serverless,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Update a specific Asset resource. </summary>
        /// <param name="options"> Update Asset parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Asset </returns>
        public static AssetResource Update(UpdateAssetOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Update a specific Asset resource. </summary>
        /// <param name="options"> Update Asset parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Asset </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<AssetResource> UpdateAsync(UpdateAssetOptions options,
                                                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Update a specific Asset resource. </summary>
        /// <param name="pathServiceSid"> The SID of the Service to update the Asset resource from. </param>
        /// <param name="pathSid"> The SID that identifies the Asset resource to update. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the Asset resource. It can be a maximum of 255 characters. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Asset </returns>
        public static AssetResource Update(
                                          string pathServiceSid,
                                          string pathSid,
                                          string friendlyName,
                                          ITwilioRestClient client = null)
        {
            var options = new UpdateAssetOptions(pathServiceSid, pathSid, friendlyName){  };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Update a specific Asset resource. </summary>
        /// <param name="pathServiceSid"> The SID of the Service to update the Asset resource from. </param>
        /// <param name="pathSid"> The SID that identifies the Asset resource to update. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the Asset resource. It can be a maximum of 255 characters. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Asset </returns>
        public static async System.Threading.Tasks.Task<AssetResource> UpdateAsync(
                                                                              string pathServiceSid,
                                                                              string pathSid,
                                                                              string friendlyName,
                                                                              ITwilioRestClient client = null)
        {
            var options = new UpdateAssetOptions(pathServiceSid, pathSid, friendlyName){  };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a AssetResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AssetResource object represented by the provided JSON </returns>
        public static AssetResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<AssetResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> The unique string that we created to identify the Asset resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Asset resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The SID of the Service that the Asset resource is associated with. </summary> 
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }

        ///<summary> The string that you assigned to describe the Asset resource. It can be a maximum of 255 characters. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> The date and time in GMT when the Asset resource was created specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the Asset resource was last updated specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The absolute URL of the Asset resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> The URLs of the Asset resource's nested resources. </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }



        private AssetResource() {

        }
    }
}

