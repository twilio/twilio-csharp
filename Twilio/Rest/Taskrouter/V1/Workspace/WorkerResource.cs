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

    public class WorkerResource : Resource 
    {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="activityName"> The activity_name </param>
        /// <param name="activitySid"> The activity_sid </param>
        /// <param name="available"> The available </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="targetWorkersExpression"> The target_workers_expression </param>
        /// <param name="taskQueueName"> The task_queue_name </param>
        /// <param name="taskQueueSid"> The task_queue_sid </param>
        /// <returns> WorkerReader capable of executing the read </returns> 
        public static WorkerReader Reader(string workspaceSid, string activityName=null, string activitySid=null, string available=null, string friendlyName=null, string targetWorkersExpression=null, string taskQueueName=null, string taskQueueSid=null)
        {
            return new WorkerReader(workspaceSid, activityName:activityName, activitySid:activitySid, available:available, friendlyName:friendlyName, targetWorkersExpression:targetWorkersExpression, taskQueueName:taskQueueName, taskQueueSid:taskQueueSid);
        }
    
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="activitySid"> The activity_sid </param>
        /// <param name="attributes"> The attributes </param>
        /// <returns> WorkerCreator capable of executing the create </returns> 
        public static WorkerCreator Creator(string workspaceSid, string friendlyName, string activitySid=null, string attributes=null)
        {
            return new WorkerCreator(workspaceSid, friendlyName, activitySid:activitySid, attributes:attributes);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> WorkerFetcher capable of executing the fetch </returns> 
        public static WorkerFetcher Fetcher(string workspaceSid, string sid)
        {
            return new WorkerFetcher(workspaceSid, sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <param name="activitySid"> The activity_sid </param>
        /// <param name="attributes"> The attributes </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> WorkerUpdater capable of executing the update </returns> 
        public static WorkerUpdater Updater(string workspaceSid, string sid, string activitySid=null, string attributes=null, string friendlyName=null)
        {
            return new WorkerUpdater(workspaceSid, sid, activitySid:activitySid, attributes:attributes, friendlyName:friendlyName);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> WorkerDeleter capable of executing the delete </returns> 
        public static WorkerDeleter Deleter(string workspaceSid, string sid)
        {
            return new WorkerDeleter(workspaceSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a WorkerResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkerResource object represented by the provided JSON </returns> 
        public static WorkerResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<WorkerResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string accountSid { get; }
        [JsonProperty("activity_name")]
        public string activityName { get; }
        [JsonProperty("activity_sid")]
        public string activitySid { get; }
        [JsonProperty("attributes")]
        public string attributes { get; }
        [JsonProperty("available")]
        public bool? available { get; }
        [JsonProperty("date_created")]
        public DateTime? dateCreated { get; }
        [JsonProperty("date_status_changed")]
        public DateTime? dateStatusChanged { get; }
        [JsonProperty("date_updated")]
        public DateTime? dateUpdated { get; }
        [JsonProperty("friendly_name")]
        public string friendlyName { get; }
        [JsonProperty("sid")]
        public string sid { get; }
        [JsonProperty("workspace_sid")]
        public string workspaceSid { get; }
        [JsonProperty("url")]
        public Uri url { get; }
        [JsonProperty("links")]
        public Dictionary<string, string> links { get; }
    
        public WorkerResource()
        {
        
        }
    
        private WorkerResource([JsonProperty("account_sid")]
                               string accountSid, 
                               [JsonProperty("activity_name")]
                               string activityName, 
                               [JsonProperty("activity_sid")]
                               string activitySid, 
                               [JsonProperty("attributes")]
                               string attributes, 
                               [JsonProperty("available")]
                               bool? available, 
                               [JsonProperty("date_created")]
                               string dateCreated, 
                               [JsonProperty("date_status_changed")]
                               string dateStatusChanged, 
                               [JsonProperty("date_updated")]
                               string dateUpdated, 
                               [JsonProperty("friendly_name")]
                               string friendlyName, 
                               [JsonProperty("sid")]
                               string sid, 
                               [JsonProperty("workspace_sid")]
                               string workspaceSid, 
                               [JsonProperty("url")]
                               Uri url, 
                               [JsonProperty("links")]
                               Dictionary<string, string> links)
                               {
            this.accountSid = accountSid;
            this.activityName = activityName;
            this.activitySid = activitySid;
            this.attributes = attributes;
            this.available = available;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateStatusChanged = MarshalConverter.DateTimeFromString(dateStatusChanged);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.sid = sid;
            this.workspaceSid = workspaceSid;
            this.url = url;
            this.links = links;
        }
    }
}