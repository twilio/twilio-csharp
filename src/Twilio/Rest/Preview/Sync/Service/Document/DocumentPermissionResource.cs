/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Preview
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



namespace Twilio.Rest.Preview.Sync.Service.Document
{
    public class DocumentPermissionResource : Resource
    {
    

        
        /// <summary> Delete a specific Sync Document Permission. </summary>
        /// <param name="options"> Delete DocumentPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DocumentPermission </returns>
        private static Request BuildDeleteRequest(DeleteDocumentPermissionOptions options, ITwilioRestClient client)
        {
            
            string path = "/Sync/Services/{ServiceSid}/Documents/{DocumentSid}/Permissions/{Identity}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathDocumentSid = options.PathDocumentSid;
            path = path.Replace("{"+"DocumentSid"+"}", PathDocumentSid);
            string PathIdentity = options.PathIdentity;
            path = path.Replace("{"+"Identity"+"}", PathIdentity);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Preview,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Delete a specific Sync Document Permission. </summary>
        /// <param name="options"> Delete DocumentPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DocumentPermission </returns>
        public static bool Delete(DeleteDocumentPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Delete a specific Sync Document Permission. </summary>
        /// <param name="options"> Delete DocumentPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DocumentPermission </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteDocumentPermissionOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Delete a specific Sync Document Permission. </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathDocumentSid"> Identifier of the Sync Document. Either a SID or a unique name. </param>
        /// <param name="pathIdentity"> Arbitrary string identifier representing a user associated with an FPA token, assigned by the developer. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DocumentPermission </returns>
        public static bool Delete(string pathServiceSid, string pathDocumentSid, string pathIdentity, ITwilioRestClient client = null)
        {
            var options = new DeleteDocumentPermissionOptions(pathServiceSid, pathDocumentSid, pathIdentity)           ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Delete a specific Sync Document Permission. </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathDocumentSid"> Identifier of the Sync Document. Either a SID or a unique name. </param>
        /// <param name="pathIdentity"> Arbitrary string identifier representing a user associated with an FPA token, assigned by the developer. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DocumentPermission </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid, string pathDocumentSid, string pathIdentity, ITwilioRestClient client = null)
        {
            var options = new DeleteDocumentPermissionOptions(pathServiceSid, pathDocumentSid, pathIdentity) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchDocumentPermissionOptions options, ITwilioRestClient client)
        {
            
            string path = "/Sync/Services/{ServiceSid}/Documents/{DocumentSid}/Permissions/{Identity}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathDocumentSid = options.PathDocumentSid;
            path = path.Replace("{"+"DocumentSid"+"}", PathDocumentSid);
            string PathIdentity = options.PathIdentity;
            path = path.Replace("{"+"Identity"+"}", PathIdentity);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a specific Sync Document Permission. </summary>
        /// <param name="options"> Fetch DocumentPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DocumentPermission </returns>
        public static DocumentPermissionResource Fetch(FetchDocumentPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a specific Sync Document Permission. </summary>
        /// <param name="options"> Fetch DocumentPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DocumentPermission </returns>
        public static async System.Threading.Tasks.Task<DocumentPermissionResource> FetchAsync(FetchDocumentPermissionOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a specific Sync Document Permission. </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathDocumentSid"> Identifier of the Sync Document. Either a SID or a unique name. </param>
        /// <param name="pathIdentity"> Arbitrary string identifier representing a user associated with an FPA token, assigned by the developer. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DocumentPermission </returns>
        public static DocumentPermissionResource Fetch(
                                         string pathServiceSid, 
                                         string pathDocumentSid, 
                                         string pathIdentity, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchDocumentPermissionOptions(pathServiceSid, pathDocumentSid, pathIdentity){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a specific Sync Document Permission. </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathDocumentSid"> Identifier of the Sync Document. Either a SID or a unique name. </param>
        /// <param name="pathIdentity"> Arbitrary string identifier representing a user associated with an FPA token, assigned by the developer. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DocumentPermission </returns>
        public static async System.Threading.Tasks.Task<DocumentPermissionResource> FetchAsync(string pathServiceSid, string pathDocumentSid, string pathIdentity, ITwilioRestClient client = null)
        {
            var options = new FetchDocumentPermissionOptions(pathServiceSid, pathDocumentSid, pathIdentity){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadDocumentPermissionOptions options, ITwilioRestClient client)
        {
            
            string path = "/Sync/Services/{ServiceSid}/Documents/{DocumentSid}/Permissions";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathDocumentSid = options.PathDocumentSid;
            path = path.Replace("{"+"DocumentSid"+"}", PathDocumentSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of all Permissions applying to a Sync Document. </summary>
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

        #if !NET35
        /// <summary> Retrieve a list of all Permissions applying to a Sync Document. </summary>
        /// <param name="options"> Read DocumentPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DocumentPermission </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<DocumentPermissionResource>> ReadAsync(ReadDocumentPermissionOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<DocumentPermissionResource>.FromJson("permissions", response.Content);
            return new ResourceSet<DocumentPermissionResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of all Permissions applying to a Sync Document. </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathDocumentSid"> Identifier of the Sync Document. Either a SID or a unique name. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DocumentPermission </returns>
        public static ResourceSet<DocumentPermissionResource> Read(
                                                     string pathServiceSid,
                                                     string pathDocumentSid,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadDocumentPermissionOptions(pathServiceSid, pathDocumentSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Permissions applying to a Sync Document. </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathDocumentSid"> Identifier of the Sync Document. Either a SID or a unique name. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DocumentPermission </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<DocumentPermissionResource>> ReadAsync(
                                                                                             string pathServiceSid,
                                                                                             string pathDocumentSid,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadDocumentPermissionOptions(pathServiceSid, pathDocumentSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<DocumentPermissionResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<DocumentPermissionResource>.FromJson("permissions", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<DocumentPermissionResource> NextPage(Page<DocumentPermissionResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<DocumentPermissionResource>.FromJson("permissions", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<DocumentPermissionResource> PreviousPage(Page<DocumentPermissionResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<DocumentPermissionResource>.FromJson("permissions", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateDocumentPermissionOptions options, ITwilioRestClient client)
        {
            
            string path = "/Sync/Services/{ServiceSid}/Documents/{DocumentSid}/Permissions/{Identity}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathDocumentSid = options.PathDocumentSid;
            path = path.Replace("{"+"DocumentSid"+"}", PathDocumentSid);
            string PathIdentity = options.PathIdentity;
            path = path.Replace("{"+"Identity"+"}", PathIdentity);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Update an identity's access to a specific Sync Document. </summary>
        /// <param name="options"> Update DocumentPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DocumentPermission </returns>
        public static DocumentPermissionResource Update(UpdateDocumentPermissionOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Update an identity's access to a specific Sync Document. </summary>
        /// <param name="options"> Update DocumentPermission parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DocumentPermission </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<DocumentPermissionResource> UpdateAsync(UpdateDocumentPermissionOptions options,
                                                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Update an identity's access to a specific Sync Document. </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Sync Service Instance. </param>
        /// <param name="pathDocumentSid"> Identifier of the Sync Document. Either a SID or a unique name. </param>
        /// <param name="pathIdentity"> Arbitrary string identifier representing a human user associated with an FPA token, assigned by the developer. </param>
        /// <param name="read"> Boolean flag specifying whether the identity can read the Sync Document. </param>
        /// <param name="write"> Boolean flag specifying whether the identity can update the Sync Document. </param>
        /// <param name="manage"> Boolean flag specifying whether the identity can delete the Sync Document. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of DocumentPermission </returns>
        public static DocumentPermissionResource Update(
                                          string pathServiceSid,
                                          string pathDocumentSid,
                                          string pathIdentity,
                                          bool? read,
                                          bool? write,
                                          bool? manage,
                                          ITwilioRestClient client = null)
        {
            var options = new UpdateDocumentPermissionOptions(pathServiceSid, pathDocumentSid, pathIdentity, read, write, manage){  };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Update an identity's access to a specific Sync Document. </summary>
        /// <param name="pathServiceSid"> The unique SID identifier of the Sync Service Instance. </param>
        /// <param name="pathDocumentSid"> Identifier of the Sync Document. Either a SID or a unique name. </param>
        /// <param name="pathIdentity"> Arbitrary string identifier representing a human user associated with an FPA token, assigned by the developer. </param>
        /// <param name="read"> Boolean flag specifying whether the identity can read the Sync Document. </param>
        /// <param name="write"> Boolean flag specifying whether the identity can update the Sync Document. </param>
        /// <param name="manage"> Boolean flag specifying whether the identity can delete the Sync Document. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of DocumentPermission </returns>
        public static async System.Threading.Tasks.Task<DocumentPermissionResource> UpdateAsync(
                                                                              string pathServiceSid,
                                                                              string pathDocumentSid,
                                                                              string pathIdentity,
                                                                              bool? read,
                                                                              bool? write,
                                                                              bool? manage,
                                                                              ITwilioRestClient client = null)
        {
            var options = new UpdateDocumentPermissionOptions(pathServiceSid, pathDocumentSid, pathIdentity, read, write, manage){  };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a DocumentPermissionResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> DocumentPermissionResource object represented by the provided JSON </returns>
        public static DocumentPermissionResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<DocumentPermissionResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> The unique SID identifier of the Twilio Account. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The unique SID identifier of the Sync Service Instance. </summary> 
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }

        ///<summary> The unique SID identifier of the Sync Document to which the Permission applies. </summary> 
        [JsonProperty("document_sid")]
        public string DocumentSid { get; private set; }

        ///<summary> Arbitrary string identifier representing a human user associated with an FPA token, assigned by the developer. </summary> 
        [JsonProperty("identity")]
        public string Identity { get; private set; }

        ///<summary> Boolean flag specifying whether the identity can read the Sync Document. </summary> 
        [JsonProperty("read")]
        public bool? _Read { get; private set; }

        ///<summary> Boolean flag specifying whether the identity can update the Sync Document. </summary> 
        [JsonProperty("write")]
        public bool? Write { get; private set; }

        ///<summary> Boolean flag specifying whether the identity can delete the Sync Document. </summary> 
        [JsonProperty("manage")]
        public bool? Manage { get; private set; }

        ///<summary> Contains an absolute URL for this Sync Document Permission. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private DocumentPermissionResource() {

        }
    }
}

