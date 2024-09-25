/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Messaging
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




namespace Twilio.Rest.Messaging.V1
{

    /// <summary> create </summary>
    public class CreateServiceOptions : IOptions<ServiceResource>
    {
        
        ///<summary> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </summary> 
        public string FriendlyName { get; }

        ///<summary> The URL we call using `inbound_method` when a message is received by any phone number or short code in the Service. When this property is `null`, receiving inbound messages is disabled. All messages sent to the Twilio phone number or short code will not be logged and received on the Account. If the `use_inbound_webhook_on_number` field is enabled then the webhook url defined on the phone number will override the `inbound_request_url` defined for the Messaging Service. </summary> 
        public Uri InboundRequestUrl { get; set; }

        ///<summary> The HTTP method we should use to call `inbound_request_url`. Can be `GET` or `POST` and the default is `POST`. </summary> 
        public Twilio.Http.HttpMethod InboundMethod { get; set; }

        ///<summary> The URL that we call using `fallback_method` if an error occurs while retrieving or executing the TwiML from the Inbound Request URL. If the `use_inbound_webhook_on_number` field is enabled then the webhook url defined on the phone number will override the `fallback_url` defined for the Messaging Service. </summary> 
        public Uri FallbackUrl { get; set; }

        ///<summary> The HTTP method we should use to call `fallback_url`. Can be: `GET` or `POST`. </summary> 
        public Twilio.Http.HttpMethod FallbackMethod { get; set; }

        ///<summary> The URL we should call to [pass status updates](https://www.twilio.com/docs/sms/api/message-resource#message-status-values) about message delivery. </summary> 
        public Uri StatusCallback { get; set; }

        ///<summary> Whether to enable [Sticky Sender](https://www.twilio.com/docs/messaging/services#sticky-sender) on the Service instance. </summary> 
        public bool? StickySender { get; set; }

        ///<summary> Whether to enable the [MMS Converter](https://www.twilio.com/docs/messaging/services#mms-converter) for messages sent through the Service instance. </summary> 
        public bool? MmsConverter { get; set; }

        ///<summary> Whether to enable [Smart Encoding](https://www.twilio.com/docs/messaging/services#smart-encoding) for messages sent through the Service instance. </summary> 
        public bool? SmartEncoding { get; set; }

        
        public ServiceResource.ScanMessageContentEnum ScanMessageContent { get; set; }

        ///<summary> [OBSOLETE] Former feature used to fallback to long code sender after certain short code message failures. </summary> 
        public bool? FallbackToLongCode { get; set; }

        ///<summary> Whether to enable [Area Code Geomatch](https://www.twilio.com/docs/messaging/services#area-code-geomatch) on the Service Instance. </summary> 
        public bool? AreaCodeGeomatch { get; set; }

        ///<summary> How long, in seconds, messages sent from the Service are valid. Can be an integer from `1` to `14,400`. </summary> 
        public int? ValidityPeriod { get; set; }

        ///<summary> Reserved. </summary> 
        public bool? SynchronousValidation { get; set; }

        ///<summary> A string that describes the scenario in which the Messaging Service will be used. Possible values are `notifications`, `marketing`, `verification`, `discussion`, `poll`, `undeclared`. </summary> 
        public string Usecase { get; set; }

        ///<summary> A boolean value that indicates either the webhook url configured on the phone number will be used or `inbound_request_url`/`fallback_url` url will be called when a message is received from the phone number. If this field is enabled then the webhook url defined on the phone number will override the `inbound_request_url`/`fallback_url` defined for the Messaging Service. </summary> 
        public bool? UseInboundWebhookOnNumber { get; set; }


