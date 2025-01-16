/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Flex
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



namespace Twilio.Rest.FlexApi.V1
{
    public class PluginArchiveResource : Resource
    {
    

    

        
        private static Request BuildUpdateRequest(UpdatePluginArchiveOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/PluginService/Plugins/{Sid}/Archive";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.FlexApi,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: options.GetHeaderParams()
            );
        }

        /// <summary> update </summary>
        /// <param name="options"> Update PluginArchive parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PluginArchive </returns>
        public static PluginArchiveResource Update(UpdatePluginArchiveOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> update </summary>
        /// <param name="options"> Update PluginArchive parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PluginArchive </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<PluginArchiveResource> UpdateAsync(UpdatePluginArchiveOptions options, 
                                                                                                    ITwilioRestClient client = null,
                                                                                                    System.Threading.CancellationToken cancellationToken = default)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client), cancellationToken);
            return FromJson(response.Content);
        }
        #endif

        /// <summary> update </summary>
        /// <param name="pathSid"> The SID of the Flex Plugin resource to archive. </param>
        /// <param name="flexMetadata"> The Flex-Metadata HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of PluginArchive </returns>
        public static PluginArchiveResource Update(
                                          string pathSid,
                                          string flexMetadata = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdatePluginArchiveOptions(pathSid){ FlexMetadata = flexMetadata };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> update </summary>
        /// <param name="pathSid"> The SID of the Flex Plugin resource to archive. </param>
        /// <param name="flexMetadata"> The Flex-Metadata HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of PluginArchive </returns>
        public static async System.Threading.Tasks.Task<PluginArchiveResource> UpdateAsync(
                                                                              string pathSid,
                                                                              string flexMetadata = null,
                                                                                ITwilioRestClient client = null , System.Threading.CancellationToken cancellationToken = default)
        {
            var options = new UpdatePluginArchiveOptions(pathSid){ FlexMetadata = flexMetadata };
            return await UpdateAsync(options, client, cancellationToken);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a PluginArchiveResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> PluginArchiveResource object represented by the provided JSON </returns>
        public static PluginArchiveResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<PluginArchiveResource>(json);
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

    
        ///<summary> The unique string that we created to identify the Flex Plugin resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Flex Plugin resource and owns this resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The name that uniquely identifies this Flex Plugin resource. </summary> 
        [JsonProperty("unique_name")]
        public string UniqueName { get; private set; }

        ///<summary> The friendly name this Flex Plugin resource. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> A descriptive string that you create to describe the plugin resource. It can be up to 500 characters long </summary> 
        [JsonProperty("description")]
        public string Description { get; private set; }

        ///<summary> Whether the Flex Plugin is archived. The default value is false. </summary> 
        [JsonProperty("archived")]
        public bool? Archived { get; private set; }

        ///<summary> The date and time in GMT when the Flex Plugin was created specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the Flex Plugin was last updated specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The absolute URL of the Flex Plugin resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private PluginArchiveResource() {

        }
    }
}

