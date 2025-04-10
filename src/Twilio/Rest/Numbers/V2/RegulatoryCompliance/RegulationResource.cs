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


namespace Twilio.Rest.Numbers.V2.RegulatoryCompliance
{
    public class RegulationResource : Resource
    {
    

    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class EndUserTypeEnum : StringEnum
        {
            private EndUserTypeEnum(string value) : base(value) {}
            public EndUserTypeEnum() {}
            public static implicit operator EndUserTypeEnum(string value)
            {
                return new EndUserTypeEnum(value);
            }
            public static readonly EndUserTypeEnum Individual = new EndUserTypeEnum("individual");
            public static readonly EndUserTypeEnum Business = new EndUserTypeEnum("business");

        }

        
        private static Request BuildFetchRequest(FetchRegulationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/RegulatoryCompliance/Regulations/{Sid}";

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

        /// <summary> Fetch specific Regulation Instance. </summary>
        /// <param name="options"> Fetch Regulation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Regulation </returns>
        public static RegulationResource Fetch(FetchRegulationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch specific Regulation Instance. </summary>
        /// <param name="options"> Fetch Regulation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Regulation </returns>
        public static async System.Threading.Tasks.Task<RegulationResource> FetchAsync(FetchRegulationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch specific Regulation Instance. </summary>
        /// <param name="pathSid"> The unique string that identifies the Regulation resource. </param>
        /// <param name="includeConstraints"> A boolean parameter indicating whether to include constraints or not for supporting end user, documents and their fields </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Regulation </returns>
        public static RegulationResource Fetch(
                                         string pathSid, 
                                         bool? includeConstraints = null, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchRegulationOptions(pathSid){ IncludeConstraints = includeConstraints };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch specific Regulation Instance. </summary>
        /// <param name="pathSid"> The unique string that identifies the Regulation resource. </param>
        /// <param name="includeConstraints"> A boolean parameter indicating whether to include constraints or not for supporting end user, documents and their fields </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Regulation </returns>
        public static async System.Threading.Tasks.Task<RegulationResource> FetchAsync(string pathSid, bool? includeConstraints = null, ITwilioRestClient client = null)
        {
            var options = new FetchRegulationOptions(pathSid){ IncludeConstraints = includeConstraints };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadRegulationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/RegulatoryCompliance/Regulations";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Numbers,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of all Regulations. </summary>
        /// <param name="options"> Read Regulation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Regulation </returns>
        public static ResourceSet<RegulationResource> Read(ReadRegulationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<RegulationResource>.FromJson("results", response.Content);
            return new ResourceSet<RegulationResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Regulations. </summary>
        /// <param name="options"> Read Regulation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Regulation </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<RegulationResource>> ReadAsync(ReadRegulationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<RegulationResource>.FromJson("results", response.Content);
            return new ResourceSet<RegulationResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of all Regulations. </summary>
        /// <param name="endUserType"> The type of End User the regulation requires - can be `individual` or `business`. </param>
        /// <param name="isoCountry"> The ISO country code of the phone number's country. </param>
        /// <param name="numberType"> The type of phone number that the regulatory requiremnt is restricting. </param>
        /// <param name="includeConstraints"> A boolean parameter indicating whether to include constraints or not for supporting end user, documents and their fields </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Regulation </returns>
        public static ResourceSet<RegulationResource> Read(
                                                     RegulationResource.EndUserTypeEnum endUserType = null,
                                                     string isoCountry = null,
                                                     string numberType = null,
                                                     bool? includeConstraints = null,
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadRegulationOptions(){ EndUserType = endUserType, IsoCountry = isoCountry, NumberType = numberType, IncludeConstraints = includeConstraints, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Regulations. </summary>
        /// <param name="endUserType"> The type of End User the regulation requires - can be `individual` or `business`. </param>
        /// <param name="isoCountry"> The ISO country code of the phone number's country. </param>
        /// <param name="numberType"> The type of phone number that the regulatory requiremnt is restricting. </param>
        /// <param name="includeConstraints"> A boolean parameter indicating whether to include constraints or not for supporting end user, documents and their fields </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Regulation </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<RegulationResource>> ReadAsync(
                                                                                             RegulationResource.EndUserTypeEnum endUserType = null,
                                                                                             string isoCountry = null,
                                                                                             string numberType = null,
                                                                                             bool? includeConstraints = null,
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadRegulationOptions(){ EndUserType = endUserType, IsoCountry = isoCountry, NumberType = numberType, IncludeConstraints = includeConstraints, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<RegulationResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<RegulationResource>.FromJson("results", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<RegulationResource> NextPage(Page<RegulationResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<RegulationResource>.FromJson("results", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<RegulationResource> PreviousPage(Page<RegulationResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<RegulationResource>.FromJson("results", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a RegulationResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> RegulationResource object represented by the provided JSON </returns>
        public static RegulationResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<RegulationResource>(json);
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

    
        ///<summary> The unique string that identifies the Regulation resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> A human-readable description that is assigned to describe the Regulation resource. Examples can include Germany: Mobile - Business. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> The ISO country code of the phone number's country. </summary> 
        [JsonProperty("iso_country")]
        public string IsoCountry { get; private set; }

        ///<summary> The type of phone number restricted by the regulatory requirement. For example, Germany mobile phone numbers provisioned by businesses require a business name with commercial register proof from the Handelsregisterauszug and a proof of address from Handelsregisterauszug or a trade license by Gewerbeanmeldung. </summary> 
        [JsonProperty("number_type")]
        public string NumberType { get; private set; }

        
        [JsonProperty("end_user_type")]
        public RegulationResource.EndUserTypeEnum EndUserType { get; private set; }

        ///<summary> The SID of an object that holds the regulatory information of the phone number country, phone number type, and end user type. </summary> 
        [JsonProperty("requirements")]
        public object Requirements { get; private set; }

        ///<summary> The absolute URL of the Regulation resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private RegulationResource() {

        }
    }
}

