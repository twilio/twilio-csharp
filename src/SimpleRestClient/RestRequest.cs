using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple
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

        public void AddParameter(string name, string value, ParameterType type)
        {
            this.Parameters.Add(new Parameter() { Name = name, Value = value, Type = type });
        }

        public void AddParameter(string name, object value)
        {
            this.Parameters.Add(new Parameter { Name = name, Value = value, Type = ParameterType.GetOrPost });
        }

        public void AddUrlSegment(string name, string value)
        {
            this.Parameters.Add(new Parameter() { Name = name, Value = value, Type=ParameterType.UrlSegment });
        }

        public Action<RestResponse> OnBeforeDeserialization { get; set; }
    }
}
