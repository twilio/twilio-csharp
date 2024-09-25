/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Chat
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




namespace Twilio.Rest.Chat.V2.Service
{
    public class ChannelResource : Resource
    {
    

    
        public sealed class WebhookEnabledTypeEnum : StringEnum
        {
            private WebhookEnabledTypeEnum(string value) : base(value) {}
            public WebhookEnabledTypeEnum() {}
            public static implicit operator WebhookEnabledTypeEnum(string value)
            {
                return new WebhookEnabledTypeEnum(value);
            }
            public static readonly WebhookEnabledTypeEnum True = new WebhookEnabledTypeEnum("true");
            public static readonly WebhookEnabledTypeEnum False = new WebhookEnabledTypeEnum("false");

        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class ChannelTypeEnum : StringEnum
        {
            private ChannelTypeEnum(string value) : base(value) {}
            public ChannelTypeEnum() {}
            public static implicit operator ChannelTypeEnum(string value)
            {
                return new ChannelTypeEnum(value);
            }
            public static readonly ChannelTypeEnum Public = new ChannelTypeEnum("public");
            public static readonly ChannelTypeEnum Private = new ChannelTypeEnum("private");

        }

        
        private static Request BuildCreateRequest(CreateChannelOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/Channels";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Chat,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: options.GetHeaderParams()
            );
        }

