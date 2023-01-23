/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Proxy
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



namespace Twilio.Rest.Proxy.V1.Service.Session
{
    public class ParticipantResource : Resource
    {
    

        
        private static Request BuildCreateRequest(CreateParticipantOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Sessions/{SessionSid}/Participants";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathSessionSid = options.PathSessionSid;
            path = path.Replace("{"+"SessionSid"+"}", PathSessionSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Proxy,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Add a new Participant to the Session </summary>
        /// <param name="options"> Create Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns>
        public static ParticipantResource Create(CreateParticipantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Add a new Participant to the Session </summary>
        /// <param name="options"> Create Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Participant </returns>
        public static async System.Threading.Tasks.Task<ParticipantResource> CreateAsync(CreateParticipantOptions options,
        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Add a new Participant to the Session </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) resource. </param>
        /// <param name="pathSessionSid"> The SID of the parent [Session](https://www.twilio.com/docs/proxy/api/session) resource. </param>
        /// <param name="identifier"> The phone number of the Participant. </param>
        /// <param name="friendlyName"> The string that you assigned to describe the participant. This value must be 255 characters or fewer. **This value should not have PII.** </param>
        /// <param name="proxyIdentifier"> The proxy phone number to use for the Participant. If not specified, Proxy will select a number from the pool. </param>
        /// <param name="proxyIdentifierSid"> The SID of the Proxy Identifier to assign to the Participant. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns>
        public static ParticipantResource Create(
                                          string pathServiceSid,
                                          string pathSessionSid,
                                          string identifier,
                                          string friendlyName = null,
                                          string proxyIdentifier = null,
                                          string proxyIdentifierSid = null,
                                          ITwilioRestClient client = null)
        {
            var options = new CreateParticipantOptions(pathServiceSid, pathSessionSid, identifier){  FriendlyName = friendlyName, ProxyIdentifier = proxyIdentifier, ProxyIdentifierSid = proxyIdentifierSid };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Add a new Participant to the Session </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) resource. </param>
        /// <param name="pathSessionSid"> The SID of the parent [Session](https://www.twilio.com/docs/proxy/api/session) resource. </param>
        /// <param name="identifier"> The phone number of the Participant. </param>
        /// <param name="friendlyName"> The string that you assigned to describe the participant. This value must be 255 characters or fewer. **This value should not have PII.** </param>
        /// <param name="proxyIdentifier"> The proxy phone number to use for the Participant. If not specified, Proxy will select a number from the pool. </param>
        /// <param name="proxyIdentifierSid"> The SID of the Proxy Identifier to assign to the Participant. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Participant </returns>
        public static async System.Threading.Tasks.Task<ParticipantResource> CreateAsync(
                                                                                  string pathServiceSid,
                                                                                  string pathSessionSid,
                                                                                  string identifier,
                                                                                  string friendlyName = null,
                                                                                  string proxyIdentifier = null,
                                                                                  string proxyIdentifierSid = null,
                                                                                  ITwilioRestClient client = null)
        {
        var options = new CreateParticipantOptions(pathServiceSid, pathSessionSid, identifier){  FriendlyName = friendlyName, ProxyIdentifier = proxyIdentifier, ProxyIdentifierSid = proxyIdentifierSid };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> Delete a specific Participant. This is a soft-delete. The participant remains associated with the session and cannot be re-added. Participants are only permanently deleted when the [Session](https://www.twilio.com/docs/proxy/api/session) is deleted. </summary>
        /// <param name="options"> Delete Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns>
        private static Request BuildDeleteRequest(DeleteParticipantOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Sessions/{SessionSid}/Participants/{Sid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathSessionSid = options.PathSessionSid;
            path = path.Replace("{"+"SessionSid"+"}", PathSessionSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Proxy,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Delete a specific Participant. This is a soft-delete. The participant remains associated with the session and cannot be re-added. Participants are only permanently deleted when the [Session](https://www.twilio.com/docs/proxy/api/session) is deleted. </summary>
        /// <param name="options"> Delete Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns>
        public static bool Delete(DeleteParticipantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Delete a specific Participant. This is a soft-delete. The participant remains associated with the session and cannot be re-added. Participants are only permanently deleted when the [Session](https://www.twilio.com/docs/proxy/api/session) is deleted. </summary>
        /// <param name="options"> Delete Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Participant </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteParticipantOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Delete a specific Participant. This is a soft-delete. The participant remains associated with the session and cannot be re-added. Participants are only permanently deleted when the [Session](https://www.twilio.com/docs/proxy/api/session) is deleted. </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the resource to delete. </param>
        /// <param name="pathSessionSid"> The SID of the parent [Session](https://www.twilio.com/docs/proxy/api/session) of the resource to delete. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Participant resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns>
        public static bool Delete(string pathServiceSid, string pathSessionSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteParticipantOptions(pathServiceSid, pathSessionSid, pathSid)           ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Delete a specific Participant. This is a soft-delete. The participant remains associated with the session and cannot be re-added. Participants are only permanently deleted when the [Session](https://www.twilio.com/docs/proxy/api/session) is deleted. </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the resource to delete. </param>
        /// <param name="pathSessionSid"> The SID of the parent [Session](https://www.twilio.com/docs/proxy/api/session) of the resource to delete. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Participant resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Participant </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid, string pathSessionSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteParticipantOptions(pathServiceSid, pathSessionSid, pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchParticipantOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Sessions/{SessionSid}/Participants/{Sid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathSessionSid = options.PathSessionSid;
            path = path.Replace("{"+"SessionSid"+"}", PathSessionSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Proxy,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a specific Participant. </summary>
        /// <param name="options"> Fetch Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns>
        public static ParticipantResource Fetch(FetchParticipantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a specific Participant. </summary>
        /// <param name="options"> Fetch Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Participant </returns>
        public static async System.Threading.Tasks.Task<ParticipantResource> FetchAsync(FetchParticipantOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a specific Participant. </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the resource to fetch. </param>
        /// <param name="pathSessionSid"> The SID of the parent [Session](https://www.twilio.com/docs/proxy/api/session) of the resource to fetch. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Participant resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns>
        public static ParticipantResource Fetch(
                                         string pathServiceSid, 
                                         string pathSessionSid, 
                                         string pathSid, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchParticipantOptions(pathServiceSid, pathSessionSid, pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a specific Participant. </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the resource to fetch. </param>
        /// <param name="pathSessionSid"> The SID of the parent [Session](https://www.twilio.com/docs/proxy/api/session) of the resource to fetch. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Participant resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Participant </returns>
        public static async System.Threading.Tasks.Task<ParticipantResource> FetchAsync(string pathServiceSid, string pathSessionSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchParticipantOptions(pathServiceSid, pathSessionSid, pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadParticipantOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{ServiceSid}/Sessions/{SessionSid}/Participants";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathSessionSid = options.PathSessionSid;
            path = path.Replace("{"+"SessionSid"+"}", PathSessionSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Proxy,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of all Participants in a Session. </summary>
        /// <param name="options"> Read Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Participant </returns>
        public static ResourceSet<ParticipantResource> Read(ReadParticipantOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<ParticipantResource>.FromJson("participants", response.Content);
            return new ResourceSet<ParticipantResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Participants in a Session. </summary>
        /// <param name="options"> Read Participant parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Participant </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ParticipantResource>> ReadAsync(ReadParticipantOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<ParticipantResource>.FromJson("participants", response.Content);
            return new ResourceSet<ParticipantResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of all Participants in a Session. </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the resources to read. </param>
        /// <param name="pathSessionSid"> The SID of the parent [Session](https://www.twilio.com/docs/proxy/api/session) of the resources to read. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <param name="limit"> Record limit </param>
        /// <returns> A single instance of Participant </returns>
        public static ResourceSet<ParticipantResource> Read(
                                                     string pathServiceSid,
                                                     string pathSessionSid,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadParticipantOptions(pathServiceSid, pathSessionSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Participants in a Session. </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the resources to read. </param>
        /// <param name="pathSessionSid"> The SID of the parent [Session](https://www.twilio.com/docs/proxy/api/session) of the resources to read. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <param name="limit"> Record limit </param>
        /// <returns> Task that resolves to A single instance of Participant </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ParticipantResource>> ReadAsync(
                                                                                             string pathServiceSid,
                                                                                             string pathSessionSid,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadParticipantOptions(pathServiceSid, pathSessionSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<ParticipantResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<ParticipantResource>.FromJson("participants", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<ParticipantResource> NextPage(Page<ParticipantResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ParticipantResource>.FromJson("participants", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<ParticipantResource> PreviousPage(Page<ParticipantResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ParticipantResource>.FromJson("participants", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a ParticipantResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ParticipantResource object represented by the provided JSON </returns>
        public static ParticipantResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<ParticipantResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> The unique string that we created to identify the Participant resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the parent [Session](https://www.twilio.com/docs/proxy/api/session) resource. </summary> 
        [JsonProperty("session_sid")]
        public string SessionSid { get; private set; }

        ///<summary> The SID of the resource's parent [Service](https://www.twilio.com/docs/proxy/api/service) resource. </summary> 
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Participant resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The string that you assigned to describe the participant. This value must be 255 characters or fewer. Supports UTF-8 characters. **This value should not have PII.** </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> The phone number or channel identifier of the Participant. This value must be 191 characters or fewer. Supports UTF-8 characters. </summary> 
        [JsonProperty("identifier")]
        public string Identifier { get; private set; }

        ///<summary> The phone number or short code (masked number) of the participant's partner. The participant will call or message the partner participant at this number. </summary> 
        [JsonProperty("proxy_identifier")]
        public string ProxyIdentifier { get; private set; }

        ///<summary> The SID of the Proxy Identifier assigned to the Participant. </summary> 
        [JsonProperty("proxy_identifier_sid")]
        public string ProxyIdentifierSid { get; private set; }

        ///<summary> The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date when the Participant was removed from the session. </summary> 
        [JsonProperty("date_deleted")]
        public DateTime? DateDeleted { get; private set; }

        ///<summary> The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time in GMT when the resource was created. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date and time in GMT when the resource was last updated. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The absolute URL of the Participant resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> The URLs to resources related the participant. </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }



        private ParticipantResource() {

        }
    }
}

