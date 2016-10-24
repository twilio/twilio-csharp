using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Taskrouter.V1.Workspace {

    public class EventReader : Reader<EventResource> {
        public string workspaceSid { get; }
        public DateTime? endDate { get; set; }
        public string eventType { get; set; }
        public int? minutes { get; set; }
        public string reservationSid { get; set; }
        public DateTime? startDate { get; set; }
        public string taskQueueSid { get; set; }
        public string taskSid { get; set; }
        public string workerSid { get; set; }
        public string workflowSid { get; set; }
    
        /// <summary>
        /// Construct a new EventReader
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        public EventReader(string workspaceSid) {
            this.workspaceSid = workspaceSid;
        }
    
        /// <summary>
        /// The end_date
        /// </summary>
        ///
        /// <param name="endDate"> The end_date </param>
        /// <returns> this </returns> 
        public EventReader ByEndDate(DateTime? endDate) {
            this.endDate = endDate;
            return this;
        }
    
        /// <summary>
        /// The event_type
        /// </summary>
        ///
        /// <param name="eventType"> The event_type </param>
        /// <returns> this </returns> 
        public EventReader ByEventType(string eventType) {
            this.eventType = eventType;
            return this;
        }
    
        /// <summary>
        /// The minutes
        /// </summary>
        ///
        /// <param name="minutes"> The minutes </param>
        /// <returns> this </returns> 
        public EventReader ByMinutes(int? minutes) {
            this.minutes = minutes;
            return this;
        }
    
        /// <summary>
        /// The reservation_sid
        /// </summary>
        ///
        /// <param name="reservationSid"> The reservation_sid </param>
        /// <returns> this </returns> 
        public EventReader ByReservationSid(string reservationSid) {
            this.reservationSid = reservationSid;
            return this;
        }
    
        /// <summary>
        /// The start_date
        /// </summary>
        ///
        /// <param name="startDate"> The start_date </param>
        /// <returns> this </returns> 
        public EventReader ByStartDate(DateTime? startDate) {
            this.startDate = startDate;
            return this;
        }
    
        /// <summary>
        /// The task_queue_sid
        /// </summary>
        ///
        /// <param name="taskQueueSid"> The task_queue_sid </param>
        /// <returns> this </returns> 
        public EventReader ByTaskQueueSid(string taskQueueSid) {
            this.taskQueueSid = taskQueueSid;
            return this;
        }
    
        /// <summary>
        /// The task_sid
        /// </summary>
        ///
        /// <param name="taskSid"> The task_sid </param>
        /// <returns> this </returns> 
        public EventReader ByTaskSid(string taskSid) {
            this.taskSid = taskSid;
            return this;
        }
    
        /// <summary>
        /// The worker_sid
        /// </summary>
        ///
        /// <param name="workerSid"> The worker_sid </param>
        /// <returns> this </returns> 
        public EventReader ByWorkerSid(string workerSid) {
            this.workerSid = workerSid;
            return this;
        }
    
        /// <summary>
        /// The workflow_sid
        /// </summary>
        ///
        /// <param name="workflowSid"> The workflow_sid </param>
        /// <returns> this </returns> 
        public EventReader ByWorkflowSid(string workflowSid) {
            this.workflowSid = workflowSid;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> EventResource ResourceSet </returns> 
        public override Task<ResourceSet<EventResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Events"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<EventResource>(this, client, page));
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> EventResource ResourceSet </returns> 
        public override ResourceSet<EventResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Events"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<EventResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="nextPageUri"> URI from which to retrieve the next page </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<EventResource> NextPage(Page<EventResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.TASKROUTER
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of EventResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<EventResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("EventResource read failed: Unable to connect to server");
            }
            
            if (response.StatusCode < System.Net.HttpStatusCode.OK || response.StatusCode > System.Net.HttpStatusCode.NoContent)
            {
                var restException = RestException.FromJson(response.Content);
                if (restException == null)
                {
                    throw new ApiException("Server Error, no content");
                }
            
                throw new ApiException(
                    restException.Code,
                    (int)response.StatusCode,
                    restException.Message ?? "Unable to read records, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return Page<EventResource>.FromJson("events", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
        private void AddQueryParams(Request request) {
            if (endDate != null) {
                request.AddQueryParam("EndDate", endDate.ToString());
            }
            
            if (eventType != null) {
                request.AddQueryParam("EventType", eventType);
            }
            
            if (minutes != null) {
                request.AddQueryParam("Minutes", minutes.ToString());
            }
            
            if (reservationSid != null) {
                request.AddQueryParam("ReservationSid", reservationSid);
            }
            
            if (startDate != null) {
                request.AddQueryParam("StartDate", startDate.ToString());
            }
            
            if (taskQueueSid != null) {
                request.AddQueryParam("TaskQueueSid", taskQueueSid);
            }
            
            if (taskSid != null) {
                request.AddQueryParam("TaskSid", taskSid);
            }
            
            if (workerSid != null) {
                request.AddQueryParam("WorkerSid", workerSid);
            }
            
            if (workflowSid != null) {
                request.AddQueryParam("WorkflowSid", workflowSid);
            }
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}