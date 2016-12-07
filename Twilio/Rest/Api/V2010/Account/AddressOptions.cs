using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class CreateAddressOptions : IOptions<AddressResource> 
    {
        public string AccountSid { get; set; }
        public string CustomerName { get; }
        public string Street { get; }
        public string City { get; }
        public string Region { get; }
        public string PostalCode { get; }
        public string IsoCountry { get; }
        public string FriendlyName { get; set; }
        public bool? EmergencyEnabled { get; set; }
    
        /// <summary>
        /// Construct a new CreateAddressOptions
        /// </summary>
        ///
        /// <param name="customerName"> The customer_name </param>
        /// <param name="street"> The street </param>
        /// <param name="city"> The city </param>
        /// <param name="region"> The region </param>
        /// <param name="postalCode"> The postal_code </param>
        /// <param name="isoCountry"> The iso_country </param>
        public CreateAddressOptions(string customerName, string street, string city, string region, string postalCode, string isoCountry)
        {
            CustomerName = customerName;
            Street = street;
            City = city;
            Region = region;
            PostalCode = postalCode;
            IsoCountry = isoCountry;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (CustomerName != null)
            {
                p.Add(new KeyValuePair<string, string>("CustomerName", CustomerName));
            }
            
            if (Street != null)
            {
                p.Add(new KeyValuePair<string, string>("Street", Street));
            }
            
            if (City != null)
            {
                p.Add(new KeyValuePair<string, string>("City", City));
            }
            
            if (Region != null)
            {
                p.Add(new KeyValuePair<string, string>("Region", Region));
            }
            
            if (PostalCode != null)
            {
                p.Add(new KeyValuePair<string, string>("PostalCode", PostalCode));
            }
            
            if (IsoCountry != null)
            {
                p.Add(new KeyValuePair<string, string>("IsoCountry", IsoCountry));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (EmergencyEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("EmergencyEnabled", EmergencyEnabled.ToString()));
            }
            
            return p;
        }
    }

    public class DeleteAddressOptions : IOptions<AddressResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteAddressOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public DeleteAddressOptions(string sid)
        {
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    public class FetchAddressOptions : IOptions<AddressResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchAddressOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public FetchAddressOptions(string sid)
        {
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    public class UpdateAddressOptions : IOptions<AddressResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
        public string FriendlyName { get; set; }
        public string CustomerName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public bool? EmergencyEnabled { get; set; }
    
        /// <summary>
        /// Construct a new UpdateAddressOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public UpdateAddressOptions(string sid)
        {
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (CustomerName != null)
            {
                p.Add(new KeyValuePair<string, string>("CustomerName", CustomerName));
            }
            
            if (Street != null)
            {
                p.Add(new KeyValuePair<string, string>("Street", Street));
            }
            
            if (City != null)
            {
                p.Add(new KeyValuePair<string, string>("City", City));
            }
            
            if (Region != null)
            {
                p.Add(new KeyValuePair<string, string>("Region", Region));
            }
            
            if (PostalCode != null)
            {
                p.Add(new KeyValuePair<string, string>("PostalCode", PostalCode));
            }
            
            if (EmergencyEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("EmergencyEnabled", EmergencyEnabled.ToString()));
            }
            
            return p;
        }
    }

    public class ReadAddressOptions : ReadOptions<AddressResource> 
    {
        public string AccountSid { get; set; }
        public string CustomerName { get; set; }
        public string FriendlyName { get; set; }
        public string IsoCountry { get; set; }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (CustomerName != null)
            {
                p.Add(new KeyValuePair<string, string>("CustomerName", CustomerName));
            }
            
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (IsoCountry != null)
            {
                p.Add(new KeyValuePair<string, string>("IsoCountry", IsoCountry));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

}