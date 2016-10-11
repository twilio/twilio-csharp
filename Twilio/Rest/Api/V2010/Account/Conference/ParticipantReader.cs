using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Conference {

    public class ParticipantReader : Reader<ParticipantResource> {
        private string accountSid;
        private string conferenceSid;
        private bool? muted;
        private bool? hold;
    
        /**
         * Construct a new ParticipantReader.
         * 
         * @param conferenceSid The string that uniquely identifies this conference
         */
        public ParticipantReader(string conferenceSid) {
            this.conferenceSid = conferenceSid;
        }
    
        /**
         * Construct a new ParticipantReader
         * 
         * @param accountSid The account_sid
         * @param conferenceSid The string that uniquely identifies this conference
         */
        public ParticipantReader(string accountSid, string conferenceSid) {
            this.accountSid = accountSid;
            this.conferenceSid = conferenceSid;
        }
    
        /**
         * Only show participants that are muted or unmuted
         * 
         * @param muted Filter by muted participants
         * @return this
         */
        public ParticipantReader ByMuted(bool? muted) {
            this.muted = muted;
            return this;
        }
    
        /**
         * The hold
         * 
         * @param hold The hold
         * @return this
         */
        public ParticipantReader ByHold(bool? hold) {
            this.hold = hold;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return ParticipantResource ResourceSet
         */
        public override Task<ResourceSet<ParticipantResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Conferences/" + this.conferenceSid + "/Participants.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<ParticipantResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return ParticipantResource ResourceSet
         */
        public override ResourceSet<ParticipantResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Conferences/" + this.conferenceSid + "/Participants.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<ParticipantResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<ParticipantResource> NextPage(Page<ParticipantResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.API
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /**
         * Generate a Page of ParticipantResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<ParticipantResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ParticipantResource read failed: Unable to connect to server");
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
            
            return Page<ParticipantResource>.FromJson("participants", response.GetContent());
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void AddQueryParams(Request request) {
            if (muted != null) {
                request.AddQueryParam("Muted", muted.ToString());
            }
            
            if (hold != null) {
                request.AddQueryParam("Hold", hold.ToString());
            }
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}