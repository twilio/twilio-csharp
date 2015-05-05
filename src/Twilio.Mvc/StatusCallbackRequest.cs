namespace Twilio.Mvc
{    
    /// <summary>
    /// This class can be used as the parameter on your StatusCallback action. Incoming parameters will be bound here.
    /// </summary>
    /// <remarks>http://www.twilio.com/docs/api/twiml/twilio_request</remarks>
    public class StatusCallbackRequest : VoiceRequest
    {
        public float CallDuration { get; set; }
        public string RecordingUrl { get; set; }
        public string RecordingSid { get; set; }
        public float RecordingDuration { get; set; }
    }
}
