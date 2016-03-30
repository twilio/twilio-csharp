using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Monitor.V1;

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
        public override async Task<ResourceSet<EventResource>> ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.MONITOR,
                "/v1/Events"
            );
            
            AddQueryParams(request);
            
            Page<EventResource> page = await PageForRequest(client, request);
            
            return new ResourceSet<EventResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<EventResource> NextPage(string nextPageUri, TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            
            var task = PageForRequest(client, request);
            task.Wait();
            
            return task.Result;
        }
    
        /**
         * Generate a Page of EventResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected async Task<Page<EventResource>> PageForRequest(TwilioRestClient client, Request request) {
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("EventResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
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
            if (actorSid != null) {
                request.AddQueryParam("ActorSid", actorSid);
            }
            
            if (endDate != null) {
                request.AddQueryParam("EndDate", endDate);
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
                request.AddQueryParam("StartDate", startDate);
            }
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}