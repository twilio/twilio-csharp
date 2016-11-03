using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Sip.IpAccessControlList 
{

    public class IpAddressFetcher : Fetcher<IpAddressResource> 
    {
        public string accountSid { get; set; }
        public string ipAccessControlListSid { get; }
        public string sid { get; }
    
        /// <summary>
        /// Construct a new IpAddressFetcher
        /// </summary>
        ///
        /// <param name="ipAccessControlListSid"> The ip_access_control_list_sid </param>
        /// <param name="sid"> The sid </param>
        public IpAddressFetcher(string ipAccessControlListSid, string sid)
        {
            this.ipAccessControlListSid = ipAccessControlListSid;
            this.sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched IpAddressResource </returns> 
        public override async Task<IpAddressResource> FetchAsync(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/SIP/IpAccessControlLists/" + this.ipAccessControlListSid + "/IpAddresses/" + this.sid + ".json"
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("IpAddressResource fetch failed: Unable to connect to server");
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
            
            return IpAddressResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the fetch
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Fetched IpAddressResource </returns> 
        public override IpAddressResource Fetch(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/SIP/IpAccessControlLists/" + this.ipAccessControlListSid + "/IpAddresses/" + this.sid + ".json"
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("IpAddressResource fetch failed: Unable to connect to server");
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
            
            return IpAddressResource.FromJson(response.Content);
        }
    }
}