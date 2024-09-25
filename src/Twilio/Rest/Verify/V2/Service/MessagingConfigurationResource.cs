/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Verify
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





namespace Twilio.Rest.Verify.V2.Service
{
    public class MessagingConfigurationResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreateMessagingConfigurationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/MessagingConfigurations";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Verify,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create a new MessagingConfiguration for a service. </summary>
        /// <param name="options"> Create MessagingConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of MessagingConfiguration </returns>
        public static MessagingConfigurationResource Create(CreateMessagingConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a new MessagingConfiguration for a service. </summary>
        /// <param name="options"> Create MessagingConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of MessagingConfiguration </returns>
        public static async System.Threading.Tasks.Task<MessagingConfigurationResource> CreateAsync(CreateMessagingConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a new MessagingConfiguration for a service. </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) that the resource is associated with. </param>
        /// <param name="country"> The [ISO-3166-1](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) country code of the country this configuration will be applied to. If this is a global configuration, Country will take the value `all`. </param>
        /// <param name="messagingServiceSid"> The SID of the [Messaging Service](https://www.twilio.com/docs/messaging/api/service-resource) to be used to send SMS to the country of this configuration. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of MessagingConfiguration </returns>
        public static MessagingConfigurationResource Create(
                                          string pathServiceSid,
                                          string country,
                                          string messagingServiceSid,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateMessagingConfigurationOptions(pathServiceSid, country, messagingServiceSid){  };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a new MessagingConfiguration for a service. </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) that the resource is associated with. </param>
        /// <param name="country"> The [ISO-3166-1](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) country code of the country this configuration will be applied to. If this is a global configuration, Country will take the value `all`. </param>
        /// <param name="messagingServiceSid"> The SID of the [Messaging Service](https://www.twilio.com/docs/messaging/api/service-resource) to be used to send SMS to the country of this configuration. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of MessagingConfiguration </returns>
        public static async System.Threading.Tasks.Task<MessagingConfigurationResource> CreateAsync(
                                                                                  string pathServiceSid,
                                                                                  string country,
                                                                                  string messagingServiceSid,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateMessagingConfigurationOptions(pathServiceSid, country, messagingServiceSid){  };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> Delete a specific MessagingConfiguration. </summary>
        /// <param name="options"> Delete MessagingConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of MessagingConfiguration </returns>
        private static Request BuildDeleteRequest(DeleteMessagingConfigurationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/MessagingConfigurations/{Country}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathCountry = options.PathCountry;
            path = path.Replace("{"+"Country"+"}", PathCountry);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Verify,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Delete a specific MessagingConfiguration. </summary>
        /// <param name="options"> Delete MessagingConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of MessagingConfiguration </returns>
        public static bool Delete(DeleteMessagingConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Delete a specific MessagingConfiguration. </summary>
        /// <param name="options"> Delete MessagingConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of MessagingConfiguration </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteMessagingConfigurationOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Delete a specific MessagingConfiguration. </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) that the resource is associated with. </param>
        /// <param name="pathCountry"> The [ISO-3166-1](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) country code of the country this configuration will be applied to. If this is a global configuration, Country will take the value `all`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of MessagingConfiguration </returns>
        public static bool Delete(string pathServiceSid, string pathCountry, ITwilioRestClient client = null)
        {
            var options = new DeleteMessagingConfigurationOptions(pathServiceSid, pathCountry)        ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Delete a specific MessagingConfiguration. </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) that the resource is associated with. </param>
        /// <param name="pathCountry"> The [ISO-3166-1](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) country code of the country this configuration will be applied to. If this is a global configuration, Country will take the value `all`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of MessagingConfiguration </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid, string pathCountry, ITwilioRestClient client = null)
        {
            var options = new DeleteMessagingConfigurationOptions(pathServiceSid, pathCountry) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchMessagingConfigurationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/MessagingConfigurations/{Country}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathCountry = options.PathCountry;
            path = path.Replace("{"+"Country"+"}", PathCountry);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Verify,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a specific MessagingConfiguration. </summary>
        /// <param name="options"> Fetch MessagingConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of MessagingConfiguration </returns>
        public static MessagingConfigurationResource Fetch(FetchMessagingConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a specific MessagingConfiguration. </summary>
        /// <param name="options"> Fetch MessagingConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of MessagingConfiguration </returns>
        public static async System.Threading.Tasks.Task<MessagingConfigurationResource> FetchAsync(FetchMessagingConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a specific MessagingConfiguration. </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) that the resource is associated with. </param>
        /// <param name="pathCountry"> The [ISO-3166-1](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) country code of the country this configuration will be applied to. If this is a global configuration, Country will take the value `all`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of MessagingConfiguration </returns>
        public static MessagingConfigurationResource Fetch(
                                         string pathServiceSid, 
                                         string pathCountry, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchMessagingConfigurationOptions(pathServiceSid, pathCountry){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a specific MessagingConfiguration. </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) that the resource is associated with. </param>
        /// <param name="pathCountry"> The [ISO-3166-1](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) country code of the country this configuration will be applied to. If this is a global configuration, Country will take the value `all`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of MessagingConfiguration </returns>
        public static async System.Threading.Tasks.Task<MessagingConfigurationResource> FetchAsync(string pathServiceSid, string pathCountry, ITwilioRestClient client = null)
        {
            var options = new FetchMessagingConfigurationOptions(pathServiceSid, pathCountry){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadMessagingConfigurationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/MessagingConfigurations";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Verify,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of all Messaging Configurations for a Service. </summary>
        /// <param name="options"> Read MessagingConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of MessagingConfiguration </returns>
        public static ResourceSet<MessagingConfigurationResource> Read(ReadMessagingConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<MessagingConfigurationResource>.FromJson("messaging_configurations", response.Content);
            return new ResourceSet<MessagingConfigurationResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Messaging Configurations for a Service. </summary>
        /// <param name="options"> Read MessagingConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of MessagingConfiguration </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<MessagingConfigurationResource>> ReadAsync(ReadMessagingConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<MessagingConfigurationResource>.FromJson("messaging_configurations", response.Content);
            return new ResourceSet<MessagingConfigurationResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of all Messaging Configurations for a Service. </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) that the resource is associated with. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of MessagingConfiguration </returns>
        public static ResourceSet<MessagingConfigurationResource> Read(
                                                     string pathServiceSid,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadMessagingConfigurationOptions(pathServiceSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of all Messaging Configurations for a Service. </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) that the resource is associated with. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of MessagingConfiguration </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<MessagingConfigurationResource>> ReadAsync(
                                                                                             string pathServiceSid,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadMessagingConfigurationOptions(pathServiceSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<MessagingConfigurationResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<MessagingConfigurationResource>.FromJson("messaging_configurations", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<MessagingConfigurationResource> NextPage(Page<MessagingConfigurationResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<MessagingConfigurationResource>.FromJson("messaging_configurations", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<MessagingConfigurationResource> PreviousPage(Page<MessagingConfigurationResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<MessagingConfigurationResource>.FromJson("messaging_configurations", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateMessagingConfigurationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/MessagingConfigurations/{Country}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathCountry = options.PathCountry;
            path = path.Replace("{"+"Country"+"}", PathCountry);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Verify,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Update a specific MessagingConfiguration </summary>
        /// <param name="options"> Update MessagingConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of MessagingConfiguration </returns>
        public static MessagingConfigurationResource Update(UpdateMessagingConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Update a specific MessagingConfiguration </summary>
        /// <param name="options"> Update MessagingConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of MessagingConfiguration </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<MessagingConfigurationResource> UpdateAsync(UpdateMessagingConfigurationOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Update a specific MessagingConfiguration </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) that the resource is associated with. </param>
        /// <param name="pathCountry"> The [ISO-3166-1](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) country code of the country this configuration will be applied to. If this is a global configuration, Country will take the value `all`. </param>
        /// <param name="messagingServiceSid"> The SID of the [Messaging Service](https://www.twilio.com/docs/messaging/api/service-resource) to be used to send SMS to the country of this configuration. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of MessagingConfiguration </returns>
        public static MessagingConfigurationResource Update(
                                          string pathServiceSid,
                                          string pathCountry,
                                          string messagingServiceSid,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateMessagingConfigurationOptions(pathServiceSid, pathCountry, messagingServiceSid){  };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Update a specific MessagingConfiguration </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) that the resource is associated with. </param>
        /// <param name="pathCountry"> The [ISO-3166-1](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) country code of the country this configuration will be applied to. If this is a global configuration, Country will take the value `all`. </param>
        /// <param name="messagingServiceSid"> The SID of the [Messaging Service](https://www.twilio.com/docs/messaging/api/service-resource) to be used to send SMS to the country of this configuration. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of MessagingConfiguration </returns>
        public static async System.Threading.Tasks.Task<MessagingConfigurationResource> UpdateAsync(
                                                                              string pathServiceSid,
                                                                              string pathCountry,
                                                                              string messagingServiceSid,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateMessagingConfigurationOptions(pathServiceSid, pathCountry, messagingServiceSid){  };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a MessagingConfigurationResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> MessagingConfigurationResource object represented by the provided JSON </returns>
        public static MessagingConfigurationResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessagingConfigurationResource>(json);
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

    
        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Service resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The SID of the [Service](https://www.twilio.com/docs/verify/api/service) that the resource is associated with. </summary> 
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }

        ///<summary> The [ISO-3166-1](https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2) country code of the country this configuration will be applied to. If this is a global configuration, Country will take the value `all`. </summary> 
        [JsonProperty("country")]
        public string Country { get; private set; }

        ///<summary> The SID of the [Messaging Service](https://www.twilio.com/docs/messaging/api/service-resource) to be used to send SMS to the country of this configuration. </summary> 
        [JsonProperty("messaging_service_sid")]
        public string MessagingServiceSid { get; private set; }

        ///<summary> The date and time in GMT when the resource was created specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the resource was last updated specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The URL of this resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private MessagingConfigurationResource() {

        }
    }
}

