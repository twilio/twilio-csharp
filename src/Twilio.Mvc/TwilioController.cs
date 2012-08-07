using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Twilio.TwiML.Mvc
{
    /// <summary>
    /// Extends the standard base controller to simplify returning a TwiML response
    /// </summary>
	public class TwilioController : Controller
	{
        /// <summary>
        /// Returns a property formatted TwiML response
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
		public TwiMLResult TwiML(TwilioResponse response)
		{
			return new TwiMLResult(response);
		}
	}
}
