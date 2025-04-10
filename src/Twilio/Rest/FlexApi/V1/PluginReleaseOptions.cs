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
    public class CreatePluginReleaseOptions : IOptions<PluginReleaseResource>
    {
        
        ///<summary> The SID or the Version of the Flex Plugin Configuration to release. </summary> 
        public string ConfigurationId { get; }

        ///<summary> The Flex-Metadata HTTP request header </summary> 
        public string FlexMetadata { get; set; }


        /// <summary> Construct a new CreatePluginReleaseOptions </summary>
        /// <param name="configurationId"> The SID or the Version of the Flex Plugin Configuration to release. </param>
        public CreatePluginReleaseOptions(string configurationId)
        {
            ConfigurationId = configurationId;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (ConfigurationId != null)
            {
                p.Add(new KeyValuePair<string, string>("ConfigurationId", ConfigurationId));
            }
            return p;
        }

        
    /// <summary> Generate the necessary header parameters </summary>
    public List<KeyValuePair<string, string>> GetHeaderParams()
    {
        var p = new List<KeyValuePair<string, string>>();
        if (FlexMetadata != null)
        {
            p.Add(new KeyValuePair<string, string>("Flex-Metadata", FlexMetadata));
        }
        return p;
    }

    }
    /// <summary> fetch </summary>
    public class FetchPluginReleaseOptions : IOptions<PluginReleaseResource>
    {
    
        ///<summary> The SID of the Flex Plugin Release resource to fetch. </summary> 
        public string PathSid { get; }

        ///<summary> The Flex-Metadata HTTP request header </summary> 
        public string FlexMetadata { get; set; }



        /// <summary> Construct a new FetchPluginReleaseOptions </summary>
        /// <param name="pathSid"> The SID of the Flex Plugin Release resource to fetch. </param>
        public FetchPluginReleaseOptions(string pathSid)
        {
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            return p;
        }

    
    /// <summary> Generate the necessary header parameters </summary>
    public List<KeyValuePair<string, string>> GetHeaderParams()
    {
        var p = new List<KeyValuePair<string, string>>();
        if (FlexMetadata != null)
        {
            p.Add(new KeyValuePair<string, string>("Flex-Metadata", FlexMetadata));
        }
        return p;
    }

    }


    /// <summary> read </summary>
    public class ReadPluginReleaseOptions : ReadOptions<PluginReleaseResource>
    {
    
        ///<summary> The Flex-Metadata HTTP request header </summary> 
        public string FlexMetadata { get; set; }




        
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

    
    /// <summary> Generate the necessary header parameters </summary>
    public List<KeyValuePair<string, string>> GetHeaderParams()
    {
        var p = new List<KeyValuePair<string, string>>();
        if (FlexMetadata != null)
        {
            p.Add(new KeyValuePair<string, string>("Flex-Metadata", FlexMetadata));
        }
        return p;
    }

    }

}

