using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Trunking.V1.Trunk 
{

    public class PhoneNumberCreator : Creator<PhoneNumberResource> 
    {
        public string trunkSid { get; }
        public string phoneNumberSid { get; }
    
        /// <summary>
        /// Construct a new PhoneNumberCreator
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="phoneNumberSid"> The phone_number_sid </param>
        public PhoneNumberCreator(string trunkSid, string phoneNumberSid)
        {
            this.trunkSid = trunkSid;
            this.phoneNumberSid = phoneNumberSid;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created PhoneNumberResource </returns> 
        public override async Task<PhoneNumberResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/PhoneNumbers"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("PhoneNumberResource creation failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return PhoneNumberResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created PhoneNumberResource </returns> 
        public override PhoneNumberResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.TRUNKING,
                "/v1/Trunks/" + this.trunkSid + "/PhoneNumbers"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("PhoneNumberResource creation failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return PhoneNumberResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (phoneNumberSid != null)
            {
                request.AddPostParam("PhoneNumberSid", phoneNumberSid);
            }
        }
    }
}