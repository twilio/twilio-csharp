using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Taskrouter.V1.Workspace;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Readers.Taskrouter.V1.Workspace {

    public class EventReader : Reader<EventResource> {
        private string workspaceSid;
        private DateTime? endDate;
        private string eventType;
        private int? minutes;
        private string reservationSid;
        private DateTime? startDate;
        private string taskQueueSid;
        private string taskSid;
        private string workerSid;
        private string workflowSid;
    
        /**
         * Construct a new EventReader
         * 
         * @param workspaceSid The workspace_sid
         */
        public EventReader(string workspaceSid) {
            this.workspaceSid = workspaceSid;
        }
    
        /**
         * The end_date
         * 
         * @param endDate The end_date
         * @return this
         */
        public EventReader ByEndDate(DateTime? endDate) {
            this.endDate = endDate;
            return this;
        }
    
        /**
         * The event_type
         * 
         * @param eventType The event_type
         * @return this
         */
        public EventReader ByEventType(string eventType) {
            this.eventType = eventType;
            return this;
        }
    
        /**
         * The minutes
         * 
         * @param minutes The minutes
         * @return this
         */
        public EventReader ByMinutes(int? minutes) {
            this.minutes = minutes;
            return this;
        }
    
        /**
         * The reservation_sid
         * 
         * @param reservationSid The reservation_sid
         * @return this
         */
        public EventReader ByReservationSid(string reservationSid) {
            this.reservationSid = reservationSid;
            return this;
        }
    
        /**
         * The start_date
         * 
         * @param startDate The start_date
         * @return this
         */
        public EventReader ByStartDate(DateTime? startDate) {
            this.startDate = startDate;
            return this;
        }
    
        /**
         * The task_queue_sid
         * 
         * @param taskQueueSid The task_queue_sid
         * @return this
         */
        public EventReader ByTaskQueueSid(string taskQueueSid) {
            this.taskQueueSid = taskQueueSid;
            return this;
        }
    
        /**
         * The task_sid
         * 
         * @param taskSid The task_sid
         * @return this
         */
        public EventReader ByTaskSid(string taskSid) {
            this.taskSid = taskSid;
            return this;
        }
    
        /**
         * The worker_sid
         * 
         * @param workerSid The worker_sid
         * @return this
         */
        public EventReader ByWorkerSid(string workerSid) {
            this.workerSid = workerSid;
            return this;
        }
    
        /**
         * The workflow_sid
         * 
         * @param workflowSid The workflow_sid
         * @return this
         */
        public EventReader ByWorkflowSid(string workflowSid) {
            this.workflowSid = workflowSid;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return EventResource ResourceSet
         */
        public override Task<ResourceSet<EventResource>> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Events"
            );
            
            AddQueryParams(request);
            
            Page<EventResource> page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(
                    new ResourceSet<EventResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return EventResource ResourceSet
         */
        public override ResourceSet<EventResource> Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Events"
            );
            
            AddQueryParams(request);
            
            Page<EventResource> page = PageForRequest(client, request);
            
            return new ResourceSet<EventResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<EventResource> NextPage(string nextPageUri, ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.GET,
                nextPageUri
            );
            
            var result = PageForRequest(client, request);
            
            return result;
        }
    
        /**
         * Generate a Page of EventResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<EventResource> PageForRequest(ITwilioRestClient client, Request request) {
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("EventResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.GetMessage(),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    restException.GetStatus(),
                    null
                );
            }
            
            Page<EventResource> result = new Page<EventResource>();
            result.deserialize("events", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
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
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}