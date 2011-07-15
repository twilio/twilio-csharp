using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio.TwiML.Verbs
{
	public interface IVerb
	{
		void Add(IVerb child);
		IVerb With(IVerb child);
	}
}
