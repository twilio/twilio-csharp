using System;
using System.Collections.Generic;
using System.Text;

namespace Simple
{
    /// <summary>
    /// Possible types of HTTP parameters that can be included in a request
    /// </summary>
    public enum ParameterType
    {
        /// <summary>
        /// A generic parameter included in a GET request (as a querystring value) or POST request (as a form encoded value)
        /// </summary>
        GetOrPost,
        /// <summary>
        /// Substituted for a specific portion of a URL
        /// </summary>
        UrlSegment,
        /// <summary>
        /// An HTTP header
        /// </summary>
        HttpHeader,
        /// <summary>
        /// A querystring value.
        /// </summary>
        QueryString
    }

    /// <summary>
    /// Status for responses (surprised?)
    /// </summary>
    public enum ResponseStatus
    {
        /// <summary>
        /// No response.  Normally the default value.
        /// </summary>
        None,
        /// <summary>
        /// The request completed without any transport error
        /// </summary>
        Completed,
        /// <summary>
        /// The request likely encountered a transport error
        /// </summary>
        Error,
        /// <summary>
        /// The request likely encountered an asyncronous task timeout
        /// </summary>
        TimedOut,
        /// <summary>
        /// The request was canceled
        /// </summary>
        Aborted
    }

    /// <summary>
    /// HTTP method to use when making requests
    /// </summary>
    public enum Method
    {
        /// <summary>
        /// 
        /// </summary>
        GET,
        /// <summary>
        /// 
        /// </summary>
        POST,
        /// <summary>
        /// 
        /// </summary>
        PUT,
        /// <summary>
        /// 
        /// </summary>
        DELETE,
        /// <summary>
        /// 
        /// </summary>
        HEAD,
        /// <summary>
        /// 
        /// </summary>
        OPTIONS,
        /// <summary>
        /// 
        /// </summary>
        PATCH
    }

}
