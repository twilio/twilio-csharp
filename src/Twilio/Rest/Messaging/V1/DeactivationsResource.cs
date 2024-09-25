/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Messaging
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





namespace Twilio.Rest.Messaging.V1
{
    public class DeactivationsResource : Resource
    {
    

    

        
        private static Request BuildFetchRequest(FetchDeactivationsOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Deactivations";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Messaging,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch a list of all United States numbers that have been deactivated on a specific date. </summary>
        /// <param name="options"> Fetch Deactivations parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Deactivations </returns>
        public static DeactivationsResource Fetch(FetchDeactivationsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch a list of all United States numbers that have been deactivated on a specific date. </summary>
        /// <param name="options"> Fetch Deactivations parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Deactivations </returns>
        public static async System.Threading.Tasks.Task<DeactivationsResource> FetchAsync(FetchDeactivationsOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch a list of all United States numbers that have been deactivated on a specific date. </summary>
        /// <param name="date"> The request will return a list of all United States Phone Numbers that were deactivated on the day specified by this parameter. This date should be specified in YYYY-MM-DD format. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Deactivations </returns>
        public static DeactivationsResource Fetch(
                                         DateTime? date = null, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchDeactivationsOptions(){ Date = date };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch a list of all United States numbers that have been deactivated on a specific date. </summary>
        /// <param name="date"> The request will return a list of all United States Phone Numbers that were deactivated on the day specified by this parameter. This date should be specified in YYYY-MM-DD format. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Deactivations </returns>
        public static async System.Threading.Tasks.Task<DeactivationsResource> FetchAsync(DateTime? date = null, ITwilioRestClient client = null)
        {
            var options = new FetchDeactivationsOptions(){ Date = date };
            return await FetchAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a DeactivationsResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> DeactivationsResource object represented by the provided JSON </returns>
        public static DeactivationsResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<DeactivationsResource>(json);
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

    
        ///<summary> Returns an authenticated url that redirects to a file containing the deactivated numbers for the requested day. This url is valid for up to two minutes. </summary> 
        [JsonProperty("redirect_to")]
        public Uri RedirectTo { get; private set; }



        private DeactivationsResource() {

        }
    }
}

