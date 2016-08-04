using Twilio.Clients;
using Twilio.Creators;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.Account;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Creators.Api.V2010.Account {

    public class AddressCreator : Creator<AddressResource> {
        private string accountSid;
        private string customerName;
        private string street;
        private string city;
        private string region;
        private string postalCode;
        private string isoCountry;
        private string friendlyName;
    
        /**
         * Construct a new AddressCreator.
         * 
         * @param customerName The customer_name
         * @param street The street
         * @param city The city
         * @param region The region
         * @param postalCode The postal_code
         * @param isoCountry The iso_country
         */
        public AddressCreator(string customerName, string street, string city, string region, string postalCode, string isoCountry) {
            this.customerName = customerName;
            this.street = street;
            this.city = city;
            this.region = region;
            this.postalCode = postalCode;
            this.isoCountry = isoCountry;
        }
    
        /**
         * Construct a new AddressCreator
         * 
         * @param accountSid The account_sid
         * @param customerName The customer_name
         * @param street The street
         * @param city The city
         * @param region The region
         * @param postalCode The postal_code
         * @param isoCountry The iso_country
         */
        public AddressCreator(string accountSid, string customerName, string street, string city, string region, string postalCode, string isoCountry) {
            this.accountSid = accountSid;
            this.customerName = customerName;
            this.street = street;
            this.city = city;
            this.region = region;
            this.postalCode = postalCode;
            this.isoCountry = isoCountry;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public AddressCreator setFriendlyName(string friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created AddressResource
         */
        public override async Task<AddressResource> ExecuteAsync(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Addresses.json"
            );
            
            addPostParams(request);
            Response response = await client.RequestAsync(request);
            
            if (response == null) {
                throw new ApiConnectionException("AddressResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
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
            
            return AddressResource.FromJson(response.GetContent());
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the create
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return Created AddressResource
         */
        public override AddressResource Execute(ITwilioRestClient client) {
            Request request = new Request(
                Twilio.Http.HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/Addresses.json"
            );
            
            addPostParams(request);
            Response response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("AddressResource creation failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
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
            
            return AddressResource.FromJson(response.GetContent());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
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
            
            if (isoCountry != null) {
                request.AddPostParam("IsoCountry", isoCountry);
            }
            
            if (friendlyName != null) {
                request.AddPostParam("FriendlyName", friendlyName);
            }
        }
    }
}