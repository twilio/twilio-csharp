using Twilio.Base;
using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;

#if NET40
using System.Threading.Tasks;
#endif

namespace Twilio.Rest.Api.V2010.Account.AvailablePhoneNumberCountry {

    public class MobileReader : Reader<MobileResource> {
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
    
        /**
         * Construct a new MobileReader.
         * 
         * @param countryCode The country_code
         */
        public MobileReader(string countryCode) {
            this.countryCode = countryCode;
        }
    
        /**
         * Construct a new MobileReader
         * 
         * @param accountSid The account_sid
         * @param countryCode The country_code
         */
        public MobileReader(string accountSid, string countryCode) {
            this.accountSid = accountSid;
            this.countryCode = countryCode;
        }
    
        /**
         * The area_code
         * 
         * @param areaCode The area_code
         * @return this
         */
        public MobileReader ByAreaCode(int? areaCode) {
            this.areaCode = areaCode;
            return this;
        }
    
        /**
         * The contains
         * 
         * @param contains The contains
         * @return this
         */
        public MobileReader ByContains(string contains) {
            this.contains = contains;
            return this;
        }
    
        /**
         * The sms_enabled
         * 
         * @param smsEnabled The sms_enabled
         * @return this
         */
        public MobileReader BySmsEnabled(bool? smsEnabled) {
            this.smsEnabled = smsEnabled;
            return this;
        }
    
        /**
         * The mms_enabled
         * 
         * @param mmsEnabled The mms_enabled
         * @return this
         */
        public MobileReader ByMmsEnabled(bool? mmsEnabled) {
            this.mmsEnabled = mmsEnabled;
            return this;
        }
    
        /**
         * The voice_enabled
         * 
         * @param voiceEnabled The voice_enabled
         * @return this
         */
        public MobileReader ByVoiceEnabled(bool? voiceEnabled) {
            this.voiceEnabled = voiceEnabled;
            return this;
        }
    
        /**
         * The exclude_all_address_required
         * 
         * @param excludeAllAddressRequired The exclude_all_address_required
         * @return this
         */
        public MobileReader ByExcludeAllAddressRequired(bool? excludeAllAddressRequired) {
            this.excludeAllAddressRequired = excludeAllAddressRequired;
            return this;
        }
    
        /**
         * The exclude_local_address_required
         * 
         * @param excludeLocalAddressRequired The exclude_local_address_required
         * @return this
         */
        public MobileReader ByExcludeLocalAddressRequired(bool? excludeLocalAddressRequired) {
            this.excludeLocalAddressRequired = excludeLocalAddressRequired;
            return this;
        }
    
        /**
         * The exclude_foreign_address_required
         * 
         * @param excludeForeignAddressRequired The exclude_foreign_address_required
         * @return this
         */
        public MobileReader ByExcludeForeignAddressRequired(bool? excludeForeignAddressRequired) {
            this.excludeForeignAddressRequired = excludeForeignAddressRequired;
            return this;
        }
    
        /**
         * The beta
         * 
         * @param beta The beta
         * @return this
         */
        public MobileReader ByBeta(bool? beta) {
            this.beta = beta;
            return this;
        }
    
        /**
         * The near_number
         * 
         * @param nearNumber The near_number
         * @return this
         */
        public MobileReader ByNearNumber(Twilio.Types.PhoneNumber nearNumber) {
            this.nearNumber = nearNumber;
            return this;
        }
    
        /**
         * The near_lat_long
         * 
         * @param nearLatLong The near_lat_long
         * @return this
         */
        public MobileReader ByNearLatLong(string nearLatLong) {
            this.nearLatLong = nearLatLong;
            return this;
        }
    
        /**
         * The distance
         * 
         * @param distance The distance
         * @return this
         */
        public MobileReader ByDistance(int? distance) {
            this.distance = distance;
            return this;
        }
    
        /**
         * The in_postal_code
         * 
         * @param inPostalCode The in_postal_code
         * @return this
         */
        public MobileReader ByInPostalCode(string inPostalCode) {
            this.inPostalCode = inPostalCode;
            return this;
        }
    
        /**
         * The in_region
         * 
         * @param inRegion The in_region
         * @return this
         */
        public MobileReader ByInRegion(string inRegion) {
            this.inRegion = inRegion;
            return this;
        }
    
        /**
         * The in_rate_center
         * 
         * @param inRateCenter The in_rate_center
         * @return this
         */
        public MobileReader ByInRateCenter(string inRateCenter) {
            this.inRateCenter = inRateCenter;
            return this;
        }
    
        /**
         * The in_lata
         * 
         * @param inLata The in_lata
         * @return this
         */
        public MobileReader ByInLata(string inLata) {
            this.inLata = inLata;
            return this;
        }
    
        #if NET40
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return MobileResource ResourceSet
         */
        public override Task<ResourceSet<MobileResource>> ReadAsync(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/AvailablePhoneNumbers/" + this.countryCode + "/Mobile.json"
            );
            AddQueryParams(request);
            
            var page = PageForRequest(client, request);
            
            return System.Threading.Tasks.Task.FromResult(new ResourceSet<MobileResource>(this, client, page));
        }
        #endif
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client ITwilioRestClient with which to make the request
         * @return MobileResource ResourceSet
         */
        public override ResourceSet<MobileResource> Read(ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                Domains.API,
                "/2010-04-01/Accounts/" + (this.accountSid != null ? this.accountSid : client.GetAccountSid()) + "/AvailablePhoneNumbers/" + this.countryCode + "/Mobile.json"
            );
            
            AddQueryParams(request);
            var page = PageForRequest(client, request);
            
            return new ResourceSet<MobileResource>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client ITwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<MobileResource> NextPage(Page<MobileResource> page, ITwilioRestClient client) {
            var request = new Request(
                HttpMethod.GET,
                page.GetNextPageUrl(
                    Domains.API
                )
            );
            
            return PageForRequest(client, request);
        }
    
        /**
         * Generate a Page of MobileResource Resources for a given request
         * 
         * @param client ITwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<MobileResource> PageForRequest(ITwilioRestClient client, Request request) {
            var response = client.Request(request);
            
            if (response == null) {
                throw new ApiConnectionException("MobileResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() < System.Net.HttpStatusCode.OK || response.GetStatusCode() > System.Net.HttpStatusCode.NoContent) {
                var restException = RestException.FromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    (restException.GetMessage() != null ? restException.GetMessage() : "Unable to read records, " + response.GetStatusCode()),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    (int)response.GetStatusCode(),
                    null
                );
            }
            
            return Page<MobileResource>.FromJson("available_phone_numbers", response.GetContent());
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
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