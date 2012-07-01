
namespace Twilio.Mvc
{
    /// <summary>
    /// This class can be used as the parameter on your SMS action. Incoming parameters will be bound here.
    /// </summary>
    /// <remarks>http://www.twilio.com/docs/api/twiml/sms/twilio_request</remarks>
    public class SmsRequest
    {
        public string SmsSid { get; set; }
        public string AccountSid { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Body { get; set; }

        public string FromCity { get; set; }
        public string FromState { get; set; }
        public string FromZip { get; set; }
        public string FromCountry { get; set; }
        public string ToCity { get; set; }
        public string ToState { get; set; }
        public string ToZip { get; set; }
        public string ToCountry { get; set; }
    }
}
