using Newtonsoft.Json;
using System;
using Twilio.Clients.TwilioRestClient;
using Twilio.Creators.Api.V2010.Account;
using Twilio.Deleters.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account;
using com.twilio.sdk.converters.MarshalConverter;
using org.joda.time.DateTime;

namespace Twilio.Resources.Api.V2010.Account {

    public class Address : SidResource {
        /**
         * create
         * 
         * @param accountSid The account_sid
         * @param customerName The customer_name
         * @param street The street
         * @param city The city
         * @param region The region
         * @param postalCode The postal_code
         * @param isoCountry The iso_country
         * @return AddressCreator capable of executing the create
         */
        public static AddressCreator create(String accountSid, String customerName, String street, String city, String region, String postalCode, String isoCountry) {
            return new AddressCreator(accountSid, customerName, street, city, region, postalCode, isoCountry);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return AddressDeleter capable of executing the delete
         */
        public static AddressDeleter delete(String accountSid, String sid) {
            return new AddressDeleter(accountSid, sid);
        }
    
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return AddressFetcher capable of executing the fetch
         */
        public static AddressFetcher fetch(String accountSid, String sid) {
            return new AddressFetcher(accountSid, sid);
        }
    
        /**
         * update
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return AddressUpdater capable of executing the update
         */
        public static AddressUpdater update(String accountSid, String sid) {
            return new AddressUpdater(accountSid, sid);
        }
    
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @return AddressReader capable of executing the read
         */
        public static AddressReader read(String accountSid) {
            return new AddressReader(accountSid);
        }
    
        /**
         * Converts a JSON string into a Address object
         * 
         * @param json Raw JSON string
         * @return Address object represented by the provided JSON
         */
        public static Address fromJson(string json) {
            // Convert all checked exceptions to Runtime
            try {
                return JsonConvert.DeserializeObject<Address>(json);
            } catch (JsonException e) {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        private readonly String accountSid;
        [JsonProperty("city")]
        private readonly String city;
        [JsonProperty("customer_name")]
        private readonly String customerName;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly String friendlyName;
        [JsonProperty("iso_country")]
        private readonly String isoCountry;
        [JsonProperty("postal_code")]
        private readonly String postalCode;
        [JsonProperty("region")]
        private readonly String region;
        [JsonProperty("sid")]
        private readonly String sid;
        [JsonProperty("street")]
        private readonly String street;
        [JsonProperty("uri")]
        private readonly String uri;
    
        private Address([JsonProperty("account_sid")]
                        String accountSid, 
                        [JsonProperty("city")]
                        String city, 
                        [JsonProperty("customer_name")]
                        String customerName, 
                        [JsonProperty("date_created")]
                        String dateCreated, 
                        [JsonProperty("date_updated")]
                        String dateUpdated, 
                        [JsonProperty("friendly_name")]
                        String friendlyName, 
                        [JsonProperty("iso_country")]
                        String isoCountry, 
                        [JsonProperty("postal_code")]
                        String postalCode, 
                        [JsonProperty("region")]
                        String region, 
                        [JsonProperty("sid")]
                        String sid, 
                        [JsonProperty("street")]
                        String street, 
                        [JsonProperty("uri")]
                        String uri) {
            this.accountSid = accountSid;
            this.city = city;
            this.customerName = customerName;
            this.dateCreated = MarshalConverter.dateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.dateTimeFromString(dateUpdated);
            this.friendlyName = friendlyName;
            this.isoCountry = isoCountry;
            this.postalCode = postalCode;
            this.region = region;
            this.sid = sid;
            this.street = street;
            this.uri = uri;
        }
    
        /**
         * @return The account_sid
         */
        public String GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The city
         */
        public String GetCity() {
            return this.city;
        }
    
        /**
         * @return The customer_name
         */
        public String GetCustomerName() {
            return this.customerName;
        }
    
        /**
         * @return The date_created
         */
        public DateTime GetDateCreated() {
            return this.dateCreated;
        }
    
        /**
         * @return The date_updated
         */
        public DateTime GetDateUpdated() {
            return this.dateUpdated;
        }
    
        /**
         * @return The friendly_name
         */
        public String GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The iso_country
         */
        public String GetIsoCountry() {
            return this.isoCountry;
        }
    
        /**
         * @return The postal_code
         */
        public String GetPostalCode() {
            return this.postalCode;
        }
    
        /**
         * @return The region
         */
        public String GetRegion() {
            return this.region;
        }
    
        /**
         * @return The sid
         */
        public String GetSid() {
            return this.sid;
        }
    
        /**
         * @return The street
         */
        public String GetStreet() {
            return this.street;
        }
    
        /**
         * @return The uri
         */
        public String GetUri() {
            return this.uri;
        }
    }
}