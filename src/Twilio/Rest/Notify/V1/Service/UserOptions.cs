using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;

namespace Twilio.Rest.Notify.V1.Service 
{

    /// <summary>
    /// CreateUserOptions
    /// </summary>
    public class CreateUserOptions : IOptions<UserResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The identity
        /// </summary>
        public string Identity { get; }
        /// <summary>
        /// The segment
        /// </summary>
        public List<string> Segment { get; set; }

        /// <summary>
        /// Construct a new CreateUserOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="identity"> The identity </param>
        public CreateUserOptions(string pathServiceSid, string identity)
        {
            PathServiceSid = pathServiceSid;
            Identity = identity;
            Segment = new List<string>();
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Identity != null)
            {
                p.Add(new KeyValuePair<string, string>("Identity", Identity));
            }

            if (Segment != null)
            {
                p.AddRange(Segment.Select(prop => new KeyValuePair<string, string>("Segment", prop)));
            }

            return p;
        }
    }

    /// <summary>
    /// DeleteUserOptions
    /// </summary>
    public class DeleteUserOptions : IOptions<UserResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The identity
        /// </summary>
        public string PathIdentity { get; }

        /// <summary>
        /// Construct a new DeleteUserOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathIdentity"> The identity </param>
        public DeleteUserOptions(string pathServiceSid, string pathIdentity)
        {
            PathServiceSid = pathServiceSid;
            PathIdentity = pathIdentity;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    /// <summary>
    /// FetchUserOptions
    /// </summary>
    public class FetchUserOptions : IOptions<UserResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The identity
        /// </summary>
        public string PathIdentity { get; }

        /// <summary>
        /// Construct a new FetchUserOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        /// <param name="pathIdentity"> The identity </param>
        public FetchUserOptions(string pathServiceSid, string pathIdentity)
        {
            PathServiceSid = pathServiceSid;
            PathIdentity = pathIdentity;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            return p;
        }
    }

    /// <summary>
    /// ReadUserOptions
    /// </summary>
    public class ReadUserOptions : ReadOptions<UserResource> 
    {
        /// <summary>
        /// The service_sid
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// The identity
        /// </summary>
        public List<string> Identity { get; set; }
        /// <summary>
        /// The segment
        /// </summary>
        public string Segment { get; set; }

        /// <summary>
        /// Construct a new ReadUserOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> The service_sid </param>
        public ReadUserOptions(string pathServiceSid)
        {
            PathServiceSid = pathServiceSid;
            Identity = new List<string>();
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (Identity != null)
            {
                p.AddRange(Identity.Select(prop => new KeyValuePair<string, string>("Identity", prop)));
            }

            if (Segment != null)
            {
                p.Add(new KeyValuePair<string, string>("Segment", Segment));
            }

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

}