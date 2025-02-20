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



namespace Twilio.Rest.Verify.V2
{
    public class TemplateResource : Resource
    {
    

    

        
        private static Request BuildReadRequest(ReadTemplateOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Templates";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Verify,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> List all the available templates for a given Account. </summary>
        /// <param name="options"> Read Template parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Template </returns>
        public static ResourceSet<TemplateResource> Read(ReadTemplateOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<TemplateResource>.FromJson("templates", response.Content);
            return new ResourceSet<TemplateResource>(page, options, client);
        }

        #if !NET35
        /// <summary> List all the available templates for a given Account. </summary>
        /// <param name="options"> Read Template parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Template </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<TemplateResource>> ReadAsync(ReadTemplateOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<TemplateResource>.FromJson("templates", response.Content);
            return new ResourceSet<TemplateResource>(page, options, client);
        }
        #endif
        /// <summary> List all the available templates for a given Account. </summary>
        /// <param name="friendlyName"> String filter used to query templates with a given friendly name. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Template </returns>
        public static ResourceSet<TemplateResource> Read(
                                                     string friendlyName = null,
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadTemplateOptions(){ FriendlyName = friendlyName, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> List all the available templates for a given Account. </summary>
        /// <param name="friendlyName"> String filter used to query templates with a given friendly name. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Template </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<TemplateResource>> ReadAsync(
                                                                                             string friendlyName = null,
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadTemplateOptions(){ FriendlyName = friendlyName, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<TemplateResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<TemplateResource>.FromJson("templates", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<TemplateResource> NextPage(Page<TemplateResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<TemplateResource>.FromJson("templates", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<TemplateResource> PreviousPage(Page<TemplateResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<TemplateResource>.FromJson("templates", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a TemplateResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TemplateResource object represented by the provided JSON </returns>
        public static TemplateResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<TemplateResource>(json);
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

    
        ///<summary> A 34 character string that uniquely identifies a Verification Template. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The unique SID identifier of the Account. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> A descriptive string that you create to describe a Template. It can be up to 32 characters long. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> A list of channels that support the Template. Can include: sms, voice. </summary> 
        [JsonProperty("channels")]
        public List<string> Channels { get; private set; }

        ///<summary> An object that contains the different translations of the template. Every translation is identified by the language short name and contains its respective information as the approval status, text and created/modified date. </summary> 
        [JsonProperty("translations")]
        public object Translations { get; private set; }



        private TemplateResource() {

        }
    }
}

