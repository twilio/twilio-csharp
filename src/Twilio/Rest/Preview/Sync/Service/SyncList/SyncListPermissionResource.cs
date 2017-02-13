using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Sync.Service.SyncList 
{

    public class SyncListPermissionResource : Resource 
    {
        private static Request BuildFetchRequest(FetchSyncListPermissionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Lists/" + options.ListSid + "/Permissions/" + options.Identity + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Fetch a specific Sync List Permission.
        /// </summary>
        ///
        /// <param name="options"> Fetch SyncListPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncListPermission </returns> 
        public static SyncListPermissionResource Fetch(FetchSyncListPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        /// <summary>
        /// Fetch a specific Sync List Permission.
        /// </summary>
        ///
        /// <param name="options"> Fetch SyncListPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncListPermission </returns> 
        public static async System.Threading.Tasks.Task<SyncListPermissionResource> FetchAsync(FetchSyncListPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Fetch a specific Sync List Permission.
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="listSid"> Sync List SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync List Permission applies. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncListPermission </returns> 
        public static SyncListPermissionResource Fetch(string serviceSid, string listSid, string identity, ITwilioRestClient client = null)
        {
            var options = new FetchSyncListPermissionOptions(serviceSid, listSid, identity);
            return Fetch(options, client);
        }
    
        #if NET40
        /// <summary>
        /// Fetch a specific Sync List Permission.
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="listSid"> Sync List SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync List Permission applies. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncListPermission </returns> 
        public static async System.Threading.Tasks.Task<SyncListPermissionResource> FetchAsync(string serviceSid, string listSid, string identity, ITwilioRestClient client = null)
        {
            var options = new FetchSyncListPermissionOptions(serviceSid, listSid, identity);
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteSyncListPermissionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Lists/" + options.ListSid + "/Permissions/" + options.Identity + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Delete a specific Sync List Permission.
        /// </summary>
        ///
        /// <param name="options"> Delete SyncListPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncListPermission </returns> 
        public static bool Delete(DeleteSyncListPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        /// <summary>
        /// Delete a specific Sync List Permission.
        /// </summary>
        ///
        /// <param name="options"> Delete SyncListPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncListPermission </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteSyncListPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif
    
        /// <summary>
        /// Delete a specific Sync List Permission.
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="listSid"> Sync List SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync List Permission applies. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncListPermission </returns> 
        public static bool Delete(string serviceSid, string listSid, string identity, ITwilioRestClient client = null)
        {
            var options = new DeleteSyncListPermissionOptions(serviceSid, listSid, identity);
            return Delete(options, client);
        }
    
        #if NET40
        /// <summary>
        /// Delete a specific Sync List Permission.
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="listSid"> Sync List SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync List Permission applies. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncListPermission </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string serviceSid, string listSid, string identity, ITwilioRestClient client = null)
        {
            var options = new DeleteSyncListPermissionOptions(serviceSid, listSid, identity);
            return await DeleteAsync(options, client);
        }
        #endif
    
        private static Request BuildReadRequest(ReadSyncListPermissionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Lists/" + options.ListSid + "/Permissions",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Retrieve a list of all Permissions applying to a Sync List.
        /// </summary>
        ///
        /// <param name="options"> Read SyncListPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncListPermission </returns> 
        public static ResourceSet<SyncListPermissionResource> Read(ReadSyncListPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<SyncListPermissionResource>.FromJson("permissions", response.Content);
            return new ResourceSet<SyncListPermissionResource>(page, options, client);
        }
    
        #if NET40
        /// <summary>
        /// Retrieve a list of all Permissions applying to a Sync List.
        /// </summary>
        ///
        /// <param name="options"> Read SyncListPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncListPermission </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<SyncListPermissionResource>> ReadAsync(ReadSyncListPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<SyncListPermissionResource>.FromJson("permissions", response.Content);
            return new ResourceSet<SyncListPermissionResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// Retrieve a list of all Permissions applying to a Sync List.
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="listSid"> Sync List SID or unique name. </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncListPermission </returns> 
        public static ResourceSet<SyncListPermissionResource> Read(string serviceSid, string listSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadSyncListPermissionOptions(serviceSid, listSid){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        /// <summary>
        /// Retrieve a list of all Permissions applying to a Sync List.
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="listSid"> Sync List SID or unique name. </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncListPermission </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<SyncListPermissionResource>> ReadAsync(string serviceSid, string listSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadSyncListPermissionOptions(serviceSid, listSid){PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns> 
        public static Page<SyncListPermissionResource> NextPage(Page<SyncListPermissionResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Preview,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<SyncListPermissionResource>.FromJson("permissions", response.Content);
        }
    
        private static Request BuildUpdateRequest(UpdateSyncListPermissionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Lists/" + options.ListSid + "/Permissions/" + options.Identity + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Update an identity's access to a specific Sync List.
        /// </summary>
        ///
        /// <param name="options"> Update SyncListPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncListPermission </returns> 
        public static SyncListPermissionResource Update(UpdateSyncListPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        /// <summary>
        /// Update an identity's access to a specific Sync List.
        /// </summary>
        ///
        /// <param name="options"> Update SyncListPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncListPermission </returns> 
        public static async System.Threading.Tasks.Task<SyncListPermissionResource> UpdateAsync(UpdateSyncListPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Update an identity's access to a specific Sync List.
        /// </summary>
        ///
        /// <param name="serviceSid"> Sync Service Instance SID. </param>
        /// <param name="listSid"> Sync List SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync List Permission applies. </param>
        /// <param name="read"> Read access. </param>
        /// <param name="write"> Write access. </param>
        /// <param name="manage"> Manage access. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncListPermission </returns> 
        public static SyncListPermissionResource Update(string serviceSid, string listSid, string identity, bool? read, bool? write, bool? manage, ITwilioRestClient client = null)
        {
            var options = new UpdateSyncListPermissionOptions(serviceSid, listSid, identity, read, write, manage);
            return Update(options, client);
        }
    
        #if NET40
        /// <summary>
        /// Update an identity's access to a specific Sync List.
        /// </summary>
        ///
        /// <param name="serviceSid"> Sync Service Instance SID. </param>
        /// <param name="listSid"> Sync List SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync List Permission applies. </param>
        /// <param name="read"> Read access. </param>
        /// <param name="write"> Write access. </param>
        /// <param name="manage"> Manage access. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncListPermission </returns> 
        public static async System.Threading.Tasks.Task<SyncListPermissionResource> UpdateAsync(string serviceSid, string listSid, string identity, bool? read, bool? write, bool? manage, ITwilioRestClient client = null)
        {
            var options = new UpdateSyncListPermissionOptions(serviceSid, listSid, identity, read, write, manage);
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a SyncListPermissionResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SyncListPermissionResource object represented by the provided JSON </returns> 
        public static SyncListPermissionResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<SyncListPermissionResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        /// <summary>
        /// Twilio Account SID.
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// Sync Service Instance SID.
        /// </summary>
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }
        /// <summary>
        /// Sync List SID.
        /// </summary>
        [JsonProperty("list_sid")]
        public string ListSid { get; private set; }
        /// <summary>
        /// Identity of the user to whom the Sync List Permission applies.
        /// </summary>
        [JsonProperty("identity")]
        public string Identity { get; private set; }
        /// <summary>
        /// Read access.
        /// </summary>
        [JsonProperty("read")]
        public bool? _Read { get; private set; }
        /// <summary>
        /// Write access.
        /// </summary>
        [JsonProperty("write")]
        public bool? Write { get; private set; }
        /// <summary>
        /// Manage access.
        /// </summary>
        [JsonProperty("manage")]
        public bool? Manage { get; private set; }
        /// <summary>
        /// URL of this Sync List Permission.
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private SyncListPermissionResource()
        {
        
        }
    }

}