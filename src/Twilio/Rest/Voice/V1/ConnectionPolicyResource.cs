/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Voice
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



namespace Twilio.Rest.Voice.V1
{
    public class ConnectionPolicyResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreateConnectionPolicyOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/ConnectionPolicies";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.Voice,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> create </summary>
        /// <param name="options"> Create ConnectionPolicy parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ConnectionPolicy </returns>
        public static ConnectionPolicyResource Create(CreateConnectionPolicyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="options"> Create ConnectionPolicy parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ConnectionPolicy </returns>
        public static async System.Threading.Tasks.Task<ConnectionPolicyResource> CreateAsync(CreateConnectionPolicyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> create </summary>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It is not unique and can be up to 255 characters long. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ConnectionPolicy </returns>
        public static ConnectionPolicyResource Create(
                                          string friendlyName = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateConnectionPolicyOptions(){  FriendlyName = friendlyName };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It is not unique and can be up to 255 characters long. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ConnectionPolicy </returns>
        public static async System.Threading.Tasks.Task<ConnectionPolicyResource> CreateAsync(
                                                                                  string friendlyName = null,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateConnectionPolicyOptions(){  FriendlyName = friendlyName };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> delete </summary>
        /// <param name="options"> Delete ConnectionPolicy parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ConnectionPolicy </returns>
        private static Request BuildDeleteRequest(DeleteConnectionPolicyOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/ConnectionPolicies/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Voice,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> delete </summary>
        /// <param name="options"> Delete ConnectionPolicy parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ConnectionPolicy </returns>
        public static bool Delete(DeleteConnectionPolicyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="options"> Delete ConnectionPolicy parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ConnectionPolicy </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteConnectionPolicyOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> delete </summary>
        /// <param name="pathSid"> The unique string that we created to identify the Connection Policy resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ConnectionPolicy </returns>
        public static bool Delete(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteConnectionPolicyOptions(pathSid)     ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="pathSid"> The unique string that we created to identify the Connection Policy resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ConnectionPolicy </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteConnectionPolicyOptions(pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchConnectionPolicyOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/ConnectionPolicies/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Voice,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> fetch </summary>
        /// <param name="options"> Fetch ConnectionPolicy parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ConnectionPolicy </returns>
        public static ConnectionPolicyResource Fetch(FetchConnectionPolicyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch ConnectionPolicy parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ConnectionPolicy </returns>
        public static async System.Threading.Tasks.Task<ConnectionPolicyResource> FetchAsync(FetchConnectionPolicyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathSid"> The unique string that we created to identify the Connection Policy resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ConnectionPolicy </returns>
        public static ConnectionPolicyResource Fetch(
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchConnectionPolicyOptions(pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathSid"> The unique string that we created to identify the Connection Policy resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ConnectionPolicy </returns>
        public static async System.Threading.Tasks.Task<ConnectionPolicyResource> FetchAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchConnectionPolicyOptions(pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadConnectionPolicyOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/ConnectionPolicies";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Voice,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> read </summary>
        /// <param name="options"> Read ConnectionPolicy parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ConnectionPolicy </returns>
        public static ResourceSet<ConnectionPolicyResource> Read(ReadConnectionPolicyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<ConnectionPolicyResource>.FromJson("connection_policies", response.Content);
            return new ResourceSet<ConnectionPolicyResource>(page, options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="options"> Read ConnectionPolicy parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ConnectionPolicy </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ConnectionPolicyResource>> ReadAsync(ReadConnectionPolicyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<ConnectionPolicyResource>.FromJson("connection_policies", response.Content);
            return new ResourceSet<ConnectionPolicyResource>(page, options, client);
        }
        #endif
        /// <summary> read </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ConnectionPolicy </returns>
        public static ResourceSet<ConnectionPolicyResource> Read(
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadConnectionPolicyOptions(){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ConnectionPolicy </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ConnectionPolicyResource>> ReadAsync(
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadConnectionPolicyOptions(){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<ConnectionPolicyResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<ConnectionPolicyResource>.FromJson("connection_policies", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<ConnectionPolicyResource> NextPage(Page<ConnectionPolicyResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ConnectionPolicyResource>.FromJson("connection_policies", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<ConnectionPolicyResource> PreviousPage(Page<ConnectionPolicyResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ConnectionPolicyResource>.FromJson("connection_policies", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateConnectionPolicyOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/ConnectionPolicies/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Voice,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> update </summary>
        /// <param name="options"> Update ConnectionPolicy parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ConnectionPolicy </returns>
        public static ConnectionPolicyResource Update(UpdateConnectionPolicyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> update </summary>
        /// <param name="options"> Update ConnectionPolicy parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ConnectionPolicy </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<ConnectionPolicyResource> UpdateAsync(UpdateConnectionPolicyOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> update </summary>
        /// <param name="pathSid"> The unique string that we created to identify the Connection Policy resource to update. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It is not unique and can be up to 255 characters long. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ConnectionPolicy </returns>
        public static ConnectionPolicyResource Update(
                                          string pathSid,
                                          string friendlyName = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateConnectionPolicyOptions(pathSid){ FriendlyName = friendlyName };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> update </summary>
        /// <param name="pathSid"> The unique string that we created to identify the Connection Policy resource to update. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It is not unique and can be up to 255 characters long. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ConnectionPolicy </returns>
        public static async System.Threading.Tasks.Task<ConnectionPolicyResource> UpdateAsync(
                                                                              string pathSid,
                                                                              string friendlyName = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateConnectionPolicyOptions(pathSid){ FriendlyName = friendlyName };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a ConnectionPolicyResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ConnectionPolicyResource object represented by the provided JSON </returns>
        public static ConnectionPolicyResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<ConnectionPolicyResource>(json);
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

    
        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Connection Policy resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The unique string that we created to identify the Connection Policy resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The string that you assigned to describe the resource. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> The date and time in GMT when the resource was created specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the resource was last updated specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The absolute URL of the resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> The URLs of related resources. </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }



        private ConnectionPolicyResource() {

        }
    }
}

