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



namespace Twilio.Rest.Api.V2010.Account.Recording.AddOnResult
{
    public class PayloadResource : Resource
    {
    

    

        
        /// <summary> Delete a payload from the result along with all associated Data </summary>
        /// <param name="options"> Delete Payload parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Payload </returns>
        private static Request BuildDeleteRequest(DeletePayloadOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/Recordings/{ReferenceSid}/AddOnResults/{AddOnResultSid}/Payloads/{Sid}.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathReferenceSid = options.PathReferenceSid;
            path = path.Replace("{"+"ReferenceSid"+"}", PathReferenceSid);
            string PathAddOnResultSid = options.PathAddOnResultSid;
            path = path.Replace("{"+"AddOnResultSid"+"}", PathAddOnResultSid);
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

        /// <summary> Delete a payload from the result along with all associated Data </summary>
        /// <param name="options"> Delete Payload parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Payload </returns>
        public static bool Delete(DeletePayloadOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Delete a payload from the result along with all associated Data </summary>
        /// <param name="options"> Delete Payload parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Payload </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeletePayloadOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Delete a payload from the result along with all associated Data </summary>
        /// <param name="pathReferenceSid"> The SID of the recording to which the AddOnResult resource that contains the payloads to delete belongs. </param>
        /// <param name="pathAddOnResultSid"> The SID of the AddOnResult to which the payloads to delete belongs. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Recording AddOnResult Payload resource to delete. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Recording AddOnResult Payload resources to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Payload </returns>
        public static bool Delete(string pathReferenceSid, string pathAddOnResultSid, string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeletePayloadOptions(pathReferenceSid, pathAddOnResultSid, pathSid)            { PathAccountSid = pathAccountSid }   ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Delete a payload from the result along with all associated Data </summary>
        /// <param name="pathReferenceSid"> The SID of the recording to which the AddOnResult resource that contains the payloads to delete belongs. </param>
        /// <param name="pathAddOnResultSid"> The SID of the AddOnResult to which the payloads to delete belongs. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Recording AddOnResult Payload resource to delete. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Recording AddOnResult Payload resources to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Payload </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathReferenceSid, string pathAddOnResultSid, string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeletePayloadOptions(pathReferenceSid, pathAddOnResultSid, pathSid)  { PathAccountSid = pathAccountSid };
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchPayloadOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/Recordings/{ReferenceSid}/AddOnResults/{AddOnResultSid}/Payloads/{Sid}.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathReferenceSid = options.PathReferenceSid;
            path = path.Replace("{"+"ReferenceSid"+"}", PathReferenceSid);
            string PathAddOnResultSid = options.PathAddOnResultSid;
            path = path.Replace("{"+"AddOnResultSid"+"}", PathAddOnResultSid);
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

        /// <summary> Fetch an instance of a result payload </summary>
        /// <param name="options"> Fetch Payload parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Payload </returns>
        public static PayloadResource Fetch(FetchPayloadOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch an instance of a result payload </summary>
        /// <param name="options"> Fetch Payload parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Payload </returns>
        public static async System.Threading.Tasks.Task<PayloadResource> FetchAsync(FetchPayloadOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch an instance of a result payload </summary>
        /// <param name="pathReferenceSid"> The SID of the recording to which the AddOnResult resource that contains the payload to fetch belongs. </param>
        /// <param name="pathAddOnResultSid"> The SID of the AddOnResult to which the payload to fetch belongs. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Recording AddOnResult Payload resource to fetch. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Recording AddOnResult Payload resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Payload </returns>
        public static PayloadResource Fetch(
                                         string pathReferenceSid, 
                                         string pathAddOnResultSid, 
                                         string pathSid, 
                                         string pathAccountSid = null, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchPayloadOptions(pathReferenceSid, pathAddOnResultSid, pathSid){ PathAccountSid = pathAccountSid };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch an instance of a result payload </summary>
        /// <param name="pathReferenceSid"> The SID of the recording to which the AddOnResult resource that contains the payload to fetch belongs. </param>
        /// <param name="pathAddOnResultSid"> The SID of the AddOnResult to which the payload to fetch belongs. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Recording AddOnResult Payload resource to fetch. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Recording AddOnResult Payload resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Payload </returns>
        public static async System.Threading.Tasks.Task<PayloadResource> FetchAsync(string pathReferenceSid, string pathAddOnResultSid, string pathSid, string pathAccountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchPayloadOptions(pathReferenceSid, pathAddOnResultSid, pathSid){ PathAccountSid = pathAccountSid };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadPayloadOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/Recordings/{ReferenceSid}/AddOnResults/{AddOnResultSid}/Payloads.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathReferenceSid = options.PathReferenceSid;
            path = path.Replace("{"+"ReferenceSid"+"}", PathReferenceSid);
            string PathAddOnResultSid = options.PathAddOnResultSid;
            path = path.Replace("{"+"AddOnResultSid"+"}", PathAddOnResultSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of payloads belonging to the AddOnResult </summary>
        /// <param name="options"> Read Payload parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Payload </returns>
        public static ResourceSet<PayloadResource> Read(ReadPayloadOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<PayloadResource>.FromJson("payloads", response.Content);
            return new ResourceSet<PayloadResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of payloads belonging to the AddOnResult </summary>
        /// <param name="options"> Read Payload parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Payload </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<PayloadResource>> ReadAsync(ReadPayloadOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<PayloadResource>.FromJson("payloads", response.Content);
            return new ResourceSet<PayloadResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of payloads belonging to the AddOnResult </summary>
        /// <param name="pathReferenceSid"> The SID of the recording to which the AddOnResult resource that contains the payloads to read belongs. </param>
        /// <param name="pathAddOnResultSid"> The SID of the AddOnResult to which the payloads to read belongs. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Recording AddOnResult Payload resources to read. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Payload </returns>
        public static ResourceSet<PayloadResource> Read(
                                                     string pathReferenceSid,
                                                     string pathAddOnResultSid,
                                                     string pathAccountSid = null,
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadPayloadOptions(pathReferenceSid, pathAddOnResultSid){ PathAccountSid = pathAccountSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of payloads belonging to the AddOnResult </summary>
        /// <param name="pathReferenceSid"> The SID of the recording to which the AddOnResult resource that contains the payloads to read belongs. </param>
        /// <param name="pathAddOnResultSid"> The SID of the AddOnResult to which the payloads to read belongs. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Recording AddOnResult Payload resources to read. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Payload </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<PayloadResource>> ReadAsync(
                                                                                             string pathReferenceSid,
                                                                                             string pathAddOnResultSid,
                                                                                             string pathAccountSid = null,
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadPayloadOptions(pathReferenceSid, pathAddOnResultSid){ PathAccountSid = pathAccountSid, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<PayloadResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<PayloadResource>.FromJson("payloads", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<PayloadResource> NextPage(Page<PayloadResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<PayloadResource>.FromJson("payloads", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<PayloadResource> PreviousPage(Page<PayloadResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<PayloadResource>.FromJson("payloads", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a PayloadResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> PayloadResource object represented by the provided JSON </returns>
        public static PayloadResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<PayloadResource>(json);
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

    
        ///<summary> The unique string that that we created to identify the Recording AddOnResult Payload resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the AddOnResult to which the payload belongs. </summary> 
        [JsonProperty("add_on_result_sid")]
        public string AddOnResultSid { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Recording AddOnResult Payload resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The string provided by the vendor that describes the payload. </summary> 
        [JsonProperty("label")]
        public string Label { get; private set; }

        ///<summary> The SID of the Add-on to which the result belongs. </summary> 
        [JsonProperty("add_on_sid")]
        public string AddOnSid { get; private set; }

        ///<summary> The SID of the Add-on configuration. </summary> 
        [JsonProperty("add_on_configuration_sid")]
        public string AddOnConfigurationSid { get; private set; }

        ///<summary> The MIME type of the payload. </summary> 
        [JsonProperty("content_type")]
        public string ContentType { get; private set; }

        ///<summary> The date and time in GMT that the resource was created specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT that the resource was last updated specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The SID of the recording to which the AddOnResult resource that contains the payload belongs. </summary> 
        [JsonProperty("reference_sid")]
        public string ReferenceSid { get; private set; }

        ///<summary> A list of related resources identified by their relative URIs. </summary> 
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> SubresourceUris { get; private set; }



        private PayloadResource() {

        }
    }
}

