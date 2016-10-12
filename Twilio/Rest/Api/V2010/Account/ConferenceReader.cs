using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class ConferenceReader : Reader<ConferenceResource> {
        private string accountSid;
        private string dateCreated;
        private string dateUpdated;
        private string friendlyName;
        private ConferenceResource.Status status;
    
        /**
         * Construct a new ConferenceReader.
         */
        public ConferenceReader() {
        }
    
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
         * also specify inequality such as DateCreated&lt;=YYYY-MM-DD
         * 
         * @param dateCreated Filter by date created
         * @return this
         */
        public ConferenceReader ByDateCreated(string dateCreated) {
            this.dateCreated = dateCreated;
            return this;
        }
    
        /**
         * Only show conferences that were last updated on this date, given as
         * YYYY-MM-DD. You can also specify inequality such as
         * DateUpdated&gt;=YYYY-MM-DD
         * 
         * @param dateUpdated Filter by date updated
         * @return this
         */
        public ConferenceReader ByDateUpdated(string dateUpdated) {
            this.dateUpdated = dateUpdated;
            return this;
        }
    
        /**
         * Only show results who's friendly name exactly matches the string
         * 
         * @param friendlyName Filter by friendly name
         * @return this
         */
        public ConferenceReader ByFriendlyName(string friendlyName) {
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
        public ConferenceReader ByStatus(ConferenceResource.Status status) {
            this.status = status;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return ConferenceResource ResourceSet
         */
        public override Task<ResourceSet<ConferenceResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Conferences.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<ConferenceResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return ConferenceResource ResourceSet
         */
        public override ResourceSet<ConferenceResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Conferences.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<ConferenceResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<ConferenceResource> NextPage(Page<ConferenceResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.API
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /**
         * Generate a Page of ConferenceResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<ConferenceResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ConferenceResource read failed: Unable to connect to server");
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
            
            return Page<ConferenceResource>.FromJson("conferences", response.Content);
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
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}