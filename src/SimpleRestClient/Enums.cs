using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio
{
    public enum ParameterType
    {
        Cookie,
        GetOrPost,
        UrlSegment,
        HttpHeader,
        RequestBody,
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
}
