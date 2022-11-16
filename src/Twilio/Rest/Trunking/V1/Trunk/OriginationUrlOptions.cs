/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Trunking
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




namespace Twilio.Rest.Trunking.V1.Trunk
{

    /// <summary> create </summary>
    public class CreateOriginationUrlOptions : IOptions<OriginationUrlResource>
    {
        
        ///<summary> The SID of the Trunk to associate the resource with. </summary> 
        public string PathTrunkSid { get; }

        ///<summary> The value that determines the relative share of the load the URI should receive compared to other URIs with the same priority. Can be an integer from 1 to 65535, inclusive, and the default is 10. URLs with higher values receive more load than those with lower ones with the same priority. </summary> 
        public int? Weight { get; }

        ///<summary> The relative importance of the URI. Can be an integer from 0 to 65535, inclusive, and the default is 10. The lowest number represents the most important URI. </summary> 
        public int? Priority { get; }

        ///<summary> Whether the URL is enabled. The default is `true`. </summary> 
        public bool? Enabled { get; }

        ///<summary> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </summary> 
        public string FriendlyName { get; }

        ///<summary> The SIP address you want Twilio to route your Origination calls to. This must be a `sip:` schema. </summary> 
        public Uri SipUrl { get; }


        /// <summary> Construct a new CreateOriginationUrlOptions </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk to associate the resource with. </param>
        /// <param name="weight"> The value that determines the relative share of the load the URI should receive compared to other URIs with the same priority. Can be an integer from 1 to 65535, inclusive, and the default is 10. URLs with higher values receive more load than those with lower ones with the same priority. </param>
        /// <param name="priority"> The relative importance of the URI. Can be an integer from 0 to 65535, inclusive, and the default is 10. The lowest number represents the most important URI. </param>
        /// <param name="enabled"> Whether the URL is enabled. The default is `true`. </param>
        /// <param name="friendlyName"> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </param>
        /// <param name="sipUrl"> The SIP address you want Twilio to route your Origination calls to. This must be a `sip:` schema. </param>
        public CreateOriginationUrlOptions(string pathTrunkSid, int? weight, int? priority, bool? enabled, string friendlyName, Uri sipUrl)
        {
            PathTrunkSid = pathTrunkSid;
            Weight = weight;
            Priority = priority;
            Enabled = enabled;
            FriendlyName = friendlyName;
            SipUrl = sipUrl;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Weight != null)
            {
                p.Add(new KeyValuePair<string, string>("Weight", Weight.ToString()));
            }
            if (Priority != null)
            {
                p.Add(new KeyValuePair<string, string>("Priority", Priority.ToString()));
            }
            if (Enabled != null)
            {
                p.Add(new KeyValuePair<string, string>("Enabled", Enabled.Value.ToString().ToLower()));
            }
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (SipUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("SipUrl", Serializers.Url(SipUrl)));
            }
            return p;
        }
        

    }
    /// <summary> delete </summary>
    public class DeleteOriginationUrlOptions : IOptions<OriginationUrlResource>
    {
        
        ///<summary> The SID of the Trunk from which to delete the OriginationUrl. </summary> 
        public string PathTrunkSid { get; }

        ///<summary> The unique string that we created to identify the OriginationUrl resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteOriginationUrlOptions </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk from which to delete the OriginationUrl. </param>
        /// <param name="pathSid"> The unique string that we created to identify the OriginationUrl resource to delete. </param>
        public DeleteOriginationUrlOptions(string pathTrunkSid, string pathSid)
        {
            PathTrunkSid = pathTrunkSid;
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
    public class FetchOriginationUrlOptions : IOptions<OriginationUrlResource>
    {
    
        ///<summary> The SID of the Trunk from which to fetch the OriginationUrl. </summary> 
        public string PathTrunkSid { get; }

        ///<summary> The unique string that we created to identify the OriginationUrl resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchOriginationUrlOptions </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk from which to fetch the OriginationUrl. </param>
        /// <param name="pathSid"> The unique string that we created to identify the OriginationUrl resource to fetch. </param>
        public FetchOriginationUrlOptions(string pathTrunkSid, string pathSid)
        {
            PathTrunkSid = pathTrunkSid;
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
    public class ReadOriginationUrlOptions : ReadOptions<OriginationUrlResource>
    {
    
        ///<summary> The SID of the Trunk from which to read the OriginationUrl. </summary> 
        public string PathTrunkSid { get; }



        /// <summary> Construct a new ListOriginationUrlOptions </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk from which to read the OriginationUrl. </param>
        public ReadOriginationUrlOptions(string pathTrunkSid)
        {
            PathTrunkSid = pathTrunkSid;
        }

        
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

    /// <summary> update </summary>
    public class UpdateOriginationUrlOptions : IOptions<OriginationUrlResource>
    {
    
        ///<summary> The SID of the Trunk from which to update the OriginationUrl. </summary> 
        public string PathTrunkSid { get; }

        ///<summary> The unique string that we created to identify the OriginationUrl resource to update. </summary> 
        public string PathSid { get; }

        ///<summary> The value that determines the relative share of the load the URI should receive compared to other URIs with the same priority. Can be an integer from 1 to 65535, inclusive, and the default is 10. URLs with higher values receive more load than those with lower ones with the same priority. </summary> 
        public int? Weight { get; set; }

        ///<summary> The relative importance of the URI. Can be an integer from 0 to 65535, inclusive, and the default is 10. The lowest number represents the most important URI. </summary> 
        public int? Priority { get; set; }

        ///<summary> Whether the URL is enabled. The default is `true`. </summary> 
        public bool? Enabled { get; set; }

        ///<summary> A descriptive string that you create to describe the resource. It can be up to 64 characters long. </summary> 
        public string FriendlyName { get; set; }

        ///<summary> The SIP address you want Twilio to route your Origination calls to. This must be a `sip:` schema. `sips` is NOT supported. </summary> 
        public Uri SipUrl { get; set; }



        /// <summary> Construct a new UpdateOriginationUrlOptions </summary>
        /// <param name="pathTrunkSid"> The SID of the Trunk from which to update the OriginationUrl. </param>
        /// <param name="pathSid"> The unique string that we created to identify the OriginationUrl resource to update. </param>
        public UpdateOriginationUrlOptions(string pathTrunkSid, string pathSid)
        {
            PathTrunkSid = pathTrunkSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (Weight != null)
            {
                p.Add(new KeyValuePair<string, string>("Weight", Weight.ToString()));
            }
            if (Priority != null)
            {
                p.Add(new KeyValuePair<string, string>("Priority", Priority.ToString()));
            }
            if (Enabled != null)
            {
                p.Add(new KeyValuePair<string, string>("Enabled", Enabled.Value.ToString().ToLower()));
            }
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            if (SipUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("SipUrl", Serializers.Url(SipUrl)));
            }
            return p;
        }
        

    }


}

