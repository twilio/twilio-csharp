/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Messaging
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




namespace Twilio.Rest.Messaging.V1.Service
{

    /// <summary> create </summary>
    public class CreateChannelSenderOptions : IOptions<ChannelSenderResource>
    {
        
        ///<summary> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to create the resource under. </summary> 
        public string PathMessagingServiceSid { get; }

        ///<summary> The SID of the Channel Sender being added to the Service. </summary> 
        public string Sid { get; }


        /// <summary> Construct a new CreateChannelSenderOptions </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to create the resource under. </param>
        /// <param name="sid"> The SID of the Channel Sender being added to the Service. </param>
        public CreateChannelSenderOptions(string pathMessagingServiceSid, string sid)
        {
            PathMessagingServiceSid = pathMessagingServiceSid;
            Sid = sid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Sid != null)
            {
                p.Add(new KeyValuePair<string, string>("Sid", Sid));
            }
            return p;
        }

        

    }
    /// <summary> delete </summary>
    public class DeleteChannelSenderOptions : IOptions<ChannelSenderResource>
    {
        
        ///<summary> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to delete the resource from. </summary> 
        public string PathMessagingServiceSid { get; }

        ///<summary> The SID of the Channel Sender resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteChannelSenderOptions </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to delete the resource from. </param>
        /// <param name="pathSid"> The SID of the Channel Sender resource to delete. </param>
        public DeleteChannelSenderOptions(string pathMessagingServiceSid, string pathSid)
        {
            PathMessagingServiceSid = pathMessagingServiceSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> fetch </summary>
    public class FetchChannelSenderOptions : IOptions<ChannelSenderResource>
    {
    
        ///<summary> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to fetch the resource from. </summary> 
        public string PathMessagingServiceSid { get; }

        ///<summary> The SID of the ChannelSender resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchChannelSenderOptions </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to fetch the resource from. </param>
        /// <param name="pathSid"> The SID of the ChannelSender resource to fetch. </param>
        public FetchChannelSenderOptions(string pathMessagingServiceSid, string pathSid)
        {
            PathMessagingServiceSid = pathMessagingServiceSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> read </summary>
    public class ReadChannelSenderOptions : ReadOptions<ChannelSenderResource>
    {
    
        ///<summary> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to read the resources from. </summary> 
        public string PathMessagingServiceSid { get; }



        /// <summary> Construct a new ListChannelSenderOptions </summary>
        /// <param name="pathMessagingServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to read the resources from. </param>
        public ReadChannelSenderOptions(string pathMessagingServiceSid)
        {
            PathMessagingServiceSid = pathMessagingServiceSid;
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

}

