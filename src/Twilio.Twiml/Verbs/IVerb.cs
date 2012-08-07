using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Twilio.TwiML.Verbs
{
    /// <summary>
    /// Represents a TwiML Verb
    /// </summary>
	public interface IVerb
	{
		void Add(IVerb child);
		IVerb With(IVerb child);
	}
}
