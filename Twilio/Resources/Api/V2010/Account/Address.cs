using Newtonsoft.Json;
using System;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Creators.Api.V2010.Account;
using Twilio.Deleters.Api.V2010.Account;
using Twilio.Exceptions;
using Twilio.Fetchers.Api.V2010.Account;
using Twilio.Http;
using Twilio.Readers.Api.V2010.Account;
using Twilio.Resources;
using Twilio.Updaters.Api.V2010.Account;

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
        public static AddressCreator create(string accountSid, string customerName, string street, string city, string region, string postalCode, string isoCountry) {
            return new AddressCreator(accountSid, customerName, street, city, region, postalCode, isoCountry);
        }
    
        /**
         * delete
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return AddressDeleter capable of executing the delete
         */
        public static AddressDeleter delete(string accountSid, string sid) {
            return new AddressDeleter(accountSid, sid);
        }
    
        /**
         * fetch
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return AddressFetcher capable of executing the fetch
         */
        public static AddressFetcher fetch(string accountSid, string sid) {
            return new AddressFetcher(accountSid, sid);
        }
    
        /**
         * update
         * 
         * @param accountSid The account_sid
         * @param sid The sid
         * @return AddressUpdater capable of executing the update
         */
        public static AddressUpdater update(string accountSid, string sid) {
            return new AddressUpdater(accountSid, sid);
        }
    
        /**
         * read
         * 
         * @param accountSid The account_sid
         * @return AddressReader capable of executing the read
         */
        public static AddressReader read(string accountSid) {
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
        private readonly string accountSid;
        [JsonProperty("city")]
        private readonly string city;
        [JsonProperty("customer_name")]
        private readonly string customerName;
        [JsonProperty("date_created")]
        private readonly DateTime dateCreated;
        [JsonProperty("date_updated")]
        private readonly DateTime dateUpdated;
        [JsonProperty("friendly_name")]
        private readonly string friendlyName;
        [JsonProperty("iso_country")]
        private readonly string isoCountry;
        [JsonProperty("postal_code")]
        private readonly string postalCode;
        [JsonProperty("region")]
        private readonly string region;
        [JsonProperty("sid")]
        private readonly string sid;
        [JsonProperty("street")]
        private readonly string street;
        [JsonProperty("uri")]
        private readonly string uri;
    
        private Address([JsonProperty("account_sid")]
                        string accountSid, 
                        [JsonProperty("city")]
                        string city, 
                        [JsonProperty("customer_name")]
                        string customerName, 
                        [JsonProperty("date_created")]
                        string dateCreated, 
                        [JsonProperty("date_updated")]
                        string dateUpdated, 
                        [JsonProperty("friendly_name")]
                        string friendlyName, 
                        [JsonProperty("iso_country")]
                        string isoCountry, 
                        [JsonProperty("postal_code")]
                        string postalCode, 
                        [JsonProperty("region")]
                        string region, 
                        [JsonProperty("sid")]
                        string sid, 
                        [JsonProperty("street")]
                        string street, 
                        [JsonProperty("uri")]
                        string uri) {
            this.accountSid = accountSid;
            this.city = city;
            this.customerName = customerName;
            this.dateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            this.dateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
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
        public string GetAccountSid() {
            return this.accountSid;
        }
    
        /**
         * @return The city
         */
        public string GetCity() {
            return this.city;
        }
    
        /**
         * @return The customer_name
         */
        public string GetCustomerName() {
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
        public string GetFriendlyName() {
            return this.friendlyName;
        }
    
        /**
         * @return The iso_country
         */
        public string GetIsoCountry() {
            return this.isoCountry;
        }
    
        /**
         * @return The postal_code
         */
        public string GetPostalCode() {
            return this.postalCode;
        }
    
        /**
         * @return The region
         */
        public string GetRegion() {
            return this.region;
        }
    
        /**
         * @return The sid
         */
        public string GetSid() {
            return this.sid;
        }
    
        /**
         * @return The street
         */
        public string GetStreet() {
            return this.street;
        }
    
        /**
         * @return The uri
         */
        public string GetUri() {
            return this.uri;
        }
    }
}