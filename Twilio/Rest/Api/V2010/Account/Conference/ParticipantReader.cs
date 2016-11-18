using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Conference 
{

    public class ParticipantReader : Reader<ParticipantResource> 
    {
        public string AccountSid { get; set; }
        public string ConferenceSid { get; }
        public bool? Muted { get; set; }
        public bool? Hold { get; set; }
    
        /// <summary>
        /// Construct a new ParticipantReader
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        public ParticipantReader(string conferenceSid)
        {
            ConferenceSid = conferenceSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> ParticipantResource ResourceSet </returns> 
        public override System.Threading.Tasks.Task<ResourceSet<ParticipantResource>> ReadAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.AccountSid) + "/Conferences/" + ConferenceSid + "/Participants.json"
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
        public override ResourceSet<ParticipantResource> Read(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.AccountSid) + "/Conferences/" + ConferenceSid + "/Participants.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<ParticipantResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="page"> current page of results </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<ParticipantResource> NextPage(Page<ParticipantResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api
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
        protected Page<ParticipantResource> PageForRequest(ITwilioRestClient client, Request request)
        {
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
        private void AddQueryParams(Request request)
        {
            if (Muted != null)
            {
                request.AddQueryParam("Muted", Muted.ToString());
            }
            
            if (Hold != null)
            {
                request.AddQueryParam("Hold", Hold.ToString());
            }
            
            if (PageSize != null)
            {
                request.AddQueryParam("PageSize", PageSize.ToString());
            }
        }
    }
}