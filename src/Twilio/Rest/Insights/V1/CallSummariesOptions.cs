/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Insights
 * This is the public Twilio REST API.
 *
 * NOTE: This class is auto generated by OpenAPI Generator.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;




namespace Twilio.Rest.Insights.V1
{
    /// <summary> Get a list of Call Summaries. </summary>
    public class ReadCallSummariesOptions : ReadOptions<CallSummariesResource>
    {
    
        ///<summary> A calling party. Could be an E.164 number, a SIP URI, or a Twilio Client registered name. </summary> 
        public string From { get; set; }

        ///<summary> A called party. Could be an E.164 number, a SIP URI, or a Twilio Client registered name. </summary> 
        public string To { get; set; }

        ///<summary> An origination carrier. </summary> 
        public string FromCarrier { get; set; }

        ///<summary> A destination carrier. </summary> 
        public string ToCarrier { get; set; }

        ///<summary> A source country code based on phone number in From. </summary> 
        public string FromCountryCode { get; set; }

        ///<summary> A destination country code. Based on phone number in To. </summary> 
        public string ToCountryCode { get; set; }

        ///<summary> A boolean flag indicating whether or not the caller was verified using SHAKEN/STIR.One of 'true' or 'false'. </summary> 
        public bool? VerifiedCaller { get; set; }

        ///<summary> A boolean flag indicating the presence of one or more [Voice Insights Call Tags](https://www.twilio.com/docs/voice/voice-insights/api/call/details-call-tags). </summary> 
        public bool? HasTag { get; set; }

        ///<summary> A Start time of the calls. xm (x minutes), xh (x hours), xd (x days), 1w, 30m, 3d, 4w or datetime-ISO. Defaults to 4h. </summary> 
        public string StartTime { get; set; }

        ///<summary> An End Time of the calls. xm (x minutes), xh (x hours), xd (x days), 1w, 30m, 3d, 4w or datetime-ISO. Defaults to 0m. </summary> 
        public string EndTime { get; set; }

        ///<summary> A Call Type of the calls. One of `carrier`, `sip`, `trunking` or `client`. </summary> 
        public string CallType { get; set; }

        ///<summary> A Call State of the calls. One of `ringing`, `completed`, `busy`, `fail`, `noanswer`, `canceled`, `answered`, `undialed`. </summary> 
        public string CallState { get; set; }

        ///<summary> A Direction of the calls. One of `outbound_api`, `outbound_dial`, `inbound`, `trunking_originating`, `trunking_terminating`. </summary> 
        public string Direction { get; set; }

        ///<summary> A Processing State of the Call Summaries. One of `completed`, `partial` or `all`. </summary> 
        public CallSummariesResource.ProcessingStateRequestEnum ProcessingState { get; set; }

        ///<summary> A Sort By criterion for the returned list of Call Summaries. One of `start_time` or `end_time`. </summary> 
        public CallSummariesResource.SortByEnum SortBy { get; set; }

        ///<summary> A unique SID identifier of a Subaccount. </summary> 
        public string Subaccount { get; set; }

        ///<summary> A boolean flag indicating an abnormal session where the last SIP response was not 200 OK. </summary> 
        public bool? AbnormalSession { get; set; }

        ///<summary> An Answered By value for the calls based on `Answering Machine Detection (AMD)`. One of `unknown`, `machine_start`, `machine_end_beep`, `machine_end_silence`, `machine_end_other`, `human` or `fax`. </summary> 
        public CallSummariesResource.AnsweredByEnum AnsweredBy { get; set; }

        ///<summary> Either machine or human. </summary> 
        public string AnsweredByAnnotation { get; set; }

        ///<summary> A Connectivity Issue with the calls. One of `no_connectivity_issue`, `invalid_number`, `caller_id`, `dropped_call`, or `number_reachability`. </summary> 
        public string ConnectivityIssueAnnotation { get; set; }

        ///<summary> A subjective Quality Issue with the calls. One of `no_quality_issue`, `low_volume`, `choppy_robotic`, `echo`, `dtmf`, `latency`, `owa`, `static_noise`. </summary> 
        public string QualityIssueAnnotation { get; set; }

