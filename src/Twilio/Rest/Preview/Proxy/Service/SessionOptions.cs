using System;
using System.Collections.Generic;
using System.Linq;
using Twilio.Base;

namespace Twilio.Rest.Preview.Proxy.Service 
{

    /// <summary>
    /// Fetch a specific Session.
    /// </summary>
    public class FetchSessionOptions : IOptions<SessionResource> 
    {
        /// <summary>
        /// Service Sid.
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// A string that uniquely identifies this Session.
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new FetchSessionOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSid"> A string that uniquely identifies this Session. </param>
        public FetchSessionOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathSid = pathSid;
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
    /// Retrieve a list of all Sessions for a Service.
    /// </summary>
    public class ReadSessionOptions : ReadOptions<SessionResource> 
    {
        /// <summary>
        /// Service Sid.
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// A unique, developer assigned name of this Session.
        /// </summary>
        public string UniqueName { get; set; }
        /// <summary>
        /// The Status of this Session
        /// </summary>
        public SessionResource.StatusEnum Status { get; set; }

        /// <summary>
        /// Construct a new ReadSessionOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        public ReadSessionOptions(string pathServiceSid)
        {
            PathServiceSid = pathServiceSid;
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (UniqueName != null)
            {
                p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
            }

            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }

            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }

            return p;
        }
    }

    /// <summary>
    /// Start a new Session
    /// </summary>
    public class CreateSessionOptions : IOptions<SessionResource> 
    {
        /// <summary>
        /// Service Sid.
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// A unique, developer assigned name of this Session.
        /// </summary>
        public string UniqueName { get; set; }
        /// <summary>
        /// How long will this session stay open, in seconds.
        /// </summary>
        public int? Ttl { get; set; }
        /// <summary>
        /// The Status of this Session
        /// </summary>
        public SessionResource.StatusEnum Status { get; set; }
        /// <summary>
        /// The participants
        /// </summary>
        public List<string> Participants { get; set; }

        /// <summary>
        /// Construct a new CreateSessionOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        public CreateSessionOptions(string pathServiceSid)
        {
            PathServiceSid = pathServiceSid;
            Participants = new List<string>();
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (UniqueName != null)
            {
                p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
            }

            if (Ttl != null)
            {
                p.Add(new KeyValuePair<string, string>("Ttl", Ttl.Value.ToString()));
            }

            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }

            if (Participants != null)
            {
                p.AddRange(Participants.Select(prop => new KeyValuePair<string, string>("Participants", prop)));
            }

            return p;
        }
    }

    /// <summary>
    /// Delete a specific Session.
    /// </summary>
    public class DeleteSessionOptions : IOptions<SessionResource> 
    {
        /// <summary>
        /// Service Sid.
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// A string that uniquely identifies this Session.
        /// </summary>
        public string PathSid { get; }

        /// <summary>
        /// Construct a new DeleteSessionOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSid"> A string that uniquely identifies this Session. </param>
        public DeleteSessionOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathSid = pathSid;
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
    /// Update a specific Session.
    /// </summary>
    public class UpdateSessionOptions : IOptions<SessionResource> 
    {
        /// <summary>
        /// Service Sid.
        /// </summary>
        public string PathServiceSid { get; }
        /// <summary>
        /// A string that uniquely identifies this Session.
        /// </summary>
        public string PathSid { get; }
        /// <summary>
        /// A unique, developer assigned name of this Session.
        /// </summary>
        public string UniqueName { get; set; }
        /// <summary>
        /// How long will this session stay open, in seconds.
        /// </summary>
        public int? Ttl { get; set; }
        /// <summary>
        /// The Status of this Session
        /// </summary>
        public SessionResource.StatusEnum Status { get; set; }
        /// <summary>
        /// The participants
        /// </summary>
        public List<string> Participants { get; set; }

        /// <summary>
        /// Construct a new UpdateSessionOptions
        /// </summary>
        ///
        /// <param name="pathServiceSid"> Service Sid. </param>
        /// <param name="pathSid"> A string that uniquely identifies this Session. </param>
        public UpdateSessionOptions(string pathServiceSid, string pathSid)
        {
            PathServiceSid = pathServiceSid;
            PathSid = pathSid;
            Participants = new List<string>();
        }

        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (UniqueName != null)
            {
                p.Add(new KeyValuePair<string, string>("UniqueName", UniqueName));
            }

            if (Ttl != null)
            {
                p.Add(new KeyValuePair<string, string>("Ttl", Ttl.Value.ToString()));
            }

            if (Status != null)
            {
                p.Add(new KeyValuePair<string, string>("Status", Status.ToString()));
            }

            if (Participants != null)
            {
                p.AddRange(Participants.Select(prop => new KeyValuePair<string, string>("Participants", prop)));
            }

            return p;
        }
    }

}