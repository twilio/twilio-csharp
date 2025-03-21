/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Intelligence
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


namespace Twilio.Rest.Intelligence.V2
{
    public class OperatorTypeResource : Resource
    {
    

    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class ProviderEnum : StringEnum
        {
            private ProviderEnum(string value) : base(value) {}
            public ProviderEnum() {}
            public static implicit operator ProviderEnum(string value)
            {
                return new ProviderEnum(value);
            }
            public static readonly ProviderEnum Twilio = new ProviderEnum("twilio");
            public static readonly ProviderEnum Amazon = new ProviderEnum("amazon");
            public static readonly ProviderEnum Openai = new ProviderEnum("openai");

        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class AvailabilityEnum : StringEnum
        {
            private AvailabilityEnum(string value) : base(value) {}
            public AvailabilityEnum() {}
            public static implicit operator AvailabilityEnum(string value)
            {
                return new AvailabilityEnum(value);
            }
            public static readonly AvailabilityEnum Internal = new AvailabilityEnum("internal");
            public static readonly AvailabilityEnum Beta = new AvailabilityEnum("beta");
            public static readonly AvailabilityEnum GeneralAvailability = new AvailabilityEnum("general-availability");
            public static readonly AvailabilityEnum Retired = new AvailabilityEnum("retired");
            public static readonly AvailabilityEnum Deprecated = new AvailabilityEnum("deprecated");

        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class OutputTypeEnum : StringEnum
        {
            private OutputTypeEnum(string value) : base(value) {}
            public OutputTypeEnum() {}
            public static implicit operator OutputTypeEnum(string value)
            {
                return new OutputTypeEnum(value);
            }
            public static readonly OutputTypeEnum TextClassification = new OutputTypeEnum("text-classification");
            public static readonly OutputTypeEnum TextExtraction = new OutputTypeEnum("text-extraction");
            public static readonly OutputTypeEnum TextExtractionNormalized = new OutputTypeEnum("text-extraction-normalized");
            public static readonly OutputTypeEnum TextGeneration = new OutputTypeEnum("text-generation");

        }

        
        private static Request BuildFetchRequest(FetchOperatorTypeOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/OperatorTypes/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Intelligence,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a specific Operator Type. </summary>
        /// <param name="options"> Fetch OperatorType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OperatorType </returns>
        public static OperatorTypeResource Fetch(FetchOperatorTypeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a specific Operator Type. </summary>
        /// <param name="options"> Fetch OperatorType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of OperatorType </returns>
        public static async System.Threading.Tasks.Task<OperatorTypeResource> FetchAsync(FetchOperatorTypeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a specific Operator Type. </summary>
        /// <param name="pathSid"> Either a 34 character string that uniquely identifies this Operator Type or the unique name that references an Operator Type. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OperatorType </returns>
        public static OperatorTypeResource Fetch(
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchOperatorTypeOptions(pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a specific Operator Type. </summary>
        /// <param name="pathSid"> Either a 34 character string that uniquely identifies this Operator Type or the unique name that references an Operator Type. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of OperatorType </returns>
        public static async System.Threading.Tasks.Task<OperatorTypeResource> FetchAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchOperatorTypeOptions(pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadOperatorTypeOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/OperatorTypes";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Intelligence,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieves a list of all Operator Types for an Account. </summary>
        /// <param name="options"> Read OperatorType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OperatorType </returns>
        public static ResourceSet<OperatorTypeResource> Read(ReadOperatorTypeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<OperatorTypeResource>.FromJson("operator_types", response.Content);
            return new ResourceSet<OperatorTypeResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieves a list of all Operator Types for an Account. </summary>
        /// <param name="options"> Read OperatorType parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of OperatorType </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<OperatorTypeResource>> ReadAsync(ReadOperatorTypeOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<OperatorTypeResource>.FromJson("operator_types", response.Content);
            return new ResourceSet<OperatorTypeResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieves a list of all Operator Types for an Account. </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of OperatorType </returns>
        public static ResourceSet<OperatorTypeResource> Read(
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadOperatorTypeOptions(){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieves a list of all Operator Types for an Account. </summary>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of OperatorType </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<OperatorTypeResource>> ReadAsync(
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadOperatorTypeOptions(){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<OperatorTypeResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<OperatorTypeResource>.FromJson("operator_types", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<OperatorTypeResource> NextPage(Page<OperatorTypeResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<OperatorTypeResource>.FromJson("operator_types", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<OperatorTypeResource> PreviousPage(Page<OperatorTypeResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<OperatorTypeResource>.FromJson("operator_types", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a OperatorTypeResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> OperatorTypeResource object represented by the provided JSON </returns>
        public static OperatorTypeResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<OperatorTypeResource>(json);
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

    
        ///<summary> A unique name that references an Operator's Operator Type. </summary> 
        [JsonProperty("name")]
        public string Name { get; private set; }

        ///<summary> A 34 character string that uniquely identifies this Operator Type. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> A human-readable name of this resource, up to 64 characters. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> A human-readable description of this resource, longer than the friendly name. </summary> 
        [JsonProperty("description")]
        public string Description { get; private set; }

        ///<summary> Additional documentation for the Operator Type. </summary> 
        [JsonProperty("docs_link")]
        public Uri DocsLink { get; private set; }

        
        [JsonProperty("output_type")]
        public OperatorTypeResource.OutputTypeEnum OutputType { get; private set; }

        ///<summary> List of languages this Operator Type supports. </summary> 
        [JsonProperty("supported_languages")]
        public List<string> SupportedLanguages { get; private set; }

        
        [JsonProperty("provider")]
        public OperatorTypeResource.ProviderEnum Provider { get; private set; }

        
        [JsonProperty("availability")]
        public OperatorTypeResource.AvailabilityEnum Availability { get; private set; }

        ///<summary> Operators can be created from configurable Operator Types. </summary> 
        [JsonProperty("configurable")]
        public bool? Configurable { get; private set; }

        ///<summary> JSON Schema for configuring an Operator with this Operator Type. Following https://json-schema.org/ </summary> 
        [JsonProperty("config_schema")]
        public object ConfigSchema { get; private set; }

        ///<summary> The date that this Operator Type was created, given in ISO 8601 format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date that this Operator Type was updated, given in ISO 8601 format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The URL of this resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private OperatorTypeResource() {

        }
    }
}

