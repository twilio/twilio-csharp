using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Converters;

namespace Twilio.Rest.Monitor.V1 
{

    public class FetchAlertOptions : IOptions<AlertResource> 
    {
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new FetchAlertOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public FetchAlertOptions(string sid)
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

    public class DeleteAlertOptions : IOptions<AlertResource> 
    {
        public string Sid { get; }
    
        /// <summary>
        /// Construct a new DeleteAlertOptions
        /// </summary>
        ///
        /// <param name="sid"> The sid </param>
        public DeleteAlertOptions(string sid)
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

    public class ReadAlertOptions : ReadOptions<AlertResource> 
    {
        public string LogLevel { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    
        /// <summary>
        /// Generate the necessary parameters
        /// </summary>
        public override List<KeyValuePair<string, string>> GetParams()
        {
            var p = new List<KeyValuePair<string, string>>();
            if (LogLevel != null)
            {
                p.Add(new KeyValuePair<string, string>("LogLevel", LogLevel));
            }
            
            if (StartDate != null)
            {
                p.Add(new KeyValuePair<string, string>("StartDate", StartDate.Value.ToString("yyyy-MM-dd")));
            }
            
            if (EndDate != null)
            {
                p.Add(new KeyValuePair<string, string>("EndDate", EndDate.Value.ToString("yyyy-MM-dd")));
            }
            
            if (PageSize != null)
            {
                p.Add(new KeyValuePair<string, string>("PageSize", PageSize.ToString()));
            }
            
            return p;
        }
    }

}