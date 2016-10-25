using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Worker {

    public class ReservationResource : Resource {
        public sealed class Status : IStringEnum {
            public const string Pending = "pending";
            public const string Accepted = "accepted";
            public const string Rejected = "rejected";
            public const string Timeout = "timeout";
            public const string Canceled = "canceled";
            public const string Rescinded = "rescinded";
        
            private string _value;
            
            public Status() { }
            
            public Status(string value) {
                _value = value;
            }
            
            public override string ToString() {
                return _value;
            }
            
            public static implicit operator Status(string value) {
                return new Status(value);
            }
            
            public static implicit operator string(Status value) {
                return value.ToString();
            }
            
            public void FromString(string value) {
                _value = value;
            }
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workerSid"> The worker_sid </param>
        /// <param name="reservationStatus"> The reservation_status </param>
        /// <returns> ReservationReader capable of executing the read </returns> 
        public static ReservationReader Reader(string workspaceSid, string workerSid, ReservationResource.Status reservationStatus=null) {
            return new ReservationReader(workspaceSid, workerSid, reservationStatus:reservationStatus);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workerSid"> The worker_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> ReservationFetcher capable of executing the fetch </returns> 
        public static ReservationFetcher Fetcher(string workspaceSid, string workerSid, string sid) {
            return new ReservationFetcher(workspaceSid, workerSid, sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workerSid"> The worker_sid </param>
        /// <param name="sid"> The sid </param>
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
        /// <returns> ReservationUpdater capable of executing the update </returns> 
        public static ReservationUpdater Updater(string workspaceSid, string workerSid, string sid, ReservationResource.Status reservationStatus=null, string workerActivitySid=null, string instruction=null, string dequeuePostWorkActivitySid=null, string dequeueFrom=null, string dequeueRecord=null, int? dequeueTimeout=null, string dequeueTo=null, Uri dequeueStatusCallbackUrl=null, string callFrom=null, string callRecord=null, int? callTimeout=null, string callTo=null, Uri callUrl=null, Uri callStatusCallbackUrl=null, bool? callAccept=null, string redirectCallSid=null, bool? redirectAccept=null, Uri redirectUrl=null) {
            return new ReservationUpdater(workspaceSid, workerSid, sid, reservationStatus:reservationStatus, workerActivitySid:workerActivitySid, instruction:instruction, dequeuePostWorkActivitySid:dequeuePostWorkActivitySid, dequeueFrom:dequeueFrom, dequeueRecord:dequeueRecord, dequeueTimeout:dequeueTimeout, dequeueTo:dequeueTo, dequeueStatusCallbackUrl:dequeueStatusCallbackUrl, callFrom:callFrom, callRecord:callRecord, callTimeout:callTimeout, callTo:callTo, callUrl:callUrl, callStatusCallbackUrl:callStatusCallbackUrl, callAccept:callAccept, redirectCallSid:redirectCallSid, redirectAccept:redirectAccept, redirectUrl:redirectUrl);
        }
    
        /// <summary>
        /// Converts a JSON string into a ReservationResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> ReservationResource object represented by the provided JSON </returns> 
        public static ReservationResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<ReservationResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("reservation_status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ReservationResource.Status reservationStatus { get; }
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("task_sid")]
        public string taskSid { get; }
        [JsonProperty("worker_name")]
        public string workerName { get; }
        [JsonProperty("worker_sid")]
        public string workerSid { get; }
        [JsonProperty("workspace_sid")]
        public string workspaceSid { get; }
        [JsonProperty("url")]
        public Uri url { get; }
        [JsonProperty("links")]
        public Dictionary<string, string> links { get; }
    
        public ReservationResource() {
        
        }
    
        private ReservationResource([JsonProperty("account_sid")]
                                    string accountSid, 
                                    [JsonProperty("date_created")]
                                    string dateCreated, 
                                    [JsonProperty("date_updated")]
                                    string dateUpdated, 
                                    [JsonProperty("reservation_status")]
                                    ReservationResource.Status reservationStatus, 
                                    [JsonProperty("sid")]
                                    string sid, 
                                    [JsonProperty("task_sid")]
                                    string taskSid, 
                                    [JsonProperty("worker_name")]
                                    string workerName, 
                                    [JsonProperty("worker_sid")]
                                    string workerSid, 
                                    [JsonProperty("workspace_sid")]
                                    string workspaceSid, 
                                    [JsonProperty("url")]
                                    Uri url, 
                                    [JsonProperty("links")]
                                    Dictionary<string, string> links) {
            this.accountSid = accountSid;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.reservationStatus = reservationStatus;
            this.sid = sid;
            this.taskSid = taskSid;
            this.workerName = workerName;
            this.workerSid = workerSid;
            this.workspaceSid = workspaceSid;
            this.url = url;
            this.links = links;
        }
    }
}