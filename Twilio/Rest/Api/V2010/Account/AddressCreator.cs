using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account 
{

    public class AddressCreator : Creator<AddressResource> 
    {
        public string accountSid { get; set; }
        public string customerName { get; }
        public string street { get; }
        public string city { get; }
        public string region { get; }
        public string postalCode { get; }
        public string isoCountry { get; }
        public string friendlyName { get; set; }
    
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
            this.customerName = customerName;
            this.street = street;
            this.city = city;
            this.region = region;
            this.postalCode = postalCode;
            this.isoCountry = isoCountry;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the create
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Created AddressResource </returns> 
        public override async Task<AddressResource> CreateAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.POST,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Addresses.json"
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
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/Addresses.json"
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
            if (customerName != null)
            {
                request.AddPostParam("CustomerName", customerName);
            }
            
            if (street != null)
            {
                request.AddPostParam("Street", street);
            }
            
            if (city != null)
            {
                request.AddPostParam("City", city);
            }
            
            if (region != null)
            {
                request.AddPostParam("Region", region);
            }
            
            if (postalCode != null)
            {
                request.AddPostParam("PostalCode", postalCode);
            }
            
            if (isoCountry != null)
            {
                request.AddPostParam("IsoCountry", isoCountry);
            }
            
            if (friendlyName != null)
            {
                request.AddPostParam("FriendlyName", friendlyName);
            }
        }
    }
}