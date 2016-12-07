using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Call 
{

    public class NotificationResource : Resource 
    {
        private static Request BuildFetchRequest(FetchNotificationOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Calls/" + options.CallSid + "/Notifications/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static NotificationResource Fetch(FetchNotificationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<NotificationResource> FetchAsync(FetchNotificationOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static NotificationResource Fetch(string callSid, string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchNotificationOptions(callSid, sid){AccountSid = accountSid};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<NotificationResource> FetchAsync(string callSid, string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchNotificationOptions(callSid, sid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteNotificationOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Calls/" + options.CallSid + "/Notifications/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeleteNotificationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteNotificationOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(string callSid, string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteNotificationOptions(callSid, sid){AccountSid = accountSid};
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string callSid, string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteNotificationOptions(callSid, sid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        private static Request BuildReadRequest(ReadNotificationOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Calls/" + options.CallSid + "/Notifications.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<NotificationResource> Read(ReadNotificationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<NotificationResource>.FromJson("notifications", response.Content);
            return new ResourceSet<NotificationResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<NotificationResource>> ReadAsync(ReadNotificationOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<NotificationResource> Read(string callSid, string accountSid = null, int? log = null, DateTime? messageDateBefore = null, DateTime? messageDate = null, DateTime? messageDateAfter = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadNotificationOptions(callSid){AccountSid = accountSid, Log = log, MessageDateBefore = messageDateBefore, MessageDate = messageDate, MessageDateAfter = messageDateAfter, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<NotificationResource>> ReadAsync(string callSid, string accountSid = null, int? log = null, DateTime? messageDateBefore = null, DateTime? messageDate = null, DateTime? messageDateAfter = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadNotificationOptions(callSid){AccountSid = accountSid, Log = log, MessageDateBefore = messageDateBefore, MessageDate = messageDate, MessageDateAfter = messageDateAfter, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<NotificationResource> NextPage(Page<NotificationResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<NotificationResource>.FromJson("notifications", response.Content);
        }
    
        /// <summary>
        /// Converts a JSON string into a NotificationResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> NotificationResource object represented by the provided JSON </returns> 
        public static NotificationResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<NotificationResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("api_version")]
        public string ApiVersion { get; private set; }
        [JsonProperty("call_sid")]
        public string CallSid { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("error_code")]
        public string ErrorCode { get; private set; }
        [JsonProperty("log")]
        public string Log { get; private set; }
        [JsonProperty("message_date")]
        public DateTime? MessageDate { get; private set; }
        [JsonProperty("message_text")]
        public string MessageText { get; private set; }
        [JsonProperty("more_info")]
        public Uri MoreInfo { get; private set; }
        [JsonProperty("request_method")]
        [JsonConverter(typeof(HttpMethodConverter))]
        public Twilio.Http.HttpMethod RequestMethod { get; private set; }
        [JsonProperty("request_url")]
        public Uri RequestUrl { get; private set; }
        [JsonProperty("request_variables")]
        public string RequestVariables { get; private set; }
        [JsonProperty("response_body")]
        public string ResponseBody { get; private set; }
        [JsonProperty("response_headers")]
        public string ResponseHeaders { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("uri")]
        public string Uri { get; private set; }
    
        private NotificationResource()
        {
        
        }
    }

}