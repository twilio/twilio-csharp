namespace Twilio.Mvc
{    
    /// <summary>
    /// Base class for mapping incoming request parameters into a strongly typed object
    /// </summary>
    public abstract class TwilioRequest
    {
        /// <summary>
        /// Your Twilio account id. It is 34 characters long, and always starts with the letters AC
        /// </summary>
        public string AccountSid { get; set; }
        
        /// <summary>
        /// The phone number or client identifier of the party that initiated the call
        /// </summary>
        /// <remarks>
        /// Phone numbers are formatted with a '+' and country code, e.g. +16175551212 (E.164 format). Client identifiers begin with the client: URI scheme; for example, for a call from a client named 'tommy', the From parameter will be client:tommy.
        /// </remarks>
        public string From { get; set; }
        
        /// <summary>
        /// The phone number or client identifier of the called party
        /// </summary>
        /// <remarks>
        /// Phone numbers are formatted with a '+' and country code, e.g. +16175551212 (E.164 format). Client identifiers begin with the client: URI scheme; for example, for a call to a client named 'jenny', the To parameter will be client:jenny.
        /// </remarks>
        public string To { get; set; }

        
        /// <summary>
        /// The city of the caller
        /// </summary>
        public string FromCity { get; set; }
        
        /// <summary>
        /// The state or province of the caller
        /// </summary>
        public string FromState { get; set; }
        
        /// <summary>
        /// The postal code of the caller
        /// </summary>
        public string FromZip { get; set; }
        
        /// <summary>
        /// The country of the caller
        /// </summary>
        public string FromCountry { get; set; }
        
        /// <summary>
        /// The city of the called party
        /// </summary>
        public string ToCity { get; set; }
        
        /// <summary>
        /// The state or province of the called party
        /// </summary>
        public string ToState { get; set; }
        
        /// <summary>
        /// The postal code of the called party
        /// </summary>
        public string ToZip { get; set; }
        
        /// <summary>
        /// The country of the called party
        /// </summary>
        public string ToCountry { get; set; }
    }
}
