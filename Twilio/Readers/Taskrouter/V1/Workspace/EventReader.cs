using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources.Taskrouter.V1.Workspace;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Taskrouter.V1.Workspace {

    public class EventReader : Reader<EventResource> {
        private string workspaceSid;
        private DateTime endDate;
        private string eventType;
        private int minutes;
        private string reservationSid;
        private DateTime startDate;
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
        public EventReader byEndDate(DateTime endDate) {
            this.endDate = endDate;
            return this;
        }
    
        /**
         * The event_type
         * 
         * @param eventType The event_type
         * @return this
         */
        public EventReader byEventType(string eventType) {
            this.eventType = eventType;
            return this;
        }
    
        /**
         * The minutes
         * 
         * @param minutes The minutes
         * @return this
         */
        public EventReader byMinutes(int minutes) {
            this.minutes = minutes;
            return this;
        }
    
        /**
         * The reservation_sid
         * 
         * @param reservationSid The reservation_sid
         * @return this
         */
        public EventReader byReservationSid(string reservationSid) {
            this.reservationSid = reservationSid;
            return this;
        }
    
        /**
         * The start_date
         * 
         * @param startDate The start_date
         * @return this
         */
        public EventReader byStartDate(DateTime startDate) {
            this.startDate = startDate;
            return this;
        }
    
        /**
         * The task_queue_sid
         * 
         * @param taskQueueSid The task_queue_sid
         * @return this
         */
        public EventReader byTaskQueueSid(string taskQueueSid) {
            this.taskQueueSid = taskQueueSid;
            return this;
        }
    
        /**
         * The task_sid
         * 
         * @param taskSid The task_sid
         * @return this
         */
        public EventReader byTaskSid(string taskSid) {
            this.taskSid = taskSid;
            return this;
        }
    
        /**
         * The worker_sid
         * 
         * @param workerSid The worker_sid
         * @return this
         */
        public EventReader byWorkerSid(string workerSid) {
            this.workerSid = workerSid;
            return this;
        }
    
        /**
         * The workflow_sid
         * 
         * @param workflowSid The workflow_sid
         * @return this
         */
        public EventReader byWorkflowSid(string workflowSid) {
            this.workflowSid = workflowSid;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return EventResource ResourceSet
         */
        public override ResourceSet<EventResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.TASKROUTER,
                "/v1/Workspaces/" + this.workspaceSid + "/Events"
            );
            
            addQueryParams(request);
            
            Page<EventResource> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<EventResource> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of EventResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<EventResource> pageForRequest(TwilioRestClient client, Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("EventResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.GetContent());
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
            
            Page<EventResource> result = new Page<>();
            result.deserialize("events", response.GetContent(), EventResource.class, client.getObjectMapper());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void addQueryParams(Request request) {
            if (endDate != null) {
                request.addQueryParam("EndDate", endDate.ToString());
            }
            
            if (eventType != null) {
                request.addQueryParam("EventType", eventType);
            }
            
            if (minutes != null) {
                request.addQueryParam("Minutes", minutes.ToString());
            }
            
            if (reservationSid != null) {
                request.addQueryParam("ReservationSid", reservationSid);
            }
            
            if (startDate != null) {
                request.addQueryParam("StartDate", startDate.ToString());
            }
            
            if (taskQueueSid != null) {
                request.addQueryParam("TaskQueueSid", taskQueueSid);
            }
            
            if (taskSid != null) {
                request.addQueryParam("TaskSid", taskSid);
            }
            
            if (workerSid != null) {
                request.addQueryParam("WorkerSid", workerSid);
            }
            
            if (workflowSid != null) {
                request.addQueryParam("WorkflowSid", workflowSid);
            }
            
            request.addQueryParam("PageSize", Integer.toString(getPageSize()));
        }
    }
}