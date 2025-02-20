/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Ip_messaging
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


namespace Twilio.Rest.IpMessaging.V2.Service.User
{
    public class UserChannelResource : Resource
    {
    

    
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class NotificationLevelEnum : StringEnum
        {
            private NotificationLevelEnum(string value) : base(value) {}
            public NotificationLevelEnum() {}
            public static implicit operator NotificationLevelEnum(string value)
            {
                return new NotificationLevelEnum(value);
            }
            public static readonly NotificationLevelEnum Default = new NotificationLevelEnum("default");
            public static readonly NotificationLevelEnum Muted = new NotificationLevelEnum("muted");

        }
        [JsonConverter(typeof(StringEnumConverter))]
        public sealed class ChannelStatusEnum : StringEnum
        {
            private ChannelStatusEnum(string value) : base(value) {}
            public ChannelStatusEnum() {}
            public static implicit operator ChannelStatusEnum(string value)
            {
                return new ChannelStatusEnum(value);
            }
            public static readonly ChannelStatusEnum Joined = new ChannelStatusEnum("joined");
            public static readonly ChannelStatusEnum Invited = new ChannelStatusEnum("invited");
            public static readonly ChannelStatusEnum NotParticipating = new ChannelStatusEnum("not_participating");

        }

        
        /// <summary> delete </summary>
        /// <param name="options"> Delete UserChannel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserChannel </returns>
        private static Request BuildDeleteRequest(DeleteUserChannelOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/Users/{UserSid}/Channels/{ChannelSid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathUserSid = options.PathUserSid;
            path = path.Replace("{"+"UserSid"+"}", PathUserSid);
            string PathChannelSid = options.PathChannelSid;
            path = path.Replace("{"+"ChannelSid"+"}", PathChannelSid);

            return new Request(
                HttpMethod.Delete,
                Rest.Domain.IpMessaging,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> delete </summary>
        /// <param name="options"> Delete UserChannel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserChannel </returns>
        public static bool Delete(DeleteUserChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="options"> Delete UserChannel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserChannel </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteUserChannelOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> delete </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathUserSid">  </param>
        /// <param name="pathChannelSid">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserChannel </returns>
        public static bool Delete(string pathServiceSid, string pathUserSid, string pathChannelSid, ITwilioRestClient client = null)
        {
            var options = new DeleteUserChannelOptions(pathServiceSid, pathUserSid, pathChannelSid)           ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathUserSid">  </param>
        /// <param name="pathChannelSid">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserChannel </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathServiceSid, string pathUserSid, string pathChannelSid, ITwilioRestClient client = null)
        {
            var options = new DeleteUserChannelOptions(pathServiceSid, pathUserSid, pathChannelSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchUserChannelOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/Users/{UserSid}/Channels/{ChannelSid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathUserSid = options.PathUserSid;
            path = path.Replace("{"+"UserSid"+"}", PathUserSid);
            string PathChannelSid = options.PathChannelSid;
            path = path.Replace("{"+"ChannelSid"+"}", PathChannelSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.IpMessaging,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> fetch </summary>
        /// <param name="options"> Fetch UserChannel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserChannel </returns>
        public static UserChannelResource Fetch(FetchUserChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch UserChannel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserChannel </returns>
        public static async System.Threading.Tasks.Task<UserChannelResource> FetchAsync(FetchUserChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathUserSid">  </param>
        /// <param name="pathChannelSid">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserChannel </returns>
        public static UserChannelResource Fetch(
                                         string pathServiceSid, 
                                         string pathUserSid, 
                                         string pathChannelSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchUserChannelOptions(pathServiceSid, pathUserSid, pathChannelSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathUserSid">  </param>
        /// <param name="pathChannelSid">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserChannel </returns>
        public static async System.Threading.Tasks.Task<UserChannelResource> FetchAsync(string pathServiceSid, string pathUserSid, string pathChannelSid, ITwilioRestClient client = null)
        {
            var options = new FetchUserChannelOptions(pathServiceSid, pathUserSid, pathChannelSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadUserChannelOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/Users/{UserSid}/Channels";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathUserSid = options.PathUserSid;
            path = path.Replace("{"+"UserSid"+"}", PathUserSid);

            return new Request(
                HttpMethod.Get,
                Rest.Domain.IpMessaging,
                path,
                queryParams: options.GetParams(),
                headerParams: null
            );
        }
        /// <summary> read </summary>
        /// <param name="options"> Read UserChannel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserChannel </returns>
        public static ResourceSet<UserChannelResource> Read(ReadUserChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<UserChannelResource>.FromJson("channels", response.Content);
            return new ResourceSet<UserChannelResource>(page, options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="options"> Read UserChannel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserChannel </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<UserChannelResource>> ReadAsync(ReadUserChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<UserChannelResource>.FromJson("channels", response.Content);
            return new ResourceSet<UserChannelResource>(page, options, client);
        }
        #endif
        /// <summary> read </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathUserSid">  </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserChannel </returns>
        public static ResourceSet<UserChannelResource> Read(
                                                     string pathServiceSid,
                                                     string pathUserSid,
                                                     long? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadUserChannelOptions(pathServiceSid, pathUserSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathUserSid">  </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserChannel </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<UserChannelResource>> ReadAsync(
                                                                                             string pathServiceSid,
                                                                                             string pathUserSid,
                                                                                             long? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadUserChannelOptions(pathServiceSid, pathUserSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<UserChannelResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<UserChannelResource>.FromJson("channels", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<UserChannelResource> NextPage(Page<UserChannelResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<UserChannelResource>.FromJson("channels", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<UserChannelResource> PreviousPage(Page<UserChannelResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<UserChannelResource>.FromJson("channels", response.Content);
        }

        
        private static Request BuildUpdateRequest(UpdateUserChannelOptions options, ITwilioRestClient client)
        {
            
            string path = "/v2/Services/{ServiceSid}/Users/{UserSid}/Channels/{ChannelSid}";

            string PathServiceSid = options.PathServiceSid;
            path = path.Replace("{"+"ServiceSid"+"}", PathServiceSid);
            string PathUserSid = options.PathUserSid;
            path = path.Replace("{"+"UserSid"+"}", PathUserSid);
            string PathChannelSid = options.PathChannelSid;
            path = path.Replace("{"+"ChannelSid"+"}", PathChannelSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.IpMessaging,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> update </summary>
        /// <param name="options"> Update UserChannel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserChannel </returns>
        public static UserChannelResource Update(UpdateUserChannelOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> update </summary>
        /// <param name="options"> Update UserChannel parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserChannel </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<UserChannelResource> UpdateAsync(UpdateUserChannelOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> update </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathUserSid">  </param>
        /// <param name="pathChannelSid">  </param>
        /// <param name="notificationLevel">  </param>
        /// <param name="lastConsumedMessageIndex">  </param>
        /// <param name="lastConsumptionTimestamp">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of UserChannel </returns>
        public static UserChannelResource Update(
                                          string pathServiceSid,
                                          string pathUserSid,
                                          string pathChannelSid,
                                          UserChannelResource.NotificationLevelEnum notificationLevel = null,
                                          int? lastConsumedMessageIndex = null,
                                          DateTime? lastConsumptionTimestamp = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdateUserChannelOptions(pathServiceSid, pathUserSid, pathChannelSid){ NotificationLevel = notificationLevel, LastConsumedMessageIndex = lastConsumedMessageIndex, LastConsumptionTimestamp = lastConsumptionTimestamp };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> update </summary>
        /// <param name="pathServiceSid">  </param>
        /// <param name="pathUserSid">  </param>
        /// <param name="pathChannelSid">  </param>
        /// <param name="notificationLevel">  </param>
        /// <param name="lastConsumedMessageIndex">  </param>
        /// <param name="lastConsumptionTimestamp">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of UserChannel </returns>
        public static async System.Threading.Tasks.Task<UserChannelResource> UpdateAsync(
                                                                              string pathServiceSid,
                                                                              string pathUserSid,
                                                                              string pathChannelSid,
                                                                              UserChannelResource.NotificationLevelEnum notificationLevel = null,
                                                                              int? lastConsumedMessageIndex = null,
                                                                              DateTime? lastConsumptionTimestamp = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdateUserChannelOptions(pathServiceSid, pathUserSid, pathChannelSid){ NotificationLevel = notificationLevel, LastConsumedMessageIndex = lastConsumedMessageIndex, LastConsumptionTimestamp = lastConsumptionTimestamp };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a UserChannelResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> UserChannelResource object represented by the provided JSON </returns>
        public static UserChannelResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<UserChannelResource>(json);
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

    
        ///<summary> The account_sid </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The service_sid </summary> 
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }

        ///<summary> The channel_sid </summary> 
        [JsonProperty("channel_sid")]
        public string ChannelSid { get; private set; }

        ///<summary> The user_sid </summary> 
        [JsonProperty("user_sid")]
        public string UserSid { get; private set; }

        ///<summary> The member_sid </summary> 
        [JsonProperty("member_sid")]
        public string MemberSid { get; private set; }

        
        [JsonProperty("status")]
        public UserChannelResource.ChannelStatusEnum Status { get; private set; }

        ///<summary> The last_consumed_message_index </summary> 
        [JsonProperty("last_consumed_message_index")]
        public int? LastConsumedMessageIndex { get; private set; }

        ///<summary> The unread_messages_count </summary> 
        [JsonProperty("unread_messages_count")]
        public int? UnreadMessagesCount { get; private set; }

        ///<summary> The links </summary> 
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }

        ///<summary> The url </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }

        
        [JsonProperty("notification_level")]
        public UserChannelResource.NotificationLevelEnum NotificationLevel { get; private set; }



        private UserChannelResource() {

        }
    }
}

