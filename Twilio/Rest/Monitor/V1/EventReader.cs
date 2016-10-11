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
    
        /**
         * The actor_sid
         * 
         * @param actorSid The actor_sid
         * @return this
         */
        public EventReader ByActorSid(string actorSid) {
            this.actorSid = actorSid;
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
         * The resource_sid
         * 
         * @param resourceSid The resource_sid
         * @return this
         */
        public EventReader ByResourceSid(string resourceSid) {
            this.resourceSid = resourceSid;
            return this;
        }
    
        /**
         * The source_ip_address
         * 
         * @param sourceIpAddress The source_ip_address
         * @return this
         */
        public EventReader BySourceIpAddress(string sourceIpAddress) {
            this.sourceIpAddress = sourceIpAddress;
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
         * The end_date
         * 
         * @param endDate The end_date
         * @return this
         */
        public EventReader ByEndDate(DateTime? endDate) {
            this.endDate = endDate;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return EventResource ResourceSet
         */
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
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return EventResource ResourceSet
         */
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
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<EventResource> NextPage(Page<EventResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.MONITOR
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /**
         * Generate a Page of EventResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<EventResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("EventResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to read records, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
                    null
                );
            }
            
            return Page<EventResource>.FromJson("events", response.GetContent());
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
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