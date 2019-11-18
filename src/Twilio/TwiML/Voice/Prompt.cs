/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Twilio.Converters;
using Twilio.Types;

namespace Twilio.TwiML.Voice
{

    /// <summary>
    /// Prompt Twiml Verb
    /// </summary>
    public class Prompt : TwiML
    {
        public sealed class ForEnum : StringEnum
        {
            private ForEnum(string value) : base(value) {}
            public ForEnum() {}
            public static implicit operator ForEnum(string value)
            {
                return new ForEnum(value);
            }

            public static readonly ForEnum PaymentCardNumber = new ForEnum("payment-card-number");
            public static readonly ForEnum ExpirationDate = new ForEnum("expiration-date");
            public static readonly ForEnum SecurityCode = new ForEnum("security-code");
            public static readonly ForEnum PostalCode = new ForEnum("postal-code");
            public static readonly ForEnum PaymentProcessing = new ForEnum("payment-processing");
            public static readonly ForEnum BankAccountNumber = new ForEnum("bank-account-number");
            public static readonly ForEnum BankRoutingNumber = new ForEnum("bank-routing-number");
        }

        public sealed class ErrorTypeEnum : StringEnum
        {
            private ErrorTypeEnum(string value) : base(value) {}
            public ErrorTypeEnum() {}
            public static implicit operator ErrorTypeEnum(string value)
            {
                return new ErrorTypeEnum(value);
            }

            public static readonly ErrorTypeEnum Timeout = new ErrorTypeEnum("timeout");
            public static readonly ErrorTypeEnum InvalidCardNumber = new ErrorTypeEnum("invalid-card-number");
            public static readonly ErrorTypeEnum InvalidCardType = new ErrorTypeEnum("invalid-card-type");
            public static readonly ErrorTypeEnum InvalidDate = new ErrorTypeEnum("invalid-date");
            public static readonly ErrorTypeEnum InvalidSecurityCode = new ErrorTypeEnum("invalid-security-code");
            public static readonly ErrorTypeEnum InternalError = new ErrorTypeEnum("internal-error");
        }

        public sealed class CardTypeEnum : StringEnum
        {
            private CardTypeEnum(string value) : base(value) {}
            public CardTypeEnum() {}
            public static implicit operator CardTypeEnum(string value)
            {
                return new CardTypeEnum(value);
            }

            public static readonly CardTypeEnum Visa = new CardTypeEnum("visa");
            public static readonly CardTypeEnum Mastercard = new CardTypeEnum("mastercard");
            public static readonly CardTypeEnum Amex = new CardTypeEnum("amex");
            public static readonly CardTypeEnum Maestro = new CardTypeEnum("maestro");
            public static readonly CardTypeEnum Discover = new CardTypeEnum("discover");
            public static readonly CardTypeEnum Optima = new CardTypeEnum("optima");
            public static readonly CardTypeEnum Jcb = new CardTypeEnum("jcb");
            public static readonly CardTypeEnum DinersClub = new CardTypeEnum("diners-club");
            public static readonly CardTypeEnum Enroute = new CardTypeEnum("enroute");
        }

        /// <summary>
        /// Name of the payment source data element
        /// </summary>
        public Prompt.ForEnum For_ { get; set; }
        /// <summary>
        /// Type of error
        /// </summary>
        public List<Prompt.ErrorTypeEnum> ErrorType { get; set; }
        /// <summary>
        /// Type of the credit card
        /// </summary>
        public List<Prompt.CardTypeEnum> CardType { get; set; }
        /// <summary>
        /// Current attempt count
        /// </summary>
        public List<int> Attempt { get; set; }

