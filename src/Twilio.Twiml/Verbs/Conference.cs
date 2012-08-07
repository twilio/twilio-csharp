using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Twilio.TwiML
{
    /// <summary>
    /// Allows you to connect to a conference room.
    /// </summary>
    /// <remarks>
    /// Much like how the &lt;Number&gt; noun allows you to connect to another phone 
    /// number, the &lt;Conference&gt; noun allows you to connect to a named conference
    /// room and talk with the other callers who have also connected to that room.  
    /// The name of the room is up to you and is namespaced to your account. This means 
    /// that any caller who joins 'room1234' via your account will end up in the same 
    /// conference room, but callers connecting through different accounts would not. 
    /// The maximum number of participants in a single Twilio conference room is 40.  
    /// By default, Twilio conference rooms enable a number of useful features used by 
    /// business conference bridges:
    /// Conferences do not start until at least two participants join.
    /// While waiting, customizable background music is played.
    /// When participants join and leave, notification sounds are played to inform the other 
    /// participants.
    /// You can configure or disable each of these features based on your particular needs.
    /// </remarks>
	public class Conference : ElementBase, IDialNoun
	{
        /// <summary>
        /// Initializes a new instance of the Conference class.
        /// </summary>
		public Conference()
		{
			Element = new XElement("Conference");

			AllowedAttributes.Add("muted");
			AllowedAttributes.Add("beep");
			AllowedAttributes.Add("waitUrl");
			AllowedAttributes.Add("waitMethod");
			AllowedAttributes.Add("startConferenceOnEnter");
			AllowedAttributes.Add("endConferenceOnExit");
		}

        /// <summary>
        /// Initializes a new instance of the Conference class.
        /// </summary>
        /// <param name="room">The name of the conference room</param>
        public Conference(string room)
            : this()
		{
			Element = new XElement("Conference", room);
		}

        /// <summary>
        /// Initializes a new instance of the Conference class.
        /// </summary>
        /// <param name="room">The name of the conference room</param>
        ///<param name="attributes"></param>
        public Conference(string room, object attributes)
            : this(room)
		{
			AddAttributesFromObject(attributes);
		}
	}
}
