using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace.Worker {

    public class WorkerChannelResource : SidResource {
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workerSid"> The worker_sid </param>
        /// <returns> WorkerChannelReader capable of executing the read </returns> 
        public static WorkerChannelReader Reader(string workspaceSid, string workerSid) {
            return new WorkerChannelReader(workspaceSid, workerSid);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workerSid"> The worker_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> WorkerChannelFetcher capable of executing the fetch </returns> 
        public static WorkerChannelFetcher Fetcher(string workspaceSid, string workerSid, string sid) {
            return new WorkerChannelFetcher(workspaceSid, workerSid, sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        /// <param name="workerSid"> The worker_sid </param>
        /// <param name="sid"> The sid </param>
        /// <returns> WorkerChannelUpdater capable of executing the update </returns> 
        public static WorkerChannelUpdater Updater(string workspaceSid, string workerSid, string sid) {
            return new WorkerChannelUpdater(workspaceSid, workerSid, sid);
        }
    
        /// <summary>
        /// Converts a JSON string into a WorkerChannelResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> WorkerChannelResource object represented by the provided JSON </returns> 
        public static WorkerChannelResource FromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<WorkerChannelResource>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly string accountSid;
        [JsonProperty("assigned_tasks")]
        private readonly int? assignedTasks;
        [JsonProperty("available")]
        private readonly bool? available;
        [JsonProperty("available_capacity_percentage")]
        private readonly int? availableCapacityPercentage;
        [JsonProperty("configured_capacity")]
        private readonly int? configuredCapacity;
        [JsonProperty("date_created")]
        private readonly DateTime? dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime? dateUpdated;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("task_channel_sid")]
        private readonly string taskChannelSid;
        [JsonProperty("task_channel_unique_name")]
        private readonly string taskChannelUniqueName;
        [JsonProperty("worker_sid")]
        private readonly string workerSid;
        [JsonProperty("workspace_sid")]
        private readonly string workspaceSid;
        [JsonProperty("links")]
        private readonly Dictionary<string, string> links;
        [JsonProperty("url")]
        private readonly Uri url;
    
        public WorkerChannelResource() {
        
        }
    
        private WorkerChannelResource([JsonProperty("account_sid")]
                                      string accountSid, 
                                      [JsonProperty("assigned_tasks")]
                                      int? assignedTasks, 
                                      [JsonProperty("available")]
                                      bool? available, 
                                      [JsonProperty("available_capacity_percentage")]
                                      int? availableCapacityPercentage, 
                                      [JsonProperty("configured_capacity")]
                                      int? configuredCapacity, 
                                      [JsonProperty("date_created")]
                                      string dateCreated, 
                                      [JsonProperty("date_updated")]
                                      string dateUpdated, 
                                      [JsonProperty("sid")]
                                      string sid, 
                                      [JsonProperty("task_channel_sid")]
                                      string taskChannelSid, 
                                      [JsonProperty("task_channel_unique_name")]
                                      string taskChannelUniqueName, 
                                      [JsonProperty("worker_sid")]
                                      string workerSid, 
                                      [JsonProperty("workspace_sid")]
                                      string workspaceSid, 
                                      [JsonProperty("links")]
                                      Dictionary<string, string> links, 
                                      [JsonProperty("url")]
                                      Uri url) {
            this.accountSid = accountSid;
            this.assignedTasks = assignedTasks;
            this.available = available;
            this.availableCapacityPercentage = availableCapacityPercentage;
            this.configuredCapacity = configuredCapacity;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            this.sid = sid;
            this.taskChannelSid = taskChannelSid;
            this.taskChannelUniqueName = taskChannelUniqueName;
            this.workerSid = workerSid;
            this.workspaceSid = workspaceSid;
            this.links = links;
            this.url = url;
        }
    
        /// <returns> The account_sid </returns> 
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /// <returns> The assigned_tasks </returns> 
        public int? GetAssignedTasks() {
            return this.assignedTasks;
        }
    
        /// <returns> The available </returns> 
        public bool? GetAvailable() {
            return this.available;
        }
    
        /// <returns> The available_capacity_percentage </returns> 
        public int? GetAvailableCapacityPercentage() {
            return this.availableCapacityPercentage;
        }
    
        /// <returns> The configured_capacity </returns> 
        public int? GetConfiguredCapacity() {
            return this.configuredCapacity;
        }
    
        /// <returns> The date_created </returns> 
        public DateTime? GetDateCreated() {
            return this.dateCreated;
        }
    
        /// <returns> The date_updated </returns> 
        public DateTime? GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /// <returns> The sid </returns> 
        public override string GetSid() {
            return this.sid;
        }
    
        /// <returns> The task_channel_sid </returns> 
        public string GetTaskChannelSid() {
            return this.taskChannelSid;
        }
    
        /// <returns> The task_channel_unique_name </returns> 
        public string GetTaskChannelUniqueName() {
            return this.taskChannelUniqueName;
        }
    
        /// <returns> The worker_sid </returns> 
        public string GetWorkerSid() {
            return this.workerSid;
        }
    
        /// <returns> The workspace_sid </returns> 
        public string GetWorkspaceSid() {
            return this.workspaceSid;
        }
    
        /// <returns> The links </returns> 
        public Dictionary<string, string> GetLinks() {
            return this.links;
        }
    
        /// <returns> The url </returns> 
        public Uri GetUrl() {
            return this.url;
        }
    }
}