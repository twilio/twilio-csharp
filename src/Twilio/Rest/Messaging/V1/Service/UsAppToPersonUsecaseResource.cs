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





namespace Twilio.Rest.Messaging.V1.Service
{
    public class UsAppToPersonUsecaseResource : Resource
    {
    

    

        
        private static Request BuildFetchRequest(FetchUsAppToPersonUsecaseOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{MessagingServiceSid}/Compliance/Usa2p/Usecases";

            string PathMessagingServiceSid = options.PathMessagingServiceSid;
            path = path.Replace("{"+"MessagingServiceSid"+"}", PathMessagingServiceSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Messaging,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> fetch </summary>
        /// <param name="options"> Fetch UsAppToPersonUsecase parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UsAppToPersonUsecase </returns>
        public static UsAppToPersonUsecaseResource Fetch(FetchUsAppToPersonUsecaseOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch UsAppToPersonUsecase parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UsAppToPersonUsecase </returns>
        public static async System.Threading.Tasks.Task<UsAppToPersonUsecaseResource> FetchAsync(FetchUsAppToPersonUsecaseOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Messaging Service](https://www.twilio.com/docs/messaging/api/service-resource) to fetch the resource from. </param>
        /// <param name="brandRegistrationSid"> The unique string to identify the A2P brand. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UsAppToPersonUsecase </returns>
        public static UsAppToPersonUsecaseResource Fetch(
                                         string pathMessagingServiceSid, 
                                         string brandRegistrationSid = null, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchUsAppToPersonUsecaseOptions(pathMessagingServiceSid){ BrandRegistrationSid = brandRegistrationSid };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Messaging Service](https://www.twilio.com/docs/messaging/api/service-resource) to fetch the resource from. </param>
        /// <param name="brandRegistrationSid"> The unique string to identify the A2P brand. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UsAppToPersonUsecase </returns>
        public static async System.Threading.Tasks.Task<UsAppToPersonUsecaseResource> FetchAsync(string pathMessagingServiceSid, string brandRegistrationSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchUsAppToPersonUsecaseOptions(pathMessagingServiceSid){ BrandRegistrationSid = brandRegistrationSid };
            return await FetchAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a UsAppToPersonUsecaseResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> UsAppToPersonUsecaseResource object represented by the provided JSON </returns>
        public static UsAppToPersonUsecaseResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<UsAppToPersonUsecaseResource>(json);
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

    
        ///<summary> Human readable name, code, description and post_approval_required (indicates whether or not post approval is required for this Use Case) of A2P Campaign Use Cases. </summary> 
        [JsonProperty("us_app_to_person_usecases")]
        public List<object> UsAppToPersonUsecases { get; private set; }



        private UsAppToPersonUsecaseResource() {

        }
    }
}