        /// <summary> create </summary>
        /// <param name="options"> Create Channel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Channel </returns>
        public static ChannelResource Create(CreateChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="options"> Create Channel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Channel </returns>
        public static async System.Threading.Tasks.Task<ChannelResource> CreateAsync(CreateChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> create </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to create the Channel resource under. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the new resource. It can be up to 64 characters long. </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the resource. It can be used to address the resource in place of the Channel resource's `sid` in the URL. This value must be 64 characters or less in length and be unique within the Service. </param>
        /// <param name="attributes"> A valid JSON string that contains application-specific data. </param>
        /// <param name="type">  </param>
        /// <param name="dateCreated"> The date, specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format, to assign to the resource as the date it was created. The default value is the current time set by the Chat service.  Note that this should only be used in cases where a Channel is being recreated from a backup/separate source. </param>
        /// <param name="dateUpdated"> The date, specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format, to assign to the resource as the date it was last updated. The default value is `null`. Note that this parameter should only be used in cases where a Channel is being recreated from a backup/separate source  and where a Message was previously updated. </param>
        /// <param name="createdBy"> The `identity` of the User that created the channel. Default is: `system`. </param>
        /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Channel </returns>
        public static ChannelResource Create(
                                          string pathServiceSid,
                                          string friendlyName = null,
                                          string uniqueName = null,
                                          string attributes = null,
                                          ChannelResource.ChannelTypeEnum type = null,
                                          DateTime? dateCreated = null,
                                          DateTime? dateUpdated = null,
                                          string createdBy = null,
                                          ChannelResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateChannelOptions(pathServiceSid){  FriendlyName = friendlyName, UniqueName = uniqueName, Attributes = attributes, Type = type, DateCreated = dateCreated, DateUpdated = dateUpdated, CreatedBy = createdBy, XTwilioWebhookEnabled = xTwilioWebhookEnabled };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to create the Channel resource under. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the new resource. It can be up to 64 characters long. </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the resource. It can be used to address the resource in place of the Channel resource's `sid` in the URL. This value must be 64 characters or less in length and be unique within the Service. </param>
        /// <param name="attributes"> A valid JSON string that contains application-specific data. </param>
        /// <param name="type">  </param>
        /// <param name="dateCreated"> The date, specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format, to assign to the resource as the date it was created. The default value is the current time set by the Chat service.  Note that this should only be used in cases where a Channel is being recreated from a backup/separate source. </param>
        /// <param name="dateUpdated"> The date, specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format, to assign to the resource as the date it was last updated. The default value is `null`. Note that this parameter should only be used in cases where a Channel is being recreated from a backup/separate source  and where a Message was previously updated. </param>
        /// <param name="createdBy"> The `identity` of the User that created the channel. Default is: `system`. </param>
        /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Channel </returns>
        public static async System.Threading.Tasks.Task<ChannelResource> CreateAsync(
                                                                                  string pathServiceSid,
                                                                                  string friendlyName = null,
                                                                                  string uniqueName = null,
                                                                                  string attributes = null,
                                                                                  ChannelResource.ChannelTypeEnum type = null,
                                                                                  DateTime? dateCreated = null,
                                                                                  DateTime? dateUpdated = null,
                                                                                  string createdBy = null,
                                                                                  ChannelResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateChannelOptions(pathServiceSid){  FriendlyName = friendlyName, UniqueName = uniqueName, Attributes = attributes, Type = type, DateCreated = dateCreated, DateUpdated = dateUpdated, CreatedBy = createdBy, XTwilioWebhookEnabled = xTwilioWebhookEnabled };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> delete </summary>
        /// <param name="options"> Delete Channel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Channel </returns>
        private static Request BuildDeleteRequest(DeleteChannelOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/Channels/{Sid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Chat,
                path,
                queryParams: options.GetParams(),
                headerParams: options.GetHeaderParams()
            );
        }

        /// <summary> delete </summary>
        /// <param name="options"> Delete Channel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Channel </returns>
        public static bool Delete(DeleteChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="options"> Delete Channel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Channel </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteChannelOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> delete </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to delete the resource from. </param>
        /// <param name="pathSid"> The SID of the Channel resource to delete.  This value can be either the `sid` or the `unique_name` of the Channel resource to delete. </param>
        /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Channel </returns>
        public static bool Delete(string pathServiceSid, string pathSid, ChannelResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null, ITwilioRestClient client = null)
        {
            var options = new DeleteChannelOptions(pathServiceSid, pathSid)         { XTwilioWebhookEnabled = xTwilioWebhookEnabled }   ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to delete the resource from. </param>
        /// <param name="pathSid"> The SID of the Channel resource to delete.  This value can be either the `sid` or the `unique_name` of the Channel resource to delete. </param>
        /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Channel </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid, string pathSid, ChannelResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null, ITwilioRestClient client = null)
        {
            var options = new DeleteChannelOptions(pathServiceSid, pathSid)  { XTwilioWebhookEnabled = xTwilioWebhookEnabled };
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchChannelOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/Channels/{Sid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Chat,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> fetch </summary>
        /// <param name="options"> Fetch Channel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Channel </returns>
        public static ChannelResource Fetch(FetchChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch Channel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Channel </returns>
        public static async System.Threading.Tasks.Task<ChannelResource> FetchAsync(FetchChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to fetch the Channel resource from. </param>
        /// <param name="pathSid"> The SID of the Channel resource to fetch. This value can be either the `sid` or the `unique_name` of the Channel resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Channel </returns>
        public static ChannelResource Fetch(
                                         string pathServiceSid, 
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchChannelOptions(pathServiceSid, pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to fetch the Channel resource from. </param>
        /// <param name="pathSid"> The SID of the Channel resource to fetch. This value can be either the `sid` or the `unique_name` of the Channel resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Channel </returns>
        public static async System.Threading.Tasks.Task<ChannelResource> FetchAsync(string pathServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchChannelOptions(pathServiceSid, pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadChannelOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/Channels";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.Chat,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> read </summary>
        /// <param name="options"> Read Channel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Channel </returns>
        public static ResourceSet<ChannelResource> Read(ReadChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<ChannelResource>.FromJson("channels", response.Content);
            return new ResourceSet<ChannelResource>(page, options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="options"> Read Channel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Channel </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ChannelResource>> ReadAsync(ReadChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<ChannelResource>.FromJson("channels", response.Content);
            return new ResourceSet<ChannelResource>(page, options, client);
        }
        #endif
        /// <summary> read </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to read the Channel resources from. </param>
        /// <param name="type"> The visibility of the Channels to read. Can be: `public` or `private` and defaults to `public`. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Channel </returns>
        public static ResourceSet<ChannelResource> Read(
                                                     string pathServiceSid,
                                                     List<ChannelResource.ChannelTypeEnum> type = null,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadChannelOptions(pathServiceSid){ Type = type, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to read the Channel resources from. </param>
        /// <param name="type"> The visibility of the Channels to read. Can be: `public` or `private` and defaults to `public`. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Channel </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ChannelResource>> ReadAsync(
                                                                                             string pathServiceSid,
                                                                                             List<ChannelResource.ChannelTypeEnum> type = null,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadChannelOptions(pathServiceSid){ Type = type, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<ChannelResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<ChannelResource>.FromJson("channels", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<ChannelResource> NextPage(Page<ChannelResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ChannelResource>.FromJson("channels", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<ChannelResource> PreviousPage(Page<ChannelResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ChannelResource>.FromJson("channels", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateChannelOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/Channels/{Sid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Chat,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: options.GetHeaderParams()
            );
        }

        /// <summary> update </summary>
        /// <param name="options"> Update Channel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Channel </returns>
        public static ChannelResource Update(UpdateChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> update </summary>
        /// <param name="options"> Update Channel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Channel </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<ChannelResource> UpdateAsync(UpdateChannelOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> update </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to update the Channel resource in. </param>
        /// <param name="pathSid"> The SID of the Channel resource to update. This value can be either the `sid` or the `unique_name` of the Channel resource to update. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It can be up to 256 characters long. </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the resource. It can be used to address the resource in place of the resource's `sid` in the URL. This value must be 256 characters or less in length and unique within the Service. </param>
        /// <param name="attributes"> A valid JSON string that contains application-specific data. </param>
        /// <param name="dateCreated"> The date, specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format, to assign to the resource as the date it was created. The default value is the current time set by the Chat service.  Note that this should only be used in cases where a Channel is being recreated from a backup/separate source. </param>
        /// <param name="dateUpdated"> The date, specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format, to assign to the resource as the date it was last updated. </param>
        /// <param name="createdBy"> The `identity` of the User that created the channel. Default is: `system`. </param>
        /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Channel </returns>
        public static ChannelResource Update(
                                          string pathServiceSid,
                                          string pathSid,
                                          string friendlyName = null,
                                          string uniqueName = null,
                                          string attributes = null,
                                          DateTime? dateCreated = null,
                                          DateTime? dateUpdated = null,
                                          string createdBy = null,
                                          ChannelResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateChannelOptions(pathServiceSid, pathSid){ FriendlyName = friendlyName, UniqueName = uniqueName, Attributes = attributes, DateCreated = dateCreated, DateUpdated = dateUpdated, CreatedBy = createdBy, XTwilioWebhookEnabled = xTwilioWebhookEnabled };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> update </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to update the Channel resource in. </param>
        /// <param name="pathSid"> The SID of the Channel resource to update. This value can be either the `sid` or the `unique_name` of the Channel resource to update. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It can be up to 256 characters long. </param>
        /// <param name="uniqueName"> An application-defined string that uniquely identifies the resource. It can be used to address the resource in place of the resource's `sid` in the URL. This value must be 256 characters or less in length and unique within the Service. </param>
        /// <param name="attributes"> A valid JSON string that contains application-specific data. </param>
        /// <param name="dateCreated"> The date, specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format, to assign to the resource as the date it was created. The default value is the current time set by the Chat service.  Note that this should only be used in cases where a Channel is being recreated from a backup/separate source. </param>
        /// <param name="dateUpdated"> The date, specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format, to assign to the resource as the date it was last updated. </param>
        /// <param name="createdBy"> The `identity` of the User that created the channel. Default is: `system`. </param>
        /// <param name="xTwilioWebhookEnabled"> The X-Twilio-Webhook-Enabled HTTP request header </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Channel </returns>
        public static async System.Threading.Tasks.Task<ChannelResource> UpdateAsync(
                                                                              string pathServiceSid,
                                                                              string pathSid,
                                                                              string friendlyName = null,
                                                                              string uniqueName = null,
                                                                              string attributes = null,
                                                                              DateTime? dateCreated = null,
                                                                              DateTime? dateUpdated = null,
                                                                              string createdBy = null,
                                                                              ChannelResource.WebhookEnabledTypeEnum xTwilioWebhookEnabled = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateChannelOptions(pathServiceSid, pathSid){ FriendlyName = friendlyName, UniqueName = uniqueName, Attributes = attributes, DateCreated = dateCreated, DateUpdated = dateUpdated, CreatedBy = createdBy, XTwilioWebhookEnabled = xTwilioWebhookEnabled };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a ChannelResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ChannelResource object represented by the provided JSON </returns>
        public static ChannelResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<ChannelResource>(json);
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

    
        ///<summary> The unique string that we created to identify the Channel resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Channel resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) the Channel resource is associated with. </summary> 
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }

        ///<summary> The string that you assigned to describe the resource. </summary> 
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }

        ///<summary> An application-defined string that uniquely identifies the resource. It can be used to address the resource in place of the resource's `sid` in the URL. </summary> 
        [JsonProperty("unique_name")]
        public string UniqueName { get; private set; }

        ///<summary> The JSON string that stores application-specific data. If attributes have not been set, `{}` is returned. </summary> 
        [JsonProperty("attributes")]
        public string Attributes { get; private set; }

        
        [JsonProperty("type")]
        public ChannelResource.ChannelTypeEnum Type { get; private set; }

        ///<summary> The date and time in GMT when the resource was created specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the resource was last updated specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The `identity` of the User that created the channel. If the Channel was created by using the API, the value is `system`. </summary> 
        [JsonProperty("created_by")]
        public string CreatedBy { get; private set; }

        ///<summary> The number of Members in the Channel. </summary> 
        [JsonProperty("members_count")]
        public int? MembersCount { get; private set; }

        ///<summary> The number of Messages that have been passed in the Channel. </summary> 
        [JsonProperty("messages_count")]
        public int? MessagesCount { get; private set; }

        ///<summary> The absolute URL of the Channel resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        ///<summary> The absolute URLs of the [Members](https://www.twilio.com/docs/chat/rest/member-resource), [Messages](https://www.twilio.com/docs/chat/rest/message-resource), [Invites](https://www.twilio.com/docs/chat/rest/invite-resource), Webhooks and, if it exists, the last [Message](https://www.twilio.com/docs/chat/rest/message-resource) for the Channel. </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }



        private ChannelResource() {

        }
    }
}

