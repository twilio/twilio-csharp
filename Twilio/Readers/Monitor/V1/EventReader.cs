using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Monitor.V1.Event;
using com.twilio.sdk.readers.Reader;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Monitor.V1 {

    public class EventReader : Reader<Event> {
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
         * @return Event ResourceSet
         */
        [Override]
        public ResourceSet<Event> execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.MONITOR,
                "/v1/Events",
                client.getAccountSid()
            );
            
            addQueryParams(request);
            
            Page<Event> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        [Override]
        public Page<Event> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                nextPageUri,
                client.getAccountSid()
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of Event Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<Event> pageForRequest(final TwilioRestClient client, final Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Event read failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.getStream(), client.getObjectMapper());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.getMessage(),
                    restException.getCode(),
                    restException.getMoreInfo(),
                    restException.getStatus(),
                    null
                );
            }
            
            Page<Event> result = new Page<>();
            result.deserialize("events", response.getContent(), Event.class, client.getObjectMapper());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void addQueryParams(final Request request) {
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