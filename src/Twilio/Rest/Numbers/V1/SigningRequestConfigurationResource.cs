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





namespace Twilio.Rest.Numbers.V1
{
    public class SigningRequestConfigurationResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreateSigningRequestConfigurationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/SigningRequest/Configuration";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.Numbers,
                path,

                contentType: EnumConstants.ContentTypeEnum.JSON,
                body: options.GetBody(),
                headerParams: null
            );
        }

        /// <summary> Synchronous operation to insert or update a configuration for the customer. </summary>
        /// <param name="options"> Create SigningRequestConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SigningRequestConfiguration </returns>
        public static SigningRequestConfigurationResource Create(CreateSigningRequestConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Synchronous operation to insert or update a configuration for the customer. </summary>
        /// <param name="options"> Create SigningRequestConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SigningRequestConfiguration </returns>
        public static async System.Threading.Tasks.Task<SigningRequestConfigurationResource> CreateAsync(CreateSigningRequestConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Synchronous operation to insert or update a configuration for the customer. </summary>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SigningRequestConfiguration </returns>
        public static SigningRequestConfigurationResource Create(
                                            ITwilioRestClient client = null)
        {
            var options = new CreateSigningRequestConfigurationOptions(){  };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Synchronous operation to insert or update a configuration for the customer. </summary>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SigningRequestConfiguration </returns>
        public static async System.Threading.Tasks.Task<SigningRequestConfigurationResource> CreateAsync(
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateSigningRequestConfigurationOptions(){  };
            return await CreateAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadSigningRequestConfigurationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/SigningRequest/Configuration";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Numbers,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Synchronous operation to retrieve configurations for the customer. </summary>
        /// <param name="options"> Read SigningRequestConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SigningRequestConfiguration </returns>
        public static ResourceSet<SigningRequestConfigurationResource> Read(ReadSigningRequestConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<SigningRequestConfigurationResource>.FromJson("configurations", response.Content);
            return new ResourceSet<SigningRequestConfigurationResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Synchronous operation to retrieve configurations for the customer. </summary>
        /// <param name="options"> Read SigningRequestConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SigningRequestConfiguration </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<SigningRequestConfigurationResource>> ReadAsync(ReadSigningRequestConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<SigningRequestConfigurationResource>.FromJson("configurations", response.Content);
            return new ResourceSet<SigningRequestConfigurationResource>(page, options, client);
        }
        #endif
        /// <summary> Synchronous operation to retrieve configurations for the customer. </summary>
        /// <param name="country"> The country ISO code to apply this configuration, this is an optional field, Example: US, MX </param>
        /// <param name="product"> The product or service for which is requesting the signature, this is an optional field, Example: Porting, Hosting </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of SigningRequestConfiguration </returns>
        public static ResourceSet<SigningRequestConfigurationResource> Read(
                                                     string country = null,
                                                     string product = null,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadSigningRequestConfigurationOptions(){ Country = country, Product = product, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Synchronous operation to retrieve configurations for the customer. </summary>
        /// <param name="country"> The country ISO code to apply this configuration, this is an optional field, Example: US, MX </param>
        /// <param name="product"> The product or service for which is requesting the signature, this is an optional field, Example: Porting, Hosting </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of SigningRequestConfiguration </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<SigningRequestConfigurationResource>> ReadAsync(
                                                                                             string country = null,
                                                                                             string product = null,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadSigningRequestConfigurationOptions(){ Country = country, Product = product, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<SigningRequestConfigurationResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<SigningRequestConfigurationResource>.FromJson("configurations", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<SigningRequestConfigurationResource> NextPage(Page<SigningRequestConfigurationResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<SigningRequestConfigurationResource>.FromJson("configurations", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<SigningRequestConfigurationResource> PreviousPage(Page<SigningRequestConfigurationResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<SigningRequestConfigurationResource>.FromJson("configurations", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a SigningRequestConfigurationResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SigningRequestConfigurationResource object represented by the provided JSON </returns>
        public static SigningRequestConfigurationResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<SigningRequestConfigurationResource>(json);
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

    
        ///<summary> The SID of the document  that includes the logo that will appear in the LOA. To upload documents follow the following guide: https://www.twilio.com/docs/phone-numbers/regulatory/getting-started/create-new-bundle-public-rest-apis#supporting-document-create  </summary> 
        [JsonProperty("logo_sid")]
        public string LogoSid { get; private set; }

        ///<summary> This is the string that you assigned as a friendly name for describing the creation of the configuration. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> The product or service for which is requesting the signature. </summary> 
        [JsonProperty("product")]
        public string Product { get; private set; }

        ///<summary> The country ISO code to apply the configuration. </summary> 
        [JsonProperty("country")]
        public string Country { get; private set; }

        ///<summary> Subject of the email that the end client will receive ex: “Twilio Hosting Request”, maximum length of 255 characters. </summary> 
        [JsonProperty("email_subject")]
        public string EmailSubject { get; private set; }

        ///<summary> Content of the email that the end client will receive ex: “This is a Hosting request from Twilio, please check the document and sign it”, maximum length of 5,000 characters. </summary> 
        [JsonProperty("email_message")]
        public string EmailMessage { get; private set; }

        ///<summary> Url the end client will be redirected after signing a document. </summary> 
        [JsonProperty("url_redirection")]
        public string UrlRedirection { get; private set; }

        ///<summary> The url </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private SigningRequestConfigurationResource() {

        }
    }
}

