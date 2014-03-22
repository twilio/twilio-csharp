using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple
{
    public enum ParameterType
    {
        //Cookie,
        GetOrPost,
        UrlSegment,
        HttpHeader,
        //RequestBody,
        QueryString
    }

    /// <summary>
    /// Status for responses (surprised?)
    /// </summary>
    public enum ResponseStatus
    {
        None,
        Completed,
        Error,
        TimedOut,
        Aborted
    }

    /// <summary>
    /// HTTP method to use when making requests
    /// </summary>
    public enum Method
    {
        GET,
        POST,
        PUT,
        DELETE,
        HEAD,
        OPTIONS,
        PATCH
    }

}
