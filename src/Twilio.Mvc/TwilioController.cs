using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Twilio.TwiML.Mvc
{
	public class TwilioController : Controller
	{
		public TwiMLResult TwiML(TwilioResponse response)
		{
			return new TwiMLResult(response);
		}
	}
}
