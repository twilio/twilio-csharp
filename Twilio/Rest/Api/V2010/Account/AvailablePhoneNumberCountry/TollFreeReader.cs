using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.AvailablePhoneNumberCountry {

    public class TollFreeReader : Reader<TollFreeResource> {
        public string accountSid { get; }
        public string countryCode { get; }
        public int? areaCode { get; set; }
        public string contains { get; set; }
        public bool? smsEnabled { get; set; }
        public bool? mmsEnabled { get; set; }
        public bool? voiceEnabled { get; set; }
        public bool? excludeAllAddressRequired { get; set; }
        public bool? excludeLocalAddressRequired { get; set; }
        public bool? excludeForeignAddressRequired { get; set; }
        public bool? beta { get; set; }
        public Twilio.Types.PhoneNumber nearNumber { get; set; }
        public string nearLatLong { get; set; }
        public int? distance { get; set; }
        public string inPostalCode { get; set; }
        public string inRegion { get; set; }
        public string inRateCenter { get; set; }
        public string inLata { get; set; }
    
        /// <summary>
        /// Construct a new TollFreeReader
        /// </summary>
        ///
        /// <param name="countryCode"> The country_code </param>
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="areaCode"> The area_code </param>
        /// <param name="contains"> The contains </param>
        /// <param name="smsEnabled"> The sms_enabled </param>
        /// <param name="mmsEnabled"> The mms_enabled </param>
        /// <param name="voiceEnabled"> The voice_enabled </param>
        /// <param name="excludeAllAddressRequired"> The exclude_all_address_required </param>
        /// <param name="excludeLocalAddressRequired"> The exclude_local_address_required </param>
        /// <param name="excludeForeignAddressRequired"> The exclude_foreign_address_required </param>
        /// <param name="beta"> The beta </param>
        /// <param name="nearNumber"> The near_number </param>
        /// <param name="nearLatLong"> The near_lat_long </param>
        /// <param name="distance"> The distance </param>
        /// <param name="inPostalCode"> The in_postal_code </param>
        /// <param name="inRegion"> The in_region </param>
        /// <param name="inRateCenter"> The in_rate_center </param>
        /// <param name="inLata"> The in_lata </param>
        public TollFreeReader(string countryCode, string accountSid=null, int? areaCode=null, string contains=null, bool? smsEnabled=null, bool? mmsEnabled=null, bool? voiceEnabled=null, bool? excludeAllAddressRequired=null, bool? excludeLocalAddressRequired=null, bool? excludeForeignAddressRequired=null, bool? beta=null, Twilio.Types.PhoneNumber nearNumber=null, string nearLatLong=null, int? distance=null, string inPostalCode=null, string inRegion=null, string inRateCenter=null, string inLata=null) {
            this.excludeAllAddressRequired = excludeAllAddressRequired;
            this.nearNumber = nearNumber;
            this.inLata = inLata;
            this.excludeLocalAddressRequired = excludeLocalAddressRequired;
            this.areaCode = areaCode;
            this.contains = contains;
            this.inRateCenter = inRateCenter;
            this.smsEnabled = smsEnabled;
            this.inPostalCode = inPostalCode;
            this.beta = beta;
            this.inRegion = inRegion;
            this.accountSid = accountSid;
            this.excludeForeignAddressRequired = excludeForeignAddressRequired;
            this.mmsEnabled = mmsEnabled;
            this.distance = distance;
            this.nearLatLong = nearLatLong;
            this.voiceEnabled = voiceEnabled;
            this.countryCode = countryCode;
        }
    
        #if NET40
        /// <summary>
        /// Make the request to the Twilio API to perform the read
        /// </summary>
        ///
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> TollFreeResource ResourceSet </returns> 
        public override Task<ResourceSet<TollFreeResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/AvailablePhoneNumbers/" + this.countryCode + "/TollFree.json"
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
        public override ResourceSet<TollFreeResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (accountSid ?? client.GetAccountSid()) + "/AvailablePhoneNumbers/" + this.countryCode + "/TollFree.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<TollFreeResource>(this, client, page);
        }
    
        /// <summary>
        /// Retrieve the next page from the Twilio API
        /// </summary>
        ///
        /// <param name="nextPageUri"> URI from which to retrieve the next page </param>
        /// <param name="client"> ITwilioRestClient with which to make the request </param>
        /// <returns> Next Page </returns> 
        public override Page<TollFreeResource> NextPage(Page<TollFreeResource> page, ITwilioRestClient client) {
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
        protected Page<TollFreeResource> PageForRequest(ITwilioRestClient client, Request request) {
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
        private void AddQueryParams(Request request) {
            if (areaCode != null) {
                request.AddQueryParam("AreaCode", areaCode.ToString());
            }
            
            if (contains != null) {
                request.AddQueryParam("Contains", contains);
            }
            
            if (smsEnabled != null) {
                request.AddQueryParam("SmsEnabled", smsEnabled.ToString());
            }
            
            if (mmsEnabled != null) {
                request.AddQueryParam("MmsEnabled", mmsEnabled.ToString());
            }
            
            if (voiceEnabled != null) {
                request.AddQueryParam("VoiceEnabled", voiceEnabled.ToString());
            }
            
            if (excludeAllAddressRequired != null) {
                request.AddQueryParam("ExcludeAllAddressRequired", excludeAllAddressRequired.ToString());
            }
            
            if (excludeLocalAddressRequired != null) {
                request.AddQueryParam("ExcludeLocalAddressRequired", excludeLocalAddressRequired.ToString());
            }
            
            if (excludeForeignAddressRequired != null) {
                request.AddQueryParam("ExcludeForeignAddressRequired", excludeForeignAddressRequired.ToString());
            }
            
            if (beta != null) {
                request.AddQueryParam("Beta", beta.ToString());
            }
            
            if (nearNumber != null) {
                request.AddQueryParam("NearNumber", nearNumber.ToString());
            }
            
            if (nearLatLong != null) {
                request.AddQueryParam("NearLatLong", nearLatLong);
            }
            
            if (distance != null) {
                request.AddQueryParam("Distance", distance.ToString());
            }
            
            if (inPostalCode != null) {
                request.AddQueryParam("InPostalCode", inPostalCode);
            }
            
            if (inRegion != null) {
                request.AddQueryParam("InRegion", inRegion);
            }
            
            if (inRateCenter != null) {
                request.AddQueryParam("InRateCenter", inRateCenter);
            }
            
            if (inLata != null) {
                request.AddQueryParam("InLata", inLata);
            }
            
            request.AddQueryParam("PageSize", PageSize.ToString());
        }
    }
}