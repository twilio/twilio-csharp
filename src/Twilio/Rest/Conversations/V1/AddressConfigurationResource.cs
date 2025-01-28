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
using Twilio.Types;


namespace Twilio.Rest.Conversations.V1
{
    public class AddressConfigurationResource : Resource
    {
    

    
        public sealed class MethodEnum : StringEnum
        {
            private MethodEnum(string value) : base(value) {}
            public MethodEnum() {}
            public static implicit operator MethodEnum(string value)
            {
                return new MethodEnum(value);
            }
            public static readonly MethodEnum Get = new MethodEnum("GET");
            public static readonly MethodEnum Post = new MethodEnum("POST");

        }
        public sealed class TypeEnum : StringEnum
        {
            private TypeEnum(string value) : base(value) {}
            public TypeEnum() {}
            public static implicit operator TypeEnum(string value)
            {
                return new TypeEnum(value);
            }
            public static readonly TypeEnum Sms = new TypeEnum("sms");
            public static readonly TypeEnum Whatsapp = new TypeEnum("whatsapp");
            public static readonly TypeEnum Messenger = new TypeEnum("messenger");
            public static readonly TypeEnum Gbm = new TypeEnum("gbm");
            public static readonly TypeEnum Email = new TypeEnum("email");
            public static readonly TypeEnum Rcs = new TypeEnum("rcs");
            public static readonly TypeEnum Apple = new TypeEnum("apple");

        }
        public sealed class AutoCreationTypeEnum : StringEnum
        {
            private AutoCreationTypeEnum(string value) : base(value) {}
            public AutoCreationTypeEnum() {}
            public static implicit operator AutoCreationTypeEnum(string value)
            {
                return new AutoCreationTypeEnum(value);
            }
            public static readonly AutoCreationTypeEnum Webhook = new AutoCreationTypeEnum("webhook");
            public static readonly AutoCreationTypeEnum Studio = new AutoCreationTypeEnum("studio");
            public static readonly AutoCreationTypeEnum Default = new AutoCreationTypeEnum("default");

        }

        
        private static Request BuildCreateRequest(CreateAddressConfigurationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Configuration/Addresses";


            return new Request(
                HttpMethod.Post,
                Rest.Domain.Conversations,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Create a new address configuration </summary>
        /// <param name="options"> Create AddressConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AddressConfiguration </returns>
        public static AddressConfigurationResource Create(CreateAddressConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Create a new address configuration </summary>
        /// <param name="options"> Create AddressConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AddressConfiguration </returns>
        public static async System.Threading.Tasks.Task<AddressConfigurationResource> CreateAsync(CreateAddressConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Create a new address configuration </summary>
        /// <param name="type">  </param>
        /// <param name="address"> The unique address to be configured. The address can be a whatsapp address or phone number </param>
        /// <param name="friendlyName"> The human-readable name of this configuration, limited to 256 characters. Optional. </param>
        /// <param name="autoCreationEnabled"> Enable/Disable auto-creating conversations for messages to this address </param>
        /// <param name="autoCreationType">  </param>
        /// <param name="autoCreationConversationServiceSid"> Conversation Service for the auto-created conversation. If not set, the conversation is created in the default service. </param>
        /// <param name="autoCreationWebhookUrl"> For type `webhook`, the url for the webhook request. </param>
        /// <param name="autoCreationWebhookMethod">  </param>
        /// <param name="autoCreationWebhookFilters"> The list of events, firing webhook event for this Conversation. Values can be any of the following: `onMessageAdded`, `onMessageUpdated`, `onMessageRemoved`, `onConversationUpdated`, `onConversationStateUpdated`, `onConversationRemoved`, `onParticipantAdded`, `onParticipantUpdated`, `onParticipantRemoved`, `onDeliveryUpdated` </param>
        /// <param name="autoCreationStudioFlowSid"> For type `studio`, the studio flow SID where the webhook should be sent to. </param>
        /// <param name="autoCreationStudioRetryCount"> For type `studio`, number of times to retry the webhook request </param>
        /// <param name="addressCountry"> An ISO 3166-1 alpha-2n country code which the address belongs to. This is currently only applicable to short code addresses. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AddressConfiguration </returns>
        public static AddressConfigurationResource Create(
                                          AddressConfigurationResource.TypeEnum type,
                                          string address,
                                          string friendlyName = null,
                                          bool? autoCreationEnabled = null,
                                          AddressConfigurationResource.AutoCreationTypeEnum autoCreationType = null,
                                          string autoCreationConversationServiceSid = null,
                                          string autoCreationWebhookUrl = null,
                                          AddressConfigurationResource.MethodEnum autoCreationWebhookMethod = null,
                                          List<string> autoCreationWebhookFilters = null,
                                          string autoCreationStudioFlowSid = null,
                                          int? autoCreationStudioRetryCount = null,
                                          string addressCountry = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateAddressConfigurationOptions(type, address){  FriendlyName = friendlyName, AutoCreationEnabled = autoCreationEnabled, AutoCreationType = autoCreationType, AutoCreationConversationServiceSid = autoCreationConversationServiceSid, AutoCreationWebhookUrl = autoCreationWebhookUrl, AutoCreationWebhookMethod = autoCreationWebhookMethod, AutoCreationWebhookFilters = autoCreationWebhookFilters, AutoCreationStudioFlowSid = autoCreationStudioFlowSid, AutoCreationStudioRetryCount = autoCreationStudioRetryCount, AddressCountry = addressCountry };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> Create a new address configuration </summary>
        /// <param name="type">  </param>
        /// <param name="address"> The unique address to be configured. The address can be a whatsapp address or phone number </param>
        /// <param name="friendlyName"> The human-readable name of this configuration, limited to 256 characters. Optional. </param>
        /// <param name="autoCreationEnabled"> Enable/Disable auto-creating conversations for messages to this address </param>
        /// <param name="autoCreationType">  </param>
        /// <param name="autoCreationConversationServiceSid"> Conversation Service for the auto-created conversation. If not set, the conversation is created in the default service. </param>
        /// <param name="autoCreationWebhookUrl"> For type `webhook`, the url for the webhook request. </param>
        /// <param name="autoCreationWebhookMethod">  </param>
        /// <param name="autoCreationWebhookFilters"> The list of events, firing webhook event for this Conversation. Values can be any of the following: `onMessageAdded`, `onMessageUpdated`, `onMessageRemoved`, `onConversationUpdated`, `onConversationStateUpdated`, `onConversationRemoved`, `onParticipantAdded`, `onParticipantUpdated`, `onParticipantRemoved`, `onDeliveryUpdated` </param>
        /// <param name="autoCreationStudioFlowSid"> For type `studio`, the studio flow SID where the webhook should be sent to. </param>
        /// <param name="autoCreationStudioRetryCount"> For type `studio`, number of times to retry the webhook request </param>
        /// <param name="addressCountry"> An ISO 3166-1 alpha-2n country code which the address belongs to. This is currently only applicable to short code addresses. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AddressConfiguration </returns>
        public static async System.Threading.Tasks.Task<AddressConfigurationResource> CreateAsync(
                                                                                  AddressConfigurationResource.TypeEnum type,
                                                                                  string address,
                                                                                  string friendlyName = null,
                                                                                  bool? autoCreationEnabled = null,
                                                                                  AddressConfigurationResource.AutoCreationTypeEnum autoCreationType = null,
                                                                                  string autoCreationConversationServiceSid = null,
                                                                                  string autoCreationWebhookUrl = null,
                                                                                  AddressConfigurationResource.MethodEnum autoCreationWebhookMethod = null,
                                                                                  List<string> autoCreationWebhookFilters = null,
                                                                                  string autoCreationStudioFlowSid = null,
                                                                                  int? autoCreationStudioRetryCount = null,
                                                                                  string addressCountry = null,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateAddressConfigurationOptions(type, address){  FriendlyName = friendlyName, AutoCreationEnabled = autoCreationEnabled, AutoCreationType = autoCreationType, AutoCreationConversationServiceSid = autoCreationConversationServiceSid, AutoCreationWebhookUrl = autoCreationWebhookUrl, AutoCreationWebhookMethod = autoCreationWebhookMethod, AutoCreationWebhookFilters = autoCreationWebhookFilters, AutoCreationStudioFlowSid = autoCreationStudioFlowSid, AutoCreationStudioRetryCount = autoCreationStudioRetryCount, AddressCountry = addressCountry };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> Remove an existing address configuration </summary>
        /// <param name="options"> Delete AddressConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AddressConfiguration </returns>
        private static Request BuildDeleteRequest(DeleteAddressConfigurationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Configuration/Addresses/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Conversations,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Remove an existing address configuration </summary>
        /// <param name="options"> Delete AddressConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AddressConfiguration </returns>
        public static bool Delete(DeleteAddressConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> Remove an existing address configuration </summary>
        /// <param name="options"> Delete AddressConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AddressConfiguration </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteAddressConfigurationOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> Remove an existing address configuration </summary>
        /// <param name="pathSid"> The SID of the Address Configuration resource. This value can be either the `sid` or the `address` of the configuration </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AddressConfiguration </returns>
        public static bool Delete(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteAddressConfigurationOptions(pathSid)     ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> Remove an existing address configuration </summary>
        /// <param name="pathSid"> The SID of the Address Configuration resource. This value can be either the `sid` or the `address` of the configuration </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AddressConfiguration </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteAddressConfigurationOptions(pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchAddressConfigurationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Configuration/Addresses/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Conversations,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Fetch an address configuration  </summary>
        /// <param name="options"> Fetch AddressConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AddressConfiguration </returns>
        public static AddressConfigurationResource Fetch(FetchAddressConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> Fetch an address configuration  </summary>
        /// <param name="options"> Fetch AddressConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AddressConfiguration </returns>
        public static async System.Threading.Tasks.Task<AddressConfigurationResource> FetchAsync(FetchAddressConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> Fetch an address configuration  </summary>
        /// <param name="pathSid"> The SID of the Address Configuration resource. This value can be either the `sid` or the `address` of the configuration </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AddressConfiguration </returns>
        public static AddressConfigurationResource Fetch(
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchAddressConfigurationOptions(pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> Fetch an address configuration  </summary>
        /// <param name="pathSid"> The SID of the Address Configuration resource. This value can be either the `sid` or the `address` of the configuration </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AddressConfiguration </returns>
        public static async System.Threading.Tasks.Task<AddressConfigurationResource> FetchAsync(string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchAddressConfigurationOptions(pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadAddressConfigurationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Configuration/Addresses";


            return new Request(
                HttpMethod.Get,
                Rest.Domain.Conversations,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> Retrieve a list of address configurations for an account </summary>
        /// <param name="options"> Read AddressConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AddressConfiguration </returns>
        public static ResourceSet<AddressConfigurationResource> Read(ReadAddressConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<AddressConfigurationResource>.FromJson("address_configurations", response.Content);
            return new ResourceSet<AddressConfigurationResource>(page, options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of address configurations for an account </summary>
        /// <param name="options"> Read AddressConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AddressConfiguration </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<AddressConfigurationResource>> ReadAsync(ReadAddressConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<AddressConfigurationResource>.FromJson("address_configurations", response.Content);
            return new ResourceSet<AddressConfigurationResource>(page, options, client);
        }
        #endif
        /// <summary> Retrieve a list of address configurations for an account </summary>
        /// <param name="type"> Filter the address configurations by its type. This value can be one of: `whatsapp`, `sms`. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AddressConfiguration </returns>
        public static ResourceSet<AddressConfigurationResource> Read(
                                                     string type = null,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadAddressConfigurationOptions(){ Type = type, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> Retrieve a list of address configurations for an account </summary>
        /// <param name="type"> Filter the address configurations by its type. This value can be one of: `whatsapp`, `sms`. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AddressConfiguration </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<AddressConfigurationResource>> ReadAsync(
                                                                                             string type = null,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadAddressConfigurationOptions(){ Type = type, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<AddressConfigurationResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<AddressConfigurationResource>.FromJson("address_configurations", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<AddressConfigurationResource> NextPage(Page<AddressConfigurationResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<AddressConfigurationResource>.FromJson("address_configurations", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<AddressConfigurationResource> PreviousPage(Page<AddressConfigurationResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<AddressConfigurationResource>.FromJson("address_configurations", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateAddressConfigurationOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Configuration/Addresses/{Sid}";

            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Conversations,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> Update an existing address configuration </summary>
        /// <param name="options"> Update AddressConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AddressConfiguration </returns>
        public static AddressConfigurationResource Update(UpdateAddressConfigurationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> Update an existing address configuration </summary>
        /// <param name="options"> Update AddressConfiguration parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AddressConfiguration </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<AddressConfigurationResource> UpdateAsync(UpdateAddressConfigurationOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> Update an existing address configuration </summary>
        /// <param name="pathSid"> The SID of the Address Configuration resource. This value can be either the `sid` or the `address` of the configuration </param>
        /// <param name="friendlyName"> The human-readable name of this configuration, limited to 256 characters. Optional. </param>
        /// <param name="autoCreationEnabled"> Enable/Disable auto-creating conversations for messages to this address </param>
        /// <param name="autoCreationType">  </param>
        /// <param name="autoCreationConversationServiceSid"> Conversation Service for the auto-created conversation. If not set, the conversation is created in the default service. </param>
        /// <param name="autoCreationWebhookUrl"> For type `webhook`, the url for the webhook request. </param>
        /// <param name="autoCreationWebhookMethod">  </param>
        /// <param name="autoCreationWebhookFilters"> The list of events, firing webhook event for this Conversation. Values can be any of the following: `onMessageAdded`, `onMessageUpdated`, `onMessageRemoved`, `onConversationUpdated`, `onConversationStateUpdated`, `onConversationRemoved`, `onParticipantAdded`, `onParticipantUpdated`, `onParticipantRemoved`, `onDeliveryUpdated` </param>
        /// <param name="autoCreationStudioFlowSid"> For type `studio`, the studio flow SID where the webhook should be sent to. </param>
        /// <param name="autoCreationStudioRetryCount"> For type `studio`, number of times to retry the webhook request </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of AddressConfiguration </returns>
        public static AddressConfigurationResource Update(
                                          string pathSid,
                                          string friendlyName = null,
                                          bool? autoCreationEnabled = null,
                                          AddressConfigurationResource.AutoCreationTypeEnum autoCreationType = null,
                                          string autoCreationConversationServiceSid = null,
                                          string autoCreationWebhookUrl = null,
                                          AddressConfigurationResource.MethodEnum autoCreationWebhookMethod = null,
                                          List<string> autoCreationWebhookFilters = null,
                                          string autoCreationStudioFlowSid = null,
                                          int? autoCreationStudioRetryCount = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateAddressConfigurationOptions(pathSid){ FriendlyName = friendlyName, AutoCreationEnabled = autoCreationEnabled, AutoCreationType = autoCreationType, AutoCreationConversationServiceSid = autoCreationConversationServiceSid, AutoCreationWebhookUrl = autoCreationWebhookUrl, AutoCreationWebhookMethod = autoCreationWebhookMethod, AutoCreationWebhookFilters = autoCreationWebhookFilters, AutoCreationStudioFlowSid = autoCreationStudioFlowSid, AutoCreationStudioRetryCount = autoCreationStudioRetryCount };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> Update an existing address configuration </summary>
        /// <param name="pathSid"> The SID of the Address Configuration resource. This value can be either the `sid` or the `address` of the configuration </param>
        /// <param name="friendlyName"> The human-readable name of this configuration, limited to 256 characters. Optional. </param>
        /// <param name="autoCreationEnabled"> Enable/Disable auto-creating conversations for messages to this address </param>
        /// <param name="autoCreationType">  </param>
        /// <param name="autoCreationConversationServiceSid"> Conversation Service for the auto-created conversation. If not set, the conversation is created in the default service. </param>
        /// <param name="autoCreationWebhookUrl"> For type `webhook`, the url for the webhook request. </param>
        /// <param name="autoCreationWebhookMethod">  </param>
        /// <param name="autoCreationWebhookFilters"> The list of events, firing webhook event for this Conversation. Values can be any of the following: `onMessageAdded`, `onMessageUpdated`, `onMessageRemoved`, `onConversationUpdated`, `onConversationStateUpdated`, `onConversationRemoved`, `onParticipantAdded`, `onParticipantUpdated`, `onParticipantRemoved`, `onDeliveryUpdated` </param>
        /// <param name="autoCreationStudioFlowSid"> For type `studio`, the studio flow SID where the webhook should be sent to. </param>
        /// <param name="autoCreationStudioRetryCount"> For type `studio`, number of times to retry the webhook request </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of AddressConfiguration </returns>
        public static async System.Threading.Tasks.Task<AddressConfigurationResource> UpdateAsync(
                                                                              string pathSid,
                                                                              string friendlyName = null,
                                                                              bool? autoCreationEnabled = null,
                                                                              AddressConfigurationResource.AutoCreationTypeEnum autoCreationType = null,
                                                                              string autoCreationConversationServiceSid = null,
                                                                              string autoCreationWebhookUrl = null,
                                                                              AddressConfigurationResource.MethodEnum autoCreationWebhookMethod = null,
                                                                              List<string> autoCreationWebhookFilters = null,
                                                                              string autoCreationStudioFlowSid = null,
                                                                              int? autoCreationStudioRetryCount = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateAddressConfigurationOptions(pathSid){ FriendlyName = friendlyName, AutoCreationEnabled = autoCreationEnabled, AutoCreationType = autoCreationType, AutoCreationConversationServiceSid = autoCreationConversationServiceSid, AutoCreationWebhookUrl = autoCreationWebhookUrl, AutoCreationWebhookMethod = autoCreationWebhookMethod, AutoCreationWebhookFilters = autoCreationWebhookFilters, AutoCreationStudioFlowSid = autoCreationStudioFlowSid, AutoCreationStudioRetryCount = autoCreationStudioRetryCount };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a AddressConfigurationResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AddressConfigurationResource object represented by the provided JSON </returns>
        public static AddressConfigurationResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<AddressConfigurationResource>(json);
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

    
        ///<summary> A 34 character string that uniquely identifies this resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The unique ID of the [Account](https://www.twilio.com/docs/iam/api/account) the address belongs to </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> Type of Address, value can be `whatsapp` or `sms`. </summary> 
        [JsonProperty("type")]
        public string Type { get; private set; }

        ///<summary> The unique address to be configured. The address can be a whatsapp address or phone number </summary> 
        [JsonProperty("address")]
        public string Address { get; private set; }

        ///<summary> The human-readable name of this configuration, limited to 256 characters. Optional. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> Auto Creation configuration for the address. </summary> 
        [JsonProperty("auto_creation")]
        public object AutoCreation { get; private set; }

        ///<summary> The date that this resource was created. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date that this resource was last updated. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> An absolute API resource URL for this address configuration. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> An ISO 3166-1 alpha-2n country code which the address belongs to. This is currently only applicable to short code addresses. </summary> 
        [JsonProperty("address_country")]
        public string AddressCountry { get; private set; }



        private AddressConfigurationResource() {

        }
    }
}

