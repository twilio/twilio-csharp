using Twilio.Clients.TwilioRestClient;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Resources.Api.V2010.account.available_phone_number_country.TollFree;
using com.twilio.sdk.readers.Reader;
using com.twilio.sdk.resources.Page;
using com.twilio.sdk.resources.ResourceSet;

namespace Twilio.Readers.Api.V2010.Account.Availablephonenumbercountry {

    public class TollFreeReader : Reader<TollFree> {
        private String accountSid;
        private String countryCode;
        private Integer areaCode;
        private String contains;
        private Boolean smsEnabled;
        private Boolean mmsEnabled;
        private Boolean voiceEnabled;
        private Boolean excludeAllAddressRequired;
        private Boolean excludeLocalAddressRequired;
        private Boolean excludeForeignAddressRequired;
        private Boolean beta;
    
        /**
         * Construct a new TollFreeReader
         * 
         * @param accountSid The account_sid
         * @param countryCode The country_code
         */
        public TollFreeReader(String accountSid, String countryCode) {
            this.accountSid = accountSid;
            this.countryCode = countryCode;
        }
    
        /**
         * The area_code
         * 
         * @param areaCode The area_code
         * @return this
         */
        public TollFreeReader byAreaCode(Integer areaCode) {
            this.areaCode = areaCode;
            return this;
        }
    
        /**
         * The contains
         * 
         * @param contains The contains
         * @return this
         */
        public TollFreeReader byContains(String contains) {
            this.contains = contains;
            return this;
        }
    
        /**
         * The sms_enabled
         * 
         * @param smsEnabled The sms_enabled
         * @return this
         */
        public TollFreeReader bySmsEnabled(Boolean smsEnabled) {
            this.smsEnabled = smsEnabled;
            return this;
        }
    
        /**
         * The mms_enabled
         * 
         * @param mmsEnabled The mms_enabled
         * @return this
         */
        public TollFreeReader byMmsEnabled(Boolean mmsEnabled) {
            this.mmsEnabled = mmsEnabled;
            return this;
        }
    
        /**
         * The voice_enabled
         * 
         * @param voiceEnabled The voice_enabled
         * @return this
         */
        public TollFreeReader byVoiceEnabled(Boolean voiceEnabled) {
            this.voiceEnabled = voiceEnabled;
            return this;
        }
    
        /**
         * The exclude_all_address_required
         * 
         * @param excludeAllAddressRequired The exclude_all_address_required
         * @return this
         */
        public TollFreeReader byExcludeAllAddressRequired(Boolean excludeAllAddressRequired) {
            this.excludeAllAddressRequired = excludeAllAddressRequired;
            return this;
        }
    
        /**
         * The exclude_local_address_required
         * 
         * @param excludeLocalAddressRequired The exclude_local_address_required
         * @return this
         */
        public TollFreeReader byExcludeLocalAddressRequired(Boolean excludeLocalAddressRequired) {
            this.excludeLocalAddressRequired = excludeLocalAddressRequired;
            return this;
        }
    
        /**
         * The exclude_foreign_address_required
         * 
         * @param excludeForeignAddressRequired The exclude_foreign_address_required
         * @return this
         */
        public TollFreeReader byExcludeForeignAddressRequired(Boolean excludeForeignAddressRequired) {
            this.excludeForeignAddressRequired = excludeForeignAddressRequired;
            return this;
        }
    
        /**
         * The beta
         * 
         * @param beta The beta
         * @return this
         */
        public TollFreeReader byBeta(Boolean beta) {
            this.beta = beta;
            return this;
        }
    
        /**
         * Make the request to the Twilio API to perform the read
         * 
         * @param client TwilioRestClient with which to make the request
         * @return TollFree ResourceSet
         */
        [Override]
        public ResourceSet<TollFree> execute(TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                TwilioRestClient.Domains.API,
                "/2010-04-01/Accounts/" + this.accountSid + "/AvailablePhoneNumbers/" + this.countryCode + "/TollFree.json",
                client.getAccountSid()
            );
            
            addQueryParams(request);
            
            Page<TollFree> page = pageForRequest(client, request);
            
            return new ResourceSet<>(this, client, page);
        }
    
        /**
         * Retrieve the next page from the Twilio API
         * 
         * @param nextPageUri URI from which to retrieve the next page
         * @param client TwilioRestClient with which to make the request
         * @return Next Page
         */
        [Override]
        public Page<TollFree> nextPage(final String nextPageUri, final TwilioRestClient client) {
            Request request = new Request(
                HttpMethod.GET,
                nextPageUri,
                client.getAccountSid()
            );
            return pageForRequest(client, request);
        }
    
        /**
         * Generate a Page of TollFree Resources for a given request
         * 
         * @param client TwilioRestClient with which to make the request
         * @param request Request to generate a page for
         * @return Page for the Request
         */
        protected Page<TollFree> pageForRequest(final TwilioRestClient client, final Request request) {
            Response response = client.request(request);
            
            if (response == null) {
                throw new ApiConnectionException("TollFree read failed: Unable to connect to server");
            } else if (response.getStatusCode() != TwilioRestClient.HTTP_STATUS_CODE_OK) {
                RestException restException = RestException.fromJson(response.getStream(), client.getObjectMapper());
                if (restException == null)
                    throw new ApiException("Server Error, no content");
                throw new ApiException(
                    restException.getMessage(),
                    restException.getCode(),
                    restException.getMoreInfo(),
                    restException.getStatus(),
                    null
                );
            }
            
            Page<TollFree> result = new Page<>();
            result.deserialize("available_phone_numbers", response.getContent(), TollFree.class, client.getObjectMapper());
            
            return result;
        }
    
        /**
         * Add the requested query string arguments to the Request
         * 
         * @param request Request to add query string arguments to
         */
        private void addQueryParams(final Request request) {
            if (areaCode != null) {
                request.addQueryParam("AreaCode", areaCode.toString());
            }
            
            if (contains != null) {
                request.addQueryParam("Contains", contains);
            }
            
            if (smsEnabled != null) {
                request.addQueryParam("SmsEnabled", smsEnabled.toString());
            }
            
            if (mmsEnabled != null) {
                request.addQueryParam("MmsEnabled", mmsEnabled.toString());
            }
            
            if (voiceEnabled != null) {
                request.addQueryParam("VoiceEnabled", voiceEnabled.toString());
            }
            
            if (excludeAllAddressRequired != null) {
                request.addQueryParam("ExcludeAllAddressRequired", excludeAllAddressRequired.toString());
            }
            
            if (excludeLocalAddressRequired != null) {
                request.addQueryParam("ExcludeLocalAddressRequired", excludeLocalAddressRequired.toString());
            }
            
            if (excludeForeignAddressRequired != null) {
                request.addQueryParam("ExcludeForeignAddressRequired", excludeForeignAddressRequired.toString());
            }
            
            if (beta != null) {
                request.addQueryParam("Beta", beta.toString());
            }
            
            request.addQueryParam("PageSize", Integer.toString(getPageSize()));
        }
    }
}