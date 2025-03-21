/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Conversations
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



namespace Twilio.Rest.Conversations.V1
{
    public class ConfigurationResource : Resource
    {
    

    

        
        private static Request BuildFetchRequest(FetchConfigurationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Configuration";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Conversations,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch the global configuration of conversations on your account </summary>
        /// <param name="options"> Fetch Configuration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Configuration </returns>
        public static ConfigurationResource Fetch(FetchConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch the global configuration of conversations on your account </summary>
        /// <param name="options"> Fetch Configuration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Configuration </returns>
        public static async System.Threading.Tasks.Task<ConfigurationResource> FetchAsync(FetchConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch the global configuration of conversations on your account </summary>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Configuration </returns>
        public static ConfigurationResource Fetch(
                                        ITwilioRestClient client = null)
        {
            var options = new FetchConfigurationOptions(){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch the global configuration of conversations on your account </summary>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Configuration </returns>
        public static async System.Threading.Tasks.Task<ConfigurationResource> FetchAsync(ITwilioRestClient client = null)
        {
            var options = new FetchConfigurationOptions(){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildUpdateRequest(UpdateConfigurationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Configuration";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.Conversations,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Update the global configuration of conversations on your account </summary>
        /// <param name="options"> Update Configuration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Configuration </returns>
        public static ConfigurationResource Update(UpdateConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Update the global configuration of conversations on your account </summary>
        /// <param name="options"> Update Configuration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Configuration </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<ConfigurationResource> UpdateAsync(UpdateConfigurationOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Update the global configuration of conversations on your account </summary>
        /// <param name="defaultChatServiceSid"> The SID of the default [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) to use when creating a conversation. </param>
        /// <param name="defaultMessagingServiceSid"> The SID of the default [Messaging Service](https://www.twilio.com/docs/messaging/api/service-resource) to use when creating a conversation. </param>
        /// <param name="defaultInactiveTimer"> Default ISO8601 duration when conversation will be switched to `inactive` state. Minimum value for this timer is 1 minute. </param>
        /// <param name="defaultClosedTimer"> Default ISO8601 duration when conversation will be switched to `closed` state. Minimum value for this timer is 10 minutes. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Configuration </returns>
        public static ConfigurationResource Update(
                                          string defaultChatServiceSid = null,
                                          string defaultMessagingServiceSid = null,
                                          string defaultInactiveTimer = null,
                                          string defaultClosedTimer = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateConfigurationOptions(){ DefaultChatServiceSid = defaultChatServiceSid, DefaultMessagingServiceSid = defaultMessagingServiceSid, DefaultInactiveTimer = defaultInactiveTimer, DefaultClosedTimer = defaultClosedTimer };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Update the global configuration of conversations on your account </summary>
        /// <param name="defaultChatServiceSid"> The SID of the default [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) to use when creating a conversation. </param>
        /// <param name="defaultMessagingServiceSid"> The SID of the default [Messaging Service](https://www.twilio.com/docs/messaging/api/service-resource) to use when creating a conversation. </param>
        /// <param name="defaultInactiveTimer"> Default ISO8601 duration when conversation will be switched to `inactive` state. Minimum value for this timer is 1 minute. </param>
        /// <param name="defaultClosedTimer"> Default ISO8601 duration when conversation will be switched to `closed` state. Minimum value for this timer is 10 minutes. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Configuration </returns>
        public static async System.Threading.Tasks.Task<ConfigurationResource> UpdateAsync(
                                                                              string defaultChatServiceSid = null,
                                                                              string defaultMessagingServiceSid = null,
                                                                              string defaultInactiveTimer = null,
                                                                              string defaultClosedTimer = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateConfigurationOptions(){ DefaultChatServiceSid = defaultChatServiceSid, DefaultMessagingServiceSid = defaultMessagingServiceSid, DefaultInactiveTimer = defaultInactiveTimer, DefaultClosedTimer = defaultClosedTimer };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a ConfigurationResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ConfigurationResource object represented by the provided JSON </returns>
        public static ConfigurationResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<ConfigurationResource>(json);
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

    
        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) responsible for this configuration. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The SID of the default [Conversation Service](https://www.twilio.com/docs/conversations/api/service-resource) used when creating a conversation. </summary> 
        [JsonProperty("default_chat_service_sid")]
        public string DefaultChatServiceSid { get; private set; }

        ///<summary> The SID of the default [Messaging Service](https://www.twilio.com/docs/messaging/api/service-resource) used when creating a conversation. </summary> 
        [JsonProperty("default_messaging_service_sid")]
        public string DefaultMessagingServiceSid { get; private set; }

        ///<summary> Default ISO8601 duration when conversation will be switched to `inactive` state. Minimum value for this timer is 1 minute. </summary> 
        [JsonProperty("default_inactive_timer")]
        public string DefaultInactiveTimer { get; private set; }

        ///<summary> Default ISO8601 duration when conversation will be switched to `closed` state. Minimum value for this timer is 10 minutes. </summary> 
        [JsonProperty("default_closed_timer")]
        public string DefaultClosedTimer { get; private set; }

        ///<summary> An absolute API resource URL for this global configuration. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> Contains absolute API resource URLs to access the webhook and default service configurations. </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }



        private ConfigurationResource() {

        }
    }
}

