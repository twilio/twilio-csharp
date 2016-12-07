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

    public class CallResource : Resource 
    {
        public sealed class EventEnum : StringEnum 
        {
            private EventEnum(string value) : base(value) {}
            public EventEnum() {}
        
            public static readonly EventEnum Initiated = new EventEnum("initiated");
            public static readonly EventEnum Ringing = new EventEnum("ringing");
            public static readonly EventEnum Answered = new EventEnum("answered");
            public static readonly EventEnum Completed = new EventEnum("completed");
        }
    
        public sealed class StatusEnum : StringEnum 
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}
        
            public static readonly StatusEnum Queued = new StatusEnum("queued");
            public static readonly StatusEnum Ringing = new StatusEnum("ringing");
            public static readonly StatusEnum InProgress = new StatusEnum("in-progress");
            public static readonly StatusEnum Completed = new StatusEnum("completed");
            public static readonly StatusEnum Busy = new StatusEnum("busy");
            public static readonly StatusEnum Failed = new StatusEnum("failed");
            public static readonly StatusEnum NoAnswer = new StatusEnum("no-answer");
            public static readonly StatusEnum Canceled = new StatusEnum("canceled");
        }
    
        public sealed class UpdateStatusEnum : StringEnum 
        {
            private UpdateStatusEnum(string value) : base(value) {}
            public UpdateStatusEnum() {}
        
            public static readonly UpdateStatusEnum Canceled = new UpdateStatusEnum("canceled");
            public static readonly UpdateStatusEnum Completed = new UpdateStatusEnum("completed");
        }
    
        private static Request BuildCreateRequest(CreateCallOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Calls.json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Create a new outgoing call to phones, SIP-enabled endpoints or Twilio Client connections
        /// </summary>
        public static CallResource Create(CreateCallOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<CallResource> CreateAsync(CreateCallOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Create a new outgoing call to phones, SIP-enabled endpoints or Twilio Client connections
        /// </summary>
        public static CallResource Create(IEndpoint to, Types.PhoneNumber from, string accountSid = null, Uri url = null, string applicationSid = null, Twilio.Http.HttpMethod method = null, Uri fallbackUrl = null, Twilio.Http.HttpMethod fallbackMethod = null, Uri statusCallback = null, List<string> statusCallbackEvent = null, Twilio.Http.HttpMethod statusCallbackMethod = null, string sendDigits = null, string ifMachine = null, string machineDetection = null, int? machineDetectionTimeout = null, int? timeout = null, bool? record = null, string recordingChannels = null, string recordingStatusCallback = null, Twilio.Http.HttpMethod recordingStatusCallbackMethod = null, string sipAuthUsername = null, string sipAuthPassword = null, ITwilioRestClient client = null)
        {
            var options = new CreateCallOptions(to, from){AccountSid = accountSid, Url = url, ApplicationSid = applicationSid, Method = method, FallbackUrl = fallbackUrl, FallbackMethod = fallbackMethod, StatusCallback = statusCallback, StatusCallbackEvent = statusCallbackEvent, StatusCallbackMethod = statusCallbackMethod, SendDigits = sendDigits, IfMachine = ifMachine, MachineDetection = machineDetection, MachineDetectionTimeout = machineDetectionTimeout, Timeout = timeout, Record = record, RecordingChannels = recordingChannels, RecordingStatusCallback = recordingStatusCallback, RecordingStatusCallbackMethod = recordingStatusCallbackMethod, SipAuthUsername = sipAuthUsername, SipAuthPassword = sipAuthPassword};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<CallResource> CreateAsync(IEndpoint to, Types.PhoneNumber from, string accountSid = null, Uri url = null, string applicationSid = null, Twilio.Http.HttpMethod method = null, Uri fallbackUrl = null, Twilio.Http.HttpMethod fallbackMethod = null, Uri statusCallback = null, List<string> statusCallbackEvent = null, Twilio.Http.HttpMethod statusCallbackMethod = null, string sendDigits = null, string ifMachine = null, string machineDetection = null, int? machineDetectionTimeout = null, int? timeout = null, bool? record = null, string recordingChannels = null, string recordingStatusCallback = null, Twilio.Http.HttpMethod recordingStatusCallbackMethod = null, string sipAuthUsername = null, string sipAuthPassword = null, ITwilioRestClient client = null)
        {
            var options = new CreateCallOptions(to, from){AccountSid = accountSid, Url = url, ApplicationSid = applicationSid, Method = method, FallbackUrl = fallbackUrl, FallbackMethod = fallbackMethod, StatusCallback = statusCallback, StatusCallbackEvent = statusCallbackEvent, StatusCallbackMethod = statusCallbackMethod, SendDigits = sendDigits, IfMachine = ifMachine, MachineDetection = machineDetection, MachineDetectionTimeout = machineDetectionTimeout, Timeout = timeout, Record = record, RecordingChannels = recordingChannels, RecordingStatusCallback = recordingStatusCallback, RecordingStatusCallbackMethod = recordingStatusCallbackMethod, SipAuthUsername = sipAuthUsername, SipAuthPassword = sipAuthPassword};
            return await CreateAsync(options, client);
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteCallOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Calls/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Once the record is deleted, it will no longer appear in the API and Account Portal logs.
        /// </summary>
        public static bool Delete(DeleteCallOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteCallOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
        #endif
    
        /// <summary>
        /// Once the record is deleted, it will no longer appear in the API and Account Portal logs.
        /// </summary>
        public static bool Delete(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteCallOptions(sid){AccountSid = accountSid};
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteCallOptions(sid){AccountSid = accountSid};
            return await DeleteAsync(options, client);
        }
        #endif
    
        private static Request BuildFetchRequest(FetchCallOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Calls/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Fetch the Call specified by the provided Call Sid
        /// </summary>
        public static CallResource Fetch(FetchCallOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<CallResource> FetchAsync(FetchCallOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Fetch the Call specified by the provided Call Sid
        /// </summary>
        public static CallResource Fetch(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchCallOptions(sid){AccountSid = accountSid};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<CallResource> FetchAsync(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchCallOptions(sid){AccountSid = accountSid};
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildReadRequest(ReadCallOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Calls.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Retrieves a collection of Calls made to and from your account
        /// </summary>
        public static ResourceSet<CallResource> Read(ReadCallOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<CallResource>.FromJson("calls", response.Content);
            return new ResourceSet<CallResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<CallResource>> ReadAsync(ReadCallOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<CallResource>.FromJson("calls", response.Content);
            return new ResourceSet<CallResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// Retrieves a collection of Calls made to and from your account
        /// </summary>
        public static ResourceSet<CallResource> Read(string accountSid = null, Types.PhoneNumber to = null, Types.PhoneNumber from = null, string parentCallSid = null, CallResource.StatusEnum status = null, DateTime? startTimeBefore = null, DateTime? startTime = null, DateTime? startTimeAfter = null, DateTime? endTimeBefore = null, DateTime? endTime = null, DateTime? endTimeAfter = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadCallOptions{AccountSid = accountSid, To = to, From = from, ParentCallSid = parentCallSid, Status = status, StartTimeBefore = startTimeBefore, StartTime = startTime, StartTimeAfter = startTimeAfter, EndTimeBefore = endTimeBefore, EndTime = endTime, EndTimeAfter = endTimeAfter, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<CallResource>> ReadAsync(string accountSid = null, Types.PhoneNumber to = null, Types.PhoneNumber from = null, string parentCallSid = null, CallResource.StatusEnum status = null, DateTime? startTimeBefore = null, DateTime? startTime = null, DateTime? startTimeAfter = null, DateTime? endTimeBefore = null, DateTime? endTime = null, DateTime? endTimeAfter = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadCallOptions{AccountSid = accountSid, To = to, From = from, ParentCallSid = parentCallSid, Status = status, StartTimeBefore = startTimeBefore, StartTime = startTime, StartTimeAfter = startTimeAfter, EndTimeBefore = endTimeBefore, EndTime = endTime, EndTimeAfter = endTimeAfter, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        public static Page<CallResource> NextPage(Page<CallResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<CallResource>.FromJson("calls", response.Content);
        }
    
        private static Request BuildUpdateRequest(UpdateCallOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Calls/" + options.Sid + ".json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Initiates a call redirect or terminates a call
        /// </summary>
        public static CallResource Update(UpdateCallOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<CallResource> UpdateAsync(UpdateCallOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Initiates a call redirect or terminates a call
        /// </summary>
        public static CallResource Update(string sid, string accountSid = null, Uri url = null, Twilio.Http.HttpMethod method = null, CallResource.UpdateStatusEnum status = null, Uri fallbackUrl = null, Twilio.Http.HttpMethod fallbackMethod = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, ITwilioRestClient client = null)
        {
            var options = new UpdateCallOptions(sid){AccountSid = accountSid, Url = url, Method = method, Status = status, FallbackUrl = fallbackUrl, FallbackMethod = fallbackMethod, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<CallResource> UpdateAsync(string sid, string accountSid = null, Uri url = null, Twilio.Http.HttpMethod method = null, CallResource.UpdateStatusEnum status = null, Uri fallbackUrl = null, Twilio.Http.HttpMethod fallbackMethod = null, Uri statusCallback = null, Twilio.Http.HttpMethod statusCallbackMethod = null, ITwilioRestClient client = null)
        {
            var options = new UpdateCallOptions(sid){AccountSid = accountSid, Url = url, Method = method, Status = status, FallbackUrl = fallbackUrl, FallbackMethod = fallbackMethod, StatusCallback = statusCallback, StatusCallbackMethod = statusCallbackMethod};
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a CallResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CallResource object represented by the provided JSON </returns> 
        public static CallResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<CallResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("annotation")]
        public string Annotation { get; private set; }
        [JsonProperty("answered_by")]
        public string AnsweredBy { get; private set; }
        [JsonProperty("api_version")]
        public string ApiVersion { get; private set; }
        [JsonProperty("caller_name")]
        public string CallerName { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("direction")]
        public string Direction { get; private set; }
        [JsonProperty("duration")]
        public string Duration { get; private set; }
        [JsonProperty("end_time")]
        public DateTime? EndTime { get; private set; }
        [JsonProperty("forwarded_from")]
        public string ForwardedFrom { get; private set; }
        [JsonProperty("from")]
        public string From { get; private set; }
        [JsonProperty("from_formatted")]
        public string FromFormatted { get; private set; }
        [JsonProperty("group_sid")]
        public string GroupSid { get; private set; }
        [JsonProperty("parent_call_sid")]
        public string ParentCallSid { get; private set; }
        [JsonProperty("phone_number_sid")]
        public string PhoneNumberSid { get; private set; }
        [JsonProperty("price")]
        public decimal? Price { get; private set; }
        [JsonProperty("price_unit")]
        public string PriceUnit { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("start_time")]
        public DateTime? StartTime { get; private set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public CallResource.StatusEnum Status { get; private set; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> SubresourceUris { get; private set; }
        [JsonProperty("to")]
        public string To { get; private set; }
        [JsonProperty("to_formatted")]
        public string ToFormatted { get; private set; }
        [JsonProperty("uri")]
        public string Uri { get; private set; }
    
        private CallResource()
        {
        
        }
    }

}