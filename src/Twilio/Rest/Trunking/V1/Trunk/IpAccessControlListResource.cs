/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Trunking
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



namespace Twilio.Rest.Trunking.V1.Trunk
{
    public class IpAccessControlListResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreateIpAccessControlListOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Trunks/{TrunkSid}/IpAccessControlLists";

            string PathTrunkSid = options.PathTrunkSid;
            path = path.Replace("{"+"TrunkSid"+"}", PathTrunkSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Trunking,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Associate an IP Access Control List with a Trunk </summary>
        /// <param name="options"> Create IpAccessControlList parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpAccessControlList </returns>
        public static IpAccessControlListResource Create(CreateIpAccessControlListOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Associate an IP Access Control List with a Trunk </summary>
        /// <param name="options"> Create IpAccessControlList parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpAccessControlList </returns>
        public static async System.Threading.Tasks.Task<IpAccessControlListResource> CreateAsync(CreateIpAccessControlListOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Associate an IP Access Control List with a Trunk </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk to associate the IP Access Control List with. </param>
        /// <param name="ipAccessControlListSid"> The SID of the [IP Access Control List](https://www.twilio.com/docs/voice/sip/api/sip-ipaccesscontrollist-resource) that you want to associate with the trunk. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpAccessControlList </returns>
        public static IpAccessControlListResource Create(
                                          string pathTrunkSid,
                                          string ipAccessControlListSid,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateIpAccessControlListOptions(pathTrunkSid, ipAccessControlListSid){  };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Associate an IP Access Control List with a Trunk </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk to associate the IP Access Control List with. </param>
        /// <param name="ipAccessControlListSid"> The SID of the [IP Access Control List](https://www.twilio.com/docs/voice/sip/api/sip-ipaccesscontrollist-resource) that you want to associate with the trunk. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpAccessControlList </returns>
        public static async System.Threading.Tasks.Task<IpAccessControlListResource> CreateAsync(
                                                                                  string pathTrunkSid,
                                                                                  string ipAccessControlListSid,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateIpAccessControlListOptions(pathTrunkSid, ipAccessControlListSid){  };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> Remove an associated IP Access Control List from a Trunk </summary>
        /// <param name="options"> Delete IpAccessControlList parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpAccessControlList </returns>
        private static Request BuildDeleteRequest(DeleteIpAccessControlListOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Trunks/{TrunkSid}/IpAccessControlLists/{Sid}";

            string PathTrunkSid = options.PathTrunkSid;
            path = path.Replace("{"+"TrunkSid"+"}", PathTrunkSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Trunking,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Remove an associated IP Access Control List from a Trunk </summary>
        /// <param name="options"> Delete IpAccessControlList parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpAccessControlList </returns>
        public static bool Delete(DeleteIpAccessControlListOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Remove an associated IP Access Control List from a Trunk </summary>
        /// <param name="options"> Delete IpAccessControlList parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpAccessControlList </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteIpAccessControlListOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Remove an associated IP Access Control List from a Trunk </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk from which to delete the IP Access Control List. </param>
        /// <param name="pathSid"> The unique string that we created to identify the IpAccessControlList resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpAccessControlList </returns>
        public static bool Delete(string pathTrunkSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteIpAccessControlListOptions(pathTrunkSid, pathSid)        ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Remove an associated IP Access Control List from a Trunk </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk from which to delete the IP Access Control List. </param>
        /// <param name="pathSid"> The unique string that we created to identify the IpAccessControlList resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpAccessControlList </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathTrunkSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteIpAccessControlListOptions(pathTrunkSid, pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchIpAccessControlListOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Trunks/{TrunkSid}/IpAccessControlLists/{Sid}";

            string PathTrunkSid = options.PathTrunkSid;
            path = path.Replace("{"+"TrunkSid"+"}", PathTrunkSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Trunking,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> fetch </summary>
        /// <param name="options"> Fetch IpAccessControlList parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpAccessControlList </returns>
        public static IpAccessControlListResource Fetch(FetchIpAccessControlListOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch IpAccessControlList parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpAccessControlList </returns>
        public static async System.Threading.Tasks.Task<IpAccessControlListResource> FetchAsync(FetchIpAccessControlListOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk from which to fetch the IP Access Control List. </param>
        /// <param name="pathSid"> The unique string that we created to identify the IpAccessControlList resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpAccessControlList </returns>
        public static IpAccessControlListResource Fetch(
                                         string pathTrunkSid, 
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchIpAccessControlListOptions(pathTrunkSid, pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk from which to fetch the IP Access Control List. </param>
        /// <param name="pathSid"> The unique string that we created to identify the IpAccessControlList resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpAccessControlList </returns>
        public static async System.Threading.Tasks.Task<IpAccessControlListResource> FetchAsync(string pathTrunkSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchIpAccessControlListOptions(pathTrunkSid, pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadIpAccessControlListOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Trunks/{TrunkSid}/IpAccessControlLists";

            string PathTrunkSid = options.PathTrunkSid;
            path = path.Replace("{"+"TrunkSid"+"}", PathTrunkSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Trunking,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> List all IP Access Control Lists for a Trunk </summary>
        /// <param name="options"> Read IpAccessControlList parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpAccessControlList </returns>
        public static ResourceSet<IpAccessControlListResource> Read(ReadIpAccessControlListOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<IpAccessControlListResource>.FromJson("ip_access_control_lists", response.Content);
            return new ResourceSet<IpAccessControlListResource>(page, options, client);
        }

        #if !NET35
        /// <summary> List all IP Access Control Lists for a Trunk </summary>
        /// <param name="options"> Read IpAccessControlList parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpAccessControlList </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<IpAccessControlListResource>> ReadAsync(ReadIpAccessControlListOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<IpAccessControlListResource>.FromJson("ip_access_control_lists", response.Content);
            return new ResourceSet<IpAccessControlListResource>(page, options, client);
        }
        #endif
        /// <summary> List all IP Access Control Lists for a Trunk </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk from which to read the IP Access Control Lists. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpAccessControlList </returns>
        public static ResourceSet<IpAccessControlListResource> Read(
                                                     string pathTrunkSid,
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadIpAccessControlListOptions(pathTrunkSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> List all IP Access Control Lists for a Trunk </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk from which to read the IP Access Control Lists. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpAccessControlList </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<IpAccessControlListResource>> ReadAsync(
                                                                                             string pathTrunkSid,
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadIpAccessControlListOptions(pathTrunkSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<IpAccessControlListResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<IpAccessControlListResource>.FromJson("ip_access_control_lists", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<IpAccessControlListResource> NextPage(Page<IpAccessControlListResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<IpAccessControlListResource>.FromJson("ip_access_control_lists", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<IpAccessControlListResource> PreviousPage(Page<IpAccessControlListResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<IpAccessControlListResource>.FromJson("ip_access_control_lists", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a IpAccessControlListResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> IpAccessControlListResource object represented by the provided JSON </returns>
        public static IpAccessControlListResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<IpAccessControlListResource>(json);
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

    
        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the IpAccessControlList resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The unique string that we created to identify the IpAccessControlList resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the Trunk the resource is associated with. </summary> 
        [JsonProperty("trunk_sid")]
        public string TrunkSid { get; private set; }

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



        private IpAccessControlListResource() {

        }
    }
}

