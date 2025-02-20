/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Api
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



namespace Twilio.Rest.Api.V2010.Account.Sip.Domain
{
    public class IpAccessControlListMappingResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreateIpAccessControlListMappingOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/SIP/Domains/{DomainSid}/IpAccessControlListMappings.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathDomainSid = options.PathDomainSid;
            path = path.Replace("{"+"DomainSid"+"}", PathDomainSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create a new IpAccessControlListMapping resource. </summary>
        /// <param name="options"> Create IpAccessControlListMapping parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpAccessControlListMapping </returns>
        public static IpAccessControlListMappingResource Create(CreateIpAccessControlListMappingOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a new IpAccessControlListMapping resource. </summary>
        /// <param name="options"> Create IpAccessControlListMapping parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpAccessControlListMapping </returns>
        public static async System.Threading.Tasks.Task<IpAccessControlListMappingResource> CreateAsync(CreateIpAccessControlListMappingOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a new IpAccessControlListMapping resource. </summary>
        /// <param name="pathDomainSid"> A 34 character string that uniquely identifies the SIP domain. </param>
        /// <param name="ipAccessControlListSid"> The unique id of the IP access control list to map to the SIP domain. </param>
        /// <param name="pathAccountSid"> The unique id of the Account that is responsible for this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpAccessControlListMapping </returns>
        public static IpAccessControlListMappingResource Create(
                                          string pathDomainSid,
                                          string ipAccessControlListSid,
                                          string pathAccountSid = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateIpAccessControlListMappingOptions(pathDomainSid, ipAccessControlListSid){  PathAccountSid = pathAccountSid };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a new IpAccessControlListMapping resource. </summary>
        /// <param name="pathDomainSid"> A 34 character string that uniquely identifies the SIP domain. </param>
        /// <param name="ipAccessControlListSid"> The unique id of the IP access control list to map to the SIP domain. </param>
        /// <param name="pathAccountSid"> The unique id of the Account that is responsible for this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpAccessControlListMapping </returns>
        public static async System.Threading.Tasks.Task<IpAccessControlListMappingResource> CreateAsync(
                                                                                  string pathDomainSid,
                                                                                  string ipAccessControlListSid,
                                                                                  string pathAccountSid = null,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateIpAccessControlListMappingOptions(pathDomainSid, ipAccessControlListSid){  PathAccountSid = pathAccountSid };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> Delete an IpAccessControlListMapping resource. </summary>
        /// <param name="options"> Delete IpAccessControlListMapping parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpAccessControlListMapping </returns>
        private static Request BuildDeleteRequest(DeleteIpAccessControlListMappingOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/SIP/Domains/{DomainSid}/IpAccessControlListMappings/{Sid}.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathDomainSid = options.PathDomainSid;
            path = path.Replace("{"+"DomainSid"+"}", PathDomainSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Delete an IpAccessControlListMapping resource. </summary>
        /// <param name="options"> Delete IpAccessControlListMapping parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpAccessControlListMapping </returns>
        public static bool Delete(DeleteIpAccessControlListMappingOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Delete an IpAccessControlListMapping resource. </summary>
        /// <param name="options"> Delete IpAccessControlListMapping parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpAccessControlListMapping </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteIpAccessControlListMappingOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Delete an IpAccessControlListMapping resource. </summary>
        /// <param name="pathDomainSid"> A 34 character string that uniquely identifies the SIP domain. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies the resource to delete. </param>
        /// <param name="pathAccountSid"> The unique id of the Account that is responsible for this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpAccessControlListMapping </returns>
        public static bool Delete(string pathDomainSid, string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteIpAccessControlListMappingOptions(pathDomainSid, pathSid)         { PathAccountSid = pathAccountSid }   ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Delete an IpAccessControlListMapping resource. </summary>
        /// <param name="pathDomainSid"> A 34 character string that uniquely identifies the SIP domain. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies the resource to delete. </param>
        /// <param name="pathAccountSid"> The unique id of the Account that is responsible for this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpAccessControlListMapping </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathDomainSid, string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteIpAccessControlListMappingOptions(pathDomainSid, pathSid)  { PathAccountSid = pathAccountSid };
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchIpAccessControlListMappingOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/SIP/Domains/{DomainSid}/IpAccessControlListMappings/{Sid}.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathDomainSid = options.PathDomainSid;
            path = path.Replace("{"+"DomainSid"+"}", PathDomainSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch an IpAccessControlListMapping resource. </summary>
        /// <param name="options"> Fetch IpAccessControlListMapping parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpAccessControlListMapping </returns>
        public static IpAccessControlListMappingResource Fetch(FetchIpAccessControlListMappingOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch an IpAccessControlListMapping resource. </summary>
        /// <param name="options"> Fetch IpAccessControlListMapping parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpAccessControlListMapping </returns>
        public static async System.Threading.Tasks.Task<IpAccessControlListMappingResource> FetchAsync(FetchIpAccessControlListMappingOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch an IpAccessControlListMapping resource. </summary>
        /// <param name="pathDomainSid"> A 34 character string that uniquely identifies the SIP domain. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies the resource to fetch. </param>
        /// <param name="pathAccountSid"> The unique id of the Account that is responsible for this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpAccessControlListMapping </returns>
        public static IpAccessControlListMappingResource Fetch(
                                         string pathDomainSid, 
                                         string pathSid, 
                                         string pathAccountSid = null, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchIpAccessControlListMappingOptions(pathDomainSid, pathSid){ PathAccountSid = pathAccountSid };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch an IpAccessControlListMapping resource. </summary>
        /// <param name="pathDomainSid"> A 34 character string that uniquely identifies the SIP domain. </param>
        /// <param name="pathSid"> A 34 character string that uniquely identifies the resource to fetch. </param>
        /// <param name="pathAccountSid"> The unique id of the Account that is responsible for this resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpAccessControlListMapping </returns>
        public static async System.Threading.Tasks.Task<IpAccessControlListMappingResource> FetchAsync(string pathDomainSid, string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchIpAccessControlListMappingOptions(pathDomainSid, pathSid){ PathAccountSid = pathAccountSid };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadIpAccessControlListMappingOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/SIP/Domains/{DomainSid}/IpAccessControlListMappings.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathDomainSid = options.PathDomainSid;
            path = path.Replace("{"+"DomainSid"+"}", PathDomainSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of IpAccessControlListMapping resources. </summary>
        /// <param name="options"> Read IpAccessControlListMapping parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpAccessControlListMapping </returns>
        public static ResourceSet<IpAccessControlListMappingResource> Read(ReadIpAccessControlListMappingOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<IpAccessControlListMappingResource>.FromJson("ip_access_control_list_mappings", response.Content);
            return new ResourceSet<IpAccessControlListMappingResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of IpAccessControlListMapping resources. </summary>
        /// <param name="options"> Read IpAccessControlListMapping parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpAccessControlListMapping </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<IpAccessControlListMappingResource>> ReadAsync(ReadIpAccessControlListMappingOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<IpAccessControlListMappingResource>.FromJson("ip_access_control_list_mappings", response.Content);
            return new ResourceSet<IpAccessControlListMappingResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of IpAccessControlListMapping resources. </summary>
        /// <param name="pathDomainSid"> A 34 character string that uniquely identifies the SIP domain. </param>
        /// <param name="pathAccountSid"> The unique id of the Account that is responsible for this resource. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of IpAccessControlListMapping </returns>
        public static ResourceSet<IpAccessControlListMappingResource> Read(
                                                     string pathDomainSid,
                                                     string pathAccountSid = null,
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadIpAccessControlListMappingOptions(pathDomainSid){ PathAccountSid = pathAccountSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of IpAccessControlListMapping resources. </summary>
        /// <param name="pathDomainSid"> A 34 character string that uniquely identifies the SIP domain. </param>
        /// <param name="pathAccountSid"> The unique id of the Account that is responsible for this resource. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of IpAccessControlListMapping </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<IpAccessControlListMappingResource>> ReadAsync(
                                                                                             string pathDomainSid,
                                                                                             string pathAccountSid = null,
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadIpAccessControlListMappingOptions(pathDomainSid){ PathAccountSid = pathAccountSid, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<IpAccessControlListMappingResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<IpAccessControlListMappingResource>.FromJson("ip_access_control_list_mappings", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<IpAccessControlListMappingResource> NextPage(Page<IpAccessControlListMappingResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<IpAccessControlListMappingResource>.FromJson("ip_access_control_list_mappings", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<IpAccessControlListMappingResource> PreviousPage(Page<IpAccessControlListMappingResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<IpAccessControlListMappingResource>.FromJson("ip_access_control_list_mappings", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a IpAccessControlListMappingResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> IpAccessControlListMappingResource object represented by the provided JSON </returns>
        public static IpAccessControlListMappingResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<IpAccessControlListMappingResource>(json);
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

    
        ///<summary> The unique id of the Account that is responsible for this resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The date that this resource was created, given as GMT in [RFC 2822](https://www.php.net/manual/en/class.datetime.php#datetime.constants.rfc2822) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date that this resource was last updated, given as GMT in [RFC 2822](https://www.php.net/manual/en/class.datetime.php#datetime.constants.rfc2822) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The unique string that is created to identify the SipDomain resource. </summary> 
        [JsonProperty("domain_sid")]
        public string DomainSid { get; private set; }

        ///<summary> A human readable descriptive text for this resource, up to 64 characters long. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> A 34 character string that uniquely identifies this resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The URI for this resource, relative to `https://api.twilio.com` </summary> 
        [JsonProperty("uri")]
        public string Uri { get; private set; }



        private IpAccessControlListMappingResource() {

        }
    }
}

