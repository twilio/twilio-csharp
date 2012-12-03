using System;
using System.Net;
using System.Web.Mvc;

namespace Twilio
{
    public class HttpStatusCodeResult : ActionResult
    {
        public HttpStatusCodeResult(HttpStatusCode statusCode)
        {
            StatusCode = (int)statusCode;
        }

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
