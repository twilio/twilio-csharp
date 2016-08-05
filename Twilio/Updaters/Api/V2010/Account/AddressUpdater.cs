using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;
using Twilio.Updaters;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Updaters.Api.V2010.Account {

    public class AddressUpdater : Updater<AddressResource> {
        private string accountSid;
        private string sid;
        private string friendlyName;
        private string customerName;
        private string street;
        private string city;
        private string region;
        private string postalCode;
    
        /**
         * Construct a new AddressUpdater.
         * 
         * @param sid The sid
         */
        public AddressUpdater(string sid) {
            this.sid = sid;
        }
    
        /**
         * Construct a new AddressUpdater
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         */
        public AddressUpdater(string accountSid, string sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public AddressUpdater setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The customer_name
         * 
         * @param customerName The customer_name
         * @return this
         */
        public AddressUpdater setCustomerName(string customerName) {
            this.customerName = customerName;
            return this;
        }
    
        /**
         * The street
         * 
         * @param street The street
         * @return this
         */
        public AddressUpdater setStreet(string street) {
            this.street = street;
            return this;
        }
    
        /**
         * The city
         * 
         * @param city The city
         * @return this
         */
        public AddressUpdater setCity(string city) {
            this.city = city;
            return this;
        }
    
        /**
         * The region
         * 
         * @param region The region
         * @return this
         */
        public AddressUpdater setRegion(string region) {
            this.region = region;
            return this;
        }
    
        /**
         * The postal_code
         * 
         * @param postalCode The postal_code
         * @return this
         */
        public AddressUpdater setPostalCode(string postalCode) {
            this.postalCode = postalCode;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated AddressResource
         */
        public override async Task<AddressResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Addresses/" + this.sid + ".json"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("AddressResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to update record, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
                    null
                );
            }
            
            return AddressResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Updated AddressResource
         */
        public override AddressResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Addresses/" + this.sid + ".json"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("AddressResource update failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                RestException restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to update record, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
                    null
                );
            }
            
            return AddressResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
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