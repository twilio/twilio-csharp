using System;
using System.Net;
using System.Web.Mvc;

namespace Twilio
{
    /// <summary>
    /// Returns an HTTP status code
    /// </summary>
    public class HttpStatusCodeResult : ActionResult
    {
        /// <summary>
        /// Creates a new instance of the class with a specific status code
        /// </summary>
        /// <param name="statusCode">The status code to return</param>
        public HttpStatusCodeResult(HttpStatusCode statusCode)
        {
            StatusCode = (int)statusCode;
        }

        /// <summary>
        /// Gets the status code for this instance
        /// </summary>
        public int StatusCode { get; private set; }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            context.HttpContext.Response.StatusCode = StatusCode;
        }
    }
}
