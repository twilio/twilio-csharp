using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class AddressResource : Resource 
    {
        private static Request BuildCreateRequest(CreateAddressOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Addresses.json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static AddressResource Create(CreateAddressOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<AddressResource> CreateAsync(CreateAddressOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static AddressResource Create(string customerName, string street, string city, string region, string postalCode, string isoCountry, string accountSid = null, string friendlyName = null, bool? emergencyEnabled = null, ITwilioRestClient client = null)
        {
            var options = new CreateAddressOptions(customerName, street, city, region, postalCode, isoCountry){AccountSid = accountSid, FriendlyName = friendlyName, EmergencyEnabled = emergencyEnabled};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<AddressResource> CreateAsync(string customerName, string street, string city, string region, string postalCode, string isoCountry, string accountSid = null, string friendlyName = null, bool? emergencyEnabled = null, ITwilioRestClient client = null)
        {
            var options = new CreateAddressOptions(customerName, street, city, region, postalCode, isoCountry){AccountSid = accountSid, FriendlyName = friendlyName, EmergencyEnabled = emergencyEnabled};
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteAddressOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Addresses/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeleteAddressOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteAddressOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteAddressOptions(sid){AccountSid = accountSid};
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new DeleteAddressOptions(sid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        private static Request BuildFetchRequest(FetchAddressOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Addresses/" + options.Sid + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static AddressResource Fetch(FetchAddressOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<AddressResource> FetchAsync(FetchAddressOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static AddressResource Fetch(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchAddressOptions(sid){AccountSid = accountSid};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<AddressResource> FetchAsync(string sid, string accountSid = null, ITwilioRestClient client = null)
        {
            var options = new FetchAddressOptions(sid){AccountSid = accountSid};
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildUpdateRequest(UpdateAddressOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Addresses/" + options.Sid + ".json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static AddressResource Update(UpdateAddressOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<AddressResource> UpdateAsync(UpdateAddressOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static AddressResource Update(string sid, string accountSid = null, string friendlyName = null, string customerName = null, string street = null, string city = null, string region = null, string postalCode = null, bool? emergencyEnabled = null, ITwilioRestClient client = null)
        {
            var options = new UpdateAddressOptions(sid){AccountSid = accountSid, FriendlyName = friendlyName, CustomerName = customerName, Street = street, City = city, Region = region, PostalCode = postalCode, EmergencyEnabled = emergencyEnabled};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<AddressResource> UpdateAsync(string sid, string accountSid = null, string friendlyName = null, string customerName = null, string street = null, string city = null, string region = null, string postalCode = null, bool? emergencyEnabled = null, ITwilioRestClient client = null)
        {
            var options = new UpdateAddressOptions(sid){AccountSid = accountSid, FriendlyName = friendlyName, CustomerName = customerName, Street = street, City = city, Region = region, PostalCode = postalCode, EmergencyEnabled = emergencyEnabled};
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        private static Request BuildReadRequest(ReadAddressOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.AccountSid ?? client.AccountSid) + "/Addresses.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<AddressResource> Read(ReadAddressOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<AddressResource>.FromJson("addresses", response.Content);
            return new ResourceSet<AddressResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<AddressResource>> ReadAsync(ReadAddressOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<AddressResource> Read(string accountSid = null, string customerName = null, string friendlyName = null, string isoCountry = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadAddressOptions{AccountSid = accountSid, CustomerName = customerName, FriendlyName = friendlyName, IsoCountry = isoCountry, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<AddressResource>> ReadAsync(string accountSid = null, string customerName = null, string friendlyName = null, string isoCountry = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadAddressOptions{AccountSid = accountSid, CustomerName = customerName, FriendlyName = friendlyName, IsoCountry = isoCountry, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<AddressResource> NextPage(Page<AddressResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<AddressResource>.FromJson("addresses", response.Content);
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
        public string AccountSid { get; private set; }
        [JsonProperty("city")]
        public string City { get; private set; }
        [JsonProperty("customer_name")]
        public string CustomerName { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("iso_country")]
        public string IsoCountry { get; private set; }
        [JsonProperty("postal_code")]
        public string PostalCode { get; private set; }
        [JsonProperty("region")]
        public string Region { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("street")]
        public string Street { get; private set; }
        [JsonProperty("uri")]
        public string Uri { get; private set; }
        [JsonProperty("emergency_enabled")]
        public bool? EmergencyEnabled { get; private set; }
    
        private AddressResource()
        {
        
        }
    }

}