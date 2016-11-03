using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Rest.Api.V2010.Account.Sip.Domain;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.Sip.Domain 
{

    public class IpAccessControlListMappingDeleter : Deleter<IpAccessControlListMappingResource> 
    {
        public string accountSid { get; set; }
        public string domainSid { get; }
        public string sid { get; }
    
        /// <summary>
        /// Construct a new IpAccessControlListMappingDeleter
        /// </summary>
        ///
        /// <param name="domainSid"> The domain_sid </param>
        /// <param name="sid"> The sid </param>
        public IpAccessControlListMappingDeleter(string domainSid, string sid)
        {
            this.domainSid = domainSid;
            this.sid = sid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the delete
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        public override async System.Threading.Tasks.Task DeleteAsync(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.DELETE,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/SIP/Domains/" + this.domainSid + "/IpAccessControlListMappings/" + this.sid + ".json"
            );
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("IpAccessControlListMappingResource delete failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to delete record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return;
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the delete
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        public override void Delete(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.DELETE,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/SIP/Domains/" + this.domainSid + "/IpAccessControlListMappings/" + this.sid + ".json"
            );
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("IpAccessControlListMappingResource delete failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to delete record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return;
        }
    }
}