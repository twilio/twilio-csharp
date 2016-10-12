using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.AvailablePhoneNumberCountry {

    public class TollFreeReader : Reader<TollFreeResource> {
        private string accountSid;
        private string countryCode;
        private int? areaCode;
        private string contains;
        private bool? smsEnabled;
        private bool? mmsEnabled;
        private bool? voiceEnabled;
        private bool? excludeAllAddressRequired;
        private bool? excludeLocalAddressRequired;
        private bool? excludeForeignAddressRequired;
        private bool? beta;
        private Twilio.Types.PhoneNumber nearNumber;
        private string nearLatLong;
        private int? distance;
        private string inPostalCode;
        private string inRegion;
        private string inRateCenter;
        private string inLata;
    
        /// <summary>
        /// Construct a new TollFreeReader.
        /// </summary>
        ///
        /// <param name="countryCode"> The country_code </param>
        public TollFreeReader(string countryCode) {
            this.countryCode = countryCode;
        }
    
        /// <summary>
        /// Construct a new TollFreeReader
        /// </summary>
        ///
        /// <param name="accountSid"> The account_sid </param>
        /// <param name="countryCode"> The country_code </param>
        public TollFreeReader(string accountSid, string countryCode) {
            this.accountSid = accountSid;
            this.countryCode = countryCode;
        }
    
        /// <summary>
        /// The area_code
        /// </summary>
        ///
        /// <param name="areaCode"> The area_code </param>
        /// <returns> this </returns> 
        public TollFreeReader ByAreaCode(int? areaCode) {
            this.areaCode = areaCode;
            return this;
        }
    
        /// <summary>
        /// The contains
        /// </summary>
        ///
        /// <param name="contains"> The contains </param>
        /// <returns> this </returns> 
        public TollFreeReader ByContains(string contains) {
            this.contains = contains;
            return this;
        }
    
        /// <summary>
        /// The sms_enabled
        /// </summary>
        ///
        /// <param name="smsEnabled"> The sms_enabled </param>
        /// <returns> this </returns> 
        public TollFreeReader BySmsEnabled(bool? smsEnabled) {
            this.smsEnabled = smsEnabled;
            return this;
        }
    
        /// <summary>
        /// The mms_enabled
        /// </summary>
        ///
        /// <param name="mmsEnabled"> The mms_enabled </param>
        /// <returns> this </returns> 
        public TollFreeReader ByMmsEnabled(bool? mmsEnabled) {
            this.mmsEnabled = mmsEnabled;
            return this;
        }
    
        /// <summary>
        /// The voice_enabled
        /// </summary>
        ///
        /// <param name="voiceEnabled"> The voice_enabled </param>
        /// <returns> this </returns> 
        public TollFreeReader ByVoiceEnabled(bool? voiceEnabled) {
            this.voiceEnabled = voiceEnabled;
            return this;
        }
    
        /// <summary>
        /// The exclude_all_address_required
        /// </summary>
        ///
        /// <param name="excludeAllAddressRequired"> The exclude_all_address_required </param>
        /// <returns> this </returns> 
        public TollFreeReader ByExcludeAllAddressRequired(bool? excludeAllAddressRequired) {
            this.excludeAllAddressRequired = excludeAllAddressRequired;
            return this;
        }
    
        /// <summary>
        /// The exclude_local_address_required
        /// </summary>
        ///
        /// <param name="excludeLocalAddressRequired"> The exclude_local_address_required </param>
        /// <returns> this </returns> 
        public TollFreeReader ByExcludeLocalAddressRequired(bool? excludeLocalAddressRequired) {
            this.excludeLocalAddressRequired = excludeLocalAddressRequired;
            return this;
        }
    
        /// <summary>
        /// The exclude_foreign_address_required
        /// </summary>
        ///
        /// <param name="excludeForeignAddressRequired"> The exclude_foreign_address_required </param>
        /// <returns> this </returns> 
        public TollFreeReader ByExcludeForeignAddressRequired(bool? excludeForeignAddressRequired) {
            this.excludeForeignAddressRequired = excludeForeignAddressRequired;
            return this;
        }
    
        /// <summary>
        /// The beta
        /// </summary>
        ///
        /// <param name="beta"> The beta </param>
        /// <returns> this </returns> 
        public TollFreeReader ByBeta(bool? beta) {
            this.beta = beta;
            return this;
        }
    
        /// <summary>
        /// The near_number
        /// </summary>
        ///
        /// <param name="nearNumber"> The near_number </param>
        /// <returns> this </returns> 
        public TollFreeReader ByNearNumber(Twilio.Types.PhoneNumber nearNumber) {
            this.nearNumber = nearNumber;
            return this;
        }
    
        /// <summary>
        /// The near_lat_long
        /// </summary>
        ///
        /// <param name="nearLatLong"> The near_lat_long </param>
        /// <returns> this </returns> 
        public TollFreeReader ByNearLatLong(string nearLatLong) {
            this.nearLatLong = nearLatLong;
            return this;
        }
    
        /// <summary>
        /// The distance
        /// </summary>
        ///
        /// <param name="distance"> The distance </param>
        /// <returns> this </returns> 
        public TollFreeReader ByDistance(int? distance) {
            this.distance = distance;
            return this;
        }
    
        /// <summary>
        /// The in_postal_code
        /// </summary>
        ///
        /// <param name="inPostalCode"> The in_postal_code </param>
        /// <returns> this </returns> 
        public TollFreeReader ByInPostalCode(string inPostalCode) {
            this.inPostalCode = inPostalCode;
            return this;
        }
    
        /// <summary>
        /// The in_region
        /// </summary>
        ///
        /// <param name="inRegion"> The in_region </param>
        /// <returns> this </returns> 
        public TollFreeReader ByInRegion(string inRegion) {
            this.inRegion = inRegion;
            return this;
        }
    
        /// <summary>
        /// The in_rate_center
        /// </summary>
        ///
        /// <param name="inRateCenter"> The in_rate_center </param>
        /// <returns> this </returns> 
        public TollFreeReader ByInRateCenter(string inRateCenter) {
            this.inRateCenter = inRateCenter;
            return this;
        }
    
        /// <summary>
        /// The in_lata
        /// </summary>
        ///
        /// <param name="inLata"> The in_lata </param>
        /// <returns> this </returns> 
        public TollFreeReader ByInLata(string inLata) {
            this.inLata = inLata;
            return this;
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
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/AvailablePhoneNumbers/" + this.countryCode + "/TollFree.json"
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
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/AvailablePhoneNumbers/" + this.countryCode + "/TollFree.json"
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