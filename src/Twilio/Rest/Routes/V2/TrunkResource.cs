/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Routes
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





namespace Twilio.Rest.Routes.V2
{
    public class TrunkResource : Resource
    {
    

    

        
        private static Request BuildFetchRequest(FetchTrunkOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Trunks/{SipTrunkDomain}";

            string PathSipTrunkDomain = options.PathSipTrunkDomain;
            path = path.Replace("{"+"SipTrunkDomain"+"}", PathSipTrunkDomain);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Routes,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch the Inbound Processing Region assigned to a SIP Trunk. </summary>
        /// <param name="options"> Fetch Trunk parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Trunk </returns>
        public static TrunkResource Fetch(FetchTrunkOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch the Inbound Processing Region assigned to a SIP Trunk. </summary>
        /// <param name="options"> Fetch Trunk parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Trunk </returns>
        public static async System.Threading.Tasks.Task<TrunkResource> FetchAsync(FetchTrunkOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch the Inbound Processing Region assigned to a SIP Trunk. </summary>
        /// <param name="pathSipTrunkDomain"> The absolute URL of the SIP Trunk </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Trunk </returns>
        public static TrunkResource Fetch(
                                         string pathSipTrunkDomain, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchTrunkOptions(pathSipTrunkDomain){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch the Inbound Processing Region assigned to a SIP Trunk. </summary>
        /// <param name="pathSipTrunkDomain"> The absolute URL of the SIP Trunk </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Trunk </returns>
        public static async System.Threading.Tasks.Task<TrunkResource> FetchAsync(string pathSipTrunkDomain, ITwilioRestClient client = null)
        {
            var options = new FetchTrunkOptions(pathSipTrunkDomain){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildUpdateRequest(UpdateTrunkOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Trunks/{SipTrunkDomain}";

            string PathSipTrunkDomain = options.PathSipTrunkDomain;
            path = path.Replace("{"+"SipTrunkDomain"+"}", PathSipTrunkDomain);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Routes,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Assign an Inbound Processing Region to a SIP Trunk </summary>
        /// <param name="options"> Update Trunk parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Trunk </returns>
        public static TrunkResource Update(UpdateTrunkOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Assign an Inbound Processing Region to a SIP Trunk </summary>
        /// <param name="options"> Update Trunk parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Trunk </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<TrunkResource> UpdateAsync(UpdateTrunkOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Assign an Inbound Processing Region to a SIP Trunk </summary>
        /// <param name="pathSipTrunkDomain"> The absolute URL of the SIP Trunk </param>
        /// <param name="voiceRegion"> The Inbound Processing Region used for this SIP Trunk for voice </param>
        /// <param name="friendlyName"> A human readable description of this resource, up to 64 characters. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Trunk </returns>
        public static TrunkResource Update(
                                          string pathSipTrunkDomain,
                                          string voiceRegion = null,
                                          string friendlyName = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateTrunkOptions(pathSipTrunkDomain){ VoiceRegion = voiceRegion, FriendlyName = friendlyName };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Assign an Inbound Processing Region to a SIP Trunk </summary>
        /// <param name="pathSipTrunkDomain"> The absolute URL of the SIP Trunk </param>
        /// <param name="voiceRegion"> The Inbound Processing Region used for this SIP Trunk for voice </param>
        /// <param name="friendlyName"> A human readable description of this resource, up to 64 characters. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Trunk </returns>
        public static async System.Threading.Tasks.Task<TrunkResource> UpdateAsync(
                                                                              string pathSipTrunkDomain,
                                                                              string voiceRegion = null,
                                                                              string friendlyName = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateTrunkOptions(pathSipTrunkDomain){ VoiceRegion = voiceRegion, FriendlyName = friendlyName };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a TrunkResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> TrunkResource object represented by the provided JSON </returns>
        public static TrunkResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<TrunkResource>(json);
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

    
        ///<summary> The absolute URL of the SIP Trunk </summary> 
        [JsonProperty("sip_trunk_domain")]
        public string SipTrunkDomain { get; private set; }

        ///<summary> The absolute URL of the resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> A 34 character string that uniquely identifies the Inbound Processing Region assignments for this SIP Trunk. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The unique SID identifier of the Account. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> A human readable description of the Inbound Processing Region assignments for this SIP Trunk, up to 64 characters. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> The Inbound Processing Region used for this SIP Trunk for voice. </summary> 
        [JsonProperty("voice_region")]
        public string VoiceRegion { get; private set; }

        ///<summary> The date that this SIP Trunk was assigned an Inbound Processing Region, given in ISO 8601 format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date that the Inbound Processing Region was updated for this SIP Trunk, given in ISO 8601 format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }



        private TrunkResource() {

        }
    }
}

