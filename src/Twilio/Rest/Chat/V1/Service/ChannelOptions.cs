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



namespace Twilio.Rest.Chat.V1.Service
{

    /// <summary> create </summary>
    public class CreateChannelOptions : IOptions<ChannelResource>
    {
        
        ///<summary> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to create the resource under. </summary> 
        public string PathServiceSid { get; }

        ///<summary> A descriptive string that you create to describe the new resource. It can be up to 64 characters long. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> An application-defined string that uniquely identifies the resource. It can be used to address the resource in place of the resource's `sid` in the URL. This value must be 64 characters or less in length and be unique within the Service. </summary> 
        public string UniqueName { get; set; }

        ///<summary> A valid JSON string that contains application-specific data. </summary> 
        public string Attributes { get; set; }

        
        public ChannelResource.ChannelTypeEnum Type { get; set; }


        /// <summary> Construct a new CreateChannelOptions </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to create the resource under. </param>

        public CreateChannelOptions(string pathServiceSid)
        {
            PathServiceSid = pathServiceSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (UniqueName != null)
            {
                p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
            }
            if (Attributes != null)
            {
                p.Add(new KeyValuePair<string, string>("Attributes", Attributes));
            }
            if (Type != null)
            {
                p.Add(new KeyValuePair<string, string>("Type", Type.ToString()));
            }
            return p;
        }
        

    }
    /// <summary> delete </summary>
    public class DeleteChannelOptions : IOptions<ChannelResource>
    {
        
        ///<summary> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to delete the resource from. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the Channel resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteChannelOptions </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to delete the resource from. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Channel resource to delete. </param>

        public DeleteChannelOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
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
    
        ///<summary> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to fetch the resource from. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the Channel resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchChannelOptions </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to fetch the resource from. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Channel resource to fetch. </param>

        public FetchChannelOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
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
    
        ///<summary> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to read the resources from. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The visibility of the Channels to read. Can be: `public` or `private` and defaults to `public`. </summary> 
        public List<ChannelResource.ChannelTypeEnum> Type { get; set; }



        /// <summary> Construct a new ListChannelOptions </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to read the resources from. </param>

        public ReadChannelOptions(string pathServiceSid)
        {
            PathServiceSid = pathServiceSid;
            Type = new List<ChannelResource.ChannelTypeEnum>();
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Type != null)
            {
                p.AddRange(Type.Select(Type => new KeyValuePair<string, string>("Type", Type.ToString())));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }
        

    }

    /// <summary> update </summary>
    public class UpdateChannelOptions : IOptions<ChannelResource>
    {
    
        ///<summary> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to update the resource from. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the Channel resource to update. </summary> 
        public string PathSid { get; }

        ///<summary> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> An application-defined string that uniquely identifies the resource. It can be used to address the resource in place of the resource's `sid` in the URL. This value must be 64 characters or less in length and be unique within the Service. </summary> 
        public string UniqueName { get; set; }

        ///<summary> A valid JSON string that contains application-specific data. </summary> 
        public string Attributes { get; set; }



        /// <summary> Construct a new UpdateChannelOptions </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/api/chat/rest/services) to update the resource from. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Channel resource to update. </param>

        public UpdateChannelOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (UniqueName != null)
            {
                p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
            }
            if (Attributes != null)
            {
                p.Add(new KeyValuePair<string, string>("Attributes", Attributes));
            }
            return p;
        }
        

    }


}

