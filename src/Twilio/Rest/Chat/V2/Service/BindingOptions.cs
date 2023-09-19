/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Chat
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
using System.Linq;



namespace Twilio.Rest.Chat.V2.Service
{
    /// <summary> delete </summary>
    public class DeleteBindingOptions : IOptions<BindingResource>
    {
        
        ///<summary> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to delete the Binding resource from. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The SID of the Binding resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteBindingOptions </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to delete the Binding resource from. </param>
        /// <param name="pathSid"> The SID of the Binding resource to delete. </param>
        public DeleteBindingOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
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
    public class FetchBindingOptions : IOptions<BindingResource>
    {
    
        ///<summary> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to fetch the Binding resource from. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The SID of the Binding resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchBindingOptions </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to fetch the Binding resource from. </param>
        /// <param name="pathSid"> The SID of the Binding resource to fetch. </param>
        public FetchBindingOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
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
    public class ReadBindingOptions : ReadOptions<BindingResource>
    {
    
        ///<summary> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to read the Binding resources from. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The push technology used by the Binding resources to read.  Can be: `apn`, `gcm`, or `fcm`.  See [push notification configuration](https://www.twilio.com/docs/chat/push-notification-configuration) for more info. </summary> 
        public List<BindingResource.BindingTypeEnum> BindingType { get; set; }

        ///<summary> The [User](https://www.twilio.com/docs/chat/rest/user-resource)'s `identity` value of the resources to read. See [access tokens](https://www.twilio.com/docs/chat/create-tokens) for more details. </summary> 
        public List<string> Identity { get; set; }



        /// <summary> Construct a new ListBindingOptions </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to read the Binding resources from. </param>
        public ReadBindingOptions(string pathServiceSid)
        {
            PathServiceSid = pathServiceSid;
            BindingType = new List<BindingResource.BindingTypeEnum>();
            Identity = new List<string>();
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (BindingType != null)
            {
                p.AddRange(BindingType.Select(BindingType => new KeyValuePair<string, string>("BindingType", BindingType.ToString())));
            }
            if (Identity != null)
            {
                p.AddRange(Identity.Select(Identity => new KeyValuePair<string, string>("Identity", Identity)));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }
        

    }

}

