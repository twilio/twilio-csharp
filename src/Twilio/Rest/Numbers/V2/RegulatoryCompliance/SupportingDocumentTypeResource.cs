/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Numbers
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





namespace Twilio.Rest.Numbers.V2.RegulatoryCompliance
{
    public class SupportingDocumentTypeResource : Resource
    {
    

    

        
        private static Request BuildFetchRequest(FetchSupportingDocumentTypeOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/RegulatoryCompliance/SupportingDocumentTypes/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Numbers,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a specific Supporting Document Type Instance. </summary>
        /// <param name="options"> Fetch SupportingDocumentType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SupportingDocumentType </returns>
        public static SupportingDocumentTypeResource Fetch(FetchSupportingDocumentTypeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a specific Supporting Document Type Instance. </summary>
        /// <param name="options"> Fetch SupportingDocumentType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SupportingDocumentType </returns>
        public static async System.Threading.Tasks.Task<SupportingDocumentTypeResource> FetchAsync(FetchSupportingDocumentTypeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a specific Supporting Document Type Instance. </summary>
        /// <param name="pathSid"> The unique string that identifies the Supporting Document Type resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SupportingDocumentType </returns>
        public static SupportingDocumentTypeResource Fetch(
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchSupportingDocumentTypeOptions(pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a specific Supporting Document Type Instance. </summary>
        /// <param name="pathSid"> The unique string that identifies the Supporting Document Type resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SupportingDocumentType </returns>
        public static async System.Threading.Tasks.Task<SupportingDocumentTypeResource> FetchAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchSupportingDocumentTypeOptions(pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadSupportingDocumentTypeOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/RegulatoryCompliance/SupportingDocumentTypes";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Numbers,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of all Supporting Document Types. </summary>
        /// <param name="options"> Read SupportingDocumentType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SupportingDocumentType </returns>
        public static ResourceSet<SupportingDocumentTypeResource> Read(ReadSupportingDocumentTypeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<SupportingDocumentTypeResource>.FromJson("supporting_document_types", response.Content);
            return new ResourceSet<SupportingDocumentTypeResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Supporting Document Types. </summary>
        /// <param name="options"> Read SupportingDocumentType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SupportingDocumentType </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<SupportingDocumentTypeResource>> ReadAsync(ReadSupportingDocumentTypeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<SupportingDocumentTypeResource>.FromJson("supporting_document_types", response.Content);
            return new ResourceSet<SupportingDocumentTypeResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of all Supporting Document Types. </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SupportingDocumentType </returns>
        public static ResourceSet<SupportingDocumentTypeResource> Read(
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadSupportingDocumentTypeOptions(){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Supporting Document Types. </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SupportingDocumentType </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<SupportingDocumentTypeResource>> ReadAsync(
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadSupportingDocumentTypeOptions(){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<SupportingDocumentTypeResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<SupportingDocumentTypeResource>.FromJson("supporting_document_types", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<SupportingDocumentTypeResource> NextPage(Page<SupportingDocumentTypeResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<SupportingDocumentTypeResource>.FromJson("supporting_document_types", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<SupportingDocumentTypeResource> PreviousPage(Page<SupportingDocumentTypeResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<SupportingDocumentTypeResource>.FromJson("supporting_document_types", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a SupportingDocumentTypeResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SupportingDocumentTypeResource object represented by the provided JSON </returns>
        public static SupportingDocumentTypeResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<SupportingDocumentTypeResource>(json);
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

    
        ///<summary> The unique string that identifies the Supporting Document Type resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> A human-readable description of the Supporting Document Type resource. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> The machine-readable description of the Supporting Document Type resource. </summary> 
        [JsonProperty("machine_name")]
        public string MachineName { get; private set; }

        ///<summary> The required information for creating a Supporting Document. The required fields will change as regulatory needs change and will differ for businesses and individuals. </summary> 
        [JsonProperty("fields")]
        public List<object> Fields { get; private set; }

        ///<summary> The absolute URL of the Supporting Document Type resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private SupportingDocumentTypeResource() {

        }
    }
}

