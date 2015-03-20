using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    public class TaskAttributes : ElementBase, IQueueNoun
    {
        /// <summary>
        /// Initializes a new instance of the Body class.
        /// </summary>
        /// <param name="body"></param>
		public TaskAttributes(string taskattributes)
		{
			Element = new XElement("TaskAttributes", taskattributes);
		}
    }
}