        ///<summary> A boolean flag indicating spam calls. </summary> 
        public bool? SpamAnnotation { get; set; }

        ///<summary> A Call Score of the calls. Use a range of 1-5 to indicate the call experience score, with the following mapping as a reference for the rated call [5: Excellent, 4: Good, 3 : Fair, 2 : Poor, 1: Bad]. </summary> 
        public string CallScoreAnnotation { get; set; }

        ///<summary> A boolean flag indicating whether or not the calls were branded using Twilio Branded Calls. One of 'true' or 'false' </summary> 
        public bool? BrandedEnabled { get; set; }

        ///<summary> A boolean flag indicating whether or not the phone number had voice integrity enabled.One of 'true' or 'false' </summary> 
        public bool? VoiceIntegrityEnabled { get; set; }

        ///<summary> A unique SID identifier of the Branded Call. </summary> 
        public string BrandedBundleSid { get; set; }

        ///<summary> A unique SID identifier of the Voice Integrity Profile. </summary> 
        public string VoiceIntegrityBundleSid { get; set; }

        ///<summary> A Voice Integrity Use Case . Is of type enum. One of 'abandoned_cart', 'appointment_reminders', 'appointment_scheduling', 'asset_management', 'automated_support', 'call_tracking', 'click_to_call', 'contact_tracing', 'contactless_delivery', 'customer_support', 'dating/social', 'delivery_notifications', 'distance_learning', 'emergency_notifications', 'employee_notifications', 'exam_proctoring', 'field_notifications', 'first_responder', 'fraud_alerts', 'group_messaging', 'identify_&_verification', 'intelligent_routing', 'lead_alerts', 'lead_distribution', 'lead_generation', 'lead_management', 'lead_nurturing', 'marketing_events', 'mass_alerts', 'meetings/collaboration', 'order_notifications', 'outbound_dialer', 'pharmacy', 'phone_system', 'purchase_confirmation', 'remote_appointments', 'rewards_program', 'self-service', 'service_alerts', 'shift_management', 'survey/research', 'telehealth', 'telemarketing', 'therapy_(individual+group)'. </summary> 
        public string VoiceIntegrityUseCase { get; set; }

        ///<summary> A Business Identity of the calls. Is of type enum. One of 'direct_customer', 'isv_reseller_or_partner'.  </summary> 
        public string BusinessProfileIdentity { get; set; }

        ///<summary> A Business Industry of the calls. Is of type enum. One of 'automotive', 'agriculture', 'banking', 'consumer', 'construction', 'education', 'engineering', 'energy', 'oil_and_gas', 'fast_moving_consumer_goods', 'financial', 'fintech', 'food_and_beverage', 'government', 'healthcare', 'hospitality', 'insurance', 'legal', 'manufacturing', 'media', 'online', 'professional_services', 'raw_materials', 'real_estate', 'religion', 'retail', 'jewelry', 'technology', 'telecommunications', 'transportation', 'travel', 'electronics', 'not_for_profit'  </summary> 
        public string BusinessProfileIndustry { get; set; }

        ///<summary> A unique SID identifier of the Business Profile. </summary> 
        public string BusinessProfileBundleSid { get; set; }

