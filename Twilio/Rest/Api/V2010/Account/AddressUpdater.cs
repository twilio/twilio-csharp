using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account {

    public class AddressUpdater : Updater<AddressResource> {
        private string accountSid;
        private string sid;
        private string friendlyName;
        private string customerName;
        private string street;
        private string city;
        private string region;
        private string postalCode;
    
        /// <summary>
        /// Construct a new AddressUpdater.
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public AddressUpdater(string sid) {
            this.sid = sid;
        }
    
        /// <summary>
        /// Construct a new AddressUpdater
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="sid"> The sid </param>
        public AddressUpdater(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /// <summary>
        /// The friendly_name
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        /// <returns> this </returns> 
        public AddressUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /// <summary>
        /// The customer_name
        /// </summary>
        ///
        /// <param name="customerName"> The customer_name </param>
        /// <returns> this </returns> 
        public AddressUpdater setCustomerName(string customerName) {
            this.customerName = customerName;
            return this;
        }
    
        /// <summary>
        /// The street
        /// </summary>
        ///
        /// <param name="street"> The street </param>
        /// <returns> this </returns> 
        public AddressUpdater setStreet(string street) {
            this.street = street;
            return this;
        }
    
        /// <summary>
        /// The city
        /// </summary>
        ///
        /// <param name="city"> The city </param>
        /// <returns> this </returns> 
        public AddressUpdater setCity(string city) {
            this.city = city;
            return this;
        }
    
        /// <summary>
        /// The region
        /// </summary>
        ///
        /// <param name="region"> The region </param>
        /// <returns> this </returns> 
        public AddressUpdater setRegion(string region) {
            this.region = region;
            return this;
        }
    
        /// <summary>
        /// The postal_code
        /// </summary>
        ///
        /// <param name="postalCode"> The postal_code </param>
        /// <returns> this </returns> 
        public AddressUpdater setPostalCode(string postalCode) {
            this.postalCode = postalCode;
            return this;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the update
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Updated AddressResource </returns> 
        public override async Task<AddressResource> UpdateAsync(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Addresses/" + this.sid + ".json"
            );
            addPostParams(request);
            
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
        public override AddressResource Update(ITwilioRestClient client) {
            var request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Addresses/" + this.sid + ".json"
            );
            addPostParams(request);
            
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
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
            
            if (customerName != null) {
                request.AddPostParam("CustomerName", customerName);
            }
            
            if (street != null) {
                request.AddPostParam("Street", street);
            }
            
            if (city != null) {
                request.AddPostParam("City", city);
            }
            
            if (region != null) {
                request.AddPostParam("Region", region);
            }
            
            if (postalCode != null) {
                request.AddPostParam("PostalCode", postalCode);
            }
        }
    }
}