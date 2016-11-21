using Newtonsoft.Json;
using System;
using Twilio.Base;
using Twilio.Converters;
using Twilio.Exceptions;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class AddressResource : Resource 
    {
        /// <summary>
        /// create
        /// </summary>
        ///
        /// <param name="customerName"> The customer_name </param>
        /// <param name="street"> The street </param>
        /// <param name="city"> The city </param>
        /// <param name="region"> The region </param>
        /// <param name="postalCode"> The postal_code </param>
        /// <param name="isoCountry"> The iso_country </param>
        /// <returns> AddressCreator capable of executing the create </returns> 
        public static AddressCreator Creator(string customerName, string street, string city, string region, string postalCode, string isoCountry)
        {
            return new AddressCreator(customerName, street, city, region, postalCode, isoCountry);
        }
    
        /// <summary>
        /// delete
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> AddressDeleter capable of executing the delete </returns> 
        public static AddressDeleter Deleter(string sid)
        {
            return new AddressDeleter(sid);
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> AddressFetcher capable of executing the fetch </returns> 
        public static AddressFetcher Fetcher(string sid)
        {
            return new AddressFetcher(sid);
        }
    
        /// <summary>
        /// update
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        /// <returns> AddressUpdater capable of executing the update </returns> 
        public static AddressUpdater Updater(string sid)
        {
            return new AddressUpdater(sid);
        }
    
        /// <summary>
        /// read
        /// </summary>
        ///
        /// <returns> AddressReader capable of executing the read </returns> 
        public static AddressReader Reader()
        {
            return new AddressReader();
        }
    
        /// <summary>
        /// Converts a JSON string into a AddressResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AddressResource object represented by the provided JSON </returns> 
        public static AddressResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<AddressResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("account_sid")]
        public string AccountSid { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; set; }
        [JsonProperty("iso_country")]
        public string IsoCountry { get; set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("sid")]
        public string Sid { get; set; }
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("uri")]
        public string Uri { get; set; }
    
        public AddressResource()
        {
        
        }
    
        private AddressResource([JsonProperty("account_sid")]
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
                                string uri)
                                {
            AccountSid = accountSid;
            City = city;
            CustomerName = customerName;
            DateCreated = MarshalConverter.DateTimeFromString(dateCreated);
            DateUpdated = MarshalConverter.DateTimeFromString(dateUpdated);
            FriendlyName = friendlyName;
            IsoCountry = isoCountry;
            PostalCode = postalCode;
            Region = region;
            Sid = sid;
            Street = street;
            Uri = uri;
        }
    }
}