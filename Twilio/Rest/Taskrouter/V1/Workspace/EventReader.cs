using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Taskrouter.V1.Workspace 
{

    public class EventReader : Reader<EventResource> 
    {
        public string WorkspaceSid { get; }
        public DateTime? EndDate { get; set; }
        public string EventType { get; set; }
        public int? Minutes { get; set; }
        public string ReservationSid { get; set; }
        public DateTime? StartDate { get; set; }
        public string TaskQueueSid { get; set; }
        public string TaskSid { get; set; }
        public string WorkerSid { get; set; }
        public string WorkflowSid { get; set; }
    
        /// <summary>
        /// Construct a new EventReader
        /// </summary>
        ///
        /// <param name="workspaceSid"> The workspace_sid </param>
        public EventReader(string workspaceSid)
        {
            WorkspaceSid = workspaceSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> EventResource ResourceSet </returns> 
        public override System.Threading.Tasks.Task<ResourceSet<EventResource>> ReadAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + WorkspaceSid + "/Events"
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
        public override ResourceSet<EventResource> Read(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Rest.Domain.Taskrouter,
                "/v1/Workspaces/" + WorkspaceSid + "/Events"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<EventResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="page"> current page of results </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<EventResource> NextPage(Page<EventResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Rest.Domain.Taskrouter
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
        protected Page<EventResource> PageForRequest(ITwilioRestClient client, Request request)
        {
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
        private void AddQueryParams(Request request)
        {
            if (EndDate != null)
            {
                request.AddQueryParam("EndDate", EndDate.ToString());
            }
            
            if (EventType != null)
            {
                request.AddQueryParam("EventType", EventType);
            }
            
            if (Minutes != null)
            {
                request.AddQueryParam("Minutes", Minutes.ToString());
            }
            
            if (ReservationSid != null)
            {
                request.AddQueryParam("ReservationSid", ReservationSid);
            }
            
            if (StartDate != null)
            {
                request.AddQueryParam("StartDate", StartDate.ToString());
            }
            
            if (TaskQueueSid != null)
            {
                request.AddQueryParam("TaskQueueSid", TaskQueueSid);
            }
            
            if (TaskSid != null)
            {
                request.AddQueryParam("TaskSid", TaskSid);
            }
            
            if (WorkerSid != null)
            {
                request.AddQueryParam("WorkerSid", WorkerSid);
            }
            
            if (WorkflowSid != null)
            {
                request.AddQueryParam("WorkflowSid", WorkflowSid);
            }
            
            if (PageSize != null)
            {
                request.AddQueryParam("PageSize", PageSize.ToString());
            }
        }
    }
}