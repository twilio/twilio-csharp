using System;
using System.Collections.Generic;
using System.Text;

namespace Simple
{
    /// <summary>
    /// Holds the parameters of an individual request
    /// </summary>
    public class RestRequest
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public RestRequest()
        {
            Parameters = new List<Parameter>();

            OnBeforeDeserialization = r => { };

            this.Method = "GET";
        }

        /// <summary>
        /// Initializes the request with a specific HTTP Method
        /// </summary>
        /// <param name="method"></param>
        public RestRequest(string method)
            : this()
        {
            this.Method = method;
        }

        /// <summary>
        /// Initializes the request with a specific HTTP Method
        /// </summary>
        /// <param name="method"></param>
        public RestRequest(Method method)
            : this()
        {
            this.Method = method.ToString();
        }

        /// <summary>
        /// Gets or sets the HTTP Method used to make this request
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets the REST resource to request
        /// </summary>
        public string Resource { get; set; }

        /// <summary>
        /// Gets or sets a collection of parameters to include in this request
        /// </summary>
        public List<Parameter> Parameters { get; set; }

        /// <summary>
        /// Gets or sets the format string to use when formatting datetime values
        /// </summary>
        public string DateFormat { get; set; }

        /// <summary>
        /// Add a parameter to this request
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        public void AddParameter(string name, string value, ParameterType type)
        {
            this.Parameters.Add(new Parameter() { Name = name, Value = value, Type = type });
        }

        /// <summary>
        /// Add a GetOrPost parameter to this request
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void AddParameter(string name, object value)
        {
            this.Parameters.Add(new Parameter { Name = name, Value = value, Type = ParameterType.GetOrPost });
        }

        /// <summary>
        /// Add a UrlSegmenet parameter to this request
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void AddUrlSegment(string name, string value)
        {
            this.Parameters.Add(new Parameter() { Name = name, Value = value, Type=ParameterType.UrlSegment });
        }

        /// <summary>
        /// Method called prior to response content deserialization.  Provides an opportunity to change the response content.
        /// </summary>
        public Action<RestResponse> OnBeforeDeserialization { get; set; }
    }
}
