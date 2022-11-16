/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Flex
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




namespace Twilio.Rest.FlexApi.V1
{

    /// <summary> create </summary>
    public class CreateChannelOptions : IOptions<ChannelResource>
    {
        
        ///<summary> The SID of the Flex Flow. </summary> 
        public string FlexFlowSid { get; }

        ///<summary> The `identity` value that uniquely identifies the new resource's chat User. </summary> 
        public string Identity { get; }

        ///<summary> The chat participant's friendly name. </summary> 
        public string ChatUserFriendlyName { get; }

        ///<summary> The chat channel's friendly name. </summary> 
        public string ChatFriendlyName { get; }

        ///<summary> The Target Contact Identity, for example the phone number of an SMS. </summary> 
        public string Target { get; set; }

        ///<summary> The chat channel's unique name. </summary> 
        public string ChatUniqueName { get; set; }

        ///<summary> The pre-engagement data. </summary> 
        public string PreEngagementData { get; set; }

        ///<summary> The SID of the TaskRouter Task. Only valid when integration type is `task`. `null` for integration types `studio` & `external` </summary> 
        public string TaskSid { get; set; }

        ///<summary> The Task attributes to be added for the TaskRouter Task. </summary> 
        public string TaskAttributes { get; set; }

        ///<summary> Whether to create the channel as long-lived. </summary> 
        public bool? LongLived { get; set; }


        /// <summary> Construct a new CreateChannelOptions </summary>
        /// <param name="flexFlowSid"> The SID of the Flex Flow. </param>
        /// <param name="identity"> The `identity` value that uniquely identifies the new resource's chat User. </param>
        /// <param name="chatUserFriendlyName"> The chat participant's friendly name. </param>
        /// <param name="chatFriendlyName"> The chat channel's friendly name. </param>

        public CreateChannelOptions(string flexFlowSid, string identity, string chatUserFriendlyName, string chatFriendlyName)
        {
            FlexFlowSid = flexFlowSid;
            Identity = identity;
            ChatUserFriendlyName = chatUserFriendlyName;
            ChatFriendlyName = chatFriendlyName;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FlexFlowSid != null)
            {
                p.Add(new KeyValuePair<string, string>("FlexFlowSid", FlexFlowSid));
            }
            if (Identity != null)
            {
                p.Add(new KeyValuePair<string, string>("Identity", Identity));
            }
            if (ChatUserFriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("ChatUserFriendlyName", ChatUserFriendlyName));
            }
            if (ChatFriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("ChatFriendlyName", ChatFriendlyName));
            }
            if (Target != null)
            {
                p.Add(new KeyValuePair<string, string>("Target", Target));
            }
            if (ChatUniqueName != null)
            {
                p.Add(new KeyValuePair<string, string>("ChatUniqueName", ChatUniqueName));
            }
            if (PreEngagementData != null)
            {
                p.Add(new KeyValuePair<string, string>("PreEngagementData", PreEngagementData));
            }
            if (TaskSid != null)
            {
                p.Add(new KeyValuePair<string, string>("TaskSid", TaskSid));
            }
            if (TaskAttributes != null)
            {
                p.Add(new KeyValuePair<string, string>("TaskAttributes", TaskAttributes));
            }
            if (LongLived != null)
            {
                p.Add(new KeyValuePair<string, string>("LongLived", LongLived.Value.ToString().ToLower()));
            }
            return p;
        }
        

    }
    /// <summary> delete </summary>
    public class DeleteChannelOptions : IOptions<ChannelResource>
    {
        
        ///<summary> The SID of the Flex chat channel resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteChannelOptions </summary>
        /// <param name="pathSid"> The SID of the Flex chat channel resource to delete. </param>

        public DeleteChannelOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> fetch </summary>
    public class FetchChannelOptions : IOptions<ChannelResource>
    {
    
        ///<summary> The SID of the Flex chat channel resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchChannelOptions </summary>
        /// <param name="pathSid"> The SID of the Flex chat channel resource to fetch. </param>

        public FetchChannelOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }
        

    }


    /// <summary> read </summary>
    public class ReadChannelOptions : ReadOptions<ChannelResource>
    {
    



        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
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

