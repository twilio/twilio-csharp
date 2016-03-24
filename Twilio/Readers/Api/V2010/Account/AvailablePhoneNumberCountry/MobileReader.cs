using Twilio.Clients;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Readers;
using Twilio.Resources.Api.V2010.Account.AvailablePhoneNumberCountry;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Api.V2010.Account.Availablephonenumbercountry {

    public class MobileReader : Reader<MobileResource> {
        private string accountSid;
        private string countryCode;
        private int areaCode;
        private string contains;
        private bool smsEnabled;
        private bool mmsEnabled;
        private bool voiceEnabled;
        private bool excludeAllAddressRequired;
        private bool excludeLocalAddressRequired;
        private bool excludeForeignAddressRequired;
        private bool beta;
    
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
        public MobileReader byAreaCode(int areaCode) {
            this.areaCode = areaCode;
            return this;
        }
    
        /**
         * The contains
         * 
         * @param contains The contains
         * @return this
         */
        public MobileReader byContains(string contains) {
            this.contains = contains;
            return this;
        }
    
        /**
         * The sms_enabled
         * 
         * @param smsEnabled The sms_enabled
         * @return this
         */
        public MobileReader bySmsEnabled(bool smsEnabled) {
            this.smsEnabled = smsEnabled;
            return this;
        }
    
        /**
         * The mms_enabled
         * 
         * @param mmsEnabled The mms_enabled
         * @return this
         */
        public MobileReader byMmsEnabled(bool mmsEnabled) {
            this.mmsEnabled = mmsEnabled;
            return this;
        }
    
        /**
         * The voice_enabled
         * 
         * @param voiceEnabled The voice_enabled
         * @return this
         */
        public MobileReader byVoiceEnabled(bool voiceEnabled) {
            this.voiceEnabled = voiceEnabled;
            return this;
        }
    
        /**
         * The exclude_all_address_required
         * 
         * @param excludeAllAddressRequired The exclude_all_address_required
         * @return this
         */
        public MobileReader byExcludeAllAddressRequired(bool excludeAllAddressRequired) {
            this.excludeAllAddressRequired = excludeAllAddressRequired;
            return this;
        }
    
        /**
         * The exclude_local_address_required
         * 
         * @param excludeLocalAddressRequired The exclude_local_address_required
         * @return this
         */
        public MobileReader byExcludeLocalAddressRequired(bool excludeLocalAddressRequired) {
            this.excludeLocalAddressRequired = excludeLocalAddressRequired;
            return this;
        }
    
        /**
         * The exclude_foreign_address_required
         * 
         * @param excludeForeignAddressRequired The exclude_foreign_address_required
         * @return this
         */
        public MobileReader byExcludeForeignAddressRequired(bool excludeForeignAddressRequired) {
            this.excludeForeignAddressRequired = excludeForeignAddressRequired;
            return this;
        }
    
        /**
         * The beta
         * 
         * @param beta The beta
         * @return this
         */
        public MobileReader byBeta(bool beta) {
            this.beta = beta;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return MobileResource ResourceSet
         */
        public override ResourceSet<MobileResource> execute(TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/AvailablePhoneNumbers/" + this.countryCode + "/Mobile.json"
            );
            
            addQueryParams(request);
            
            Page<MobileResource> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        public override Page<MobileResource> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                System.Net.Http.HttpMethod.Get,
                nextPageUri
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of MobileResource Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<MobileResource> pageForRequest(TwilioRestClient client, Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("MobileResource read failed: Unable to connect to server");
            } else if (response.GetStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.GetContent());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.GetMessage(),
                    restException.GetCode(),
                    restException.GetMoreInfo(),
                    restException.GetStatus(),
                    null
                );
            }
            
            Page<MobileResource> result = new Page<>();
            result.deserialize("available_phone_numbers", response.GetContent(), MobileResource.class, client.getObjectMapper());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void addQueryParams(Request request) {
            if (areaCode != null) {
                request.addQueryParam("AreaCode", areaCode.ToString());
            }
            
            if (contains != null) {
                request.addQueryParam("Contains", contains);
            }
            
            if (smsEnabled != null) {
                request.addQueryParam("SmsEnabled", smsEnabled.ToString());
            }
            
            if (mmsEnabled != null) {
                request.addQueryParam("MmsEnabled", mmsEnabled.ToString());
            }
            
            if (voiceEnabled != null) {
                request.addQueryParam("VoiceEnabled", voiceEnabled.ToString());
            }
            
            if (excludeAllAddressRequired != null) {
                request.addQueryParam("ExcludeAllAddressRequired", excludeAllAddressRequired.ToString());
            }
            
            if (excludeLocalAddressRequired != null) {
                request.addQueryParam("ExcludeLocalAddressRequired", excludeLocalAddressRequired.ToString());
            }
            
            if (excludeForeignAddressRequired != null) {
                request.addQueryParam("ExcludeForeignAddressRequired", excludeForeignAddressRequired.ToString());
            }
            
            if (beta != null) {
                request.addQueryParam("Beta", beta.ToString());
            }
            
            request.addQueryParam("PageSize", Integer.toString(getPageSize()));
        }
    }
}