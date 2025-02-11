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
    public class CreateDestinationAlphaSenderOptions : IOptions<DestinationAlphaSenderResource>
    {
        
        ///<summary> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to create the resource under. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The Alphanumeric Sender ID string. Can be up to 11 characters long. Valid characters are A-Z, a-z, 0-9, space, hyphen `-`, plus `+`, underscore `_` and ampersand `&`. This value cannot contain only numbers. </summary> 
        public string AlphaSender { get; }

        ///<summary> The Optional Two Character ISO Country Code the Alphanumeric Sender ID will be used for. If the IsoCountryCode is not provided, a default Alpha Sender will be created that can be used across all countries. </summary> 
        public string IsoCountryCode { get; set; }


        /// <summary> Construct a new CreateDestinationAlphaSenderOptions </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to create the resource under. </param>
        /// <param name="alphaSender"> The Alphanumeric Sender ID string. Can be up to 11 characters long. Valid characters are A-Z, a-z, 0-9, space, hyphen `-`, plus `+`, underscore `_` and ampersand `&`. This value cannot contain only numbers. </param>
        public CreateDestinationAlphaSenderOptions(string pathServiceSid, string alphaSender)
        {
            PathServiceSid = pathServiceSid;
            AlphaSender = alphaSender;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (AlphaSender != null)
            {
                p.Add(new KeyValuePair<string, string>("AlphaSender", AlphaSender));
            }
            if (IsoCountryCode != null)
            {
                p.Add(new KeyValuePair<string, string>("IsoCountryCode", IsoCountryCode));
            }
            return p;
        }

        

    }
    /// <summary> delete </summary>
    public class DeleteDestinationAlphaSenderOptions : IOptions<DestinationAlphaSenderResource>
    {
        
        ///<summary> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to delete the resource from. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The SID of the AlphaSender resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteDestinationAlphaSenderOptions </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to delete the resource from. </param>
        /// <param name="pathSid"> The SID of the AlphaSender resource to delete. </param>
        public DeleteDestinationAlphaSenderOptions(string pathServiceSid, string pathSid)
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
    public class FetchDestinationAlphaSenderOptions : IOptions<DestinationAlphaSenderResource>
    {
    
        ///<summary> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to fetch the resource from. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The SID of the AlphaSender resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchDestinationAlphaSenderOptions </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to fetch the resource from. </param>
        /// <param name="pathSid"> The SID of the AlphaSender resource to fetch. </param>
        public FetchDestinationAlphaSenderOptions(string pathServiceSid, string pathSid)
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
    public class ReadDestinationAlphaSenderOptions : ReadOptions<DestinationAlphaSenderResource>
    {
    
        ///<summary> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to read the resources from. </summary> 
        public string PathServiceSid { get; }



        /// <summary> Construct a new ListDestinationAlphaSenderOptions </summary>
        /// <param name="pathServiceSid"> The SID of the [Service](https://www.twilio.com/docs/chat/rest/service-resource) to read the resources from. </param>
        public ReadDestinationAlphaSenderOptions(string pathServiceSid)
        {
            PathServiceSid = pathServiceSid;
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

