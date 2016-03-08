using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.Address;
using com.twilio.sdk.updaters.Updater;

namespace Twilio.Updaters.Api.V2010.Account {

    public class AddressUpdater : Updater<Address> {
        private String accountSid;
        private String sid;
        private String friendlyName;
        private String customerName;
        private String street;
        private String city;
        private String region;
        private String postalCode;
    
        /**
         * Construct a new AddressUpdater
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         */
        public AddressUpdater(String accountSid, String sid) {
            this.accountSid = accountSid;
            this.sid = sid;
        }
    
        /**
         * The friendly_name
         * 
         * @param friendlyName The friendly_name
         * @return this
         */
        public AddressUpdater setFriendlyName(String friendlyName) {
            this.friendlyName = friendlyName;
            return this;
        }
    
        /**
         * The customer_name
         * 
         * @param customerName The customer_name
         * @return this
         */
        public AddressUpdater setCustomerName(String customerName) {
            this.customerName = customerName;
            return this;
        }
    
        /**
         * The street
         * 
         * @param street The street
         * @return this
         */
        public AddressUpdater setStreet(String street) {
            this.street = street;
            return this;
        }
    
        /**
         * The city
         * 
         * @param city The city
         * @return this
         */
        public AddressUpdater setCity(String city) {
            this.city = city;
            return this;
        }
    
        /**
         * The region
         * 
         * @param region The region
         * @return this
         */
        public AddressUpdater setRegion(String region) {
            this.region = region;
            return this;
        }
    
        /**
         * The postal_code
         * 
         * @param postalCode The postal_code
         * @return this
         */
        public AddressUpdater setPostalCode(String postalCode) {
            this.postalCode = postalCode;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the update
         * 
         * @param client TwilioRestClient with which to make the request
         * @return Updated Address
         */
        [Override]
        public Address execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.POST,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/Addresses/" + this.sid + ".json",
                client.getAccountSid()
            );
            
            addPostParams(request);
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("Address update failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.getStream(), client.getObjectMapper());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.getMessage(),
                    restException.getCode(),
                    restException.getMoreInfo(),
                    restException.getStatus(),
                    null
                );
            }
            
            return Address.fromJson(response.getStream(), client.getObjectMapper());
        }
    
        /**
         * Add the requested post parameters to the Request
         * 
         * @param request Request to add post params to
         */
        private void addPostParams(Request request) {
            if (friendlyName != null) {
                request.addPostParam("FriendlyName", friendlyName);
            }
            
            if (customerName != null) {
                request.addPostParam("CustomerName", customerName);
            }
            
            if (street != null) {
                request.addPostParam("Street", street);
            }
            
            if (city != null) {
                request.addPostParam("City", city);
            }
            
            if (region != null) {
                request.addPostParam("Region", region);
            }
            
            if (postalCode != null) {
                request.addPostParam("PostalCode", postalCode);
            }
        }
    }
}