using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Sync.Service.SyncMap 
{

    /// <summary>
    /// SyncMapPermissionResource
    /// </summary>
    public class SyncMapPermissionResource : Resource 
    {
        private static Request BuildFetchRequest(FetchSyncMapPermissionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Maps/" + options.MapSid + "/Permissions/" + options.Identity + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Fetch a specific Sync Map Permission.
        /// </summary>
        ///
        /// <param name="options"> Fetch SyncMapPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncMapPermission </returns> 
        public static SyncMapPermissionResource Fetch(FetchSyncMapPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if !NET35
        /// <summary>
        /// Fetch a specific Sync Map Permission.
        /// </summary>
        ///
        /// <param name="options"> Fetch SyncMapPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncMapPermission </returns> 
        public static async System.Threading.Tasks.Task<SyncMapPermissionResource> FetchAsync(FetchSyncMapPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Fetch a specific Sync Map Permission.
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> Sync Map SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync Map Permission applies. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncMapPermission </returns> 
        public static SyncMapPermissionResource Fetch(string serviceSid, string mapSid, string identity, ITwilioRestClient client = null)
        {
            var options = new FetchSyncMapPermissionOptions(serviceSid, mapSid, identity);
            return Fetch(options, client);
        }
    
        #if !NET35
        /// <summary>
        /// Fetch a specific Sync Map Permission.
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> Sync Map SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync Map Permission applies. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncMapPermission </returns> 
        public static async System.Threading.Tasks.Task<SyncMapPermissionResource> FetchAsync(string serviceSid, string mapSid, string identity, ITwilioRestClient client = null)
        {
            var options = new FetchSyncMapPermissionOptions(serviceSid, mapSid, identity);
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteSyncMapPermissionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Maps/" + options.MapSid + "/Permissions/" + options.Identity + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Delete a specific Sync Map Permission.
        /// </summary>
        ///
        /// <param name="options"> Delete SyncMapPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncMapPermission </returns> 
        public static bool Delete(DeleteSyncMapPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if !NET35
        /// <summary>
        /// Delete a specific Sync Map Permission.
        /// </summary>
        ///
        /// <param name="options"> Delete SyncMapPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncMapPermission </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteSyncMapPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif
    
        /// <summary>
        /// Delete a specific Sync Map Permission.
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> Sync Map SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync Map Permission applies. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncMapPermission </returns> 
        public static bool Delete(string serviceSid, string mapSid, string identity, ITwilioRestClient client = null)
        {
            var options = new DeleteSyncMapPermissionOptions(serviceSid, mapSid, identity);
            return Delete(options, client);
        }
    
        #if !NET35
        /// <summary>
        /// Delete a specific Sync Map Permission.
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> Sync Map SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync Map Permission applies. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncMapPermission </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string serviceSid, string mapSid, string identity, ITwilioRestClient client = null)
        {
            var options = new DeleteSyncMapPermissionOptions(serviceSid, mapSid, identity);
            return await DeleteAsync(options, client);
        }
        #endif
    
        private static Request BuildReadRequest(ReadSyncMapPermissionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Maps/" + options.MapSid + "/Permissions",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Retrieve a list of all Permissions applying to a Sync Map.
        /// </summary>
        ///
        /// <param name="options"> Read SyncMapPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncMapPermission </returns> 
        public static ResourceSet<SyncMapPermissionResource> Read(ReadSyncMapPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<SyncMapPermissionResource>.FromJson("permissions", response.Content);
            return new ResourceSet<SyncMapPermissionResource>(page, options, client);
        }
    
        #if !NET35
        /// <summary>
        /// Retrieve a list of all Permissions applying to a Sync Map.
        /// </summary>
        ///
        /// <param name="options"> Read SyncMapPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncMapPermission </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<SyncMapPermissionResource>> ReadAsync(ReadSyncMapPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<SyncMapPermissionResource>.FromJson("permissions", response.Content);
            return new ResourceSet<SyncMapPermissionResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// Retrieve a list of all Permissions applying to a Sync Map.
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> Sync Map SID or unique name. </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncMapPermission </returns> 
        public static ResourceSet<SyncMapPermissionResource> Read(string serviceSid, string mapSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadSyncMapPermissionOptions(serviceSid, mapSid){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if !NET35
        /// <summary>
        /// Retrieve a list of all Permissions applying to a Sync Map.
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="mapSid"> Sync Map SID or unique name. </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncMapPermission </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<SyncMapPermissionResource>> ReadAsync(string serviceSid, string mapSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadSyncMapPermissionOptions(serviceSid, mapSid){PageSize = pageSize, Limit = limit};
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
        public static Page<SyncMapPermissionResource> NextPage(Page<SyncMapPermissionResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Preview,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<SyncMapPermissionResource>.FromJson("permissions", response.Content);
        }
    
        private static Request BuildUpdateRequest(UpdateSyncMapPermissionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Maps/" + options.MapSid + "/Permissions/" + options.Identity + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Update an identity's access to a specific Sync Map.
        /// </summary>
        ///
        /// <param name="options"> Update SyncMapPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncMapPermission </returns> 
        public static SyncMapPermissionResource Update(UpdateSyncMapPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if !NET35
        /// <summary>
        /// Update an identity's access to a specific Sync Map.
        /// </summary>
        ///
        /// <param name="options"> Update SyncMapPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncMapPermission </returns> 
        public static async System.Threading.Tasks.Task<SyncMapPermissionResource> UpdateAsync(UpdateSyncMapPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Update an identity's access to a specific Sync Map.
        /// </summary>
        ///
        /// <param name="serviceSid"> Sync Service Instance SID. </param>
        /// <param name="mapSid"> Sync Map SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync Map Permission applies. </param>
        /// <param name="read"> Read access. </param>
        /// <param name="write"> Write access. </param>
        /// <param name="manage"> Manage access. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SyncMapPermission </returns> 
        public static SyncMapPermissionResource Update(string serviceSid, string mapSid, string identity, bool? read, bool? write, bool? manage, ITwilioRestClient client = null)
        {
            var options = new UpdateSyncMapPermissionOptions(serviceSid, mapSid, identity, read, write, manage);
            return Update(options, client);
        }
    
        #if !NET35
        /// <summary>
        /// Update an identity's access to a specific Sync Map.
        /// </summary>
        ///
        /// <param name="serviceSid"> Sync Service Instance SID. </param>
        /// <param name="mapSid"> Sync Map SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync Map Permission applies. </param>
        /// <param name="read"> Read access. </param>
        /// <param name="write"> Write access. </param>
        /// <param name="manage"> Manage access. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SyncMapPermission </returns> 
        public static async System.Threading.Tasks.Task<SyncMapPermissionResource> UpdateAsync(string serviceSid, string mapSid, string identity, bool? read, bool? write, bool? manage, ITwilioRestClient client = null)
        {
            var options = new UpdateSyncMapPermissionOptions(serviceSid, mapSid, identity, read, write, manage);
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a SyncMapPermissionResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SyncMapPermissionResource object represented by the provided JSON </returns> 
        public static SyncMapPermissionResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<SyncMapPermissionResource>(json);
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
        /// Sync Map SID.
        /// </summary>
        [JsonProperty("map_sid")]
        public string MapSid { get; private set; }
        /// <summary>
        /// Identity of the user to whom the Sync Map Permission applies.
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
        /// URL of this Sync Map Permission.
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private SyncMapPermissionResource()
        {
        
        }
    }

}