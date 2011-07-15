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
	public class ValidateRequestAttribute : ActionFilterAttribute
	{
		public string AuthToken { get; set; }
		public string UrlOverride { get; set; }

		public ValidateRequestAttribute(string authToken)
		{
			AuthToken = authToken;
		}

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
				filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
				filterContext.HttpContext.Response.SuppressContent = true;
				filterContext.HttpContext.ApplicationInstance.CompleteRequest();
			}
			
			base.OnActionExecuting(filterContext);
		}
	}
}