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
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;



namespace Twilio.Rest.Api.V2010.Account.IncomingPhoneNumber
{
    public class AssignedAddOnResource : Resource
    {
    

        
        private static Request BuildCreateRequest(CreateAssignedAddOnOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/IncomingPhoneNumbers/{ResourceSid}/AssignedAddOns.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathResourceSid = options.PathResourceSid;
            path = path.Replace("{"+"ResourceSid"+"}", PathResourceSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Assign an Add-on installation to the Number specified. </summary>
        /// <param name="options"> Create AssignedAddOn parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AssignedAddOn </returns>
        public static AssignedAddOnResource Create(CreateAssignedAddOnOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Assign an Add-on installation to the Number specified. </summary>
        /// <param name="options"> Create AssignedAddOn parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AssignedAddOn </returns>
        public static async System.Threading.Tasks.Task<AssignedAddOnResource> CreateAsync(CreateAssignedAddOnOptions options,
        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Assign an Add-on installation to the Number specified. </summary>
        /// <param name="pathResourceSid"> The SID of the Phone Number to assign the Add-on. </param>
        /// <param name="installedAddOnSid"> The SID that identifies the Add-on installation. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that will create the resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AssignedAddOn </returns>
        public static AssignedAddOnResource Create(
                                          string pathResourceSid,
                                          string installedAddOnSid,
                                          string pathAccountSid = null,
                                          ITwilioRestClient client = null)
        {
            var options = new CreateAssignedAddOnOptions(pathResourceSid, installedAddOnSid){  PathAccountSid = pathAccountSid };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Assign an Add-on installation to the Number specified. </summary>
        /// <param name="pathResourceSid"> The SID of the Phone Number to assign the Add-on. </param>
        /// <param name="installedAddOnSid"> The SID that identifies the Add-on installation. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that will create the resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AssignedAddOn </returns>
        public static async System.Threading.Tasks.Task<AssignedAddOnResource> CreateAsync(
                                                                                  string pathResourceSid,
                                                                                  string installedAddOnSid,
                                                                                  string pathAccountSid = null,
                                                                                  ITwilioRestClient client = null)
        {
        var options = new CreateAssignedAddOnOptions(pathResourceSid, installedAddOnSid){  PathAccountSid = pathAccountSid };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> Remove the assignment of an Add-on installation from the Number specified. </summary>
        /// <param name="options"> Delete AssignedAddOn parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AssignedAddOn </returns>
        private static Request BuildDeleteRequest(DeleteAssignedAddOnOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/IncomingPhoneNumbers/{ResourceSid}/AssignedAddOns/{Sid}.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathResourceSid = options.PathResourceSid;
            path = path.Replace("{"+"ResourceSid"+"}", PathResourceSid);
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

        /// <summary> Remove the assignment of an Add-on installation from the Number specified. </summary>
        /// <param name="options"> Delete AssignedAddOn parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AssignedAddOn </returns>
        public static bool Delete(DeleteAssignedAddOnOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Remove the assignment of an Add-on installation from the Number specified. </summary>
        /// <param name="options"> Delete AssignedAddOn parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AssignedAddOn </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteAssignedAddOnOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Remove the assignment of an Add-on installation from the Number specified. </summary>
        /// <param name="pathResourceSid"> The SID of the Phone Number to which the Add-on is assigned. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the resource to delete. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the resources to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AssignedAddOn </returns>
        public static bool Delete(string pathResourceSid, string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteAssignedAddOnOptions(pathResourceSid, pathSid)         { PathAccountSid = pathAccountSid }   ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Remove the assignment of an Add-on installation from the Number specified. </summary>
        /// <param name="pathResourceSid"> The SID of the Phone Number to which the Add-on is assigned. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the resource to delete. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the resources to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AssignedAddOn </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathResourceSid, string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteAssignedAddOnOptions(pathResourceSid, pathSid)  { PathAccountSid = pathAccountSid };
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchAssignedAddOnOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/IncomingPhoneNumbers/{ResourceSid}/AssignedAddOns/{Sid}.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathResourceSid = options.PathResourceSid;
            path = path.Replace("{"+"ResourceSid"+"}", PathResourceSid);
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

        /// <summary> Fetch an instance of an Add-on installation currently assigned to this Number. </summary>
        /// <param name="options"> Fetch AssignedAddOn parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AssignedAddOn </returns>
        public static AssignedAddOnResource Fetch(FetchAssignedAddOnOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch an instance of an Add-on installation currently assigned to this Number. </summary>
        /// <param name="options"> Fetch AssignedAddOn parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AssignedAddOn </returns>
        public static async System.Threading.Tasks.Task<AssignedAddOnResource> FetchAsync(FetchAssignedAddOnOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch an instance of an Add-on installation currently assigned to this Number. </summary>
        /// <param name="pathResourceSid"> The SID of the Phone Number to which the Add-on is assigned. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the resource to fetch. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AssignedAddOn </returns>
        public static AssignedAddOnResource Fetch(
                                         string pathResourceSid, 
                                         string pathSid, 
                                         string pathAccountSid = null, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchAssignedAddOnOptions(pathResourceSid, pathSid){ PathAccountSid = pathAccountSid };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch an instance of an Add-on installation currently assigned to this Number. </summary>
        /// <param name="pathResourceSid"> The SID of the Phone Number to which the Add-on is assigned. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the resource to fetch. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AssignedAddOn </returns>
        public static async System.Threading.Tasks.Task<AssignedAddOnResource> FetchAsync(string pathResourceSid, string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchAssignedAddOnOptions(pathResourceSid, pathSid){ PathAccountSid = pathAccountSid };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadAssignedAddOnOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/IncomingPhoneNumbers/{ResourceSid}/AssignedAddOns.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathResourceSid = options.PathResourceSid;
            path = path.Replace("{"+"ResourceSid"+"}", PathResourceSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of Add-on installations currently assigned to this Number. </summary>
        /// <param name="options"> Read AssignedAddOn parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AssignedAddOn </returns>
        public static ResourceSet<AssignedAddOnResource> Read(ReadAssignedAddOnOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<AssignedAddOnResource>.FromJson("assigned_add_ons", response.Content);
            return new ResourceSet<AssignedAddOnResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of Add-on installations currently assigned to this Number. </summary>
        /// <param name="options"> Read AssignedAddOn parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AssignedAddOn </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<AssignedAddOnResource>> ReadAsync(ReadAssignedAddOnOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<AssignedAddOnResource>.FromJson("assigned_add_ons", response.Content);
            return new ResourceSet<AssignedAddOnResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of Add-on installations currently assigned to this Number. </summary>
        /// <param name="pathResourceSid"> The SID of the Phone Number to which the Add-on is assigned. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the resources to read. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <param name="limit"> Record limit </param>
        /// <returns> A single instance of AssignedAddOn </returns>
        public static ResourceSet<AssignedAddOnResource> Read(
                                                     string pathResourceSid,
                                                     string pathAccountSid = null,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadAssignedAddOnOptions(pathResourceSid){ PathAccountSid = pathAccountSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of Add-on installations currently assigned to this Number. </summary>
        /// <param name="pathResourceSid"> The SID of the Phone Number to which the Add-on is assigned. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the resources to read. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <param name="limit"> Record limit </param>
        /// <returns> Task that resolves to A single instance of AssignedAddOn </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<AssignedAddOnResource>> ReadAsync(
                                                                                             string pathResourceSid,
                                                                                             string pathAccountSid = null,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadAssignedAddOnOptions(pathResourceSid){ PathAccountSid = pathAccountSid, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<AssignedAddOnResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<AssignedAddOnResource>.FromJson("assigned_add_ons", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<AssignedAddOnResource> NextPage(Page<AssignedAddOnResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<AssignedAddOnResource>.FromJson("assigned_add_ons", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<AssignedAddOnResource> PreviousPage(Page<AssignedAddOnResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<AssignedAddOnResource>.FromJson("assigned_add_ons", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a AssignedAddOnResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AssignedAddOnResource object represented by the provided JSON </returns>
        public static AssignedAddOnResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<AssignedAddOnResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> The unique string that identifies the resource </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the Account that created the resource </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The SID of the Phone Number that installed this Add-on </summary> 
        [JsonProperty("resource_sid")]
        public string ResourceSid { get; private set; }

        ///<summary> The string that you assigned to describe the resource </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> A short description of the Add-on functionality </summary> 
        [JsonProperty("description")]
        public string Description { get; private set; }

        ///<summary> A JSON string that represents the current configuration </summary> 
        [JsonProperty("configuration")]
        public object Configuration { get; private set; }

        ///<summary> An application-defined string that uniquely identifies the resource </summary> 
        [JsonProperty("unique_name")]
        public string UniqueName { get; private set; }

        ///<summary> The RFC 2822 date and time in GMT that the resource was created </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The RFC 2822 date and time in GMT that the resource was last updated </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The URI of the resource, relative to `https://api.twilio.com` </summary> 
        [JsonProperty("uri")]
        public string Uri { get; private set; }

        ///<summary> A list of related resources identified by their relative URIs </summary> 
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> SubresourceUris { get; private set; }



        private AssignedAddOnResource() {

        }
    }
}

