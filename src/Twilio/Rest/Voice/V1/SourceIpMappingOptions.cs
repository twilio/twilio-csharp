/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Voice
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




namespace Twilio.Rest.Voice.V1
{

    /// <summary> create </summary>
    public class CreateSourceIpMappingOptions : IOptions<SourceIpMappingResource>
    {
        
        ///<summary> The Twilio-provided string that uniquely identifies the IP Record resource to map from. </summary> 
        public string IpRecordSid { get; }

        ///<summary> The SID of the SIP Domain that the IP Record should be mapped to. </summary> 
        public string SipDomainSid { get; }


        /// <summary> Construct a new CreateSourceIpMappingOptions </summary>
        /// <param name="ipRecordSid"> The Twilio-provided string that uniquely identifies the IP Record resource to map from. </param>
        /// <param name="sipDomainSid"> The SID of the SIP Domain that the IP Record should be mapped to. </param>
        public CreateSourceIpMappingOptions(string ipRecordSid, string sipDomainSid)
        {
            IpRecordSid = ipRecordSid;
            SipDomainSid = sipDomainSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (IpRecordSid != null)
            {
                p.Add(new KeyValuePair<string, string>("IpRecordSid", IpRecordSid));
            }
            if (SipDomainSid != null)
            {
                p.Add(new KeyValuePair<string, string>("SipDomainSid", SipDomainSid));
            }
            return p;
        }

        

    }
    /// <summary> delete </summary>
    public class DeleteSourceIpMappingOptions : IOptions<SourceIpMappingResource>
    {
        
        ///<summary> The Twilio-provided string that uniquely identifies the IP Record resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteSourceIpMappingOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the IP Record resource to delete. </param>
        public DeleteSourceIpMappingOptions(string pathSid)
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


    /// <summary> fetch </summary>
    public class FetchSourceIpMappingOptions : IOptions<SourceIpMappingResource>
    {
    
        ///<summary> The Twilio-provided string that uniquely identifies the IP Record resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchSourceIpMappingOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the IP Record resource to fetch. </param>
        public FetchSourceIpMappingOptions(string pathSid)
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


    /// <summary> read </summary>
    public class ReadSourceIpMappingOptions : ReadOptions<SourceIpMappingResource>
    {
    



        
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

    /// <summary> update </summary>
    public class UpdateSourceIpMappingOptions : IOptions<SourceIpMappingResource>
    {
    
        ///<summary> The Twilio-provided string that uniquely identifies the IP Record resource to update. </summary> 
        public string PathSid { get; }

        ///<summary> The SID of the SIP Domain that the IP Record should be mapped to. </summary> 
        public string SipDomainSid { get; }



        /// <summary> Construct a new UpdateSourceIpMappingOptions </summary>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the IP Record resource to update. </param>
        /// <param name="sipDomainSid"> The SID of the SIP Domain that the IP Record should be mapped to. </param>
        public UpdateSourceIpMappingOptions(string pathSid, string sipDomainSid)
        {
            PathSid = pathSid;
            SipDomainSid = sipDomainSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (SipDomainSid != null)
            {
                p.Add(new KeyValuePair<string, string>("SipDomainSid", SipDomainSid));
            }
            return p;
        }

        

    }


}

