/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Api.V2010.Account.Call
{

    /// <summary>
    /// Subscribe to User Defined Messages for a given Call SID.
    /// </summary>
    public class CreateUserDefinedMessageSubscriptionOptions : IOptions<UserDefinedMessageSubscriptionResource>
    {
        /// <summary>
        /// Account SID.
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// Call SID.
        /// </summary>
        public string PathCallSid { get; }
        /// <summary>
        /// The URL we should call to send user defined messages.
        /// </summary>
        public Uri Callback { get; }
        /// <summary>
        /// HTTP method used with the callback.
        /// </summary>
        public Twilio.Http.HttpMethod Method { get; }
        /// <summary>
        /// A unique string value to identify API call. This should be a unique string value per API call and can be a randomly generated.
        /// </summary>
        public string IdempotencyKey { get; set; }

        /// <summary>
        /// Construct a new CreateUserDefinedMessageSubscriptionOptions
        /// </summary>
        /// <param name="pathCallSid"> Call SID. </param>
        /// <param name="callback"> The URL we should call to send user defined messages. </param>
        /// <param name="method"> HTTP method used with the callback. </param>
        public CreateUserDefinedMessageSubscriptionOptions(string pathCallSid, Uri callback, Twilio.Http.HttpMethod method)
        {
            PathCallSid = pathCallSid;
            Callback = callback;
            Method = method;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Callback != null)
            {
                p.Add(new KeyValuePair<string, string>("Callback", Serializers.Url(Callback)));
            }

            if (Method != null)
            {
                p.Add(new KeyValuePair<string, string>("Method", Method.ToString()));
            }

            if (IdempotencyKey != null)
            {
                p.Add(new KeyValuePair<string, string>("IdempotencyKey", IdempotencyKey));
            }

            return p;
        }
    }

    /// <summary>
    /// Delete a specific User Defined Message Subscription.
    /// </summary>
    public class DeleteUserDefinedMessageSubscriptionOptions : IOptions<UserDefinedMessageSubscriptionResource>
    {
        /// <summary>
        /// Account SID.
        /// </summary>
        public string PathAccountSid { get; set; }
        /// <summary>
        /// Call SID.
        /// </summary>
        public string PathCallSid { get; }
        /// <summary>
        /// User Defined Message Subscription SID.
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new DeleteUserDefinedMessageSubscriptionOptions
        /// </summary>
        /// <param name="pathCallSid"> Call SID. </param>
        /// <param name="pathSid"> User Defined Message Subscription SID. </param>
        public DeleteUserDefinedMessageSubscriptionOptions(string pathCallSid, string pathSid)
        {
            PathCallSid = pathCallSid;
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