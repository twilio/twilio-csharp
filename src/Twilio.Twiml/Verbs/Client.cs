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
        /// <summary>
        /// Initializes a new instance of the Client class
        /// </summary>
        /// <param name="clientName">The name of the client</param>
		public Client(string clientName)
		{
			Element = new XElement("Client", clientName);
            AllowedAttributes.Add("url");
            AllowedAttributes.Add("method");
		}

        /// <summary>
        /// Initializes a new instance of the Client class using the specified client name and attributes
		/// </summary>
		/// <param name="number"></param>
		/// <param name="attributes"></param>
        public Client(string clientName, object attributes) : this(clientName)
		{
			AddAttributesFromObject(attributes);
		}
	}
}