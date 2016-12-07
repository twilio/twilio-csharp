using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Worker 
{

    public class ReservationResource : Resource 
    {
        public sealed class StatusEnum : StringEnum 
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}
        
            public static readonly StatusEnum Pending = new StatusEnum("pending");
            public static readonly StatusEnum Accepted = new StatusEnum("accepted");
            public static readonly StatusEnum Rejected = new StatusEnum("rejected");
            public static readonly StatusEnum Timeout = new StatusEnum("timeout");
            public static readonly StatusEnum Canceled = new StatusEnum("canceled");
            public static readonly StatusEnum Rescinded = new StatusEnum("rescinded");
        }
    
        private static Request BuildReadRequest(ReadReservationOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/Workers/" + options.WorkerSid + "/Reservations",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<ReservationResource> Read(ReadReservationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<ReservationResource>.FromJson("reservations", response.Content);
            return new ResourceSet<ReservationResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<ReservationResource>> ReadAsync(ReadReservationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildReadRequest(options, client));
            
            var page = Page<ReservationResource>.FromJson("reservations", response.Content);
            return new ResourceSet<ReservationResource>(page, options, client);
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<ReservationResource> Read(string workspaceSid, string workerSid, ReservationResource.StatusEnum reservationStatus = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadReservationOptions(workspaceSid, workerSid){ReservationStatus = reservationStatus, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<ReservationResource>> ReadAsync(string workspaceSid, string workerSid, ReservationResource.StatusEnum reservationStatus = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadReservationOptions(workspaceSid, workerSid){ReservationStatus = reservationStatus, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif
    
        public static Page<ReservationResource> NextPage(Page<ReservationResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Taskrouter,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<ReservationResource>.FromJson("reservations", response.Content);
        }
    
        private static Request BuildFetchRequest(FetchReservationOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/Workers/" + options.WorkerSid + "/Reservations/" + options.Sid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static ReservationResource Fetch(FetchReservationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ReservationResource> FetchAsync(FetchReservationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static ReservationResource Fetch(string workspaceSid, string workerSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchReservationOptions(workspaceSid, workerSid, sid);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ReservationResource> FetchAsync(string workspaceSid, string workerSid, string sid, ITwilioRestClient client = null)
        {
            var options = new FetchReservationOptions(workspaceSid, workerSid, sid);
            return await FetchAsync(options, client);
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateReservationOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.WorkspaceSid + "/Workers/" + options.WorkerSid + "/Reservations/" + options.Sid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static ReservationResource Update(UpdateReservationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ReservationResource> UpdateAsync(UpdateReservationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static ReservationResource Update(string workspaceSid, string workerSid, string sid, ReservationResource.StatusEnum reservationStatus = null, string workerActivitySid = null, string instruction = null, string dequeuePostWorkActivitySid = null, string dequeueFrom = null, string dequeueRecord = null, int? dequeueTimeout = null, string dequeueTo = null, Uri dequeueStatusCallbackUrl = null, string callFrom = null, string callRecord = null, int? callTimeout = null, string callTo = null, Uri callUrl = null, Uri callStatusCallbackUrl = null, bool? callAccept = null, string redirectCallSid = null, bool? redirectAccept = null, Uri redirectUrl = null, ITwilioRestClient client = null)
        {
            var options = new UpdateReservationOptions(workspaceSid, workerSid, sid){ReservationStatus = reservationStatus, WorkerActivitySid = workerActivitySid, Instruction = instruction, DequeuePostWorkActivitySid = dequeuePostWorkActivitySid, DequeueFrom = dequeueFrom, DequeueRecord = dequeueRecord, DequeueTimeout = dequeueTimeout, DequeueTo = dequeueTo, DequeueStatusCallbackUrl = dequeueStatusCallbackUrl, CallFrom = callFrom, CallRecord = callRecord, CallTimeout = callTimeout, CallTo = callTo, CallUrl = callUrl, CallStatusCallbackUrl = callStatusCallbackUrl, CallAccept = callAccept, RedirectCallSid = redirectCallSid, RedirectAccept = redirectAccept, RedirectUrl = redirectUrl};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ReservationResource> UpdateAsync(string workspaceSid, string workerSid, string sid, ReservationResource.StatusEnum reservationStatus = null, string workerActivitySid = null, string instruction = null, string dequeuePostWorkActivitySid = null, string dequeueFrom = null, string dequeueRecord = null, int? dequeueTimeout = null, string dequeueTo = null, Uri dequeueStatusCallbackUrl = null, string callFrom = null, string callRecord = null, int? callTimeout = null, string callTo = null, Uri callUrl = null, Uri callStatusCallbackUrl = null, bool? callAccept = null, string redirectCallSid = null, bool? redirectAccept = null, Uri redirectUrl = null, ITwilioRestClient client = null)
        {
            var options = new UpdateReservationOptions(workspaceSid, workerSid, sid){ReservationStatus = reservationStatus, WorkerActivitySid = workerActivitySid, Instruction = instruction, DequeuePostWorkActivitySid = dequeuePostWorkActivitySid, DequeueFrom = dequeueFrom, DequeueRecord = dequeueRecord, DequeueTimeout = dequeueTimeout, DequeueTo = dequeueTo, DequeueStatusCallbackUrl = dequeueStatusCallbackUrl, CallFrom = callFrom, CallRecord = callRecord, CallTimeout = callTimeout, CallTo = callTo, CallUrl = callUrl, CallStatusCallbackUrl = callStatusCallbackUrl, CallAccept = callAccept, RedirectCallSid = redirectCallSid, RedirectAccept = redirectAccept, RedirectUrl = redirectUrl};
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a ReservationResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ReservationResource object represented by the provided JSON </returns> 
        public static ReservationResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<ReservationResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("reservation_status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ReservationResource.StatusEnum ReservationStatus { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("task_sid")]
        public string TaskSid { get; private set; }
        [JsonProperty("worker_name")]
        public string WorkerName { get; private set; }
        [JsonProperty("worker_sid")]
        public string WorkerSid { get; private set; }
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }
    
        private ReservationResource()
        {
        
        }
    }

}