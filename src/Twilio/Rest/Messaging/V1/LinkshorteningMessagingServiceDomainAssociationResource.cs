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
    public class LinkshorteningMessagingServiceDomainAssociationResource : Resource
    {
    

    

        
        private static Request BuildFetchRequest(FetchLinkshorteningMessagingServiceDomainAssociationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/LinkShortening/MessagingServices/{MessagingServiceSid}/Domain";

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
        /// <param name="options"> Fetch LinkshorteningMessagingServiceDomainAssociation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of LinkshorteningMessagingServiceDomainAssociation </returns>
        public static LinkshorteningMessagingServiceDomainAssociationResource Fetch(FetchLinkshorteningMessagingServiceDomainAssociationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch LinkshorteningMessagingServiceDomainAssociation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of LinkshorteningMessagingServiceDomainAssociation </returns>
        public static async System.Threading.Tasks.Task<LinkshorteningMessagingServiceDomainAssociationResource> FetchAsync(FetchLinkshorteningMessagingServiceDomainAssociationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathMessagingServiceSid"> Unique string used to identify the Messaging service that this domain should be associated with. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of LinkshorteningMessagingServiceDomainAssociation </returns>
        public static LinkshorteningMessagingServiceDomainAssociationResource Fetch(
                                         string pathMessagingServiceSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchLinkshorteningMessagingServiceDomainAssociationOptions(pathMessagingServiceSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathMessagingServiceSid"> Unique string used to identify the Messaging service that this domain should be associated with. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of LinkshorteningMessagingServiceDomainAssociation </returns>
        public static async System.Threading.Tasks.Task<LinkshorteningMessagingServiceDomainAssociationResource> FetchAsync(string pathMessagingServiceSid, ITwilioRestClient client = null)
        {
            var options = new FetchLinkshorteningMessagingServiceDomainAssociationOptions(pathMessagingServiceSid){  };
            return await FetchAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a LinkshorteningMessagingServiceDomainAssociationResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> LinkshorteningMessagingServiceDomainAssociationResource object represented by the provided JSON </returns>
        public static LinkshorteningMessagingServiceDomainAssociationResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<LinkshorteningMessagingServiceDomainAssociationResource>(json);
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

    
        ///<summary> The unique string that we created to identify the Domain resource. </summary> 
        [JsonProperty("domain_sid")]
        public string DomainSid { get; private set; }

        ///<summary> The unique string that identifies the messaging service </summary> 
        [JsonProperty("messaging_service_sid")]
        public string MessagingServiceSid { get; private set; }

        ///<summary> The url </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private LinkshorteningMessagingServiceDomainAssociationResource() {

        }
    }
}

