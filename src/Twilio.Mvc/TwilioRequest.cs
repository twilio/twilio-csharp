namespace Twilio.Mvc
{    
    /// <summary>
    /// Base class for mapping incoming request parameters into a strongly typed object
    /// </summary>
    public abstract class TwilioRequest
    {
        public string AccountSid { get; set; }
        public string From { get; set; }
        public string To { get; set; }

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
