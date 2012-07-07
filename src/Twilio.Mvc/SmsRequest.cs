namespace Twilio.Mvc
{
    /// <summary>
    /// This class can be used as the parameter on your SMS action. Incoming parameters will be bound here.
    /// </summary>
    /// <remarks>http://www.twilio.com/docs/api/twiml/sms/twilio_request</remarks>
    public class SmsRequest : TwilioRequest
    {
        public string SmsSid { get; set; }
        public string Body { get; set; }
    }
}
