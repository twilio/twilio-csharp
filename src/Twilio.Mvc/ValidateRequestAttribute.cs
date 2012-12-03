using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Net;
using System.Web;

namespace Twilio.TwiML.Mvc
{
    /// <summary>
    /// Represents an attribute that is used to prevent forgery of a request.
    /// </summary>
	public class ValidateRequestAttribute : ActionFilterAttribute
	{
		public string AuthToken { get; set; }
		public string UrlOverride { get; set; }

        /// <summary>
        /// Initializes a new instance of the ValidateRequestAttribute class.
        /// </summary>
        /// <param name="authToken"></param>
		public ValidateRequestAttribute(string authToken)
		{
			AuthToken = authToken;
		}

        /// <summary>
        /// Initializes a new instance of the ValidateRequestAttribute class.
        /// </summary>
        /// <param name="authToken"></param>
        /// <param name="urlOverride"></param>
		public ValidateRequestAttribute(string authToken, string urlOverride)
		{
			AuthToken = authToken;
			UrlOverride = urlOverride;
		}

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var validator = new RequestValidator();

            var context = ((HttpApplication)filterContext.HttpContext.GetService(typeof(HttpApplication))).Context;

            if (!validator.IsValidRequest(context, AuthToken, UrlOverride))
            {
                //This did not actually stop the Action execution, so its been replaced by the Result below
                //filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                //filterContext.HttpContext.Response.SuppressContent = true;
                //filterContext.HttpContext.ApplicationInstance.CompleteRequest();

                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.Forbidden);
            }

            base.OnActionExecuting(filterContext);
        }

    }
}