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




namespace Twilio.Rest.Messaging.V2
{

    /// <summary> Create a new sender of WhatsApp. </summary>
    public class CreateChannelsSenderOptions : IOptions<ChannelsSenderResource>
    {
        
        
        public ChannelsSenderResource.MessagingV2ChannelsSenderRequestsCreate MessagingV2ChannelsSenderRequestsCreate { get; }


        /// <summary> Construct a new CreateChannelsSenderOptions </summary>
        /// <param name="messagingV2ChannelsSenderRequestsCreate">  </param>
        public CreateChannelsSenderOptions(ChannelsSenderResource.MessagingV2ChannelsSenderRequestsCreate messagingV2ChannelsSenderRequestsCreate)
        {
            MessagingV2ChannelsSenderRequestsCreate = messagingV2ChannelsSenderRequestsCreate;
        }

        
        /// <summary> Generate the request body </summary>
        public string GetBody()
        {
            string body = "";

            if (MessagingV2ChannelsSenderRequestsCreate != null)
            {
                body = ChannelsSenderResource.ToJson(MessagingV2ChannelsSenderRequestsCreate);
            }
            return body;
        }
        

    }
    /// <summary> Delete a specific sender by its unique identifier. </summary>
    public class DeleteChannelsSenderOptions : IOptions<ChannelsSenderResource>
    {
        
        ///<summary> A 34 character string that uniquely identifies this Sender. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteChannelsSenderOptions </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Sender. </param>
        public DeleteChannelsSenderOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> Retrieve details of a specific sender by its unique identifier. </summary>
    public class FetchChannelsSenderOptions : IOptions<ChannelsSenderResource>
    {
    
        ///<summary> A 34 character string that uniquely identifies this Sender. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchChannelsSenderOptions </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Sender. </param>
        public FetchChannelsSenderOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    

    }


    /// <summary> Get a list of Senders for an account. </summary>
    public class ReadChannelsSenderOptions : ReadOptions<ChannelsSenderResource>
    {
    
        
        public string Channel { get; }



        /// <summary> Construct a new ListChannelsSenderOptions </summary>
        /// <param name="channel">  </param>
        public ReadChannelsSenderOptions(string channel)
        {
            Channel = channel;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Channel != null)
            {
                p.Add(new KeyValuePair<string, string>("Channel", Channel));
            }
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            return p;
        }

    

    }

    /// <summary> Update a specific sender information like OTP Code, Webhook, Profile information. </summary>
    public class UpdateChannelsSenderOptions : IOptions<ChannelsSenderResource>
    {
    
        ///<summary> A 34 character string that uniquely identifies this Sender. </summary> 
        public string PathSid { get; }

        
        public ChannelsSenderResource.MessagingV2ChannelsSenderRequestsUpdate MessagingV2ChannelsSenderRequestsUpdate { get; set; }



        /// <summary> Construct a new UpdateChannelsSenderOptions </summary>
        /// <param name="pathSid"> A 34 character string that uniquely identifies this Sender. </param>
        public UpdateChannelsSenderOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the request body </summary>
        public string GetBody()
        {
            string body = "";

            if (MessagingV2ChannelsSenderRequestsUpdate != null)
            {
                body = ChannelsSenderResource.ToJson(MessagingV2ChannelsSenderRequestsUpdate);
            }
            return body;
        }
        

    }


}

