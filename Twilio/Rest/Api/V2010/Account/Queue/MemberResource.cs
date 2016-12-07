using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Queue 
{

    public class MemberResource : Resource 
    {
        private static Request BuildFetchRequest(FetchMemberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Queues/" + options.QueueSid + "/Members/" + options.CallSid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Fetch a specific members of the queue
        /// </summary>
        public static MemberResource Fetch(FetchMemberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<MemberResource> FetchAsync(FetchMemberOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Fetch a specific members of the queue
        /// </summary>
        public static MemberResource Fetch(string queueSid, string callSid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchMemberOptions(queueSid, callSid){AccountSid = accountSid};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<MemberResource> FetchAsync(string queueSid, string callSid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchMemberOptions(queueSid, callSid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateMemberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Queues/" + options.QueueSid + "/Members/" + options.CallSid + ".json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Dequeue a member from a queue and have the member's call begin executing the TwiML document at that URL
        /// </summary>
        public static MemberResource Update(UpdateMemberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<MemberResource> UpdateAsync(UpdateMemberOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Dequeue a member from a queue and have the member's call begin executing the TwiML document at that URL
        /// </summary>
        public static MemberResource Update(string queueSid, string callSid, Uri url, Twilio.Http.HttpMethod method, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new UpdateMemberOptions(queueSid, callSid, url, method){AccountSid = accountSid};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<MemberResource> UpdateAsync(string queueSid, string callSid, Uri url, Twilio.Http.HttpMethod method, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new UpdateMemberOptions(queueSid, callSid, url, method){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        private static Request BuildReadRequest(ReadMemberOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Queues/" + options.QueueSid + "/Members.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Retrieve a list of members in the queue
        /// </summary>
        public static ResourceSet<MemberResource> Read(ReadMemberOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<MemberResource>.FromJson("queue_members", response.Content);
            return new ResourceSet<MemberResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<MemberResource>> ReadAsync(ReadMemberOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Retrieve a list of members in the queue
        /// </summary>
        public static ResourceSet<MemberResource> Read(string queueSid, string accountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadMemberOptions(queueSid){AccountSid = accountSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<MemberResource>> ReadAsync(string queueSid, string accountSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadMemberOptions(queueSid){AccountSid = accountSid, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<MemberResource> NextPage(Page<MemberResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<MemberResource>.FromJson("queue_members", response.Content);
        }
    
        /// <summary>
        /// Converts a JSON string into a MemberResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> MemberResource object represented by the provided JSON </returns> 
        public static MemberResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<MemberResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("call_sid")]
        public string CallSid { get; private set; }
        [JsonProperty("date_enqueued")]
        public DateTime? DateEnqueued { get; private set; }
        [JsonProperty("position")]
        public int? Position { get; private set; }
        [JsonProperty("uri")]
        public string Uri { get; private set; }
        [JsonProperty("wait_time")]
        public int? WaitTime { get; private set; }
    
        private MemberResource()
        {
        
        }
    }

}