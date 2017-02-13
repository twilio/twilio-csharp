using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Preview.Sync.Service 
{

    public class DocumentResource : Resource 
    {
        private static Request BuildFetchRequest(FetchDocumentOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Documents/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch Document parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Document </returns> 
        public static DocumentResource Fetch(FetchDocumentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch Document parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Document </returns> 
        public static async System.Threading.Tasks.Task<DocumentResource> FetchAsync(FetchDocumentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Document </returns> 
        public static DocumentResource Fetch(string serviceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchDocumentOptions(serviceSid, sid);
            return Fetch(options, client);
        }
    
        #if NET40
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Document </returns> 
        public static async System.Threading.Tasks.Task<DocumentResource> FetchAsync(string serviceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchDocumentOptions(serviceSid, sid);
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteDocumentOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Documents/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="options"> Delete Document parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Document </returns> 
        public static bool Delete(DeleteDocumentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="options"> Delete Document parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Document </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteDocumentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Document </returns> 
        public static bool Delete(string serviceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteDocumentOptions(serviceSid, sid);
            return Delete(options, client);
        }
    
        #if NET40
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Document </returns> 
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string serviceSid, string sid, ITwilioRestClient client = null)
        {
            var options = new DeleteDocumentOptions(serviceSid, sid);
            return await DeleteAsync(options, client);
        }
        #endif
    
        private static Request BuildCreateRequest(CreateDocumentOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Documents",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="options"> Create Document parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Document </returns> 
        public static DocumentResource Create(CreateDocumentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="options"> Create Document parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Document </returns> 
        public static async System.Threading.Tasks.Task<DocumentResource> CreateAsync(CreateDocumentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="uniqueName"> The unique_name </param>
        /// <param name="data"> The data </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Document </returns> 
        public static DocumentResource Create(string serviceSid, string uniqueName = null, object data = null, ITwilioRestClient client = null)
        {
            var options = new CreateDocumentOptions(serviceSid){UniqueName = uniqueName, Data = data};
            return Create(options, client);
        }
    
        #if NET40
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="uniqueName"> The unique_name </param>
        /// <param name="data"> The data </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Document </returns> 
        public static async System.Threading.Tasks.Task<DocumentResource> CreateAsync(string serviceSid, string uniqueName = null, object data = null, ITwilioRestClient client = null)
        {
            var options = new CreateDocumentOptions(serviceSid){UniqueName = uniqueName, Data = data};
            return await CreateAsync(options, client);
        }
        #endif
    
        private static Request BuildReadRequest(ReadDocumentOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Documents",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read Document parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Document </returns> 
        public static ResourceSet<DocumentResource> Read(ReadDocumentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<DocumentResource>.FromJson("documents", response.Content);
            return new ResourceSet<DocumentResource>(page, options, client);
        }
    
        #if NET40
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read Document parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Document </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<DocumentResource>> ReadAsync(ReadDocumentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<DocumentResource>.FromJson("documents", response.Content);
            return new ResourceSet<DocumentResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Document </returns> 
        public static ResourceSet<DocumentResource> Read(string serviceSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadDocumentOptions(serviceSid){PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Document </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<DocumentResource>> ReadAsync(string serviceSid, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadDocumentOptions(serviceSid){PageSize = pageSize, Limit = limit};
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
        public static Page<DocumentResource> NextPage(Page<DocumentResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Preview,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<DocumentResource>.FromJson("documents", response.Content);
        }
    
        private static Request BuildUpdateRequest(UpdateDocumentOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Documents/" + options.Sid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="options"> Update Document parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Document </returns> 
        public static DocumentResource Update(UpdateDocumentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="options"> Update Document parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Document </returns> 
        public static async System.Threading.Tasks.Task<DocumentResource> UpdateAsync(UpdateDocumentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="data"> The data </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Document </returns> 
        public static DocumentResource Update(string serviceSid, string sid, object data, ITwilioRestClient client = null)
        {
            var options = new UpdateDocumentOptions(serviceSid, sid, data);
            return Update(options, client);
        }
    
        #if NET40
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="serviceSid"> The service_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="data"> The data </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Document </returns> 
        public static async System.Threading.Tasks.Task<DocumentResource> UpdateAsync(string serviceSid, string sid, object data, ITwilioRestClient client = null)
        {
            var options = new UpdateDocumentOptions(serviceSid, sid, data);
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a DocumentResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> DocumentResource object represented by the provided JSON </returns> 
        public static DocumentResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<DocumentResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        /// <summary>
        /// The sid
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// The unique_name
        /// </summary>
        [JsonProperty("unique_name")]
        public string UniqueName { get; private set; }
        /// <summary>
        /// The account_sid
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The service_sid
        /// </summary>
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }
        /// <summary>
        /// The url
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        /// <summary>
        /// The links
        /// </summary>
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }
        /// <summary>
        /// The revision
        /// </summary>
        [JsonProperty("revision")]
        public string Revision { get; private set; }
        /// <summary>
        /// The data
        /// </summary>
        [JsonProperty("data")]
        public object Data { get; private set; }
        /// <summary>
        /// The date_created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The date_updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// The created_by
        /// </summary>
        [JsonProperty("created_by")]
        public string CreatedBy { get; private set; }
    
        private DocumentResource()
        {
        
        }
    }

}