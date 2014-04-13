using Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    public partial class TwilioRestClient
    {
        private void AddNumberSearchParameters(AvailablePhoneNumberListRequest options, RestRequest request)
        {
            if (options.AreaCode.HasValue()) request.AddParameter("AreaCode", options.AreaCode);
            if (options.Contains.HasValue()) request.AddParameter("Contains", options.Contains);
            if (options.Distance.HasValue) request.AddParameter("Distance", options.Distance);
            if (options.InLata.HasValue()) request.AddParameter("InLata", options.InLata);
            if (options.InPostalCode.HasValue()) request.AddParameter("InPostalCode", options.InPostalCode);
            if (options.InRateCenter.HasValue()) request.AddParameter("InRateCenter", options.InRateCenter);
            if (options.InRegion.HasValue()) request.AddParameter("InRegion", options.InRegion);
            if (options.NearLatLong.HasValue()) request.AddParameter("NearLatLong", options.NearLatLong);
            if (options.NearNumber.HasValue()) request.AddParameter("NearNumber", options.NearNumber);

            if (options.SmsEnabled.HasValue) request.AddParameter("SmsEnabled", options.SmsEnabled.Value);
            if (options.VoiceEnabled.HasValue) request.AddParameter("VoiceEnabled", options.VoiceEnabled.Value);
            if (options.MmsEnabled.HasValue) request.AddParameter("MmsEnabled", options.MmsEnabled.Value);
        }

        private static void AddCallOptions(CallOptions options, RestRequest request)
        {
            request.AddParameter("From", options.From);
            request.AddParameter("To", options.To);

            if (options.ApplicationSid.HasValue())
            {
                request.AddParameter("ApplicationSid", options.ApplicationSid);
            }
            else
            {
                request.AddParameter("Url", options.Url);
            }

            if (options.StatusCallback.HasValue()) request.AddParameter("StatusCallback", options.StatusCallback);
            if (options.StatusCallbackMethod.HasValue()) request.AddParameter("StatusCallbackMethod", options.StatusCallbackMethod);
            if (options.FallbackUrl.HasValue()) request.AddParameter("FallbackUrl", options.FallbackUrl);
            if (options.FallbackMethod.HasValue()) request.AddParameter("FallbackMethod", options.FallbackMethod);
            if (options.Method.HasValue()) request.AddParameter("Method", options.Method);
            if (options.SendDigits.HasValue()) request.AddParameter("SendDigits", options.SendDigits);
            if (options.IfMachine.HasValue()) request.AddParameter("IfMachine", options.IfMachine);
            if (options.Timeout.HasValue) request.AddParameter("Timeout", options.Timeout.Value);
            if (options.Record) request.AddParameter("Record", "true");
            if (options.SipAuthUsername.HasValue()) request.AddParameter("SipAuthUsername", options.SipAuthUsername);
            if (options.SipAuthPassword.HasValue()) request.AddParameter("SipAuthPassword", options.SipAuthPassword);
        }

        private void AddCallListOptions(CallListRequest options, RestRequest request)
        {
            if (options.From.HasValue()) request.AddParameter("From", options.From);
            if (options.To.HasValue()) request.AddParameter("To", options.To);
            if (options.Status.HasValue()) request.AddParameter("Status", options.Status);
            //			if (options.StartTime.HasValue) request.AddParameter("StartTime", options.StartTime.Value.ToString("yyyy-MM-dd"));
            //			if (options.EndTime.HasValue) request.AddParameter("EndTime", options.EndTime.Value.ToString("yyyy-MM-dd"));

            var startTimeParameterName = GetParameterNameWithEquality(options.StartTimeComparison, "StartTime");
            var endTimeParameterName = GetParameterNameWithEquality(options.EndTimeComparison, "EndTime");

            if (options.StartTime.HasValue) request.AddParameter(startTimeParameterName, options.StartTime.Value.ToString("yyyy-MM-dd"));
            if (options.EndTime.HasValue) request.AddParameter(endTimeParameterName, options.EndTime.Value.ToString("yyyy-MM-dd"));

            if (options.Count.HasValue) request.AddParameter("PageSize", options.Count.Value);
            if (options.PageNumber.HasValue) request.AddParameter("Page", options.PageNumber.Value);

            if (options.ParentCallSid.HasValue()) request.AddParameter("ParentCallSid", options.ParentCallSid);
        }

        private void AddConferenceListOptions(ConferenceListRequest options, RestRequest request)
        {
            if (options.Status.HasValue()) request.AddParameter("Status", options.Status);
            if (options.FriendlyName.HasValue()) request.AddParameter("FriendlyName", options.FriendlyName);

            var dateCreatedParameterName = GetParameterNameWithEquality(options.DateCreatedComparison, "DateCreated");
            var dateUpdatedParameterName = GetParameterNameWithEquality(options.DateUpdatedComparison, "DateUpdated");

            if (options.DateCreated.HasValue) request.AddParameter(dateCreatedParameterName, options.DateCreated.Value.ToString("yyyy-MM-dd"));
            if (options.DateUpdated.HasValue) request.AddParameter(dateUpdatedParameterName, options.DateUpdated.Value.ToString("yyyy-MM-dd"));

            if (options.Count.HasValue) request.AddParameter("PageSize", options.Count.Value);
            if (options.PageNumber.HasValue) request.AddParameter("Page", options.PageNumber.Value);
        }

        private void AddSmsOptionsToRequest(RestRequest request, PhoneNumberOptions options)
        {
            // some check for null. in those cases an empty string is a valid value (to remove a URL assignment)
            if (options.SmsApplicationSid != null) request.AddParameter("SmsApplicationSid", options.SmsApplicationSid);
            if (options.SmsUrl != null) request.AddParameter("SmsUrl", options.SmsUrl);
            if (options.SmsMethod.HasValue()) request.AddParameter("SmsMethod", options.SmsMethod.ToString());
            if (options.SmsFallbackUrl != null) request.AddParameter("SmsFallbackUrl", options.SmsFallbackUrl);
            if (options.SmsFallbackMethod.HasValue()) request.AddParameter("SmsFallbackMethod", options.SmsFallbackMethod.ToString());
        }

        private void AddPhoneNumberOptionsToRequest(RestRequest request, PhoneNumberOptions options)
        {
            if (options.AccountSid.HasValue())
            {
                request.AddParameter("AccountSid", options.AccountSid);
            }

            if (options.FriendlyName.HasValue())
            {
                Validate.IsValidLength(options.FriendlyName, 64);
                request.AddParameter("FriendlyName", options.FriendlyName);
            }
            // some check for null. in those cases an empty string is a valid value (to remove a URL assignment)
            if (options.VoiceApplicationSid != null) request.AddParameter("VoiceApplicationSid", options.VoiceApplicationSid);

            if (options.VoiceUrl != null) request.AddParameter("VoiceUrl", options.VoiceUrl);
            if (options.VoiceMethod.HasValue()) request.AddParameter("VoiceMethod", options.VoiceMethod.ToString());
            if (options.VoiceFallbackUrl != null) request.AddParameter("VoiceFallbackUrl", options.VoiceFallbackUrl);
            if (options.VoiceFallbackMethod.HasValue()) request.AddParameter("VoiceFallbackMethod", options.VoiceFallbackMethod.ToString());
            if (options.VoiceCallerIdLookup.HasValue) request.AddParameter("VoiceCallerIdLookup", options.VoiceCallerIdLookup.Value);
            if (options.StatusCallback.HasValue()) request.AddParameter("StatusCallback", options.StatusCallback);
            if (options.StatusCallbackMethod.HasValue()) request.AddParameter("StatusCallbackMethod", options.StatusCallbackMethod.ToString());
        }

        private void AddMediaListOptions(MediaListRequest options, RestRequest request)
        {
            if (options.ParentSid.HasValue()) request.AddParameter("ParentSid", options.ParentSid);
            // Construct the date filter
            if (options.DateCreated.HasValue)
            {
                var dateCreatedParameterName = GetParameterNameWithEquality(options.DateCreatedComparison, "DateCreated");
                request.AddParameter(dateCreatedParameterName, options.DateCreated.Value.ToString("yyyy-MM-dd"));
            }

            // Paging options
            if (options.PageNumber.HasValue) request.AddParameter("Page", options.PageNumber.Value);
            if (options.Count.HasValue) request.AddParameter("PageSize", options.Count.Value);
        }

        private void AddMessageListOptions(MessageListRequest options, RestRequest request)
        {
            if (options.To.HasValue()) request.AddParameter("To", options.To);
            if (options.From.HasValue()) request.AddParameter("From", options.From);

            // Construct the date filter
            if (options.DateSent.HasValue)
            {
                var dateSentParameterName = GetParameterNameWithEquality(options.DateSentComparison, "DateSent");
                request.AddParameter(dateSentParameterName, options.DateSent.Value.ToString("yyyy-MM-dd"));
            }

            // Paging options
            if (options.PageNumber.HasValue) request.AddParameter("Page", options.PageNumber.Value);
            if (options.Count.HasValue) request.AddParameter("PageSize", options.Count.Value);
        }

        private static void AddDomainOptions(DomainOptions options, RestRequest request)
        {
            if (options.DomainName.HasValue()) request.AddParameter("DomainName", options.DomainName);

            if (options.AuthType.HasValue()) request.AddParameter("AuthType", options.AuthType);
            if (options.FriendlyName.HasValue()) request.AddParameter("FriendlyName", options.FriendlyName);
            if (options.VoiceFallbackMethod.HasValue()) request.AddParameter("VoiceFallbackMethod", options.VoiceFallbackMethod);
            if (options.VoiceFallbackUrl.HasValue()) request.AddParameter("VoiceFallbackUrl", options.VoiceFallbackUrl);
            if (options.VoiceMethod.HasValue()) request.AddParameter("VoiceMethod", options.VoiceMethod);
            if (options.VoiceStatusCallbackMethod.HasValue()) request.AddParameter("VoiceStatusCallbackMethod", options.VoiceStatusCallbackMethod);
            if (options.VoiceStatusCallbackUrl.HasValue()) request.AddParameter("VoiceStatusCallbackUrl", options.VoiceStatusCallbackUrl);
            if (options.VoiceUrl.HasValue()) request.AddParameter("VoiceUrl", options.VoiceUrl);
        }
    }
}
