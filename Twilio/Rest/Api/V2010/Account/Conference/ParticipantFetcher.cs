using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.Conference 
{

    public class ParticipantFetcher : Fetcher<ParticipantResource> 
    {
        public string AccountSid { get; set; }
        public string ConferenceSid { get; }
        public string CallSid { get; }
    
        /// <summary>
        /// Construct a new ParticipantFetcher
        /// </summary>
        ///
        /// <param name="conferenceSid"> The string that uniquely identifies this conference </param>
        /// <param name="callSid"> The call_sid </param>
        public ParticipantFetcher(string conferenceSid, string callSid)
        {
            ConferenceSid = conferenceSid;
            CallSid = callSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched ParticipantResource </returns> 
        public override async System.Threading.Tasks.Task<ParticipantResource> FetchAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.AccountSid) + "/Conferences/" + ConferenceSid + "/Participants/" + CallSid + ".json"
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("ParticipantResource fetch failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to fetch record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return ParticipantResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched ParticipantResource </returns> 
        public override ParticipantResource Fetch(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.AccountSid) + "/Conferences/" + ConferenceSid + "/Participants/" + CallSid + ".json"
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("ParticipantResource fetch failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to fetch record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return ParticipantResource.FromJson(response.Content);
        }
    }
}