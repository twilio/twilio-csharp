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
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;



namespace Twilio.Rest.Messaging.V1.Service
{
    public class UsAppToPersonResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreateUsAppToPersonOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{MessagingServiceSid}/Compliance/Usa2p";

            string PathMessagingServiceSid = options.PathMessagingServiceSid;
            path = path.Replace("{"+"MessagingServiceSid"+"}", PathMessagingServiceSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Messaging,
                path,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> create </summary>
        /// <param name="options"> Create UsAppToPerson parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UsAppToPerson </returns>
        public static UsAppToPersonResource Create(CreateUsAppToPersonOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="options"> Create UsAppToPerson parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UsAppToPerson </returns>
        public static async System.Threading.Tasks.Task<UsAppToPersonResource> CreateAsync(CreateUsAppToPersonOptions options,
        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> create </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Messaging Service](https://www.twilio.com/docs/messaging/services/api) to create the resources from. </param>
        /// <param name="brandRegistrationSid"> A2P Brand Registration SID </param>
        /// <param name="description"> A short description of what this SMS campaign does. Min length: 40 characters. Max length: 4096 characters. </param>
        /// <param name="messageFlow"> Required for all Campaigns. Details around how a consumer opts-in to their campaign, therefore giving consent to receive their messages. If multiple opt-in methods can be used for the same campaign, they must all be listed. 40 character minimum. 2048 character maximum. </param>
        /// <param name="messageSamples"> Message samples, at least 1 and up to 5 sample messages (at least 2 for sole proprietor), >=20 chars, <=1024 chars each. </param>
        /// <param name="usAppToPersonUsecase"> A2P Campaign Use Case. Examples: [ 2FA, EMERGENCY, MARKETING..] </param>
        /// <param name="hasEmbeddedLinks"> Indicates that this SMS campaign will send messages that contain links. </param>
        /// <param name="hasEmbeddedPhone"> Indicates that this SMS campaign will send messages that contain phone numbers. </param>
        /// <param name="optInMessage"> If end users can text in a keyword to start receiving messages from this campaign, the auto-reply messages sent to the end users must be provided. The opt-in response should include the Brand name, confirmation of opt-in enrollment to a recurring message campaign, how to get help, and clear description of how to opt-out. This field is required if end users can text in a keyword to start receiving messages from this campaign. 20 character minimum. 320 character maximum. </param>
        /// <param name="optOutMessage"> Upon receiving the opt-out keywords from the end users, Twilio customers are expected to send back an auto-generated response, which must provide acknowledgment of the opt-out request and confirmation that no further messages will be sent. It is also recommended that these opt-out messages include the brand name. This field is required if managing opt out keywords yourself (i.e. not using Twilio's Default or Advanced Opt Out features). 20 character minimum. 320 character maximum. </param>
        /// <param name="helpMessage"> When customers receive the help keywords from their end users, Twilio customers are expected to send back an auto-generated response; this may include the brand name and additional support contact information. This field is required if managing help keywords yourself (i.e. not using Twilio's Default or Advanced Opt Out features). 20 character minimum. 320 character maximum. </param>
        /// <param name="optInKeywords"> If end users can text in a keyword to start receiving messages from this campaign, those keywords must be provided. This field is required if end users can text in a keyword to start receiving messages from this campaign. Values must be alphanumeric. 255 character maximum. </param>
        /// <param name="optOutKeywords"> End users should be able to text in a keyword to stop receiving messages from this campaign. Those keywords must be provided. This field is required if managing opt out keywords yourself (i.e. not using Twilio's Default or Advanced Opt Out features). Values must be alphanumeric. 255 character maximum. </param>
        /// <param name="helpKeywords"> End users should be able to text in a keyword to receive help. Those keywords must be provided as part of the campaign registration request. This field is required if managing help keywords yourself (i.e. not using Twilio's Default or Advanced Opt Out features). Values must be alphanumeric. 255 character maximum. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UsAppToPerson </returns>
        public static UsAppToPersonResource Create(
                                          string pathMessagingServiceSid,
                                          string brandRegistrationSid,
                                          string description,
                                          string messageFlow,
                                          List<string> messageSamples,
                                          string usAppToPersonUsecase,
                                          bool? hasEmbeddedLinks,
                                          bool? hasEmbeddedPhone,
                                          string optInMessage = null,
                                          string optOutMessage = null,
                                          string helpMessage = null,
                                          List<string> optInKeywords = null,
                                          List<string> optOutKeywords = null,
                                          List<string> helpKeywords = null,
                                          ITwilioRestClient client = null)
        {
            var options = new CreateUsAppToPersonOptions(pathMessagingServiceSid, brandRegistrationSid, description, messageFlow, messageSamples, usAppToPersonUsecase, hasEmbeddedLinks, hasEmbeddedPhone){  OptInMessage = optInMessage, OptOutMessage = optOutMessage, HelpMessage = helpMessage, OptInKeywords = optInKeywords, OptOutKeywords = optOutKeywords, HelpKeywords = helpKeywords };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Messaging Service](https://www.twilio.com/docs/messaging/services/api) to create the resources from. </param>
        /// <param name="brandRegistrationSid"> A2P Brand Registration SID </param>
        /// <param name="description"> A short description of what this SMS campaign does. Min length: 40 characters. Max length: 4096 characters. </param>
        /// <param name="messageFlow"> Required for all Campaigns. Details around how a consumer opts-in to their campaign, therefore giving consent to receive their messages. If multiple opt-in methods can be used for the same campaign, they must all be listed. 40 character minimum. 2048 character maximum. </param>
        /// <param name="messageSamples"> Message samples, at least 1 and up to 5 sample messages (at least 2 for sole proprietor), >=20 chars, <=1024 chars each. </param>
        /// <param name="usAppToPersonUsecase"> A2P Campaign Use Case. Examples: [ 2FA, EMERGENCY, MARKETING..] </param>
        /// <param name="hasEmbeddedLinks"> Indicates that this SMS campaign will send messages that contain links. </param>
        /// <param name="hasEmbeddedPhone"> Indicates that this SMS campaign will send messages that contain phone numbers. </param>
        /// <param name="optInMessage"> If end users can text in a keyword to start receiving messages from this campaign, the auto-reply messages sent to the end users must be provided. The opt-in response should include the Brand name, confirmation of opt-in enrollment to a recurring message campaign, how to get help, and clear description of how to opt-out. This field is required if end users can text in a keyword to start receiving messages from this campaign. 20 character minimum. 320 character maximum. </param>
        /// <param name="optOutMessage"> Upon receiving the opt-out keywords from the end users, Twilio customers are expected to send back an auto-generated response, which must provide acknowledgment of the opt-out request and confirmation that no further messages will be sent. It is also recommended that these opt-out messages include the brand name. This field is required if managing opt out keywords yourself (i.e. not using Twilio's Default or Advanced Opt Out features). 20 character minimum. 320 character maximum. </param>
        /// <param name="helpMessage"> When customers receive the help keywords from their end users, Twilio customers are expected to send back an auto-generated response; this may include the brand name and additional support contact information. This field is required if managing help keywords yourself (i.e. not using Twilio's Default or Advanced Opt Out features). 20 character minimum. 320 character maximum. </param>
        /// <param name="optInKeywords"> If end users can text in a keyword to start receiving messages from this campaign, those keywords must be provided. This field is required if end users can text in a keyword to start receiving messages from this campaign. Values must be alphanumeric. 255 character maximum. </param>
        /// <param name="optOutKeywords"> End users should be able to text in a keyword to stop receiving messages from this campaign. Those keywords must be provided. This field is required if managing opt out keywords yourself (i.e. not using Twilio's Default or Advanced Opt Out features). Values must be alphanumeric. 255 character maximum. </param>
        /// <param name="helpKeywords"> End users should be able to text in a keyword to receive help. Those keywords must be provided as part of the campaign registration request. This field is required if managing help keywords yourself (i.e. not using Twilio's Default or Advanced Opt Out features). Values must be alphanumeric. 255 character maximum. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UsAppToPerson </returns>
        public static async System.Threading.Tasks.Task<UsAppToPersonResource> CreateAsync(
                                                                                  string pathMessagingServiceSid,
                                                                                  string brandRegistrationSid,
                                                                                  string description,
                                                                                  string messageFlow,
                                                                                  List<string> messageSamples,
                                                                                  string usAppToPersonUsecase,
                                                                                  bool? hasEmbeddedLinks,
                                                                                  bool? hasEmbeddedPhone,
                                                                                  string optInMessage = null,
                                                                                  string optOutMessage = null,
                                                                                  string helpMessage = null,
                                                                                  List<string> optInKeywords = null,
                                                                                  List<string> optOutKeywords = null,
                                                                                  List<string> helpKeywords = null,
                                                                                  ITwilioRestClient client = null)
        {
        var options = new CreateUsAppToPersonOptions(pathMessagingServiceSid, brandRegistrationSid, description, messageFlow, messageSamples, usAppToPersonUsecase, hasEmbeddedLinks, hasEmbeddedPhone){  OptInMessage = optInMessage, OptOutMessage = optOutMessage, HelpMessage = helpMessage, OptInKeywords = optInKeywords, OptOutKeywords = optOutKeywords, HelpKeywords = helpKeywords };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> delete </summary>
        /// <param name="options"> Delete UsAppToPerson parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UsAppToPerson </returns>
        private static Request BuildDeleteRequest(DeleteUsAppToPersonOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{MessagingServiceSid}/Compliance/Usa2p/{Sid}";

            string PathMessagingServiceSid = options.PathMessagingServiceSid;
            path = path.Replace("{"+"MessagingServiceSid"+"}", PathMessagingServiceSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Messaging,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> delete </summary>
        /// <param name="options"> Delete UsAppToPerson parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UsAppToPerson </returns>
        public static bool Delete(DeleteUsAppToPersonOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="options"> Delete UsAppToPerson parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UsAppToPerson </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteUsAppToPersonOptions options,
                                                                          ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> delete </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Messaging Service](https://www.twilio.com/docs/messaging/services/api) to delete the resource from. </param>
        /// <param name="pathSid"> The SID of the US A2P Compliance resource to delete `QE2c6890da8086d771620e9b13fadeba0b`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UsAppToPerson </returns>
        public static bool Delete(string pathMessagingServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteUsAppToPersonOptions(pathMessagingServiceSid, pathSid)        ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Messaging Service](https://www.twilio.com/docs/messaging/services/api) to delete the resource from. </param>
        /// <param name="pathSid"> The SID of the US A2P Compliance resource to delete `QE2c6890da8086d771620e9b13fadeba0b`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UsAppToPerson </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathMessagingServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteUsAppToPersonOptions(pathMessagingServiceSid, pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchUsAppToPersonOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{MessagingServiceSid}/Compliance/Usa2p/{Sid}";

            string PathMessagingServiceSid = options.PathMessagingServiceSid;
            path = path.Replace("{"+"MessagingServiceSid"+"}", PathMessagingServiceSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Messaging,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> fetch </summary>
        /// <param name="options"> Fetch UsAppToPerson parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UsAppToPerson </returns>
        public static UsAppToPersonResource Fetch(FetchUsAppToPersonOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch UsAppToPerson parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UsAppToPerson </returns>
        public static async System.Threading.Tasks.Task<UsAppToPersonResource> FetchAsync(FetchUsAppToPersonOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Messaging Service](https://www.twilio.com/docs/messaging/services/api) to fetch the resource from. </param>
        /// <param name="pathSid"> The SID of the US A2P Compliance resource to fetch `QE2c6890da8086d771620e9b13fadeba0b`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UsAppToPerson </returns>
        public static UsAppToPersonResource Fetch(
                                         string pathMessagingServiceSid, 
                                         string pathSid, 
                                         ITwilioRestClient client = null)
        {
            var options = new FetchUsAppToPersonOptions(pathMessagingServiceSid, pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Messaging Service](https://www.twilio.com/docs/messaging/services/api) to fetch the resource from. </param>
        /// <param name="pathSid"> The SID of the US A2P Compliance resource to fetch `QE2c6890da8086d771620e9b13fadeba0b`. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UsAppToPerson </returns>
        public static async System.Threading.Tasks.Task<UsAppToPersonResource> FetchAsync(string pathMessagingServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchUsAppToPersonOptions(pathMessagingServiceSid, pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadUsAppToPersonOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{MessagingServiceSid}/Compliance/Usa2p";

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
        /// <summary> read </summary>
        /// <param name="options"> Read UsAppToPerson parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UsAppToPerson </returns>
        public static ResourceSet<UsAppToPersonResource> Read(ReadUsAppToPersonOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<UsAppToPersonResource>.FromJson("compliance", response.Content);
            return new ResourceSet<UsAppToPersonResource>(page, options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="options"> Read UsAppToPerson parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UsAppToPerson </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<UsAppToPersonResource>> ReadAsync(ReadUsAppToPersonOptions options,
                                                                                             ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<UsAppToPersonResource>.FromJson("compliance", response.Content);
            return new ResourceSet<UsAppToPersonResource>(page, options, client);
        }
        #endif
        /// <summary> read </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Messaging Service](https://www.twilio.com/docs/messaging/services/api) to fetch the resource from. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UsAppToPerson </returns>
        public static ResourceSet<UsAppToPersonResource> Read(
                                                     string pathMessagingServiceSid,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                     ITwilioRestClient client = null)
        {
            var options = new ReadUsAppToPersonOptions(pathMessagingServiceSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Messaging Service](https://www.twilio.com/docs/messaging/services/api) to fetch the resource from. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UsAppToPerson </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<UsAppToPersonResource>> ReadAsync(
                                                                                             string pathMessagingServiceSid,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                             ITwilioRestClient client = null)
        {
            var options = new ReadUsAppToPersonOptions(pathMessagingServiceSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<UsAppToPersonResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<UsAppToPersonResource>.FromJson("compliance", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<UsAppToPersonResource> NextPage(Page<UsAppToPersonResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<UsAppToPersonResource>.FromJson("compliance", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<UsAppToPersonResource> PreviousPage(Page<UsAppToPersonResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<UsAppToPersonResource>.FromJson("compliance", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a UsAppToPersonResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> UsAppToPersonResource object represented by the provided JSON </returns>
        public static UsAppToPersonResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<UsAppToPersonResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }

    
        ///<summary> The unique string that identifies a US A2P Compliance resource `QE2c6890da8086d771620e9b13fadeba0b`. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that the Campaign belongs to. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The unique string to identify the A2P brand. </summary> 
        [JsonProperty("brand_registration_sid")]
        public string BrandRegistrationSid { get; private set; }

        ///<summary> The SID of the [Messaging Service](https://www.twilio.com/docs/messaging/services/api) that the resource is associated with. </summary> 
        [JsonProperty("messaging_service_sid")]
        public string MessagingServiceSid { get; private set; }

        ///<summary> A short description of what this SMS campaign does. Min length: 40 characters. Max length: 4096 characters. </summary> 
        [JsonProperty("description")]
        public string Description { get; private set; }

        ///<summary> Message samples, at least 1 and up to 5 sample messages (at least 2 for starter/sole proprietor), >=20 chars, <=1024 chars each. </summary> 
        [JsonProperty("message_samples")]
        public List<string> MessageSamples { get; private set; }

        ///<summary> A2P Campaign Use Case. Examples: [ 2FA, EMERGENCY, MARKETING, SOLE_PROPRIETOR...]. SOLE_PROPRIETOR campaign use cases can only be created by SOLE_PROPRIETOR Brands, and there can only be one SOLE_PROPRIETOR campaign created per SOLE_PROPRIETOR Brand. </summary> 
        [JsonProperty("us_app_to_person_usecase")]
        public string UsAppToPersonUsecase { get; private set; }

        ///<summary> Indicate that this SMS campaign will send messages that contain links. </summary> 
        [JsonProperty("has_embedded_links")]
        public bool? HasEmbeddedLinks { get; private set; }

        ///<summary> Indicates that this SMS campaign will send messages that contain phone numbers. </summary> 
        [JsonProperty("has_embedded_phone")]
        public bool? HasEmbeddedPhone { get; private set; }

        ///<summary> Campaign status. Examples: IN_PROGRESS, VERIFIED, FAILED. </summary> 
        [JsonProperty("campaign_status")]
        public string CampaignStatus { get; private set; }

        ///<summary> The Campaign Registry (TCR) Campaign ID. </summary> 
        [JsonProperty("campaign_id")]
        public string CampaignId { get; private set; }

        ///<summary> Indicates whether the campaign was registered externally or not. </summary> 
        [JsonProperty("is_externally_registered")]
        public bool? IsExternallyRegistered { get; private set; }

        ///<summary> Rate limit and/or classification set by each carrier, Ex. AT&T or T-Mobile. </summary> 
        [JsonProperty("rate_limits")]
        public object RateLimits { get; private set; }

        ///<summary> Details around how a consumer opts-in to their campaign, therefore giving consent to receive their messages. If multiple opt-in methods can be used for the same campaign, they must all be listed. 40 character minimum. 2048 character maximum. </summary> 
        [JsonProperty("message_flow")]
        public string MessageFlow { get; private set; }

        ///<summary> If end users can text in a keyword to start receiving messages from this campaign, the auto-reply messages sent to the end users must be provided. The opt-in response should include the Brand name, confirmation of opt-in enrollment to a recurring message campaign, how to get help, and clear description of how to opt-out. This field is required if end users can text in a keyword to start receiving messages from this campaign. 20 character minimum. 320 character maximum. </summary> 
        [JsonProperty("opt_in_message")]
        public string OptInMessage { get; private set; }

        ///<summary> Upon receiving the opt-out keywords from the end users, Twilio customers are expected to send back an auto-generated response, which must provide acknowledgment of the opt-out request and confirmation that no further messages will be sent. It is also recommended that these opt-out messages include the brand name. This field is required if managing opt out keywords yourself (i.e. not using Twilio's Default or Advanced Opt Out features). 20 character minimum. 320 character maximum. </summary> 
        [JsonProperty("opt_out_message")]
        public string OptOutMessage { get; private set; }

        ///<summary> When customers receive the help keywords from their end users, Twilio customers are expected to send back an auto-generated response; this may include the brand name and additional support contact information. This field is required if managing help keywords yourself (i.e. not using Twilio's Default or Advanced Opt Out features). 20 character minimum. 320 character maximum. </summary> 
        [JsonProperty("help_message")]
        public string HelpMessage { get; private set; }

        ///<summary> If end users can text in a keyword to start receiving messages from this campaign, those keywords must be provided. This field is required if end users can text in a keyword to start receiving messages from this campaign. Values must be alphanumeric. 255 character maximum. </summary> 
        [JsonProperty("opt_in_keywords")]
        public List<string> OptInKeywords { get; private set; }

        ///<summary> End users should be able to text in a keyword to stop receiving messages from this campaign. Those keywords must be provided. This field is required if managing opt out keywords yourself (i.e. not using Twilio's Default or Advanced Opt Out features). Values must be alphanumeric. 255 character maximum. </summary> 
        [JsonProperty("opt_out_keywords")]
        public List<string> OptOutKeywords { get; private set; }

        ///<summary> End users should be able to text in a keyword to receive help. Those keywords must be provided as part of the campaign registration request. This field is required if managing help keywords yourself (i.e. not using Twilio's Default or Advanced Opt Out features). Values must be alphanumeric. 255 character maximum. </summary> 
        [JsonProperty("help_keywords")]
        public List<string> HelpKeywords { get; private set; }

        ///<summary> The date and time in GMT when the resource was created specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the resource was last updated specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The absolute URL of the US App to Person resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> A boolean that specifies whether campaign is a mock or not. Mock campaigns will be automatically created if using a mock brand. Mock campaigns should only be used for testing purposes. </summary> 
        [JsonProperty("mock")]
        public bool? Mock { get; private set; }

        ///<summary> Details indicating why a campaign registration failed. These errors can indicate one or more fields that were incorrect or did not meet review requirements. </summary> 
        [JsonProperty("errors")]
        public List<object> Errors { get; private set; }



        private UsAppToPersonResource() {

        }
    }
}

