/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Events
 * This is the public Twilio REST API.
 *
 * NOTE: This class is auto generated by OpenAPI Generator.
 * https://openapi-generator.tech
 * Do not edit the class manually.
 */


using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;




namespace Twilio.Rest.Events.V1.Subscription
{

    /// <summary> Add an event type to a Subscription. </summary>
    public class CreateSubscribedEventOptions : IOptions<SubscribedEventResource>
    {
        
        ///<summary> The unique SID identifier of the Subscription. </summary> 
        public string PathSubscriptionSid { get; }

        ///<summary> Type of event being subscribed to. </summary> 
        public string Type { get; }

        ///<summary> The schema version that the Subscription should use. </summary> 
        public int? SchemaVersion { get; set; }


        /// <summary> Construct a new CreateSubscribedEventOptions </summary>
        /// <param name="pathSubscriptionSid"> The unique SID identifier of the Subscription. </param>
        /// <param name="type"> Type of event being subscribed to. </param>
        public CreateSubscribedEventOptions(string pathSubscriptionSid, string type)
        {
            PathSubscriptionSid = pathSubscriptionSid;
            Type = type;
        }

        
        /// <summary> Generate the necessary parameters </summary>
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
    /// <summary> Remove an event type from a Subscription. </summary>
    public class DeleteSubscribedEventOptions : IOptions<SubscribedEventResource>
    {
        
        ///<summary> The unique SID identifier of the Subscription. </summary> 
        public string PathSubscriptionSid { get; }

        ///<summary> Type of event being subscribed to. </summary> 
        public string PathType { get; }



        /// <summary> Construct a new DeleteSubscribedEventOptions </summary>
        /// <param name="pathSubscriptionSid"> The unique SID identifier of the Subscription. </param>
        /// <param name="pathType"> Type of event being subscribed to. </param>
        public DeleteSubscribedEventOptions(string pathSubscriptionSid, string pathType)
        {
            PathSubscriptionSid = pathSubscriptionSid;
            PathType = pathType;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> Read an Event for a Subscription. </summary>
    public class FetchSubscribedEventOptions : IOptions<SubscribedEventResource>
    {
    
        ///<summary> The unique SID identifier of the Subscription. </summary> 
        public string PathSubscriptionSid { get; }

        ///<summary> Type of event being subscribed to. </summary> 
        public string PathType { get; }



        /// <summary> Construct a new FetchSubscribedEventOptions </summary>
        /// <param name="pathSubscriptionSid"> The unique SID identifier of the Subscription. </param>
        /// <param name="pathType"> Type of event being subscribed to. </param>
        public FetchSubscribedEventOptions(string pathSubscriptionSid, string pathType)
        {
            PathSubscriptionSid = pathSubscriptionSid;
            PathType = pathType;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> Retrieve a list of all Subscribed Event types for a Subscription. </summary>
    public class ReadSubscribedEventOptions : ReadOptions<SubscribedEventResource>
    {
    
        ///<summary> The unique SID identifier of the Subscription. </summary> 
        public string PathSubscriptionSid { get; }



        /// <summary> Construct a new ListSubscribedEventOptions </summary>
        /// <param name="pathSubscriptionSid"> The unique SID identifier of the Subscription. </param>
        public ReadSubscribedEventOptions(string pathSubscriptionSid)
        {
            PathSubscriptionSid = pathSubscriptionSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }

    

    }

    /// <summary> Update an Event for a Subscription. </summary>
    public class UpdateSubscribedEventOptions : IOptions<SubscribedEventResource>
    {
    
        ///<summary> The unique SID identifier of the Subscription. </summary> 
        public string PathSubscriptionSid { get; }

        ///<summary> Type of event being subscribed to. </summary> 
        public string PathType { get; }

        ///<summary> The schema version that the Subscription should use. </summary> 
        public int? SchemaVersion { get; set; }



        /// <summary> Construct a new UpdateSubscribedEventOptions </summary>
        /// <param name="pathSubscriptionSid"> The unique SID identifier of the Subscription. </param>
        /// <param name="pathType"> Type of event being subscribed to. </param>
        public UpdateSubscribedEventOptions(string pathSubscriptionSid, string pathType)
        {
            PathSubscriptionSid = pathSubscriptionSid;
            PathType = pathType;
        }

        
        /// <summary> Generate the necessary parameters </summary>
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


}

