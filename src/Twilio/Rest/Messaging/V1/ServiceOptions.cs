using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Messaging.V1 
{

    /// <summary>
    /// CreateServiceOptions
    /// </summary>
    public class CreateServiceOptions : IOptions<ServiceResource> 
    {
        /// <summary>
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; }
        /// <summary>
        /// The inbound_request_url
        /// </summary>
        public Uri InboundRequestUrl { get; set; }
        /// <summary>
        /// The inbound_method
        /// </summary>
        public Twilio.Http.HttpMethod InboundMethod { get; set; }
        /// <summary>
        /// The fallback_url
        /// </summary>
        public Uri FallbackUrl { get; set; }
        /// <summary>
        /// The fallback_method
        /// </summary>
        public Twilio.Http.HttpMethod FallbackMethod { get; set; }
        /// <summary>
        /// The status_callback
        /// </summary>
        public Uri StatusCallback { get; set; }
        /// <summary>
        /// The sticky_sender
        /// </summary>
        public bool? StickySender { get; set; }
        /// <summary>
        /// The mms_converter
        /// </summary>
        public bool? MmsConverter { get; set; }
        /// <summary>
        /// The smart_encoding
        /// </summary>
        public bool? SmartEncoding { get; set; }
        /// <summary>
        /// The scan_message_content
        /// </summary>
        public ServiceResource.ScanMessageContentEnum ScanMessageContent { get; set; }
        /// <summary>
        /// The fallback_to_long_code
        /// </summary>
        public bool? FallbackToLongCode { get; set; }
        /// <summary>
        /// The area_code_geomatch
        /// </summary>
        public bool? AreaCodeGeomatch { get; set; }
        /// <summary>
        /// The validity_period
        /// </summary>
        public int? ValidityPeriod { get; set; }
        /// <summary>
        /// The synchronous_validation
        /// </summary>
        public bool? SynchronousValidation { get; set; }

        /// <summary>
        /// Construct a new CreateServiceOptions
        /// </summary>
        ///
        /// <param name="friendlyName"> The friendly_name </param>
        public CreateServiceOptions(string friendlyName)
        {
            FriendlyName = friendlyName;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }

            if (InboundRequestUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("InboundRequestUrl", InboundRequestUrl.AbsoluteUri));
            }

            if (InboundMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("InboundMethod", InboundMethod.ToString()));
            }

            if (FallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("FallbackUrl", FallbackUrl.AbsoluteUri));
            }

            if (FallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("FallbackMethod", FallbackMethod.ToString()));
            }

            if (StatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallback", StatusCallback.AbsoluteUri));
            }

            if (StickySender != null)
            {
                p.Add(new KeyValuePair<string, string>("StickySender", StickySender.Value.ToString()));
            }

            if (MmsConverter != null)
            {
                p.Add(new KeyValuePair<string, string>("MmsConverter", MmsConverter.Value.ToString()));
            }

            if (SmartEncoding != null)
            {
                p.Add(new KeyValuePair<string, string>("SmartEncoding", SmartEncoding.Value.ToString()));
            }

            if (ScanMessageContent != null)
            {
                p.Add(new KeyValuePair<string, string>("ScanMessageContent", ScanMessageContent.ToString()));
            }

            if (FallbackToLongCode != null)
            {
                p.Add(new KeyValuePair<string, string>("FallbackToLongCode", FallbackToLongCode.Value.ToString()));
            }

            if (AreaCodeGeomatch != null)
            {
                p.Add(new KeyValuePair<string, string>("AreaCodeGeomatch", AreaCodeGeomatch.Value.ToString()));
            }

            if (ValidityPeriod != null)
            {
                p.Add(new KeyValuePair<string, string>("ValidityPeriod", ValidityPeriod.Value.ToString()));
            }

            if (SynchronousValidation != null)
            {
                p.Add(new KeyValuePair<string, string>("SynchronousValidation", SynchronousValidation.Value.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// UpdateServiceOptions
    /// </summary>
    public class UpdateServiceOptions : IOptions<ServiceResource> 
    {
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }
        /// <summary>
        /// The friendly_name
        /// </summary>
        public string FriendlyName { get; set; }
        /// <summary>
        /// The inbound_request_url
        /// </summary>
        public Uri InboundRequestUrl { get; set; }
        /// <summary>
        /// The inbound_method
        /// </summary>
        public Twilio.Http.HttpMethod InboundMethod { get; set; }
        /// <summary>
        /// The fallback_url
        /// </summary>
        public Uri FallbackUrl { get; set; }
        /// <summary>
        /// The fallback_method
        /// </summary>
        public Twilio.Http.HttpMethod FallbackMethod { get; set; }
        /// <summary>
        /// The status_callback
        /// </summary>
        public Uri StatusCallback { get; set; }
        /// <summary>
        /// The sticky_sender
        /// </summary>
        public bool? StickySender { get; set; }
        /// <summary>
        /// The mms_converter
        /// </summary>
        public bool? MmsConverter { get; set; }
        /// <summary>
        /// The smart_encoding
        /// </summary>
        public bool? SmartEncoding { get; set; }
        /// <summary>
        /// The scan_message_content
        /// </summary>
        public ServiceResource.ScanMessageContentEnum ScanMessageContent { get; set; }
        /// <summary>
        /// The fallback_to_long_code
        /// </summary>
        public bool? FallbackToLongCode { get; set; }
        /// <summary>
        /// The area_code_geomatch
        /// </summary>
        public bool? AreaCodeGeomatch { get; set; }
        /// <summary>
        /// The validity_period
        /// </summary>
        public int? ValidityPeriod { get; set; }
        /// <summary>
        /// The synchronous_validation
        /// </summary>
        public bool? SynchronousValidation { get; set; }

        /// <summary>
        /// Construct a new UpdateServiceOptions
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        public UpdateServiceOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }

            if (InboundRequestUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("InboundRequestUrl", InboundRequestUrl.AbsoluteUri));
            }

            if (InboundMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("InboundMethod", InboundMethod.ToString()));
            }

            if (FallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("FallbackUrl", FallbackUrl.AbsoluteUri));
            }

            if (FallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("FallbackMethod", FallbackMethod.ToString()));
            }

            if (StatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallback", StatusCallback.AbsoluteUri));
            }

            if (StickySender != null)
            {
                p.Add(new KeyValuePair<string, string>("StickySender", StickySender.Value.ToString()));
            }

            if (MmsConverter != null)
            {
                p.Add(new KeyValuePair<string, string>("MmsConverter", MmsConverter.Value.ToString()));
            }

            if (SmartEncoding != null)
            {
                p.Add(new KeyValuePair<string, string>("SmartEncoding", SmartEncoding.Value.ToString()));
            }

            if (ScanMessageContent != null)
            {
                p.Add(new KeyValuePair<string, string>("ScanMessageContent", ScanMessageContent.ToString()));
            }

            if (FallbackToLongCode != null)
            {
                p.Add(new KeyValuePair<string, string>("FallbackToLongCode", FallbackToLongCode.Value.ToString()));
            }

            if (AreaCodeGeomatch != null)
            {
                p.Add(new KeyValuePair<string, string>("AreaCodeGeomatch", AreaCodeGeomatch.Value.ToString()));
            }

            if (ValidityPeriod != null)
            {
                p.Add(new KeyValuePair<string, string>("ValidityPeriod", ValidityPeriod.Value.ToString()));
            }

            if (SynchronousValidation != null)
            {
                p.Add(new KeyValuePair<string, string>("SynchronousValidation", SynchronousValidation.Value.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// ReadServiceOptions
    /// </summary>
    public class ReadServiceOptions : ReadOptions<ServiceResource> 
    {
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// FetchServiceOptions
    /// </summary>
    public class FetchServiceOptions : IOptions<ServiceResource> 
    {
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchServiceOptions
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        public FetchServiceOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    /// <summary>
    /// DeleteServiceOptions
    /// </summary>
    public class DeleteServiceOptions : IOptions<ServiceResource> 
    {
        /// <summary>
        /// The sid
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new DeleteServiceOptions
        /// </summary>
        ///
        /// <param name="pathSid"> The sid </param>
        public DeleteServiceOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

}