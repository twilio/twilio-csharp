/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Trusthub
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


namespace Twilio.Rest.Trusthub.V1.TrustProducts
{
    public class TrustProductsEvaluationsResource : Resource
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
            public static readonly StatusEnum Compliant = new StatusEnum("compliant");
            public static readonly StatusEnum Noncompliant = new StatusEnum("noncompliant");

        }

        
        private static Request BuildCreateRequest(CreateTrustProductsEvaluationsOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/TrustProducts/{TrustProductSid}/Evaluations";

            string PathTrustProductSid = options.PathTrustProductSid;
            path = path.Replace("{"+"TrustProductSid"+"}", PathTrustProductSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Trusthub,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create a new Evaluation </summary>
        /// <param name="options"> Create TrustProductsEvaluations parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of TrustProductsEvaluations </returns>
        public static TrustProductsEvaluationsResource Create(CreateTrustProductsEvaluationsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a new Evaluation </summary>
        /// <param name="options"> Create TrustProductsEvaluations parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of TrustProductsEvaluations </returns>
        public static async System.Threading.Tasks.Task<TrustProductsEvaluationsResource> CreateAsync(CreateTrustProductsEvaluationsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a new Evaluation </summary>
        /// <param name="pathTrustProductSid"> The unique string that we created to identify the trust_product resource. </param>
        /// <param name="policySid"> The unique string of a policy that is associated to the customer_profile resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of TrustProductsEvaluations </returns>
        public static TrustProductsEvaluationsResource Create(
                                          string pathTrustProductSid,
                                          string policySid,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateTrustProductsEvaluationsOptions(pathTrustProductSid, policySid){  };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a new Evaluation </summary>
        /// <param name="pathTrustProductSid"> The unique string that we created to identify the trust_product resource. </param>
        /// <param name="policySid"> The unique string of a policy that is associated to the customer_profile resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of TrustProductsEvaluations </returns>
        public static async System.Threading.Tasks.Task<TrustProductsEvaluationsResource> CreateAsync(
                                                                                  string pathTrustProductSid,
                                                                                  string policySid,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateTrustProductsEvaluationsOptions(pathTrustProductSid, policySid){  };
            return await CreateAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchTrustProductsEvaluationsOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/TrustProducts/{TrustProductSid}/Evaluations/{Sid}";

            string PathTrustProductSid = options.PathTrustProductSid;
            path = path.Replace("{"+"TrustProductSid"+"}", PathTrustProductSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Trusthub,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch specific Evaluation Instance. </summary>
        /// <param name="options"> Fetch TrustProductsEvaluations parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of TrustProductsEvaluations </returns>
        public static TrustProductsEvaluationsResource Fetch(FetchTrustProductsEvaluationsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch specific Evaluation Instance. </summary>
        /// <param name="options"> Fetch TrustProductsEvaluations parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of TrustProductsEvaluations </returns>
        public static async System.Threading.Tasks.Task<TrustProductsEvaluationsResource> FetchAsync(FetchTrustProductsEvaluationsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch specific Evaluation Instance. </summary>
        /// <param name="pathTrustProductSid"> The unique string that we created to identify the trust_product resource. </param>
        /// <param name="pathSid"> The unique string that identifies the Evaluation resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of TrustProductsEvaluations </returns>
        public static TrustProductsEvaluationsResource Fetch(
                                         string pathTrustProductSid, 
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchTrustProductsEvaluationsOptions(pathTrustProductSid, pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch specific Evaluation Instance. </summary>
        /// <param name="pathTrustProductSid"> The unique string that we created to identify the trust_product resource. </param>
        /// <param name="pathSid"> The unique string that identifies the Evaluation resource. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of TrustProductsEvaluations </returns>
        public static async System.Threading.Tasks.Task<TrustProductsEvaluationsResource> FetchAsync(string pathTrustProductSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchTrustProductsEvaluationsOptions(pathTrustProductSid, pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadTrustProductsEvaluationsOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/TrustProducts/{TrustProductSid}/Evaluations";

            string PathTrustProductSid = options.PathTrustProductSid;
            path = path.Replace("{"+"TrustProductSid"+"}", PathTrustProductSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Trusthub,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of Evaluations associated to the trust_product resource. </summary>
        /// <param name="options"> Read TrustProductsEvaluations parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of TrustProductsEvaluations </returns>
        public static ResourceSet<TrustProductsEvaluationsResource> Read(ReadTrustProductsEvaluationsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<TrustProductsEvaluationsResource>.FromJson("results", response.Content);
            return new ResourceSet<TrustProductsEvaluationsResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of Evaluations associated to the trust_product resource. </summary>
        /// <param name="options"> Read TrustProductsEvaluations parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of TrustProductsEvaluations </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<TrustProductsEvaluationsResource>> ReadAsync(ReadTrustProductsEvaluationsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<TrustProductsEvaluationsResource>.FromJson("results", response.Content);
            return new ResourceSet<TrustProductsEvaluationsResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of Evaluations associated to the trust_product resource. </summary>
        /// <param name="pathTrustProductSid"> The unique string that we created to identify the trust_product resource. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of TrustProductsEvaluations </returns>
        public static ResourceSet<TrustProductsEvaluationsResource> Read(
                                                     string pathTrustProductSid,
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadTrustProductsEvaluationsOptions(pathTrustProductSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of Evaluations associated to the trust_product resource. </summary>
        /// <param name="pathTrustProductSid"> The unique string that we created to identify the trust_product resource. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of TrustProductsEvaluations </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<TrustProductsEvaluationsResource>> ReadAsync(
                                                                                             string pathTrustProductSid,
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadTrustProductsEvaluationsOptions(pathTrustProductSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<TrustProductsEvaluationsResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<TrustProductsEvaluationsResource>.FromJson("results", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<TrustProductsEvaluationsResource> NextPage(Page<TrustProductsEvaluationsResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<TrustProductsEvaluationsResource>.FromJson("results", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<TrustProductsEvaluationsResource> PreviousPage(Page<TrustProductsEvaluationsResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<TrustProductsEvaluationsResource>.FromJson("results", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a TrustProductsEvaluationsResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TrustProductsEvaluationsResource object represented by the provided JSON </returns>
        public static TrustProductsEvaluationsResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<TrustProductsEvaluationsResource>(json);
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

    
        ///<summary> The unique string that identifies the Evaluation resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the trust_product resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The unique string of a policy that is associated to the trust_product resource. </summary> 
        [JsonProperty("policy_sid")]
        public string PolicySid { get; private set; }

        ///<summary> The unique string that we created to identify the trust_product resource. </summary> 
        [JsonProperty("trust_product_sid")]
        public string TrustProductSid { get; private set; }

        
        [JsonProperty("status")]
        public TrustProductsEvaluationsResource.StatusEnum Status { get; private set; }

        ///<summary> The results of the Evaluation which includes the valid and invalid attributes. </summary> 
        [JsonProperty("results")]
        public List<object> Results { get; private set; }

        ///<summary> The date_created </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The url </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private TrustProductsEvaluationsResource() {

        }
    }
}

