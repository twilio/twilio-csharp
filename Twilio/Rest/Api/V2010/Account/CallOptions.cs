using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010.Account 
{

    public class CreateCallOptions : IOptions<CallResource> 
    {
        public string AccountSid { get; set; }
        public IEndpoint To { get; }
        public Types.PhoneNumber From { get; }
        public Uri Url { get; set; }
        public string ApplicationSid { get; set; }
        public Twilio.Http.HttpMethod Method { get; set; }
        public Uri FallbackUrl { get; set; }
        public Twilio.Http.HttpMethod FallbackMethod { get; set; }
        public Uri StatusCallback { get; set; }
        public List<string> StatusCallbackEvent { get; set; }
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }
        public string SendDigits { get; set; }
        public string IfMachine { get; set; }
        public string MachineDetection { get; set; }
        public int? MachineDetectionTimeout { get; set; }
        public int? Timeout { get; set; }
        public bool? Record { get; set; }
        public string RecordingChannels { get; set; }
        public string RecordingStatusCallback { get; set; }
        public Twilio.Http.HttpMethod RecordingStatusCallbackMethod { get; set; }
        public string SipAuthUsername { get; set; }
        public string SipAuthPassword { get; set; }
    
        /// <summary>
        /// Construct a new CreateCallOptions
        /// </summary>
        ///
        /// <param name="to"> Phone number, SIP address or client identifier to call </param>
        /// <param name="from"> Twilio number from which to originate the call </param>
        public CreateCallOptions(IEndpoint to, Types.PhoneNumber from)
        {
            To = to;
            From = from;
            StatusCallbackEvent = new List<string>();
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (To != null)
            {
                p.Add(new KeyValuePair<string, string>("To", To.ToString()));
            }
            
            if (From != null)
            {
                p.Add(new KeyValuePair<string, string>("From", From.ToString()));
            }
            
            if (Url != null)
            {
                p.Add(new KeyValuePair<string, string>("Url", Url.ToString()));
            }
            
            if (ApplicationSid != null)
            {
                p.Add(new KeyValuePair<string, string>("ApplicationSid", ApplicationSid.ToString()));
            }
            
            if (Method != null)
            {
                p.Add(new KeyValuePair<string, string>("Method", Method.ToString()));
            }
            
            if (FallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("FallbackUrl", FallbackUrl.ToString()));
            }
            
            if (FallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("FallbackMethod", FallbackMethod.ToString()));
            }
            
            if (StatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallback", StatusCallback.ToString()));
            }
            
            if (StatusCallbackEvent != null)
            {
                p.AddRange(StatusCallbackEvent.Select(prop => new KeyValuePair<string, string>("StatusCallbackEvent", prop)));
            }
            
            if (StatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallbackMethod", StatusCallbackMethod.ToString()));
            }
            
            if (SendDigits != null)
            {
                p.Add(new KeyValuePair<string, string>("SendDigits", SendDigits));
            }
            
            if (IfMachine != null)
            {
                p.Add(new KeyValuePair<string, string>("IfMachine", IfMachine));
            }
            
            if (MachineDetection != null)
            {
                p.Add(new KeyValuePair<string, string>("MachineDetection", MachineDetection));
            }
            
            if (MachineDetectionTimeout != null)
            {
                p.Add(new KeyValuePair<string, string>("MachineDetectionTimeout", MachineDetectionTimeout.Value.ToString()));
            }
            
            if (Timeout != null)
            {
                p.Add(new KeyValuePair<string, string>("Timeout", Timeout.Value.ToString()));
            }
            
            if (Record != null)
            {
                p.Add(new KeyValuePair<string, string>("Record", Record.Value.ToString()));
            }
            
            if (RecordingChannels != null)
            {
                p.Add(new KeyValuePair<string, string>("RecordingChannels", RecordingChannels));
            }
            
            if (RecordingStatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("RecordingStatusCallback", RecordingStatusCallback));
            }
            
            if (RecordingStatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("RecordingStatusCallbackMethod", RecordingStatusCallbackMethod.ToString()));
            }
            
            if (SipAuthUsername != null)
            {
                p.Add(new KeyValuePair<string, string>("SipAuthUsername", SipAuthUsername));
            }
            
            if (SipAuthPassword != null)
            {
                p.Add(new KeyValuePair<string, string>("SipAuthPassword", SipAuthPassword));
            }
            
            return p;
        }
    }

    public class DeleteCallOptions : IOptions<CallResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteCallOptions
        /// </summary>
        ///
        /// <param name="sid"> Call Sid that uniquely identifies the Call to delete </param>
        public DeleteCallOptions(string sid)
        {
            Sid = sid;
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

    public class FetchCallOptions : IOptions<CallResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchCallOptions
        /// </summary>
        ///
        /// <param name="sid"> Call Sid that uniquely identifies the Call to fetch </param>
        public FetchCallOptions(string sid)
        {
            Sid = sid;
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

    public class ReadCallOptions : ReadOptions<CallResource> 
    {
        public string AccountSid { get; set; }
        public Types.PhoneNumber To { get; set; }
        public Types.PhoneNumber From { get; set; }
        public string ParentCallSid { get; set; }
        public CallResource.StatusEnum Status { get; set; }
        public DateTime? StartTimeBefore { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? StartTimeAfter { get; set; }
        public DateTime? EndTimeBefore { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? EndTimeAfter { get; set; }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (To != null)
            {
                p.Add(new KeyValuePair<string, string>("To", To.ToString()));
            }
            
            if (From != null)
            {
                p.Add(new KeyValuePair<string, string>("From", From.ToString()));
            }
            
            if (ParentCallSid != null)
            {
                p.Add(new KeyValuePair<string, string>("ParentCallSid", ParentCallSid.ToString()));
            }
            
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            
            if (StartTime != null)
            {
                p.Add(new KeyValuePair<string, string>("StartTime", StartTime.ToString()));
            }
            else
            {
                if (StartTimeBefore != null)
                {
                    p.Add(new KeyValuePair<string, string>("StartTime<", StartTimeBefore.ToString()));
                }
            
                if (StartTimeAfter != null)
                {
                    p.Add(new KeyValuePair<string, string>("StartTime>", StartTimeAfter.ToString()));
                }
            }
            
            if (EndTime != null)
            {
                p.Add(new KeyValuePair<string, string>("EndTime", EndTime.ToString()));
            }
            else
            {
                if (EndTimeBefore != null)
                {
                    p.Add(new KeyValuePair<string, string>("EndTime<", EndTimeBefore.ToString()));
                }
            
                if (EndTimeAfter != null)
                {
                    p.Add(new KeyValuePair<string, string>("EndTime>", EndTimeAfter.ToString()));
                }
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    public class UpdateCallOptions : IOptions<CallResource> 
    {
        public string AccountSid { get; set; }
        public string Sid { get; }
        public Uri Url { get; set; }
        public Twilio.Http.HttpMethod Method { get; set; }
        public CallResource.UpdateStatusEnum Status { get; set; }
        public Uri FallbackUrl { get; set; }
        public Twilio.Http.HttpMethod FallbackMethod { get; set; }
        public Uri StatusCallback { get; set; }
        public Twilio.Http.HttpMethod StatusCallbackMethod { get; set; }
    
        /// <summary>
        /// Construct a new UpdateCallOptions
        /// </summary>
        ///
        /// <param name="sid"> Call Sid that uniquely identifies the Call to update </param>
        public UpdateCallOptions(string sid)
        {
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Url != null)
            {
                p.Add(new KeyValuePair<string, string>("Url", Url.ToString()));
            }
            
            if (Method != null)
            {
                p.Add(new KeyValuePair<string, string>("Method", Method.ToString()));
            }
            
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            
            if (FallbackUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("FallbackUrl", FallbackUrl.ToString()));
            }
            
            if (FallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("FallbackMethod", FallbackMethod.ToString()));
            }
            
            if (StatusCallback != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallback", StatusCallback.ToString()));
            }
            
            if (StatusCallbackMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("StatusCallbackMethod", StatusCallbackMethod.ToString()));
            }
            
            return p;
        }
    }

}