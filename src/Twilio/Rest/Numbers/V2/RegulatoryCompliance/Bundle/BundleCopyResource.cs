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
using Twilio.Types;




namespace Twilio.Rest.Numbers.V2.RegulatoryCompliance.Bundle
{
    public class BundleCopyResource : Resource
    {
    

    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class StatusEnum : StringEnum
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}
            public static implicit operator StatusEnum(string value)
            {
                return new StatusEnum(value);
            }
            public static readonly StatusEnum Draft = new StatusEnum("draft");
            public static readonly StatusEnum PendingReview = new StatusEnum("pending-review");
            public static readonly StatusEnum InReview = new StatusEnum("in-review");
            public static readonly StatusEnum TwilioRejected = new StatusEnum("twilio-rejected");
            public static readonly StatusEnum TwilioApproved = new StatusEnum("twilio-approved");
            public static readonly StatusEnum ProvisionallyApproved = new StatusEnum("provisionally-approved");

        }

        
        private static Request BuildCreateRequest(CreateBundleCopyOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/RegulatoryCompliance/Bundles/{BundleSid}/Copies";

            string PathBundleSid = options.PathBundleSid;
            path = path.Replace("{"+"BundleSid"+"}", PathBundleSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Numbers,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Creates a new copy of a Bundle. It will internally create copies of all the bundle items (identities and documents) of the original bundle </summary>
        /// <param name="options"> Create BundleCopy parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of BundleCopy </returns>
        public static BundleCopyResource Create(CreateBundleCopyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Creates a new copy of a Bundle. It will internally create copies of all the bundle items (identities and documents) of the original bundle </summary>
        /// <param name="options"> Create BundleCopy parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of BundleCopy </returns>
        public static async System.Threading.Tasks.Task<BundleCopyResource> CreateAsync(CreateBundleCopyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Creates a new copy of a Bundle. It will internally create copies of all the bundle items (identities and documents) of the original bundle </summary>
        /// <param name="pathBundleSid"> The unique string that identifies the Bundle to be copied. </param>
        /// <param name="friendlyName"> The string that you assigned to describe the copied bundle. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of BundleCopy </returns>
        public static BundleCopyResource Create(
                                          string pathBundleSid,
                                          string friendlyName = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateBundleCopyOptions(pathBundleSid){  FriendlyName = friendlyName };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Creates a new copy of a Bundle. It will internally create copies of all the bundle items (identities and documents) of the original bundle </summary>
        /// <param name="pathBundleSid"> The unique string that identifies the Bundle to be copied. </param>
        /// <param name="friendlyName"> The string that you assigned to describe the copied bundle. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of BundleCopy </returns>
        public static async System.Threading.Tasks.Task<BundleCopyResource> CreateAsync(
                                                                                  string pathBundleSid,
                                                                                  string friendlyName = null,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateBundleCopyOptions(pathBundleSid){  FriendlyName = friendlyName };
            return await CreateAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadBundleCopyOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/RegulatoryCompliance/Bundles/{BundleSid}/Copies";

            string PathBundleSid = options.PathBundleSid;
            path = path.Replace("{"+"BundleSid"+"}", PathBundleSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Numbers,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of all Bundles Copies for a Bundle. </summary>
        /// <param name="options"> Read BundleCopy parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of BundleCopy </returns>
        public static ResourceSet<BundleCopyResource> Read(ReadBundleCopyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<BundleCopyResource>.FromJson("results", response.Content);
            return new ResourceSet<BundleCopyResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Bundles Copies for a Bundle. </summary>
        /// <param name="options"> Read BundleCopy parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of BundleCopy </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<BundleCopyResource>> ReadAsync(ReadBundleCopyOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<BundleCopyResource>.FromJson("results", response.Content);
            return new ResourceSet<BundleCopyResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of all Bundles Copies for a Bundle. </summary>
        /// <param name="pathBundleSid"> The unique string that we created to identify the Bundle resource. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of BundleCopy </returns>
        public static ResourceSet<BundleCopyResource> Read(
                                                     string pathBundleSid,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadBundleCopyOptions(pathBundleSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Bundles Copies for a Bundle. </summary>
        /// <param name="pathBundleSid"> The unique string that we created to identify the Bundle resource. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of BundleCopy </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<BundleCopyResource>> ReadAsync(
                                                                                             string pathBundleSid,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadBundleCopyOptions(pathBundleSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<BundleCopyResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<BundleCopyResource>.FromJson("results", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<BundleCopyResource> NextPage(Page<BundleCopyResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<BundleCopyResource>.FromJson("results", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<BundleCopyResource> PreviousPage(Page<BundleCopyResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<BundleCopyResource>.FromJson("results", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a BundleCopyResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> BundleCopyResource object represented by the provided JSON </returns>
        public static BundleCopyResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<BundleCopyResource>(json);
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

    
        ///<summary> The unique string that we created to identify the Bundle resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Bundle resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The unique string of a regulation that is associated to the Bundle resource. </summary> 
        [JsonProperty("regulation_sid")]
        public string RegulationSid { get; private set; }

        ///<summary> The string that you assigned to describe the resource. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        
        [JsonProperty("status")]
        public BundleCopyResource.StatusEnum Status { get; private set; }

        ///<summary> The date and time in GMT in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format when the resource will be valid until. </summary> 
        [JsonProperty("valid_until")]
        public DateTime? ValidUntil { get; private set; }

        ///<summary> The email address that will receive updates when the Bundle resource changes status. </summary> 
        [JsonProperty("email")]
        public string Email { get; private set; }

        ///<summary> The URL we call to inform your application of status changes. </summary> 
        [JsonProperty("status_callback")]
        public Uri StatusCallback { get; private set; }

        ///<summary> The date and time in GMT when the resource was created specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the resource was last updated specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }



        private BundleCopyResource() {

        }
    }
}

