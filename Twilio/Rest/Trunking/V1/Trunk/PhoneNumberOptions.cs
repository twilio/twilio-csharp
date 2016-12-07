using System;
using System.Collections.Generic;
using Twilio.Base;

namespace Twilio.Rest.Trunking.V1.Trunk 
{

    public class FetchPhoneNumberOptions : IOptions<PhoneNumberResource> 
    {
        public string TrunkSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchPhoneNumberOptions
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="sid"> The sid </param>
        public FetchPhoneNumberOptions(string trunkSid, string sid)
        {
            TrunkSid = trunkSid;
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

    public class DeletePhoneNumberOptions : IOptions<PhoneNumberResource> 
    {
        public string TrunkSid { get; }
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeletePhoneNumberOptions
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="sid"> The sid </param>
        public DeletePhoneNumberOptions(string trunkSid, string sid)
        {
            TrunkSid = trunkSid;
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

    public class CreatePhoneNumberOptions : IOptions<PhoneNumberResource> 
    {
        public string TrunkSid { get; }
        public string PhoneNumberSid { get; }
    
        /// <summary>
        /// Construct a new CreatePhoneNumberOptions
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        /// <param name="phoneNumberSid"> The phone_number_sid </param>
        public CreatePhoneNumberOptions(string trunkSid, string phoneNumberSid)
        {
            TrunkSid = trunkSid;
            PhoneNumberSid = phoneNumberSid;
        }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (PhoneNumberSid != null)
            {
                p.Add(new KeyValuePair<string, string>("PhoneNumberSid", PhoneNumberSid));
            }
            
            return p;
        }
    }

    public class ReadPhoneNumberOptions : ReadOptions<PhoneNumberResource> 
    {
        public string TrunkSid { get; }
    
        /// <summary>
        /// Construct a new ReadPhoneNumberOptions
        /// </summary>
        ///
        /// <param name="trunkSid"> The trunk_sid </param>
        public ReadPhoneNumberOptions(string trunkSid)
        {
            TrunkSid = trunkSid;
        }
    
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

}