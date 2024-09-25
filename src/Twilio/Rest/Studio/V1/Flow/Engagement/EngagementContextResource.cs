/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Studio
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





namespace Twilio.Rest.Studio.V1.Flow.Engagement
{
    public class EngagementContextResource : Resource
    {
    

    

        
        private static Request BuildFetchRequest(FetchEngagementContextOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Flows/{FlowSid}/Engagements/{EngagementSid}/Context";

            string PathFlowSid = options.PathFlowSid;
            path = path.Replace("{"+"FlowSid"+"}", PathFlowSid);
            string PathEngagementSid = options.PathEngagementSid;
            path = path.Replace("{"+"EngagementSid"+"}", PathEngagementSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Studio,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Retrieve the most recent context for an Engagement. </summary>
        /// <param name="options"> Fetch EngagementContext parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of EngagementContext </returns>
        public static EngagementContextResource Fetch(FetchEngagementContextOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Retrieve the most recent context for an Engagement. </summary>
        /// <param name="options"> Fetch EngagementContext parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of EngagementContext </returns>
        public static async System.Threading.Tasks.Task<EngagementContextResource> FetchAsync(FetchEngagementContextOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Retrieve the most recent context for an Engagement. </summary>
        /// <param name="pathFlowSid"> The SID of the Flow. </param>
        /// <param name="pathEngagementSid"> The SID of the Engagement. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of EngagementContext </returns>
        public static EngagementContextResource Fetch(
                                         string pathFlowSid, 
                                         string pathEngagementSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchEngagementContextOptions(pathFlowSid, pathEngagementSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Retrieve the most recent context for an Engagement. </summary>
        /// <param name="pathFlowSid"> The SID of the Flow. </param>
        /// <param name="pathEngagementSid"> The SID of the Engagement. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of EngagementContext </returns>
        public static async System.Threading.Tasks.Task<EngagementContextResource> FetchAsync(string pathFlowSid, string pathEngagementSid, ITwilioRestClient client = null)
        {
            var options = new FetchEngagementContextOptions(pathFlowSid, pathEngagementSid){  };
            return await FetchAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a EngagementContextResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> EngagementContextResource object represented by the provided JSON </returns>
        public static EngagementContextResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<EngagementContextResource>(json);
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

    
        ///<summary> The SID of the Account. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> As your flow executes, we save the state in what's called the Flow Context. Any data in the flow context can be accessed by your widgets as variables, either in configuration fields or in text areas as variable substitution. </summary> 
        [JsonProperty("context")]
        public object Context { get; private set; }

        ///<summary> The SID of the Engagement. </summary> 
        [JsonProperty("engagement_sid")]
        public string EngagementSid { get; private set; }

        ///<summary> The SID of the Flow. </summary> 
        [JsonProperty("flow_sid")]
        public string FlowSid { get; private set; }

        ///<summary> The URL of the resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private EngagementContextResource() {

        }
    }
}

