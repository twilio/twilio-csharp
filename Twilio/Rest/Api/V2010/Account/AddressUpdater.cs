using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account 
{

    public class AddressUpdater : Updater<AddressResource> 
    {
        public string accountSid { get; }
        public string sid { get; }
        public string friendlyName { get; set; }
        public string customerName { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string postalCode { get; set; }
    
        /// <summary>
        /// Construct a new AddressUpdater
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="friendlyName"> The friendly_name </param>
        /// <param name="customerName"> The customer_name </param>
        /// <param name="street"> The street </param>
        /// <param name="city"> The city </param>
        /// <param name="region"> The region </param>
        /// <param name="postalCode"> The postal_code </param>
        public AddressUpdater(string sid, string accountSid=null, string friendlyName=null, string customerName=null, string street=null, string city=null, string region=null, string postalCode=null)
        {
            this.city = city;
            this.sid = sid;
            this.street = street;
            this.customerName = customerName;
            this.accountSid = accountSid;
            this.region = region;
            this.friendlyName = friendlyName;
            this.postalCode = postalCode;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated AddressResource </returns> 
        public override async Task<AddressResource> UpdateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Addresses/" + this.sid + ".json"
            );
            AddPostParams(request);
            
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("AddressResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return AddressResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated AddressResource </returns> 
        public override AddressResource Update(ITwilioRestClient client)
        {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Addresses/" + this.sid + ".json"
            );
            AddPostParams(request);
            
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("AddressResource update failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to update record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return AddressResource.FromJson(response.Content);
        }
    
        /// <summary>
        /// Add the requested post parameters to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add post params to </param>
        private void AddPostParams(Request request)
        {
            if (friendlyName != null)
            {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (customerName != null)
            {
                request.AddPostParam("CustomerName", customerName);
            }
            
            if (street != null)
            {
                request.AddPostParam("Street", street);
            }
            
            if (city != null)
            {
                request.AddPostParam("City", city);
            }
            
            if (region != null)
            {
                request.AddPostParam("Region", region);
            }
            
            if (postalCode != null)
            {
                request.AddPostParam("PostalCode", postalCode);
            }
        }
    }
}