using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    public class RestRequest
    {
        public RestRequest()
        {
            Parameters = new List<Parameter>();

            OnBeforeDeserialization = r => { };

            this.Method = "GET";
        }

        public RestRequest(string method)
            : this()
        {
            this.Method = method;
        }

        public string Method { get; set; }
        public string Resource { get; set; }
        public List<Parameter> Parameters { get; set; }
        public string DateFormat { get; set; }

        public Action<IRestResponse> OnBeforeDeserialization { get; set; }
    }
}
