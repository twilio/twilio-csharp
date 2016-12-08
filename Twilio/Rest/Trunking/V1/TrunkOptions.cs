using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Trunking.V1 
{

    public class FetchTrunkOptions : IOptions<TrunkResource> 
    {
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchTrunkOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public FetchTrunkOptions(string sid)
        {
            Sid = sid;
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

    public class DeleteTrunkOptions : IOptions<TrunkResource> 
    {
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteTrunkOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public DeleteTrunkOptions(string sid)
        {
            Sid = sid;
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

    public class CreateTrunkOptions : IOptions<TrunkResource> 
    {
        public string FriendlyName { get; set; }
        public string DomainName { get; set; }
        public Uri DisasterRecoveryUrl { get; set; }
        public Twilio.Http.HttpMethod DisasterRecoveryMethod { get; set; }
        public string Recording { get; set; }
        public bool? Secure { get; set; }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (DomainName != null)
            {
                p.Add(new KeyValuePair<string, string>("DomainName", DomainName));
            }
            
            if (DisasterRecoveryUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("DisasterRecoveryUrl", DisasterRecoveryUrl.ToString()));
            }
            
            if (DisasterRecoveryMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("DisasterRecoveryMethod", DisasterRecoveryMethod.ToString()));
            }
            
            if (Recording != null)
            {
                p.Add(new KeyValuePair<string, string>("Recording", Recording));
            }
            
            if (Secure != null)
            {
                p.Add(new KeyValuePair<string, string>("Secure", Secure.Value.ToString()));
            }
            
            return p;
        }
    }

    public class ReadTrunkOptions : ReadOptions<TrunkResource> 
    {
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

    public class UpdateTrunkOptions : IOptions<TrunkResource> 
    {
        public string Sid { get; }
        public string FriendlyName { get; set; }
        public string DomainName { get; set; }
        public Uri DisasterRecoveryUrl { get; set; }
        public Twilio.Http.HttpMethod DisasterRecoveryMethod { get; set; }
        public string Recording { get; set; }
        public bool? Secure { get; set; }
    
        /// <summary>
        /// Construct a new UpdateTrunkOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public UpdateTrunkOptions(string sid)
        {
            Sid = sid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (FriendlyName != null)
            {
                p.Add(new KeyValuePair<string, string>("FriendlyName", FriendlyName));
            }
            
            if (DomainName != null)
            {
                p.Add(new KeyValuePair<string, string>("DomainName", DomainName));
            }
            
            if (DisasterRecoveryUrl != null)
            {
                p.Add(new KeyValuePair<string, string>("DisasterRecoveryUrl", DisasterRecoveryUrl.ToString()));
            }
            
            if (DisasterRecoveryMethod != null)
            {
                p.Add(new KeyValuePair<string, string>("DisasterRecoveryMethod", DisasterRecoveryMethod.ToString()));
            }
            
            if (Recording != null)
            {
                p.Add(new KeyValuePair<string, string>("Recording", Recording));
            }
            
            if (Secure != null)
            {
                p.Add(new KeyValuePair<string, string>("Secure", Secure.Value.ToString()));
            }
            
            return p;
        }
    }

}