/// This code was generated by
/// \ / _    _  _|   _  _
///  | (_)\/(_)(_|\/| |(/_  v1.0.0
///       /       /

using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Events.V1.Subscription
{

    /// <summary>
    /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
    ///
    /// Retrieve a list of all Subscribed Event types for a Subscription.
    /// </summary>
    public class ReadSubscribedEventOptions : ReadOptions<SubscribedEventResource>
    {
        /// <summary>
        /// Subscription SID.
        /// </summary>
        public string PathSubscriptionSid { get; }

        /// <summary>
        /// Construct a new ReadSubscribedEventOptions
        /// </summary>
        /// <param name="pathSubscriptionSid"> Subscription SID. </param>
        public ReadSubscribedEventOptions(string pathSubscriptionSid)
        {
            PathSubscriptionSid = pathSubscriptionSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
    ///
    /// Create a new Subscribed Event type for the subscription
    /// </summary>
    public class CreateSubscribedEventOptions : IOptions<SubscribedEventResource>
    {
        /// <summary>
        /// Subscription SID.
        /// </summary>
        public string PathSubscriptionSid { get; }
        /// <summary>
        /// Type of event being subscribed to.
        /// </summary>
        public string Type { get; }
        /// <summary>
        /// The schema version that the subscription should use.
        /// </summary>
        public int? SchemaVersion { get; set; }

        /// <summary>
        /// Construct a new CreateSubscribedEventOptions
        /// </summary>
        /// <param name="pathSubscriptionSid"> Subscription SID. </param>
        /// <param name="type"> Type of event being subscribed to. </param>
        public CreateSubscribedEventOptions(string pathSubscriptionSid, string type)
        {
            PathSubscriptionSid = pathSubscriptionSid;
            Type = type;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Type != null)
            {
                p.Add(new KeyValuePair<string, string>("Type", Type));
            }

            if (SchemaVersion != null)
            {
                p.Add(new KeyValuePair<string, string>("SchemaVersion", SchemaVersion.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
    ///
    /// Read an Event for a Subscription.
    /// </summary>
    public class FetchSubscribedEventOptions : IOptions<SubscribedEventResource>
    {
        /// <summary>
        /// Subscription SID.
        /// </summary>
        public string PathSubscriptionSid { get; }
        /// <summary>
        /// Type of event being subscribed to.
        /// </summary>
        public string PathType { get; }

        /// <summary>
        /// Construct a new FetchSubscribedEventOptions
        /// </summary>
        /// <param name="pathSubscriptionSid"> Subscription SID. </param>
        /// <param name="pathType"> Type of event being subscribed to. </param>
        public FetchSubscribedEventOptions(string pathSubscriptionSid, string pathType)
        {
            PathSubscriptionSid = pathSubscriptionSid;
            PathType = pathType;
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

    /// <summary>
    /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
    ///
    /// Update an Event for a Subscription.
    /// </summary>
    public class UpdateSubscribedEventOptions : IOptions<SubscribedEventResource>
    {
        /// <summary>
        /// Subscription SID.
        /// </summary>
        public string PathSubscriptionSid { get; }
        /// <summary>
        /// Type of event being subscribed to.
        /// </summary>
        public string PathType { get; }
        /// <summary>
        /// The schema version that the subscription should use.
        /// </summary>
        public int? SchemaVersion { get; set; }

        /// <summary>
        /// Construct a new UpdateSubscribedEventOptions
        /// </summary>
        /// <param name="pathSubscriptionSid"> Subscription SID. </param>
        /// <param name="pathType"> Type of event being subscribed to. </param>
        public UpdateSubscribedEventOptions(string pathSubscriptionSid, string pathType)
        {
            PathSubscriptionSid = pathSubscriptionSid;
            PathType = pathType;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (SchemaVersion != null)
            {
                p.Add(new KeyValuePair<string, string>("SchemaVersion", SchemaVersion.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// PLEASE NOTE that this class contains beta products that are subject to change. Use them with caution.
    ///
    /// Remove an event type from a subscription.
    /// </summary>
    public class DeleteSubscribedEventOptions : IOptions<SubscribedEventResource>
    {
        /// <summary>
        /// Subscription SID.
        /// </summary>
        public string PathSubscriptionSid { get; }
        /// <summary>
        /// Type of event being subscribed to.
        /// </summary>
        public string PathType { get; }

        /// <summary>
        /// Construct a new DeleteSubscribedEventOptions
        /// </summary>
        /// <param name="pathSubscriptionSid"> Subscription SID. </param>
        /// <param name="pathType"> Type of event being subscribed to. </param>
        public DeleteSubscribedEventOptions(string pathSubscriptionSid, string pathType)
        {
            PathSubscriptionSid = pathSubscriptionSid;
            PathType = pathType;
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