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
    public class ChannelSenderResource : Resource
    {
    

    

        
        private static Request BuildCreateRequest(CreateChannelSenderOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{MessagingServiceSid}/ChannelSenders";

            string PathMessagingServiceSid = options.PathMessagingServiceSid;
            path = path.Replace("{"+"MessagingServiceSid"+"}", PathMessagingServiceSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Messaging,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> create </summary>
        /// <param name="options"> Create ChannelSender parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ChannelSender </returns>
        public static ChannelSenderResource Create(CreateChannelSenderOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="options"> Create ChannelSender parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ChannelSender </returns>
        public static async System.Threading.Tasks.Task<ChannelSenderResource> CreateAsync(CreateChannelSenderOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> create </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to create the resource under. </param>
        /// <param name="sid"> The SID of the Channel Sender being added to the Service. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ChannelSender </returns>
        public static ChannelSenderResource Create(
                                          string pathMessagingServiceSid,
                                          string sid,
                                            ITwilioRestClient client = null)
        {
            var options = new CreateChannelSenderOptions(pathMessagingServiceSid, sid){  };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> create </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to create the resource under. </param>
        /// <param name="sid"> The SID of the Channel Sender being added to the Service. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ChannelSender </returns>
        public static async System.Threading.Tasks.Task<ChannelSenderResource> CreateAsync(
                                                                                  string pathMessagingServiceSid,
                                                                                  string sid,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreateChannelSenderOptions(pathMessagingServiceSid, sid){  };
            return await CreateAsync(options, client);
        }
        #endif
        
        /// <summary> delete </summary>
        /// <param name="options"> Delete ChannelSender parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ChannelSender </returns>
        private static Request BuildDeleteRequest(DeleteChannelSenderOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{MessagingServiceSid}/ChannelSenders/{Sid}";

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
        /// <param name="options"> Delete ChannelSender parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ChannelSender </returns>
        public static bool Delete(DeleteChannelSenderOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="options"> Delete ChannelSender parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ChannelSender </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteChannelSenderOptions options,
                                                                        ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif

        /// <summary> delete </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to delete the resource from. </param>
        /// <param name="pathSid"> The SID of the Channel Sender resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ChannelSender </returns>
        public static bool Delete(string pathMessagingServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteChannelSenderOptions(pathMessagingServiceSid, pathSid)        ;
            return Delete(options, client);
        }

        #if !NET35
        /// <summary> delete </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to delete the resource from. </param>
        /// <param name="pathSid"> The SID of the Channel Sender resource to delete. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ChannelSender </returns>
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string pathMessagingServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new DeleteChannelSenderOptions(pathMessagingServiceSid, pathSid) ;
            return await DeleteAsync(options, client);
        }
        #endif
        
        private static Request BuildFetchRequest(FetchChannelSenderOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{MessagingServiceSid}/ChannelSenders/{Sid}";

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
        /// <param name="options"> Fetch ChannelSender parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ChannelSender </returns>
        public static ChannelSenderResource Fetch(FetchChannelSenderOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="options"> Fetch ChannelSender parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ChannelSender </returns>
        public static async System.Threading.Tasks.Task<ChannelSenderResource> FetchAsync(FetchChannelSenderOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
        /// <summary> fetch </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to fetch the resource from. </param>
        /// <param name="pathSid"> The SID of the ChannelSender resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ChannelSender </returns>
        public static ChannelSenderResource Fetch(
                                         string pathMessagingServiceSid, 
                                         string pathSid, 
                                        ITwilioRestClient client = null)
        {
            var options = new FetchChannelSenderOptions(pathMessagingServiceSid, pathSid){  };
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary> fetch </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to fetch the resource from. </param>
        /// <param name="pathSid"> The SID of the ChannelSender resource to fetch. </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ChannelSender </returns>
        public static async System.Threading.Tasks.Task<ChannelSenderResource> FetchAsync(string pathMessagingServiceSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchChannelSenderOptions(pathMessagingServiceSid, pathSid){  };
            return await FetchAsync(options, client);
        }
        #endif
        
        private static Request BuildReadRequest(ReadChannelSenderOptions options, ITwilioRestClient client)
        {
            
            string path = "/v1/Services/{MessagingServiceSid}/ChannelSenders";

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
        /// <param name="options"> Read ChannelSender parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ChannelSender </returns>
        public static ResourceSet<ChannelSenderResource> Read(ReadChannelSenderOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            var page = Page<ChannelSenderResource>.FromJson("senders", response.Content);
            return new ResourceSet<ChannelSenderResource>(page, options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="options"> Read ChannelSender parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ChannelSender </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ChannelSenderResource>> ReadAsync(ReadChannelSenderOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));

            var page = Page<ChannelSenderResource>.FromJson("senders", response.Content);
            return new ResourceSet<ChannelSenderResource>(page, options, client);
        }
        #endif
        /// <summary> read </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to read the resources from. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of ChannelSender </returns>
        public static ResourceSet<ChannelSenderResource> Read(
                                                     string pathMessagingServiceSid,
                                                     int? pageSize = null,
                                                     long? limit = null,
                                                    ITwilioRestClient client = null)
        {
            var options = new ReadChannelSenderOptions(pathMessagingServiceSid){ PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary> read </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to read the resources from. </param>
        /// <param name="pageSize"> How many resources to return in each list page. The default is 50, and the maximum is 1000. </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of ChannelSender </returns>
        public static async System.Threading.Tasks.Task<ResourceSet<ChannelSenderResource>> ReadAsync(
                                                                                             string pathMessagingServiceSid,
                                                                                             int? pageSize = null,
                                                                                             long? limit = null,
                                                                                            ITwilioRestClient client = null)
        {
            var options = new ReadChannelSenderOptions(pathMessagingServiceSid){ PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        
        /// <summary> Fetch the target page of records </summary>
        /// <param name="targetUrl"> API-generated URL for the requested results page </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The target page of records </returns>
        public static Page<ChannelSenderResource> GetPage(string targetUrl, ITwilioRestClient client)
        {
            client = client ?? TwilioClient.GetRestClient();

            var request = new Request(
                HttpMethod.Get,
                targetUrl
            );

            var response = client.Request(request);
            return Page<ChannelSenderResource>.FromJson("senders", response.Content);
        }

        /// <summary> Fetch the next page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns>
        public static Page<ChannelSenderResource> NextPage(Page<ChannelSenderResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ChannelSenderResource>.FromJson("senders", response.Content);
        }

        /// <summary> Fetch the previous page of records </summary>
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The previous page of records </returns>
        public static Page<ChannelSenderResource> PreviousPage(Page<ChannelSenderResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetPreviousPageUrl(Rest.Domain.Api)
            );

            var response = client.Request(request);
            return Page<ChannelSenderResource>.FromJson("senders", response.Content);
        }

    
        /// <summary>
        /// Converts a JSON string into a ChannelSenderResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ChannelSenderResource object represented by the provided JSON </returns>
        public static ChannelSenderResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<ChannelSenderResource>(json);
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

    
        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the ChannelSender resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The SID of the [Service](https://www.twilio.com/docs/messaging/services) the resource is associated with. </summary> 
        [JsonProperty("messaging_service_sid")]
        public string MessagingServiceSid { get; private set; }

        ///<summary> The unique string that we created to identify the ChannelSender resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The unique string that identifies the sender e.g whatsapp:+123456XXXX. </summary> 
        [JsonProperty("sender")]
        public string Sender { get; private set; }

        ///<summary> A string value that identifies the sender type e.g WhatsApp, Messenger. </summary> 
        [JsonProperty("sender_type")]
        public string SenderType { get; private set; }

        ///<summary> The 2-character [ISO Country Code](https://www.iso.org/iso-3166-country-codes.html) of the number. </summary> 
        [JsonProperty("country_code")]
        public string CountryCode { get; private set; }

        ///<summary> The date and time in GMT when the resource was created specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT when the resource was last updated specified in [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The absolute URL of the ChannelSender resource. </summary> 
        [JsonProperty("url")]
        public Uri Url { get; private set; }



        private ChannelSenderResource() {

        }
    }
}

