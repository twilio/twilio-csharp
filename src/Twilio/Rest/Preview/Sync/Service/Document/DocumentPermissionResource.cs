using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Sync.Service.Document 
{

    public class DocumentPermissionResource : Resource 
    {
        private static Request BuildFetchRequest(FetchDocumentPermissionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Documents/" + options.DocumentSid + "/Permissions/" + options.Identity + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Fetch a specific Sync Document Permission.
        /// </summary>
        ///
        /// <param name="options"> Fetch DocumentPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DocumentPermission </returns> 
        public static DocumentPermissionResource Fetch(FetchDocumentPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        /// <summary>
        /// Fetch a specific Sync Document Permission.
        /// </summary>
        ///
        /// <param name="options"> Fetch DocumentPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DocumentPermission </returns> 
        public static async System.Threading.Tasks.Task<DocumentPermissionResource> FetchAsync(FetchDocumentPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Fetch a specific Sync Document Permission.
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="documentSid"> Sync Document SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync Document Permission applies. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DocumentPermission </returns> 
        public static DocumentPermissionResource Fetch(string serviceSid, string documentSid, string identity, ITwilioRestClient client = null)
        {
            var options = new FetchDocumentPermissionOptions(serviceSid, documentSid, identity);
            return Fetch(options, client);
        }
    
        #if NET40
        /// <summary>
        /// Fetch a specific Sync Document Permission.
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="documentSid"> Sync Document SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync Document Permission applies. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DocumentPermission </returns> 
        public static async System.Threading.Tasks.Task<DocumentPermissionResource> FetchAsync(string serviceSid, string documentSid, string identity, ITwilioRestClient client = null)
        {
            var options = new FetchDocumentPermissionOptions(serviceSid, documentSid, identity);
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteDocumentPermissionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Documents/" + options.DocumentSid + "/Permissions/" + options.Identity + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Delete a specific Sync Document Permission.
        /// </summary>
        ///
        /// <param name="options"> Delete DocumentPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DocumentPermission </returns> 
        public static bool Delete(DeleteDocumentPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        /// <summary>
        /// Delete a specific Sync Document Permission.
        /// </summary>
        ///
        /// <param name="options"> Delete DocumentPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DocumentPermission </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteDocumentPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif
    
        /// <summary>
        /// Delete a specific Sync Document Permission.
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="documentSid"> Sync Document SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync Document Permission applies. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DocumentPermission </returns> 
        public static bool Delete(string serviceSid, string documentSid, string identity, ITwilioRestClient client = null)
        {
            var options = new DeleteDocumentPermissionOptions(serviceSid, documentSid, identity);
            return Delete(options, client);
        }
    
        #if NET40
        /// <summary>
        /// Delete a specific Sync Document Permission.
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="documentSid"> Sync Document SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync Document Permission applies. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DocumentPermission </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string serviceSid, string documentSid, string identity, ITwilioRestClient client = null)
        {
            var options = new DeleteDocumentPermissionOptions(serviceSid, documentSid, identity);
            return await DeleteAsync(options, client);
        }
        #endif
    
        private static Request BuildReadRequest(ReadDocumentPermissionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Documents/" + options.DocumentSid + "/Permissions",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Retrieve a list of all Permissions applying to a Sync Document.
        /// </summary>
        ///
        /// <param name="options"> Read DocumentPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DocumentPermission </returns> 
        public static ResourceSet<DocumentPermissionResource> Read(ReadDocumentPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<DocumentPermissionResource>.FromJson("permissions", response.Content);
            return new ResourceSet<DocumentPermissionResource>(page, options, client);
        }
    
        #if NET40
        /// <summary>
        /// Retrieve a list of all Permissions applying to a Sync Document.
        /// </summary>
        ///
        /// <param name="options"> Read DocumentPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DocumentPermission </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<DocumentPermissionResource>> ReadAsync(ReadDocumentPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<DocumentPermissionResource>.FromJson("permissions", response.Content);
            return new ResourceSet<DocumentPermissionResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// Retrieve a list of all Permissions applying to a Sync Document.
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="documentSid"> Sync Document SID or unique name. </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DocumentPermission </returns> 
        public static ResourceSet<DocumentPermissionResource> Read(string serviceSid, string documentSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadDocumentPermissionOptions(serviceSid, documentSid){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        /// <summary>
        /// Retrieve a list of all Permissions applying to a Sync Document.
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="documentSid"> Sync Document SID or unique name. </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DocumentPermission </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<DocumentPermissionResource>> ReadAsync(string serviceSid, string documentSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadDocumentPermissionOptions(serviceSid, documentSid){PageSize = pageSize, Limit = limit};
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
        public static Page<DocumentPermissionResource> NextPage(Page<DocumentPermissionResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Preview,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<DocumentPermissionResource>.FromJson("permissions", response.Content);
        }
    
        private static Request BuildUpdateRequest(UpdateDocumentPermissionOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Documents/" + options.DocumentSid + "/Permissions/" + options.Identity + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Update an identity's access to a specific Sync Document.
        /// </summary>
        ///
        /// <param name="options"> Update DocumentPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DocumentPermission </returns> 
        public static DocumentPermissionResource Update(UpdateDocumentPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        /// <summary>
        /// Update an identity's access to a specific Sync Document.
        /// </summary>
        ///
        /// <param name="options"> Update DocumentPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DocumentPermission </returns> 
        public static async System.Threading.Tasks.Task<DocumentPermissionResource> UpdateAsync(UpdateDocumentPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Update an identity's access to a specific Sync Document.
        /// </summary>
        ///
        /// <param name="serviceSid"> Sync Service Instance SID. </param>
        /// <param name="documentSid"> Sync Document SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync Document Permission applies. </param>
        /// <param name="read"> Read access. </param>
        /// <param name="write"> Write access. </param>
        /// <param name="manage"> Manage access. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DocumentPermission </returns> 
        public static DocumentPermissionResource Update(string serviceSid, string documentSid, string identity, bool? read, bool? write, bool? manage, ITwilioRestClient client = null)
        {
            var options = new UpdateDocumentPermissionOptions(serviceSid, documentSid, identity, read, write, manage);
            return Update(options, client);
        }
    
        #if NET40
        /// <summary>
        /// Update an identity's access to a specific Sync Document.
        /// </summary>
        ///
        /// <param name="serviceSid"> Sync Service Instance SID. </param>
        /// <param name="documentSid"> Sync Document SID or unique name. </param>
        /// <param name="identity"> Identity of the user to whom the Sync Document Permission applies. </param>
        /// <param name="read"> Read access. </param>
        /// <param name="write"> Write access. </param>
        /// <param name="manage"> Manage access. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DocumentPermission </returns> 
        public static async System.Threading.Tasks.Task<DocumentPermissionResource> UpdateAsync(string serviceSid, string documentSid, string identity, bool? read, bool? write, bool? manage, ITwilioRestClient client = null)
        {
            var options = new UpdateDocumentPermissionOptions(serviceSid, documentSid, identity, read, write, manage);
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a DocumentPermissionResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> DocumentPermissionResource object represented by the provided JSON </returns> 
        public static DocumentPermissionResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<DocumentPermissionResource>(json);
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
        /// Sync Document SID.
        /// </summary>
        [JsonProperty("document_sid")]
        public string DocumentSid { get; private set; }
        /// <summary>
        /// Identity of the user to whom the Sync Document Permission applies.
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
        /// URL of this Sync Document Permission.
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private DocumentPermissionResource()
        {
        
        }
    }

}