using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account;

namespace Twilio.Readers.Api.V2010.Account {

    public class ConferenceReader : Reader<ConferenceResource> {
        private string accountSid;
        private string dateCreated;
        private string dateUpdated;
        private string friendlyName;
        private ConferenceResource.Status status;
    
        /**
         * Construct a new ConferenceReader
         * 
         * @param accountSid The account_sid
         */
        public ConferenceReader(string accountSid) {
            this.accountSid = accountSid;
        }
    
        /**
         * Only show conferences that started on this date, given as YYYY-MM-DD. You can
         * also specify inequality such as DateCreated<=YYYY-MM-DD
         * 
         * @param dateCreated Filter by date created
         * @return this
         */
        public ConferenceReader byDateCreated(string dateCreated) {
            this.dateCreated = dateCreated;
            return this;
        }
    
        /**
         * Only show conferences that were last updated on this date, given as
         * YYYY-MM-DD. You can also specify inequality such as DateUpdated>=YYYY-MM-DD
         * 
         * @param dateUpdated Filter by date updated
         * @return this
         */
        public ConferenceReader byDateUpdated(string dateUpdated) {
            this.dateUpdated = dateUpdated;
            return this;
        }
    
        /**
         * Only show results who's friendly name exactly matches the string
         * 
         * @param friendlyName Filter by friendly name
         * @return this
         */
        public ConferenceReader byFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * A string representing the status of the conference. May be `init`,
         * `in-progress`, or `completed`.
         * 
         * @param status The status of the conference
         * @return this
         */
        public ConferenceReader byStatus(ConferenceResource.Status status) {
            this.status = status;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return ConferenceResource ResourceSet
         */
        public override ResourceSet<ConferenceResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Conferences.json"
            );
            
            AddQueryParams(request);
            
            Page<ConferenceResource> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public Page<ConferenceResource> nextPage(string nextPageUri, TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of ConferenceResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<ConferenceResource> pageForRequest(TwilioRestClient client, Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ConferenceResource read failed: Unable to connect to server");
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
            
            Page<ConferenceResource> result = new Page<>();
            result.deserialize("conferences", response.GetContent());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (dateCreated != null) {
                request.AddQueryParam("DateCreated", dateCreated);
            }
            
            if (dateUpdated != null) {
                request.AddQueryParam("DateUpdated", dateUpdated);
            }
            
            if (friendlyName != null) {
                request.AddQueryParam("FriendlyName", friendlyName);
            }
            
            if (status != null) {
                request.AddQueryParam("Status", status.ToString());
            }
            
            request.AddQueryParam("PageSize", getPageSize().ToString());
        }
    }
}