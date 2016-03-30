using System.Threading.Tasks;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources;
using Twilio.Resources.Api.V2010.Account.Conference;

namespace Twilio.Readers.Api.V2010.Account.Conference {

    public class ParticipantReader : Reader<ParticipantResource> {
        private string accountSid;
        private string conferenceSid;
        private bool? muted;
    
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
        public ParticipantReader byMuted(bool? muted) {
            this.muted = muted;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return ParticipantResource ResourceSet
         */
        public override async Task<ResourceSet<ParticipantResource>> ExecuteAsync(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Conferences/" + this.conferenceSid + "/Participants.json"
            );
            
            AddQueryParams(request);
            
            Page<ParticipantResource> page = await PageForRequest(client, request);
            
            return new ResourceSet<ParticipantResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<ParticipantResource> NextPage(string nextPageUri, TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            
            var task = PageForRequest(client, request);
            task.Wait();
            
            return task.Result;
        }
    
        /**
         * Generate a Page of ParticipantResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected async Task<Page<ParticipantResource>> PageForRequest(TwilioRestClient client, Request request) {
            Response response = await client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("ParticipantResource read failed: Unable to connect to server");
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
            
            Page<ParticipantResource> result = new Page<ParticipantResource>();
            result.deserialize("participants", response.GetContent());
            
            return result;
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
            
            request.AddQueryParam("PageSize", GetPageSize().ToString());
        }
    }
}