using System;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Monitor.V1 {

    public class EventReader : Reader<EventResource> {
        private string actorSid;
        private string eventType;
        private string resourceSid;
        private string sourceIpAddress;
        private DateTime? startDate;
        private DateTime? endDate;
    
        /// <summary>
        /// The actor_sid
        /// </summary>
        ///
        /// <param name="actorSid"> The actor_sid </param>
        /// <returns> this </returns> 
        public EventReader ByActorSid(string actorSid) {
            this.actorSid = actorSid;
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
        /// The resource_sid
        /// </summary>
        ///
        /// <param name="resourceSid"> The resource_sid </param>
        /// <returns> this </returns> 
        public EventReader ByResourceSid(string resourceSid) {
            this.resourceSid = resourceSid;
            return this;
        }
    
        /// <summary>
        /// The source_ip_address
        /// </summary>
        ///
        /// <param name="sourceIpAddress"> The source_ip_address </param>
        /// <returns> this </returns> 
        public EventReader BySourceIpAddress(string sourceIpAddress) {
            this.sourceIpAddress = sourceIpAddress;
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
        /// The end_date
        /// </summary>
        ///
        /// <param name="endDate"> The end_date </param>
        /// <returns> this </returns> 
        public EventReader ByEndDate(DateTime? endDate) {
            this.endDate = endDate;
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
                Domains.MONITOR,
                "/v1/Events"
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
                Domains.MONITOR,
                "/v1/Events"
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
                    Domains.MONITOR
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
            if (actorSid != null) {
                request.AddQueryParam("ActorSid", actorSid);
            }
            
            if (eventType != null) {
                request.AddQueryParam("EventType", eventType);
            }
            
            if (resourceSid != null) {
                request.AddQueryParam("ResourceSid", resourceSid);
            }
            
            if (sourceIpAddress != null) {
                request.AddQueryParam("SourceIpAddress", sourceIpAddress);
            }
            
            if (startDate != null) {
                request.AddQueryParam("StartDate", startDate.ToString());
            }
            
            if (endDate != null) {
                request.AddQueryParam("EndDate", endDate.ToString());
            }
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}