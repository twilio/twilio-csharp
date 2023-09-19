/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Microvisor
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



namespace Twilio.Rest.Microvisor.V1
{
    public class DeviceResource : Resource
    {
    

    

        
        private static Request BuildFetchRequest(FetchDeviceOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Devices/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Microvisor,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a specific Device. </summary>
        /// <param name="options"> Fetch Device parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Device </returns>
        public static DeviceResource Fetch(FetchDeviceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a specific Device. </summary>
        /// <param name="options"> Fetch Device parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Device </returns>
        public static async System.Threading.Tasks.Task<DeviceResource> FetchAsync(FetchDeviceOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a specific Device. </summary>
        /// <param name="pathSid"> A 34-character string that uniquely identifies this Device. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Device </returns>
        public static DeviceResource Fetch(
                                         string pathSid, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchDeviceOptions(pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a specific Device. </summary>
        /// <param name="pathSid"> A 34-character string that uniquely identifies this Device. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Device </returns>
        public static async System.Threading.Tasks.Task<DeviceResource> FetchAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchDeviceOptions(pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadDeviceOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Devices";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Microvisor,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of all Devices registered with the Account. </summary>
        /// <param name="options"> Read Device parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Device </returns>
        public static ResourceSet<DeviceResource> Read(ReadDeviceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<DeviceResource>.FromJson("devices", response.Content);
            return new ResourceSet<DeviceResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Devices registered with the Account. </summary>
        /// <param name="options"> Read Device parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Device </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<DeviceResource>> ReadAsync(ReadDeviceOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<DeviceResource>.FromJson("devices", response.Content);
            return new ResourceSet<DeviceResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of all Devices registered with the Account. </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Device </returns>
        public static ResourceSet<DeviceResource> Read(
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadDeviceOptions(){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Devices registered with the Account. </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Device </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<DeviceResource>> ReadAsync(
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadDeviceOptions(){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<DeviceResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<DeviceResource>.FromJson("devices", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<DeviceResource> NextPage(Page<DeviceResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<DeviceResource>.FromJson("devices", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<DeviceResource> PreviousPage(Page<DeviceResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<DeviceResource>.FromJson("devices", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateDeviceOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Devices/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Microvisor,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Update a specific Device. </summary>
        /// <param name="options"> Update Device parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Device </returns>
        public static DeviceResource Update(UpdateDeviceOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Update a specific Device. </summary>
        /// <param name="options"> Update Device parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Device </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<DeviceResource> UpdateAsync(UpdateDeviceOptions options,
                                                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Update a specific Device. </summary>
        /// <param name="pathSid"> A 34-character string that uniquely identifies this Device. </param>
        /// <param name="uniqueName"> A unique and addressable name to be assigned to this Device by the developer. It may be used in place of the Device SID. </param>
        /// <param name="targetApp"> The SID or unique name of the App to be targeted to the Device. </param>
        /// <param name="loggingEnabled"> A Boolean flag specifying whether to enable application logging. Logs will be enabled or extended for 24 hours. </param>
        /// <param name="restartApp"> Set to true to restart the App running on the Device. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Device </returns>
        public static DeviceResource Update(
                                          string pathSid,
                                          string uniqueName = null,
                                          string targetApp = null,
                                          bool? loggingEnabled = null,
                                          bool? restartApp = null,
                                          ITwilioRestClient client = null)
        {
            var options = new UpdateDeviceOptions(pathSid){ UniqueName = uniqueName, TargetApp = targetApp, LoggingEnabled = loggingEnabled, RestartApp = restartApp };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Update a specific Device. </summary>
        /// <param name="pathSid"> A 34-character string that uniquely identifies this Device. </param>
        /// <param name="uniqueName"> A unique and addressable name to be assigned to this Device by the developer. It may be used in place of the Device SID. </param>
        /// <param name="targetApp"> The SID or unique name of the App to be targeted to the Device. </param>
        /// <param name="loggingEnabled"> A Boolean flag specifying whether to enable application logging. Logs will be enabled or extended for 24 hours. </param>
        /// <param name="restartApp"> Set to true to restart the App running on the Device. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Device </returns>
        public static async System.Threading.Tasks.Task<DeviceResource> UpdateAsync(
                                                                              string pathSid,
                                                                              string uniqueName = null,
                                                                              string targetApp = null,
                                                                              bool? loggingEnabled = null,
                                                                              bool? restartApp = null,
                                                                              ITwilioRestClient client = null)
        {
            var options = new UpdateDeviceOptions(pathSid){ UniqueName = uniqueName, TargetApp = targetApp, LoggingEnabled = loggingEnabled, RestartApp = restartApp };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a DeviceResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> DeviceResource object represented by the provided JSON </returns>
        public static DeviceResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<DeviceResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> A 34-character string that uniquely identifies this Device. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> A developer-defined string that uniquely identifies the Device. This value must be unique for all Devices on this Account. The `unique_name` value may be used as an alternative to the `sid` in the URL path to address the resource. </summary> 
        [JsonProperty("unique_name")]
        public string UniqueName { get; private set; }

        ///<summary> The unique SID identifier of the Account. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> Information about the target App and the App reported by this Device. Contains the properties `target_sid`, `date_targeted`, `update_status` (one of `up-to-date`, `pending` and `error`), `update_error_code`, `reported_sid` and `date_reported`. </summary> 
        [JsonProperty("app")]
        public object App { get; private set; }

        ///<summary> Object specifying whether application logging is enabled for this Device. Contains the properties `enabled` and `date_expires`. </summary> 
        [JsonProperty("logging")]
        public object Logging { get; private set; }

        ///<summary> The date that this Device was created, given in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date that this Device was last updated, given in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The URL of this resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> The absolute URLs of related resources. </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }



        private DeviceResource() {

        }
    }
}

