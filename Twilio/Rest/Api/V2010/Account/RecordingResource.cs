using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class RecordingResource : Resource 
    {
        public sealed class SourceEnum : StringEnum 
        {
            private SourceEnum(string value) : base(value) {}
            public SourceEnum() {}
        
            public static readonly SourceEnum Dialverb = new SourceEnum("DialVerb");
            public static readonly SourceEnum Conference = new SourceEnum("Conference");
            public static readonly SourceEnum Outboundapi = new SourceEnum("OutboundAPI");
            public static readonly SourceEnum Trunking = new SourceEnum("Trunking");
            public static readonly SourceEnum Recordverb = new SourceEnum("RecordVerb");
        }
    
        public sealed class StatusEnum : StringEnum 
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}
        
            public static readonly StatusEnum Processing = new StatusEnum("processing");
            public static readonly StatusEnum Completed = new StatusEnum("completed");
        }
    
        private static Request BuildFetchRequest(FetchRecordingOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Recordings/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Fetch an instance of a recording
        /// </summary>
        public static RecordingResource Fetch(FetchRecordingOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<RecordingResource> FetchAsync(FetchRecordingOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Fetch an instance of a recording
        /// </summary>
        public static RecordingResource Fetch(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchRecordingOptions(sid){AccountSid = accountSid};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<RecordingResource> FetchAsync(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchRecordingOptions(sid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteRecordingOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Recordings/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Delete a recording from your account
        /// </summary>
        public static bool Delete(DeleteRecordingOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteRecordingOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Delete a recording from your account
        /// </summary>
        public static bool Delete(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteRecordingOptions(sid){AccountSid = accountSid};
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteRecordingOptions(sid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        private static Request BuildReadRequest(ReadRecordingOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Recordings.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Retrieve a list of recordings belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<RecordingResource> Read(ReadRecordingOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<RecordingResource>.FromJson("recordings", response.Content);
            return new ResourceSet<RecordingResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<RecordingResource>> ReadAsync(ReadRecordingOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Retrieve a list of recordings belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<RecordingResource> Read(string accountSid = null, string dateCreated = null, string callSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadRecordingOptions{AccountSid = accountSid, DateCreated = dateCreated, CallSid = callSid, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<RecordingResource>> ReadAsync(string accountSid = null, string dateCreated = null, string callSid = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadRecordingOptions{AccountSid = accountSid, DateCreated = dateCreated, CallSid = callSid, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<RecordingResource> NextPage(Page<RecordingResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<RecordingResource>.FromJson("recordings", response.Content);
        }
    
        /// <summary>
        /// Converts a JSON string into a RecordingResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> RecordingResource object represented by the provided JSON </returns> 
        public static RecordingResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<RecordingResource>(json);
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
        [JsonProperty("duration")]
        public string Duration { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("price")]
        public string Price { get; private set; }
        [JsonProperty("price_unit")]
        public string PriceUnit { get; private set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RecordingResource.StatusEnum Status { get; private set; }
        [JsonProperty("channels")]
        public int? Channels { get; private set; }
        [JsonProperty("source")]
        [JsonConverter(typeof(StringEnumConverter))]
        public RecordingResource.SourceEnum Source { get; private set; }
        [JsonProperty("uri")]
        public string Uri { get; private set; }
    
        private RecordingResource()
        {
        
        }
    }

}