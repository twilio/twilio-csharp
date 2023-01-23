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
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;



namespace Twilio.Rest.Studio.V1.Flow.Engagement.Step
{
    public class StepContextResource : Resource
    {
    

        
        private static Request BuildFetchRequest(FetchStepContextOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Flows/{FlowSid}/Engagements/{EngagementSid}/Steps/{StepSid}/Context";

            string PathFlowSid = options.PathFlowSid;
            path = path.Replace("{"+"FlowSid"+"}", PathFlowSid);
            string PathEngagementSid = options.PathEngagementSid;
            path = path.Replace("{"+"EngagementSid"+"}", PathEngagementSid);
            string PathStepSid = options.PathStepSid;
            path = path.Replace("{"+"StepSid"+"}", PathStepSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Studio,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Retrieve the context for an Engagement Step. </summary>
        /// <param name="options"> Fetch StepContext parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of StepContext </returns>
        public static StepContextResource Fetch(FetchStepContextOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Retrieve the context for an Engagement Step. </summary>
        /// <param name="options"> Fetch StepContext parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of StepContext </returns>
        public static async System.Threading.Tasks.Task<StepContextResource> FetchAsync(FetchStepContextOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Retrieve the context for an Engagement Step. </summary>
        /// <param name="pathFlowSid"> The SID of the Flow with the Step to fetch. </param>
        /// <param name="pathEngagementSid"> The SID of the Engagement with the Step to fetch. </param>
        /// <param name="pathStepSid"> The SID of the Step to fetch </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of StepContext </returns>
        public static StepContextResource Fetch(
                                         string pathFlowSid, 
                                         string pathEngagementSid, 
                                         string pathStepSid, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchStepContextOptions(pathFlowSid, pathEngagementSid, pathStepSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Retrieve the context for an Engagement Step. </summary>
        /// <param name="pathFlowSid"> The SID of the Flow with the Step to fetch. </param>
        /// <param name="pathEngagementSid"> The SID of the Engagement with the Step to fetch. </param>
        /// <param name="pathStepSid"> The SID of the Step to fetch </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of StepContext </returns>
        public static async System.Threading.Tasks.Task<StepContextResource> FetchAsync(string pathFlowSid, string pathEngagementSid, string pathStepSid, ITwilioRestClient client = null)
        {
            var options = new FetchStepContextOptions(pathFlowSid, pathEngagementSid, pathStepSid){  };
            return await FetchAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a StepContextResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> StepContextResource object represented by the provided JSON </returns>
        public static StepContextResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<StepContextResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the StepContext resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The current state of the Flow's Execution. As a flow executes, we save its state in this context. We save data that your widgets can access as variables in configuration fields or in text areas as variable substitution. </summary> 
        [JsonProperty("context")]
        public object Context { get; private set; }

        ///<summary> The SID of the Engagement. </summary> 
        [JsonProperty("engagement_sid")]
        public string EngagementSid { get; private set; }

        ///<summary> The SID of the Flow. </summary> 
        [JsonProperty("flow_sid")]
        public string FlowSid { get; private set; }

        ///<summary> The SID of the Step the context is associated with. </summary> 
        [JsonProperty("step_sid")]
        public string StepSid { get; private set; }

        ///<summary> The absolute URL of the resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private StepContextResource() {

        }
    }
}

