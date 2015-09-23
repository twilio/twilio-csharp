using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    public class Task : ElementBase, IQueueNoun
    {
        /// <summary>
        /// Initializes a new instance of the Body class.
        /// </summary>
        /// <param name="body"></param>
        public Task(string taskattributes)
        {
            Element = new XElement("Task", taskattributes);

            AllowedAttributes.Add("priority");
            AllowedAttributes.Add("timeout");
        }

        /// <summary>
        /// Initializes a new instance of the Conference class.
        /// </summary>
        /// <param name="taskattributes">json attributes of the task</param>
        /// <param name="attributes">attributes of the task (priority, timeout)</param>
        public Task(string taskattributes, object attributes)
            : this(taskattributes)
        {
            AddAttributesFromObject(attributes);
        }
    }
}
