using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class EventResource : Resource 
    {
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> EventFetcher capable of executing the fetch </returns> 
        public static EventFetcher Fetcher(string workspaceSid, string sid)
        {
            return new EventFetcher(workspaceSid, sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="endDate"> The end_date </param>
        /// <param name="eventType"> The event_type </param>
        /// <param name="minutes"> The minutes </param>
        /// <param name="reservationSid"> The reservation_sid </param>
        /// <param name="startDate"> The start_date </param>
        /// <param name="taskQueueSid"> The task_queue_sid </param>
        /// <param name="taskSid"> The task_sid </param>
        /// <param name="workerSid"> The worker_sid </param>
        /// <param name="workflowSid"> The workflow_sid </param>
        /// <returns> EventReader capable of executing the read </returns> 
        public static EventReader Reader(string workspaceSid, DateTime? endDate=null, string eventType=null, int? minutes=null, string reservationSid=null, DateTime? startDate=null, string taskQueueSid=null, string taskSid=null, string workerSid=null, string workflowSid=null)
        {
            return new EventReader(workspaceSid, endDate:endDate, eventType:eventType, minutes:minutes, reservationSid:reservationSid, startDate:startDate, taskQueueSid:taskQueueSid, taskSid:taskSid, workerSid:workerSid, workflowSid:workflowSid);
        }
    
        /// <summary>
        /// Converts a JSON string into a EventResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> EventResource object represented by the provided JSON </returns> 
        public static EventResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<EventResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("actor_sid")]
        public string actorSid { get; }
        [JsonProperty("actor_type")]
        public string actorType { get; }
        [JsonProperty("actor_url")]
        public Uri actorUrl { get; }
        [JsonProperty("description")]
        public string description { get; }
        [JsonProperty("event_data")]
        public Dictionary<string, string> eventData { get; }
        [JsonProperty("event_date")]
        public DateTime? eventDate { get; }
        [JsonProperty("event_type")]
        public string eventType { get; }
        [JsonProperty("resource_sid")]
        public string resourceSid { get; }
        [JsonProperty("resource_type")]
        public string resourceType { get; }
        [JsonProperty("resource_url")]
        public Uri resourceUrl { get; }
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("source")]
        public string source { get; }
        [JsonProperty("source_ip_address")]
        public string sourceIpAddress { get; }
        [JsonProperty("url")]
        public Uri url { get; }
    
        public EventResource()
        {
        
        }
    
        private EventResource([JsonProperty("account_sid")]
                              string accountSid, 
                              [JsonProperty("actor_sid")]
                              string actorSid, 
                              [JsonProperty("actor_type")]
                              string actorType, 
                              [JsonProperty("actor_url")]
                              Uri actorUrl, 
                              [JsonProperty("description")]
                              string description, 
                              [JsonProperty("event_data")]
                              Dictionary<string, string> eventData, 
                              [JsonProperty("event_date")]
                              string eventDate, 
                              [JsonProperty("event_type")]
                              string eventType, 
                              [JsonProperty("resource_sid")]
                              string resourceSid, 
                              [JsonProperty("resource_type")]
                              string resourceType, 
                              [JsonProperty("resource_url")]
                              Uri resourceUrl, 
                              [JsonProperty("sid")]
                              string sid, 
                              [JsonProperty("source")]
                              string source, 
                              [JsonProperty("source_ip_address")]
                              string sourceIpAddress, 
                              [JsonProperty("url")]
                              Uri url)
                              {
            this.accountSid = accountSid;
            this.actorSid = actorSid;
            this.actorType = actorType;
            this.actorUrl = actorUrl;
            this.description = description;
            this.eventData = eventData;
            this.eventDate = MarshalConverter.DateTimeFromString(eventDate);
            this.eventType = eventType;
            this.resourceSid = resourceSid;
            this.resourceType = resourceType;
            this.resourceUrl = resourceUrl;
            this.sid = sid;
            this.source = source;
            this.sourceIpAddress = sourceIpAddress;
            this.url = url;
        }
    }
}