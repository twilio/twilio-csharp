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
    
        /// <summary>
        /// Construct a new ParticipantReader.
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        public ParticipantReader(string conferenceSid) {
            this.conferenceSid = conferenceSid;
        }
    
        /// <summary>
        /// Construct a new ParticipantReader
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        public ParticipantReader(string accountSid, string conferenceSid) {
            this.accountSid = accountSid;
            this.conferenceSid = conferenceSid;
        }
    
        /// <summary>
        /// Only show participants that are muted or unmuted
        /// </summary>
        ///
        /// <param name="muted"> Filter by muted participants </param>
        /// <returns> this </returns> 
        public ParticipantReader ByMuted(bool? muted) {
            this.muted = muted;
            return this;
        }
    
        /// <summary>
        /// The hold
        /// </summary>
        ///
        /// <param name="hold"> The hold </param>
        /// <returns> this </returns> 
        public ParticipantReader ByHold(bool? hold) {
            this.hold = hold;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> ParticipantResource ResourceSet </returns> 
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
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> ParticipantResource ResourceSet </returns> 
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
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="nextPageUri"> URI from which to retrieve the next page </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<ParticipantResource> NextPage(Page<ParticipantResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.API
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of ParticipantResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<ParticipantResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ParticipantResource read failed: Unable to connect to server");
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
            
            return Page<ParticipantResource>.FromJson("participants", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
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