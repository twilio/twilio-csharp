/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Api
 * This is the public Twilio REST API.
 *
 * NOTE: This class is auto generated by OpenAPI Generator.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Constant;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;




namespace Twilio.Rest.Api.V2010.Account.Call
{
    public class PaymentResource : Resource
    {
    

    
        public sealed class StatusEnum : StringEnum
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}
            public static implicit operator StatusEnum(string value)
            {
                return new StatusEnum(value);
            }
            public static readonly StatusEnum Complete = new StatusEnum("complete");
            public static readonly StatusEnum Cancel = new StatusEnum("cancel");

        }
        public sealed class PaymentMethodEnum : StringEnum
        {
            private PaymentMethodEnum(string value) : base(value) {}
            public PaymentMethodEnum() {}
            public static implicit operator PaymentMethodEnum(string value)
            {
                return new PaymentMethodEnum(value);
            }
            public static readonly PaymentMethodEnum CreditCard = new PaymentMethodEnum("credit-card");
            public static readonly PaymentMethodEnum AchDebit = new PaymentMethodEnum("ach-debit");

        }
        public sealed class TokenTypeEnum : StringEnum
        {
            private TokenTypeEnum(string value) : base(value) {}
            public TokenTypeEnum() {}
            public static implicit operator TokenTypeEnum(string value)
            {
                return new TokenTypeEnum(value);
            }
            public static readonly TokenTypeEnum OneTime = new TokenTypeEnum("one-time");
            public static readonly TokenTypeEnum Reusable = new TokenTypeEnum("reusable");
            public static readonly TokenTypeEnum PaymentMethod = new TokenTypeEnum("payment-method");

        }
        public sealed class BankAccountTypeEnum : StringEnum
        {
            private BankAccountTypeEnum(string value) : base(value) {}
            public BankAccountTypeEnum() {}
            public static implicit operator BankAccountTypeEnum(string value)
            {
                return new BankAccountTypeEnum(value);
            }
            public static readonly BankAccountTypeEnum ConsumerChecking = new BankAccountTypeEnum("consumer-checking");
            public static readonly BankAccountTypeEnum ConsumerSavings = new BankAccountTypeEnum("consumer-savings");
            public static readonly BankAccountTypeEnum CommercialChecking = new BankAccountTypeEnum("commercial-checking");

        }
        public sealed class CaptureEnum : StringEnum
        {
            private CaptureEnum(string value) : base(value) {}
            public CaptureEnum() {}
            public static implicit operator CaptureEnum(string value)
            {
                return new CaptureEnum(value);
            }
            public static readonly CaptureEnum PaymentCardNumber = new CaptureEnum("payment-card-number");
            public static readonly CaptureEnum ExpirationDate = new CaptureEnum("expiration-date");
            public static readonly CaptureEnum SecurityCode = new CaptureEnum("security-code");
            public static readonly CaptureEnum PostalCode = new CaptureEnum("postal-code");
            public static readonly CaptureEnum BankRoutingNumber = new CaptureEnum("bank-routing-number");
            public static readonly CaptureEnum BankAccountNumber = new CaptureEnum("bank-account-number");

        }

        
        private static Request BuildCreateRequest(CreatePaymentOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/Calls/{CallSid}/Payments.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathCallSid = options.PathCallSid;
            path = path.Replace("{"+"CallSid"+"}", PathCallSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> create an instance of payments. This will start a new payments session </summary>
        /// <param name="options"> Create Payment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Payment </returns>
        public static PaymentResource Create(CreatePaymentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }

        #if !NET35
        /// <summary> create an instance of payments. This will start a new payments session </summary>
        /// <param name="options"> Create Payment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Payment </returns>
        public static async System.Threading.Tasks.Task<PaymentResource> CreateAsync(CreatePaymentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> create an instance of payments. This will start a new payments session </summary>
        /// <param name="pathCallSid"> The SID of the call that will create the resource. Call leg associated with this sid is expected to provide payment information thru DTMF. </param>
        /// <param name="idempotencyKey"> A unique token that will be used to ensure that multiple API calls with the same information do not result in multiple transactions. This should be a unique string value per API call and can be a randomly generated. </param>
        /// <param name="statusCallback"> Provide an absolute or relative URL to receive status updates regarding your Pay session. Read more about the [expected StatusCallback values](https://www.twilio.com/docs/voice/api/payment-resource#statuscallback) </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that will create the resource. </param>
        /// <param name="bankAccountType">  </param>
        /// <param name="chargeAmount"> A positive decimal value less than 1,000,000 to charge against the credit card or bank account. Default currency can be overwritten with `currency` field. Leave blank or set to 0 to tokenize. </param>
        /// <param name="currency"> The currency of the `charge_amount`, formatted as [ISO 4127](http://www.iso.org/iso/home/standards/currency_codes.htm) format. The default value is `USD` and all values allowed from the Pay Connector are accepted. </param>
        /// <param name="description"> The description can be used to provide more details regarding the transaction. This information is submitted along with the payment details to the Payment Connector which are then posted on the transactions. </param>
        /// <param name="input"> A list of inputs that should be accepted. Currently only `dtmf` is supported. All digits captured during a pay session are redacted from the logs. </param>
        /// <param name="minPostalCodeLength"> A positive integer that is used to validate the length of the `PostalCode` inputted by the user. User must enter this many digits. </param>
        /// <param name="parameter"> A single-level JSON object used to pass custom parameters to payment processors. (Required for ACH payments). The information that has to be included here depends on the <Pay> Connector. [Read more](https://www.twilio.com/console/voice/pay-connectors). </param>
        /// <param name="paymentConnector"> This is the unique name corresponding to the Pay Connector installed in the Twilio Add-ons. Learn more about [<Pay> Connectors](https://www.twilio.com/console/voice/pay-connectors). The default value is `Default`. </param>
        /// <param name="paymentMethod">  </param>
        /// <param name="postalCode"> Indicates whether the credit card postal code (zip code) is a required piece of payment information that must be provided by the caller. The default is `true`. </param>
        /// <param name="securityCode"> Indicates whether the credit card security code is a required piece of payment information that must be provided by the caller. The default is `true`. </param>
        /// <param name="timeout"> The number of seconds that <Pay> should wait for the caller to press a digit between each subsequent digit, after the first one, before moving on to validate the digits captured. The default is `5`, maximum is `600`. </param>
        /// <param name="tokenType">  </param>
        /// <param name="validCardTypes"> Credit card types separated by space that Pay should accept. The default value is `visa mastercard amex` </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Payment </returns>
        public static PaymentResource Create(
                                          string pathCallSid,
                                          string idempotencyKey,
                                          Uri statusCallback,
                                          string pathAccountSid = null,
                                          PaymentResource.BankAccountTypeEnum bankAccountType = null,
                                          decimal? chargeAmount = null,
                                          string currency = null,
                                          string description = null,
                                          string input = null,
                                          int? minPostalCodeLength = null,
                                          object parameter = null,
                                          string paymentConnector = null,
                                          PaymentResource.PaymentMethodEnum paymentMethod = null,
                                          bool? postalCode = null,
                                          bool? securityCode = null,
                                          int? timeout = null,
                                          PaymentResource.TokenTypeEnum tokenType = null,
                                          string validCardTypes = null,
                                            ITwilioRestClient client = null)
        {
            var options = new CreatePaymentOptions(pathCallSid, idempotencyKey, statusCallback){  PathAccountSid = pathAccountSid, BankAccountType = bankAccountType, ChargeAmount = chargeAmount, Currency = currency, Description = description, Input = input, MinPostalCodeLength = minPostalCodeLength, Parameter = parameter, PaymentConnector = paymentConnector, PaymentMethod = paymentMethod, PostalCode = postalCode, SecurityCode = securityCode, Timeout = timeout, TokenType = tokenType, ValidCardTypes = validCardTypes };
            return Create(options, client);
        }

        #if !NET35
        /// <summary> create an instance of payments. This will start a new payments session </summary>
        /// <param name="pathCallSid"> The SID of the call that will create the resource. Call leg associated with this sid is expected to provide payment information thru DTMF. </param>
        /// <param name="idempotencyKey"> A unique token that will be used to ensure that multiple API calls with the same information do not result in multiple transactions. This should be a unique string value per API call and can be a randomly generated. </param>
        /// <param name="statusCallback"> Provide an absolute or relative URL to receive status updates regarding your Pay session. Read more about the [expected StatusCallback values](https://www.twilio.com/docs/voice/api/payment-resource#statuscallback) </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that will create the resource. </param>
        /// <param name="bankAccountType">  </param>
        /// <param name="chargeAmount"> A positive decimal value less than 1,000,000 to charge against the credit card or bank account. Default currency can be overwritten with `currency` field. Leave blank or set to 0 to tokenize. </param>
        /// <param name="currency"> The currency of the `charge_amount`, formatted as [ISO 4127](http://www.iso.org/iso/home/standards/currency_codes.htm) format. The default value is `USD` and all values allowed from the Pay Connector are accepted. </param>
        /// <param name="description"> The description can be used to provide more details regarding the transaction. This information is submitted along with the payment details to the Payment Connector which are then posted on the transactions. </param>
        /// <param name="input"> A list of inputs that should be accepted. Currently only `dtmf` is supported. All digits captured during a pay session are redacted from the logs. </param>
        /// <param name="minPostalCodeLength"> A positive integer that is used to validate the length of the `PostalCode` inputted by the user. User must enter this many digits. </param>
        /// <param name="parameter"> A single-level JSON object used to pass custom parameters to payment processors. (Required for ACH payments). The information that has to be included here depends on the <Pay> Connector. [Read more](https://www.twilio.com/console/voice/pay-connectors). </param>
        /// <param name="paymentConnector"> This is the unique name corresponding to the Pay Connector installed in the Twilio Add-ons. Learn more about [<Pay> Connectors](https://www.twilio.com/console/voice/pay-connectors). The default value is `Default`. </param>
        /// <param name="paymentMethod">  </param>
        /// <param name="postalCode"> Indicates whether the credit card postal code (zip code) is a required piece of payment information that must be provided by the caller. The default is `true`. </param>
        /// <param name="securityCode"> Indicates whether the credit card security code is a required piece of payment information that must be provided by the caller. The default is `true`. </param>
        /// <param name="timeout"> The number of seconds that <Pay> should wait for the caller to press a digit between each subsequent digit, after the first one, before moving on to validate the digits captured. The default is `5`, maximum is `600`. </param>
        /// <param name="tokenType">  </param>
        /// <param name="validCardTypes"> Credit card types separated by space that Pay should accept. The default value is `visa mastercard amex` </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Payment </returns>
        public static async System.Threading.Tasks.Task<PaymentResource> CreateAsync(
                                                                                  string pathCallSid,
                                                                                  string idempotencyKey,
                                                                                  Uri statusCallback,
                                                                                  string pathAccountSid = null,
                                                                                  PaymentResource.BankAccountTypeEnum bankAccountType = null,
                                                                                  decimal? chargeAmount = null,
                                                                                  string currency = null,
                                                                                  string description = null,
                                                                                  string input = null,
                                                                                  int? minPostalCodeLength = null,
                                                                                  object parameter = null,
                                                                                  string paymentConnector = null,
                                                                                  PaymentResource.PaymentMethodEnum paymentMethod = null,
                                                                                  bool? postalCode = null,
                                                                                  bool? securityCode = null,
                                                                                  int? timeout = null,
                                                                                  PaymentResource.TokenTypeEnum tokenType = null,
                                                                                  string validCardTypes = null,
                                                                                    ITwilioRestClient client = null)
        {
        var options = new CreatePaymentOptions(pathCallSid, idempotencyKey, statusCallback){  PathAccountSid = pathAccountSid, BankAccountType = bankAccountType, ChargeAmount = chargeAmount, Currency = currency, Description = description, Input = input, MinPostalCodeLength = minPostalCodeLength, Parameter = parameter, PaymentConnector = paymentConnector, PaymentMethod = paymentMethod, PostalCode = postalCode, SecurityCode = securityCode, Timeout = timeout, TokenType = tokenType, ValidCardTypes = validCardTypes };
            return await CreateAsync(options, client);
        }
        #endif
        
        private static Request BuildUpdateRequest(UpdatePaymentOptions options, ITwilioRestClient client)
        {
            
            string path = "/2010-04-01/Accounts/{AccountSid}/Calls/{CallSid}/Payments/{Sid}.json";

            string PathAccountSid = options.PathAccountSid ?? client.AccountSid;
            path = path.Replace("{"+"AccountSid"+"}", PathAccountSid);
            string PathCallSid = options.PathCallSid;
            path = path.Replace("{"+"CallSid"+"}", PathCallSid);
            string PathSid = options.PathSid;
            path = path.Replace("{"+"Sid"+"}", PathSid);

            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                path,
                contentType: EnumConstants.ContentTypeEnum.FORM_URLENCODED,
                postParams: options.GetParams(),
                headerParams: null
            );
        }

        /// <summary> update an instance of payments with different phases of payment flows. </summary>
        /// <param name="options"> Update Payment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Payment </returns>
        public static PaymentResource Update(UpdatePaymentOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }

        /// <summary> update an instance of payments with different phases of payment flows. </summary>
        /// <param name="options"> Update Payment parameters </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Payment </returns>
        #if !NET35
        public static async System.Threading.Tasks.Task<PaymentResource> UpdateAsync(UpdatePaymentOptions options,
                                                                                                    ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = await client.RequestAsync(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
        #endif

        /// <summary> update an instance of payments with different phases of payment flows. </summary>
        /// <param name="pathCallSid"> The SID of the call that will update the resource. This should be the same call sid that was used to create payments resource. </param>
        /// <param name="pathSid"> The SID of Payments session that needs to be updated. </param>
        /// <param name="idempotencyKey"> A unique token that will be used to ensure that multiple API calls with the same information do not result in multiple transactions. This should be a unique string value per API call and can be a randomly generated. </param>
        /// <param name="statusCallback"> Provide an absolute or relative URL to receive status updates regarding your Pay session. Read more about the [Update](https://www.twilio.com/docs/voice/api/payment-resource#statuscallback-update) and [Complete/Cancel](https://www.twilio.com/docs/voice/api/payment-resource#statuscallback-cancelcomplete) POST requests. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that will update the resource. </param>
        /// <param name="capture">  </param>
        /// <param name="status">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> A single instance of Payment </returns>
        public static PaymentResource Update(
                                          string pathCallSid,
                                          string pathSid,
                                          string idempotencyKey,
                                          Uri statusCallback,
                                          string pathAccountSid = null,
                                          PaymentResource.CaptureEnum capture = null,
                                          PaymentResource.StatusEnum status = null,
                                            ITwilioRestClient client = null)
        {
            var options = new UpdatePaymentOptions(pathCallSid, pathSid, idempotencyKey, statusCallback){ PathAccountSid = pathAccountSid, Capture = capture, Status = status };
            return Update(options, client);
        }

        #if !NET35
        /// <summary> update an instance of payments with different phases of payment flows. </summary>
        /// <param name="pathCallSid"> The SID of the call that will update the resource. This should be the same call sid that was used to create payments resource. </param>
        /// <param name="pathSid"> The SID of Payments session that needs to be updated. </param>
        /// <param name="idempotencyKey"> A unique token that will be used to ensure that multiple API calls with the same information do not result in multiple transactions. This should be a unique string value per API call and can be a randomly generated. </param>
        /// <param name="statusCallback"> Provide an absolute or relative URL to receive status updates regarding your Pay session. Read more about the [Update](https://www.twilio.com/docs/voice/api/payment-resource#statuscallback-update) and [Complete/Cancel](https://www.twilio.com/docs/voice/api/payment-resource#statuscallback-cancelcomplete) POST requests. </param>
        /// <param name="pathAccountSid"> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that will update the resource. </param>
        /// <param name="capture">  </param>
        /// <param name="status">  </param>
        /// <param name="client"> Client to make requests to Twilio </param>
        /// <returns> Task that resolves to A single instance of Payment </returns>
        public static async System.Threading.Tasks.Task<PaymentResource> UpdateAsync(
                                                                              string pathCallSid,
                                                                              string pathSid,
                                                                              string idempotencyKey,
                                                                              Uri statusCallback,
                                                                              string pathAccountSid = null,
                                                                              PaymentResource.CaptureEnum capture = null,
                                                                              PaymentResource.StatusEnum status = null,
                                                                                ITwilioRestClient client = null)
        {
            var options = new UpdatePaymentOptions(pathCallSid, pathSid, idempotencyKey, statusCallback){ PathAccountSid = pathAccountSid, Capture = capture, Status = status };
            return await UpdateAsync(options, client);
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a PaymentResource object
        /// </summary>
        /// <param name="json"> Raw JSON string </param>
        /// <returns> PaymentResource object represented by the provided JSON </returns>
        public static PaymentResource FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<PaymentResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
        /// <summary>
    /// Converts an object into a json string
    /// </summary>
    /// <param name="model"> C# model </param>
    /// <returns> JSON string </returns>
    public static string ToJson(object model)
    {
        try
        {
            return JsonConvert.SerializeObject(model);
        }
        catch (JsonException e)
        {
            throw new ApiException(e.Message, e);
        }
    }

    
        ///<summary> The SID of the [Account](https://www.twilio.com/docs/iam/api/account) that created the Payments resource. </summary> 
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }

        ///<summary> The SID of the [Call](https://www.twilio.com/docs/voice/api/call-resource) the Payments resource is associated with. This will refer to the call sid that is producing the payment card (credit/ACH) information thru DTMF. </summary> 
        [JsonProperty("call_sid")]
        public string CallSid { get; private set; }

        ///<summary> The SID of the Payments resource. </summary> 
        [JsonProperty("sid")]
        public string Sid { get; private set; }

        ///<summary> The date and time in GMT that the resource was created specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }

        ///<summary> The date and time in GMT that the resource was last updated specified in [RFC 2822](https://www.ietf.org/rfc/rfc2822.txt) format. </summary> 
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }

        ///<summary> The URI of the resource, relative to `https://api.twilio.com`. </summary> 
        [JsonProperty("uri")]
        public string Uri { get; private set; }



        private PaymentResource() {

        }
    }
}

