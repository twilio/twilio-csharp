using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

namespace Twilio.Rest.Api.V2010.Account.AvailablePhoneNumberCountry 
{

    public class TollFreeReader : Reader<TollFreeResource> 
    {
        public string AccountSid { get; set; }
        public string CountryCode { get; }
        public int? AreaCode { get; set; }
        public string Contains { get; set; }
        public bool? SmsEnabled { get; set; }
        public bool? MmsEnabled { get; set; }
        public bool? VoiceEnabled { get; set; }
        public bool? ExcludeAllAddressRequired { get; set; }
        public bool? ExcludeLocalAddressRequired { get; set; }
        public bool? ExcludeForeignAddressRequired { get; set; }
        public bool? Beta { get; set; }
        public Types.PhoneNumber NearNumber { get; set; }
        public string NearLatLong { get; set; }
        public int? Distance { get; set; }
        public string InPostalCode { get; set; }
        public string InRegion { get; set; }
        public string InRateCenter { get; set; }
        public string InLata { get; set; }
    
        /// <summary>
        /// Construct a new TollFreeReader
        /// </summary>
        ///
        /// <param name="countryCode"> The country_code </param>
        public TollFreeReader(string countryCode)
        {
            CountryCode = countryCode;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> TollFreeResource ResourceSet </returns> 
        public override System.Threading.Tasks.Task<ResourceSet<TollFreeResource>> ReadAsync(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/AvailablePhoneNumbers/" + CountryCode + "/TollFree.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<TollFreeResource>(this, client, page));
        }
        #endif
    
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> TollFreeResource ResourceSet </returns> 
        public override ResourceSet<TollFreeResource> Read(ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (AccountSid ?? client.GetAccountSid()) + "/AvailablePhoneNumbers/" + CountryCode + "/TollFree.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<TollFreeResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="page"> current page of results </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<TollFreeResource> NextPage(Page<TollFreeResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.API
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /// <summary>
        /// Generate a Page of TollFreeResource Resources for a given request
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <param name="request"> Request to generate a page for </param>
        /// <returns> Page for the Request </returns> 
        protected Page<TollFreeResource> PageForRequest(ITwilioRestClient client, Request request)
        {
            var response = client.Request(request);
            if (response == null)
            {
                throw new ApiConnectionException("TollFreeResource read failed: Unable to connect to server");
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
                    restException.Message ?? "Unable to read records, " + response.StatusCode,
                    restException.MoreInfo
                );
            }
            
            return Page<TollFreeResource>.FromJson("available_phone_numbers", response.Content);
        }
    
        /// <summary>
        /// Add the requested query string arguments to the Request
        /// </summary>
        ///
        /// <param name="request"> Request to add query string arguments to </param>
        private void AddQueryParams(Request request)
        {
            if (AreaCode != null)
            {
                request.AddQueryParam("AreaCode", AreaCode.ToString());
            }
            
            if (Contains != null)
            {
                request.AddQueryParam("Contains", Contains);
            }
            
            if (SmsEnabled != null)
            {
                request.AddQueryParam("SmsEnabled", SmsEnabled.ToString());
            }
            
            if (MmsEnabled != null)
            {
                request.AddQueryParam("MmsEnabled", MmsEnabled.ToString());
            }
            
            if (VoiceEnabled != null)
            {
                request.AddQueryParam("VoiceEnabled", VoiceEnabled.ToString());
            }
            
            if (ExcludeAllAddressRequired != null)
            {
                request.AddQueryParam("ExcludeAllAddressRequired", ExcludeAllAddressRequired.ToString());
            }
            
            if (ExcludeLocalAddressRequired != null)
            {
                request.AddQueryParam("ExcludeLocalAddressRequired", ExcludeLocalAddressRequired.ToString());
            }
            
            if (ExcludeForeignAddressRequired != null)
            {
                request.AddQueryParam("ExcludeForeignAddressRequired", ExcludeForeignAddressRequired.ToString());
            }
            
            if (Beta != null)
            {
                request.AddQueryParam("Beta", Beta.ToString());
            }
            
            if (NearNumber != null)
            {
                request.AddQueryParam("NearNumber", NearNumber.ToString());
            }
            
            if (NearLatLong != null)
            {
                request.AddQueryParam("NearLatLong", NearLatLong);
            }
            
            if (Distance != null)
            {
                request.AddQueryParam("Distance", Distance.ToString());
            }
            
            if (InPostalCode != null)
            {
                request.AddQueryParam("InPostalCode", InPostalCode);
            }
            
            if (InRegion != null)
            {
                request.AddQueryParam("InRegion", InRegion);
            }
            
            if (InRateCenter != null)
            {
                request.AddQueryParam("InRateCenter", InRateCenter);
            }
            
            if (InLata != null)
            {
                request.AddQueryParam("InLata", InLata);
            }
            
            if (PageSize != null)
            {
                request.AddQueryParam("PageSize", PageSize.ToString());
            }
        }
    }
}