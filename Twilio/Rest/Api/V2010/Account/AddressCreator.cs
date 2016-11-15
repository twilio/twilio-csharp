using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class AddressCreator : Creator<AddressResource> 
    {
        public string AccountSid { get; set; }
        public string CustomerName { get; }
        public string Street { get; }
        public string City { get; }
        public string Region { get; }
        public string PostalCode { get; }
        public string IsoCountry { get; }
        public string FriendlyName { get; set; }
    
        /// <summary>
        /// Construct a new AddressCreator
        /// </summary>
        ///
        /// <param name="customerName"> The customer_name </param>
        /// <param name="street"> The street </param>
        /// <param name="city"> The city </param>
        /// <param name="region"> The region </param>
        /// <param name="postalCode"> The postal_code </param>
        /// <param name="isoCountry"> The iso_country </param>
        public AddressCreator(string customerName, string street, string city, string region, string postalCode, string isoCountry)
        {
            CustomerName = customerName;
            Street = street;
            City = city;
            Region = region;
            PostalCode = postalCode;
            IsoCountry = isoCountry;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created AddressResource </returns> 
        public override async System.Threading.Tasks.Task<AddressResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/Addresses.json"
            );
            
            AddPostParams(request);
            var response = await client.RequestAsync(request);
            if (response == null)
            {
                throw new ApiConnectionException("AddressResource creation failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return AddressResource.FromJson(response.Content);
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created AddressResource </returns> 
        public override AddressResource Create(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.Api,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/Addresses.json"
            );
            
            AddPostParams(request);
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("AddressResource creation failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to create record, " + response.StatusCode,
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
            if (CustomerName != null)
            {
                request.AddPostParam("CustomerName", CustomerName);
            }
            
            if (Street != null)
            {
                request.AddPostParam("Street", Street);
            }
            
            if (City != null)
            {
                request.AddPostParam("City", City);
            }
            
            if (Region != null)
            {
                request.AddPostParam("Region", Region);
            }
            
            if (PostalCode != null)
            {
                request.AddPostParam("PostalCode", PostalCode);
            }
            
            if (IsoCountry != null)
            {
                request.AddPostParam("IsoCountry", IsoCountry);
            }
            
            if (FriendlyName != null)
            {
                request.AddPostParam("FriendlyName", FriendlyName);
            }
        }
    }
}