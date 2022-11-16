/*
 * This code was generated by
 * ___ _ _ _ _ _    _ ____    ____ ____ _    ____ ____ _  _ ____ ____ ____ ___ __   __
 *  |  | | | | |    | |  | __ |  | |__| | __ | __ |___ |\ | |___ |__/ |__|  | |  | |__/
 *  |  |_|_| | |___ | |__|    |__| |  | |    |__] |___ | \| |___ |  \ |  |  | |__| |  \
 *
 * Twilio - Proxy
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



namespace Twilio.Rest.Proxy.V1.Service
{

    /// <summary> Create a new Session </summary>
    public class CreateSessionOptions : IOptions<SessionResource>
    {
        
        ///<summary> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) resource. </summary> 
        public string PathServiceSid { get; }

        ///<summary> An application-defined string that uniquely identifies the resource. This value must be 191 characters or fewer in length and be unique. **This value should not have PII.** </summary> 
        public string UniqueName { get; set; }

        ///<summary> The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date when the Session should expire. If this is value is present, it overrides the `ttl` value. </summary> 
        public DateTime? DateExpiry { get; set; }

        ///<summary> The time, in seconds, when the session will expire. The time is measured from the last Session create or the Session's last Interaction. </summary> 
        public int? Ttl { get; set; }

        
        public SessionResource.ModeEnum Mode { get; set; }

        
        public SessionResource.StatusEnum Status { get; set; }

        ///<summary> The Participant objects to include in the new session. </summary> 
        public List<object> Participants { get; set; }


        /// <summary> Construct a new CreateSessionOptions </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) resource. </param>
        public CreateSessionOptions(string pathServiceSid)
        {
            PathServiceSid = pathServiceSid;
            Participants = new List<object>();
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (UniqueName != null)
            {
                p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
            }
            if (DateExpiry != null)
            {
                p.Add(new KeyValuePair<string, string>("DateExpiry", Serializers.DateTimeIso8601(DateExpiry)));
            }
            if (Ttl != null)
            {
                p.Add(new KeyValuePair<string, string>("Ttl", Ttl.ToString()));
            }
            if (Mode != null)
            {
                p.Add(new KeyValuePair<string, string>("Mode", Mode.ToString()));
            }
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            if (Participants != null)
            {
                p.AddRange(Participants.Select(Participants => new KeyValuePair<string, string>("Participants", Serializers.JsonObject(Participants))));
            }
            return p;
        }
        

    }
    /// <summary> Delete a specific Session. </summary>
    public class DeleteSessionOptions : IOptions<SessionResource>
    {
        
        ///<summary> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the resource to delete. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the Session resource to delete. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new DeleteSessionOptions </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the resource to delete. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Session resource to delete. </param>
        public DeleteSessionOptions(string pathServiceSid, string pathSid)
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


    /// <summary> Fetch a specific Session. </summary>
    public class FetchSessionOptions : IOptions<SessionResource>
    {
    
        ///<summary> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the resource to fetch. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the Session resource to fetch. </summary> 
        public string PathSid { get; }



        /// <summary> Construct a new FetchSessionOptions </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the resource to fetch. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Session resource to fetch. </param>
        public FetchSessionOptions(string pathServiceSid, string pathSid)
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


    /// <summary> Retrieve a list of all Sessions for the Service. A maximum of 100 records will be returned per page. </summary>
    public class ReadSessionOptions : ReadOptions<SessionResource>
    {
    
        ///<summary> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the resource to read. </summary> 
        public string PathServiceSid { get; }



        /// <summary> Construct a new ListSessionOptions </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the resource to read. </param>
        public ReadSessionOptions(string pathServiceSid)
        {
            PathServiceSid = pathServiceSid;
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

    /// <summary> Update a specific Session. </summary>
    public class UpdateSessionOptions : IOptions<SessionResource>
    {
    
        ///<summary> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the resource to update. </summary> 
        public string PathServiceSid { get; }

        ///<summary> The Twilio-provided string that uniquely identifies the Session resource to update. </summary> 
        public string PathSid { get; }

        ///<summary> The [ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) date when the Session should expire. If this is value is present, it overrides the `ttl` value. </summary> 
        public DateTime? DateExpiry { get; set; }

        ///<summary> The time, in seconds, when the session will expire. The time is measured from the last Session create or the Session's last Interaction. </summary> 
        public int? Ttl { get; set; }

        
        public SessionResource.StatusEnum Status { get; set; }



        /// <summary> Construct a new UpdateSessionOptions </summary>
        /// <param name="pathServiceSid"> The SID of the parent [Service](https://www.twilio.com/docs/proxy/api/service) of the resource to update. </param>
        /// <param name="pathSid"> The Twilio-provided string that uniquely identifies the Session resource to update. </param>
        public UpdateSessionOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathSid = pathSid;
        }

        
        /// <summary> Generate the necessary parameters </summary>
        public  List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();

            if (DateExpiry != null)
            {
                p.Add(new KeyValuePair<string, string>("DateExpiry", Serializers.DateTimeIso8601(DateExpiry)));
            }
            if (Ttl != null)
            {
                p.Add(new KeyValuePair<string, string>("Ttl", Ttl.ToString()));
            }
            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }
            return p;
        }
        

    }


}