        ///<summary> A Business Profile Type of the calls. Is of type enum. One of 'primary', 'secondary'. </summary> 
        public string BusinessProfileType { get; set; }




        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (From != null)
            {
                p.Add(new KeyValuePair<string, string>("From", From));
            }
            if (To != null)
            {
                p.Add(new KeyValuePair<string, string>("To", To));
            }
            if (FromCarrier != null)
            {
                p.Add(new KeyValuePair<string, string>("FromCarrier", FromCarrier));
            }
            if (ToCarrier != null)
            {
                p.Add(new KeyValuePair<string, string>("ToCarrier", ToCarrier));
            }
            if (FromCountryCode != null)
            {
                p.Add(new KeyValuePair<string, string>("FromCountryCode", FromCountryCode));
            }
            if (ToCountryCode != null)
            {
                p.Add(new KeyValuePair<string, string>("ToCountryCode", ToCountryCode));
            }
            if (VerifiedCaller != null)
            {
                p.Add(new KeyValuePair<string, string>("VerifiedCaller", VerifiedCaller.Value.ToString().ToLower()));
            }
            if (HasTag != null)
            {
                p.Add(new KeyValuePair<string, string>("HasTag", HasTag.Value.ToString().ToLower()));
            }
            if (StartTime != null)
            {
                p.Add(new KeyValuePair<string, string>("StartTime", StartTime));
            }
            if (EndTime != null)
            {
                p.Add(new KeyValuePair<string, string>("EndTime", EndTime));
            }
            if (CallType != null)
            {
                p.Add(new KeyValuePair<string, string>("CallType", CallType));
            }
            if (CallState != null)
            {
                p.Add(new KeyValuePair<string, string>("CallState", CallState));
            }
            if (Direction != null)
            {
                p.Add(new KeyValuePair<string, string>("Direction", Direction));
            }
            if (ProcessingState != null)
            {
                p.Add(new KeyValuePair<string, string>("ProcessingState", ProcessingState.ToString()));
            }
            if (SortBy != null)
            {
                p.Add(new KeyValuePair<string, string>("SortBy", SortBy.ToString()));
            }
            if (Subaccount != null)
            {
                p.Add(new KeyValuePair<string, string>("Subaccount", Subaccount));
            }
            if (AbnormalSession != null)
            {
                p.Add(new KeyValuePair<string, string>("AbnormalSession", AbnormalSession.Value.ToString().ToLower()));
            }
            if (AnsweredBy != null)
            {
                p.Add(new KeyValuePair<string, string>("AnsweredBy", AnsweredBy.ToString()));
            }
            if (AnsweredByAnnotation != null)
            {
                p.Add(new KeyValuePair<string, string>("AnsweredByAnnotation", AnsweredByAnnotation));
            }
            if (ConnectivityIssueAnnotation != null)
            {
                p.Add(new KeyValuePair<string, string>("ConnectivityIssueAnnotation", ConnectivityIssueAnnotation));
            }
            if (QualityIssueAnnotation != null)
            {
                p.Add(new KeyValuePair<string, string>("QualityIssueAnnotation", QualityIssueAnnotation));
            }
            if (SpamAnnotation != null)
            {
                p.Add(new KeyValuePair<string, string>("SpamAnnotation", SpamAnnotation.Value.ToString().ToLower()));
            }
            if (CallScoreAnnotation != null)
            {
                p.Add(new KeyValuePair<string, string>("CallScoreAnnotation", CallScoreAnnotation));
            }
            if (BrandedEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("BrandedEnabled", BrandedEnabled.Value.ToString().ToLower()));
            }
            if (VoiceIntegrityEnabled != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceIntegrityEnabled", VoiceIntegrityEnabled.Value.ToString().ToLower()));
            }
            if (BrandedBundleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("BrandedBundleSid", BrandedBundleSid));
            }
            if (VoiceIntegrityBundleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceIntegrityBundleSid", VoiceIntegrityBundleSid));
            }
            if (VoiceIntegrityUseCase != null)
            {
                p.Add(new KeyValuePair<string, string>("VoiceIntegrityUseCase", VoiceIntegrityUseCase));
            }
            if (BusinessProfileIdentity != null)
            {
                p.Add(new KeyValuePair<string, string>("BusinessProfileIdentity", BusinessProfileIdentity));
            }
            if (BusinessProfileIndustry != null)
            {
                p.Add(new KeyValuePair<string, string>("BusinessProfileIndustry", BusinessProfileIndustry));
            }
            if (BusinessProfileBundleSid != null)
            {
                p.Add(new KeyValuePair<string, string>("BusinessProfileBundleSid", BusinessProfileBundleSid));
            }
            if (BusinessProfileType != null)
            {
                p.Add(new KeyValuePair<string, string>("BusinessProfileType", BusinessProfileType));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }

    

    }

}

