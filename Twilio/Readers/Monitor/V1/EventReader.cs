using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources.Monitor.V1;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Monitor.V1 {

    public class EventReader : Reader<EventResource> {
        private string actorSid;
        private string endDate;
        private string eventType;
        private string resourceSid;
        private string sourceIpAddress;
        private string startDate;
    
        /**
         * The actor_sid
         * 
         * @param actorSid The actor_sid
         * @return this
         */
        public EventReader byActorSid(string actorSid) {
            this.actorSid = actorSid;
            return this;
        }
    
        /**
         * The end_date
         * 
         * @param endDate The end_date
         * @return this
         */
        public EventReader byEndDate(string endDate) {
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
         * The resource_sid
         * 
         * @param resourceSid The resource_sid
         * @return this
         */
        public EventReader byResourceSid(string resourceSid) {
            this.resourceSid = resourceSid;
            return this;
        }
    
        /**
         * The source_ip_address
         * 
         * @param sourceIpAddress The source_ip_address
         * @return this
         */
        public EventReader bySourceIpAddress(string sourceIpAddress) {
            this.sourceIpAddress = sourceIpAddress;
            return this;
        }
    
        /**
         * The start_date
         * 
         * @param startDate The start_date
         * @return this
         */
        public EventReader byStartDate(string startDate) {
            this.startDate = startDate;
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
                TwilioRestClient.Domains.MONITOR,
                "/v1/Events"
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
            if (actorSid != null) {
                request.addQueryParam("ActorSid", actorSid);
            }
            
            if (endDate != null) {
                request.addQueryParam("EndDate", endDate);
            }
            
            if (eventType != null) {
                request.addQueryParam("EventType", eventType);
            }
            
            if (resourceSid != null) {
                request.addQueryParam("ResourceSid", resourceSid);
            }
            
            if (sourceIpAddress != null) {
                request.addQueryParam("SourceIpAddress", sourceIpAddress);
            }
            
            if (startDate != null) {
                request.addQueryParam("StartDate", startDate);
            }
            
            request.addQueryParam("PageSize", Integer.toString(getPageSize()));
        }
    }
}