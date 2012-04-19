using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Specifies a client identifier to dial.
    /// </summary>
    /// <remarks>
    /// You can use multiple &lt;Client&gt; nouns within a &lt;Dial&gt; verb to simultaneously 
    /// attempt a connection with many clients at once. The first client to accept the incoming
    /// connection is connected to the call and the other connection attempts are canceled. 
    /// If you want to connect with multiple other clients simultaneously, read about 
    /// the &lt;Conference&gt; noun.  The client identifier currently may only contain 
    /// alpha-numberic and underscore characters.
    /// </remarks>
	public class Client : ElementBase, IDialNoun
	{
		public Client(string clientName)
		{
			Element = new XElement("Client", clientName);
		}
	}
}