        /// <summary> Construct a new CreateServiceOptions </summary>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </param>
        public CreateServiceOptions(string friendlyName)
        {
            FriendlyName = friendlyName;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (InboundRequestUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("InboundRequestUrl", Serializers.Url(InboundRequestUrl)));
            }
            if (InboundMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("InboundMethod", InboundMethod.ToString()));
            }
            if (FallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("FallbackUrl", Serializers.Url(FallbackUrl)));
            }
            if (FallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("FallbackMethod", FallbackMethod.ToString()));
            }
            if (StatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallback", Serializers.Url(StatusCallback)));
            }
            if (StickySender != null)
            {
                p.Add(new KeyValuePair<string, string>("StickySender", StickySender.Value.ToString().ToLower()));
            }
            if (MmsConverter != null)
            {
                p.Add(new KeyValuePair<string, string>("MmsConverter", MmsConverter.Value.ToString().ToLower()));
            }
            if (SmartEncoding != null)
            {
                p.Add(new KeyValuePair<string, string>("SmartEncoding", SmartEncoding.Value.ToString().ToLower()));
            }
            if (ScanMessageContent != null)
            {
                p.Add(new KeyValuePair<string, string>("ScanMessageContent", ScanMessageContent.ToString()));
            }
            if (FallbackToLongCode != null)
            {
                p.Add(new KeyValuePair<string, string>("FallbackToLongCode", FallbackToLongCode.Value.ToString().ToLower()));
            }
            if (AreaCodeGeomatch != null)
            {
                p.Add(new KeyValuePair<string, string>("AreaCodeGeomatch", AreaCodeGeomatch.Value.ToString().ToLower()));
            }
            if (ValidityPeriod != null)
            {
                p.Add(new KeyValuePair<string, string>("ValidityPeriod", ValidityPeriod.ToString()));
            }
            if (SynchronousValidation != null)
            {
                p.Add(new KeyValuePair<string, string>("SynchronousValidation", SynchronousValidation.Value.ToString().ToLower()));
            }
            if (Usecase != null)
            {
                p.Add(new KeyValuePair<string, string>("Usecase", Usecase));
            }
            if (UseInboundWebhookOnNumber != null)
            {
                p.Add(new KeyValuePair<string, string>("UseInboundWebhookOnNumber", UseInboundWebhookOnNumber.Value.ToString().ToLower()));
            }
            return p;
        }

        

    }
    /// <summary> delete </summary>
    public class DeleteServiceOptions : IOptions<ServiceResource>
    {
        
        ///<summary> The SID of the Service resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteServiceOptions </summary>
        /// <param name="pathSid"> The SID of the Service resource to delete. </param>
        public DeleteServiceOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> fetch </summary>
    public class FetchServiceOptions : IOptions<ServiceResource>
    {
    
        ///<summary> The SID of the Service resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchServiceOptions </summary>
        /// <param name="pathSid"> The SID of the Service resource to fetch. </param>
        public FetchServiceOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> read </summary>
    public class ReadServiceOptions : ReadOptions<ServiceResource>
    {
    



        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }

    

    }

    /// <summary> update </summary>
    public class UpdateServiceOptions : IOptions<ServiceResource>
    {
    
        ///<summary> The SID of the Service resource to update. </summary> 
        public string PathSid { get; }

        ///<summary> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> The URL we call using `inbound_method` when a message is received by any phone number or short code in the Service. When this property is `null`, receiving inbound messages is disabled. All messages sent to the Twilio phone number or short code will not be logged and received on the Account. If the `use_inbound_webhook_on_number` field is enabled then the webhook url defined on the phone number will override the `inbound_request_url` defined for the Messaging Service. </summary> 
        public Uri InboundRequestUrl { get; set; }

        ///<summary> The HTTP method we should use to call `inbound_request_url`. Can be `GET` or `POST` and the default is `POST`. </summary> 
        public Twilio.Http.HttpMethod InboundMethod { get; set; }

        ///<summary> The URL that we call using `fallback_method` if an error occurs while retrieving or executing the TwiML from the Inbound Request URL. If the `use_inbound_webhook_on_number` field is enabled then the webhook url defined on the phone number will override the `fallback_url` defined for the Messaging Service. </summary> 
        public Uri FallbackUrl { get; set; }

        ///<summary> The HTTP method we should use to call `fallback_url`. Can be: `GET` or `POST`. </summary> 
        public Twilio.Http.HttpMethod FallbackMethod { get; set; }

        ///<summary> The URL we should call to [pass status updates](https://www.twilio.com/docs/sms/api/message-resource#message-status-values) about message delivery. </summary> 
        public Uri StatusCallback { get; set; }

        ///<summary> Whether to enable [Sticky Sender](https://www.twilio.com/docs/messaging/services#sticky-sender) on the Service instance. </summary> 
        public bool? StickySender { get; set; }

        ///<summary> Whether to enable the [MMS Converter](https://www.twilio.com/docs/messaging/services#mms-converter) for messages sent through the Service instance. </summary> 
        public bool? MmsConverter { get; set; }

        ///<summary> Whether to enable [Smart Encoding](https://www.twilio.com/docs/messaging/services#smart-encoding) for messages sent through the Service instance. </summary> 
        public bool? SmartEncoding { get; set; }

        
        public ServiceResource.ScanMessageContentEnum ScanMessageContent { get; set; }

        ///<summary> [OBSOLETE] Former feature used to fallback to long code sender after certain short code message failures. </summary> 
        public bool? FallbackToLongCode { get; set; }

        ///<summary> Whether to enable [Area Code Geomatch](https://www.twilio.com/docs/messaging/services#area-code-geomatch) on the Service Instance. </summary> 
        public bool? AreaCodeGeomatch { get; set; }

        ///<summary> How long, in seconds, messages sent from the Service are valid. Can be an integer from `1` to `14,400`. </summary> 
        public int? ValidityPeriod { get; set; }

        ///<summary> Reserved. </summary> 
        public bool? SynchronousValidation { get; set; }

        ///<summary> A string that describes the scenario in which the Messaging Service will be used. Possible values are `notifications`, `marketing`, `verification`, `discussion`, `poll`, `undeclared`. </summary> 
        public string Usecase { get; set; }

        ///<summary> A boolean value that indicates either the webhook url configured on the phone number will be used or `inbound_request_url`/`fallback_url` url will be called when a message is received from the phone number. If this field is enabled then the webhook url defined on the phone number will override the `inbound_request_url`/`fallback_url` defined for the Messaging Service. </summary> 
        public bool? UseInboundWebhookOnNumber { get; set; }



        /// <summary> Construct a new UpdateServiceOptions </summary>
        /// <param name="pathSid"> The SID of the Service resource to update. </param>
        public UpdateServiceOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (InboundRequestUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("InboundRequestUrl", Serializers.Url(InboundRequestUrl)));
            }
            if (InboundMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("InboundMethod", InboundMethod.ToString()));
            }
            if (FallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("FallbackUrl", Serializers.Url(FallbackUrl)));
            }
            if (FallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("FallbackMethod", FallbackMethod.ToString()));
            }
            if (StatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallback", Serializers.Url(StatusCallback)));
            }
            if (StickySender != null)
            {
                p.Add(new KeyValuePair<string, string>("StickySender", StickySender.Value.ToString().ToLower()));
            }
            if (MmsConverter != null)
            {
                p.Add(new KeyValuePair<string, string>("MmsConverter", MmsConverter.Value.ToString().ToLower()));
            }
            if (SmartEncoding != null)
            {
                p.Add(new KeyValuePair<string, string>("SmartEncoding", SmartEncoding.Value.ToString().ToLower()));
            }
            if (ScanMessageContent != null)
            {
                p.Add(new KeyValuePair<string, string>("ScanMessageContent", ScanMessageContent.ToString()));
            }
            if (FallbackToLongCode != null)
            {
                p.Add(new KeyValuePair<string, string>("FallbackToLongCode", FallbackToLongCode.Value.ToString().ToLower()));
            }
            if (AreaCodeGeomatch != null)
            {
                p.Add(new KeyValuePair<string, string>("AreaCodeGeomatch", AreaCodeGeomatch.Value.ToString().ToLower()));
            }
            if (ValidityPeriod != null)
            {
                p.Add(new KeyValuePair<string, string>("ValidityPeriod", ValidityPeriod.ToString()));
            }
            if (SynchronousValidation != null)
            {
                p.Add(new KeyValuePair<string, string>("SynchronousValidation", SynchronousValidation.Value.ToString().ToLower()));
            }
            if (Usecase != null)
            {
                p.Add(new KeyValuePair<string, string>("Usecase", Usecase));
            }
            if (UseInboundWebhookOnNumber != null)
            {
                p.Add(new KeyValuePair<string, string>("UseInboundWebhookOnNumber", UseInboundWebhookOnNumber.Value.ToString().ToLower()));
            }
            return p;
        }

        

    }


}

