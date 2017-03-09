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

    /// <summary>
    /// ReservationResource
    /// </summary>
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
                "/v1/Workspaces/" + options.PathWorkspaceSid + "/Workers/" + options.PathWorkerSid + "/Reservations",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read Reservation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Reservation </returns> 
        public static ResourceSet<ReservationResource> Read(ReadReservationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));

            var page = Page<ReservationResource>.FromJson("reservations", response.Content);
            return new ResourceSet<ReservationResource>(page, options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="options"> Read Reservation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Reservation </returns> 
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
        ///
        /// <param name="pathWorkspaceSid"> The workspace_sid </param>
        /// <param name="pathWorkerSid"> The worker_sid </param>
        /// <param name="reservationStatus"> The reservation_status </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Reservation </returns> 
        public static ResourceSet<ReservationResource> Read(string pathWorkspaceSid, string pathWorkerSid, ReservationResource.StatusEnum reservationStatus = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadReservationOptions(pathWorkspaceSid, pathWorkerSid){ReservationStatus = reservationStatus, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }

        #if !NET35
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="pathWorkspaceSid"> The workspace_sid </param>
        /// <param name="pathWorkerSid"> The worker_sid </param>
        /// <param name="reservationStatus"> The reservation_status </param>
        /// <param name="pageSize"> Page size </param>
        /// <param name="limit"> Record limit </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Reservation </returns> 
        public static async System.Threading.Tasks.Task<ResourceSet<ReservationResource>> ReadAsync(string pathWorkspaceSid, string pathWorkerSid, ReservationResource.StatusEnum reservationStatus = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadReservationOptions(pathWorkspaceSid, pathWorkerSid){ReservationStatus = reservationStatus, PageSize = pageSize, Limit = limit};
            return await ReadAsync(options, client);
        }
        #endif

        /// <summary>
        /// Fetch the next page of records
        /// </summary>
        ///
        /// <param name="page"> current page of records </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> The next page of records </returns> 
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
                "/v1/Workspaces/" + options.PathWorkspaceSid + "/Workers/" + options.PathWorkerSid + "/Reservations/" + options.PathSid + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }

        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch Reservation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Reservation </returns> 
        public static ReservationResource Fetch(FetchReservationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="options"> Fetch Reservation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Reservation </returns> 
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
        ///
        /// <param name="pathWorkspaceSid"> The workspace_sid </param>
        /// <param name="pathWorkerSid"> The worker_sid </param>
        /// <param name="pathSid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Reservation </returns> 
        public static ReservationResource Fetch(string pathWorkspaceSid, string pathWorkerSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchReservationOptions(pathWorkspaceSid, pathWorkerSid, pathSid);
            return Fetch(options, client);
        }

        #if !NET35
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="pathWorkspaceSid"> The workspace_sid </param>
        /// <param name="pathWorkerSid"> The worker_sid </param>
        /// <param name="pathSid"> The sid </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Reservation </returns> 
        public static async System.Threading.Tasks.Task<ReservationResource> FetchAsync(string pathWorkspaceSid, string pathWorkerSid, string pathSid, ITwilioRestClient client = null)
        {
            var options = new FetchReservationOptions(pathWorkspaceSid, pathWorkerSid, pathSid);
            return await FetchAsync(options, client);
        }
        #endif

        private static Request BuildUpdateRequest(UpdateReservationOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + options.PathWorkspaceSid + "/Workers/" + options.PathWorkerSid + "/Reservations/" + options.PathSid + "",
                client.Region,
                postParams: options.GetParams()
            );
        }

        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="options"> Update Reservation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Reservation </returns> 
        public static ReservationResource Update(UpdateReservationOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="options"> Update Reservation parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Reservation </returns> 
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
        ///
        /// <param name="pathWorkspaceSid"> The workspace_sid </param>
        /// <param name="pathWorkerSid"> The worker_sid </param>
        /// <param name="pathSid"> The sid </param>
        /// <param name="reservationStatus"> The reservation_status </param>
        /// <param name="workerActivitySid"> The worker_activity_sid </param>
        /// <param name="instruction"> The instruction </param>
        /// <param name="dequeuePostWorkActivitySid"> The dequeue_post_work_activity_sid </param>
        /// <param name="dequeueFrom"> The dequeue_from </param>
        /// <param name="dequeueRecord"> The dequeue_record </param>
        /// <param name="dequeueTimeout"> The dequeue_timeout </param>
        /// <param name="dequeueTo"> The dequeue_to </param>
        /// <param name="dequeueStatusCallbackUrl"> The dequeue_status_callback_url </param>
        /// <param name="callFrom"> The call_from </param>
        /// <param name="callRecord"> The call_record </param>
        /// <param name="callTimeout"> The call_timeout </param>
        /// <param name="callTo"> The call_to </param>
        /// <param name="callUrl"> The call_url </param>
        /// <param name="callStatusCallbackUrl"> The call_status_callback_url </param>
        /// <param name="callAccept"> The call_accept </param>
        /// <param name="redirectCallSid"> The redirect_call_sid </param>
        /// <param name="redirectAccept"> The redirect_accept </param>
        /// <param name="redirectUrl"> The redirect_url </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Reservation </returns> 
        public static ReservationResource Update(string pathWorkspaceSid, string pathWorkerSid, string pathSid, ReservationResource.StatusEnum reservationStatus = null, string workerActivitySid = null, string instruction = null, string dequeuePostWorkActivitySid = null, string dequeueFrom = null, string dequeueRecord = null, int? dequeueTimeout = null, string dequeueTo = null, Uri dequeueStatusCallbackUrl = null, string callFrom = null, string callRecord = null, int? callTimeout = null, string callTo = null, Uri callUrl = null, Uri callStatusCallbackUrl = null, bool? callAccept = null, string redirectCallSid = null, bool? redirectAccept = null, Uri redirectUrl = null, ITwilioRestClient client = null)
        {
            var options = new UpdateReservationOptions(pathWorkspaceSid, pathWorkerSid, pathSid){ReservationStatus = reservationStatus, WorkerActivitySid = workerActivitySid, Instruction = instruction, DequeuePostWorkActivitySid = dequeuePostWorkActivitySid, DequeueFrom = dequeueFrom, DequeueRecord = dequeueRecord, DequeueTimeout = dequeueTimeout, DequeueTo = dequeueTo, DequeueStatusCallbackUrl = dequeueStatusCallbackUrl, CallFrom = callFrom, CallRecord = callRecord, CallTimeout = callTimeout, CallTo = callTo, CallUrl = callUrl, CallStatusCallbackUrl = callStatusCallbackUrl, CallAccept = callAccept, RedirectCallSid = redirectCallSid, RedirectAccept = redirectAccept, RedirectUrl = redirectUrl};
            return Update(options, client);
        }

        #if !NET35
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="pathWorkspaceSid"> The workspace_sid </param>
        /// <param name="pathWorkerSid"> The worker_sid </param>
        /// <param name="pathSid"> The sid </param>
        /// <param name="reservationStatus"> The reservation_status </param>
        /// <param name="workerActivitySid"> The worker_activity_sid </param>
        /// <param name="instruction"> The instruction </param>
        /// <param name="dequeuePostWorkActivitySid"> The dequeue_post_work_activity_sid </param>
        /// <param name="dequeueFrom"> The dequeue_from </param>
        /// <param name="dequeueRecord"> The dequeue_record </param>
        /// <param name="dequeueTimeout"> The dequeue_timeout </param>
        /// <param name="dequeueTo"> The dequeue_to </param>
        /// <param name="dequeueStatusCallbackUrl"> The dequeue_status_callback_url </param>
        /// <param name="callFrom"> The call_from </param>
        /// <param name="callRecord"> The call_record </param>
        /// <param name="callTimeout"> The call_timeout </param>
        /// <param name="callTo"> The call_to </param>
        /// <param name="callUrl"> The call_url </param>
        /// <param name="callStatusCallbackUrl"> The call_status_callback_url </param>
        /// <param name="callAccept"> The call_accept </param>
        /// <param name="redirectCallSid"> The redirect_call_sid </param>
        /// <param name="redirectAccept"> The redirect_accept </param>
        /// <param name="redirectUrl"> The redirect_url </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Reservation </returns> 
        public static async System.Threading.Tasks.Task<ReservationResource> UpdateAsync(string pathWorkspaceSid, string pathWorkerSid, string pathSid, ReservationResource.StatusEnum reservationStatus = null, string workerActivitySid = null, string instruction = null, string dequeuePostWorkActivitySid = null, string dequeueFrom = null, string dequeueRecord = null, int? dequeueTimeout = null, string dequeueTo = null, Uri dequeueStatusCallbackUrl = null, string callFrom = null, string callRecord = null, int? callTimeout = null, string callTo = null, Uri callUrl = null, Uri callStatusCallbackUrl = null, bool? callAccept = null, string redirectCallSid = null, bool? redirectAccept = null, Uri redirectUrl = null, ITwilioRestClient client = null)
        {
            var options = new UpdateReservationOptions(pathWorkspaceSid, pathWorkerSid, pathSid){ReservationStatus = reservationStatus, WorkerActivitySid = workerActivitySid, Instruction = instruction, DequeuePostWorkActivitySid = dequeuePostWorkActivitySid, DequeueFrom = dequeueFrom, DequeueRecord = dequeueRecord, DequeueTimeout = dequeueTimeout, DequeueTo = dequeueTo, DequeueStatusCallbackUrl = dequeueStatusCallbackUrl, CallFrom = callFrom, CallRecord = callRecord, CallTimeout = callTimeout, CallTo = callTo, CallUrl = callUrl, CallStatusCallbackUrl = callStatusCallbackUrl, CallAccept = callAccept, RedirectCallSid = redirectCallSid, RedirectAccept = redirectAccept, RedirectUrl = redirectUrl};
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

        /// <summary>
        /// The account_sid
        /// </summary>
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        /// <summary>
        /// The date_created
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        /// <summary>
        /// The date_updated
        /// </summary>
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        /// <summary>
        /// The reservation_status
        /// </summary>
        [JsonProperty("reservation_status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ReservationResource.StatusEnum ReservationStatus { get; private set; }
        /// <summary>
        /// The sid
        /// </summary>
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        /// <summary>
        /// The task_sid
        /// </summary>
        [JsonProperty("task_sid")]
        public string TaskSid { get; private set; }
        /// <summary>
        /// The worker_name
        /// </summary>
        [JsonProperty("worker_name")]
        public string WorkerName { get; private set; }
        /// <summary>
        /// The worker_sid
        /// </summary>
        [JsonProperty("worker_sid")]
        public string WorkerSid { get; private set; }
        /// <summary>
        /// The workspace_sid
        /// </summary>
        [JsonProperty("workspace_sid")]
        public string WorkspaceSid { get; private set; }
        /// <summary>
        /// The url
        /// </summary>
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        /// <summary>
        /// The links
        /// </summary>
        [JsonProperty("links")]
        public Dictionary<string, string> Links { get; private set; }

        private ReservationResource()
        {

        }
    }

}