        /// <summary>
        /// Create a new Prompt
        /// </summary>
        /// <param name="for_"> Name of the payment source data element </param>
        /// <param name="errorType"> Type of error </param>
        /// <param name="cardType"> Type of the credit card </param>
        /// <param name="attempt"> Current attempt count </param>
        public Prompt(Prompt.ForEnum for_ = null,
                      List<Prompt.ErrorTypeEnum> errorType = null,
                      List<Prompt.CardTypeEnum> cardType = null,
                      List<int> attempt = null) : base("Prompt")
        {
            this.For_ = for_;
            this.ErrorType = errorType;
            this.CardType = cardType;
            this.Attempt = attempt;
        }

        /// <summary>
        /// Return the attributes of the TwiML tag
        /// </summary>
        protected override List<XAttribute> GetElementAttributes()
        {
            var attributes = new List<XAttribute>();
            if (this.For_ != null)
            {
                attributes.Add(new XAttribute("for_", this.For_.ToString()));
            }
            if (this.ErrorType != null)
            {
                attributes.Add(new XAttribute("errorType", String.Join(" ", this.ErrorType.Select(e => e.ToString()).ToArray())));
            }
            if (this.CardType != null)
            {
                attributes.Add(new XAttribute("cardType", String.Join(" ", this.CardType.Select(e => e.ToString()).ToArray())));
            }
            if (this.Attempt != null)
            {
                attributes.Add(new XAttribute("attempt", String.Join(" ", this.Attempt.Select(e => e.ToString()).ToArray())));
            }
            return attributes;
        }

        /// <summary>
        /// Create a new <Say/> element and append it as a child of this element.
        /// </summary>
        /// <param name="message"> Message to say, the body of the TwiML Element. </param>
        /// <param name="voice"> Voice to use </param>
        /// <param name="loop"> Times to loop message </param>
        /// <param name="language"> Message langauge </param>
        public Prompt Say(string message = null,
                          Say.VoiceEnum voice = null,
                          int? loop = null,
                          Say.LanguageEnum language = null)
        {
            var newChild = new Say(message, voice, loop, language);
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Append a <Say/> element as a child of this element
        /// </summary>
        /// <param name="say"> A Say instance. </param>
        [System.Obsolete("This method is deprecated, use .Append() instead.")]
        public Prompt Say(Say say)
        {
            this.Append(say);
            return this;
        }

        /// <summary>
        /// Create a new <Play/> element and append it as a child of this element.
        /// </summary>
        /// <param name="url"> Media URL, the body of the TwiML Element. </param>
        /// <param name="loop"> Times to loop media </param>
        /// <param name="digits"> Play DTMF tones for digits </param>
        public Prompt Play(Uri url = null, int? loop = null, string digits = null)
        {
            var newChild = new Play(url, loop, digits);
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Append a <Play/> element as a child of this element
        /// </summary>
        /// <param name="play"> A Play instance. </param>
        [System.Obsolete("This method is deprecated, use .Append() instead.")]
        public Prompt Play(Play play)
        {
            this.Append(play);
            return this;
        }

        /// <summary>
        /// Create a new <Pause/> element and append it as a child of this element.
        /// </summary>
        /// <param name="length"> Length in seconds to pause </param>
        public Prompt Pause(int? length = null)
        {
            var newChild = new Pause(length);
            this.Append(newChild);
            return this;
        }

        /// <summary>
        /// Append a <Pause/> element as a child of this element
        /// </summary>
        /// <param name="pause"> A Pause instance. </param>
        [System.Obsolete("This method is deprecated, use .Append() instead.")]
        public Prompt Pause(Pause pause)
        {
            this.Append(pause);
            return this;
        }

        /// <summary>
        /// Append a child TwiML element to this element returning this element to allow chaining.
        /// </summary>
        /// <param name="childElem"> Child TwiML element to add </param>
        public new Prompt Append(TwiML childElem)
        {
            return (Prompt) base.Append(childElem);
        }

        /// <summary>
        /// Add freeform key-value attributes to the generated xml
        /// </summary>
        /// <param name="key"> Option key </param>
        /// <param name="value"> Option value </param>
        public new Prompt SetOption(string key, object value)
        {
            return (Prompt) base.SetOption(key, value);
        }
    }

}