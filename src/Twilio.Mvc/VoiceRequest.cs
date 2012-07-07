namespace Twilio.Mvc
{
    /// <summary>
    /// This class can be used as the parameter on your voice action. Incoming parameters will be bound here.
    /// </summary>
    /// <remarks>http://www.twilio.com/docs/api/twiml/twilio_request</remarks>
    public class VoiceRequest : TwilioRequest
    {
        public string CallSid { get; set; }
        public string CallStatus { get; set; }
        public string ApiVersion { get; set; }
        public string Direction { get; set; }
        public string ForwardedFrom { get; set; }
        public string CallerName { get; set; }
    }
}
